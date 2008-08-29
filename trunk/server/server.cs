using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Serialization;

using RPUsers;

namespace RPServer
{
    public class Setup
    {
        public List<string> hosts = new List<string>();
        public string templateDir = string.Empty;
        public string replyEmail = string.Empty;
        public string serviceName = string.Empty;
        public string userDir = string.Empty;
        public string md5Salt = string.Empty;
        public string smtpServer = string.Empty;
        public string smtpUsername = string.Empty;
        public string smtpPassword = string.Empty;
    }

    public class Connection 
    {
        public Connection ( HttpListenerContext c )
        {
            context = c;

            HttpListenerRequest request = context.Request;

            arguments.Clear();

            // get our base keys
            if(request.QueryString.HasKeys())
            {
                for (int i = 0; i < request.QueryString.Count; i++ )
                {
                    string name =  request.QueryString.GetKey(i);
                    string value = string.Empty;

                    if (request.QueryString.GetValues(i).GetLength(0) > 0)
                        value = request.QueryString.GetValues(i)[0];

                    arguments.Add(name,value);
                }
             }
        }

        public string getArg ( string key )
        {
            if (arguments.ContainsKey(key))
                return arguments[key];
            return null;
        }

        public HttpListenerContext context;
        Dictionary<string,string>   arguments = new Dictionary<string,string>();
    }

    public class Templates
    {
        string readFile ( string path, string file )
        {
            string ret = null;

            FileInfo f = new FileInfo(path + file);
            if (f.Exists)
            {
                StreamReader stream = f.OpenText();
                ret = stream.ReadToEnd();
                stream.Close();
            }
            return ret;
        }

        public Templates( string dir )
        {
            // load em up
            httpHeader = readFile(dir,"httpHeader.html");
            httpFooter = readFile(dir, "httpFooter.html");

            mainPage = readFile(dir,"mainPage.html");
            newUserSetup = readFile(dir,"newUserSetup.html");
            newUserError = readFile(dir,"newUserError.html");
            newUserComplete = readFile(dir,"newUserComplete.html");
            newUserVerified = readFile(dir, "newUserVerified.html");

            mail = readFile(dir,"mail.txt");
        }

        public bool valid ( )
        {
            if (httpHeader == null)
                return false;
            if (httpFooter == null)
                return false;
            if (mainPage == null)
                return false;
            if (newUserSetup == null)
                return false;
            if (newUserError == null)
                return false;
            if (newUserComplete == null)
                return false;
            if (newUserVerified == null)
                return false;
            if (mail == null)
                return false;

            return true;
        }

        public string httpHeader = string.Empty;
        public string httpFooter = string.Empty;
        public string mainPage = string.Empty;
        public string newUserSetup = string.Empty;
        public string newUserError = string.Empty;
        public string newUserComplete = string.Empty;
        public string newUserVerified = string.Empty;

        public string mail = string.Empty;

    }

    public class Server
    {
        public Setup setup = new Setup();
        Templates templates;

        List<string> authedSessions = new List<string>();

        Usermanager users = new Usermanager();

        DirectoryInfo usersDir;

        public string publicURL = "http://localhost";

        private void writeToContext ( string text, HttpListenerContext context )
        {
            context.Response.OutputStream.Write(System.Text.ASCIIEncoding.ASCII.GetBytes(text), 0, text.Length);
        }

        private void writeToContext ( string text, Connection connection )
        {
            writeToContext(text,connection.context);
        }

        private void writeHTTPHeader ( Connection connection )
        {
            writeHTTPHeader(connection, "");
        }

        private void writeHTTPHeader(Connection connection, string title)
        {
            if(templates.httpHeader != null)
            {
                connection.context.Response.ContentType = "text/html";
                string header = templates.httpHeader.Replace("[TITLE]", title);
                writeToContext(header, connection.context);
            }
            else
                connection.context.Response.ContentType = "text/plain";
        }

