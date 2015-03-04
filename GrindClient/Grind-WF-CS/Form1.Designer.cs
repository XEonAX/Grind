namespace Grind_WF_CS
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
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.tpTask = new System.Windows.Forms.TabPage();
            this.scTasksMain = new System.Windows.Forms.SplitContainer();
            this.spTaskListAndForm = new System.Windows.Forms.SplitContainer();
            this.dGridTasks = new System.Windows.Forms.DataGridView();
            this.colTaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaskStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaskType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBugType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTargetDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExecutor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReviewer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApproved = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.cobReviewer = new System.Windows.Forms.ComboBox();
            this.cobExecutor = new System.Windows.Forms.ComboBox();
            this.GroupBox7 = new System.Windows.Forms.GroupBox();
            this.cbApproved = new System.Windows.Forms.CheckBox();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.rbOthers = new System.Windows.Forms.RadioButton();
            this.rbCRITSIT = new System.Windows.Forms.RadioButton();
            this.rbBacklog = new System.Windows.Forms.RadioButton();
            this.rbHMA = new System.Windows.Forms.RadioButton();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.rbHL = new System.Windows.Forms.RadioButton();
            this.rbBug = new System.Windows.Forms.RadioButton();
            this.gbTaskStatus = new System.Windows.Forms.GroupBox();
            this.tlpTaskStatus = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpPromotion = new System.Windows.Forms.DateTimePicker();
            this.dtpCorrection = new System.Windows.Forms.DateTimePicker();
            this.dtpReview = new System.Windows.Forms.DateTimePicker();
            this.dtpAnalysis = new System.Windows.Forms.DateTimePicker();
            this.dtpOpen = new System.Windows.Forms.DateTimePicker();
            this.dtpCollection = new System.Windows.Forms.DateTimePicker();
            this.dtpClosed = new System.Windows.Forms.DateTimePicker();
            this.trbTaskStatus = new System.Windows.Forms.TrackBar();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tpFiles = new System.Windows.Forms.TabPage();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtbAnalysis = new System.Windows.Forms.RichTextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.rtbReview = new System.Windows.Forms.RichTextBox();
            this.TabControl1.SuspendLayout();
            this.tpTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scTasksMain)).BeginInit();
            this.scTasksMain.Panel1.SuspendLayout();
            this.scTasksMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spTaskListAndForm)).BeginInit();
            this.spTaskListAndForm.Panel1.SuspendLayout();
            this.spTaskListAndForm.Panel2.SuspendLayout();
            this.spTaskListAndForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridTasks)).BeginInit();
            this.GroupBox6.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.GroupBox7.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.gbTaskStatus.SuspendLayout();
            this.tlpTaskStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbTaskStatus)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.tpTask);
            this.TabControl1.Controls.Add(this.tpFiles);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.HotTrack = true;
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(1010, 520);
            this.TabControl1.TabIndex = 1;
            // 
            // tpTask
            // 
            this.tpTask.Controls.Add(this.scTasksMain);
            this.tpTask.Location = new System.Drawing.Point(4, 22);
            this.tpTask.Name = "tpTask";
            this.tpTask.Padding = new System.Windows.Forms.Padding(3);
            this.tpTask.Size = new System.Drawing.Size(1002, 494);
            this.tpTask.TabIndex = 1;
            this.tpTask.Text = "Tasks";
            this.tpTask.UseVisualStyleBackColor = true;
            // 
            // scTasksMain
            // 
            this.scTasksMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scTasksMain.Location = new System.Drawing.Point(3, 3);
            this.scTasksMain.Name = "scTasksMain";
            // 
            // scTasksMain.Panel1
            // 
            this.scTasksMain.Panel1.Controls.Add(this.spTaskListAndForm);
            this.scTasksMain.Panel1.Controls.Add(this.MenuStrip1);
            this.scTasksMain.Panel2MinSize = 80;
            this.scTasksMain.Size = new System.Drawing.Size(996, 488);
            this.scTasksMain.SplitterDistance = 875;
            this.scTasksMain.TabIndex = 0;
            // 
            // spTaskListAndForm
            // 
            this.spTaskListAndForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spTaskListAndForm.Location = new System.Drawing.Point(0, 24);
            this.spTaskListAndForm.Name = "spTaskListAndForm";
            this.spTaskListAndForm.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spTaskListAndForm.Panel1
            // 
            this.spTaskListAndForm.Panel1.Controls.Add(this.dGridTasks);
            // 
            // spTaskListAndForm.Panel2
            // 
            this.spTaskListAndForm.Panel2.AutoScroll = true;
            this.spTaskListAndForm.Panel2.Controls.Add(this.groupBox9);
            this.spTaskListAndForm.Panel2.Controls.Add(this.groupBox2);
            this.spTaskListAndForm.Panel2.Controls.Add(this.GroupBox6);
            this.spTaskListAndForm.Panel2.Controls.Add(this.GroupBox3);
            this.spTaskListAndForm.Panel2.Controls.Add(this.gbTaskStatus);
            this.spTaskListAndForm.Panel2.Controls.Add(this.GroupBox1);
            this.spTaskListAndForm.Panel2.Controls.Add(this.TextBox1);
            this.spTaskListAndForm.Size = new System.Drawing.Size(875, 464);
            this.spTaskListAndForm.SplitterDistance = 259;
            this.spTaskListAndForm.TabIndex = 0;
            // 
            // dGridTasks
            // 
            this.dGridTasks.AllowUserToAddRows = false;
            this.dGridTasks.AllowUserToDeleteRows = false;
            this.dGridTasks.AllowUserToResizeRows = false;
            this.dGridTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGridTasks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dGridTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTaskName,
            this.colTaskStatus,
            this.colTaskType,
            this.colBugType,
            this.colTargetDate,
            this.colExecutor,
            this.colReviewer,
            this.colApproved,
            this.colModified,
            this.colCreated});
            this.dGridTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGridTasks.Location = new System.Drawing.Point(0, 0);
            this.dGridTasks.Name = "dGridTasks";
            this.dGridTasks.ReadOnly = true;
            this.dGridTasks.RowHeadersVisible = false;
            this.dGridTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGridTasks.Size = new System.Drawing.Size(875, 259);
            this.dGridTasks.TabIndex = 1;
            this.dGridTasks.SelectionChanged += new System.EventHandler(this.dGridTasks_SelectionChanged);
            // 
            // colTaskName
            // 
            this.colTaskName.DataPropertyName = "Name";
            this.colTaskName.FillWeight = 40F;
            this.colTaskName.HeaderText = "Task Name";
            this.colTaskName.Name = "colTaskName";
            this.colTaskName.ReadOnly = true;
            // 
            // colTaskStatus
            // 
            this.colTaskStatus.DataPropertyName = "TaskStatus";
            this.colTaskStatus.FillWeight = 15F;
            this.colTaskStatus.HeaderText = "Task Status";
            this.colTaskStatus.Name = "colTaskStatus";
            this.colTaskStatus.ReadOnly = true;
            // 
            // colTaskType
            // 
            this.colTaskType.DataPropertyName = "TaskType";
            this.colTaskType.FillWeight = 15F;
            this.colTaskType.HeaderText = "Task Type";
            this.colTaskType.Name = "colTaskType";
            this.colTaskType.ReadOnly = true;
            // 
            // colBugType
            // 
            this.colBugType.DataPropertyName = "BugType";
            this.colBugType.FillWeight = 10F;
            this.colBugType.HeaderText = "Bug Type";
            this.colBugType.Name = "colBugType";
            this.colBugType.ReadOnly = true;
            // 
            // colTargetDate
            // 
            this.colTargetDate.DataPropertyName = "TargetDate";
            this.colTargetDate.FillWeight = 15F;
            this.colTargetDate.HeaderText = "Target Date";
            this.colTargetDate.Name = "colTargetDate";
            this.colTargetDate.ReadOnly = true;
            // 
            // colExecutor
            // 
            this.colExecutor.DataPropertyName = "DeveloperName";
            this.colExecutor.FillWeight = 20F;
            this.colExecutor.HeaderText = "Executor";
            this.colExecutor.Name = "colExecutor";
            this.colExecutor.ReadOnly = true;
            // 
            // colReviewer
            // 
            this.colReviewer.DataPropertyName = "ReviewerName";
            this.colReviewer.FillWeight = 20F;
            this.colReviewer.HeaderText = "Reviewer";
            this.colReviewer.Name = "colReviewer";
            this.colReviewer.ReadOnly = true;
            // 
            // colApproved
            // 
            this.colApproved.DataPropertyName = "Approved";
            this.colApproved.FillWeight = 10F;
            this.colApproved.HeaderText = "Approved";
            this.colApproved.Name = "colApproved";
            this.colApproved.ReadOnly = true;
            this.colApproved.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colApproved.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colModified
            // 
            this.colModified.DataPropertyName = "UpdatedAt";
            this.colModified.FillWeight = 10F;
            this.colModified.HeaderText = "Modified";
            this.colModified.Name = "colModified";
            this.colModified.ReadOnly = true;
            // 
            // colCreated
            // 
            this.colCreated.DataPropertyName = "CreatedAt";
            this.colCreated.FillWeight = 10F;
            this.colCreated.HeaderText = "Created";
            this.colCreated.Name = "colCreated";
            this.colCreated.ReadOnly = true;
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.rtbDescription);
            this.GroupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBox6.Location = new System.Drawing.Point(0, 282);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(858, 197);
            this.GroupBox6.TabIndex = 5;
            this.GroupBox6.TabStop = false;
            this.GroupBox6.Text = "Description";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.GroupBox8);
            this.GroupBox3.Controls.Add(this.GroupBox7);
            this.GroupBox3.Controls.Add(this.GroupBox5);
            this.GroupBox3.Controls.Add(this.GroupBox4);
            this.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBox3.Location = new System.Drawing.Point(0, 186);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(858, 96);
            this.GroupBox3.TabIndex = 4;
            this.GroupBox3.TabStop = false;
            // 
            // GroupBox8
            // 
            this.GroupBox8.Controls.Add(this.Panel1);
            this.GroupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox8.Location = new System.Drawing.Point(444, 16);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(411, 77);
            this.GroupBox8.TabIndex = 3;
            this.GroupBox8.TabStop = false;
            this.GroupBox8.Text = "Concerned Persons";
            // 
            // Panel1
            // 
            this.Panel1.AutoScroll = true;
            this.Panel1.Controls.Add(this.cobReviewer);
            this.Panel1.Controls.Add(this.cobExecutor);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(3, 16);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(405, 58);
            this.Panel1.TabIndex = 0;
            // 
            // cobReviewer
            // 
            this.cobReviewer.Dock = System.Windows.Forms.DockStyle.Left;
            this.cobReviewer.FormattingEnabled = true;
            this.cobReviewer.Items.AddRange(new object[] {
            "Reviewer",
            "-------------------------"});
            this.cobReviewer.Location = new System.Drawing.Point(144, 0);
            this.cobReviewer.Name = "cobReviewer";
            this.cobReviewer.Size = new System.Drawing.Size(144, 21);
            this.cobReviewer.TabIndex = 1;
            // 
            // cobExecutor
            // 
            this.cobExecutor.Dock = System.Windows.Forms.DockStyle.Left;
            this.cobExecutor.FormattingEnabled = true;
            this.cobExecutor.Items.AddRange(new object[] {
            "Executor",
            "-------------------------"});
            this.cobExecutor.Location = new System.Drawing.Point(0, 0);
            this.cobExecutor.Name = "cobExecutor";
            this.cobExecutor.Size = new System.Drawing.Size(144, 21);
            this.cobExecutor.TabIndex = 0;
            // 
            // GroupBox7
            // 
            this.GroupBox7.AutoSize = true;
            this.GroupBox7.Controls.Add(this.cbApproved);
            this.GroupBox7.Dock = System.Windows.Forms.DockStyle.Left;
            this.GroupBox7.Location = new System.Drawing.Point(334, 16);
            this.GroupBox7.Name = "GroupBox7";
            this.GroupBox7.Size = new System.Drawing.Size(110, 77);
            this.GroupBox7.TabIndex = 2;
            this.GroupBox7.TabStop = false;
            this.GroupBox7.Text = "Approval";
            // 
            // cbApproved
            // 
            this.cbApproved.AutoSize = true;
            this.cbApproved.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbApproved.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbApproved.Location = new System.Drawing.Point(3, 16);
            this.cbApproved.Name = "cbApproved";
            this.cbApproved.Size = new System.Drawing.Size(104, 58);
            this.cbApproved.TabIndex = 0;
            this.cbApproved.Tag = "Approved";
            this.cbApproved.Text = "Approved";
            this.cbApproved.UseVisualStyleBackColor = true;
            // 
            // GroupBox5
            // 
            this.GroupBox5.AutoSize = true;
            this.GroupBox5.Controls.Add(this.rbOthers);
            this.GroupBox5.Controls.Add(this.rbCRITSIT);
            this.GroupBox5.Controls.Add(this.rbBacklog);
            this.GroupBox5.Controls.Add(this.rbHMA);
            this.GroupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.GroupBox5.Location = new System.Drawing.Point(92, 16);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(242, 77);
            this.GroupBox5.TabIndex = 1;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "BugType";
            // 
            // rbOthers
            // 
            this.rbOthers.AutoSize = true;
            this.rbOthers.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbOthers.Location = new System.Drawing.Point(183, 16);
            this.rbOthers.Name = "rbOthers";
            this.rbOthers.Size = new System.Drawing.Size(56, 58);
            this.rbOthers.TabIndex = 3;
            this.rbOthers.TabStop = true;
            this.rbOthers.Tag = "Others";
            this.rbOthers.Text = "Others";
            this.rbOthers.UseVisualStyleBackColor = true;
            // 
            // rbCRITSIT
            // 
            this.rbCRITSIT.AutoSize = true;
            this.rbCRITSIT.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbCRITSIT.Location = new System.Drawing.Point(116, 16);
            this.rbCRITSIT.Name = "rbCRITSIT";
            this.rbCRITSIT.Size = new System.Drawing.Size(67, 58);
            this.rbCRITSIT.TabIndex = 2;
            this.rbCRITSIT.TabStop = true;
            this.rbCRITSIT.Tag = "CRITSIT";
            this.rbCRITSIT.Text = "CRITSIT";
            this.rbCRITSIT.UseVisualStyleBackColor = true;
            // 
            // rbBacklog
            // 
            this.rbBacklog.AutoSize = true;
            this.rbBacklog.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbBacklog.Location = new System.Drawing.Point(52, 16);
            this.rbBacklog.Name = "rbBacklog";
            this.rbBacklog.Size = new System.Drawing.Size(64, 58);
            this.rbBacklog.TabIndex = 1;
            this.rbBacklog.TabStop = true;
            this.rbBacklog.Tag = "Backlog";
            this.rbBacklog.Text = "Backlog";
            this.rbBacklog.UseVisualStyleBackColor = true;
            // 
            // rbHMA
            // 
            this.rbHMA.AutoSize = true;
            this.rbHMA.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbHMA.Location = new System.Drawing.Point(3, 16);
            this.rbHMA.Name = "rbHMA";
            this.rbHMA.Size = new System.Drawing.Size(49, 58);
            this.rbHMA.TabIndex = 0;
            this.rbHMA.TabStop = true;
            this.rbHMA.Tag = "HMA";
            this.rbHMA.Text = "HMA";
            this.rbHMA.UseVisualStyleBackColor = true;
            // 
            // GroupBox4
            // 
            this.GroupBox4.AutoSize = true;
            this.GroupBox4.Controls.Add(this.rbHL);
            this.GroupBox4.Controls.Add(this.rbBug);
            this.GroupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.GroupBox4.Location = new System.Drawing.Point(3, 16);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(89, 77);
            this.GroupBox4.TabIndex = 0;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Task Type";
            // 
            // rbHL
            // 
            this.rbHL.AutoSize = true;
            this.rbHL.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbHL.Location = new System.Drawing.Point(47, 16);
            this.rbHL.Name = "rbHL";
            this.rbHL.Size = new System.Drawing.Size(39, 58);
            this.rbHL.TabIndex = 1;
            this.rbHL.TabStop = true;
            this.rbHL.Tag = "HL";
            this.rbHL.Text = "HL";
            this.rbHL.UseVisualStyleBackColor = true;
            // 
            // rbBug
            // 
            this.rbBug.AutoSize = true;
            this.rbBug.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbBug.Location = new System.Drawing.Point(3, 16);
            this.rbBug.Name = "rbBug";
            this.rbBug.Size = new System.Drawing.Size(44, 58);
            this.rbBug.TabIndex = 0;
            this.rbBug.TabStop = true;
            this.rbBug.Tag = "Bug";
            this.rbBug.Text = "Bug";
            this.rbBug.UseVisualStyleBackColor = true;
            // 
            // gbTaskStatus
            // 
            this.gbTaskStatus.Controls.Add(this.tlpTaskStatus);
            this.gbTaskStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTaskStatus.Location = new System.Drawing.Point(0, 67);
            this.gbTaskStatus.Name = "gbTaskStatus";
            this.gbTaskStatus.Size = new System.Drawing.Size(858, 119);
            this.gbTaskStatus.TabIndex = 3;
            this.gbTaskStatus.TabStop = false;
            this.gbTaskStatus.Text = "Task Status";
            // 
            // tlpTaskStatus
            // 
            this.tlpTaskStatus.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpTaskStatus.ColumnCount = 7;
            this.tlpTaskStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpTaskStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpTaskStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpTaskStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpTaskStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpTaskStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpTaskStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpTaskStatus.Controls.Add(this.label1, 0, 0);
            this.tlpTaskStatus.Controls.Add(this.label2, 1, 0);
            this.tlpTaskStatus.Controls.Add(this.label3, 2, 0);
            this.tlpTaskStatus.Controls.Add(this.label4, 3, 0);
            this.tlpTaskStatus.Controls.Add(this.label5, 4, 0);
            this.tlpTaskStatus.Controls.Add(this.label6, 5, 0);
            this.tlpTaskStatus.Controls.Add(this.label7, 6, 0);
            this.tlpTaskStatus.Controls.Add(this.dtpPromotion, 4, 2);
            this.tlpTaskStatus.Controls.Add(this.dtpCorrection, 3, 2);
            this.tlpTaskStatus.Controls.Add(this.dtpReview, 2, 2);
            this.tlpTaskStatus.Controls.Add(this.dtpAnalysis, 1, 2);
            this.tlpTaskStatus.Controls.Add(this.dtpOpen, 0, 2);
            this.tlpTaskStatus.Controls.Add(this.dtpCollection, 5, 2);
            this.tlpTaskStatus.Controls.Add(this.dtpClosed, 6, 2);
            this.tlpTaskStatus.Controls.Add(this.trbTaskStatus, 0, 1);
            this.tlpTaskStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTaskStatus.Location = new System.Drawing.Point(3, 16);
            this.tlpTaskStatus.Name = "tlpTaskStatus";
            this.tlpTaskStatus.RowCount = 3;
            this.tlpTaskStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTaskStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tlpTaskStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpTaskStatus.Size = new System.Drawing.Size(852, 100);
            this.tlpTaskStatus.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Open";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(125, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Analysis";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(246, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Review";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(367, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Correction";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(488, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "Promotion";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(609, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "Collection";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(730, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "Closed";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpPromotion
            // 
            this.dtpPromotion.Checked = false;
            this.dtpPromotion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpPromotion.Enabled = false;
            this.dtpPromotion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPromotion.Location = new System.Drawing.Point(488, 77);
            this.dtpPromotion.Name = "dtpPromotion";
            this.dtpPromotion.Size = new System.Drawing.Size(114, 20);
            this.dtpPromotion.TabIndex = 13;
            this.dtpPromotion.Tag = "PromotionDate";
            // 
            // dtpCorrection
            // 
            this.dtpCorrection.Checked = false;
            this.dtpCorrection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpCorrection.Enabled = false;
            this.dtpCorrection.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCorrection.Location = new System.Drawing.Point(367, 77);
            this.dtpCorrection.Name = "dtpCorrection";
            this.dtpCorrection.Size = new System.Drawing.Size(114, 20);
            this.dtpCorrection.TabIndex = 12;
            this.dtpCorrection.Tag = "CorrectionDate";
            // 
            // dtpReview
            // 
            this.dtpReview.Checked = false;
            this.dtpReview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpReview.Enabled = false;
            this.dtpReview.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReview.Location = new System.Drawing.Point(246, 77);
            this.dtpReview.Name = "dtpReview";
            this.dtpReview.Size = new System.Drawing.Size(114, 20);
            this.dtpReview.TabIndex = 11;
            this.dtpReview.Tag = "ReviewDate";
            // 
            // dtpAnalysis
            // 
            this.dtpAnalysis.Checked = false;
            this.dtpAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpAnalysis.Enabled = false;
            this.dtpAnalysis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAnalysis.Location = new System.Drawing.Point(125, 77);
            this.dtpAnalysis.Name = "dtpAnalysis";
            this.dtpAnalysis.Size = new System.Drawing.Size(114, 20);
            this.dtpAnalysis.TabIndex = 10;
            this.dtpAnalysis.Tag = "AnalysisDate";
            // 
            // dtpOpen
            // 
            this.dtpOpen.Checked = false;
            this.dtpOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpOpen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOpen.Location = new System.Drawing.Point(4, 77);
            this.dtpOpen.Name = "dtpOpen";
            this.dtpOpen.Size = new System.Drawing.Size(114, 20);
            this.dtpOpen.TabIndex = 9;
            this.dtpOpen.Tag = "OpenDate";
            this.dtpOpen.Value = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            // 
            // dtpCollection
            // 
            this.dtpCollection.Checked = false;
            this.dtpCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpCollection.Enabled = false;
            this.dtpCollection.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCollection.Location = new System.Drawing.Point(609, 77);
            this.dtpCollection.Name = "dtpCollection";
            this.dtpCollection.Size = new System.Drawing.Size(114, 20);
            this.dtpCollection.TabIndex = 16;
            this.dtpCollection.Tag = "CollectionDate";
            // 
            // dtpClosed
            // 
            this.dtpClosed.Checked = false;
            this.dtpClosed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpClosed.Enabled = false;
            this.dtpClosed.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpClosed.Location = new System.Drawing.Point(730, 77);
            this.dtpClosed.Name = "dtpClosed";
            this.dtpClosed.Size = new System.Drawing.Size(118, 20);
            this.dtpClosed.TabIndex = 17;
            this.dtpClosed.Tag = "ClosedDate";
            // 
            // trbTaskStatus
            // 
            this.tlpTaskStatus.SetColumnSpan(this.trbTaskStatus, 7);
            this.trbTaskStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trbTaskStatus.LargeChange = 1;
            this.trbTaskStatus.Location = new System.Drawing.Point(11, 25);
            this.trbTaskStatus.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.trbTaskStatus.Maximum = 6;
            this.trbTaskStatus.Name = "trbTaskStatus";
            this.trbTaskStatus.Size = new System.Drawing.Size(830, 45);
            this.trbTaskStatus.TabIndex = 18;
            this.trbTaskStatus.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trbTaskStatus.ValueChanged += new System.EventHandler(this.trbTaskStatus_ValueChanged);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtTitle);
            this.GroupBox1.Controls.Add(this.label8);
            this.GroupBox1.Controls.Add(this.txtTaskName);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBox1.Location = new System.Drawing.Point(0, 27);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(858, 40);
            this.GroupBox1.TabIndex = 2;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Name";
            // 
            // txtTitle
            // 
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTitle.Location = new System.Drawing.Point(233, 16);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(622, 20);
            this.txtTitle.TabIndex = 3;
            this.txtTitle.Tag = "TaskName";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Location = new System.Drawing.Point(184, 16);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label8.Size = new System.Drawing.Size(49, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "Abstract:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTaskName
            // 
            this.txtTaskName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTaskName.Location = new System.Drawing.Point(3, 16);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(181, 20);
            this.txtTaskName.TabIndex = 1;
            this.txtTaskName.Tag = "TaskName";
            // 
            // TextBox1
            // 
            this.TextBox1.BackColor = System.Drawing.Color.ForestGreen;
            this.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox1.ForeColor = System.Drawing.Color.White;
            this.TextBox1.Location = new System.Drawing.Point(0, 0);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.ReadOnly = true;
            this.TextBox1.Size = new System.Drawing.Size(858, 27);
            this.TextBox1.TabIndex = 1;
            this.TextBox1.Text = "TaskTracking Form";
            this.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem1,
            this.RefreshToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(875, 24);
            this.MenuStrip1.TabIndex = 1;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(43, 20);
            this.ToolStripMenuItem1.Text = "New";
            this.ToolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.RefreshToolStripMenuItem.Text = "Refresh";
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // tpFiles
            // 
            this.tpFiles.Location = new System.Drawing.Point(4, 22);
            this.tpFiles.Name = "tpFiles";
            this.tpFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tpFiles.Size = new System.Drawing.Size(1002, 494);
            this.tpFiles.TabIndex = 0;
            this.tpFiles.Text = "Files";
            this.tpFiles.UseVisualStyleBackColor = true;
            // 
            // rtbDescription
            // 
            this.rtbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDescription.Location = new System.Drawing.Point(3, 16);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(852, 178);
            this.rtbDescription.TabIndex = 0;
            this.rtbDescription.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtbAnalysis);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 479);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(858, 197);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Analysis";
            // 
            // rtbAnalysis
            // 
            this.rtbAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbAnalysis.Location = new System.Drawing.Point(3, 16);
            this.rtbAnalysis.Name = "rtbAnalysis";
            this.rtbAnalysis.Size = new System.Drawing.Size(852, 178);
            this.rtbAnalysis.TabIndex = 0;
            this.rtbAnalysis.Text = "";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.rtbReview);
            this.groupBox9.Location = new System.Drawing.Point(144, 695);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(420, 197);
            this.groupBox9.TabIndex = 7;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Description";
            // 
            // rtbReview
            // 
            this.rtbReview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbReview.Location = new System.Drawing.Point(3, 16);
            this.rtbReview.Name = "rtbReview";
            this.rtbReview.Size = new System.Drawing.Size(414, 178);
            this.rtbReview.TabIndex = 0;
            this.rtbReview.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 520);
            this.Controls.Add(this.TabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TabControl1.ResumeLayout(false);
            this.tpTask.ResumeLayout(false);
            this.scTasksMain.Panel1.ResumeLayout(false);
            this.scTasksMain.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scTasksMain)).EndInit();
            this.scTasksMain.ResumeLayout(false);
            this.spTaskListAndForm.Panel1.ResumeLayout(false);
            this.spTaskListAndForm.Panel2.ResumeLayout(false);
            this.spTaskListAndForm.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spTaskListAndForm)).EndInit();
            this.spTaskListAndForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridTasks)).EndInit();
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox8.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.GroupBox7.ResumeLayout(false);
            this.GroupBox7.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.gbTaskStatus.ResumeLayout(false);
            this.tlpTaskStatus.ResumeLayout(false);
            this.tlpTaskStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbTaskStatus)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage tpTask;
        internal System.Windows.Forms.SplitContainer scTasksMain;
        internal System.Windows.Forms.SplitContainer spTaskListAndForm;
        internal System.Windows.Forms.DataGridView dGridTasks;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colTaskName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colTaskStatus;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colTaskType;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colBugType;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colTargetDate;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colExecutor;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colReviewer;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn colApproved;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colModified;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colCreated;
        internal System.Windows.Forms.GroupBox GroupBox6;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.GroupBox GroupBox8;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.ComboBox cobReviewer;
        internal System.Windows.Forms.ComboBox cobExecutor;
        internal System.Windows.Forms.GroupBox GroupBox7;
        internal System.Windows.Forms.CheckBox cbApproved;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.RadioButton rbOthers;
        internal System.Windows.Forms.RadioButton rbCRITSIT;
        internal System.Windows.Forms.RadioButton rbBacklog;
        internal System.Windows.Forms.RadioButton rbHMA;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.RadioButton rbHL;
        internal System.Windows.Forms.RadioButton rbBug;
        internal System.Windows.Forms.GroupBox gbTaskStatus;
        internal System.Windows.Forms.TableLayoutPanel tlpTaskStatus;
        internal System.Windows.Forms.DateTimePicker dtpPromotion;
        internal System.Windows.Forms.DateTimePicker dtpCorrection;
        internal System.Windows.Forms.DateTimePicker dtpReview;
        internal System.Windows.Forms.DateTimePicker dtpAnalysis;
        internal System.Windows.Forms.DateTimePicker dtpOpen;
        internal System.Windows.Forms.DateTimePicker dtpCollection;
        internal System.Windows.Forms.DateTimePicker dtpClosed;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txtTaskName;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
        internal System.Windows.Forms.TabPage tpFiles;
        private System.Windows.Forms.TrackBar trbTaskStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RichTextBox rtbReview;
        internal System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtbAnalysis;
        private System.Windows.Forms.RichTextBox rtbDescription;
    }
}

