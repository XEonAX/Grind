using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Grind.Common;
using System.Diagnostics;
using System.IO;
namespace Grind.WPF.CSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGridTasks.AutoGenerateColumns = false;
            dGridTasks.ItemsSource = TaskList;
            Controllers.ControllersInit("http://localhost:4567/", ref sbiMessage, ref sbiState);
            new Globals();

            Controllers.ReadPeople(out Globals.People);
            Controllers.ReadTasks(ref TaskList);
            //cobExecutor.Items.AddRange(Globals.People.Select(x => x.name).ToArray());
            //cobReviewer.Items.AddRange(Globals.People.Select(x => x.name).ToArray());
            ttfrmControl.FillPeopleDropDown();
            dGridTasks.ItemsSource = TaskList;
            SetMode(ViewMode.Normal);
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            if (((string)btnNew.Content) == "New")
            {
                //New Task mode
                SetMode(ViewMode.New);
                //FillTaskTrackingForm(new Task());
                ttfrmControl.FillFormfromTask(new Task());


            }
            else if (((string)btnNew.Content) == "Save" && ((string)btnUpdate.Content) == "Cancel")
            {
                //New Task Save
                Task task = new Task();
                //BuildTaskFromForm(ref task);
                ttfrmControl.BuildTaskfromTaskFilledForm(ref task);
                if (RetCode.successful == Controllers.CreateTask(ref task))
                {
                    UserChange = false;
                    Controllers.ReadTasks(ref TaskList);
                    UserChange = true;
                    //dGridTasks.DataSource = TaskList;
                    //if (dGridTasks.RowCount > 0)
                    //    dGridTasks.CurrentCell = dGridTasks.Rows[dGridTasks.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[1];

                    ttfrmControl.FillFormfromTask(task);
                    SetMode(ViewMode.Normal);
                }
                else
                {
                    string ErrMsg = "";
                    //if (Controllers.rRestResponse != null && Controllers.rRestResponse.Content != null)
                    //{
                    //    ErrMsg = Environment.NewLine + Controllers.rRestResponse.Content;
                    //}
                    ErrMsg = Controllers.GetResponseError();
                    MessageBox.Show("There was some problem while Saving the Task." + ErrMsg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }
            else if (((string)btnNew.Content) == "Cancel" && ((string)btnUpdate.Content) == "Save")
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
        private void SetMode(ViewMode viewMode)
        {
            switch (viewMode)
            {
                case ViewMode.Normal:
                    dGridTasks.IsEnabled = true;
                    ttfrmControl.DisableForm();
                    btnNew.Content = "New";
                    btnUpdate.Content = "Update";
                    break;
                case ViewMode.New:
                    dGridTasks.IsEnabled = false;
                    ttfrmControl.EnableForm();
                    btnNew.Content = "Save";
                    btnUpdate.Content = "Cancel";
                    break;
                case ViewMode.Update:
                    dGridTasks.IsEnabled = false;
                    ttfrmControl.EnableForm();
                    btnNew.Content = "Cancel";
                    btnUpdate.Content = "Save";
                    break;
                case ViewMode.ChangeCancelled:
                    SetMode(ViewMode.Normal);
                    break;
                default:
                    break;
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Controllers.ReadPeople(out Globals.People);
            Controllers.ReadTasks(ref TaskList);
            //cobExecutor.Items.AddRange(Globals.People.Select(x => x.name).ToArray());
            //cobReviewer.Items.AddRange(Globals.People.Select(x => x.name).ToArray());
            ttfrmControl.FillPeopleDropDown();
            dGridTasks.ItemsSource = TaskList;
            SetMode(ViewMode.Normal);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (btnUpdate.Content == "Update")
            {
                SetMode(ViewMode.Update);
            }
            else if (btnUpdate.Content == "Save" && btnNew.Content == "Cancel")
            {
                int OldTaskId = CurrentTask.id;
                ttfrmControl.BuildTaskfromTaskFilledForm(ref CurrentTask);
                if (RetCode.successful==Controllers.UpdateTask(ref CurrentTask))
                {

                    UserChange = false;
                    Controllers.ReadTasks(ref TaskList);

                    if (TaskList.Count > 0)
                    {
                        dGridTasks.SelectedIndex = GetIndexByIdFromTaskList(OldTaskId);
                        //dGridTasks.CurrentCell = DataGrid.GetCell(1, GetIndexByIdFromTaskList(OldTaskId));
                        Controllers.ReadTask(((Task)dGridTasks.SelectedCells[0].Item).id, out CurrentTask);
                        //Controllers.ReadTask((int)dGridTasks.CurrentItem.Cells["colId"].Value, ref CurrentTask);
                    }

                    //FillTaskTrackingForm(RetrievedTask);
                    UserChange = true;
                    ttfrmControl.FillFormfromTask(CurrentTask);
                    SetMode(ViewMode.Normal);
                }
                else
                {
                    string ErrMsg = "";
                    if (Controllers.rRestResponse != null && Controllers.rRestResponse.Content != null)
                    {
                        ErrMsg = Environment.NewLine + Controllers.rRestResponse.Content;
                    }
                    MessageBox.Show("There was some problem while Updating the Task." + ErrMsg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (btnUpdate.Content == "Cancel" && btnNew.Content == "Save")
            {
                ttfrmControl.FillFormfromTask(CurrentTask);
                //tsmiRefresh_Click(null, EventArgs.Empty);
                SetMode(ViewMode.Normal);
            }
        }


        #region Lambdas
        private int GetIndexByIdFromTaskList(int id)
        {
            return TaskList.ToList().FindIndex(x => x.id == id);
        }
        #endregion

        private void dGridTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserChange && dGridTasks.CurrentItem != null)
            {
                Debug.Print(">>>>>>>>>>>" + dGridTasks.SelectedCells[0].Item.ToString());
                Controllers.ReadTask(((Task)dGridTasks.SelectedCells[0].Item).id, out CurrentTask);
                //FillTaskTrackingForm(RetrievedTask);
                ttfrmControl.FillFormfromTask(CurrentTask);

            }
        }

        private void chkOffline_Checked(object sender, RoutedEventArgs e)
        {
            Controllers.setOffline();
        }

        private void chkOffline_Unchecked(object sender, RoutedEventArgs e)
        {
            Controllers.setOnline();
        }
    }
}
