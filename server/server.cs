using System;
using System.Collections.Generic;
using System.Text;
using System.Net;


namespace RPServer
{
    public class Server
    {
        public void init ( )
        {
            // load all the databases
        }

        public void update ( )
        {

        }

        public bool handleURL ( HttpListenerContext context, Uri relitiveUri )
        {
            bool shutdown = false;

            string reply = "Hello world!";

            if (relitiveUri.ToString() == "stop")
            {
                shutdown = true;
                reply = "ok, shutdown!";
            }

            byte[] byteArr = System.Text.ASCIIEncoding.ASCII.GetBytes(reply);
            context.Response.OutputStream.Write(byteArr, 0, byteArr.Length);

            return shutdown;
        }
    }
}