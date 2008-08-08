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

        public void write(StreamWriter stream)
        {
            stream.WriteLine(AC.ToString());
            stream.WriteLine(fortitude.ToString());
            stream.WriteLine(reflex.ToString());
            stream.WriteLine(will.ToString());
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

        public void write(StreamWriter stream, bool player)
        {
            stream.WriteLine(maxHP.ToString());
            if (player)
            {
                stream.WriteLine(currentHP.ToString());
                stream.WriteLine(tempHP.ToString());
            }
        }
    }

    public struct Surges
    {
        public int perDay;
        public int current;

        public void read(StreamReader stream)
        {
            perDay = int.Parse(stream.ReadLine());
            current = int.Parse(stream.ReadLine());
        }

        public void write(StreamWriter stream)
        {
            stream.WriteLine(perDay.ToString());
            stream.WriteLine(current.ToString());
        }
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
                statuses = new List<string>();
                foreach (string i in stream.ReadLine().Split(new char[] { ' ' }))
                    statuses.Add(i);

                markTarget = stream.ReadLine();
                markedBy = stream.ReadLine();
            }
            else
            {
                markTarget = "";
                markedBy = "";
                statuses = new List<string>();
            }
        }

        public void write(StreamWriter stream, bool player)
        {
            stream.WriteLine(inititive.ToString());
            stream.WriteLine(actionPoints.ToString());
            defenses.write(stream);
            health.write(stream, player);
            if (player)
            {
                foreach (string i in statuses)
                    stream.Write(i+" ");

                stream.WriteLine(markTarget);
                stream.WriteLine(markedBy);
            }
        }
    }

    public class Player
    {
        public Player ( int id)
        {
            GUID = id;
            dirty = false;
        }
        
        public string getFileName ( )
        {
            return playerName + "_" + characterName + GUID.ToString() + ".txt";
        }

        public string playerName = string.Empty;
        public string characterName = string.Empty;
        public CommonStats stats;
        public Surges surges;
        public int GUID;

        bool dirty;

        public void read(StreamReader stream)
        {
            playerName = stream.ReadLine();
            characterName = stream.ReadLine();
            GUID = int.Parse(stream.ReadLine());
            stats.read(stream, true);
            surges.read(stream);
        }

        public void write(StreamWriter stream)
        {
            stream.WriteLine(playerName);
            stream.WriteLine(characterName);
            stream.WriteLine(GUID.ToString());
            stats.write(stream, true);
            surges.write(stream);
        }
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
        public bool dirty;

        public string getFileName ( )
        {
            return name + GUID.ToString() +".txt";
        }

        public void read ( StreamReader stream )
        {
            name = stream.ReadLine();
            GUID = int.Parse(stream.ReadLine());
            stats.read(stream, false);

            XP = int.Parse(stream.ReadLine());
            level = int.Parse(stream.ReadLine());

            if (!stream.EndOfStream)
            {
                size = stream.ReadLine();
                type = stream.ReadLine();
                role = stream.ReadLine();
                speed = stream.ReadLine();
                senses = stream.ReadLine();
                special = stream.ReadLine();
            }
        }

        public void write(StreamWriter stream)
        {
            stream.WriteLine(name);
            stream.WriteLine(GUID.ToString());
            stats.write(stream, false);

            stream.WriteLine(XP.ToString());
            stream.WriteLine(level.ToString());

            //write out the extra info later
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
        public Monster parent;

        public void read(StreamReader stream)
        {
            GUID = 0;
            parent = null;

            name = stream.ReadLine();
            GUID = int.TryParse(stream.ReadLine());
            stats.read(stream, false);
        }

        public void write(StreamWriter stream)
        {
            stream.WriteLine(name);
            stream.WriteLine(GUID.ToString());
            stats.write(stream, false);

            stream.WriteLine(XP.ToString());
            stream.WriteLine(level.ToString());

            //write out the extra info later
        }
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

        public void read(StreamReader stream)
        {
            monsters.Clear();
            name = stream.ReadLine();
            int count =0;
            int.TryParse(stream.ReadLine(), count);

            for (int i = 0; i < count; i++)
            {
                MonsterInstance inst = new MonsterInstance();
                inst.read(stream);
                monsters.Add(inst);
            }
        }

        public void write(StreamWriter stream)
        {
            stream.WriteLine(name);
            stream.WriteLine(GUID.ToString());
            stats.write(stream, false);

            stream.WriteLine(XP.ToString());
            stream.WriteLine(level.ToString());

            //write out the extra info later
        }
    }
}