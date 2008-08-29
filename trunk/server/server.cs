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
            newUserSetup = readFile(dir,"newUSerSetup.html");
            newUserError = readFile(dir,"newUserError.html");
            newUserComplete = readFile(dir,"newUserComplete.html");

            mail = readFile(dir,"mail.txt");
         }


        public string httpHeader = string.Empty;
        public string httpFooter = string.Empty;
        public string mainPage = string.Empty;
        public string newUserSetup = string.Empty;
        public string newUserError = string.Empty;
        public string newUserComplete = string.Empty;

        public string mail;

    }

    public class Server
    {
        public Setup setup = new Setup();

        List<string> authedSessions = new List<string>();

        Usermanager users = new Usermanager();

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
            connection.context.Response.ContentType = "text/html";
            writeToContext("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01//EN\" \"http://www.w3.org/TR/html4/strict.dtd\">", connection.context);
            writeToContext("<html><head>", connection.context);
            writeToContext("</head><body>", connection.context);
        }

        private void writeHTTPHeader(Connection connection, string title)
        {
            connection.context.Response.ContentType = "text/html";
            writeToContext("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01//EN\" \"http://www.w3.org/TR/html4/strict.dtd\">", connection.context);
            writeToContext("<html><head>", connection.context);
            if (title.Length > 0)
                writeToContext("<title>" + title + "</title", connection.context);
            writeToContext("</head><body>", connection.context);
        }

        private void writeHTTPFooter(Connection connection)
        {
            writeToContext("</body></html>", connection.context);
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

            users.load(new DirectoryInfo(setup.userDir));
        }

        public void update ( )
        {

        }

        private bool fieldValid ( string text )
        {
            if (text != null || text.Length == 0)
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
                if (!fieldValid(username) || !fieldValid(password) || fieldValid(email) )
                {
                    writeToContext("<h2>Required info was missing!</h2>",connection);
                    return;
                }

                if (users.getUser(username) != null)
                {
                    writeToContext("<h2>Username is taken!</h2>",connection);
                    return;
                }

                if ( password != password2)
                {
                    writeToContext("<h2>Passwords do not match</h2>",connection);
                    return;
                }

                if ( password.Length < 6)
                {
                    writeToContext("<h2>Passwords too short</h2>",connection);
                    return;
                }

                if ( !email.Contains("@") || !email.Contains("."))
                {
                    writeToContext("<h2>Invalid E-mail</h2>",connection);
                    return;
                }

                if ( email != email2)
                {
                    writeToContext("<h2>E-Mail does not match</h2>",connection);
                    return;
                }

                // all is good, make a user and have them verify

                Random rng = new Random();

                string verifyKey = string.Empty;

                for ( int i = 0; i < 5; i++)
                    verifyKey += rng.Next().ToString();

                SmtpClient mailer = new SmtpClient();
                string subject = "Registration with " + publicURL;
                string body = "Thanks for registering, click this link to verify your address\n";
                body += publicURL + "?action=adduser&mode=verify&key=" + verifyKey;
                body += "\n<a href=\"" + publicURL + "?action=adduser&mode=verify&key=" + verifyKey + "\">Here</a>";

                mailer.Send(setup.replyEmail, email, subject, body);

                writeToContext("<h2>Thank you for registering, you have been sent a confirmation e-mail, click the link to verify your account</h2>",connection);

                User user = new User();
                user.email = email;
                user.username = username;
                user.verified = false;
                user.emailKey = verifyKey;

                MD5 md5 = MD5.Create();
                md5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(password));

                user.passwordHash = md5.GetHashCode().ToString();;
            }
            else if ( mode == "verify" )
            {
                // this has to come form the verifyer
            }
            else // new user form
            {
                writeToContext("</br><h2>Please fill out the following information</h2",connection);
                writeToContext("<form name=\"input\" action=\"?\" method=\"put\">",connection);

                writeToContext("<input type=\"hidden\" name=\"action\" value=\"newuser\">",connection);
                writeToContext("<input type=\"hidden\" name=\"mode\" value=\"adduser\">",connection);
                writeToContext("</br>Username<input type=\"text\" name=\"username\">",connection);
                writeToContext("</br>E-mail<input type=\"text\" name=\"email\">",connection);
                writeToContext("</br>E-mail(confirm)<input type=\"text\" name=\"email2\">",connection);
                writeToContext("</br>Password (6 character min)<input password=\"text\" name=\"password\">",connection);
                writeToContext("</br>Password(confirm)<input password=\"text\" name=\"password2\">",connection);
                writeToContext("</form></br>", connection);
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
                writeToContext("</br><h2>Please Login</h2",connection);
                writeToContext("<form name=\"input\" action=\"?\" method=\"put\">",connection);

                writeToContext("<input type=\"hidden\" name=\"action\" value=\"login\">",connection);
                writeToContext("</br>Username<input type=\"text\" name=\"username\">",connection);
                writeToContext("</br>Password<input password=\"text\" name=\"password\">",connection);
                writeToContext("</form></br>", connection);
                writeToContext("<a href=\"?action=newuser\">New User?</a>",connection);
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