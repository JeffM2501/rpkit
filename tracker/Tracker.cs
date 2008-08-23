using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace tracker
{
    public class TrackerLogic
    {
        List<Party> parties = new List<Party>();
        List<Encounter> encounters = new List<Encounter>();
        MonsterDB monsterDB = new MonsterDB();

        Random rand = new Random();

        Form1 ui;

        public string getLocalDir( bool write )
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/My RPGs/";
            if (write)
            {
                DirectoryInfo dInfo = new DirectoryInfo(dir);
                if (!dInfo.Exists)
                    dInfo.Create();
            }
            return dir;
        }

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
            fillEncounterList();
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

        public Monster findMonster (int GUID)
        {
            foreach (Monster m in monsterDB.items)
            {
                if (GUID == m.GUID)
                    return m;
            }
            return null;
        }


        public void deleteMonster (int index)
        {
            monsterDB.items.Remove(getMonster(index));
            flushDirtyMonsters();
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

        private void flushDirtyMonsters ( )
        {
            XmlSerializer xml = new XmlSerializer(typeof(MonsterDB));
            string rootDir = getLocalDir(true);

            FileInfo f = new FileInfo(rootDir +"monsterDB.xml");

            FileStream fs = f.OpenWrite();
            StreamWriter file = new StreamWriter(fs);

            xml.Serialize(file, monsterDB);

            file.Close();
            fs.Close();

        }

        // encounters
        public void fillEncounterList ()
        {
            ui.clearEncounters();
            foreach (Encounter e in encounters)
                ui.addEncounter(e);
        }

        public void encountersChanged()
        {
            fillEncounterList();
            flushDirtyEncounters();
        }

        public Encounter getEncounter(int index)
        {
            return encounters[index];
        }

        public void deleteEncounter(int index)
        {
            clearEncounterFile(getEncounter(index));
            encounters.Remove(getEncounter(index));
            fillEncounterList();
        }

        public void addEncounter(Encounter e)
        {
            encounters.Add(e);
            encountersChanged();
        }

        private void clearEncounterFile(Encounter e)
        {
            string rootDir = getLocalDir(false);
            string encountersDIr = "encounters";
            DirectoryInfo dir = new DirectoryInfo(rootDir + encountersDIr);

            if (!dir.Exists)
                return;

            FileInfo f = new FileInfo(rootDir + encountersDIr + "/" + e.name + ".xml");
            if (f.Exists)
                f.Delete();
        }

        public void flushDirtyEncounters()
        {
            string rootDir = getLocalDir(true);
            string encounterDir = "encounters";
            DirectoryInfo dir = new DirectoryInfo(rootDir + encounterDir);

            if (!dir.Exists)
                dir.Create();

            foreach (Encounter e in encounters)
            {
                if ( e.dirty && (e.name.Length > 0))
                {
                    // open the file and write it.

                    FileInfo f = new FileInfo(rootDir + encounterDir + "/" + e.name + ".xml");

                    FileStream fs = f.OpenWrite();
                    StreamWriter file = new StreamWriter(fs);

                    XmlSerializer xml = new XmlSerializer(typeof(Encounter));
                    xml.Serialize(file, e);

                    file.Close();
                    fs.Close();

                    e.dirty = false;
                }
            }
        }

        private void linkEncounters ()
        {
            foreach (Encounter e in encounters)
            {
                foreach (MonsterInstance i in e.monsters)
                {
                    Monster m = findMonster(i.GUID);
                    if (m != null)
                        i.parent = m;
                    else
                        e.monsters.Remove(i); // if the monster can't be found, delete it? or maybe just flag it
                }
            }
        }

        private void loadMonsterDB ( )
        {
            XmlSerializer xml = new XmlSerializer(typeof(MonsterDB));
            string rootDir = getLocalDir(false);

            FileInfo f = new FileInfo(rootDir + "monsterDB.xml");

            if (!f.Exists)
            {
                monsterDB.items.Clear();
                return;
            }

            FileStream fs = f.OpenRead();
            StreamReader file = new StreamReader(fs);

            monsterDB = (MonsterDB)xml.Deserialize(file);

            file.Close();
            fs.Close();
        }

        private void loadParty (StreamReader stream)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Party));
            parties.Add((Party)xml.Deserialize(stream));
        }

        private void loadEncounter(StreamReader stream)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Encounter));
            encounters.Add((Encounter)xml.Deserialize(stream));
        }

        // database
        private void loadDatabases()
        {
            loadMonsterDB();

            string rootDir = getLocalDir(false);

            // load the parties list
            DirectoryInfo dir = new DirectoryInfo(rootDir + "parties");
            if (dir.Exists)
            {
                foreach (FileInfo f in dir.GetFiles("*.xml"))
                {
                    FileStream fs = f.OpenRead();
                    StreamReader file = new StreamReader(fs);

                    loadParty(file);

                    file.Close();
                    fs.Close();
                }
            }

            // load the encounters
            dir = new DirectoryInfo(rootDir + "encounters");
            if (dir.Exists)
            {
                foreach (FileInfo f in dir.GetFiles("*.xml"))
                {
                    FileStream fs = f.OpenRead();
                    StreamReader file = new StreamReader(fs);

                    Encounter enc = new Encounter();

                    loadEncounter(file);

                    file.Close();
                    fs.Close();
                }

                linkEncounters();
            }

        }
    }
}
