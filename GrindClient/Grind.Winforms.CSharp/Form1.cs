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
using Grind.Common;

namespace Grind.Winforms.CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public SortableBindingList<TaskListItem> TaskList;
        Task CurrentTask;
        bool UserChange = true;

        enum ViewMode
        {
            Normal,
            New,
            Update,
            ChangeCancelled
        }


        private void Form1_Load(object sender, System.EventArgs e)
        {
            dGridTasks.AutoGenerateColumns = false;
            dGridTasks.DataSource = TaskList;
            Controllers.Init("http://localhost:4567/");
            
        }


        private void tsmiNew_Click(object sender, EventArgs e)
        {
            if (tsmiNew.Text == "New")
            {
                //New Task mode
                SetMode(ViewMode.New); 
                //FillTaskTrackingForm(new Task());
                ttfrmControl.FillFormfromTask(new Task());


            }
            else if (tsmiNew.Text == "Save" && tsmiUpdate.Text == "Cancel")
            {
                //New Task Save
                Task task = new Task();
                //BuildTaskFromForm(ref task);
                ttfrmControl.BuildTaskfromTaskFilledForm(ref task);
                Controllers.CreateTask(task);
                UserChange = false;
                Controllers.ReadTasks(ref TaskList);
                UserChange = true;
                //dGridTasks.DataSource = TaskList;
                if (dGridTasks.RowCount>0)
                    dGridTasks.CurrentCell = dGridTasks.Rows[dGridTasks.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[1];

                ttfrmControl.FillFormfromTask(task);
                SetMode(ViewMode.Normal);
            }
            else if (tsmiNew.Text == "Cancel" && tsmiUpdate.Text == "Save")
            {
                //int OldTaskId = CurrentTask.id;
                ////Update Mode Cancel
                //UserChange = false;
                //Controllers.ReadTasks(ref TaskList);
                //UserChange = true;
                //if (dGridTasks.RowCount > 0)
                //{
                //    dGridTasks.CurrentCell = dGridTasks[1, GetIndexByIdFromTaskList(OldTaskId)];
                //}
                ttfrmControl.FillFormfromTask(CurrentTask);
                SetMode(ViewMode.Normal);

            }

        }

        private void tsmiRefresh_Click(System.Object sender, System.EventArgs e)
        {
            Controllers.ReadPeople(out Session.People);
            Controllers.ReadTasks(ref TaskList);
            Session.HashPeople();
            //cobExecutor.Items.AddRange(Globals.People.Select(x => x.name).ToArray());
            //cobReviewer.Items.AddRange(Globals.People.Select(x => x.name).ToArray());
            ttfrmControl.FillPeopleDropDown();
            dGridTasks.DataSource = TaskList;
            SetMode(ViewMode.Normal);
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            if (tsmiUpdate.Text == "Update")
            {
                SetMode(ViewMode.Update);
            }
            else if (tsmiUpdate.Text == "Save" && tsmiNew.Text == "Cancel")
            {
                int OldTaskId = CurrentTask.id;
                ttfrmControl.BuildTaskfromTaskFilledForm(ref CurrentTask);
                Controllers.UpdateTask(CurrentTask);


                UserChange = false;
                Controllers.ReadTasks(ref TaskList);
                
                if (dGridTasks.RowCount > 0)
                {
                    dGridTasks.CurrentCell = dGridTasks[1, GetIndexByIdFromTaskList(OldTaskId)];
                    Controllers.ReadTask((int)dGridTasks.CurrentRow.Cells["colId"].Value, out CurrentTask);
                }
                
                //FillTaskTrackingForm(RetrievedTask);
                UserChange = true;
                ttfrmControl.FillFormfromTask(CurrentTask);
                SetMode(ViewMode.Normal);
            }
            else if (tsmiUpdate.Text == "Cancel" && tsmiNew.Text == "Save")
            {
                ttfrmControl.FillFormfromTask(CurrentTask);
                //tsmiRefresh_Click(null, EventArgs.Empty);
                SetMode(ViewMode.Normal);
            }
        }


        private void dGridTasks_SelectionChanged(System.Object sender, System.EventArgs e)
        {
            if (UserChange && dGridTasks.CurrentRow != null)
            {
                Controllers.ReadTask((int)dGridTasks.CurrentRow.Cells["colId"].Value, out CurrentTask);
                //FillTaskTrackingForm(RetrievedTask);
                ttfrmControl.FillFormfromTask(CurrentTask);

            }
        }

        private void dGridTasks_RowCountChanged(object sender, DataGridViewRowsAddedEventArgs e)
        {
            RowCountChanged(sender, e);
        }

        private void dGridTasks_RowCountChanged(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            RowCountChanged(sender, e);
        }

        private void RowCountChanged(object sender, EventArgs e)
        {
            if (sender is DataGridView)
                if (((DataGridView)sender).RowCount == 0)
                    tsmiUpdate.Enabled = false;
                else
                    tsmiUpdate.Enabled = true;


        }

        private void SetMode(ViewMode viewMode)
        {
            switch (viewMode)
            {
                case ViewMode.Normal:
                    dGridTasks.Enabled = true;
                    ttfrmControl.DisableForm();
                    tsmiNew.Text = "New";
                    tsmiUpdate.Text = "Update";
                    break;
                case ViewMode.New:
                    dGridTasks.Enabled = false;
                    ttfrmControl.EnableForm();
                    tsmiNew.Text = "Save";
                    tsmiUpdate.Text = "Cancel";
                    break;
                case ViewMode.Update:
                    dGridTasks.Enabled = false;
                    ttfrmControl.EnableForm();
                    tsmiNew.Text = "Cancel";
                    tsmiUpdate.Text = "Save";
                    break;
                case ViewMode.ChangeCancelled:
                    SetMode(ViewMode.Normal);
                    break;
                default:
                    break;
            }
        }
        #region Lambdas
        private int GetIndexByIdFromTaskList(int id)
        {
            return TaskList.ToList().FindIndex(x => x.id == id);
        }
        #endregion
    }



}












