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
            this.PartyPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PartyParties = new System.Windows.Forms.ComboBox();
            this.PartyDBSave = new System.Windows.Forms.Button();
            this.PartyDBDelete = new System.Windows.Forms.Button();
            this.PartyDBAdd = new System.Windows.Forms.Button();
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
            this.MobDatabase = new System.Windows.Forms.GroupBox();
            this.MobEdit = new System.Windows.Forms.Button();
            this.MobDupe = new System.Windows.Forms.Button();
            this.MobDelete = new System.Windows.Forms.Button();
            this.MobNew = new System.Windows.Forms.Button();
            this.MobSearch = new System.Windows.Forms.Button();
            this.MobSearchTerm = new System.Windows.Forms.TextBox();
            this.MobList = new System.Windows.Forms.ListView();
            this.MobName = new System.Windows.Forms.ColumnHeader();
            this.MobInit = new System.Windows.Forms.ColumnHeader();
            this.MobHP = new System.Windows.Forms.ColumnHeader();
            this.MobAC = new System.Windows.Forms.ColumnHeader();
            this.MobFort = new System.Windows.Forms.ColumnHeader();
            this.MobRef = new System.Windows.Forms.ColumnHeader();
            this.MobWill = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.EncounterItemName = new System.Windows.Forms.ColumnHeader();
            this.EncounterItemID = new System.Windows.Forms.ColumnHeader();
            this.MobAddToEnc = new System.Windows.Forms.Button();
            this.MobRemFromEnc = new System.Windows.Forms.Button();
            this.PlayerNotes = new System.Windows.Forms.ColumnHeader();
            this.TrackerNotes = new System.Windows.Forms.ColumnHeader();
            this.PartyEdit = new System.Windows.Forms.Button();
            this.PartyNew = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.TrackerPage.SuspendLayout();
            this.PartyPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.MonstersPage.SuspendLayout();
            this.MobDatabase.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.TrackerPage);
            this.tabControl1.Controls.Add(this.PartyPage);
            this.tabControl1.Controls.Add(this.MonstersPage);
            this.tabControl1.Location = new System.Drawing.Point(-1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(626, 510);
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
            this.TrackerPage.Size = new System.Drawing.Size(618, 484);
            this.TrackerPage.TabIndex = 0;
            this.TrackerPage.Text = "Tracker";
            this.TrackerPage.UseVisualStyleBackColor = true;
            this.TrackerPage.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // Start
            // 
            this.Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Start.Location = new System.Drawing.Point(535, 455);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 2;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            // 
            // Next
            // 
            this.Next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Next.Location = new System.Drawing.Point(10, 455);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(75, 23);
            this.Next.TabIndex = 1;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            // 
            // TrackerList
            // 
            this.TrackerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TrackerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Character,
            this.Player,
            this.Code,
            this.HP,
            this.AC,
            this.Fort,
            this.Ref,
            this.Will,
            this.Status,
            this.TrackerNotes});
            this.TrackerList.FullRowSelect = true;
            this.TrackerList.GridLines = true;
            this.TrackerList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.TrackerList.Location = new System.Drawing.Point(10, 7);
            this.TrackerList.Name = "TrackerList";
            this.TrackerList.Size = new System.Drawing.Size(600, 442);
            this.TrackerList.TabIndex = 0;
            this.TrackerList.UseCompatibleStateImageBehavior = false;
            this.TrackerList.View = System.Windows.Forms.View.Details;
            // 
            // Character
            // 
            this.Character.Text = "Character";
            this.Character.Width = 143;
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
            // PartyPage
            // 
            this.PartyPage.Controls.Add(this.PartyNew);
            this.PartyPage.Controls.Add(this.PartyEdit);
            this.PartyPage.Controls.Add(this.groupBox1);
            this.PartyPage.Controls.Add(this.PartyShortRest);
            this.PartyPage.Controls.Add(this.PartyMilestone);
            this.PartyPage.Controls.Add(this.PartyRest);
            this.PartyPage.Controls.Add(this.PartyList);
            this.PartyPage.Location = new System.Drawing.Point(4, 22);
            this.PartyPage.Name = "PartyPage";
            this.PartyPage.Padding = new System.Windows.Forms.Padding(3);
            this.PartyPage.Size = new System.Drawing.Size(618, 484);
            this.PartyPage.TabIndex = 1;
            this.PartyPage.Text = "Party";
            this.PartyPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.PartyParties);
            this.groupBox1.Controls.Add(this.PartyDBSave);
            this.groupBox1.Controls.Add(this.PartyDBDelete);
            this.groupBox1.Controls.Add(this.PartyDBAdd);
            this.groupBox1.Location = new System.Drawing.Point(3, 424);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 54);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Parties";
            // 
            // PartyParties
            // 
            this.PartyParties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PartyParties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PartyParties.FormattingEnabled = true;
            this.PartyParties.Location = new System.Drawing.Point(312, 19);
            this.PartyParties.Name = "PartyParties";
            this.PartyParties.Size = new System.Drawing.Size(293, 21);
            this.PartyParties.TabIndex = 3;
            // 
            // PartyDBSave
            // 
            this.PartyDBSave.Location = new System.Drawing.Point(168, 19);
            this.PartyDBSave.Name = "PartyDBSave";
            this.PartyDBSave.Size = new System.Drawing.Size(75, 23);
            this.PartyDBSave.TabIndex = 2;
            this.PartyDBSave.Text = "Save";
            this.PartyDBSave.UseVisualStyleBackColor = true;
            this.PartyDBSave.Click += new System.EventHandler(this.PartyEdit_Click);
            // 
            // PartyDBDelete
            // 
            this.PartyDBDelete.Location = new System.Drawing.Point(87, 19);
            this.PartyDBDelete.Name = "PartyDBDelete";
            this.PartyDBDelete.Size = new System.Drawing.Size(75, 23);
            this.PartyDBDelete.TabIndex = 1;
            this.PartyDBDelete.Text = "Delete";
            this.PartyDBDelete.UseVisualStyleBackColor = true;
            this.PartyDBDelete.Click += new System.EventHandler(this.PartyDelete_Click);
            // 
            // PartyDBAdd
            // 
            this.PartyDBAdd.Location = new System.Drawing.Point(6, 19);
            this.PartyDBAdd.Name = "PartyDBAdd";
            this.PartyDBAdd.Size = new System.Drawing.Size(75, 23);
            this.PartyDBAdd.TabIndex = 0;
            this.PartyDBAdd.Text = "Add";
            this.PartyDBAdd.UseVisualStyleBackColor = true;
            // 
            // PartyShortRest
            // 
            this.PartyShortRest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PartyShortRest.Location = new System.Drawing.Point(163, 395);
            this.PartyShortRest.Name = "PartyShortRest";
            this.PartyShortRest.Size = new System.Drawing.Size(75, 23);
            this.PartyShortRest.TabIndex = 3;
            this.PartyShortRest.Text = "Short Rest";
            this.PartyShortRest.UseVisualStyleBackColor = true;
            // 
            // PartyMilestone
            // 
            this.PartyMilestone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PartyMilestone.Location = new System.Drawing.Point(82, 395);
            this.PartyMilestone.Name = "PartyMilestone";
            this.PartyMilestone.Size = new System.Drawing.Size(75, 23);
            this.PartyMilestone.TabIndex = 2;
            this.PartyMilestone.Text = "Milestone";
            this.PartyMilestone.UseVisualStyleBackColor = true;
            // 
            // PartyRest
            // 
            this.PartyRest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PartyRest.Location = new System.Drawing.Point(1, 395);
            this.PartyRest.Name = "PartyRest";
            this.PartyRest.Size = new System.Drawing.Size(75, 23);
            this.PartyRest.TabIndex = 1;
            this.PartyRest.Text = "Rest";
            this.PartyRest.UseVisualStyleBackColor = true;
            // 
            // PartyList
            // 
            this.PartyList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.PlayerSurges,
            this.PlayerNotes});
            this.PartyList.FullRowSelect = true;
            this.PartyList.GridLines = true;
            this.PartyList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.PartyList.Location = new System.Drawing.Point(4, 4);
            this.PartyList.Name = "PartyList";
            this.PartyList.Size = new System.Drawing.Size(608, 385);
            this.PartyList.TabIndex = 0;
            this.PartyList.UseCompatibleStateImageBehavior = false;
            this.PartyList.View = System.Windows.Forms.View.Details;
            // 
            // PartyCharacter
            // 
            this.PartyCharacter.Text = "Character";
            this.PartyCharacter.Width = 128;
            // 
            // PartyPlayer
            // 
            this.PartyPlayer.Text = "Player";
            this.PartyPlayer.Width = 85;
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
            this.MonstersPage.Controls.Add(this.groupBox2);
            this.MonstersPage.Controls.Add(this.MobDatabase);
            this.MonstersPage.Location = new System.Drawing.Point(4, 22);
            this.MonstersPage.Name = "MonstersPage";
            this.MonstersPage.Size = new System.Drawing.Size(618, 484);
            this.MonstersPage.TabIndex = 2;
            this.MonstersPage.Text = "Monsters";
            this.MonstersPage.UseVisualStyleBackColor = true;
            this.MonstersPage.Click += new System.EventHandler(this.MonstersPage_Click);
            // 
            // MobNewEncounter
            // 
            this.MobNewEncounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MobNewEncounter.Location = new System.Drawing.Point(199, 14);
            this.MobNewEncounter.Name = "MobNewEncounter";
            this.MobNewEncounter.Size = new System.Drawing.Size(56, 23);
            this.MobNewEncounter.TabIndex = 6;
            this.MobNewEncounter.Text = "New";
            this.MobNewEncounter.UseVisualStyleBackColor = true;
            this.MobNewEncounter.Click += new System.EventHandler(this.MobNewEncounter_Click);
            // 
            // MobEncounters
            // 
            this.MobEncounters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MobEncounters.FormattingEnabled = true;
            this.MobEncounters.Location = new System.Drawing.Point(27, 16);
            this.MobEncounters.Name = "MobEncounters";
            this.MobEncounters.Size = new System.Drawing.Size(166, 21);
            this.MobEncounters.TabIndex = 5;
            this.MobEncounters.SelectedIndexChanged += new System.EventHandler(this.MobEncounters_SelectedIndexChanged);
            this.MobEncounters.Leave += new System.EventHandler(this.MobEncounters_Leave);
            this.MobEncounters.TextChanged += new System.EventHandler(this.MobEncounters_TextChanged);
            // 
            // MobDatabase
            // 
            this.MobDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MobDatabase.Controls.Add(this.MobEdit);
            this.MobDatabase.Controls.Add(this.MobDupe);
            this.MobDatabase.Controls.Add(this.MobDelete);
            this.MobDatabase.Controls.Add(this.MobNew);
            this.MobDatabase.Controls.Add(this.MobSearch);
            this.MobDatabase.Controls.Add(this.MobSearchTerm);
            this.MobDatabase.Controls.Add(this.MobList);
            this.MobDatabase.Location = new System.Drawing.Point(0, 4);
            this.MobDatabase.Name = "MobDatabase";
            this.MobDatabase.Size = new System.Drawing.Size(288, 477);
            this.MobDatabase.TabIndex = 3;
            this.MobDatabase.TabStop = false;
            this.MobDatabase.Text = "Database";
            this.MobDatabase.Enter += new System.EventHandler(this.MobDatabase_Enter);
            // 
            // MobEdit
            // 
            this.MobEdit.Location = new System.Drawing.Point(138, 47);
            this.MobEdit.Name = "MobEdit";
            this.MobEdit.Size = new System.Drawing.Size(59, 23);
            this.MobEdit.TabIndex = 5;
            this.MobEdit.Text = "Edit";
            this.MobEdit.UseVisualStyleBackColor = true;
            this.MobEdit.Click += new System.EventHandler(this.MobEdit_Click);
            // 
            // MobDupe
            // 
            this.MobDupe.Location = new System.Drawing.Point(203, 47);
            this.MobDupe.Name = "MobDupe";
            this.MobDupe.Size = new System.Drawing.Size(60, 23);
            this.MobDupe.TabIndex = 4;
            this.MobDupe.Text = "Copy";
            this.MobDupe.UseVisualStyleBackColor = true;
            this.MobDupe.Click += new System.EventHandler(this.MobDupe_Click);
            // 
            // MobDelete
            // 
            this.MobDelete.Location = new System.Drawing.Point(74, 47);
            this.MobDelete.Name = "MobDelete";
            this.MobDelete.Size = new System.Drawing.Size(58, 23);
            this.MobDelete.TabIndex = 3;
            this.MobDelete.Text = "Delete";
            this.MobDelete.UseVisualStyleBackColor = true;
            this.MobDelete.Click += new System.EventHandler(this.MobDelete_Click);
            // 
            // MobNew
            // 
            this.MobNew.Location = new System.Drawing.Point(7, 47);
            this.MobNew.Name = "MobNew";
            this.MobNew.Size = new System.Drawing.Size(61, 23);
            this.MobNew.TabIndex = 2;
            this.MobNew.Text = "New";
            this.MobNew.UseVisualStyleBackColor = true;
            this.MobNew.Click += new System.EventHandler(this.MobNew_Click);
            // 
            // MobSearch
            // 
            this.MobSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MobSearch.Location = new System.Drawing.Point(211, 18);
            this.MobSearch.Name = "MobSearch";
            this.MobSearch.Size = new System.Drawing.Size(64, 23);
            this.MobSearch.TabIndex = 1;
            this.MobSearch.Text = "Search";
            this.MobSearch.UseVisualStyleBackColor = true;
            // 
            // MobSearchTerm
            // 
            this.MobSearchTerm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MobSearchTerm.Location = new System.Drawing.Point(7, 20);
            this.MobSearchTerm.Name = "MobSearchTerm";
            this.MobSearchTerm.Size = new System.Drawing.Size(198, 20);
            this.MobSearchTerm.TabIndex = 0;
            // 
            // MobList
            // 
            this.MobList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.MobList.Location = new System.Drawing.Point(7, 77);
            this.MobList.Name = "MobList";
            this.MobList.Size = new System.Drawing.Size(276, 395);
            this.MobList.TabIndex = 0;
            this.MobList.UseCompatibleStateImageBehavior = false;
            this.MobList.View = System.Windows.Forms.View.Details;
            // 
            // MobName
            // 
            this.MobName.Text = "Name";
            this.MobName.Width = 123;
            // 
            // MobInit
            // 
            this.MobInit.Text = "Init";
            this.MobInit.Width = 28;
            // 
            // MobHP
            // 
            this.MobHP.DisplayIndex = 6;
            this.MobHP.Text = "HP";
            this.MobHP.Width = 28;
            // 
            // MobAC
            // 
            this.MobAC.DisplayIndex = 2;
            this.MobAC.Text = "AC";
            this.MobAC.Width = 26;
            // 
            // MobFort
            // 
            this.MobFort.DisplayIndex = 3;
            this.MobFort.Text = "F";
            this.MobFort.Width = 18;
            // 
            // MobRef
            // 
            this.MobRef.DisplayIndex = 4;
            this.MobRef.Text = "R";
            this.MobRef.Width = 20;
            // 
            // MobWill
            // 
            this.MobWill.DisplayIndex = 5;
            this.MobWill.Text = "W";
            this.MobWill.Width = 23;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.MobAddToEnc);
            this.groupBox2.Controls.Add(this.MobRemFromEnc);
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.MobNewEncounter);
            this.groupBox2.Controls.Add(this.MobEncounters);
            this.groupBox2.Location = new System.Drawing.Point(294, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 478);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Encounters";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(261, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EncounterItemName,
            this.EncounterItemID});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(34, 45);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(262, 428);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // EncounterItemName
            // 
            this.EncounterItemName.Text = "Name";
            this.EncounterItemName.Width = 197;
            // 
            // EncounterItemID
            // 
            this.EncounterItemID.Text = "Count";
            // 
            // MobAddToEnc
            // 
            this.MobAddToEnc.Font = new System.Drawing.Font("Wingdings", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.MobAddToEnc.Location = new System.Drawing.Point(4, 131);
            this.MobAddToEnc.Name = "MobAddToEnc";
            this.MobAddToEnc.Size = new System.Drawing.Size(28, 28);
            this.MobAddToEnc.TabIndex = 9;
            this.MobAddToEnc.Text = "è";
            this.MobAddToEnc.UseVisualStyleBackColor = true;
            // 
            // MobRemFromEnc
            // 
            this.MobRemFromEnc.Font = new System.Drawing.Font("Wingdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.MobRemFromEnc.Location = new System.Drawing.Point(4, 165);
            this.MobRemFromEnc.Name = "MobRemFromEnc";
            this.MobRemFromEnc.Size = new System.Drawing.Size(28, 30);
            this.MobRemFromEnc.TabIndex = 10;
            this.MobRemFromEnc.Text = "x";
            this.MobRemFromEnc.UseVisualStyleBackColor = true;
            // 
            // PlayerNotes
            // 
            this.PlayerNotes.Text = "Notes";
            this.PlayerNotes.Width = 136;
            // 
            // TrackerNotes
            // 
            this.TrackerNotes.Text = "Notes";
            this.TrackerNotes.Width = 149;
            // 
            // PartyEdit
            // 
            this.PartyEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PartyEdit.Location = new System.Drawing.Point(543, 395);
            this.PartyEdit.Name = "PartyEdit";
            this.PartyEdit.Size = new System.Drawing.Size(75, 23);
            this.PartyEdit.TabIndex = 5;
            this.PartyEdit.Text = "Edit";
            this.PartyEdit.UseVisualStyleBackColor = true;
            this.PartyEdit.Click += new System.EventHandler(this.PartyEdit_Click_1);
            // 
            // PartyNew
            // 
            this.PartyNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PartyNew.Location = new System.Drawing.Point(462, 395);
            this.PartyNew.Name = "PartyNew";
            this.PartyNew.Size = new System.Drawing.Size(75, 23);
            this.PartyNew.TabIndex = 6;
            this.PartyNew.Text = "New";
            this.PartyNew.UseVisualStyleBackColor = true;
            this.PartyNew.Click += new System.EventHandler(this.PartyNew_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(623, 510);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "4th Edtion Party Tracker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.TrackerPage.ResumeLayout(false);
            this.PartyPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.MonstersPage.ResumeLayout(false);
            this.MobDatabase.ResumeLayout(false);
            this.MobDatabase.PerformLayout();
            this.groupBox2.ResumeLayout(false);
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
        private System.Windows.Forms.Button PartyDBSave;
        private System.Windows.Forms.Button PartyDBDelete;
        private System.Windows.Forms.Button PartyDBAdd;
        private System.Windows.Forms.Button PartyShortRest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PartyParties;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.ComboBox MobEncounters;
        private System.Windows.Forms.Button MobEdit;
        private System.Windows.Forms.Button MobNewEncounter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader EncounterItemName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button MobRemFromEnc;
        private System.Windows.Forms.Button MobAddToEnc;
        private System.Windows.Forms.ColumnHeader EncounterItemID;
        private System.Windows.Forms.ColumnHeader TrackerNotes;
        private System.Windows.Forms.ColumnHeader PlayerNotes;
        private System.Windows.Forms.Button PartyEdit;
        private System.Windows.Forms.Button PartyNew;
    }
}

