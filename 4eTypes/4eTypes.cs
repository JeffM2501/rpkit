using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


namespace FourETypes
{
    public class Defenses
    {
        public int AC;
        public int fortitude;
        public int reflex;
        public int will;
    }

    public class Health
    {
        public int maxHP;
        public int currentHP;
        public int tempHP;
    }

    public class Surges
    {
        public int perDay;
        public int current;
    }

    public class CommonStats
    {
        public int inititive;
        public Defenses defenses = new Defenses();
        public Health health = new Health();
        public int actionPoints;
        public List<string> statuses = new List<string>();
        public string markTarget = string.Empty;
        public string markedBy = string.Empty;
    }

    public class Player
    {
        public Player ( int id)
        {
            GUID = id;
            dirty = false;
        }

        public Player()
        {
            GUID = 0;
            dirty = false;
        }
        
        public string playerName = string.Empty;
        public string characterName = string.Empty;
        public CommonStats stats;
        public Surges surges;
        public int GUID;

        [System.Xml.Serialization.XmlIgnoreAttribute]
        bool dirty;
    }

    public class Monster : ICloneable
    {
        public Monster( int id )
        {
            dirty = false;
            XP = 0;
            GUID = id;
            level = 0;
        }

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
        public string role = string.Empty;
        public string speed = string.Empty;
        public string senses = string.Empty;
        public string special = string.Empty;
        
        [System.Xml.Serialization.XmlIgnoreAttribute]
        public bool dirty;

        public string getFileName ( )
        {
            return name + GUID.ToString() +".txt";
        }

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return MemberwiseClone();
        }

        #endregion

        public Monster Clone()
        {
            return (Monster)MemberwiseClone();
        }
    }

    public class MonsterInstance
    {
        public string name = string.Empty;
        public CommonStats stats;
        public string code = string.Empty;
        public int GUID;

        [System.Xml.Serialization.XmlIgnoreAttribute]
        public Monster parent;
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

        [System.Xml.Serialization.XmlIgnoreAttribute]
        public bool dirty = false;

        public string code = string.Empty;

        public void addMonster ( Monster m )
        {
            MonsterInstance i = new MonsterInstance();
            i.name = m.name;
            i.GUID = m.GUID;
            i.stats = m.stats;
            i.code = string.Empty;
            i.parent = m;
            monsters.Add(i);
            dirty = true;
        }

        public void removeMonster (int index )
        {
            monsters.RemoveAt(index);
            dirty = true;
        }
    }

    public class Game
    {
        int GUID;
        string name;
        List<Player> players;
    }

    public class Campaign
    {
        int GUID;
        string name;

        [System.Xml.Serialization.XmlIgnoreAttribute]
        MonsterDB monsterDB;

        [System.Xml.Serialization.XmlIgnoreAttribute]
        List<Encounter> encounters;

        [System.Xml.Serialization.XmlIgnoreAttribute]
        List<Game> games;
    }
}