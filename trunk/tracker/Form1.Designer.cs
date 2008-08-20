namespace tracker
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TrackerPage = new System.Windows.Forms.TabPage();
            this.Start = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.TrackerList = new System.Windows.Forms.ListView();
            this.Character = new System.Windows.Forms.ColumnHeader();
            this.Player = new System.Windows.Forms.ColumnHeader();
            this.Code = new System.Windows.Forms.ColumnHeader();
            this.HP = new System.Windows.Forms.ColumnHeader();
            this.AC = new System.Windows.Forms.ColumnHeader();
            this.Fort = new System.Windows.Forms.ColumnHeader();
            this.Ref = new System.Windows.Forms.ColumnHeader();
            this.Will = new System.Windows.Forms.ColumnHeader();
            this.Status = new System.Windows.Forms.ColumnHeader();
            this.EncountersPage = new System.Windows.Forms.TabPage();
            this.EncountersList = new System.Windows.Forms.ListView();
            this.EncounterMobName = new System.Windows.Forms.ColumnHeader();
            this.EncounterCode = new System.Windows.Forms.ColumnHeader();
            this.EncounterCount = new System.Windows.Forms.ColumnHeader();
            this.PartyPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PartyParties = new System.Windows.Forms.ComboBox();
            this.PartyEdit = new System.Windows.Forms.Button();
            this.PartyDelete = new System.Windows.Forms.Button();
            this.PartyAdd = new System.Windows.Forms.Button();
            this.PartyShortRest = new System.Windows.Forms.Button();
            this.PartyMilestone = new System.Windows.Forms.Button();
            this.PartyRest = new System.Windows.Forms.Button();
            this.PartyList = new System.Windows.Forms.ListView();
            this.PartyCharacter = new System.Windows.Forms.ColumnHeader();
            this.PartyPlayer = new System.Windows.Forms.ColumnHeader();
            this.PlayerInitMod = new System.Windows.Forms.ColumnHeader();
            this.PlayerAC = new System.Windows.Forms.ColumnHeader();
            this.PlayerFort = new System.Windows.Forms.ColumnHeader();
            this.PlayerRef = new System.Windows.Forms.ColumnHeader();
            this.PlayerWill = new System.Windows.Forms.ColumnHeader();
            this.PlayerHP = new System.Windows.Forms.ColumnHeader();
            this.PlayerActionPoints = new System.Windows.Forms.ColumnHeader();
            this.PlayerSurges = new System.Windows.Forms.ColumnHeader();
            this.MonstersPage = new System.Windows.Forms.TabPage();
            this.MobNewEncounter = new System.Windows.Forms.Button();
            this.MobEncounters = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MobDatabase = new System.Windows.Forms.GroupBox();
            this.MobEdit = new System.Windows.Forms.Button();
            this.MobDupe = new System.Windows.Forms.Button();
            this.MobDelete = new System.Windows.Forms.Button();
            this.MobNew = new System.Windows.Forms.Button();
            this.MobSearch = new System.Windows.Forms.Button();
            this.MobSearchTerm = new System.Windows.Forms.TextBox();
            this.MobAddN = new System.Windows.Forms.Button();
            this.MobAdd1 = new System.Windows.Forms.Button();
            this.MobList = new System.Windows.Forms.ListView();
            this.MobName = new System.Windows.Forms.ColumnHeader();
            this.MobInit = new System.Windows.Forms.ColumnHeader();
            this.MobHP = new System.Windows.Forms.ColumnHeader();
            this.MobAC = new System.Windows.Forms.ColumnHeader();
            this.MobFort = new System.Windows.Forms.ColumnHeader();
            this.MobRef = new System.Windows.Forms.ColumnHeader();
            this.MobWill = new System.Windows.Forms.ColumnHeader();
            this.tabControl1.SuspendLayout();
            this.TrackerPage.SuspendLayout();
            this.EncountersPage.SuspendLayout();
            this.PartyPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.MonstersPage.SuspendLayout();
            this.MobDatabase.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.TrackerPage);
            this.tabControl1.Controls.Add(this.EncountersPage);
            this.tabControl1.Controls.Add(this.PartyPage);
            this.tabControl1.Controls.Add(this.MonstersPage);
            this.tabControl1.Location = new System.Drawing.Point(-1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(401, 455);
            this.tabControl1.TabIndex = 0;
            // 
            // TrackerPage
            // 
            this.TrackerPage.Controls.Add(this.Start);
            this.TrackerPage.Controls.Add(this.Next);
            this.TrackerPage.Controls.Add(this.TrackerList);
            this.TrackerPage.Location = new System.Drawing.Point(4, 22);
            this.TrackerPage.Name = "TrackerPage";
            this.TrackerPage.Padding = new System.Windows.Forms.Padding(3);
            this.TrackerPage.Size = new System.Drawing.Size(393, 429);
            this.TrackerPage.TabIndex = 0;
            this.TrackerPage.Text = "Tracker";
            this.TrackerPage.UseVisualStyleBackColor = true;
            this.TrackerPage.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(309, 369);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 2;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(10, 369);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(75, 23);
            this.Next.TabIndex = 1;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            // 
            // TrackerList
            // 
            this.TrackerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Character,
            this.Player,
            this.Code,
            this.HP,
            this.AC,
            this.Fort,
            this.Ref,
            this.Will,
            this.Status});
            this.TrackerList.FullRowSelect = true;
            this.TrackerList.GridLines = true;
            this.TrackerList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.TrackerList.Location = new System.Drawing.Point(10, 7);
            this.TrackerList.Name = "TrackerList";
            this.TrackerList.Size = new System.Drawing.Size(374, 356);
            this.TrackerList.TabIndex = 0;
            this.TrackerList.UseCompatibleStateImageBehavior = false;
            this.TrackerList.View = System.Windows.Forms.View.Details;
            // 
            // Character
            // 
            this.Character.Text = "Character";
            this.Character.Width = 80;
            // 
            // Player
            // 
            this.Player.Text = "Player";
            this.Player.Width = 46;
            // 
            // Code
            // 
            this.Code.Text = "Code";
            this.Code.Width = 46;
            // 
            // HP
            // 
            this.HP.Text = "HP";
            this.HP.Width = 36;
            // 
            // AC
            // 
            this.AC.Text = "AC";
            this.AC.Width = 31;
            // 
            // Fort
            // 
            this.Fort.Text = "F";
            this.Fort.Width = 25;
            // 
            // Ref
            // 
            this.Ref.Text = "R";
            this.Ref.Width = 29;
            // 
            // Will
            // 
            this.Will.Text = "W";
            this.Will.Width = 24;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 48;
            // 
            // EncountersPage
            // 
            this.EncountersPage.Controls.Add(this.EncountersList);
            this.EncountersPage.Location = new System.Drawing.Point(4, 22);
            this.EncountersPage.Name = "EncountersPage";
            this.EncountersPage.Size = new System.Drawing.Size(393, 429);
            this.EncountersPage.TabIndex = 3;
            this.EncountersPage.Text = "Encounters";
            this.EncountersPage.UseVisualStyleBackColor = true;
            // 
            // EncountersList
            // 
            this.EncountersList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EncounterMobName,
            this.EncounterCode,
            this.EncounterCount});
            this.EncountersList.GridLines = true;
            this.EncountersList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.EncountersList.Location = new System.Drawing.Point(4, 4);
            this.EncountersList.Name = "EncountersList";
            this.EncountersList.Size = new System.Drawing.Size(386, 247);
            this.EncountersList.TabIndex = 0;
            this.EncountersList.UseCompatibleStateImageBehavior = false;
            this.EncountersList.View = System.Windows.Forms.View.Details;
            // 
            // EncounterMobName
            // 
            this.EncounterMobName.Text = "Name";
            this.EncounterMobName.Width = 292;
            // 
            // EncounterCode
            // 
            this.EncounterCode.Text = "Code";
            this.EncounterCode.Width = 43;
            // 
            // EncounterCount
            // 
            this.EncounterCount.Text = "Count";
            this.EncounterCount.Width = 45;
            // 
            // PartyPage
            // 
            this.PartyPage.Controls.Add(this.groupBox1);
            this.PartyPage.Controls.Add(this.PartyShortRest);
            this.PartyPage.Controls.Add(this.PartyMilestone);
            this.PartyPage.Controls.Add(this.PartyRest);
            this.PartyPage.Controls.Add(this.PartyList);
            this.PartyPage.Location = new System.Drawing.Point(4, 22);
            this.PartyPage.Name = "PartyPage";
            this.PartyPage.Padding = new System.Windows.Forms.Padding(3);
            this.PartyPage.Size = new System.Drawing.Size(393, 429);
            this.PartyPage.TabIndex = 1;
            this.PartyPage.Text = "Party";
            this.PartyPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.PartyParties);
            this.groupBox1.Controls.Add(this.PartyEdit);
            this.groupBox1.Controls.Add(this.PartyDelete);
            this.groupBox1.Controls.Add(this.PartyAdd);
            this.groupBox1.Location = new System.Drawing.Point(4, 337);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 89);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(342, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Parties";
            // 
            // PartyParties
            // 
            this.PartyParties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PartyParties.FormattingEnabled = true;
            this.PartyParties.Location = new System.Drawing.Point(203, 32);
            this.PartyParties.Name = "PartyParties";
            this.PartyParties.Size = new System.Drawing.Size(179, 21);
            this.PartyParties.TabIndex = 3;
            // 
            // PartyEdit
            // 
            this.PartyEdit.Location = new System.Drawing.Point(6, 48);
            this.PartyEdit.Name = "PartyEdit";
            this.PartyEdit.Size = new System.Drawing.Size(75, 23);
            this.PartyEdit.TabIndex = 2;
            this.PartyEdit.Text = "Edit";
            this.PartyEdit.UseVisualStyleBackColor = true;
            this.PartyEdit.Click += new System.EventHandler(this.PartyEdit_Click);
            // 
            // PartyDelete
            // 
            this.PartyDelete.Location = new System.Drawing.Point(87, 19);
            this.PartyDelete.Name = "PartyDelete";
            this.PartyDelete.Size = new System.Drawing.Size(75, 23);
            this.PartyDelete.TabIndex = 1;
            this.PartyDelete.Text = "Delete";
            this.PartyDelete.UseVisualStyleBackColor = true;
            // 
            // PartyAdd
            // 
            this.PartyAdd.Location = new System.Drawing.Point(6, 19);
            this.PartyAdd.Name = "PartyAdd";
            this.PartyAdd.Size = new System.Drawing.Size(75, 23);
            this.PartyAdd.TabIndex = 0;
            this.PartyAdd.Text = "Add";
            this.PartyAdd.UseVisualStyleBackColor = true;
            // 
            // PartyShortRest
            // 
            this.PartyShortRest.Location = new System.Drawing.Point(315, 308);
            this.PartyShortRest.Name = "PartyShortRest";
            this.PartyShortRest.Size = new System.Drawing.Size(75, 23);
            this.PartyShortRest.TabIndex = 3;
            this.PartyShortRest.Text = "Short Rest";
            this.PartyShortRest.UseVisualStyleBackColor = true;
            // 
            // PartyMilestone
            // 
            this.PartyMilestone.Location = new System.Drawing.Point(85, 308);
            this.PartyMilestone.Name = "PartyMilestone";
            this.PartyMilestone.Size = new System.Drawing.Size(75, 23);
            this.PartyMilestone.TabIndex = 2;
            this.PartyMilestone.Text = "Milestone";
            this.PartyMilestone.UseVisualStyleBackColor = true;
            // 
            // PartyRest
            // 
            this.PartyRest.Location = new System.Drawing.Point(4, 308);
            this.PartyRest.Name = "PartyRest";
            this.PartyRest.Size = new System.Drawing.Size(75, 23);
            this.PartyRest.TabIndex = 1;
            this.PartyRest.Text = "Rest";
            this.PartyRest.UseVisualStyleBackColor = true;
            // 
            // PartyList
            // 
            this.PartyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PartyCharacter,
            this.PartyPlayer,
            this.PlayerInitMod,
            this.PlayerAC,
            this.PlayerFort,
            this.PlayerRef,
            this.PlayerWill,
            this.PlayerHP,
            this.PlayerActionPoints,
            this.PlayerSurges});
            this.PartyList.FullRowSelect = true;
            this.PartyList.GridLines = true;
            this.PartyList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.PartyList.Location = new System.Drawing.Point(4, 4);
            this.PartyList.Name = "PartyList";
            this.PartyList.Size = new System.Drawing.Size(386, 298);
            this.PartyList.TabIndex = 0;
            this.PartyList.UseCompatibleStateImageBehavior = false;
            this.PartyList.View = System.Windows.Forms.View.Details;
            // 
            // PartyCharacter
            // 
            this.PartyCharacter.Text = "Character";
            this.PartyCharacter.Width = 70;
            // 
            // PartyPlayer
            // 
            this.PartyPlayer.Text = "Player";
            this.PartyPlayer.Width = 50;
            // 
            // PlayerInitMod
            // 
            this.PlayerInitMod.Text = "Init";
            this.PlayerInitMod.Width = 26;
            // 
            // PlayerAC
            // 
            this.PlayerAC.Text = "AC";
            this.PlayerAC.Width = 28;
            // 
            // PlayerFort
            // 
            this.PlayerFort.Text = "F";
            this.PlayerFort.Width = 24;
            // 
            // PlayerRef
            // 
            this.PlayerRef.Text = "R";
            this.PlayerRef.Width = 24;
            // 
            // PlayerWill
            // 
            this.PlayerWill.Text = "W";
            this.PlayerWill.Width = 25;
            // 
            // PlayerHP
            // 
            this.PlayerHP.Text = "HP";
            this.PlayerHP.Width = 29;
            // 
            // PlayerActionPoints
            // 
            this.PlayerActionPoints.Text = "AP";
            this.PlayerActionPoints.Width = 31;
            // 
            // PlayerSurges
            // 
            this.PlayerSurges.Text = "Surges";
            this.PlayerSurges.Width = 46;
            // 
            // MonstersPage
            // 
            this.MonstersPage.Controls.Add(this.MobNewEncounter);
            this.MonstersPage.Controls.Add(this.MobEncounters);
            this.MonstersPage.Controls.Add(this.label2);
            this.MonstersPage.Controls.Add(this.MobDatabase);
            this.MonstersPage.Controls.Add(this.MobAddN);
            this.MonstersPage.Controls.Add(this.MobAdd1);
            this.MonstersPage.Controls.Add(this.MobList);
            this.MonstersPage.Location = new System.Drawing.Point(4, 22);
            this.MonstersPage.Name = "MonstersPage";
            this.MonstersPage.Size = new System.Drawing.Size(393, 429);
            this.MonstersPage.TabIndex = 2;
            this.MonstersPage.Text = "Monsters";
            this.MonstersPage.UseVisualStyleBackColor = true;
            // 
            // MobNewEncounter
            // 
            this.MobNewEncounter.Location = new System.Drawing.Point(310, 117);
            this.MobNewEncounter.Name = "MobNewEncounter";
            this.MobNewEncounter.Size = new System.Drawing.Size(75, 34);
            this.MobNewEncounter.TabIndex = 6;
            this.MobNewEncounter.Text = "New Encounter";
            this.MobNewEncounter.UseVisualStyleBackColor = true;
            this.MobNewEncounter.Click += new System.EventHandler(this.MobNewEncounter_Click);
            // 
            // MobEncounters
            // 
            this.MobEncounters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MobEncounters.FormattingEnabled = true;
            this.MobEncounters.Location = new System.Drawing.Point(298, 90);
            this.MobEncounters.Name = "MobEncounters";
            this.MobEncounters.Size = new System.Drawing.Size(93, 21);
            this.MobEncounters.TabIndex = 5;
            this.MobEncounters.SelectedIndexChanged += new System.EventHandler(this.MobEncounters_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Encounters";
            // 
            // MobDatabase
            // 
            this.MobDatabase.Controls.Add(this.MobEdit);
            this.MobDatabase.Controls.Add(this.MobDupe);
            this.MobDatabase.Controls.Add(this.MobDelete);
            this.MobDatabase.Controls.Add(this.MobNew);
            this.MobDatabase.Controls.Add(this.MobSearch);
            this.MobDatabase.Controls.Add(this.MobSearchTerm);
            this.MobDatabase.Location = new System.Drawing.Point(3, 290);
            this.MobDatabase.Name = "MobDatabase";
            this.MobDatabase.Size = new System.Drawing.Size(382, 113);
            this.MobDatabase.TabIndex = 3;
            this.MobDatabase.TabStop = false;
            this.MobDatabase.Text = "Database";
            // 
            // MobEdit
            // 
            this.MobEdit.Location = new System.Drawing.Point(88, 76);
            this.MobEdit.Name = "MobEdit";
            this.MobEdit.Size = new System.Drawing.Size(75, 23);
            this.MobEdit.TabIndex = 5;
            this.MobEdit.Text = "Edit";
            this.MobEdit.UseVisualStyleBackColor = true;
            this.MobEdit.Click += new System.EventHandler(this.MobEdit_Click);
            // 
            // MobDupe
            // 
            this.MobDupe.Location = new System.Drawing.Point(7, 76);
            this.MobDupe.Name = "MobDupe";
            this.MobDupe.Size = new System.Drawing.Size(75, 23);
            this.MobDupe.TabIndex = 4;
            this.MobDupe.Text = "Copy";
            this.MobDupe.UseVisualStyleBackColor = true;
            this.MobDupe.Click += new System.EventHandler(this.MobDupe_Click);
            // 
            // MobDelete
            // 
            this.MobDelete.Location = new System.Drawing.Point(88, 47);
            this.MobDelete.Name = "MobDelete";
            this.MobDelete.Size = new System.Drawing.Size(75, 23);
            this.MobDelete.TabIndex = 3;
            this.MobDelete.Text = "Delete";
            this.MobDelete.UseVisualStyleBackColor = true;
            this.MobDelete.Click += new System.EventHandler(this.MobDelete_Click);
            // 
            // MobNew
            // 
            this.MobNew.Location = new System.Drawing.Point(7, 47);
            this.MobNew.Name = "MobNew";
            this.MobNew.Size = new System.Drawing.Size(75, 23);
            this.MobNew.TabIndex = 2;
            this.MobNew.Text = "New";
            this.MobNew.UseVisualStyleBackColor = true;
            this.MobNew.Click += new System.EventHandler(this.MobNew_Click);
            // 
            // MobSearch
            // 
            this.MobSearch.Location = new System.Drawing.Point(301, 20);
            this.MobSearch.Name = "MobSearch";
            this.MobSearch.Size = new System.Drawing.Size(75, 23);
            this.MobSearch.TabIndex = 1;
            this.MobSearch.Text = "Search";
            this.MobSearch.UseVisualStyleBackColor = true;
            // 
            // MobSearchTerm
            // 
            this.MobSearchTerm.Location = new System.Drawing.Point(7, 20);
            this.MobSearchTerm.Name = "MobSearchTerm";
            this.MobSearchTerm.Size = new System.Drawing.Size(281, 20);
            this.MobSearchTerm.TabIndex = 0;
            // 
            // MobAddN
            // 
            this.MobAddN.Location = new System.Drawing.Point(310, 38);
            this.MobAddN.Name = "MobAddN";
            this.MobAddN.Size = new System.Drawing.Size(75, 23);
            this.MobAddN.TabIndex = 2;
            this.MobAddN.Text = "Add #";
            this.MobAddN.UseVisualStyleBackColor = true;
            // 
            // MobAdd1
            // 
            this.MobAdd1.Location = new System.Drawing.Point(310, 9);
            this.MobAdd1.Name = "MobAdd1";
            this.MobAdd1.Size = new System.Drawing.Size(75, 23);
            this.MobAdd1.TabIndex = 1;
            this.MobAdd1.Text = "Add 1";
            this.MobAdd1.UseVisualStyleBackColor = true;
            // 
            // MobList
            // 
            this.MobList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MobName,
            this.MobInit,
            this.MobHP,
            this.MobAC,
            this.MobFort,
            this.MobRef,
            this.MobWill});
            this.MobList.FullRowSelect = true;
            this.MobList.GridLines = true;
            this.MobList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.MobList.Location = new System.Drawing.Point(4, 4);
            this.MobList.Name = "MobList";
            this.MobList.Size = new System.Drawing.Size(287, 280);
            this.MobList.TabIndex = 0;
            this.MobList.UseCompatibleStateImageBehavior = false;
            this.MobList.View = System.Windows.Forms.View.Details;
            // 
            // MobName
            // 
            this.MobName.Text = "Name";
            // 
            // MobInit
            // 
            this.MobInit.Text = "Init";
            // 
            // MobHP
            // 
            this.MobHP.DisplayIndex = 6;
            this.MobHP.Text = "HP";
            this.MobHP.Width = 35;
            // 
            // MobAC
            // 
            this.MobAC.DisplayIndex = 2;
            this.MobAC.Text = "AC";
            this.MobAC.Width = 34;
            // 
            // MobFort
            // 
            this.MobFort.DisplayIndex = 3;
            this.MobFort.Text = "F";
            this.MobFort.Width = 29;
            // 
            // MobRef
            // 
            this.MobRef.DisplayIndex = 4;
            this.MobRef.Text = "R";
            this.MobRef.Width = 28;
            // 
            // MobWill
            // 
            this.MobWill.DisplayIndex = 5;
            this.MobWill.Text = "W";
            this.MobWill.Width = 34;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(400, 455);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "4th Edtion Party Tracker";
            this.tabControl1.ResumeLayout(false);
            this.TrackerPage.ResumeLayout(false);
            this.EncountersPage.ResumeLayout(false);
            this.PartyPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.MonstersPage.ResumeLayout(false);
            this.MonstersPage.PerformLayout();
            this.MobDatabase.ResumeLayout(false);
            this.MobDatabase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TrackerPage;
        private System.Windows.Forms.TabPage PartyPage;
        private System.Windows.Forms.ListView TrackerList;
        private System.Windows.Forms.ColumnHeader Character;
        private System.Windows.Forms.ColumnHeader Player;
        private System.Windows.Forms.ColumnHeader Code;
        private System.Windows.Forms.ColumnHeader HP;
        private System.Windows.Forms.ColumnHeader AC;
        private System.Windows.Forms.ColumnHeader Ref;
        private System.Windows.Forms.ColumnHeader Fort;
        private System.Windows.Forms.ColumnHeader Will;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.ListView PartyList;
        private System.Windows.Forms.ColumnHeader PartyCharacter;
        private System.Windows.Forms.ColumnHeader PartyPlayer;
        private System.Windows.Forms.ColumnHeader PlayerInitMod;
        private System.Windows.Forms.ColumnHeader PlayerAC;
        private System.Windows.Forms.ColumnHeader PlayerFort;
        private System.Windows.Forms.ColumnHeader PlayerRef;
        private System.Windows.Forms.ColumnHeader PlayerWill;
        private System.Windows.Forms.ColumnHeader PlayerHP;
        private System.Windows.Forms.ColumnHeader PlayerActionPoints;
        private System.Windows.Forms.ColumnHeader PlayerSurges;
        private System.Windows.Forms.TabPage MonstersPage;
        private System.Windows.Forms.Button MobAddN;
        private System.Windows.Forms.Button MobAdd1;
        private System.Windows.Forms.ListView MobList;
        private System.Windows.Forms.ColumnHeader MobName;
        private System.Windows.Forms.ColumnHeader MobInit;
        private System.Windows.Forms.ColumnHeader MobHP;
        private System.Windows.Forms.ColumnHeader MobAC;
        private System.Windows.Forms.ColumnHeader MobFort;
        private System.Windows.Forms.ColumnHeader MobRef;
        private System.Windows.Forms.ColumnHeader MobWill;
        private System.Windows.Forms.Button PartyMilestone;
        private System.Windows.Forms.Button PartyRest;
        private System.Windows.Forms.GroupBox MobDatabase;
        private System.Windows.Forms.Button MobDupe;
        private System.Windows.Forms.Button MobDelete;
        private System.Windows.Forms.Button MobNew;
        private System.Windows.Forms.Button MobSearch;
        private System.Windows.Forms.TextBox MobSearchTerm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button PartyEdit;
        private System.Windows.Forms.Button PartyDelete;
        private System.Windows.Forms.Button PartyAdd;
        private System.Windows.Forms.Button PartyShortRest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PartyParties;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.ComboBox MobEncounters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage EncountersPage;
        private System.Windows.Forms.ListView EncountersList;
        private System.Windows.Forms.ColumnHeader EncounterMobName;
        private System.Windows.Forms.ColumnHeader EncounterCode;
        private System.Windows.Forms.Button MobEdit;
        private System.Windows.Forms.ColumnHeader EncounterCount;
        private System.Windows.Forms.Button MobNewEncounter;
    }
}

