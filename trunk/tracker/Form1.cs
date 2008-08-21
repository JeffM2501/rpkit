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
            MobEncounters.Items.Clear();
        }

        public int addEncounter(Encounter e)
        {
            MobEncounters.Items.Add(e.name);

            return MobEncounters.Items.Count - 1;
        }

        public int currentEncounter()
        {
            if (MobEncounters.SelectedIndex == -1)
                return -1;

            return MobEncounters.SelectedIndex;
        }

        private void MobEncounters_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedEncounter = MobEncounters.SelectedIndex;
        }

        private void MobNewEncounter_Click(object sender, EventArgs e)
        {
            Encounter enc = new Encounter();
            enc.name = "New_Encounter_" + tr.newGUID().ToString();

            tr.addEncounter(enc);
            MobEncounters.SelectedItem = MobEncounters.Items[MobEncounters.Items.Count - 1];
        }

        private void MonstersPage_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MobDatabase_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void PartyDelete_Click(object sender, EventArgs e)
        {

        }

        private void PartyNew_Click(object sender, EventArgs e)
        {

        }

        private void PartyEdit_Click_1(object sender, EventArgs e)
        {

        }

        private void MobEncounters_TextChanged(object sender, EventArgs e)
        {

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
    }
}