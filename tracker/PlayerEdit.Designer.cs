namespace tracker
{
    partial class PlayerEdit
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
            this.PlayerEditOK = new System.Windows.Forms.Button();
            this.PlayerEditCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PlayerEditPlayerName = new System.Windows.Forms.TextBox();
            this.PlayerEditCharacterName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PlayerEditInit = new System.Windows.Forms.TextBox();
            this.PlayerEditMaxHP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PlayerEditCurrentHP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PlayerEditTempHP = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayerEditOK
            // 
            this.PlayerEditOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerEditOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.PlayerEditOK.Location = new System.Drawing.Point(235, 334);
            this.PlayerEditOK.Name = "PlayerEditOK";
            this.PlayerEditOK.Size = new System.Drawing.Size(75, 23);
            this.PlayerEditOK.TabIndex = 0;
            this.PlayerEditOK.Text = "OK";
            this.PlayerEditOK.UseVisualStyleBackColor = true;
            // 
            // PlayerEditCancel
            // 
            this.PlayerEditCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerEditCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.PlayerEditCancel.Location = new System.Drawing.Point(154, 334);
            this.PlayerEditCancel.Name = "PlayerEditCancel";
            this.PlayerEditCancel.Size = new System.Drawing.Size(75, 23);
            this.PlayerEditCancel.TabIndex = 1;
            this.PlayerEditCancel.Text = "Cancel";
            this.PlayerEditCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Player";
            // 
            // PlayerEditPlayerName
            // 
            this.PlayerEditPlayerName.Location = new System.Drawing.Point(12, 25);
            this.PlayerEditPlayerName.Name = "PlayerEditPlayerName";
            this.PlayerEditPlayerName.Size = new System.Drawing.Size(144, 20);
            this.PlayerEditPlayerName.TabIndex = 3;
            // 
            // PlayerEditCharacterName
            // 
            this.PlayerEditCharacterName.Location = new System.Drawing.Point(12, 64);
            this.PlayerEditCharacterName.Name = "PlayerEditCharacterName";
            this.PlayerEditCharacterName.Size = new System.Drawing.Size(144, 20);
            this.PlayerEditCharacterName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Character";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Initiative";
            // 
            // PlayerEditInit
            // 
            this.PlayerEditInit.Location = new System.Drawing.Point(162, 64);
            this.PlayerEditInit.Name = "PlayerEditInit";
            this.PlayerEditInit.Size = new System.Drawing.Size(46, 20);
            this.PlayerEditInit.TabIndex = 7;
            // 
            // PlayerEditMaxHP
            // 
            this.PlayerEditMaxHP.Location = new System.Drawing.Point(9, 32);
            this.PlayerEditMaxHP.Name = "PlayerEditMaxHP";
            this.PlayerEditMaxHP.Size = new System.Drawing.Size(46, 20);
            this.PlayerEditMaxHP.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Max";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.PlayerEditTempHP);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.PlayerEditCurrentHP);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.PlayerEditMaxHP);
            this.groupBox1.Location = new System.Drawing.Point(12, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 62);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hit Points";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Current";
            // 
            // PlayerEditCurrentHP
            // 
            this.PlayerEditCurrentHP.Location = new System.Drawing.Point(61, 32);
            this.PlayerEditCurrentHP.Name = "PlayerEditCurrentHP";
            this.PlayerEditCurrentHP.Size = new System.Drawing.Size(46, 20);
            this.PlayerEditCurrentHP.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(113, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Temp";
            // 
            // PlayerEditTempHP
            // 
            this.PlayerEditTempHP.Location = new System.Drawing.Point(113, 32);
            this.PlayerEditTempHP.Name = "PlayerEditTempHP";
            this.PlayerEditTempHP.Size = new System.Drawing.Size(46, 20);
            this.PlayerEditTempHP.TabIndex = 13;
            // 
            // PlayerEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 369);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PlayerEditInit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PlayerEditCharacterName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PlayerEditPlayerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlayerEditCancel);
            this.Controls.Add(this.PlayerEditOK);
            this.Name = "PlayerEdit";
            this.Text = "PlayerEdit";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PlayerEditOK;
        private System.Windows.Forms.Button PlayerEditCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PlayerEditPlayerName;
        private System.Windows.Forms.TextBox PlayerEditCharacterName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PlayerEditInit;
        private System.Windows.Forms.TextBox PlayerEditMaxHP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PlayerEditTempHP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PlayerEditCurrentHP;
    }
}