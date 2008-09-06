
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

using RPServer;

namespace TemplateSystem
{
    public class Templates
    {
        string readFile(FileInfo f)
        {
            string ret = null;

            if (f.Exists)
            {
                StreamReader stream = f.OpenText();
                ret = stream.ReadToEnd();
                stream.Close();
            }
            return ret;
        }

        string readFile(string file)
        {
            return readFile(new FileInfo(templateDir + file));
        }

        public Templates(string dir)
        {
            // load em up
            templateDir = dir;

            httpHeader = readFile("httpHeader.ptpl");
            httpFooter = readFile("httpFooter.ptpl");

            mainPage = readFile("mainPage.ptpl");
            newUserSetup = readFile("newUserSetup.ptpl");
            newUserError = readFile("newUserError.ptpl");
            newUserComplete = readFile("newUserComplete.ptpl");
            newUserVerified = readFile("newUserVerified.ptpl");

            mail = readFile("mail.ptpl");
        }

        public string get(string file)
        {
            return readFile(file + ".ptpl");
        }

        public string get(FileInfo file)
        {
            return readFile(file);
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
}