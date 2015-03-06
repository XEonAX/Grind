namespace Grind_WF_CS
{
    partial class PersonAdded
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtTrigram = new System.Windows.Forms.TextBox();
            this.txtIntObjId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.dupLevel = new System.Windows.Forms.DomainUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(144, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(134, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtTrigram
            // 
            this.txtTrigram.Location = new System.Drawing.Point(144, 38);
            this.txtTrigram.Name = "txtTrigram";
            this.txtTrigram.Size = new System.Drawing.Size(134, 20);
            this.txtTrigram.TabIndex = 1;
            // 
            // txtIntObjId
            // 
            this.txtIntObjId.Location = new System.Drawing.Point(144, 64);
            this.txtIntObjId.Name = "txtIntObjId";
            this.txtIntObjId.Size = new System.Drawing.Size(134, 20);
            this.txtIntObjId.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Trigram";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Internal Object Id";
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(15, 91);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(56, 17);
            this.cbActive.TabIndex = 8;
            this.cbActive.Text = "Active";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // dupLevel
            // 
            this.dupLevel.Items.Add("Master");
            this.dupLevel.Items.Add("Admin");
            this.dupLevel.Items.Add("User");
            this.dupLevel.Items.Add("Viewer");
            this.dupLevel.Location = new System.Drawing.Point(144, 90);
            this.dupLevel.Name = "dupLevel";
            this.dupLevel.Size = new System.Drawing.Size(134, 20);
            this.dupLevel.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(13, 117);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // PersonAdded
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 152);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dupLevel);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIntObjId);
            this.Controls.Add(this.txtTrigram);
            this.Controls.Add(this.txtName);
            this.Name = "PersonAdded";
            this.Text = "PersonAdded";
            this.Load += new System.EventHandler(this.PersonAdded_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtTrigram;
        private System.Windows.Forms.TextBox txtIntObjId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.DomainUpDown dupLevel;
        private System.Windows.Forms.Button btnAdd;
    }
}