        private void writeHTTPFooter(Connection connection)
        {
            if (templates.httpFooter != null)
                writeToContext(templates.httpFooter, connection.context);
        }

        private bool fatalError ( string error, Connection connection )
        {
            writeHTTPHeader(connection, "Fatal Error!");
            writeToContext("<h1>" + error + "</h1>", connection);
            writeHTTPFooter(connection);
            return true;
        }

        public Server( string[] args)
        {
            string configFile;
            string argConf = string.Empty;

            // load the setup from the args
            if (args.Length > 0)
                configFile = argConf = args[0];
            else
                configFile = "./config.xml";

            FileInfo conf = new FileInfo(configFile);
            if ( conf.Exists )
            {
                XmlSerializer xml = new XmlSerializer(typeof(Setup));

                FileStream fs = conf.OpenRead();
                StreamReader file = new StreamReader(fs);

                setup = (Setup)xml.Deserialize(file);
                file.Close();
                fs.Close();
            }
            else
            {
                // default setups?
                setup.hosts.Add("http://localhost:88/");
                setup.templateDir = "./templates/";
                setup.replyEmail = "nobody@localhost.com";
                setup.serviceName = "RPKit";
                setup.md5Salt = "adsfasdfjasl;dfj234q23412234124v";
                setup.smtpServer = "localhost";

                // dirs
                setup.userDir = "./users/";

                if (argConf.Length > 0)// try to save out the conf if they wanted one
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Setup));

                    FileStream fs = conf.OpenWrite();
                    StreamWriter file = new StreamWriter(fs);

