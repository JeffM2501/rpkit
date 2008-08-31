using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Web;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Serialization;
using System.Threading;
using System.ComponentModel;


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
        public int smtpPort = -1;
        public string smtpUsername = string.Empty;
        public string smtpPassword = string.Empty;
        public bool useSSL = false;
        public bool log = false;
        public string favicon = string.Empty;
    }

    public class Templates
    {
        string readFile(string file)
        {
            string ret = null;

            FileInfo f = new FileInfo(templateDir + file);
            if (f.Exists)
            {
                StreamReader stream = f.OpenText();
                ret = stream.ReadToEnd();
                stream.Close();
            }
            return ret;
        }

        public Templates(string dir)
        {
            // load em up
            templateDir = dir;

            httpHeader = readFile("httpHeader.html");
            httpFooter = readFile("httpFooter.html");

            mainPage = readFile("mainPage.html");
            newUserSetup = readFile("newUserSetup.html");
            newUserError = readFile("newUserError.html");
            newUserComplete = readFile("newUserComplete.html");
            newUserVerified = readFile("newUserVerified.html");

            mail = readFile("mail.txt");
        }

        public string get ( string file )
        {
            return readFile(file+".html");
        }

        public bool valid()
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

        private string templateDir = string.Empty;

        public string httpHeader = string.Empty;
        public string httpFooter = string.Empty;
        public string mainPage = string.Empty;
        public string newUserSetup = string.Empty;
        public string newUserError = string.Empty;
        public string newUserComplete = string.Empty;
        public string newUserVerified = string.Empty;

        public string mail = string.Empty;
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

            if (request.HttpMethod == "POST")
            {
                StreamReader reader = new System.IO.StreamReader(request.InputStream, request.ContentEncoding);
                string body = reader.ReadToEnd();

                while (body.Length < request.ContentLength64) // go untill we have the entire thing
                {
                    body += reader.ReadToEnd();
                    Thread.Sleep(100);
                    Console.WriteLine("readloop body read " + body.Length.ToString() + " : expected size " + request.ContentLength64.ToString() + "request flag " + request.HasEntityBody.ToString());
                }

                reader.Close();
                request.InputStream.Close();

                string[] pairs = body.Split('&');

                foreach (string s in pairs)
                {
                    string[] item = s.Split('=');

                    string name = item[0];
                    string value = string.Empty;

                    if (item.Length > 1 && item[1].Length > 0)
                        value = HttpUtility.UrlDecode(item[1]);

                    if (!arguments.ContainsKey(name))
                        arguments.Add(name, value);
                    else
                        arguments[name] = value;

                    Console.WriteLine("argument " + name + " : " + value);

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

    public class BatchMailer
    {
        List<MailMessage> messages = new List<MailMessage>();
        SmtpClient mailer;

        bool active = false;
        bool log;

        public BatchMailer(Setup setup)
        {
            if (setup.smtpPort > 0)
                mailer = new SmtpClient(setup.smtpServer, setup.smtpPort);
            else
                mailer = new SmtpClient(setup.smtpServer);

            if (setup.smtpUsername.Length > 0 && setup.smtpPassword.Length > 0)
            {
                mailer.UseDefaultCredentials = false;
                mailer.EnableSsl = setup.useSSL;
                mailer.Credentials = new NetworkCredential(setup.smtpUsername, setup.smtpPassword);
            }

            mailer.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);

            log = setup.log;
        }

        public static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            BatchMailer m = (BatchMailer)e.UserState;

            if (m.log)
                Console.WriteLine("Completed message to " + m.messages[0].To.ToString());

            m.active = false;
            m.messages.Remove(m.messages[0]);
            m.add(null);
        }

        public void add(MailMessage messge)
        {
           if (messge != null)
                messages.Add(messge);

            if (!active && messages.Count > 0)
            {
                if (log)
                    Console.WriteLine("Sending message to " + messge.To.ToString());

                try
                {
                    mailer.SendAsync(messages[0], this);
                }
                catch (System.Exception e)
                {
                    Console.WriteLine("Exception");
                    Console.WriteLine(e);
                    System.Net.Mail.SmtpException smptExc = e as System.Net.Mail.SmtpException;
                    System.Net.Mail.SmtpFailedRecipientsException smptFailExc = e as System.Net.Mail.SmtpFailedRecipientsException;

                    if (smptExc == null && smptFailExc == null)
                        throw e;
                }
            }
        }
    }

    public class AuthedSession
    {
        public User user;
        public DateTime lastTime;
    }

    public class Server
    {
        public Setup setup = new Setup();
        Templates templates;

        BatchMailer mailer;

        Dictionary<string, AuthedSession> authedSessions = new Dictionary<string, AuthedSession>();

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
                string header = templates.get("httpHeader").Replace("[TITLE]", title);
                writeToContext(header, connection.context);
            }
            else
                connection.context.Response.ContentType = "text/plain";
        }

        private void writeHTTPFooter(Connection connection)
        {
            if (templates.httpFooter != null)
                writeToContext(templates.get("httpFooter"), connection.context);
        }

        private bool fatalError ( string error, Connection connection )
        {
            writeHTTPHeader(connection, "Fatal Error!");
            writeToContext("<h1>" + error + "</h1>", connection);
            writeHTTPFooter(connection);
            return true;
        }

        private string fillTemplate ( string template )
        {
            template = template.Replace("[SERVICE]", setup.serviceName);
            template = template.Replace("[URL]", publicURL);

            template = template.Replace("[TIME]", DateTime.Now.ToString());
            return template;
        }

        private string fillTemplate(string template, string key, string val )
        {
            string ret = fillTemplate(template);
            template = template.Replace("[" + key + "]", val);

            return template;
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
                setup.favicon = "./data/favicon.icn";

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

            if (setup.favicon.Length < 1)
                setup.favicon = "./data/favicon.ico";

            if (args.Length > 1)
            {
                if (args[1] == "-consolelog")
                    setup.log = true;
            }

            // load all the databases
            if(setup.hosts.Count > 0)
                publicURL = setup.hosts[0];

            usersDir = new DirectoryInfo(setup.userDir);
            users.load(usersDir);
            templates = new Templates(setup.templateDir);

            mailer = new BatchMailer(setup);
        }

        public void update ( )
        {
            DateTime now = DateTime.Now;

           // foreach (AuthedSession s in authedSessions)
            {

            }
        }

        private bool fieldValid ( string text )
        {
            if (text == null || text.Length == 0)
                return false;
            return true;
        }

        private string hashPassword ( string password )
        {
            MD5 md5 = MD5.Create();
            md5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(password + setup.md5Salt));

            return md5.GetHashCode().ToString();
        }

        private string getSessionCookie ( )
        {
            Random rng = new Random();

            string key = string.Empty;

            for (int i = 0; i < 5; i++)
                key += rng.Next().ToString();

            return key;
        }

        private void newUser ( Connection connection )
        {
            writeHTTPHeader(connection);

            string mode = connection.getArg("mode");
            if ( mode == "adduser")
            {
                if (setup.log)
                    Console.WriteLine("adduser");

                string username = connection.getArg("username");
                string password = connection.getArg("password");
                string password2 = connection.getArg("password2");
                string email = connection.getArg("email");
                string email2 = connection.getArg("email2");

                string agree = connection.getArg("agree");

                if (!fieldValid(agree) || agree != "on")
                {
                    writeToContext(fillTemplate(templates.newUserError, "ERROR", "You need to agree to the terms"), connection);
                    return;
                }

                // verify the info
                if (!fieldValid(username) || !fieldValid(password) || !fieldValid(email) )
                {
                    writeToContext(fillTemplate(templates.newUserError,"ERROR", "Required info was missing!"), connection);
                    return;
                }

                if (users.getUser(username) != null)
                {
                    writeToContext(fillTemplate(templates.newUserError,"ERROR", "Username is taken!"), connection);
                    return;
                }

                if (users.getUserByEmail(email) != null)
                {
                    writeToContext(fillTemplate(templates.newUserError,"ERROR", "E-mail is used by another user!"), connection);
                    return;
                }

                if ( password != password2)
                {
                    writeToContext(fillTemplate(templates.newUserError,"ERROR", "Passwords do not match!"), connection);
                    return;
                }

                if ( password.Length < 6)
                {
                    writeToContext(fillTemplate(templates.newUserError,"ERROR", "Passwords too short!"), connection);
                    return;
                }

                if ( !email.Contains("@") || !email.Contains("."))
                {
                    writeToContext(fillTemplate(templates.newUserError,"ERROR", "Invalid E-mail!"), connection);
                    return;
                }

                if ( email != email2)
                {
                    writeToContext(fillTemplate(templates.newUserError,"ERROR", "E-Mail does not match!"), connection);
                    return;
                }

                // all is good, make a user and have them verify
                Random rng = new Random();

                string verifyKey = getSessionCookie();

                User user = new User();
                user.email = email;
                user.username = username;
                user.verified = false;
                user.emailKey = verifyKey;
                user.passwordHash = hashPassword(password);

                users.adduser(user);
                users.saveUser(user, usersDir);

                string verifyLink = publicURL + "?action=newuser&mode=verify&key=" + verifyKey + "&user=" + user.GUID.ToString();

                string body = fillTemplate(templates.mail,"USER", username);
                body = body.Replace("[VERIFY]", verifyLink);

                MailAddress from = new MailAddress(setup.replyEmail);
                MailAddress to = new MailAddress(email);

                MailMessage message = new MailMessage(from, to);
                message.Subject = "Registration with " + setup.serviceName  + "(" + publicURL + ")"; 
                message.Body = body;

                mailer.add(message);

                if (setup.log)
                    Console.WriteLine("added user " + user.username);

                writeToContext(templates.get("newUserComplete"),connection);
            }
            else if (mode == "verify")
            {
                // this has to come form the verifyer

                string GUID = connection.getArg("user");
                string token = connection.getArg("key");

                User user = users.getUser(int.Parse(GUID));
                if (user == null || user.verified || token.Length <= 0)
                {
                    writeToContext(fillTemplate(templates.newUserError, "ERROR", "Invalid Request!"), connection);
                    return;
                }

                if (user.emailKey == token)
                    writeToContext(fillTemplate(templates.get("newUserVerified"), "URL", publicURL), connection);
                else
                    writeToContext(fillTemplate(templates.newUserError, "ERROR", "Data mismatch!"), connection);

                if (setup.log)
                    Console.WriteLine("verify use " + user.username);

            }
            else // new user form
            {
                if (setup.log)
                    Console.WriteLine("geneate new user form");

                writeToContext(fillTemplate(templates.get("newUserSetup")), connection);
            }

            writeHTTPFooter(connection);
        }

        private void generateHomepage(Connection connection, AuthedSession session )
        {
            writeToContext(fillTemplate(templates.get("homepage")), connection);
        }

        private void login( Connection connection )
        {
            writeHTTPHeader(connection);

            string action = connection.getArg("action");

            if (action == "login")
            {
                // auth

                string username = connection.getArg("username");
                string password = connection.getArg("password");

                if ( username == string.Empty || password == string.Empty )
                {
                    writeToContext(fillTemplate(templates.newUserError, "ERROR", "Invalid Entry"), connection);
                    return;
                }

                User user = users.getUser(username);
                if (user == null)
                {
                    writeToContext(fillTemplate(templates.newUserError, "ERROR", "Invalid Username"), connection);
                    return;
                }

                if (user.passwordHash != hashPassword(password))
                {
                    writeToContext(fillTemplate(templates.newUserError, "ERROR", "Invalid password"), connection);
                    return;
                }

                // ok they have authed, give em a session cookie

                string sessionID = getSessionCookie();

                AuthedSession session = new AuthedSession();
                session.user = user;
                session.lastTime = DateTime.Now;

                if (authedSessions.ContainsKey(sessionID))
                    authedSessions[sessionID] = session;
                else
                    authedSessions.Add(sessionID, session);

                connection.context.Response.Cookies.Add(new Cookie("session",sessionID));

                generateHomepage(connection,session);
            }
            else                //login page
                writeToContext(fillTemplate(templates.get("mainPage")), connection);

            writeHTTPFooter(connection);
        }

        private bool handleAuthedQuery( Connection connection, string sessionID )
        {
            writeHTTPHeader(connection);

            AuthedSession session = authedSessions[sessionID];

            string action = connection.getArg("action");

            if (action == "stop")
            {
                writeToContext("ok, shutdown!", connection);
                writeHTTPFooter(connection);
                return true;
            }
            else
            {
                generateHomepage(connection, session);
            }

            writeHTTPFooter(connection);
            return false;
        }
        
        private bool isAuthedSession ( string session )
        {
            if (session == string.Empty)
                return false;

            if (authedSessions.ContainsKey(session))
            {
                authedSessions[session].lastTime = DateTime.Now;
                return true;
            }
            return false;
        }

        private bool handleAppQuery ( Connection connection )
        {
            // parse out the message in a nice fast XML way
            return false;
        }

        private bool handleCommonTasks ( HttpListenerContext context )
        {
            if (context.Request.Url.AbsolutePath.Contains("favicon.ico"))
            {
                // return he icon
                FileInfo icon = new FileInfo(setup.favicon);
                if (icon.Exists)
                {
                    context.Response.ContentType = "image/vnd.microsoft.icon";

                    FileStream fs = icon.OpenRead();
                    StreamReader instream = new StreamReader(fs);
                    writeToContext(instream.ReadToEnd(),context);
                    instream.Close();
                    fs.Close();
                }
                else
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return true;
            }
            return false;
        }

        public bool handleURL ( HttpListenerContext context )
        {
            if (handleCommonTasks(context)) // favicon, etc..
                return false;

            Connection connection = new Connection(context);

            if (!templates.valid())
                return fatalError("Templates not valid",connection);

            string session = string.Empty;

            string action = connection.getArg("action");
            if (connection.getArg("type") == "rpkit")
                return handleAppQuery(connection);

            if (setup.log)
            {
                Console.WriteLine("new request URL " + context.Request.Url.ToString());
                Console.WriteLine("new request action = " + action);
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
                // new user dosnt' need a session
                if (action == "newuser")
                {
                    newUser(connection);
                    return false;
                }

                login(connection);
                return false;
            }

            return handleAuthedQuery(connection, session);
        }
    }
}