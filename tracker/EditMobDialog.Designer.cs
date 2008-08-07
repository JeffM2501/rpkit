namespace tracker
{
    partial class EditMobDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EditMobOK = new System.Windows.Forms.Button();
            this.EditMobCancel = new System.Windows.Forms.Button();
            this.EditMobName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EditMobXP = new System.Windows.Forms.TextBox();
            this.EditMobLevel = new System.Windows.Forms.TextBox();
            this.EditMobClass = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.EditMobSpeed = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.EditMobWill = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.EditMobRef = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.EditMobFort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.EditMobAC = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.EditMobBloodied = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.EditMobHP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.EditMobSpecial = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.EditMobSenses = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.EditMobInit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.EditMobSizeCategory = new System.Windows.Forms.ComboBox();
            this.EditMobOrigin = new System.Windows.Forms.ComboBox();
            this.EditMobType = new System.Windows.Forms.ComboBox();
            this.EditMobSubType = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditMobOK
            // 
            this.EditMobOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EditMobOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.EditMobOK.Location = new System.Drawing.Point(459, 213);
            this.EditMobOK.Name = "EditMobOK";
            this.EditMobOK.Size = new System.Drawing.Size(75, 23);
            this.EditMobOK.TabIndex = 0;
            this.EditMobOK.Text = "Ok";
            this.EditMobOK.UseVisualStyleBackColor = true;
            this.EditMobOK.Click += new System.EventHandler(this.EditMobOK_Click);
            // 
            // EditMobCancel
            // 
            this.EditMobCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EditMobCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.EditMobCancel.Location = new System.Drawing.Point(378, 213);
            this.EditMobCancel.Name = "EditMobCancel";
            this.EditMobCancel.Size = new System.Drawing.Size(75, 23);
            this.EditMobCancel.TabIndex = 1;
            this.EditMobCancel.Text = "Cancel";
            this.EditMobCancel.UseVisualStyleBackColor = true;
            // 
            // EditMobName
            // 
            this.EditMobName.BackColor = System.Drawing.Color.DarkGreen;
            this.EditMobName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditMobName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditMobName.ForeColor = System.Drawing.Color.White;
            this.EditMobName.Location = new System.Drawing.Point(3, 4);
            this.EditMobName.Name = "EditMobName";
            this.EditMobName.Size = new System.Drawing.Size(366, 22);
            this.EditMobName.TabIndex = 2;
            this.EditMobName.Text = "Name";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.EditMobSubType);
            this.panel1.Controls.Add(this.EditMobType);
            this.panel1.Controls.Add(this.EditMobOrigin);
            this.panel1.Controls.Add(this.EditMobSizeCategory);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.EditMobXP);
            this.panel1.Controls.Add(this.EditMobLevel);
            this.panel1.Controls.Add(this.EditMobClass);
            this.panel1.Controls.Add(this.EditMobName);
            this.panel1.ForeColor = System.Drawing.Color.DarkGreen;
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 62);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(468, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "XP";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(375, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Level";
            // 
            // EditMobXP
            // 
            this.EditMobXP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditMobXP.BackColor = System.Drawing.Color.DarkGreen;
            this.EditMobXP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditMobXP.ForeColor = System.Drawing.Color.White;
            this.EditMobXP.Location = new System.Drawing.Point(495, 33);
            this.EditMobXP.Name = "EditMobXP";
            this.EditMobXP.Size = new System.Drawing.Size(48, 20);
            this.EditMobXP.TabIndex = 7;
            this.EditMobXP.Text = "0";
            // 
            // EditMobLevel
            // 
            this.EditMobLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditMobLevel.BackColor = System.Drawing.Color.DarkGreen;
            this.EditMobLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditMobLevel.ForeColor = System.Drawing.Color.White;
            this.EditMobLevel.Location = new System.Drawing.Point(411, 4);
            this.EditMobLevel.Name = "EditMobLevel";
            this.EditMobLevel.Size = new System.Drawing.Size(31, 20);
            this.EditMobLevel.TabIndex = 6;
            this.EditMobLevel.Text = "1";
            // 
            // EditMobClass
            // 
            this.EditMobClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditMobClass.BackColor = System.Drawing.Color.DarkGreen;
            this.EditMobClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditMobClass.ForeColor = System.Drawing.Color.White;
            this.EditMobClass.Location = new System.Drawing.Point(443, 4);
            this.EditMobClass.Name = "EditMobClass";
            this.EditMobClass.Size = new System.Drawing.Size(100, 20);
            this.EditMobClass.TabIndex = 5;
            this.EditMobClass.Text = "Class";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panel2.Controls.Add(this.checkedListBox2);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.checkedListBox1);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.EditMobSpeed);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.EditMobWill);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.EditMobRef);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.EditMobFort);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.EditMobAC);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.EditMobBloodied);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.EditMobHP);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.EditMobSpecial);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.EditMobSenses);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.EditMobInit);
            this.panel2.Controls.Add(this.label3);
            this.panel2.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.panel2.Location = new System.Drawing.Point(1, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(544, 143);
            this.panel2.TabIndex = 4;
            // 
            // EditMobSpeed
            // 
            this.EditMobSpeed.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.EditMobSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditMobSpeed.ForeColor = System.Drawing.Color.Black;
            this.EditMobSpeed.Location = new System.Drawing.Point(52, 110);
            this.EditMobSpeed.Name = "EditMobSpeed";
            this.EditMobSpeed.Size = new System.Drawing.Size(50, 20);
            this.EditMobSpeed.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(3, 112);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Speed";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(309, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Resist";
            // 
            // EditMobWill
            // 
            this.EditMobWill.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.EditMobWill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditMobWill.ForeColor = System.Drawing.Color.Black;
            this.EditMobWill.Location = new System.Drawing.Point(264, 81);
            this.EditMobWill.Name = "EditMobWill";
            this.EditMobWill.Size = new System.Drawing.Size(42, 20);
            this.EditMobWill.TabIndex = 26;
            this.EditMobWill.Text = "0";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(235, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Will";
            // 
            // EditMobRef
            // 
            this.EditMobRef.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.EditMobRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditMobRef.ForeColor = System.Drawing.Color.Black;
            this.EditMobRef.Location = new System.Drawing.Point(186, 81);
            this.EditMobRef.Name = "EditMobRef";
            this.EditMobRef.Size = new System.Drawing.Size(42, 20);
            this.EditMobRef.TabIndex = 24;
            this.EditMobRef.Text = "0";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(157, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Ref";
            // 
            // EditMobFort
            // 
            this.EditMobFort.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.EditMobFort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditMobFort.ForeColor = System.Drawing.Color.Black;
            this.EditMobFort.Location = new System.Drawing.Point(108, 81);
            this.EditMobFort.Name = "EditMobFort";
            this.EditMobFort.Size = new System.Drawing.Size(42, 20);
            this.EditMobFort.TabIndex = 22;
            this.EditMobFort.Text = "0";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(79, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Fort";
            // 
            // EditMobAC
            // 
            this.EditMobAC.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.EditMobAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditMobAC.ForeColor = System.Drawing.Color.Black;
            this.EditMobAC.Location = new System.Drawing.Point(30, 81);
            this.EditMobAC.Name = "EditMobAC";
            this.EditMobAC.Size = new System.Drawing.Size(42, 20);
            this.EditMobAC.TabIndex = 20;
            this.EditMobAC.Text = "0";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(3, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "AC";
            // 
            // EditMobBloodied
            // 
            this.EditMobBloodied.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.EditMobBloodied.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EditMobBloodied.ForeColor = System.Drawing.Color.Black;
            this.EditMobBloodied.Location = new System.Drawing.Point(141, 57);
            this.EditMobBloodied.Name = "EditMobBloodied";
            this.EditMobBloodied.ReadOnly = true;
            this.EditMobBloodied.Size = new System.Drawing.Size(42, 13);
            this.EditMobBloodied.TabIndex = 18;
            this.EditMobBloodied.TabStop = false;
            this.EditMobBloodied.Text = "0";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(79, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Bloodied";
            // 
            // EditMobHP
            // 
            this.EditMobHP.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.EditMobHP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditMobHP.ForeColor = System.Drawing.Color.Black;
            this.EditMobHP.Location = new System.Drawing.Point(30, 55);
            this.EditMobHP.Name = "EditMobHP";
            this.EditMobHP.Size = new System.Drawing.Size(42, 20);
            this.EditMobHP.TabIndex = 16;
            this.EditMobHP.Text = "0";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(3, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "HP";
            // 
            // EditMobSpecial
            // 
            this.EditMobSpecial.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.EditMobSpecial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditMobSpecial.ForeColor = System.Drawing.Color.Black;
            this.EditMobSpecial.Location = new System.Drawing.Point(58, 29);
            this.EditMobSpecial.Name = "EditMobSpecial";
            this.EditMobSpecial.Size = new System.Drawing.Size(475, 20);
            this.EditMobSpecial.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(3, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Special";
            // 
            // EditMobSenses
            // 
            this.EditMobSenses.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.EditMobSenses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditMobSenses.ForeColor = System.Drawing.Color.Black;
            this.EditMobSenses.Location = new System.Drawing.Point(168, 3);
            this.EditMobSenses.Name = "EditMobSenses";
            this.EditMobSenses.Size = new System.Drawing.Size(365, 20);
            this.EditMobSenses.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(121, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Senses";
            // 
            // EditMobInit
            // 
            this.EditMobInit.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.EditMobInit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditMobInit.ForeColor = System.Drawing.Color.Black;
            this.EditMobInit.Location = new System.Drawing.Point(58, 3);
            this.EditMobInit.Name = "EditMobInit";
            this.EditMobInit.Size = new System.Drawing.Size(56, 20);
            this.EditMobInit.TabIndex = 10;
            this.EditMobInit.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Initiative";
            // 
            // EditMobSizeCategory
            // 
            this.EditMobSizeCategory.BackColor = System.Drawing.Color.DarkGreen;
            this.EditMobSizeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EditMobSizeCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditMobSizeCategory.ForeColor = System.Drawing.Color.White;
            this.EditMobSizeCategory.FormattingEnabled = true;
            this.EditMobSizeCategory.Items.AddRange(new object[] {
            "Fine",
            "Diminutive",
            "Tiny",
            "Small",
            "Medium",
            "Large",
            "Huge",
            "Gargantuan",
            "Colossal"});
            this.EditMobSizeCategory.Location = new System.Drawing.Point(1, 31);
            this.EditMobSizeCategory.Name = "EditMobSizeCategory";
            this.EditMobSizeCategory.Size = new System.Drawing.Size(73, 21);
            this.EditMobSizeCategory.TabIndex = 10;
            this.EditMobSizeCategory.SelectedIndexChanged += new System.EventHandler(this.EditMobSizeCategory_SelectedIndexChanged);
            // 
            // EditMobOrigin
            // 
            this.EditMobOrigin.BackColor = System.Drawing.Color.DarkGreen;
            this.EditMobOrigin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EditMobOrigin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditMobOrigin.ForeColor = System.Drawing.Color.White;
            this.EditMobOrigin.FormattingEnabled = true;
            this.EditMobOrigin.Items.AddRange(new object[] {
            "Aberrant",
            "Elemental",
            "Fey",
            "Immortal",
            "Natural",
            "Shadow"});
            this.EditMobOrigin.Location = new System.Drawing.Point(79, 31);
            this.EditMobOrigin.Name = "EditMobOrigin";
            this.EditMobOrigin.Size = new System.Drawing.Size(120, 21);
            this.EditMobOrigin.TabIndex = 11;
            // 
            // EditMobType
            // 
            this.EditMobType.BackColor = System.Drawing.Color.DarkGreen;
            this.EditMobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EditMobType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditMobType.ForeColor = System.Drawing.Color.White;
            this.EditMobType.FormattingEnabled = true;
            this.EditMobType.Items.AddRange(new object[] {
            "Animate",
            "Beast",
            "Humanoid",
            "Magical Beast"});
            this.EditMobType.Location = new System.Drawing.Point(205, 31);
            this.EditMobType.Name = "EditMobType";
            this.EditMobType.Size = new System.Drawing.Size(120, 21);
            this.EditMobType.TabIndex = 12;
            // 
            // EditMobSubType
            // 
            this.EditMobSubType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditMobSubType.BackColor = System.Drawing.Color.DarkGreen;
            this.EditMobSubType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditMobSubType.ForeColor = System.Drawing.Color.White;
            this.EditMobSubType.Location = new System.Drawing.Point(331, 32);
            this.EditMobSubType.Name = "EditMobSubType";
            this.EditMobSubType.Size = new System.Drawing.Size(131, 20);
            this.EditMobSubType.TabIndex = 13;
            this.EditMobSubType.Text = "SubType";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(135, 110);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(50, 20);
            this.textBox1.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(106, 112);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Fly";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(234, 110);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(50, 20);
            this.textBox2.TabIndex = 34;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(191, 112);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "Climb";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Fire",
            "Ice",
            "Radiant",
            "Necrotic",
            "Psycic",
            "Acid",
            "Sonic"});
            this.checkedListBox1.Location = new System.Drawing.Point(312, 73);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(99, 45);
            this.checkedListBox1.TabIndex = 35;
            this.checkedListBox1.ThreeDCheckBoxes = true;
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.checkedListBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            "Fire",
            "Ice",
            "Radiant",
            "Necrotic",
            "Psycic",
            "Acid",
            "Sonic"});
            this.checkedListBox2.Location = new System.Drawing.Point(426, 73);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(99, 45);
            this.checkedListBox2.TabIndex = 37;
            this.checkedListBox2.ThreeDCheckBoxes = true;
            this.checkedListBox2.SelectedIndexChanged += new System.EventHandler(this.checkedListBox2_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(425, 57);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 13);
            this.label16.TabIndex = 36;
            this.label16.Text = "Vulnerability";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // EditMobDialog
            // 
            this.AcceptButton = this.EditMobOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.EditMobCancel;
            this.ClientSize = new System.Drawing.Size(546, 248);
            this.Controls.Add(this.EditMobCancel);
            this.Controls.Add(this.EditMobOK);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditMobDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Edit Monster";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button EditMobOK;
        private System.Windows.Forms.Button EditMobCancel;
        private System.Windows.Forms.TextBox EditMobName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EditMobXP;
        private System.Windows.Forms.TextBox EditMobLevel;
        private System.Windows.Forms.TextBox EditMobClass;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EditMobBloodied;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox EditMobHP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox EditMobSpecial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox EditMobSenses;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox EditMobInit;
        private System.Windows.Forms.TextBox EditMobSpeed;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox EditMobWill;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox EditMobRef;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox EditMobFort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox EditMobAC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox EditMobSizeCategory;
        private System.Windows.Forms.ComboBox EditMobType;
        private System.Windows.Forms.ComboBox EditMobOrigin;
        private System.Windows.Forms.TextBox EditMobSubType;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.Label label16;
    }
}