namespace Grind.Winforms.CSharp
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
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tpFiles = new System.Windows.Forms.TabPage();
            this.tpUsers = new System.Windows.Forms.TabPage();
            this.ttfrmControl = new Grind.Winforms.CSharp.TaskTrackingForm();
            this.grindUserMaintenence1 = new Grind.Winforms.CSharp.GrindUserMaintenence();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaskStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaskType = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colBugType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTargetDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExecutor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReviewer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApproved = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.MenuStrip1.SuspendLayout();
            this.tpUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.tpTask);
            this.TabControl1.Controls.Add(this.tpFiles);
            this.TabControl1.Controls.Add(this.tpUsers);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.HotTrack = true;
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(1342, 750);
            this.TabControl1.TabIndex = 1;
            // 
            // tpTask
            // 
            this.tpTask.Controls.Add(this.scTasksMain);
            this.tpTask.Location = new System.Drawing.Point(4, 22);
            this.tpTask.Name = "tpTask";
            this.tpTask.Padding = new System.Windows.Forms.Padding(3);
            this.tpTask.Size = new System.Drawing.Size(1334, 724);
            this.tpTask.TabIndex = 1;
            this.tpTask.Text = "Tasks";
            this.tpTask.UseVisualStyleBackColor = true;
            // 
            // scTasksMain
            // 
            this.scTasksMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scTasksMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scTasksMain.Location = new System.Drawing.Point(3, 3);
            this.scTasksMain.Name = "scTasksMain";
            // 
            // scTasksMain.Panel1
            // 
            this.scTasksMain.Panel1.Controls.Add(this.spTaskListAndForm);
            this.scTasksMain.Panel1.Controls.Add(this.MenuStrip1);
            this.scTasksMain.Panel1MinSize = 880;
            this.scTasksMain.Panel2MinSize = 80;
            this.scTasksMain.Size = new System.Drawing.Size(1328, 718);
            this.scTasksMain.SplitterDistance = 1194;
            this.scTasksMain.TabIndex = 0;
            // 
            // spTaskListAndForm
            // 
            this.spTaskListAndForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spTaskListAndForm.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
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
            this.spTaskListAndForm.Panel2.Controls.Add(this.ttfrmControl);
            this.spTaskListAndForm.Size = new System.Drawing.Size(1194, 694);
            this.spTaskListAndForm.SplitterDistance = 193;
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
            this.colId,
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
            this.dGridTasks.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dGridTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGridTasks.Size = new System.Drawing.Size(1194, 193);
            this.dGridTasks.TabIndex = 1;
            this.dGridTasks.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dGridTasks_RowCountChanged);
            this.dGridTasks.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dGridTasks_RowCountChanged);
            this.dGridTasks.SelectionChanged += new System.EventHandler(this.dGridTasks_SelectionChanged);
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRefresh,
            this.tsmiNew,
            this.tsmiUpdate});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(1194, 24);
            this.MenuStrip1.TabIndex = 1;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // tsmiRefresh
            // 
            this.tsmiRefresh.Name = "tsmiRefresh";
            this.tsmiRefresh.Size = new System.Drawing.Size(58, 20);
            this.tsmiRefresh.Text = "Refresh";
            this.tsmiRefresh.Click += new System.EventHandler(this.tsmiRefresh_Click);
            // 
            // tsmiNew
            // 
            this.tsmiNew.Name = "tsmiNew";
            this.tsmiNew.Size = new System.Drawing.Size(43, 20);
            this.tsmiNew.Text = "New";
            this.tsmiNew.Click += new System.EventHandler(this.tsmiNew_Click);
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(57, 20);
            this.tsmiUpdate.Text = "Update";
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tpFiles
            // 
            this.tpFiles.Location = new System.Drawing.Point(4, 22);
            this.tpFiles.Name = "tpFiles";
            this.tpFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tpFiles.Size = new System.Drawing.Size(1334, 724);
            this.tpFiles.TabIndex = 0;
            this.tpFiles.Text = "Files";
            this.tpFiles.UseVisualStyleBackColor = true;
            // 
            // tpUsers
            // 
            this.tpUsers.Controls.Add(this.grindUserMaintenence1);
            this.tpUsers.Location = new System.Drawing.Point(4, 22);
            this.tpUsers.Name = "tpUsers";
            this.tpUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tpUsers.Size = new System.Drawing.Size(1334, 724);
            this.tpUsers.TabIndex = 2;
            this.tpUsers.Text = "Users";
            this.tpUsers.UseVisualStyleBackColor = true;
            // 
            // ttfrmControl
            // 
            this.ttfrmControl.AutoScroll = true;
            this.ttfrmControl.AutoSize = true;
            this.ttfrmControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ttfrmControl.Location = new System.Drawing.Point(0, 0);
            this.ttfrmControl.MaximumSize = new System.Drawing.Size(2000, 2000);
            this.ttfrmControl.MinimumSize = new System.Drawing.Size(880, 0);
            this.ttfrmControl.Name = "ttfrmControl";
            this.ttfrmControl.Size = new System.Drawing.Size(1194, 497);
            this.ttfrmControl.TabIndex = 0;
            // 
            // grindUserMaintenence1
            // 
            this.grindUserMaintenence1.Location = new System.Drawing.Point(87, 24);
            this.grindUserMaintenence1.Name = "grindUserMaintenence1";
            this.grindUserMaintenence1.Size = new System.Drawing.Size(298, 420);
            this.grindUserMaintenence1.TabIndex = 22;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colTaskName
            // 
            this.colTaskName.DataPropertyName = "taskName";
            this.colTaskName.FillWeight = 30F;
            this.colTaskName.HeaderText = "Task Name";
            this.colTaskName.Name = "colTaskName";
            this.colTaskName.ReadOnly = true;
            // 
            // colTaskStatus
            // 
            this.colTaskStatus.DataPropertyName = "task_status";
            this.colTaskStatus.FillWeight = 15F;
            this.colTaskStatus.HeaderText = "Task Status";
            this.colTaskStatus.Name = "colTaskStatus";
            this.colTaskStatus.ReadOnly = true;
            // 
            // colTaskType
            // 
            this.colTaskType.DataPropertyName = "is_bug";
            this.colTaskType.FillWeight = 10F;
            this.colTaskType.HeaderText = "Is Bug";
            this.colTaskType.Name = "colTaskType";
            this.colTaskType.ReadOnly = true;
            this.colTaskType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTaskType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colBugType
            // 
            this.colBugType.DataPropertyName = "bug_type";
            this.colBugType.FillWeight = 10F;
            this.colBugType.HeaderText = "Bug Type";
            this.colBugType.Name = "colBugType";
            this.colBugType.ReadOnly = true;
            // 
            // colTargetDate
            // 
            this.colTargetDate.DataPropertyName = "target_date";
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
            this.colApproved.DataPropertyName = "approved";
            this.colApproved.FillWeight = 10F;
            this.colApproved.HeaderText = "Approved";
            this.colApproved.Name = "colApproved";
            this.colApproved.ReadOnly = true;
            this.colApproved.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colApproved.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colModified
            // 
            this.colModified.DataPropertyName = "updated_at";
            this.colModified.FillWeight = 10F;
            this.colModified.HeaderText = "Modified";
            this.colModified.Name = "colModified";
            this.colModified.ReadOnly = true;
            // 
            // colCreated
            // 
            this.colCreated.DataPropertyName = "created_at";
            this.colCreated.FillWeight = 10F;
            this.colCreated.HeaderText = "Created";
            this.colCreated.Name = "colCreated";
            this.colCreated.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 750);
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
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.tpUsers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage tpTask;
        internal System.Windows.Forms.SplitContainer scTasksMain;
        internal System.Windows.Forms.SplitContainer spTaskListAndForm;
        internal System.Windows.Forms.DataGridView dGridTasks;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem tsmiNew;
        internal System.Windows.Forms.ToolStripMenuItem tsmiRefresh;
        internal System.Windows.Forms.TabPage tpFiles;
        private System.Windows.Forms.TabPage tpUsers;
        private GrindUserMaintenence grindUserMaintenence1;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private TaskTrackingForm ttfrmControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaskStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colTaskType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBugType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTargetDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExecutor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReviewer;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colApproved;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModified;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreated;
    }
}