                    xml.Serialize(file, setup);
                    file.Close();
                    fs.Close();
                }
            }

            // load all the databases
            if(setup.hosts.Count > 0)
                publicURL = setup.hosts[0];

            usersDir = new DirectoryInfo(setup.userDir);
            users.load(usersDir);
            templates = new Templates(setup.templateDir);
        }

        public void update ( )
        {

        }

        private bool fieldValid ( string text )
        {
            if (text == null || text.Length == 0)
                return false;
            return true;
        }

        private void newUser ( Connection connection )
        {
            writeHTTPHeader(connection);

            string mode = connection.getArg("mode");
            if ( mode == "adduser")
            {
                string username = connection.getArg("username");
                string password = connection.getArg("password");
                string password2 = connection.getArg("password2");
                string email = connection.getArg("email");
                string email2 = connection.getArg("email2");

                // verify the info
                if (!fieldValid(username) || !fieldValid(password) || !fieldValid(email) )
                {
                    writeToContext(templates.newUserError.Replace("[ERROR]","Required info was missing!"),connection);
                    return;
                }

                if (users.getUser(username) != null)
                {
                    writeToContext(templates.newUserError.Replace("[ERROR]", "Username is taken!"), connection);
                    return;
                }

                if ( password != password2)
                {
                    writeToContext(templates.newUserError.Replace("[ERROR]", "Passwords do not match!"), connection);
                    return;
                }

                if ( password.Length < 6)
                {
                    writeToContext(templates.newUserError.Replace("[ERROR]", "Passwords too short!"), connection);
                    return;
                }

                if ( !email.Contains("@") || !email.Contains("."))
                {
                    writeToContext(templates.newUserError.Replace("[ERROR]", "Invalid E-mail!"), connection);
                    return;
                }

                if ( email != email2)
                {
                    writeToContext(templates.newUserError.Replace("[ERROR]", "E-Mail does not match!"), connection);
                    return;
                }

                // all is good, make a user and have them verify
                Random rng = new Random();

                string verifyKey = string.Empty;

                for (int i = 0; i < 5; i++)
                    verifyKey += rng.Next().ToString();

                User user = new User();
                user.email = email;
                user.username = username;
                user.verified = false;
                user.emailKey = verifyKey;
                MD5 md5 = MD5.Create();
                md5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(password + setup.md5Salt));

                user.passwordHash = md5.GetHashCode().ToString();

                users.adduser(user);
                users.saveUser(user, usersDir);

                string verifyLink = publicURL + "?action=adduser&mode=verify&key=" + verifyKey + "&user=" + user.GUID.ToString();

                string body = templates.mail.Replace("[SERVICE]", setup.serviceName);
                body = body.Replace("[URL]", publicURL);
                body = body.Replace("[USER]", username);
                body = body.Replace("[VERIFY]", verifyLink);

                MailAddress from = new MailAddress(setup.replyEmail);
                MailAddress to = new MailAddress(email);

                MailMessage message = new MailMessage(from, to);
                message.Subject = "Registration with " + setup.serviceName  + "(" + publicURL + ")"; 
                message.Body = body;

                SmtpClient mailer = new SmtpClient(setup.smtpServer);
                if (setup.smtpUsername.Length > 0 && setup.smtpPassword.Length > 0)
                {
                    mailer.UseDefaultCredentials = false;
                    mailer.Credentials = new NetworkCredential(setup.smtpUsername, setup.smtpPassword);
                }
                mailer.Send(message);

                writeToContext(templates.newUserComplete,connection);
            }
            else if ( mode == "verify" )
            {
                // this has to come form the verifyer

                string GUID = connection.getArg("user");
                string token = connection.getArg("key");

                User user = users.getUser(int.Parse(GUID));
                if (user == null || user.verified || token.Length <= 0)
                {
                    writeToContext(templates.newUserError.Replace("[ERROR]", "Invalid Request!"), connection);
                    return;
                }

                if ( user.emailKey == token )
                    writeToContext(templates.newUserVerified.Replace("[URL]", publicURL), connection);
                else
                    writeToContext(templates.newUserError.Replace("[ERROR]", "Data mismatch!"), connection);
            }
            else // new user form
            {
                string page = templates.newUserSetup.Replace("[SERVICE]", setup.serviceName);
                page = page.Replace("[URL]", publicURL);

                writeToContext(page, connection);
            }

            writeHTTPFooter(connection);
        }

        private void login( Connection connection, string session )
        {
            writeHTTPHeader(connection);

            string action = connection.getArg("action");

            if (action == "login")
            {
                // auth
            }
            else
            {
                //login page
                string mainpage = templates.mainPage.Replace("[SERVICE]",setup.serviceName);
                mainpage = mainpage.Replace("[URL]", publicURL);
                writeToContext(mainpage, connection);
            }
            writeHTTPFooter(connection);
        }

        private bool handleAuthedQuery( Connection connection, string session )
        {
            writeHTTPHeader(connection);

            string action = connection.getArg("action");

            if (action == "stop")
            {
                writeToContext("ok, shutdown!", connection);
                writeHTTPFooter(connection);
                return true;
            }

            writeToContext("Hello World!", connection);
            writeHTTPFooter(connection);
            return false;
        }
        
        private bool isAuthedSession ( string session )
        {
            if (session == string.Empty)
                return false;

            return authedSessions.Contains(session);
        }

        private bool handleAppQuery ( Connection connection )
        {
            // parse out the message in a nice fast XML way
            return false;
        }

        public bool handleURL ( HttpListenerContext context )
        {
            Connection connection = new Connection(context);
            if (!templates.valid())
                return fatalError("Templates not valid",connection);

            string session = string.Empty;

            string action = connection.getArg("action");
            if (connection.getArg("type") == "rpkit")
                return handleAppQuery(connection);

            // new user dosnt' need a session
            if (action == "newuser")
            {
                newUser(connection);
                return false;
            }
            
            // see if we have a session cookie
            foreach (Cookie c in context.Request.Cookies)
            {
                if (c.Name == "session")
                    session = c.Value;
            }

            // if there is no session, 
            if (!isAuthedSession(session))
            {
                login(connection,session);
                return false;
            }

            return handleAuthedQuery(connection, session);
        }
    }
}