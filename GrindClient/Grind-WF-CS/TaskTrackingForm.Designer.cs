namespace Grind_WF_CS
{
    partial class TaskTrackingForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbReview = new System.Windows.Forms.GroupBox();
            this.rtbReview = new System.Windows.Forms.RichTextBox();
            this.gbAnalysis = new System.Windows.Forms.GroupBox();
            this.rtbAnalysis = new System.Windows.Forms.RichTextBox();
            this.gbDescription = new System.Windows.Forms.GroupBox();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.gbTaskTypes = new System.Windows.Forms.GroupBox();
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
            this.gbName = new System.Windows.Forms.GroupBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gbReview.SuspendLayout();
            this.gbAnalysis.SuspendLayout();
            this.gbDescription.SuspendLayout();
            this.gbTaskTypes.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.GroupBox7.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.gbTaskStatus.SuspendLayout();
            this.tlpTaskStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbTaskStatus)).BeginInit();
            this.gbName.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbReview
            // 
            this.gbReview.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbReview.Controls.Add(this.rtbReview);
            this.gbReview.Location = new System.Drawing.Point(579, 671);
            this.gbReview.Name = "gbReview";
            this.gbReview.Size = new System.Drawing.Size(843, 164);
            this.gbReview.TabIndex = 14;
            this.gbReview.TabStop = false;
            this.gbReview.Text = "Review";
            // 
            // rtbReview
            // 
            this.rtbReview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbReview.Location = new System.Drawing.Point(3, 16);
            this.rtbReview.Name = "rtbReview";
            this.rtbReview.Size = new System.Drawing.Size(837, 145);
            this.rtbReview.TabIndex = 0;
            this.rtbReview.Text = "";
            this.rtbReview.TextChanged += new System.EventHandler(this.rtb_TextChanged);
            // 
            // gbAnalysis
            // 
            this.gbAnalysis.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbAnalysis.Controls.Add(this.rtbAnalysis);
            this.gbAnalysis.Location = new System.Drawing.Point(579, 496);
            this.gbAnalysis.Name = "gbAnalysis";
            this.gbAnalysis.Size = new System.Drawing.Size(843, 164);
            this.gbAnalysis.TabIndex = 13;
            this.gbAnalysis.TabStop = false;
            this.gbAnalysis.Text = "Analysis";
            // 
            // rtbAnalysis
            // 
            this.rtbAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbAnalysis.Location = new System.Drawing.Point(3, 16);
            this.rtbAnalysis.Name = "rtbAnalysis";
            this.rtbAnalysis.Size = new System.Drawing.Size(837, 145);
            this.rtbAnalysis.TabIndex = 0;
            this.rtbAnalysis.Text = "";
            this.rtbAnalysis.TextChanged += new System.EventHandler(this.rtb_TextChanged);
            // 
            // gbDescription
            // 
            this.gbDescription.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbDescription.Controls.Add(this.rtbDescription);
            this.gbDescription.Location = new System.Drawing.Point(579, 321);
            this.gbDescription.Name = "gbDescription";
            this.gbDescription.Size = new System.Drawing.Size(843, 164);
            this.gbDescription.TabIndex = 12;
            this.gbDescription.TabStop = false;
            this.gbDescription.Text = "Description";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDescription.Location = new System.Drawing.Point(3, 16);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(837, 145);
            this.rtbDescription.TabIndex = 0;
            this.rtbDescription.Text = "";
            this.rtbDescription.TextChanged += new System.EventHandler(this.rtb_TextChanged);
            // 
            // gbTaskTypes
            // 
            this.gbTaskTypes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbTaskTypes.Controls.Add(this.GroupBox8);
            this.gbTaskTypes.Controls.Add(this.GroupBox7);
            this.gbTaskTypes.Controls.Add(this.GroupBox5);
            this.gbTaskTypes.Controls.Add(this.GroupBox4);
            this.gbTaskTypes.Location = new System.Drawing.Point(579, 214);
            this.gbTaskTypes.Name = "gbTaskTypes";
            this.gbTaskTypes.Size = new System.Drawing.Size(843, 96);
            this.gbTaskTypes.TabIndex = 11;
            this.gbTaskTypes.TabStop = false;
            // 
            // GroupBox8
            // 
            this.GroupBox8.Controls.Add(this.Panel1);
            this.GroupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox8.Location = new System.Drawing.Point(444, 16);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(396, 77);
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
            this.Panel1.Size = new System.Drawing.Size(390, 58);
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
            this.gbTaskStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbTaskStatus.Controls.Add(this.tlpTaskStatus);
            this.gbTaskStatus.Location = new System.Drawing.Point(579, 84);
            this.gbTaskStatus.Name = "gbTaskStatus";
            this.gbTaskStatus.Size = new System.Drawing.Size(843, 119);
            this.gbTaskStatus.TabIndex = 10;
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
            this.tlpTaskStatus.Size = new System.Drawing.Size(837, 100);
            this.tlpTaskStatus.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Open";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(123, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Analysis";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(242, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Review";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(361, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Correction";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(480, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "Promotion";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(599, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "Collection";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(718, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 20);
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
            this.dtpPromotion.Location = new System.Drawing.Point(480, 77);
            this.dtpPromotion.Name = "dtpPromotion";
            this.dtpPromotion.Size = new System.Drawing.Size(112, 20);
            this.dtpPromotion.TabIndex = 13;
            this.dtpPromotion.Tag = "PromotionDate";
            // 
            // dtpCorrection
            // 
            this.dtpCorrection.Checked = false;
            this.dtpCorrection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpCorrection.Enabled = false;
            this.dtpCorrection.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCorrection.Location = new System.Drawing.Point(361, 77);
            this.dtpCorrection.Name = "dtpCorrection";
            this.dtpCorrection.Size = new System.Drawing.Size(112, 20);
            this.dtpCorrection.TabIndex = 12;
            this.dtpCorrection.Tag = "CorrectionDate";
            // 
            // dtpReview
            // 
            this.dtpReview.Checked = false;
            this.dtpReview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpReview.Enabled = false;
            this.dtpReview.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReview.Location = new System.Drawing.Point(242, 77);
            this.dtpReview.Name = "dtpReview";
            this.dtpReview.Size = new System.Drawing.Size(112, 20);
            this.dtpReview.TabIndex = 11;
            this.dtpReview.Tag = "ReviewDate";
            // 
            // dtpAnalysis
            // 
            this.dtpAnalysis.Checked = false;
            this.dtpAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpAnalysis.Enabled = false;
            this.dtpAnalysis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAnalysis.Location = new System.Drawing.Point(123, 77);
            this.dtpAnalysis.Name = "dtpAnalysis";
            this.dtpAnalysis.Size = new System.Drawing.Size(112, 20);
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
            this.dtpOpen.Size = new System.Drawing.Size(112, 20);
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
            this.dtpCollection.Location = new System.Drawing.Point(599, 77);
            this.dtpCollection.Name = "dtpCollection";
            this.dtpCollection.Size = new System.Drawing.Size(112, 20);
            this.dtpCollection.TabIndex = 16;
            this.dtpCollection.Tag = "CollectionDate";
            // 
            // dtpClosed
            // 
            this.dtpClosed.Checked = false;
            this.dtpClosed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpClosed.Enabled = false;
            this.dtpClosed.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpClosed.Location = new System.Drawing.Point(718, 77);
            this.dtpClosed.Name = "dtpClosed";
            this.dtpClosed.Size = new System.Drawing.Size(115, 20);
            this.dtpClosed.TabIndex = 17;
            this.dtpClosed.Tag = "ClosedDate";
            // 
            // trbTaskStatus
            // 
            this.tlpTaskStatus.SetColumnSpan(this.trbTaskStatus, 7);
            this.trbTaskStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trbTaskStatus.LargeChange = 1;
            this.trbTaskStatus.Location = new System.Drawing.Point(51, 25);
            this.trbTaskStatus.Margin = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.trbTaskStatus.Maximum = 6;
            this.trbTaskStatus.Name = "trbTaskStatus";
            this.trbTaskStatus.Size = new System.Drawing.Size(735, 45);
            this.trbTaskStatus.TabIndex = 18;
            this.trbTaskStatus.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trbTaskStatus.ValueChanged += new System.EventHandler(this.trbTaskStatus_ValueChanged);
            // 
            // gbName
            // 
            this.gbName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbName.Controls.Add(this.txtTitle);
            this.gbName.Controls.Add(this.label8);
            this.gbName.Controls.Add(this.txtName);
            this.gbName.Location = new System.Drawing.Point(579, 33);
            this.gbName.Name = "gbName";
            this.gbName.Size = new System.Drawing.Size(843, 40);
            this.gbName.TabIndex = 9;
            this.gbName.TabStop = false;
            this.gbName.Text = "Name";
            // 
            // txtTitle
            // 
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTitle.Location = new System.Drawing.Point(216, 16);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(624, 20);
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
            this.label8.Size = new System.Drawing.Size(32, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "Tiltle:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtName.Location = new System.Drawing.Point(3, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(181, 20);
            this.txtName.TabIndex = 1;
            this.txtName.Tag = "TaskName";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Green;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(2000, 30);
            this.label9.TabIndex = 15;
            this.label9.Text = "Task Tracking Form";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TaskTrackingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.gbReview);
            this.Controls.Add(this.gbAnalysis);
            this.Controls.Add(this.gbDescription);
            this.Controls.Add(this.gbTaskTypes);
            this.Controls.Add(this.gbTaskStatus);
            this.Controls.Add(this.gbName);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(2000, 2000);
            this.MinimumSize = new System.Drawing.Size(880, 0);
            this.Name = "TaskTrackingForm";
            this.Size = new System.Drawing.Size(2000, 1115);
            this.Load += new System.EventHandler(this.TaskTrackingForm_Load);
            this.gbReview.ResumeLayout(false);
            this.gbAnalysis.ResumeLayout(false);
            this.gbDescription.ResumeLayout(false);
            this.gbTaskTypes.ResumeLayout(false);
            this.gbTaskTypes.PerformLayout();
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
            this.gbName.ResumeLayout(false);
            this.gbName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox gbReview;
        private System.Windows.Forms.RichTextBox rtbReview;
        internal System.Windows.Forms.GroupBox gbAnalysis;
        private System.Windows.Forms.RichTextBox rtbAnalysis;
        internal System.Windows.Forms.GroupBox gbDescription;
        private System.Windows.Forms.RichTextBox rtbDescription;
        internal System.Windows.Forms.GroupBox gbTaskTypes;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.DateTimePicker dtpPromotion;
        internal System.Windows.Forms.DateTimePicker dtpCorrection;
        internal System.Windows.Forms.DateTimePicker dtpReview;
        internal System.Windows.Forms.DateTimePicker dtpAnalysis;
        internal System.Windows.Forms.DateTimePicker dtpOpen;
        internal System.Windows.Forms.DateTimePicker dtpCollection;
        internal System.Windows.Forms.DateTimePicker dtpClosed;
        private System.Windows.Forms.TrackBar trbTaskStatus;
        internal System.Windows.Forms.GroupBox gbName;
        internal System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label9;
    }
}
