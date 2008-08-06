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
        List<Party> parties;
        List<Encounter> encounters;
        MonsterDB monsterDB;

        Form1 ui;

        public TrackerLogic(Form1 form)
        {
            ui = form;
            monsterDB = new MonsterDB();
            encounters = new List<Encounter>();
            parties = new List<Party>();

            loadDatabases();

            ui.addTrackerItem("item1", 0);
            ui.addTrackerItem("item2", 1);
        }

        public Monster newMonster ( )
        {
            return new Monster();
        }

        public Monster getMonster ( int index )
        {
            return monsterDB.items[index];
        }

        public void addMonster ( Monster m )
        {
            monsterDB.items.Add(m);
            monstersChanged();
        }

        public void monstersChanged ( )
        {
            ui.clearMonsters();
            foreach (Monster m in monsterDB.items)
                ui.addMonster(m);
     
            flushDirtyMonsters();
        }

        private void flushDirtyMonsters ( )
        {
            foreach (Monster m in monsterDB.items )
            {
                if (m.dirty)
                {
                    // open the file and write it.
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
                    string name = f.Name;
                    FileStream fs = f.OpenRead();
                    StreamReader file = new StreamReader(fs);

                    Monster mob = new Monster();

                    mob.name = file.ReadLine();
                    mob.GUID = int.Parse(file.ReadLine());
                    //       mob.guid = file.ReadLine();
                    mob.stats.read(file, false);

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
                    foreach (FileInfo f in d.GetFiles("*.txt"))
                    {

                    }
                }
            }
        }
    }
}
