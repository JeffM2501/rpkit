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

using RPServer;

namespace Mailer
{
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

}