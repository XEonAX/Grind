using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Grind.Common;
namespace Grind.Winforms.CSharp
{
    public partial class TaskTrackingForm : UserControl
    {
        public TaskTrackingForm()
        {
            InitializeComponent();
        }
        private bool UserChange = true;

        private void TaskTrackingForm_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }
        public void FillPeopleDropDown()
        {
            cobExecutor.Items.Clear();
            cobExecutor.Items.Add("Executor");
            cobExecutor.Items.Add("-------------------------");
            cobExecutor.Items.AddRange(Session.People.Select(x => x.name).ToArray());

            cobReviewer.Items.Clear();
            cobReviewer.Items.Add("Reviewer");
            cobReviewer.Items.Add("-------------------------");
            cobReviewer.Items.AddRange(Session.People.Select(x => x.name).ToArray());
        }

        public void FillFormfromTask(Task task)
        {
            UserChange = false;
            txtName.Text = task.name;
            txtTitle.Text = task.title;
            dtpOpen.Enabled = true;
            dtpAnalysis.Enabled = false;
            dtpReview.Enabled = false;
            dtpCorrection.Enabled = false;
            dtpPromotion.Enabled = false;
            dtpCollection.Enabled = false;
            dtpClosed.Enabled = false;
            dtpOpen.Value = task.open_date.Date;
            dtpAnalysis.Value = task.analysis_date.Date;
            dtpReview.Value = task.review_date.Date;
            dtpCorrection.Value = task.correction_date.Date;
            dtpPromotion.Value = task.promotion_date.Date;
            dtpCollection.Value = task.collection_date.Date;
            dtpClosed.Value = task.closed_date.Date;
            if (task.is_bug)
                rbBug.Checked = true;
            else
                rbHL.Checked = true;
            switch (task.bug_type)
            {
                case eBugType.HMA:
                    rbHMA.Checked = true;
                    break;
                case eBugType.BackLog:
                    rbBacklog.Checked = true;
                    break;
                case eBugType.CRITSIT:
                    rbCRITSIT.Checked = true;
                    break;
                case eBugType.Others:
                    rbOthers.Checked = true;
                    break;
                default:
                    break;
            }
            trbTaskStatus.Enabled = true;
            trbTaskStatus.Value = (int)task.task_status;
            cobExecutor.Text = Session.People.Find(x => x.id == task.developer_id).name;
            cobReviewer.Text = Session.People.Find(x => x.id == task.reviewer_id).name;
            rtbDescription.Rtf = (string)task.description;
            rtbAnalysis.Rtf = (string)task.analysis;
            rtbReview.Rtf = (string)task.review;
            UserChange = true;
        }

        public void BuildTaskfromTaskFilledForm(ref Task task)
        {
            task.name = txtName.Text;
            task.title = txtTitle.Text;

            if (rbBug.Checked)
                task.is_bug = true;
            else
                task.is_bug = false;

            if (rbHMA.Checked)
                task.bug_type = eBugType.HMA;
            else if (rbCRITSIT.Checked)
                task.bug_type = eBugType.CRITSIT;
            else if (rbBacklog.Checked)
                task.bug_type = eBugType.BackLog;
            else
                task.bug_type = eBugType.Others;
            task.task_status = (eTaskStatus)trbTaskStatus.Value;
            task.approved = cbApproved.Checked;
            task.developer_id = Session.People.Find(x => x.name == cobExecutor.SelectedItem.ToString()).id;
            task.reviewer_id = Session.People.Find(x => x.name == cobReviewer.SelectedItem.ToString()).id;
            task.open_date = dtpOpen.Value.Date.Add(TimeZoneInfo.Local.BaseUtcOffset);
            task.analysis_date = dtpAnalysis.Value.Date.Add(TimeZoneInfo.Local.BaseUtcOffset);
            task.review_date = dtpReview.Value.Date.Add(TimeZoneInfo.Local.BaseUtcOffset);
            task.correction_date = dtpCorrection.Value.Date.Add(TimeZoneInfo.Local.BaseUtcOffset);
            task.promotion_date = dtpPromotion.Value.Date.Add(TimeZoneInfo.Local.BaseUtcOffset);
            task.collection_date = dtpCollection.Value.Date.Add(TimeZoneInfo.Local.BaseUtcOffset);
            task.closed_date = dtpClosed.Value.Date.Add(TimeZoneInfo.Local.BaseUtcOffset);
            task.description = rtbDescription.Rtf;
            task.analysis = rtbAnalysis.Rtf;
            task.review = rtbReview.Rtf;
        }

        private void trbTaskStatus_ValueChanged(object sender, EventArgs e)
        {
            int enableddtpCount = trbTaskStatus.Value;
            foreach (Control ctl in tlpTaskStatus.Controls.Cast<Control>().OrderBy(c => c.TabIndex))
            {
                if (ctl is DateTimePicker)
                {
                    if (enableddtpCount >= 0)
                    {
                        ctl.Enabled = true;
                        enableddtpCount--;
                    }
                    else
                    {
                        ctl.Enabled = false;
                        enableddtpCount--;
                    }
                }
            }
        }

        private void rtb_TextChanged(object sender, EventArgs e)
        {
            if (sender is RichTextBox)
            {
                if (!UserChange && ((RichTextBox)sender).Rtf.Length > Math.Pow(2, 20))
                {
                    ((RichTextBox)sender).BackColor = Color.Red;
                }
                else
                {
                    ((RichTextBox)sender).BackColor = Color.White;
                }
            }
        }

        public void DisableForm()
        {

            //gbName.Enabled = false;
            txtName.ReadOnly = true;
            txtTitle.ReadOnly = true;
            gbTaskStatus.Enabled = false;
            gbTaskTypes.Enabled = false;
            //gbDescription.Enabled = false;
            //gbAnalysis.Enabled = false;
            //gbReview.Enabled = false;
            rtbDescription.ReadOnly = true;
            rtbAnalysis.ReadOnly = true;
            rtbReview.ReadOnly = true;
        }
        public void EnableForm()
        {
            txtName.ReadOnly = false;
            txtTitle.ReadOnly = false;
            //gbName.Enabled = true;
            gbTaskStatus.Enabled = true;
            gbTaskTypes.Enabled = true;
            //gbDescription.Enabled = true;
            //gbAnalysis.Enabled = true;
            //gbReview.Enabled = true;
            rtbDescription.ReadOnly = false;
            rtbAnalysis.ReadOnly = false;
            rtbReview.ReadOnly = false;

        }


    }
}
