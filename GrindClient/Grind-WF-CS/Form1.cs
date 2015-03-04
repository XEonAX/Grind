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














        RestClient rRestClient = new RestClient();
        IRestResponse rRestResponse;
        RestRequest rRestRequest = new RestRequest();
        public SortableBindingList<Task> TaskList;
        JsonDeserializer JSONDeserilizer = new JsonDeserializer();
        JsonSerializer JSONSerilizer = new JsonSerializer();
        Task RetrievedTask;
        List<Person> People;
        private void RefreshToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            //Uri.TryCreate("http://localhost:4567/", UriKind.Absolute, out rRestClient.BaseUrl);
            rRestRequest.Resource = "taskslist";
            rRestRequest.Method = Method.GET;
            rRestResponse = rRestClient.Execute(rRestRequest);
            TaskList = JSONDeserilizer.Deserialize<SortableBindingList<Task>>(rRestResponse);
            rRestRequest.Resource = "people";
            rRestRequest.Method = Method.GET;
            rRestResponse = rRestClient.Execute(rRestRequest);
            People = JSONDeserilizer.Deserialize<List<Person>>(rRestResponse);
            cobExecutor.Items.AddRange(People.Select(x => x.name).ToArray());
            cobReviewer.Items.AddRange(People.Select(x => x.name).ToArray());

            dGridTasks.DataSource = TaskList;

        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            dGridTasks.AutoGenerateColumns = false;
            dGridTasks.DataSource = TaskList;
            rRestClient = new RestClient("http://localhost:4567/");
        }



        private void dGridTasks_SelectionChanged(System.Object sender, System.EventArgs e)
        {

            rRestRequest = new RestRequest();
            rRestRequest.Resource = "task/{id}";
            rRestRequest.DateFormat = "yyyy-MM-ddTHH:mm:sssssZ";
            rRestRequest.AddUrlSegment("id", TaskList[dGridTasks.CurrentRow.Index].id.ToString());
            rRestRequest.Method = Method.GET;
            rRestResponse = rRestClient.Execute(rRestRequest);
            RetrievedTask = JSONDeserilizer.Deserialize<Task>(rRestResponse);
            FillTaskTrackingForm(RetrievedTask);
        }

        private void FillTaskTrackingForm(Task _Task)
        {
            
                txtTaskName.Text = _Task.name;
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
                cobExecutor.Text = /*_Task.developer.name;*/People.Find(x => x.id==_Task.developer_id).name;
                cobReviewer.Text = /*_Task.reviewer.name;*/People.Find(x => x.id == _Task.reviewer_id).name;
                rtbDescription.Rtf = _Task.description;
                rtbAnalysis.Rtf = _Task.analysis;
                rtbReview.Rtf = _Task.review;
                      
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
            Task task=new Task();
            task.name = txtTaskName.Text;
            task.description = "Descriptiosnfds";
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
            task.developer_id = People.Find(x => x.name == cobExecutor.SelectedItem.ToString()).id;
            task.reviewer_id = People.Find(x => x.name == cobReviewer.SelectedItem.ToString()).id;
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
            if (task.documents==null)
                task.documents=new List<Document>();
            rRestRequest = new RestRequest();
            rRestRequest.Resource = "newtask";
            rRestRequest.DateFormat = "yyyy-MM-ddTHH:mm:sssssZ";
            rRestRequest.Method = Method.POST;
            rRestRequest.RequestFormat = DataFormat.Json;      
            rRestRequest.AddBody(task);
            rRestResponse = rRestClient.Execute(rRestRequest);
            RetrievedTask = JSONDeserilizer.Deserialize<Task>(rRestResponse);
            FillTaskTrackingForm(RetrievedTask);
        }

    }











}
