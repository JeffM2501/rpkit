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
using TemplateSystem;
using HTTPConnections;
using Mailer;

namespace RPServer
{
    public class MimeTypePair
    {
        public string key;
        public string value;

        public MimeTypePair()
        {
            key = string.Empty;
            value = string.Empty;
        }

        public MimeTypePair ( string k, string v)
        {
            key = k;
            value = v;
        }
    }

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
        public List<MimeTypePair> mimeTypes = new List<MimeTypePair>();
       // public Dictionary<string, string> mimeTypes = new Dictionary<string, string>();
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

        Usermanager users;

        DirectoryInfo usersDir;

        public string publicURL = "http://localhost";

        private bool isValidTransferFile ( FileInfo file )
        {
            string ext = file.Extension.Remove(0, 1).ToLower();

            if (!file.Exists || ext == "ptpl")
                return false;

            foreach (MimeTypePair m in setup.mimeTypes)
            {
                if (m.key == ext)
                    return true;
            }

            return false;
        }

        private bool isTextFile ( FileInfo file )
        {
            return getMimeType(file).Contains("text");
        }

        private string getMimeType(FileInfo file)
        {
            string ext = file.Extension.Remove(0, 1).ToLower();

            string catchall = string.Empty;
            foreach (MimeTypePair m in setup.mimeTypes)
            {
                if (m.key == ext)
                    return m.value;

                if (m.key == "*")
                    catchall = m.value;
            }

            if (catchall != string.Empty)
                return catchall;

            return "application/octet-stream";
        }

        private void writeHTTPHeader ( HTTPConnection connection )
        {
            writeHTTPHeader(connection, "");
        }

        private void writeHTTPHeader(HTTPConnection connection, string title)
        {
            if(templates.httpHeader != null)
            {
                string header = templates.get("httpHeader").Replace("[TITLE]", title);
                connection.writeToContext(header, "text/html");
            }
            else
                connection.setMimeType("text/plain");
        }

        private void writeHTTPFooter(HTTPConnection connection)
        {
            if (templates.httpFooter != null)
                connection.writeToContext(templates.get("httpFooter"));
        }

        private bool fatalError ( string error, HTTPConnection connection )
        {
            writeHTTPHeader(connection, "Fatal Error!");
            connection.writeToContext("<h1>" + error + "</h1>");
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

            bool saveConfig = false;

            FileInfo conf = new FileInfo(configFile);

            bool confRead = false;

            if ( conf.Exists )
            {
                XmlSerializer xml = new XmlSerializer(typeof(Setup));

                FileStream fs = conf.OpenRead();
                StreamReader file = new StreamReader(fs);
                try
                {
                    setup = (Setup)xml.Deserialize(file);
                    confRead = true;
                }
                catch (System.Exception e)
                {
                    Console.WriteLine("Error reading config " + e.ToString());
                }

                file.Close();
                fs.Close();
            }
            
            if (!confRead)
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
                    saveConfig = true;
            }

            if (setup.favicon.Length < 1)
                setup.favicon = "./data/favicon.ico";

            if (setup.mimeTypes.Count == 0)
            {
                setup.mimeTypes.Add(new MimeTypePair("html","text/html"));
                setup.mimeTypes.Add(new MimeTypePair("htm","text/html"));
                setup.mimeTypes.Add(new MimeTypePair("txt","text/plain"));
                setup.mimeTypes.Add(new MimeTypePair("css","text/css"));
                setup.mimeTypes.Add(new MimeTypePair("png","image/png"));
                setup.mimeTypes.Add(new MimeTypePair("ico","image/vnd.microsoft.icon"));
                setup.mimeTypes.Add(new MimeTypePair("*","application/octet-stream"));
            }

            if (args.Length > 1)
            {
                if (args[1] == "-consolelog")
                    setup.log = true;
                else if (args[1] == "-saveconf")
                    saveConfig = true;
            }

            if (saveConfig)
            {
                XmlSerializer xml = new XmlSerializer(typeof(Setup));
     
                FileStream fs = conf.OpenWrite();
                StreamWriter file = new StreamWriter(fs);

                xml.Serialize(file, setup);
                file.Close();
                fs.Close();
            }

            // load all the databases
            if(setup.hosts.Count > 0)
                publicURL = setup.hosts[0];

