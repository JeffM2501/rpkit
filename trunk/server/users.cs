using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

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

        string username = string.Empty;
        string passwordHash = string.Empty;
        string email = string.Empty;

        string emailKey = string.Empty;

        bool verified = false;

        int GUID = -1;
    }
}