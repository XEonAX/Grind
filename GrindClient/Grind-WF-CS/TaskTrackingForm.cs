using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Grind_WF_CS
{
    public partial class TaskTrackingForm : UserControl
    {
        public TaskTrackingForm()
        {
            InitializeComponent();
        }

        private void TaskTrackingForm_Load(object sender, EventArgs e)
        {

        }
        private void FillPeopleDropDown()
        {
            cobExecutor.Items.Clear();
            cobExecutor.Items.Add("Executor");
            cobExecutor.Items.Add("-------------------------");
            cobExecutor.Items.AddRange(Globals.People.Select(x => x.name).ToArray());
            
            cobReviewer.Items.Clear();
            cobReviewer.Items.Add("Reviewer");
            cobReviewer.Items.Add("-------------------------");
            cobReviewer.Items.AddRange(Globals.People.Select(x => x.name).ToArray());
        }

        public void FillFormfromTask(Task task)
        {
            txtName.Text = task.name;
            txtTitle.Text = task.title;
            dtpOpen.Enabled = true;
            dtpAnalysis.Enabled = false;
            dtpReview.Enabled = false;
            dtpCorrection.Enabled = false;
            dtpPromotion.Enabled = false;
            dtpCollection.Enabled = false;
            dtpClosed.Enabled = false;
            dtpOpen.Value = task.open_date;
            dtpAnalysis.Value = task.analysis_date;
            dtpReview.Value = task.review_date;
            dtpCorrection.Value = task.correction_date;
            dtpPromotion.Value = task.promotion_date;
            dtpCollection.Value = task.collection_date;
            dtpClosed.Value = task.closed_date;
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
            cobExecutor.Text = Globals.People.Find(x => x.id == task.developer_id).name;
            cobReviewer.Text = Globals.People.Find(x => x.id == task.reviewer_id).name;
            rtbDescription.Rtf = task.description;
            rtbAnalysis.Rtf = task.analysis;
            rtbReview.Rtf = task.review;
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
            task.developer_id = Globals.People.Find(x => x.name == cobExecutor.SelectedItem.ToString()).id;
            task.reviewer_id = Globals.People.Find(x => x.name == cobReviewer.SelectedItem.ToString()).id;
            task.open_date = dtpOpen.Value;
            task.analysis_date = dtpAnalysis.Value;
            task.review_date = dtpReview.Value;
            task.correction_date = dtpCorrection.Value;
            task.promotion_date = dtpPromotion.Value;
            task.collection_date = dtpCollection.Value;
            task.closed_date = dtpClosed.Value;
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
    }
}
