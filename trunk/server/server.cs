using System;
using System.Collections.Generic;
using System.Text;
using System.Net;


namespace RPServer
{
    public class Server
    {
        List<string> authedSessions = new List<string>();
        public void init ( )
        {
            // load all the databases
        }

        public void update ( )
        {

        }

        private void newUser ( HttpListenerContext context )
        {

        }

        private void login( HttpListenerContext context, string session, string action )
        {
            if (action == "login")
            {
                // auth
            }
            else
            {
                //login page
            }
        }

        private bool handleAuthedQuery(HttpListenerContext context, string session, string action)
        {
            string message;

            if (action == "stop")
            {
                message = "ok, shutdown!";
                context.Response.OutputStream.Write(System.Text.ASCIIEncoding.ASCII.GetBytes(message), 0, message.Length);
                return true;
            }

            message = "Hello World!";
            context.Response.OutputStream.Write(System.Text.ASCIIEncoding.ASCII.GetBytes(message), 0, message.Length);
            return false;
        }


        private bool isAuthedSession ( string session )
        {
            if (session == string.Empty)
                return false;

            return authedSessions.Contains(session);
        }

        private bool handleAppQuery ( HttpListenerContext context )
        {
            // parse out the message in a nice fast XML way
            return false;
        }

        public bool handleURL ( HttpListenerContext context, Uri relitiveUri )
        {
            // grab the cookie
            string session = string.Empty;
            string action = string.Empty;

            HttpListenerRequest request = context.Request;

            // get our base keys
            if(request.QueryString.HasKeys())
            {
                for (int i = 0; i < request.QueryString.Count; i++ )
                {
                    string name =  request.QueryString.GetKey(i);
                    if (name == "type")
                    {
                        if (request.QueryString.GetValues(i)[0] == "rpkit")
                            return handleAppQuery(context);
                    }
                    else if ( name == "action")
                        action = request.QueryString.GetValues(i)[0];
                }
             }

            // new user dosnt' need a session
            if (action == "newuser")
            {
                newUser(context);
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
                login(context,session,action);
                return false;
            }

            return handleAuthedQuery(context, session, action);
        }
    }
}