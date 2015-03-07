using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using System.Reflection;


namespace Grind_WF_CS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }














        //RestClient rRestClient = new RestClient();
        //IRestResponse rRestResponse;
        //RestRequest rRestRequest = new RestRequest();
        public SortableBindingList<ClientTask> TaskList;
        //JsonDeserializer JSONDeserilizer = new JsonDeserializer();
        //JsonSerializer JSONSerilizer = new JsonSerializer();
        Task RetrievedTask;
        bool UserChange = false;

        //string OldDescriptionRtf, OldAnalysisRtf, OldReviewRtf;
        private void RefreshToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            //Uri.TryCreate("http://localhost:4567/", UriKind.Absolute, out rRestClient.BaseUrl);
            //rRestRequest.Resource = "people";
            //rRestRequest.Method = Method.GET;
            //rRestResponse = rRestClient.Execute(rRestRequest);
            //People = JSONDeserilizer.Deserialize<List<Person>>(rRestResponse);
            Controllers.ReadPeople(ref Globals.People);
            Controllers.ReadTasks(ref TaskList);
            cobExecutor.Items.AddRange(Globals.People.Select(x => x.name).ToArray());
            cobReviewer.Items.AddRange(Globals.People.Select(x => x.name).ToArray());

            dGridTasks.DataSource = TaskList;

        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            dGridTasks.AutoGenerateColumns = false;
            dGridTasks.DataSource = TaskList;
            new Controllers("http://localhost:4567/");
            new Globals();
            //rRestClient = new RestClient("http://localhost:4567/");
        }



        private void dGridTasks_SelectionChanged(System.Object sender, System.EventArgs e)
        {

            //rRestRequest = new RestRequest();
            //rRestRequest.Resource = "task/{id}";
            //rRestRequest.DateFormat = "yyyy-MM-ddTHH:mm:sssssZ";
            //rRestRequest.AddUrlSegment("id", TaskList[dGridTasks.CurrentRow.Index].id.ToString());
            //rRestRequest.Method = Method.GET;
            //rRestResponse = rRestClient.Execute(rRestRequest);
            //RetrievedTask = JSONDeserilizer.Deserialize<Task>(rRestResponse);
            Controllers.ReadTask(TaskList[dGridTasks.CurrentRow.Index].id,ref RetrievedTask);
            FillTaskTrackingForm(RetrievedTask);

        }

        private void FillTaskTrackingForm(Task _Task)
        {

            UserChange = false;
            txtName.Text = _Task.name;
            txtTitle.Text = _Task.title;
            //foreach (Control ctl in tlpTaskStatus.Controls)
            //{
            //    ctl.Enabled = false;
            //}
            dtpOpen.Enabled = true;
            dtpAnalysis.Enabled = false;
            dtpReview.Enabled = false;
            dtpCorrection.Enabled = false;
            dtpPromotion.Enabled = false;
            dtpCollection.Enabled = false;
            dtpClosed.Enabled = false;
            dtpOpen.Value = _Task.open_date;
            dtpAnalysis.Value = _Task.analysis_date;
            dtpReview.Value = _Task.review_date;
            dtpCorrection.Value = _Task.correction_date;
            dtpPromotion.Value = _Task.promotion_date;
            dtpCollection.Value = _Task.collection_date;
            dtpClosed.Value = _Task.closed_date;
            if (_Task.is_bug)
                rbBug.Checked = true;
            else
                rbHL.Checked = true;
            switch (_Task.bug_type)
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
            trbTaskStatus.Value = (int)_Task.task_status;
            cobExecutor.Text = /*_Task.developer.name;*/Globals.People.Find(x => x.id == _Task.developer_id).name;
            cobReviewer.Text = /*_Task.reviewer.name;*/Globals.People.Find(x => x.id == _Task.reviewer_id).name;
            rtbDescription.Rtf = _Task.description;
            rtbAnalysis.Rtf = _Task.analysis;
            rtbReview.Rtf = _Task.review;

            UserChange = true;
            //case "Open":
            //    rbOpen.Checked = true;
            //    break;
            //case "Analysis":
            //    rbAnalysis.Checked = true;
            //    break;
            //case "Review":
            //    rbReview.Checked = true;
            //    break;
            //case "Correction":
            //    rbCorrection.Checked = true;
            //    break;
            //case "Promotion":
            //    rbPromotion.Checked = false;
            //    break;
            //case "Collection":
            //    rbCollection.Checked = false;
            //    break;
            //case "Closed":
            //    rbClosed.Checked = false;
            //    break;
            //default:
            //    break;

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

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           Task task = new Task();
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
            //if (RT.task.documents==null)
            //    RT.task.documents=new List<Document>();
            //rRestRequest = new RestRequest();
            //rRestRequest.Resource = "task";
            //rRestRequest.DateFormat = "yyyy-MM-ddTHH:mm:sssssZ";
            //rRestRequest.Method = Method.POST;
            //rRestRequest.RequestFormat = DataFormat.Json;
            //rRestRequest.AddBody(postObject);
            //rRestResponse = rRestClient.Execute(rRestRequest);
            //RetrievedTask = JSONDeserilizer.Deserialize<Task>(rRestResponse);
            Controllers.CreateTask(ref task);
            
            FillTaskTrackingForm(task);
        }

        private void rtbDescription_Leave(object sender, EventArgs e)
        {

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


    }



}












