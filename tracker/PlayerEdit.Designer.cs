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
            this.SuspendLayout();
            // 
            // PlayerEditOK
            // 
            this.PlayerEditOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerEditOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.PlayerEditOK.Location = new System.Drawing.Point(474, 334);
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
            this.PlayerEditCancel.Location = new System.Drawing.Point(393, 334);
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
            this.PlayerEditCharacterName.Location = new System.Drawing.Point(167, 25);
            this.PlayerEditCharacterName.Name = "PlayerEditCharacterName";
            this.PlayerEditCharacterName.Size = new System.Drawing.Size(144, 20);
            this.PlayerEditCharacterName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Character";
            // 
            // PlayerEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 369);
            this.Controls.Add(this.PlayerEditCharacterName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PlayerEditPlayerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlayerEditCancel);
            this.Controls.Add(this.PlayerEditOK);
            this.Name = "PlayerEdit";
            this.Text = "PlayerEdit";
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
    }
}