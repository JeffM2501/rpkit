using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using FourETypes;

namespace RPUsers
{
    public class User
    {
        private static List<int> usedIDs = new List<int>();

        public static int newID ( )
        {
            Random rng = new Random();

            int id = rng.Next();
            while (usedIDs.Contains(id))
                id = rng.Next();
            usedIDs.Add(id);

            return id;
        }

        public string username = string.Empty;
        public string passwordHash = string.Empty;
        public string email = string.Empty;

        public string emailKey = string.Empty;

        public bool verified = false;

        public int GUID = -1;
    }

    public class Usermanager
    {
        private List<User> users = new List<User>();

        public void load ( DirectoryInfo dir )
        {
            // flush existing users
            users.Clear();

            if (dir.Exists)
            {
                foreach (FileInfo f in dir.GetFiles() )
                {
                    XmlSerializer xml = new XmlSerializer(typeof(User));

                    FileStream fs = f.OpenRead();
                    StreamReader file = new StreamReader(fs);

                    User newUser = (User)xml.Deserialize(file);
                    file.Close();
                    fs.Close();

                    if ( newUser.ToString() + ".xml" != f.Name) // verify that this is cool
                        f.Delete();// it's a bad user, flush it
                    else
                        users.Add(newUser);
                }
            }

        }

        public User getUser ( int GUID )
        {
            foreach (User user in users )
            {
                if (user.GUID == GUID)
                    return user;
            }

            return null;
        }

        public User getUser(string name)
        {
            foreach (User user in users)
            {
                if (user.username == name)
                    return user;
            }

            return null;
        }

        public bool adduser(User user)
        {
            if (getUser(user.username) != null)
                return false;

            user.GUID = User.newID();
            user.verified = false;

            users.Add(user);

            //write user

          
            return true;
        }

        public void saveUser ( User user, DirectoryInfo dir )
        {
            if (!dir.Exists)
                return;

            FileInfo f = new FileInfo(Path.Combine(dir.FullName, user.GUID.ToString() + ".xml"));

            FileStream fs = f.OpenWrite();
            StreamWriter file = new StreamWriter(fs);

            XmlSerializer xml = new XmlSerializer(typeof(User));
            xml.Serialize(file, user);

            file.Close();
            fs.Close();
        }

        public bool removeUser ( User user, DirectoryInfo dir )
        {
            if (!dir.Exists)
                return false;

            FileInfo f = new FileInfo(dir.FullName + "/" + user.GUID.ToString() + ".xml");

            if (f.Exists)
                f.Delete();

            if (!users.Contains(user))
                return false;

            users.Remove(user);

            return true;
        }

    }
}