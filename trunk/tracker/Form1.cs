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

        public Form1()
        {
            InitializeComponent();

            tr = new TrackerLogic(this);  
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void PartyEdit_Click(object sender, EventArgs e)
        {

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
            EncountersList.Items.Clear();
            MobEncounters.Items.Clear();
        }

        public int addEncounter(Encounter e)
        {
            int id = EncountersList.Items.Count;
            ListViewItem item = new ListViewItem(e.name, id);
            item.SubItems.Add(e.code);
            item.SubItems.Add(e.monsters.Count.ToString());
            EncountersList.Items.Add(item);

            MobEncounters.Items.Add(e.name);

            return id;
        }

        public int currentEncounter()
        {
            if (EncountersList.SelectedItems.Count == 0)
                return -1;

            return EncountersList.SelectedItems[0].Index;
        }

        private void MobEncounters_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MobNewEncounter_Click(object sender, EventArgs e)
        {
            Encounter enc = new Encounter();
            enc.name = "New_Encounter_" + tr.newGUID().ToString();

            tr.addEncounter(enc);
            MobEncounters.SelectedItem = MobEncounters.Items[MobEncounters.Items.Count - 1];
        }
    }
}