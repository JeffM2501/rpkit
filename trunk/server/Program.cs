using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading;
using RPServer;


namespace server
{
    class Program
    {
        static bool runServer = true;

        static Server server;

        static Uri rootURI;
        static void Main(string[] args)
        {
            HttpListener  httpd = new HttpListener();

            // read in some kinda prefs and setup the server

            server = new Server();
            server.replyEMail = "nobody@opencombat.net";

            server.init("http://rpserver.opencombat.net:88/");

            httpd.Prefixes.Add("http://localhost:88/");
            httpd.Prefixes.Add("http://rpserver.opencombat.net:88/");
            httpd.Prefixes.Add("http://127.0.0.1:88/");

            rootURI = new Uri("http://localhost:88/");

            httpd.Start();

            AsyncCallback callback = new AsyncCallback(HTTPCallback);

            IAsyncResult result = httpd.BeginGetContext(callback, httpd);

            while (runServer)
            {
                server.update();

                Thread.Sleep(100);

                if (result.IsCompleted)
                    result = httpd.BeginGetContext(callback, httpd);                      
            }

            httpd.Close();
        }

        public static void HTTPCallback (IAsyncResult result )
        {
            HttpListener listener = (HttpListener)result.AsyncState;

            HttpListenerContext context = listener.EndGetContext(result);

            Uri relURI = rootURI.MakeRelativeUri(context.Request.Url);

            if (server.handleURL(context, relURI))
                runServer = false;

            context.Response.Close();
        }
    }
}