            usersDir = new DirectoryInfo(setup.userDir);

            users = new Usermanager(usersDir);

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
            string saltedPass = password + setup.md5Salt;
            MD5 md5 = MD5.Create();
            md5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(saltedPass));

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

        private string getNewPass()
        {
            return new Random().Next().ToString();
        }

        private void mailUserVerifyCode ( User user, bool resetPas )
        {
            string verifyKey = getSessionCookie();

            user.verified = false;
            user.emailKey = verifyKey;

            string verifyLink = publicURL + "?action=newuser&mode=verify&key=" + verifyKey + "&user=" + user.GUID.ToString();
            if (resetPas)
                verifyLink += "&resetpass=1";

            string body = fillTemplate(templates.mail, "USER", user.username);
            body = body.Replace("[VERIFY]", verifyLink);

            MailAddress from = new MailAddress(setup.replyEmail);
            MailAddress to = new MailAddress(user.email);

            MailMessage message = new MailMessage(from, to);
            message.Subject = "Registration with " + setup.serviceName + "(" + publicURL + ")";
            message.Body = body;

            mailer.add(message);
        }
        
        private void passwordRest ( HTTPConnection connection )
        {
            writeHTTPHeader(connection);
            string username = connection.getArg("username");
            string email = connection.getArg("email");

            string error = string.Empty;
            if (username.Length == 0 || email.Length == 0)
                error = "You must enter a valid username and email address";

            User user = users.getUser(username);
            if (user == null)
                error = "Invalid username";

            if (user.email != email)
                error = "Invalid e-mail";

            if (error == string.Empty)
            {
                connection.writeToContext(fillTemplate(templates.newUserError, "ERROR", error));
                writeHTTPFooter(connection);
                return;
            }
            else
                connection.writeToContext(fillTemplate(templates.get("generalMessage"), "MESSAGE","Your password reset has been processed and has been sent to your email"));

            mailUserVerifyCode(user,true);

            writeHTTPFooter(connection);
        }

        private string checkNewUserInput ( HTTPConnection connection )
        {
            string username = connection.getArg("username");
            string password = connection.getArg("password");
            string email = connection.getArg("email");

            string password2 = connection.getArg("password2");
            string email2 = connection.getArg("email2");
            string agree = connection.getArg("agree");

            if (!fieldValid(agree) || agree != "on")
                return "You need to agree to the terms";

            // verify the info
            if (!fieldValid(username) || !fieldValid(password) || !fieldValid(email))
                return "Required info was missing!";

            if (users.getUser(username) != null)
                return "Username is taken!";

            if (users.getUserByEmail(email) != null)
                return "E-mail is used by another user!";

            if (password != password2)
                return "Passwords do not match!";

            if (password.Length < 6)
                return "Passwords too short!";

            if (!email.Contains("@") || !email.Contains("."))
                return "Invalid E-mail!";

            if (email != email2)
                return "E-Mail does not match!";

            return string.Empty;
        }

        private void newUser ( HTTPConnection connection )
        {
            writeHTTPHeader(connection);

            string mode = connection.getArg("mode");
            if ( mode == "adduser")
            {
                if (setup.log)
                    Console.WriteLine("adduser");

                string error = checkNewUserInput(connection);

                if (error != string.Empty)
                {
                    connection.writeToContext(fillTemplate(templates.newUserError, "ERROR", error));
                    writeHTTPFooter(connection);
                    return;
                }

                string username = connection.getArg("username");
                string password = connection.getArg("password");
                string email = connection.getArg("email");
                
                // all is good, make a user and have them verify
                Random rng = new Random();

                User user = new User();
                user.email = email;
                user.username = username;
                user.passwordHash = hashPassword(password);

                users.adduser(user);
                users.saveUser(user);

                mailUserVerifyCode(user,false);

                if (setup.log)
                    Console.WriteLine("added user " + user.username);

                connection.writeToContext(templates.get("newUserComplete"));
            }
            else if (mode == "verify")
            {
                // this has to come form the verifyer

                string GUID = connection.getArg("user");
                string token = connection.getArg("key");

                string error = string.Empty;

                User user = users.getUser(int.Parse(GUID));
                if (user == null || user.verified || token.Length <= 0)
                    error = "Invalid Request!";

                if (user.emailKey != token)
                    error = "Data mismatch!";

                if (error == string.Empty)
                {
                    connection.writeToContext(fillTemplate(templates.newUserError, "ERROR", error));
                    writeHTTPFooter(connection);
                    return;
                }

                user.verified = true;
                if (connection.getArg("resetpass") == "1")
                {
                    string newPass = getNewPass();
                    user.passwordHash = hashPassword(newPass);

                    string template = fillTemplate(templates.get("resetPassVerified"), "URL", publicURL);
                    template = fillTemplate(template, "PASSWORD", newPass);
                    connection.writeToContext(template);
                } 
                else
                    connection.writeToContext(fillTemplate(templates.get("newUserVerified"), "URL", publicURL));

                if (setup.log)
                    Console.WriteLine("verify use " + user.username);

                users.saveUser(user);
            }
            else // new user form
            {
                if (setup.log)
                    Console.WriteLine("geneate new user form");

                connection.writeToContext(fillTemplate(templates.get("newUserSetup")));
            }

            writeHTTPFooter(connection);
        }

        private void generateHomepage(HTTPConnection connection, AuthedSession session )
        {
            connection.writeToContext(fillTemplate(templates.get("homepage")));
        }

        private void login( HTTPConnection connection )
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
                    connection.writeToContext(fillTemplate(templates.newUserError, "ERROR", "Invalid Entry"));
                    return;
                }

                User user = users.getUser(username);
                if (user == null)
                {
                    connection.writeToContext(fillTemplate(templates.newUserError, "ERROR", "Invalid Username"));
                    return;
                }

                if (!user.verified)
                {
                    connection.writeToContext(fillTemplate(templates.newUserError, "ERROR", "Unverified user"));
                    return;
                }


                if (user.passwordHash != hashPassword(password))
                {
                    connection.writeToContext(fillTemplate(templates.newUserError, "ERROR", "Invalid password"));
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

                Cookie cookie = new Cookie("session", sessionID, "/", connection.context.Request.Url.Host.ToString());
                connection.context.Response.Cookies.Add(cookie);

                generateHomepage(connection,session);
            }
            else                //login page
                connection.writeToContext(fillTemplate(templates.get("mainPage")));

            writeHTTPFooter(connection);
        }

        private bool handleAuthedQuery( HTTPConnection connection, string sessionID )
        {
            writeHTTPHeader(connection);

            AuthedSession session = authedSessions[sessionID];

            string action = connection.getArg("action");

            if (action == "stop")
            {
                connection.writeToContext("ok, shutdown!");
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

        private bool handleAppQuery ( HTTPConnection connection )
        {
            // parse out the message in a nice fast XML way
            return false;
        }

        private bool handleCommonTasks( HTTPConnection connection )
        {
            if (connection.hasArgs())
                return false;

            string absPath = string.Copy(connection.context.Request.Url.AbsolutePath);

            if (absPath.Length == 0 || absPath == "/")
                return false; // main page

            absPath = absPath.Remove(0,1);

            if (absPath.Contains("favicon.ico"))
            {
                // return he icon
                FileInfo icon = new FileInfo(setup.favicon);
                if (icon.Exists)
                {
                    connection.writeToContext(icon, "image/x-icon", true);
                    return true;
                }
            }

            FileInfo file = new FileInfo(Path.Combine(setup.templateDir, absPath));
            if (isValidTransferFile(file))
            {
                // get it's mime type and mode
                if (file.Extension == "thtm")// it's a template parse it.
                {
                    writeHTTPHeader(connection);
                    connection.writeToContext(fillTemplate(templates.get(file)));
                    writeHTTPFooter(connection);
                }
                else
                    connection.writeToContext(file,getMimeType(file),!isTextFile(file));
            }
            else
                connection.set404();

            return true;
        }

        public bool handleURL ( HttpListenerContext context )
        {
            HTTPConnection connection = new HTTPConnection(context);

            if (handleCommonTasks(connection)) // favicon, etc..
                return false;

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
                else if (action == "forgotpassword")
                {
                    passwordRest(connection);
                    return false;
                }

                login(connection);
                return false;
            }

            return handleAuthedQuery(connection, session);
        }
    }
}