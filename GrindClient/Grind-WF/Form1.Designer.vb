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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpFiles = New System.Windows.Forms.TabPage()
        Me.tpTask = New System.Windows.Forms.TabPage()
        Me.scTasksMain = New System.Windows.Forms.SplitContainer()
        Me.spTaskListAndForm = New System.Windows.Forms.SplitContainer()
        Me.GridTasks = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.colTaskName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTaskStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTaskType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBugType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTargetDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExecutor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReviewer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colApproved = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colModified = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCreated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1.SuspendLayout()
        Me.tpTask.SuspendLayout()
        CType(Me.scTasksMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scTasksMain.Panel1.SuspendLayout()
        Me.scTasksMain.SuspendLayout()
        CType(Me.spTaskListAndForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spTaskListAndForm.Panel1.SuspendLayout()
        Me.spTaskListAndForm.SuspendLayout()
        CType(Me.GridTasks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpFiles)
        Me.TabControl1.Controls.Add(Me.tpTask)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.HotTrack = True
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1029, 497)
        Me.TabControl1.TabIndex = 0
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
        Me.scTasksMain.SplitterDistance = 899
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
        Me.spTaskListAndForm.Panel1.Controls.Add(Me.GridTasks)
        Me.spTaskListAndForm.Size = New System.Drawing.Size(899, 441)
        Me.spTaskListAndForm.SplitterDistance = 247
        Me.spTaskListAndForm.TabIndex = 0
        '
        'GridTasks
        '
        Me.GridTasks.AllowUserToAddRows = False
        Me.GridTasks.AllowUserToDeleteRows = False
        Me.GridTasks.AllowUserToResizeRows = False
        Me.GridTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridTasks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.GridTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridTasks.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTaskName, Me.colTaskStatus, Me.colTaskType, Me.colBugType, Me.colTargetDate, Me.colExecutor, Me.colReviewer, Me.colApproved, Me.colModified, Me.colCreated})
        Me.GridTasks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridTasks.Location = New System.Drawing.Point(0, 0)
        Me.GridTasks.Name = "GridTasks"
        Me.GridTasks.ReadOnly = True
        Me.GridTasks.RowHeadersVisible = False
        Me.GridTasks.Size = New System.Drawing.Size(899, 247)
        Me.GridTasks.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.RefreshToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(899, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = Global.Grind_WF.My.Resources.Resources._112_Plus_Green_16x16_72
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(59, 20)
        Me.ToolStripMenuItem1.Text = "New"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Image = Global.Grind_WF.My.Resources.Resources._112_RefreshArrow_Blue_16x16_72
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(74, 20)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
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
        Me.colExecutor.DataPropertyName = "Developer"
        Me.colExecutor.FillWeight = 20.0!
        Me.colExecutor.HeaderText = "Executor"
        Me.colExecutor.Name = "colExecutor"
        Me.colExecutor.ReadOnly = True
        '
        'colReviewer
        '
        Me.colReviewer.DataPropertyName = "Reviewer"
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1029, 497)
        Me.Controls.Add(Me.TabControl1)
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
        CType(Me.spTaskListAndForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spTaskListAndForm.ResumeLayout(False)
        CType(Me.GridTasks, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents GridTasks As System.Windows.Forms.DataGridView
    Friend WithEvents colTaskName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTaskStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTaskType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBugType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTargetDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExecutor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReviewer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colApproved As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colModified As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCreated As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
