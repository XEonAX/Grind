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
            cobExecutor.Items.AddRange(People.Select(x => x.Name).ToArray());
            cobReviewer.Items.AddRange(People.Select(x => x.Name).ToArray());

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
            rRestRequest.AddUrlSegment("id", TaskList[dGridTasks.CurrentRow.Index].Id.ToString());
            rRestRequest.Method = Method.GET;
            rRestResponse = rRestClient.Execute(rRestRequest);
            RetrievedTask = JSONDeserilizer.Deserialize<Task>(rRestResponse);
            FillTaskTrackingForm(RetrievedTask);
        }

        private void FillTaskTrackingForm(Task _Task)
        {
            
                txtTaskName.Text = _Task.Name;
                txtAbstract.Text = _Task.Abstract;
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
                dtpOpen.Value = _Task.OpenDate;
                dtpAnalysis.Value = _Task.AnalysisDate;
                dtpReview.Value = _Task.ReviewDate;
                dtpCorrection.Value = _Task.CorrectionDate;
                dtpPromotion.Value = _Task.PromotionDate;
                dtpCollection.Value = _Task.CollectionDate;
                dtpClosed.Value = _Task.ClosedDate;
                if (_Task.IsBug)
                    rbBug.Checked = true;
                else
                    rbHL.Checked = true;
                switch (_Task.BugType)
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
                trbTaskStatus.Value = (int)_Task.TaskStatus;
                cobExecutor.Text = _Task.Developer.Name;//People.Find(x => x.Id==_Task.DeveloperId).Name;
                cobReviewer.Text = _Task.Reviewer.Name;//People.Find(x => x.Id == _Task.ReviewerId).Name;
            
           
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
            task.Name = txtTaskName.Text;
            task.Description = "Descriptiosnfds";
            if (rbBug.Checked)
                task.IsBug = true;
            else
                task.IsBug = false;
            if (rbHMA.Checked)
                task.BugType = eBugType.HMA;
            else if (rbCRITSIT.Checked)
                task.BugType = eBugType.CRITSIT;
            else if (rbBacklog.Checked)
                task.BugType = eBugType.BackLog;
            else
                task.BugType = eBugType.Others;
            task.TaskStatus = (eTaskStatus)trbTaskStatus.Value;
            task.Approved = cbApproved.Checked;
            task.DeveloperId = People.Find(x => x.Name == cobExecutor.SelectedItem.ToString()).Id;
            task.ReviewerId = People.Find(x => x.Name == cobReviewer.SelectedItem.ToString()).Id;
            task.OpenDate = dtpOpen.Value;
            task.AnalysisDate = dtpAnalysis.Value;
            task.ReviewDate = dtpReview.Value;
            task.CorrectionDate = dtpCorrection.Value;
            task.PromotionDate = dtpPromotion.Value;
            task.CollectionDate = dtpCollection.Value;
            task.ClosedDate = dtpClosed.Value;
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
