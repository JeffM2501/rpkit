using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tracker
{
    public partial class EditMobDialog : Form
    {
        private Monster mob;
        public Monster monster
        {
            get
            {
                return mob;
            }
            set
            {
                mob = value;
            }
        }

        public EditMobDialog( Monster m )
        {
            mob = m;
            InitializeComponent();

            if (monster.name.Length != 0)
            {
                EditMobName.Text = monster.name;
                EditMobXP.Text = monster.XP.ToString();
                EditMobLevel.Text = monster.level.ToString();
                EditMobClass.Text = monster.className;
                EditMobType.Text = monster.type;
                EditMobSize.Text = monster.size;
                int bloodied = monster.stats.health.maxHP / 2;
                EditMobBloodied.Text = bloodied.ToString();
                EditMobHP.Text = monster.stats.health.maxHP.ToString();
                EditMobSpecial.Text = monster.special;
                EditMobSenses.Text = monster.senses;
                EditMobInit.Text = monster.stats.inititive.ToString();
                EditMobSpeed.Text = monster.speed;
                EditMobResist.Text = monster.resist;
                EditMobWill.Text = monster.stats.defenses.will.ToString();
                EditMobRef.Text = monster.stats.defenses.reflex.ToString();
                EditMobFort.Text = monster.stats.defenses.fortitude.ToString();
                EditMobAC.Text = monster.stats.defenses.AC.ToString();
            }
        }

        private void EditMobOK_Click(object sender, EventArgs e)
        {
            // save off all the monster stuff

            monster.name = EditMobName.Text;
            int.TryParse(EditMobXP.Text, out monster.XP);
            int.TryParse(EditMobLevel.Text, out monster.level);
            monster.className = EditMobClass.Text;
            monster.type = EditMobType.Text;
            monster.size = EditMobSize.Text;
            int.TryParse(EditMobHP.Text, out monster.stats.health.maxHP);
            monster.special = EditMobSpecial.Text;
            monster.senses = EditMobSenses.Text;
            int.TryParse(EditMobInit.Text, out monster.stats.inititive);
            monster.speed = EditMobSpeed.Text;
            monster.resist = EditMobResist.Text;
            int.TryParse(EditMobWill.Text, out monster.stats.defenses.will);
            int.TryParse(EditMobRef.Text, out monster.stats.defenses.reflex);
            int.TryParse(EditMobFort.Text, out monster.stats.defenses.fortitude);
            int.TryParse(EditMobAC.Text, out monster.stats.defenses.AC);
            monster.dirty = true;
        }
    }
}