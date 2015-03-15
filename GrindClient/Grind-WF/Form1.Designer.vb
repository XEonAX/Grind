<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpTask = New System.Windows.Forms.TabPage()
        Me.scTasksMain = New System.Windows.Forms.SplitContainer()
        Me.spTaskListAndForm = New System.Windows.Forms.SplitContainer()
        Me.dGridTasks = New System.Windows.Forms.DataGridView()
        Me.colTaskName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTaskStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTaskType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBugType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTargetDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExecutor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReviewer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colApproved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colModified = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCreated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.conReviewer = New System.Windows.Forms.ComboBox()
        Me.cobExecutor = New System.Windows.Forms.ComboBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.cbApproved = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.rbOthers = New System.Windows.Forms.RadioButton()
        Me.rbCRITSIT = New System.Windows.Forms.RadioButton()
        Me.rbBacklog = New System.Windows.Forms.RadioButton()
        Me.rbHMA = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbHL = New System.Windows.Forms.RadioButton()
        Me.rbBug = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dtpPromotion = New System.Windows.Forms.DateTimePicker()
        Me.bsTask = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpCorrection = New System.Windows.Forms.DateTimePicker()
        Me.dtpReview = New System.Windows.Forms.DateTimePicker()
        Me.dtpAnalysis = New System.Windows.Forms.DateTimePicker()
        Me.rbOpen = New System.Windows.Forms.RadioButton()
        Me.rbAnalysis = New System.Windows.Forms.RadioButton()
        Me.rbReview = New System.Windows.Forms.RadioButton()
        Me.rbCorrection = New System.Windows.Forms.RadioButton()
        Me.rbPromotion = New System.Windows.Forms.RadioButton()
        Me.dtpOpen = New System.Windows.Forms.DateTimePicker()
        Me.dtpCollection = New System.Windows.Forms.DateTimePicker()
        Me.dtpClosed = New System.Windows.Forms.DateTimePicker()
        Me.rbCollection = New System.Windows.Forms.RadioButton()
        Me.rbClosed = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTaskName = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpFiles = New System.Windows.Forms.TabPage()
        Me.TabControl1.SuspendLayout()
        Me.tpTask.SuspendLayout()
        CType(Me.scTasksMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scTasksMain.Panel1.SuspendLayout()
        Me.scTasksMain.SuspendLayout()
        CType(Me.spTaskListAndForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spTaskListAndForm.Panel1.SuspendLayout()
        Me.spTaskListAndForm.Panel2.SuspendLayout()
        Me.spTaskListAndForm.SuspendLayout()
        CType(Me.dGridTasks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.bsTask, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpTask)
        Me.TabControl1.Controls.Add(Me.tpFiles)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.HotTrack = True
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1029, 497)
        Me.TabControl1.TabIndex = 0
        '
        'tpTask
        '
        Me.tpTask.Controls.Add(Me.scTasksMain)
        Me.tpTask.Location = New System.Drawing.Point(4, 22)
        Me.tpTask.Name = "tpTask"
        Me.tpTask.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTask.Size = New System.Drawing.Size(1021, 471)
        Me.tpTask.TabIndex = 1
        Me.tpTask.Text = "Tasks"
        Me.tpTask.UseVisualStyleBackColor = True
        '
        'scTasksMain
        '
        Me.scTasksMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scTasksMain.Location = New System.Drawing.Point(3, 3)
        Me.scTasksMain.Name = "scTasksMain"
        '
        'scTasksMain.Panel1
        '
        Me.scTasksMain.Panel1.Controls.Add(Me.spTaskListAndForm)
        Me.scTasksMain.Panel1.Controls.Add(Me.MenuStrip1)
        Me.scTasksMain.Panel2MinSize = 80
        Me.scTasksMain.Size = New System.Drawing.Size(1015, 465)
        Me.scTasksMain.SplitterDistance = 898
        Me.scTasksMain.TabIndex = 0
        '
        'spTaskListAndForm
        '
        Me.spTaskListAndForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spTaskListAndForm.Location = New System.Drawing.Point(0, 24)
        Me.spTaskListAndForm.Name = "spTaskListAndForm"
        Me.spTaskListAndForm.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spTaskListAndForm.Panel1
        '
        Me.spTaskListAndForm.Panel1.Controls.Add(Me.dGridTasks)
        '
        'spTaskListAndForm.Panel2
        '
        Me.spTaskListAndForm.Panel2.AutoScroll = True
        Me.spTaskListAndForm.Panel2.Controls.Add(Me.GroupBox6)
        Me.spTaskListAndForm.Panel2.Controls.Add(Me.GroupBox3)
        Me.spTaskListAndForm.Panel2.Controls.Add(Me.GroupBox2)
        Me.spTaskListAndForm.Panel2.Controls.Add(Me.GroupBox1)
        Me.spTaskListAndForm.Panel2.Controls.Add(Me.TextBox1)
        Me.spTaskListAndForm.Size = New System.Drawing.Size(898, 441)
        Me.spTaskListAndForm.SplitterDistance = 247
        Me.spTaskListAndForm.TabIndex = 0
        '
        'dGridTasks
        '
        Me.dGridTasks.AllowUserToAddRows = False
        Me.dGridTasks.AllowUserToDeleteRows = False
        Me.dGridTasks.AllowUserToResizeRows = False
        Me.dGridTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dGridTasks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dGridTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dGridTasks.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTaskName, Me.colTaskStatus, Me.colTaskType, Me.colBugType, Me.colTargetDate, Me.colExecutor, Me.colReviewer, Me.colApproved, Me.colModified, Me.colCreated})
        Me.dGridTasks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridTasks.Location = New System.Drawing.Point(0, 0)
        Me.dGridTasks.Name = "dGridTasks"
        Me.dGridTasks.ReadOnly = True
        Me.dGridTasks.RowHeadersVisible = False
        Me.dGridTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dGridTasks.Size = New System.Drawing.Size(898, 247)
        Me.dGridTasks.TabIndex = 1
        '
        'colTaskName
        '
        Me.colTaskName.DataPropertyName = "Name"
        Me.colTaskName.FillWeight = 40.0!
        Me.colTaskName.HeaderText = "Task Name"
        Me.colTaskName.Name = "colTaskName"
        Me.colTaskName.ReadOnly = True
        '
        'colTaskStatus
        '
        Me.colTaskStatus.DataPropertyName = "TaskStatus"
        Me.colTaskStatus.FillWeight = 15.0!
        Me.colTaskStatus.HeaderText = "Task Status"
        Me.colTaskStatus.Name = "colTaskStatus"
        Me.colTaskStatus.ReadOnly = True
        '
        'colTaskType
        '
        Me.colTaskType.DataPropertyName = "TaskType"
        Me.colTaskType.FillWeight = 15.0!
        Me.colTaskType.HeaderText = "Task Type"
        Me.colTaskType.Name = "colTaskType"
        Me.colTaskType.ReadOnly = True
        '
        'colBugType
        '
        Me.colBugType.DataPropertyName = "BugType"
        Me.colBugType.FillWeight = 10.0!
        Me.colBugType.HeaderText = "Bug Type"
        Me.colBugType.Name = "colBugType"
        Me.colBugType.ReadOnly = True
        '
        'colTargetDate
        '
        Me.colTargetDate.DataPropertyName = "TargetDate"
        Me.colTargetDate.FillWeight = 15.0!
        Me.colTargetDate.HeaderText = "Target Date"
        Me.colTargetDate.Name = "colTargetDate"
        Me.colTargetDate.ReadOnly = True
        '
        'colExecutor
        '
        Me.colExecutor.DataPropertyName = "DeveloperName"
        Me.colExecutor.FillWeight = 20.0!
        Me.colExecutor.HeaderText = "Executor"
        Me.colExecutor.Name = "colExecutor"
        Me.colExecutor.ReadOnly = True
        '
        'colReviewer
        '
        Me.colReviewer.DataPropertyName = "ReviewerName"
        Me.colReviewer.FillWeight = 20.0!
        Me.colReviewer.HeaderText = "Reviewer"
        Me.colReviewer.Name = "colReviewer"
        Me.colReviewer.ReadOnly = True
        '
        'colApproved
        '
        Me.colApproved.DataPropertyName = "Approved"
        Me.colApproved.FillWeight = 10.0!
        Me.colApproved.HeaderText = "Approved"
        Me.colApproved.Name = "colApproved"
        Me.colApproved.ReadOnly = True
        Me.colApproved.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colApproved.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colModified
        '
        Me.colModified.DataPropertyName = "UpdatedAt"
        Me.colModified.FillWeight = 10.0!
        Me.colModified.HeaderText = "Modified"
        Me.colModified.Name = "colModified"
        Me.colModified.ReadOnly = True
        '
        'colCreated
        '
        Me.colCreated.DataPropertyName = "CreatedAt"
        Me.colCreated.FillWeight = 10.0!
        Me.colCreated.HeaderText = "Created"
        Me.colCreated.Name = "colCreated"
        Me.colCreated.ReadOnly = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Location = New System.Drawing.Point(49, 401)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(417, 100)
        Me.GroupBox6.TabIndex = 5
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "GroupBox6"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox8)
        Me.GroupBox3.Controls.Add(Me.GroupBox7)
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 155)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(881, 67)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Panel1)
        Me.GroupBox8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox8.Location = New System.Drawing.Point(444, 16)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(434, 48)
        Me.GroupBox8.TabIndex = 3
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Concerned Persons"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.conReviewer)
        Me.Panel1.Controls.Add(Me.cobExecutor)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(428, 29)
        Me.Panel1.TabIndex = 0
        '
        'conReviewer
        '
        Me.conReviewer.Dock = System.Windows.Forms.DockStyle.Left
        Me.conReviewer.FormattingEnabled = True
        Me.conReviewer.Items.AddRange(New Object() {"Reviewer", "-------------------------"})
        Me.conReviewer.Location = New System.Drawing.Point(144, 0)
        Me.conReviewer.Name = "conReviewer"
        Me.conReviewer.Size = New System.Drawing.Size(144, 21)
        Me.conReviewer.TabIndex = 1
        '
        'cobExecutor
        '
        Me.cobExecutor.Dock = System.Windows.Forms.DockStyle.Left
        Me.cobExecutor.FormattingEnabled = True
        Me.cobExecutor.Items.AddRange(New Object() {"Executor", "-------------------------"})
        Me.cobExecutor.Location = New System.Drawing.Point(0, 0)
        Me.cobExecutor.Name = "cobExecutor"
        Me.cobExecutor.Size = New System.Drawing.Size(144, 21)
        Me.cobExecutor.TabIndex = 0
        '
        'GroupBox7
        '
        Me.GroupBox7.AutoSize = True
        Me.GroupBox7.Controls.Add(Me.cbApproved)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox7.Location = New System.Drawing.Point(334, 16)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(110, 48)
        Me.GroupBox7.TabIndex = 2
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Approval"
        '
        'cbApproved
        '
        Me.cbApproved.AutoSize = True
        Me.cbApproved.Dock = System.Windows.Forms.DockStyle.Left
        Me.cbApproved.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbApproved.Location = New System.Drawing.Point(3, 16)
        Me.cbApproved.Name = "cbApproved"
        Me.cbApproved.Size = New System.Drawing.Size(104, 29)
        Me.cbApproved.TabIndex = 0
        Me.cbApproved.Tag = "Approved"
        Me.cbApproved.Text = "Approved"
        Me.cbApproved.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.AutoSize = True
        Me.GroupBox5.Controls.Add(Me.rbOthers)
        Me.GroupBox5.Controls.Add(Me.rbCRITSIT)
        Me.GroupBox5.Controls.Add(Me.rbBacklog)
        Me.GroupBox5.Controls.Add(Me.rbHMA)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox5.Location = New System.Drawing.Point(92, 16)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(242, 48)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "BugType"
        '
        'rbOthers
        '
        Me.rbOthers.AutoSize = True
        Me.rbOthers.Dock = System.Windows.Forms.DockStyle.Left
        Me.rbOthers.Location = New System.Drawing.Point(183, 16)
        Me.rbOthers.Name = "rbOthers"
        Me.rbOthers.Size = New System.Drawing.Size(56, 29)
        Me.rbOthers.TabIndex = 3
        Me.rbOthers.TabStop = True
        Me.rbOthers.Tag = "Others"
        Me.rbOthers.Text = "Others"
        Me.rbOthers.UseVisualStyleBackColor = True
        '
        'rbCRITSIT
        '
        Me.rbCRITSIT.AutoSize = True
        Me.rbCRITSIT.Dock = System.Windows.Forms.DockStyle.Left
        Me.rbCRITSIT.Location = New System.Drawing.Point(116, 16)
        Me.rbCRITSIT.Name = "rbCRITSIT"
        Me.rbCRITSIT.Size = New System.Drawing.Size(67, 29)
        Me.rbCRITSIT.TabIndex = 2
        Me.rbCRITSIT.TabStop = True
        Me.rbCRITSIT.Tag = "CRITSIT"
        Me.rbCRITSIT.Text = "CRITSIT"
        Me.rbCRITSIT.UseVisualStyleBackColor = True
        '
        'rbBacklog
        '
        Me.rbBacklog.AutoSize = True
        Me.rbBacklog.Dock = System.Windows.Forms.DockStyle.Left
        Me.rbBacklog.Location = New System.Drawing.Point(52, 16)
        Me.rbBacklog.Name = "rbBacklog"
        Me.rbBacklog.Size = New System.Drawing.Size(64, 29)
        Me.rbBacklog.TabIndex = 1
        Me.rbBacklog.TabStop = True
        Me.rbBacklog.Tag = "Backlog"
        Me.rbBacklog.Text = "Backlog"
        Me.rbBacklog.UseVisualStyleBackColor = True
        '
        'rbHMA
        '
        Me.rbHMA.AutoSize = True
        Me.rbHMA.Dock = System.Windows.Forms.DockStyle.Left
        Me.rbHMA.Location = New System.Drawing.Point(3, 16)
        Me.rbHMA.Name = "rbHMA"
        Me.rbHMA.Size = New System.Drawing.Size(49, 29)
        Me.rbHMA.TabIndex = 0
        Me.rbHMA.TabStop = True
        Me.rbHMA.Tag = "HMA"
        Me.rbHMA.Text = "HMA"
        Me.rbHMA.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.AutoSize = True
        Me.GroupBox4.Controls.Add(Me.rbHL)
        Me.GroupBox4.Controls.Add(Me.rbBug)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox4.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(89, 48)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Task Type"
        '
        'rbHL
        '
        Me.rbHL.AutoSize = True
        Me.rbHL.Dock = System.Windows.Forms.DockStyle.Left
        Me.rbHL.Location = New System.Drawing.Point(47, 16)
        Me.rbHL.Name = "rbHL"
        Me.rbHL.Size = New System.Drawing.Size(39, 29)
        Me.rbHL.TabIndex = 1
        Me.rbHL.TabStop = True
        Me.rbHL.Tag = "HL"
        Me.rbHL.Text = "HL"
        Me.rbHL.UseVisualStyleBackColor = True
        '
        'rbBug
        '
        Me.rbBug.AutoSize = True
        Me.rbBug.Dock = System.Windows.Forms.DockStyle.Left
        Me.rbBug.Location = New System.Drawing.Point(3, 16)
        Me.rbBug.Name = "rbBug"
        Me.rbBug.Size = New System.Drawing.Size(44, 29)
        Me.rbBug.TabIndex = 0
        Me.rbBug.TabStop = True
        Me.rbBug.Tag = "Bug"
        Me.rbBug.Text = "Bug"
        Me.rbBug.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 73)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(881, 82)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Task Status"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.Controls.Add(Me.dtpPromotion, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpCorrection, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpReview, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpAnalysis, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.rbOpen, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rbAnalysis, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rbReview, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rbCorrection, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rbPromotion, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpOpen, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpCollection, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpClosed, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.rbCollection, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rbClosed, 6, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(875, 63)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'dtpPromotion
        '
        Me.dtpPromotion.Checked = False
        Me.dtpPromotion.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.bsTask, "PromotionDate", True))
        Me.dtpPromotion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpPromotion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPromotion.Location = New System.Drawing.Point(500, 31)
        Me.dtpPromotion.Name = "dtpPromotion"
        Me.dtpPromotion.Size = New System.Drawing.Size(117, 20)
        Me.dtpPromotion.TabIndex = 13
        Me.dtpPromotion.Tag = "PromotionDate"
        '
        'bsTask
        '
        Me.bsTask.DataSource = GetType(Task)
        '
        'dtpCorrection
        '
        Me.dtpCorrection.Checked = False
        Me.dtpCorrection.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.bsTask, "CollectionDate", True))
        Me.dtpCorrection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpCorrection.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCorrection.Location = New System.Drawing.Point(376, 31)
        Me.dtpCorrection.Name = "dtpCorrection"
        Me.dtpCorrection.Size = New System.Drawing.Size(117, 20)
        Me.dtpCorrection.TabIndex = 12
        Me.dtpCorrection.Tag = "CorrectionDate"
        '
        'dtpReview
        '
        Me.dtpReview.Checked = False
        Me.dtpReview.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.bsTask, "ReviewDate", True))
        Me.dtpReview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpReview.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReview.Location = New System.Drawing.Point(252, 31)
        Me.dtpReview.Name = "dtpReview"
        Me.dtpReview.Size = New System.Drawing.Size(117, 20)
        Me.dtpReview.TabIndex = 11
        Me.dtpReview.Tag = "ReviewDate"
        '
        'dtpAnalysis
        '
        Me.dtpAnalysis.Checked = False
        Me.dtpAnalysis.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.bsTask, "AnalysisDate", True))
        Me.dtpAnalysis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpAnalysis.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAnalysis.Location = New System.Drawing.Point(128, 31)
        Me.dtpAnalysis.Name = "dtpAnalysis"
        Me.dtpAnalysis.Size = New System.Drawing.Size(117, 20)
        Me.dtpAnalysis.TabIndex = 10
        Me.dtpAnalysis.Tag = "AnalysisDate"
        '
        'rbOpen
        '
        Me.rbOpen.AutoSize = True
        Me.rbOpen.Location = New System.Drawing.Point(4, 4)
        Me.rbOpen.Name = "rbOpen"
        Me.rbOpen.Size = New System.Drawing.Size(51, 17)
        Me.rbOpen.TabIndex = 2
        Me.rbOpen.TabStop = True
        Me.rbOpen.Tag = "Open"
        Me.rbOpen.Text = "Open"
        Me.rbOpen.UseVisualStyleBackColor = True
        '
        'rbAnalysis
        '
        Me.rbAnalysis.AutoSize = True
        Me.rbAnalysis.Location = New System.Drawing.Point(128, 4)
        Me.rbAnalysis.Name = "rbAnalysis"
        Me.rbAnalysis.Size = New System.Drawing.Size(63, 17)
        Me.rbAnalysis.TabIndex = 4
        Me.rbAnalysis.TabStop = True
        Me.rbAnalysis.Tag = "Analysis"
        Me.rbAnalysis.Text = "Analysis"
        Me.rbAnalysis.UseVisualStyleBackColor = True
        '
        'rbReview
        '
        Me.rbReview.AutoSize = True
        Me.rbReview.Location = New System.Drawing.Point(252, 4)
        Me.rbReview.Name = "rbReview"
        Me.rbReview.Size = New System.Drawing.Size(61, 17)
        Me.rbReview.TabIndex = 6
        Me.rbReview.TabStop = True
        Me.rbReview.Tag = "Review"
        Me.rbReview.Text = "Review"
        Me.rbReview.UseVisualStyleBackColor = True
        '
        'rbCorrection
        '
        Me.rbCorrection.AutoSize = True
        Me.rbCorrection.Location = New System.Drawing.Point(376, 4)
        Me.rbCorrection.Name = "rbCorrection"
        Me.rbCorrection.Size = New System.Drawing.Size(73, 17)
        Me.rbCorrection.TabIndex = 7
        Me.rbCorrection.TabStop = True
        Me.rbCorrection.Tag = "Correction"
        Me.rbCorrection.Text = "Correction"
        Me.rbCorrection.UseVisualStyleBackColor = True
        '
        'rbPromotion
        '
        Me.rbPromotion.AutoSize = True
        Me.rbPromotion.Location = New System.Drawing.Point(500, 4)
        Me.rbPromotion.Name = "rbPromotion"
        Me.rbPromotion.Size = New System.Drawing.Size(72, 17)
        Me.rbPromotion.TabIndex = 8
        Me.rbPromotion.TabStop = True
        Me.rbPromotion.Tag = "Promotion"
        Me.rbPromotion.Text = "Promotion"
        Me.rbPromotion.UseVisualStyleBackColor = True
        '
        'dtpOpen
        '
        Me.dtpOpen.Checked = False
        Me.dtpOpen.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.bsTask, "OpenDate", True))
        Me.dtpOpen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpOpen.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpOpen.Location = New System.Drawing.Point(4, 31)
        Me.dtpOpen.Name = "dtpOpen"
        Me.dtpOpen.Size = New System.Drawing.Size(117, 20)
        Me.dtpOpen.TabIndex = 9
        Me.dtpOpen.Tag = "OpenDate"
        Me.dtpOpen.Value = New Date(2015, 1, 1, 0, 0, 0, 0)
        '
        'dtpCollection
        '
        Me.dtpCollection.Checked = False
        Me.dtpCollection.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.bsTask, "CollectionDate", True))
        Me.dtpCollection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpCollection.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCollection.Location = New System.Drawing.Point(624, 31)
        Me.dtpCollection.Name = "dtpCollection"
        Me.dtpCollection.Size = New System.Drawing.Size(117, 20)
        Me.dtpCollection.TabIndex = 16
        Me.dtpCollection.Tag = "CollectionDate"
        '
        'dtpClosed
        '
        Me.dtpClosed.Checked = False
        Me.dtpClosed.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.bsTask, "ClosedDate", True))
        Me.dtpClosed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpClosed.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpClosed.Location = New System.Drawing.Point(748, 31)
        Me.dtpClosed.Name = "dtpClosed"
        Me.dtpClosed.Size = New System.Drawing.Size(123, 20)
        Me.dtpClosed.TabIndex = 17
        Me.dtpClosed.Tag = "ClosedDate"
        '
        'rbCollection
        '
        Me.rbCollection.AutoSize = True
        Me.rbCollection.Location = New System.Drawing.Point(624, 4)
        Me.rbCollection.Name = "rbCollection"
        Me.rbCollection.Size = New System.Drawing.Size(71, 17)
        Me.rbCollection.TabIndex = 14
        Me.rbCollection.TabStop = True
        Me.rbCollection.Tag = "Collection"
        Me.rbCollection.Text = "Collection"
        Me.rbCollection.UseVisualStyleBackColor = True
        '
        'rbClosed
        '
        Me.rbClosed.AutoSize = True
        Me.rbClosed.Location = New System.Drawing.Point(748, 4)
        Me.rbClosed.Name = "rbClosed"
        Me.rbClosed.Size = New System.Drawing.Size(57, 17)
        Me.rbClosed.TabIndex = 15
        Me.rbClosed.TabStop = True
        Me.rbClosed.Tag = "Closed"
        Me.rbClosed.Text = "Closed"
        Me.rbClosed.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTaskName)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(881, 46)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Name"
        '
        'txtTaskName
        '
        Me.txtTaskName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsTask, "TaskName", True))
        Me.txtTaskName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTaskName.Location = New System.Drawing.Point(3, 16)
        Me.txtTaskName.Name = "txtTaskName"
        Me.txtTaskName.Size = New System.Drawing.Size(875, 20)
        Me.txtTaskName.TabIndex = 1
        Me.txtTaskName.Tag = "TaskName"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.ForestGreen
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(0, 0)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(881, 27)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "TaskTracking Form"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.RefreshToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(898, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = Global.Grind.WF.VB.My.Resources.Resources._112_Plus_Green_16x16_72
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(59, 20)
        Me.ToolStripMenuItem1.Text = "New"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Image = Global.Grind.WF.VB.My.Resources.Resources._112_RefreshArrow_Blue_16x16_72
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(74, 20)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'tpFiles
        '
        Me.tpFiles.Location = New System.Drawing.Point(4, 22)
        Me.tpFiles.Name = "tpFiles"
        Me.tpFiles.Padding = New System.Windows.Forms.Padding(3)
        Me.tpFiles.Size = New System.Drawing.Size(1021, 471)
        Me.tpFiles.TabIndex = 0
        Me.tpFiles.Text = "Files"
        Me.tpFiles.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1029, 497)
        Me.Controls.Add(Me.TabControl1)
        Me.DoubleBuffered = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.TabControl1.ResumeLayout(False)
        Me.tpTask.ResumeLayout(False)
        Me.scTasksMain.Panel1.ResumeLayout(False)
        Me.scTasksMain.Panel1.PerformLayout()
        CType(Me.scTasksMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scTasksMain.ResumeLayout(False)
        Me.spTaskListAndForm.Panel1.ResumeLayout(False)
        Me.spTaskListAndForm.Panel2.ResumeLayout(False)
        Me.spTaskListAndForm.Panel2.PerformLayout()
        CType(Me.spTaskListAndForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spTaskListAndForm.ResumeLayout(False)
        CType(Me.dGridTasks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.bsTask, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpFiles As System.Windows.Forms.TabPage
    Friend WithEvents tpTask As System.Windows.Forms.TabPage
    Friend WithEvents scTasksMain As System.Windows.Forms.SplitContainer
    Friend WithEvents spTaskListAndForm As System.Windows.Forms.SplitContainer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dGridTasks As System.Windows.Forms.DataGridView
    Friend WithEvents colTaskName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTaskStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTaskType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBugType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTargetDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExecutor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReviewer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colApproved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colModified As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCreated As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dtpPromotion As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpCorrection As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpReview As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpAnalysis As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbOpen As System.Windows.Forms.RadioButton
    Friend WithEvents rbAnalysis As System.Windows.Forms.RadioButton
    Friend WithEvents rbReview As System.Windows.Forms.RadioButton
    Friend WithEvents rbCorrection As System.Windows.Forms.RadioButton
    Friend WithEvents rbPromotion As System.Windows.Forms.RadioButton
    Friend WithEvents dtpOpen As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpCollection As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpClosed As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbCollection As System.Windows.Forms.RadioButton
    Friend WithEvents rbClosed As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTaskName As System.Windows.Forms.TextBox
    Friend WithEvents bsTask As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents conReviewer As System.Windows.Forms.ComboBox
    Friend WithEvents cobExecutor As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cbApproved As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents rbOthers As System.Windows.Forms.RadioButton
    Friend WithEvents rbCRITSIT As System.Windows.Forms.RadioButton
    Friend WithEvents rbBacklog As System.Windows.Forms.RadioButton
    Friend WithEvents rbHMA As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbHL As System.Windows.Forms.RadioButton
    Friend WithEvents rbBug As System.Windows.Forms.RadioButton

End Class
