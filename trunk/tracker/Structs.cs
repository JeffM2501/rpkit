using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;


namespace tracker
{
    public struct Defenses
    {
        public int AC;
        public int fortitude;
        public int reflex;
        public int will;

        public void read(StreamReader stream)
        {
            AC = int.Parse(stream.ReadLine());
            fortitude = int.Parse(stream.ReadLine());
            reflex = int.Parse(stream.ReadLine());
            will = int.Parse(stream.ReadLine());
        }
    }

    public struct Health
    {
        public int maxHP;
        public int currentHP;
        public int tempHP;

        public void read(StreamReader stream, bool player)
        {
            maxHP = int.Parse(stream.ReadLine());
            if (player)
            {
                currentHP = int.Parse(stream.ReadLine());
                tempHP = int.Parse(stream.ReadLine());
            }
            else
            {
                currentHP = maxHP;
                tempHP = 0;
            }
        }
    }

    public struct Surges
    {
        public int perDay;
        public int current;
    }

    public struct CommonStats
    {
        public int inititive;
        public Defenses defenses;
        public Health health;
        public int actionPoints;
        public List<string> statuses;
        public string markTarget;
        public string markedBy;

        public void read(StreamReader stream, bool player)
        {
            inititive = int.Parse(stream.ReadLine());
            actionPoints = int.Parse(stream.ReadLine());
            defenses.read(stream);
            health.read(stream, player);
            if (player)
            {
                foreach (string i in stream.ReadLine().Split(new char[] { ' ' }))
                    statuses.Add(i);

                markTarget = stream.ReadLine();
                markedBy = stream.ReadLine();
            }
            else
            {
                markTarget = "";
                markedBy = "";
                statuses.Clear();
            }
        }
    }

    public class Player
    {
        public string player = string.Empty;
        public string character = string.Empty;
        public CommonStats stats;
        public Surges surges;
    }

    public class Monster
    {
        public Monster()
        {
            dirty = false;
            XP = 0;
            GUID = 0;
            level = 0;
        }
        public string name = string.Empty;
        public CommonStats stats;
        public int GUID;
        public int XP;
        public int level;
        public string size = string.Empty;
        public string type = string.Empty;
        public string className = string.Empty;
        public string speed = string.Empty;
        public string senses = string.Empty;
        public string special = string.Empty;
        public string resist = string.Empty;
        public bool dirty;
    }

    public class MonsterInstance
    {
        public string name = string.Empty;
        public CommonStats stats;
        public string code = string.Empty;
        public int parent; // the monster that this came from
    }

    public class Party
    {
        public List<Player> players = new List<Player>();
        public string name = string.Empty;
    }

    public class MonsterDB
    {
        public List<Monster> items = new List<Monster>();
    }

    public class Encounter
    {
        public List<MonsterInstance> monsters = new List<MonsterInstance>();
        public string name = string.Empty;
    }
}