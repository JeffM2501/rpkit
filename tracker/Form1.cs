using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace tracker
{
    public partial class Form1 : Form
    {
        TrackerLogic tr;
        private int selectedEncounter = -1;

        public Form1()
        {
            InitializeComponent();

            tr = new TrackerLogic(this);  
        }


        public void clearMonsters ()
        {
            MobList.Items.Clear();
        }

        public int addMonster ( Monster m )
        {
            int id = MobList.Items.Count;
            ListViewItem item = new ListViewItem(m.name, id);
            item.SubItems.Add(m.stats.inititive.ToString());
            item.SubItems.Add(m.stats.defenses.AC.ToString());
            item.SubItems.Add(m.stats.defenses.fortitude.ToString());
            item.SubItems.Add(m.stats.defenses.reflex.ToString());
            item.SubItems.Add(m.stats.defenses.will.ToString());
            item.SubItems.Add(m.stats.health.maxHP.ToString());
            MobList.Items.Add(item);

            return id;
        }

        public int currentMonster ( )
        {
            if (MobList.SelectedItems.Count == 0)
                return -1;

            return MobList.SelectedItems[0].Index;
        }

        public int currentEncoutnerItem()
        {
            if (EncounterMobList.SelectedItems.Count == 0)
                return -1;

            return EncounterMobList.SelectedItems[0].Index;
        }

        public bool addTrackerItem ( string name, int id )
        {
            ListViewItem item1 = new ListViewItem(name, id);
            TrackerList.Items.Add(item1);

            return true;
        }

        private void MobNew_Click(object sender, EventArgs e)
        {
            EditMobDialog editDlog = new EditMobDialog(new Monster(tr.newGUID()));

            DialogResult result = editDlog.ShowDialog(this);
            if(result == DialogResult.OK)
            {
                // do stuff
                tr.addMonster(editDlog.monster);
            }
        }

        private void MobEdit_Click(object sender, EventArgs e)
        {
            int selMob = currentMonster();
            if (selMob >= 0)
            {
                EditMobDialog editDlog = new EditMobDialog(tr.getMonster(selMob));

                DialogResult result = editDlog.ShowDialog(this);
                if (result == DialogResult.OK)
                    tr.monstersChanged();
            }
        }

        private void MobDupe_Click(object sender, EventArgs e)
        {
            int selMob = currentMonster();
            if (selMob >= 0)
            {
                Monster newMob = tr.getMonster(selMob).Clone();

                newMob.GUID = tr.newGUID();

                EditMobDialog editDlog = new EditMobDialog(newMob);

                DialogResult result = editDlog.ShowDialog(this);
                if (result == DialogResult.OK)
                    tr.addMonster(editDlog.monster);
            }
        }

        private void MobDelete_Click(object sender, EventArgs e)
        {
            int selMob = currentMonster();
            if (selMob >= 0)
            {
                tr.deleteMonster(selMob);
            }
        }

        // encounters

        public void clearEncounters()
        {
            MobEncounters.Items.Clear();
        }

        public int addEncounter(Encounter e)
        {
            MobEncounters.Items.Add(e.name);

            return MobEncounters.Items.Count - 1;
        }

        public void showEncounterMobs()
        {
            EncounterMobList.Items.Clear();
            Encounter e = tr.getEncounter(selectedEncounter);

            Dictionary<string, int> mobMap = new Dictionary<string,int>();

            foreach (MonsterInstance i in e.monsters)
            {
                if ( mobMap.ContainsKey(i.name))
                    mobMap[i.name]++;
                else
                    mobMap.Add(i.name,1);

                ListViewItem item = new ListViewItem(i.name, EncounterMobList.Items.Count);
                item.SubItems.Add(mobMap[i.name].ToString());
                EncounterMobList.Items.Add(item);
            }  
         }

        private void MobEncounters_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedEncounter = MobEncounters.SelectedIndex;
            showEncounterMobs();
        }

        private void MobNewEncounter_Click(object sender, EventArgs e)
        {
            Encounter enc = new Encounter();
            enc.name = "New_Encounter_" + tr.newGUID().ToString();

            tr.addEncounter(enc);
            MobEncounters.SelectedItem = MobEncounters.Items[MobEncounters.Items.Count - 1];
            selectedEncounter = MobEncounters.SelectedIndex;
            showEncounterMobs();
        }

        private void MobEncounters_Leave(object sender, EventArgs e)
        {
            int index = selectedEncounter;
            if ( index != -1 )
            {
                Encounter enc = tr.getEncounter(index);
                string newName = MobEncounters.Text;
                if (enc.name != newName)
                {
                    enc.name = newName;
                    enc.dirty = true;
                    tr.encountersChanged();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = selectedEncounter;
            if (index != -1)
            {
                tr.deleteEncounter(index);
            }
        }

        private void MobAddToEnc_Click(object sender, EventArgs e)
        {
            int selMob = currentMonster();
       
            if (selectedEncounter >= 0 && selMob >= 0)
            {
                tr.getEncounter(selectedEncounter).addMonster(tr.getMonster(selMob));
                tr.flushDirtyEncounters();
                showEncounterMobs();
            }
        }

        private void MobRemFromEnc_Click(object sender, EventArgs e)
        {
            int selMob = currentEncoutnerItem();
            if (selectedEncounter >= 0 && selMob >= 0)
            {
                tr.getEncounter(selectedEncounter).removeMonster(selMob);
                tr.flushDirtyEncounters();
                showEncounterMobs();
            }
        }

        private void EncounterMobList_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label.Length <= 0)
            {
                e.CancelEdit = true;
                return;
            }

            int selMob = currentEncoutnerItem();
            if (selectedEncounter >= 0 && selMob >= 0)
            {
                e.CancelEdit = false;
                Encounter enc = tr.getEncounter(selectedEncounter);
                MonsterInstance m = enc.monsters[selMob];
                m.name = e.Label;
                enc.dirty = true;
                tr.flushDirtyEncounters();
                showEncounterMobs();
            }
        }
    }
}