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

        List<Player> players = new List<Player>();
    }

    public class Usermanager
    {
        private List<User> users = new List<User>();
        DirectoryInfo rootDir;

        public Usermanager ( DirectoryInfo dir )
        {
            rootDir = dir;
            load();
        }

        public void load ( )
        {
            // flush existing users
            users.Clear();

            XmlSerializer userXML = new XmlSerializer(typeof(User));

            if (rootDir.Exists)
            {
                foreach (DirectoryInfo d in rootDir.GetDirectories())
                {
                    string GUID = d.Name;

                    // check for the user file
                    FileInfo f = new FileInfo(Path.Combine(d.FullName, "user.xml"));
                    if (f.Exists)
                    {
                        FileStream fs = f.OpenRead();
                        StreamReader file = new StreamReader(fs);

                        User newUser = (User)userXML.Deserialize(file);
                        file.Close();
                        fs.Close();

                        if (newUser.GUID.ToString() != GUID) // verify that this is cool
                            d.Delete(true);
                        else
                            users.Add(newUser);
                    }
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

        public User getUserByEmail(string email)
        {
            foreach (User user in users)
            {
                if (user.email == email)
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
          
            return true;
        }

        public void saveUser ( User user )
        {
            if (!rootDir.Exists)
                return;

            DirectoryInfo userDir = new DirectoryInfo(Path.Combine(rootDir.FullName, user.GUID.ToString()));
            if (!userDir.Exists)
                userDir.Create();

            FileInfo f = new FileInfo(Path.Combine(userDir.FullName, "user.xml"));

            FileStream fs = f.OpenWrite();
            StreamWriter file = new StreamWriter(fs);

            XmlSerializer xml = new XmlSerializer(typeof(User));
            xml.Serialize(file, user);

            file.Close();
            fs.Close();
        }

        public bool removeUser ( User user )
        {
            if (!rootDir.Exists)
                return false;

            // blow out the dir
            DirectoryInfo userDir = new DirectoryInfo(Path.Combine(rootDir.FullName, user.GUID.ToString()));
            if (userDir.Exists)
                userDir.Delete(true);

            // purge games/players/etc..
            // that others may be using before we kill it.

            users.Remove(user);

            return true;
        }

    }
}