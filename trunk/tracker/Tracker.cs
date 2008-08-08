using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace tracker
{
    public class TrackerLogic
    {
        List<Party> parties = new List<Party>();
        List<Encounter> encounters = new List<Encounter>();
        MonsterDB monsterDB = new MonsterDB();

        Random rand = new Random();

        Form1 ui;

        public int newGUID ( )
        {
            return rand.Next();
        }

        public TrackerLogic(Form1 form)
        {
            ui = form;

            loadDatabases();

            fillUI();

            ui.addTrackerItem("item1", 0);
            ui.addTrackerItem("item2", 1);
        }

        public void fillUI ()
        {
            fillMonsterList();
        }

        public void fillMonsterList ()
        {
            ui.clearMonsters();
            foreach (Monster m in monsterDB.items)
                ui.addMonster(m);
        }

        public Monster getMonster ( int index )
        {
            return monsterDB.items[index];
        }

        public void deleteMonster (int index)
        {
            clearMonsterFile(getMonster(index));
            monsterDB.items.Remove(getMonster(index));
            fillMonsterList();
        }

        public void addMonster ( Monster m )
        {
            monsterDB.items.Add(m);
            monstersChanged();
        }

        public void monstersChanged ( )
        {
            fillMonsterList();   
            flushDirtyMonsters();
        }

        private void clearMonsterFile ( Monster mob )
        {
            string rootDir = "./";
            string mobDir = "mobs";
            DirectoryInfo dir = new DirectoryInfo(rootDir + mobDir);

            if (!dir.Exists)
                return;

            FileInfo f = new FileInfo(rootDir + mobDir + "/" + mob.name + ".txt");
            if (f.Exists)
                f.Delete();
        }

        private void flushDirtyMonsters ( )
        {
            string rootDir = "./";
            string mobDir = "mobs";
            DirectoryInfo dir = new DirectoryInfo(rootDir + mobDir);

            if (!dir.Exists)
                dir.Create();

            foreach (Monster m in monsterDB.items)
            {
                if (m.dirty && m.name.Length > 0)
                {
                    // open the file and write it.

                    FileInfo f = new FileInfo(rootDir + mobDir + "/" + m.getFileName());
                  //  if (!f.Exists)
                 //       f.Create();

                    FileStream fs = f.OpenWrite();
                    StreamWriter file = new StreamWriter(fs);

                    m.write(file);

                    file.Close();
                    fs.Close();

                    m.dirty = false;
                }
            }
        }

        private void loadDatabases()
        {
            // load the mob list
            string rootDir = "./";
            DirectoryInfo dir = new DirectoryInfo(rootDir + "mobs");
            if (dir.Exists)
            {
                foreach (FileInfo f in dir.GetFiles("*.txt"))
                {
                    FileStream fs = f.OpenRead();
                    StreamReader file = new StreamReader(fs);

                    Monster mob = new Monster(0);

                    mob.read(file);
                    monsterDB.items.Add(mob);

                    file.Close();
                    fs.Close();
                }
            }

            // load the parties list
            dir = new DirectoryInfo(rootDir + "parties");
            if (dir.Exists)
            {
                foreach (DirectoryInfo d in dir.GetDirectories())
                {
                    Party party = new Party();
                    party.name = d.Name;

                    foreach (FileInfo f in d.GetFiles("*.txt"))
                    {
                        FileStream fs = f.OpenRead();
                        StreamReader file = new StreamReader(fs);

                        Player p = new Player(0);

                        p.read(file);
                        party.players.Add(p);

                        file.Close();
                        fs.Close();
                    }
                }
            }

            // load the encounters
            DirectoryInfo dir = new DirectoryInfo(rootDir + "encounters");
            if (dir.Exists)
            {
                foreach (FileInfo f in dir.GetFiles("*.txt"))
                {
                    FileStream fs = f.OpenRead();
                    StreamReader file = new StreamReader(fs);

                    Encounter enc = new Encounter();

                    Monster mob = new Monster(0);

                    mob.read(file);
                    monsterDB.items.Add(mob);

                    file.Close();
                    fs.Close();
                }
            }

        }
    }
}
