namespace CompetitionsManager
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.competitionsPanel = new System.Windows.Forms.Panel();
            this.compDatePicker = new System.Windows.Forms.DateTimePicker();
            this.compNameLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.showResBtn = new System.Windows.Forms.Button();
            this.compDistsListBox = new System.Windows.Forms.ListBox();
            this.compTeamsListBox = new System.Windows.Forms.ListBox();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.створитиToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.createDistConditionsMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.createStartProtMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.createDistResMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.compMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runCompMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.createCompMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.delCompMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.teamMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createTeamMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.distMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDistMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.addDistMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.editDistMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.delDistMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.backMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distResPanel = new System.Windows.Forms.Panel();
            this.participsListBox = new System.Windows.Forms.ListBox();
            this.reverseSortChecker = new System.Windows.Forms.CheckBox();
            this.distResPanelSortTeamBtn = new System.Windows.Forms.Button();
            this.addTeamToDistanceBtn = new System.Windows.Forms.Button();
            this.viewTeamResBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.distResPanelMainLabel = new System.Windows.Forms.Label();
            this.resTBox = new System.Windows.Forms.TextBox();
            this.teamPanel = new System.Windows.Forms.Panel();
            this.teamTabControl = new System.Windows.Forms.TabControl();
            this.teamSquadePage = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.teamPanelCancelBtn = new System.Windows.Forms.Button();
            this.teamPanelOkBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.teamCouchTbox = new System.Windows.Forms.TextBox();
            this.teamNameTBox = new System.Windows.Forms.TextBox();
            this.teammatesLBox = new System.Windows.Forms.ListBox();
            this.categoriesPage = new System.Windows.Forms.TabPage();
            this.teamPanelAddCatBtn = new System.Windows.Forms.Button();
            this.addTeammateBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.turistosLBox = new System.Windows.Forms.ListBox();
            this.catTreeView = new System.Windows.Forms.TreeView();
            this.categoryMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addSubcatMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.renameCatMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.delCatMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.addSpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squadeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.remTeammateMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.editTeammateMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.sportsmanMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editSportsmanMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.transferToOtherCatMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.delSportsmanMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.compTeamMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editTeamMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.delTeamMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.teamPropMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.compDistsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeDistFromCompMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.distPropMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.distancePanel = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.distTabPage = new System.Windows.Forms.TabPage();
            this.distPanelCancelBtn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.penPriceTBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.distHeightTBox = new System.Windows.Forms.TextBox();
            this.distLenTBox = new System.Windows.Forms.TextBox();
            this.tmCountNum = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.distNameTBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.distTypeLstBox = new System.Windows.Forms.ListBox();
            this.distPanelCreateDistanceBtn = new System.Windows.Forms.Button();
            this.distPanelAddStageBtn = new System.Windows.Forms.Button();
            this.distStagesLstBox = new System.Windows.Forms.ListBox();
            this.stagePage = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.distPanelCreateUniqueStBtn = new System.Windows.Forms.Button();
            this.lenLabel = new System.Windows.Forms.Label();
            this.distPanelDelUserStBtn = new System.Windows.Forms.Button();
            this.stageLenTBox = new System.Windows.Forms.TextBox();
            this.distPanelChoseStageBtn = new System.Windows.Forms.Button();
            this.stageTemplLBox = new System.Windows.Forms.ListBox();
            this.distMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.remStageMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.participMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.participPropMBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.competitionsPanel.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.distResPanel.SuspendLayout();
            this.teamPanel.SuspendLayout();
            this.teamTabControl.SuspendLayout();
            this.teamSquadePage.SuspendLayout();
            this.categoriesPage.SuspendLayout();
            this.categoryMenu.SuspendLayout();
            this.squadeMenu.SuspendLayout();
            this.sportsmanMenu.SuspendLayout();
            this.compTeamMenu.SuspendLayout();
            this.compDistsMenu.SuspendLayout();
            this.distancePanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.distTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmCountNum)).BeginInit();
            this.stagePage.SuspendLayout();
            this.distMenu.SuspendLayout();
            this.participMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // competitionsPanel
            // 
            this.competitionsPanel.Controls.Add(this.compDatePicker);
            this.competitionsPanel.Controls.Add(this.compNameLabel);
            this.competitionsPanel.Controls.Add(this.panel1);
            this.competitionsPanel.Controls.Add(this.label16);
            this.competitionsPanel.Controls.Add(this.label15);
            this.competitionsPanel.Controls.Add(this.showResBtn);
            this.competitionsPanel.Controls.Add(this.compDistsListBox);
            this.competitionsPanel.Controls.Add(this.compTeamsListBox);
            this.competitionsPanel.Location = new System.Drawing.Point(0, 27);
            this.competitionsPanel.Name = "competitionsPanel";
            this.competitionsPanel.Size = new System.Drawing.Size(680, 375);
            this.competitionsPanel.TabIndex = 10;
            // 
            // compDatePicker
            // 
            this.compDatePicker.CalendarFont = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.compDatePicker.Location = new System.Drawing.Point(374, 309);
            this.compDatePicker.Name = "compDatePicker";
            this.compDatePicker.Size = new System.Drawing.Size(213, 20);
            this.compDatePicker.TabIndex = 9;
            this.compDatePicker.Value = new System.DateTime(2017, 3, 9, 0, 0, 0, 0);
            // 
            // compNameLabel
            // 
            this.compNameLabel.AutoSize = true;
            this.compNameLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.compNameLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.compNameLabel.Location = new System.Drawing.Point(370, 257);
            this.compNameLabel.Name = "compNameLabel";
            this.compNameLabel.Size = new System.Drawing.Size(87, 24);
            this.compNameLabel.TabIndex = 8;
            this.compNameLabel.Text = "label17";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(264, 234);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 97);
            this.panel1.TabIndex = 7;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("MS Reference Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.ForeColor = System.Drawing.Color.ForestGreen;
            this.label16.Location = new System.Drawing.Point(260, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(239, 22);
            this.label16.TabIndex = 6;
            this.label16.Text = "Дистанції на змаганнях";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("MS Reference Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.ForeColor = System.Drawing.Color.ForestGreen;
            this.label15.Location = new System.Drawing.Point(12, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 22);
            this.label15.TabIndex = 5;
            this.label15.Text = "Команди";
            // 
            // showResBtn
            // 
            this.showResBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(211)))), ((int)(((byte)(33)))));
            this.showResBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.showResBtn.FlatAppearance.BorderSize = 0;
            this.showResBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showResBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showResBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.showResBtn.Image = ((System.Drawing.Image)(resources.GetObject("showResBtn.Image")));
            this.showResBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showResBtn.Location = new System.Drawing.Point(326, 132);
            this.showResBtn.Name = "showResBtn";
            this.showResBtn.Size = new System.Drawing.Size(261, 35);
            this.showResBtn.TabIndex = 4;
            this.showResBtn.Text = "    Результати на дистанції";
            this.showResBtn.UseVisualStyleBackColor = false;
            this.showResBtn.Click += new System.EventHandler(this.showResBtn_Click);
            // 
            // compDistsListBox
            // 
            this.compDistsListBox.BackColor = System.Drawing.Color.ForestGreen;
            this.compDistsListBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.compDistsListBox.ForeColor = System.Drawing.Color.White;
            this.compDistsListBox.FormattingEnabled = true;
            this.compDistsListBox.ItemHeight = 16;
            this.compDistsListBox.Location = new System.Drawing.Point(264, 41);
            this.compDistsListBox.Name = "compDistsListBox";
            this.compDistsListBox.Size = new System.Drawing.Size(390, 84);
            this.compDistsListBox.TabIndex = 1;
            this.compDistsListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.compDistsListBox_MouseDown);
            // 
            // compTeamsListBox
            // 
            this.compTeamsListBox.BackColor = System.Drawing.Color.ForestGreen;
            this.compTeamsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.compTeamsListBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.compTeamsListBox.ForeColor = System.Drawing.Color.White;
            this.compTeamsListBox.FormattingEnabled = true;
            this.compTeamsListBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.compTeamsListBox.ItemHeight = 16;
            this.compTeamsListBox.Location = new System.Drawing.Point(12, 41);
            this.compTeamsListBox.Name = "compTeamsListBox";
            this.compTeamsListBox.Size = new System.Drawing.Size(241, 290);
            this.compTeamsListBox.Sorted = true;
            this.compTeamsListBox.TabIndex = 0;
            this.compTeamsListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.compTeamsListBox_MouseDown);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.compMenuItem,
            this.teamMenuItem,
            this.distMenuItem,
            this.backMBtn,
            this.exitMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(680, 24);
            this.mainMenu.TabIndex = 11;
            this.mainMenu.Text = "mainMenu";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.створитиToolStripMenuItem2});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileMenuItem.Text = "Файл";
            // 
            // створитиToolStripMenuItem2
            // 
            this.створитиToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDistConditionsMBtn,
            this.createStartProtMBtn,
            this.createDistResMBtn});
            this.створитиToolStripMenuItem2.Name = "створитиToolStripMenuItem2";
            this.створитиToolStripMenuItem2.Size = new System.Drawing.Size(126, 22);
            this.створитиToolStripMenuItem2.Text = "Створити";
            // 
            // createDistConditionsMBtn
            // 
            this.createDistConditionsMBtn.Name = "createDistConditionsMBtn";
            this.createDistConditionsMBtn.Size = new System.Drawing.Size(241, 22);
            this.createDistConditionsMBtn.Text = "Умови дистанції";
            this.createDistConditionsMBtn.Click += new System.EventHandler(this.createUmovuMBtn_Click);
            // 
            // createStartProtMBtn
            // 
            this.createStartProtMBtn.Name = "createStartProtMBtn";
            this.createStartProtMBtn.Size = new System.Drawing.Size(241, 22);
            this.createStartProtMBtn.Text = "Стартовий протокол дистанції";
            this.createStartProtMBtn.Click += new System.EventHandler(this.createStartProtMBtn_Click);
            // 
            // createDistResMBtn
            // 
            this.createDistResMBtn.Name = "createDistResMBtn";
            this.createDistResMBtn.Size = new System.Drawing.Size(241, 22);
            this.createDistResMBtn.Text = "Протокол із результатами";
            this.createDistResMBtn.Click += new System.EventHandler(this.createDistResMBtn_Click);
            // 
            // compMenuItem
            // 
            this.compMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runCompMenuBtn,
            this.createCompMenuBtn,
            this.toolStripSeparator1,
            this.delCompMenuBtn});
            this.compMenuItem.Name = "compMenuItem";
            this.compMenuItem.Size = new System.Drawing.Size(72, 20);
            this.compMenuItem.Text = "Змагання";
            // 
            // runCompMenuBtn
            // 
            this.runCompMenuBtn.Name = "runCompMenuBtn";
            this.runCompMenuBtn.Size = new System.Drawing.Size(126, 22);
            this.runCompMenuBtn.Text = "Відкрити";
            this.runCompMenuBtn.Click += new System.EventHandler(this.runCompMenuBtn_Click);
            // 
            // createCompMenuBtn
            // 
            this.createCompMenuBtn.Name = "createCompMenuBtn";
            this.createCompMenuBtn.Size = new System.Drawing.Size(126, 22);
            this.createCompMenuBtn.Text = "Створити";
            this.createCompMenuBtn.Click += new System.EventHandler(this.createCompMBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(123, 6);
            // 
            // delCompMenuBtn
            // 
            this.delCompMenuBtn.Name = "delCompMenuBtn";
            this.delCompMenuBtn.Size = new System.Drawing.Size(126, 22);
            this.delCompMenuBtn.Text = "Видалити";
            this.delCompMenuBtn.Click += new System.EventHandler(this.delCompMenuBtn_Click);
            // 
            // teamMenuItem
            // 
            this.teamMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createTeamMenuBtn});
            this.teamMenuItem.Name = "teamMenuItem";
            this.teamMenuItem.Size = new System.Drawing.Size(67, 20);
            this.teamMenuItem.Text = "Команда";
            // 
            // createTeamMenuBtn
            // 
            this.createTeamMenuBtn.Name = "createTeamMenuBtn";
            this.createTeamMenuBtn.Size = new System.Drawing.Size(126, 22);
            this.createTeamMenuBtn.Text = "Створити";
            this.createTeamMenuBtn.Click += new System.EventHandler(this.createTeamMenuBtn_Click);
            // 
            // distMenuItem
            // 
            this.distMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDistMBtn,
            this.addDistMBtn,
            this.editDistMBtn,
            this.delDistMBtn});
            this.distMenuItem.Name = "distMenuItem";
            this.distMenuItem.Size = new System.Drawing.Size(74, 20);
            this.distMenuItem.Text = "Дистанція";
            // 
            // createDistMBtn
            // 
            this.createDistMBtn.Name = "createDistMBtn";
            this.createDistMBtn.Size = new System.Drawing.Size(183, 22);
            this.createDistMBtn.Text = "Створити";
            this.createDistMBtn.Click += new System.EventHandler(this.createDistMenuItem_Click);
            // 
            // addDistMBtn
            // 
            this.addDistMBtn.Name = "addDistMBtn";
            this.addDistMBtn.Size = new System.Drawing.Size(183, 22);
            this.addDistMBtn.Text = "Додати на змагання";
            this.addDistMBtn.Click += new System.EventHandler(this.addDistMBtn_Click);
            // 
            // editDistMBtn
            // 
            this.editDistMBtn.Name = "editDistMBtn";
            this.editDistMBtn.Size = new System.Drawing.Size(183, 22);
            this.editDistMBtn.Text = "Редагувати";
            this.editDistMBtn.Click += new System.EventHandler(this.editDistMBtn_Click);
            // 
            // delDistMBtn
            // 
            this.delDistMBtn.Name = "delDistMBtn";
            this.delDistMBtn.Size = new System.Drawing.Size(183, 22);
            this.delDistMBtn.Text = "Видалити";
            this.delDistMBtn.Click += new System.EventHandler(this.delDistMBtn_Click);
            // 
            // backMBtn
            // 
            this.backMBtn.Name = "backMBtn";
            this.backMBtn.Size = new System.Drawing.Size(51, 20);
            this.backMBtn.Text = "Назад";
            this.backMBtn.Click += new System.EventHandler(this.backMBtn_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(52, 20);
            this.exitMenuItem.Text = "Вийти";
            this.exitMenuItem.Click += new System.EventHandler(this.вийтиToolStripMenuItem_Click);
            // 
            // distResPanel
            // 
            this.distResPanel.Controls.Add(this.participsListBox);
            this.distResPanel.Controls.Add(this.reverseSortChecker);
            this.distResPanel.Controls.Add(this.distResPanelSortTeamBtn);
            this.distResPanel.Controls.Add(this.addTeamToDistanceBtn);
            this.distResPanel.Controls.Add(this.viewTeamResBtn);
            this.distResPanel.Controls.Add(this.label4);
            this.distResPanel.Controls.Add(this.distResPanelMainLabel);
            this.distResPanel.Controls.Add(this.resTBox);
            this.distResPanel.Location = new System.Drawing.Point(0, 25);
            this.distResPanel.Name = "distResPanel";
            this.distResPanel.Size = new System.Drawing.Size(680, 353);
            this.distResPanel.TabIndex = 12;
            // 
            // participsListBox
            // 
            this.participsListBox.BackColor = System.Drawing.Color.ForestGreen;
            this.participsListBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.participsListBox.ForeColor = System.Drawing.Color.White;
            this.participsListBox.FormattingEnabled = true;
            this.participsListBox.ItemHeight = 16;
            this.participsListBox.Location = new System.Drawing.Point(16, 33);
            this.participsListBox.Name = "participsListBox";
            this.participsListBox.Size = new System.Drawing.Size(336, 276);
            this.participsListBox.TabIndex = 31;
            this.participsListBox.SelectedIndexChanged += new System.EventHandler(this.participsListBox_SelectedIndexChanged);
            this.participsListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.participsListBox_MouseDown);
            // 
            // reverseSortChecker
            // 
            this.reverseSortChecker.AutoSize = true;
            this.reverseSortChecker.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reverseSortChecker.ForeColor = System.Drawing.Color.ForestGreen;
            this.reverseSortChecker.Location = new System.Drawing.Point(392, 253);
            this.reverseSortChecker.Name = "reverseSortChecker";
            this.reverseSortChecker.Size = new System.Drawing.Size(215, 20);
            this.reverseSortChecker.TabIndex = 30;
            this.reverseSortChecker.Text = "Більший час - вище місце";
            this.reverseSortChecker.UseVisualStyleBackColor = true;
            // 
            // distResPanelSortTeamBtn
            // 
            this.distResPanelSortTeamBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(211)))), ((int)(((byte)(33)))));
            this.distResPanelSortTeamBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.distResPanelSortTeamBtn.FlatAppearance.BorderSize = 0;
            this.distResPanelSortTeamBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.distResPanelSortTeamBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.distResPanelSortTeamBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.distResPanelSortTeamBtn.Location = new System.Drawing.Point(382, 279);
            this.distResPanelSortTeamBtn.Name = "distResPanelSortTeamBtn";
            this.distResPanelSortTeamBtn.Size = new System.Drawing.Size(252, 29);
            this.distResPanelSortTeamBtn.TabIndex = 29;
            this.distResPanelSortTeamBtn.Text = "Сортувати за результатом";
            this.distResPanelSortTeamBtn.UseVisualStyleBackColor = false;
            this.distResPanelSortTeamBtn.Click += new System.EventHandler(this.distResPanelSortTeamBtn_Click);
            // 
            // addTeamToDistanceBtn
            // 
            this.addTeamToDistanceBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(211)))), ((int)(((byte)(33)))));
            this.addTeamToDistanceBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.addTeamToDistanceBtn.FlatAppearance.BorderSize = 0;
            this.addTeamToDistanceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTeamToDistanceBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addTeamToDistanceBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.addTeamToDistanceBtn.Image = ((System.Drawing.Image)(resources.GetObject("addTeamToDistanceBtn.Image")));
            this.addTeamToDistanceBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addTeamToDistanceBtn.Location = new System.Drawing.Point(22, 315);
            this.addTeamToDistanceBtn.Name = "addTeamToDistanceBtn";
            this.addTeamToDistanceBtn.Size = new System.Drawing.Size(321, 29);
            this.addTeamToDistanceBtn.TabIndex = 28;
            this.addTeamToDistanceBtn.Text = "     Заявити команду на дистанцію";
            this.addTeamToDistanceBtn.UseVisualStyleBackColor = false;
            this.addTeamToDistanceBtn.Click += new System.EventHandler(this.addTeamToDistanceBtn_Click);
            // 
            // viewTeamResBtn
            // 
            this.viewTeamResBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(211)))), ((int)(((byte)(33)))));
            this.viewTeamResBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.viewTeamResBtn.FlatAppearance.BorderSize = 0;
            this.viewTeamResBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewTeamResBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.viewTeamResBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.viewTeamResBtn.Image = ((System.Drawing.Image)(resources.GetObject("viewTeamResBtn.Image")));
            this.viewTeamResBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.viewTeamResBtn.Location = new System.Drawing.Point(392, 135);
            this.viewTeamResBtn.Name = "viewTeamResBtn";
            this.viewTeamResBtn.Size = new System.Drawing.Size(253, 29);
            this.viewTeamResBtn.TabIndex = 27;
            this.viewTeamResBtn.Text = "     До результатів команди";
            this.viewTeamResBtn.UseVisualStyleBackColor = false;
            this.viewTeamResBtn.Click += new System.EventHandler(this.viewTeamResBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.ForestGreen;
            this.label4.Location = new System.Drawing.Point(419, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Загальний результат";
            // 
            // distResPanelMainLabel
            // 
            this.distResPanelMainLabel.AutoSize = true;
            this.distResPanelMainLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.distResPanelMainLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.distResPanelMainLabel.Location = new System.Drawing.Point(12, 9);
            this.distResPanelMainLabel.Name = "distResPanelMainLabel";
            this.distResPanelMainLabel.Size = new System.Drawing.Size(88, 20);
            this.distResPanelMainLabel.TabIndex = 25;
            this.distResPanelMainLabel.Text = "Команди";
            // 
            // resTBox
            // 
            this.resTBox.BackColor = System.Drawing.Color.White;
            this.resTBox.Enabled = false;
            this.resTBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resTBox.ForeColor = System.Drawing.Color.Black;
            this.resTBox.Location = new System.Drawing.Point(423, 101);
            this.resTBox.Name = "resTBox";
            this.resTBox.Size = new System.Drawing.Size(198, 27);
            this.resTBox.TabIndex = 24;
            // 
            // teamPanel
            // 
            this.teamPanel.Controls.Add(this.teamTabControl);
            this.teamPanel.Location = new System.Drawing.Point(0, 22);
            this.teamPanel.Name = "teamPanel";
            this.teamPanel.Size = new System.Drawing.Size(680, 352);
            this.teamPanel.TabIndex = 12;
            // 
            // teamTabControl
            // 
            this.teamTabControl.Controls.Add(this.teamSquadePage);
            this.teamTabControl.Controls.Add(this.categoriesPage);
            this.teamTabControl.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.teamTabControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.teamTabControl.Location = new System.Drawing.Point(0, 1);
            this.teamTabControl.Multiline = true;
            this.teamTabControl.Name = "teamTabControl";
            this.teamTabControl.SelectedIndex = 0;
            this.teamTabControl.Size = new System.Drawing.Size(681, 347);
            this.teamTabControl.TabIndex = 12;
            // 
            // teamSquadePage
            // 
            this.teamSquadePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(211)))), ((int)(((byte)(33)))));
            this.teamSquadePage.Controls.Add(this.label3);
            this.teamSquadePage.Controls.Add(this.label2);
            this.teamSquadePage.Controls.Add(this.teamPanelCancelBtn);
            this.teamSquadePage.Controls.Add(this.teamPanelOkBtn);
            this.teamSquadePage.Controls.Add(this.label1);
            this.teamSquadePage.Controls.Add(this.teamCouchTbox);
            this.teamSquadePage.Controls.Add(this.teamNameTBox);
            this.teamSquadePage.Controls.Add(this.teammatesLBox);
            this.teamSquadePage.Location = new System.Drawing.Point(4, 25);
            this.teamSquadePage.Name = "teamSquadePage";
            this.teamSquadePage.Padding = new System.Windows.Forms.Padding(3);
            this.teamSquadePage.Size = new System.Drawing.Size(673, 318);
            this.teamSquadePage.TabIndex = 0;
            this.teamSquadePage.Text = "Команда";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.ForestGreen;
            this.label3.Location = new System.Drawing.Point(238, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Учасники команди";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.ForestGreen;
            this.label2.Location = new System.Drawing.Point(11, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "П.І.Б. тренера";
            // 
            // teamPanelCancelBtn
            // 
            this.teamPanelCancelBtn.FlatAppearance.BorderSize = 0;
            this.teamPanelCancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.teamPanelCancelBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.teamPanelCancelBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.teamPanelCancelBtn.Image = ((System.Drawing.Image)(resources.GetObject("teamPanelCancelBtn.Image")));
            this.teamPanelCancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.teamPanelCancelBtn.Location = new System.Drawing.Point(449, 269);
            this.teamPanelCancelBtn.Name = "teamPanelCancelBtn";
            this.teamPanelCancelBtn.Size = new System.Drawing.Size(147, 35);
            this.teamPanelCancelBtn.TabIndex = 17;
            this.teamPanelCancelBtn.Text = "   Відмінити";
            this.teamPanelCancelBtn.UseVisualStyleBackColor = true;
            this.teamPanelCancelBtn.Click += new System.EventHandler(this.teamPanelCancelBtn_Click);
            // 
            // teamPanelOkBtn
            // 
            this.teamPanelOkBtn.FlatAppearance.BorderSize = 0;
            this.teamPanelOkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.teamPanelOkBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.teamPanelOkBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.teamPanelOkBtn.Image = ((System.Drawing.Image)(resources.GetObject("teamPanelOkBtn.Image")));
            this.teamPanelOkBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.teamPanelOkBtn.Location = new System.Drawing.Point(32, 269);
            this.teamPanelOkBtn.Name = "teamPanelOkBtn";
            this.teamPanelOkBtn.Size = new System.Drawing.Size(145, 35);
            this.teamPanelOkBtn.TabIndex = 16;
            this.teamPanelOkBtn.Text = "   Зберегти";
            this.teamPanelOkBtn.UseVisualStyleBackColor = true;
            this.teamPanelOkBtn.Click += new System.EventHandler(this.teamPanelOkBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(8, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Назва команди";
            // 
            // teamCouchTbox
            // 
            this.teamCouchTbox.BackColor = System.Drawing.Color.ForestGreen;
            this.teamCouchTbox.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.teamCouchTbox.ForeColor = System.Drawing.Color.White;
            this.teamCouchTbox.Location = new System.Drawing.Point(8, 161);
            this.teamCouchTbox.Name = "teamCouchTbox";
            this.teamCouchTbox.Size = new System.Drawing.Size(212, 27);
            this.teamCouchTbox.TabIndex = 12;
            // 
            // teamNameTBox
            // 
            this.teamNameTBox.BackColor = System.Drawing.Color.ForestGreen;
            this.teamNameTBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.teamNameTBox.ForeColor = System.Drawing.Color.White;
            this.teamNameTBox.Location = new System.Drawing.Point(10, 74);
            this.teamNameTBox.Name = "teamNameTBox";
            this.teamNameTBox.Size = new System.Drawing.Size(212, 27);
            this.teamNameTBox.TabIndex = 11;
            // 
            // teammatesLBox
            // 
            this.teammatesLBox.BackColor = System.Drawing.Color.ForestGreen;
            this.teammatesLBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.teammatesLBox.ForeColor = System.Drawing.Color.White;
            this.teammatesLBox.FormattingEnabled = true;
            this.teammatesLBox.ItemHeight = 16;
            this.teammatesLBox.Location = new System.Drawing.Point(242, 26);
            this.teammatesLBox.Name = "teammatesLBox";
            this.teammatesLBox.Size = new System.Drawing.Size(419, 164);
            this.teammatesLBox.TabIndex = 10;
            this.teammatesLBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.teammatesLBox_MouseDown);
            // 
            // categoriesPage
            // 
            this.categoriesPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(211)))), ((int)(((byte)(33)))));
            this.categoriesPage.Controls.Add(this.teamPanelAddCatBtn);
            this.categoriesPage.Controls.Add(this.addTeammateBtn);
            this.categoriesPage.Controls.Add(this.label6);
            this.categoriesPage.Controls.Add(this.label7);
            this.categoriesPage.Controls.Add(this.turistosLBox);
            this.categoriesPage.Controls.Add(this.catTreeView);
            this.categoriesPage.Location = new System.Drawing.Point(4, 25);
            this.categoriesPage.Name = "categoriesPage";
            this.categoriesPage.Padding = new System.Windows.Forms.Padding(3);
            this.categoriesPage.Size = new System.Drawing.Size(673, 318);
            this.categoriesPage.TabIndex = 1;
            this.categoriesPage.Text = "Каталог спортсменів";
            // 
            // teamPanelAddCatBtn
            // 
            this.teamPanelAddCatBtn.FlatAppearance.BorderSize = 0;
            this.teamPanelAddCatBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.teamPanelAddCatBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.teamPanelAddCatBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.teamPanelAddCatBtn.Image = ((System.Drawing.Image)(resources.GetObject("teamPanelAddCatBtn.Image")));
            this.teamPanelAddCatBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.teamPanelAddCatBtn.Location = new System.Drawing.Point(57, 280);
            this.teamPanelAddCatBtn.Name = "teamPanelAddCatBtn";
            this.teamPanelAddCatBtn.Size = new System.Drawing.Size(208, 30);
            this.teamPanelAddCatBtn.TabIndex = 18;
            this.teamPanelAddCatBtn.Text = "   Додати категорію";
            this.teamPanelAddCatBtn.UseVisualStyleBackColor = true;
            this.teamPanelAddCatBtn.Click += new System.EventHandler(this.teamPanelAddCatBtn_Click);
            // 
            // addTeammateBtn
            // 
            this.addTeammateBtn.FlatAppearance.BorderSize = 0;
            this.addTeammateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTeammateBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addTeammateBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.addTeammateBtn.Image = ((System.Drawing.Image)(resources.GetObject("addTeammateBtn.Image")));
            this.addTeammateBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addTeammateBtn.Location = new System.Drawing.Point(391, 276);
            this.addTeammateBtn.Name = "addTeammateBtn";
            this.addTeammateBtn.Size = new System.Drawing.Size(227, 32);
            this.addTeammateBtn.TabIndex = 17;
            this.addTeammateBtn.Text = "   Додати у команду";
            this.addTeammateBtn.UseVisualStyleBackColor = true;
            this.addTeammateBtn.Click += new System.EventHandler(this.addTeammateBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(346, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Спортсмени";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(6, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Категорії";
            // 
            // turistosLBox
            // 
            this.turistosLBox.BackColor = System.Drawing.Color.ForestGreen;
            this.turistosLBox.ForeColor = System.Drawing.Color.White;
            this.turistosLBox.FormattingEnabled = true;
            this.turistosLBox.ItemHeight = 16;
            this.turistosLBox.Location = new System.Drawing.Point(349, 26);
            this.turistosLBox.Name = "turistosLBox";
            this.turistosLBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.turistosLBox.Size = new System.Drawing.Size(312, 244);
            this.turistosLBox.TabIndex = 14;
            this.turistosLBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.turistosLBox_MouseDown);
            // 
            // catTreeView
            // 
            this.catTreeView.BackColor = System.Drawing.Color.ForestGreen;
            this.catTreeView.ForeColor = System.Drawing.Color.White;
            this.catTreeView.Location = new System.Drawing.Point(9, 26);
            this.catTreeView.Name = "catTreeView";
            this.catTreeView.Size = new System.Drawing.Size(312, 251);
            this.catTreeView.TabIndex = 13;
            this.catTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.catTreeView_AfterSelect);
            this.catTreeView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.catTreeView_MouseClick);
            // 
            // categoryMenu
            // 
            this.categoryMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSubcatMBtn,
            this.renameCatMBtn,
            this.delCatMBtn,
            this.toolStripSeparator5,
            this.addSpMenuItem});
            this.categoryMenu.Name = "categoryMenu";
            this.categoryMenu.Size = new System.Drawing.Size(188, 98);
            // 
            // addSubcatMBtn
            // 
            this.addSubcatMBtn.Name = "addSubcatMBtn";
            this.addSubcatMBtn.Size = new System.Drawing.Size(187, 22);
            this.addSubcatMBtn.Text = "Додати підкатегорію";
            this.addSubcatMBtn.Click += new System.EventHandler(this.addSubcatMBtn_Click);
            // 
            // renameCatMBtn
            // 
            this.renameCatMBtn.Name = "renameCatMBtn";
            this.renameCatMBtn.Size = new System.Drawing.Size(187, 22);
            this.renameCatMBtn.Text = "Перейменувати";
            this.renameCatMBtn.Click += new System.EventHandler(this.renameCatMBtn_Click);
            // 
            // delCatMBtn
            // 
            this.delCatMBtn.Name = "delCatMBtn";
            this.delCatMBtn.Size = new System.Drawing.Size(187, 22);
            this.delCatMBtn.Text = "Видалити";
            this.delCatMBtn.Click += new System.EventHandler(this.delCatMBtn_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(184, 6);
            // 
            // addSpMenuItem
            // 
            this.addSpMenuItem.Name = "addSpMenuItem";
            this.addSpMenuItem.Size = new System.Drawing.Size(187, 22);
            this.addSpMenuItem.Text = "Додати спортсмена";
            this.addSpMenuItem.Click += new System.EventHandler(this.addSpMenuItem_Click);
            // 
            // squadeMenu
            // 
            this.squadeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remTeammateMBtn,
            this.editTeammateMBtn});
            this.squadeMenu.Name = "squadeMenu";
            this.squadeMenu.Size = new System.Drawing.Size(135, 48);
            // 
            // remTeammateMBtn
            // 
            this.remTeammateMBtn.Name = "remTeammateMBtn";
            this.remTeammateMBtn.Size = new System.Drawing.Size(134, 22);
            this.remTeammateMBtn.Text = "Вилучити";
            this.remTeammateMBtn.Click += new System.EventHandler(this.remTeammateMBtn_Click);
            // 
            // editTeammateMBtn
            // 
            this.editTeammateMBtn.Name = "editTeammateMBtn";
            this.editTeammateMBtn.Size = new System.Drawing.Size(134, 22);
            this.editTeammateMBtn.Text = "Редагувати";
            this.editTeammateMBtn.Click += new System.EventHandler(this.editTeammateMBtn_Click);
            // 
            // sportsmanMenu
            // 
            this.sportsmanMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editSportsmanMBtn,
            this.transferToOtherCatMBtn,
            this.toolStripSeparator6,
            this.delSportsmanMBtn});
            this.sportsmanMenu.Name = "squadeMenu";
            this.sportsmanMenu.Size = new System.Drawing.Size(231, 76);
            // 
            // editSportsmanMBtn
            // 
            this.editSportsmanMBtn.Name = "editSportsmanMBtn";
            this.editSportsmanMBtn.Size = new System.Drawing.Size(230, 22);
            this.editSportsmanMBtn.Text = "Редагувати";
            this.editSportsmanMBtn.Click += new System.EventHandler(this.editSportsmanMBtn_Click);
            // 
            // transferToOtherCatMBtn
            // 
            this.transferToOtherCatMBtn.Name = "transferToOtherCatMBtn";
            this.transferToOtherCatMBtn.Size = new System.Drawing.Size(230, 22);
            this.transferToOtherCatMBtn.Text = "Перенести в іншу категорію";
            this.transferToOtherCatMBtn.Click += new System.EventHandler(this.transferToOtherCatMBtn_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(227, 6);
            // 
            // delSportsmanMBtn
            // 
            this.delSportsmanMBtn.Name = "delSportsmanMBtn";
            this.delSportsmanMBtn.Size = new System.Drawing.Size(230, 22);
            this.delSportsmanMBtn.Text = "Видалити";
            this.delSportsmanMBtn.Click += new System.EventHandler(this.delSportsmanMBtn_Click);
            // 
            // compTeamMenu
            // 
            this.compTeamMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTeamMBtn,
            this.delTeamMBtn,
            this.toolStripSeparator2,
            this.teamPropMBtn});
            this.compTeamMenu.Name = "compTeamMenu";
            this.compTeamMenu.Size = new System.Drawing.Size(165, 76);
            // 
            // editTeamMBtn
            // 
            this.editTeamMBtn.Name = "editTeamMBtn";
            this.editTeamMBtn.Size = new System.Drawing.Size(164, 22);
            this.editTeamMBtn.Text = "Редагувати";
            this.editTeamMBtn.Click += new System.EventHandler(this.editTeamMBtn_Click);
            // 
            // delTeamMBtn
            // 
            this.delTeamMBtn.Name = "delTeamMBtn";
            this.delTeamMBtn.Size = new System.Drawing.Size(164, 22);
            this.delTeamMBtn.Text = "Зняти зі змагань";
            this.delTeamMBtn.Click += new System.EventHandler(this.delTeamMBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(161, 6);
            // 
            // teamPropMBtn
            // 
            this.teamPropMBtn.Name = "teamPropMBtn";
            this.teamPropMBtn.Size = new System.Drawing.Size(164, 22);
            this.teamPropMBtn.Text = "Властивості";
            this.teamPropMBtn.Click += new System.EventHandler(this.teamPropMBtn_Click);
            // 
            // compDistsMenu
            // 
            this.compDistsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeDistFromCompMBtn,
            this.toolStripSeparator3,
            this.distPropMBtn});
            this.compDistsMenu.Name = "compTeamMenu";
            this.compDistsMenu.Size = new System.Drawing.Size(186, 54);
            // 
            // removeDistFromCompMBtn
            // 
            this.removeDistFromCompMBtn.Name = "removeDistFromCompMBtn";
            this.removeDistFromCompMBtn.Size = new System.Drawing.Size(185, 22);
            this.removeDistFromCompMBtn.Text = "Вилучити зі змагань";
            this.removeDistFromCompMBtn.Click += new System.EventHandler(this.removeDistFromCompMBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(182, 6);
            // 
            // distPropMBtn
            // 
            this.distPropMBtn.Name = "distPropMBtn";
            this.distPropMBtn.Size = new System.Drawing.Size(185, 22);
            this.distPropMBtn.Text = "Властивості";
            this.distPropMBtn.Click += new System.EventHandler(this.distPropMBtn_Click);
            // 
            // distancePanel
            // 
            this.distancePanel.Controls.Add(this.tabControl);
            this.distancePanel.Location = new System.Drawing.Point(0, 24);
            this.distancePanel.Name = "distancePanel";
            this.distancePanel.Size = new System.Drawing.Size(680, 350);
            this.distancePanel.TabIndex = 12;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.distTabPage);
            this.tabControl.Controls.Add(this.stagePage);
            this.tabControl.Location = new System.Drawing.Point(2, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(677, 351);
            this.tabControl.TabIndex = 13;
            // 
            // distTabPage
            // 
            this.distTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(211)))), ((int)(((byte)(33)))));
            this.distTabPage.Controls.Add(this.distPanelCancelBtn);
            this.distTabPage.Controls.Add(this.label11);
            this.distTabPage.Controls.Add(this.penPriceTBox);
            this.distTabPage.Controls.Add(this.label10);
            this.distTabPage.Controls.Add(this.label9);
            this.distTabPage.Controls.Add(this.distHeightTBox);
            this.distTabPage.Controls.Add(this.distLenTBox);
            this.distTabPage.Controls.Add(this.tmCountNum);
            this.distTabPage.Controls.Add(this.label5);
            this.distTabPage.Controls.Add(this.label8);
            this.distTabPage.Controls.Add(this.distNameTBox);
            this.distTabPage.Controls.Add(this.label12);
            this.distTabPage.Controls.Add(this.label13);
            this.distTabPage.Controls.Add(this.distTypeLstBox);
            this.distTabPage.Controls.Add(this.distPanelCreateDistanceBtn);
            this.distTabPage.Controls.Add(this.distPanelAddStageBtn);
            this.distTabPage.Controls.Add(this.distStagesLstBox);
            this.distTabPage.Location = new System.Drawing.Point(4, 22);
            this.distTabPage.Name = "distTabPage";
            this.distTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.distTabPage.Size = new System.Drawing.Size(669, 325);
            this.distTabPage.TabIndex = 0;
            this.distTabPage.Text = "Вкладка дистанції";
            // 
            // distPanelCancelBtn
            // 
            this.distPanelCancelBtn.FlatAppearance.BorderSize = 0;
            this.distPanelCancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.distPanelCancelBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.distPanelCancelBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.distPanelCancelBtn.Image = ((System.Drawing.Image)(resources.GetObject("distPanelCancelBtn.Image")));
            this.distPanelCancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.distPanelCancelBtn.Location = new System.Drawing.Point(271, 282);
            this.distPanelCancelBtn.Name = "distPanelCancelBtn";
            this.distPanelCancelBtn.Size = new System.Drawing.Size(143, 32);
            this.distPanelCancelBtn.TabIndex = 29;
            this.distPanelCancelBtn.Text = "   Відмінити";
            this.distPanelCancelBtn.UseVisualStyleBackColor = true;
            this.distPanelCancelBtn.Click += new System.EventHandler(this.distPanelCancelBtn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.Color.ForestGreen;
            this.label11.Location = new System.Drawing.Point(416, 243);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(169, 16);
            this.label11.TabIndex = 28;
            this.label11.Text = "Ціна штрафного бала";
            // 
            // penPriceTBox
            // 
            this.penPriceTBox.BackColor = System.Drawing.Color.ForestGreen;
            this.penPriceTBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.penPriceTBox.ForeColor = System.Drawing.Color.White;
            this.penPriceTBox.Location = new System.Drawing.Point(588, 241);
            this.penPriceTBox.Name = "penPriceTBox";
            this.penPriceTBox.Size = new System.Drawing.Size(75, 21);
            this.penPriceTBox.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.ForestGreen;
            this.label10.Location = new System.Drawing.Point(484, 176);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 18);
            this.label10.TabIndex = 26;
            this.label10.Text = "Набір висоти";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.ForestGreen;
            this.label9.Location = new System.Drawing.Point(485, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 16);
            this.label9.TabIndex = 25;
            this.label9.Text = "Довжина";
            // 
            // distHeightTBox
            // 
            this.distHeightTBox.BackColor = System.Drawing.Color.ForestGreen;
            this.distHeightTBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.distHeightTBox.ForeColor = System.Drawing.Color.White;
            this.distHeightTBox.Location = new System.Drawing.Point(622, 173);
            this.distHeightTBox.Name = "distHeightTBox";
            this.distHeightTBox.Size = new System.Drawing.Size(41, 21);
            this.distHeightTBox.TabIndex = 24;
            // 
            // distLenTBox
            // 
            this.distLenTBox.BackColor = System.Drawing.Color.ForestGreen;
            this.distLenTBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.distLenTBox.ForeColor = System.Drawing.Color.White;
            this.distLenTBox.Location = new System.Drawing.Point(622, 147);
            this.distLenTBox.Name = "distLenTBox";
            this.distLenTBox.Size = new System.Drawing.Size(41, 21);
            this.distLenTBox.TabIndex = 23;
            // 
            // tmCountNum
            // 
            this.tmCountNum.BackColor = System.Drawing.Color.ForestGreen;
            this.tmCountNum.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tmCountNum.ForeColor = System.Drawing.Color.White;
            this.tmCountNum.Location = new System.Drawing.Point(622, 205);
            this.tmCountNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tmCountNum.Name = "tmCountNum";
            this.tmCountNum.Size = new System.Drawing.Size(41, 21);
            this.tmCountNum.TabIndex = 22;
            this.tmCountNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.ForestGreen;
            this.label5.Location = new System.Drawing.Point(484, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 18);
            this.label5.TabIndex = 21;
            this.label5.Text = "К-сть учасників";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.ForestGreen;
            this.label8.Location = new System.Drawing.Point(6, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 18);
            this.label8.TabIndex = 20;
            this.label8.Text = "Назва дистанції";
            // 
            // distNameTBox
            // 
            this.distNameTBox.BackColor = System.Drawing.Color.ForestGreen;
            this.distNameTBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.distNameTBox.ForeColor = System.Drawing.Color.White;
            this.distNameTBox.Location = new System.Drawing.Point(147, 241);
            this.distNameTBox.Name = "distNameTBox";
            this.distNameTBox.Size = new System.Drawing.Size(267, 21);
            this.distNameTBox.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("MS Reference Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.ForeColor = System.Drawing.Color.ForestGreen;
            this.label12.Location = new System.Drawing.Point(490, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 19);
            this.label12.TabIndex = 18;
            this.label12.Text = "Тип дистанції";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.ForeColor = System.Drawing.Color.ForestGreen;
            this.label13.Location = new System.Drawing.Point(6, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 20);
            this.label13.TabIndex = 17;
            this.label13.Text = "Етапи";
            // 
            // distTypeLstBox
            // 
            this.distTypeLstBox.BackColor = System.Drawing.Color.ForestGreen;
            this.distTypeLstBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.distTypeLstBox.ForeColor = System.Drawing.Color.White;
            this.distTypeLstBox.FormattingEnabled = true;
            this.distTypeLstBox.ItemHeight = 15;
            this.distTypeLstBox.Location = new System.Drawing.Point(488, 98);
            this.distTypeLstBox.Name = "distTypeLstBox";
            this.distTypeLstBox.Size = new System.Drawing.Size(174, 49);
            this.distTypeLstBox.TabIndex = 16;
            // 
            // distPanelCreateDistanceBtn
            // 
            this.distPanelCreateDistanceBtn.FlatAppearance.BorderSize = 0;
            this.distPanelCreateDistanceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.distPanelCreateDistanceBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.distPanelCreateDistanceBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.distPanelCreateDistanceBtn.Image = ((System.Drawing.Image)(resources.GetObject("distPanelCreateDistanceBtn.Image")));
            this.distPanelCreateDistanceBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.distPanelCreateDistanceBtn.Location = new System.Drawing.Point(9, 283);
            this.distPanelCreateDistanceBtn.Name = "distPanelCreateDistanceBtn";
            this.distPanelCreateDistanceBtn.Size = new System.Drawing.Size(138, 32);
            this.distPanelCreateDistanceBtn.TabIndex = 15;
            this.distPanelCreateDistanceBtn.Text = "    Зберегти";
            this.distPanelCreateDistanceBtn.UseVisualStyleBackColor = true;
            this.distPanelCreateDistanceBtn.Click += new System.EventHandler(this.distPanelCreateDistanceBtn_Click);
            // 
            // distPanelAddStageBtn
            // 
            this.distPanelAddStageBtn.FlatAppearance.BorderSize = 0;
            this.distPanelAddStageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.distPanelAddStageBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.distPanelAddStageBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.distPanelAddStageBtn.Image = ((System.Drawing.Image)(resources.GetObject("distPanelAddStageBtn.Image")));
            this.distPanelAddStageBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.distPanelAddStageBtn.Location = new System.Drawing.Point(488, 30);
            this.distPanelAddStageBtn.Name = "distPanelAddStageBtn";
            this.distPanelAddStageBtn.Size = new System.Drawing.Size(172, 40);
            this.distPanelAddStageBtn.TabIndex = 14;
            this.distPanelAddStageBtn.Text = "  Додати етап";
            this.distPanelAddStageBtn.UseVisualStyleBackColor = true;
            this.distPanelAddStageBtn.Click += new System.EventHandler(this.distPanelAddStageBtn_Click);
            // 
            // distStagesLstBox
            // 
            this.distStagesLstBox.BackColor = System.Drawing.Color.ForestGreen;
            this.distStagesLstBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.distStagesLstBox.ForeColor = System.Drawing.Color.White;
            this.distStagesLstBox.FormattingEnabled = true;
            this.distStagesLstBox.ItemHeight = 16;
            this.distStagesLstBox.Location = new System.Drawing.Point(6, 33);
            this.distStagesLstBox.Name = "distStagesLstBox";
            this.distStagesLstBox.Size = new System.Drawing.Size(474, 196);
            this.distStagesLstBox.TabIndex = 12;
            this.distStagesLstBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.distStagesLstBox_KeyDown);
            this.distStagesLstBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.distStagesLstBox_MouseDown);
            // 
            // stagePage
            // 
            this.stagePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(211)))), ((int)(((byte)(33)))));
            this.stagePage.Controls.Add(this.label14);
            this.stagePage.Controls.Add(this.distPanelCreateUniqueStBtn);
            this.stagePage.Controls.Add(this.lenLabel);
            this.stagePage.Controls.Add(this.distPanelDelUserStBtn);
            this.stagePage.Controls.Add(this.stageLenTBox);
            this.stagePage.Controls.Add(this.distPanelChoseStageBtn);
            this.stagePage.Controls.Add(this.stageTemplLBox);
            this.stagePage.Location = new System.Drawing.Point(4, 22);
            this.stagePage.Name = "stagePage";
            this.stagePage.Padding = new System.Windows.Forms.Padding(3);
            this.stagePage.Size = new System.Drawing.Size(669, 325);
            this.stagePage.TabIndex = 1;
            this.stagePage.Text = "Додавання етапів";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.ForeColor = System.Drawing.Color.ForestGreen;
            this.label14.Location = new System.Drawing.Point(23, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(168, 20);
            this.label14.TabIndex = 17;
            this.label14.Text = "Стандартні етапи";
            // 
            // distPanelCreateUniqueStBtn
            // 
            this.distPanelCreateUniqueStBtn.FlatAppearance.BorderSize = 0;
            this.distPanelCreateUniqueStBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.distPanelCreateUniqueStBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.distPanelCreateUniqueStBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.distPanelCreateUniqueStBtn.Image = ((System.Drawing.Image)(resources.GetObject("distPanelCreateUniqueStBtn.Image")));
            this.distPanelCreateUniqueStBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.distPanelCreateUniqueStBtn.Location = new System.Drawing.Point(442, 34);
            this.distPanelCreateUniqueStBtn.Name = "distPanelCreateUniqueStBtn";
            this.distPanelCreateUniqueStBtn.Size = new System.Drawing.Size(176, 30);
            this.distPanelCreateUniqueStBtn.TabIndex = 16;
            this.distPanelCreateUniqueStBtn.Text = "   Створити етап";
            this.distPanelCreateUniqueStBtn.UseVisualStyleBackColor = true;
            this.distPanelCreateUniqueStBtn.Click += new System.EventHandler(this.distPanelCreateUniqueStBtn_Click);
            // 
            // lenLabel
            // 
            this.lenLabel.AutoSize = true;
            this.lenLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lenLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.lenLabel.Location = new System.Drawing.Point(439, 218);
            this.lenLabel.Name = "lenLabel";
            this.lenLabel.Size = new System.Drawing.Size(130, 18);
            this.lenLabel.TabIndex = 15;
            this.lenLabel.Text = "Довжина етапу";
            // 
            // distPanelDelUserStBtn
            // 
            this.distPanelDelUserStBtn.FlatAppearance.BorderSize = 0;
            this.distPanelDelUserStBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.distPanelDelUserStBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.distPanelDelUserStBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.distPanelDelUserStBtn.Image = ((System.Drawing.Image)(resources.GetObject("distPanelDelUserStBtn.Image")));
            this.distPanelDelUserStBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.distPanelDelUserStBtn.Location = new System.Drawing.Point(442, 78);
            this.distPanelDelUserStBtn.Name = "distPanelDelUserStBtn";
            this.distPanelDelUserStBtn.Size = new System.Drawing.Size(140, 30);
            this.distPanelDelUserStBtn.TabIndex = 14;
            this.distPanelDelUserStBtn.Text = "   Видалити";
            this.distPanelDelUserStBtn.UseVisualStyleBackColor = true;
            this.distPanelDelUserStBtn.Click += new System.EventHandler(this.distPanelDelUserStBtn_Click);
            // 
            // stageLenTBox
            // 
            this.stageLenTBox.BackColor = System.Drawing.Color.ForestGreen;
            this.stageLenTBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stageLenTBox.ForeColor = System.Drawing.Color.White;
            this.stageLenTBox.Location = new System.Drawing.Point(442, 239);
            this.stageLenTBox.Name = "stageLenTBox";
            this.stageLenTBox.Size = new System.Drawing.Size(76, 21);
            this.stageLenTBox.TabIndex = 13;
            // 
            // distPanelChoseStageBtn
            // 
            this.distPanelChoseStageBtn.FlatAppearance.BorderSize = 0;
            this.distPanelChoseStageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.distPanelChoseStageBtn.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.distPanelChoseStageBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.distPanelChoseStageBtn.Image = ((System.Drawing.Image)(resources.GetObject("distPanelChoseStageBtn.Image")));
            this.distPanelChoseStageBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.distPanelChoseStageBtn.Location = new System.Drawing.Point(441, 278);
            this.distPanelChoseStageBtn.Name = "distPanelChoseStageBtn";
            this.distPanelChoseStageBtn.Size = new System.Drawing.Size(177, 33);
            this.distPanelChoseStageBtn.TabIndex = 11;
            this.distPanelChoseStageBtn.Text = "   Додати етап";
            this.distPanelChoseStageBtn.UseVisualStyleBackColor = true;
            this.distPanelChoseStageBtn.Click += new System.EventHandler(this.distPanelChoseStageBtn_Click);
            // 
            // stageTemplLBox
            // 
            this.stageTemplLBox.BackColor = System.Drawing.Color.ForestGreen;
            this.stageTemplLBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stageTemplLBox.ForeColor = System.Drawing.Color.White;
            this.stageTemplLBox.FormattingEnabled = true;
            this.stageTemplLBox.ItemHeight = 16;
            this.stageTemplLBox.Location = new System.Drawing.Point(27, 34);
            this.stageTemplLBox.Name = "stageTemplLBox";
            this.stageTemplLBox.Size = new System.Drawing.Size(399, 276);
            this.stageTemplLBox.TabIndex = 10;
            this.stageTemplLBox.SelectedIndexChanged += new System.EventHandler(this.stageTemplLBox_SelectedIndexChanged);
            // 
            // distMenu
            // 
            this.distMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remStageMBtn});
            this.distMenu.Name = "compTeamMenu";
            this.distMenu.Size = new System.Drawing.Size(155, 26);
            // 
            // remStageMBtn
            // 
            this.remStageMBtn.Name = "remStageMBtn";
            this.remStageMBtn.Size = new System.Drawing.Size(154, 22);
            this.remStageMBtn.Text = "Вилучити етап";
            this.remStageMBtn.Click += new System.EventHandler(this.remStageMBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Location = new System.Drawing.Point(89, 155);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(105, 95);
            this.panel2.TabIndex = 12;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.ForeColor = System.Drawing.Color.ForestGreen;
            this.label17.Location = new System.Drawing.Point(211, 177);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(396, 52);
            this.label17.TabIndex = 13;
            this.label17.Text = "Для початку роботи\r\nвідкрийте або створіть змагання\r\n";
            // 
            // participMenu
            // 
            this.participMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.participPropMBtn});
            this.participMenu.Name = "compTeamMenu";
            this.participMenu.Size = new System.Drawing.Size(140, 26);
            // 
            // participPropMBtn
            // 
            this.participPropMBtn.Name = "participPropMBtn";
            this.participPropMBtn.Size = new System.Drawing.Size(139, 22);
            this.participPropMBtn.Text = "Властивості";
            this.participPropMBtn.Click += new System.EventHandler(this.participPropMBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(211)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(680, 376);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.mainMenu);
            //this.Controls.Add(this.competitionsPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(696, 415);
            this.MinimumSize = new System.Drawing.Size(696, 415);
            this.Name = "MainForm";
            this.Text = "Менеджер змагань";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.MainForm_ControlAdded);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.MainForm_ControlRemoved);
            this.competitionsPanel.ResumeLayout(false);
            this.competitionsPanel.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.distResPanel.ResumeLayout(false);
            this.distResPanel.PerformLayout();
            this.teamPanel.ResumeLayout(false);
            this.teamTabControl.ResumeLayout(false);
            this.teamSquadePage.ResumeLayout(false);
            this.teamSquadePage.PerformLayout();
            this.categoriesPage.ResumeLayout(false);
            this.categoriesPage.PerformLayout();
            this.categoryMenu.ResumeLayout(false);
            this.squadeMenu.ResumeLayout(false);
            this.sportsmanMenu.ResumeLayout(false);
            this.compTeamMenu.ResumeLayout(false);
            this.compDistsMenu.ResumeLayout(false);
            this.distancePanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.distTabPage.ResumeLayout(false);
            this.distTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmCountNum)).EndInit();
            this.stagePage.ResumeLayout(false);
            this.stagePage.PerformLayout();
            this.distMenu.ResumeLayout(false);
            this.participMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel competitionsPanel;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem compMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runCompMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem createCompMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem delCompMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem teamMenuItem;
        private System.Windows.Forms.ToolStripMenuItem distMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createTeamMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem createDistMBtn;
        private System.Windows.Forms.ToolStripMenuItem editDistMBtn;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem створитиToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem createStartProtMBtn;
        private System.Windows.Forms.ToolStripMenuItem createDistResMBtn;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem createDistConditionsMBtn;
        private System.Windows.Forms.ListBox compTeamsListBox;
        private System.Windows.Forms.ListBox compDistsListBox;
        private System.Windows.Forms.Button showResBtn;
        private System.Windows.Forms.Panel distResPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label distResPanelMainLabel;
        private System.Windows.Forms.TextBox resTBox;
        private System.Windows.Forms.Button viewTeamResBtn;
        private System.Windows.Forms.Panel teamPanel;
        private System.Windows.Forms.Button teamPanelCancelBtn;
        private System.Windows.Forms.TabControl teamTabControl;
        private System.Windows.Forms.TabPage teamSquadePage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox teamCouchTbox;
        private System.Windows.Forms.TextBox teamNameTBox;
        private System.Windows.Forms.ListBox teammatesLBox;
        private System.Windows.Forms.TabPage categoriesPage;
        private System.Windows.Forms.Button addTeammateBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox turistosLBox;
        private System.Windows.Forms.TreeView catTreeView;
        private System.Windows.Forms.Button teamPanelOkBtn;
        private System.Windows.Forms.ContextMenuStrip categoryMenu;
        private System.Windows.Forms.ToolStripMenuItem addSubcatMBtn;
        private System.Windows.Forms.ToolStripMenuItem renameCatMBtn;
        private System.Windows.Forms.ToolStripMenuItem delCatMBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem addSpMenuItem;
        private System.Windows.Forms.ContextMenuStrip squadeMenu;
        private System.Windows.Forms.ToolStripMenuItem remTeammateMBtn;
        private System.Windows.Forms.ToolStripMenuItem editTeammateMBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip sportsmanMenu;
        private System.Windows.Forms.ToolStripMenuItem editSportsmanMBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem delSportsmanMBtn;
        private System.Windows.Forms.ToolStripMenuItem backMBtn;
        private System.Windows.Forms.ToolStripMenuItem addDistMBtn;
        private System.Windows.Forms.ContextMenuStrip compTeamMenu;
        private System.Windows.Forms.ToolStripMenuItem editTeamMBtn;
        private System.Windows.Forms.ToolStripMenuItem delTeamMBtn;
        private System.Windows.Forms.ToolStripMenuItem transferToOtherCatMBtn;
        private System.Windows.Forms.ContextMenuStrip compDistsMenu;
        private System.Windows.Forms.ToolStripMenuItem removeDistFromCompMBtn;
        private System.Windows.Forms.Button addTeamToDistanceBtn;
        private System.Windows.Forms.Panel distancePanel;
        private System.Windows.Forms.TabPage distTabPage;
        private System.Windows.Forms.Button distPanelCancelBtn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox penPriceTBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox distHeightTBox;
        private System.Windows.Forms.TextBox distLenTBox;
        private System.Windows.Forms.NumericUpDown tmCountNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox distNameTBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox distTypeLstBox;
        private System.Windows.Forms.Button distPanelCreateDistanceBtn;
        private System.Windows.Forms.Button distPanelAddStageBtn;
        private System.Windows.Forms.ListBox distStagesLstBox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage stagePage;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button distPanelCreateUniqueStBtn;
        private System.Windows.Forms.Label lenLabel;
        private System.Windows.Forms.Button distPanelDelUserStBtn;
        private System.Windows.Forms.TextBox stageLenTBox;
        private System.Windows.Forms.Button distPanelChoseStageBtn;
        private System.Windows.Forms.ListBox stageTemplLBox;
        private System.Windows.Forms.ContextMenuStrip distMenu;
        private System.Windows.Forms.ToolStripMenuItem remStageMBtn;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem delDistMBtn;
        private System.Windows.Forms.Button distResPanelSortTeamBtn;
        private System.Windows.Forms.CheckBox reverseSortChecker;
        private System.Windows.Forms.ListBox participsListBox;
        private System.Windows.Forms.Button teamPanelAddCatBtn;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label compNameLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem teamPropMBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem distPropMBtn;
        private System.Windows.Forms.ContextMenuStrip participMenu;
        private System.Windows.Forms.ToolStripMenuItem participPropMBtn;
        private System.Windows.Forms.DateTimePicker compDatePicker;
    }
}

