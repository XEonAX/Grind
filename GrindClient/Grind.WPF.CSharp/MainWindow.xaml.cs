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
        Session Session;

        private string lastMessage, lastState;
        enum ViewMode
        {
            Normal,
            New,
            Update,
            ChangeCancelled
        }

        Action<eAction, object, object, object> callbackFn;
        void CallBack(eAction action, object obj1, object obj2, object obj3)
        {
            Debug.Print(action.ToString() + "===>" + obj1.ToString());
            switch (action)
            {
                case eAction.Message:
                    string Message = obj1 as string;
                    if (Message != null)
                    {
                        if (lastMessage != Message)
                            sbiMessage.Content = Message + Environment.NewLine + sbiMessage.Content;
                        lastMessage = Message;
                    }

                    break;
                case eAction.Error:
                    if (obj1 is string)
                    {
                        MessageBox.Show((string)obj1, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case eAction.State:
                    string state = obj1 as string;
                    if (state != null)
                    {
                        if (lastState != state)
                            sbiState.Content = state + Environment.NewLine + sbiState.Content;
                        lastState = state;
                    }
                    break;
                case eAction.Notification:
                    break;
                case eAction.RestError:
                    if (obj1 is System.Net.HttpStatusCode)
                    {
                        System.Net.HttpStatusCode StatusCode = (System.Net.HttpStatusCode)obj1;
                        if (StatusCode == System.Net.HttpStatusCode.Forbidden)
                            MessageBox.Show("Invalid Credentials", "Forbidden", MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                            MessageBox.Show("Error:" + (string)obj2, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    break;
                case eAction.WebSocketError:
                    break;
                case eAction.CacheError:
                    break;
                default:
                    break;
            }

        }
        Callbacker callbacker;


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGridTasks.AutoGenerateColumns = false;
            dGridTasks.ItemsSource = TaskList;
            callbacker = new Callbacker(CallBack);
            Session = new Session(@"data source=Grind.db", "http://localhost:4567/", @"ws://localhost:8080/", callbacker);
            ttfrmControl.SetSession(Session);
            userMaintenanceControl1.SetSession(Session);
            ChatsControl.SetSession(Session);

            //Controllers("http://localhost:4567/", @"data source=J:\Root\Grind\GrindClient\Grind.Common\Grind.db");
            //Person x1 = new Person { created_at = DateTime.Now, updated_at = DateTime.Now, id = 3 };
            //Cache.AddObject<Person>(x1);
            //Person x2 = Cache.GetObject<Person>(3);
            Session.ReadPeople();
            if (Globals.People.Count == 0)
            {
                Globals.People.Add(new Person { id = 0, name = "DummyUser", level = eLevel.Master, trigram = "DummyUser" });
            }
            Session.Controllers.ReadTasks(ref TaskList);
            Session.User = new Person { active = false, id = -1, name = "OfflineUser", trigram = "0x0" };
            //cobExecutor.Items.AddRange(Globals.People.Select(x => x.name).ToArray());
            //cobReviewer.Items.AddRange(Globals.People.Select(x => x.name).ToArray());
            ttfrmControl.FillPeopleDropDown(Globals.People);
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
                if (RetCode.successful == Session.Controllers.CreateTask(task))
                {
                    UserChange = false;
                    Session.Controllers.ReadTasks(ref TaskList);
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
                    //if(Session.RestService.rRestResponse != null &&Session.RestService.rRestResponse.Content != null)
                    //{
                    //    ErrMsg = Environment.NewLine +Session.RestService.rRestResponse.Content;
                    //}
                    ErrMsg = Environment.NewLine + Session.RestService.GetResponseError();
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
            Session.ReadPeople();
            Session.Controllers.ReadTasks(ref TaskList);
            //cobExecutor.Items.AddRange(Globals.People.Select(x => x.name).ToArray());
            //cobReviewer.Items.AddRange(Globals.People.Select(x => x.name).ToArray());
            ttfrmControl.FillPeopleDropDown(Globals.People);
            dGridTasks.ItemsSource = TaskList;
            SetMode(ViewMode.Normal);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btnUpdate.Content == "Update")
            {
                SetMode(ViewMode.Update);
            }
            else if ((string)btnUpdate.Content == "Save" && (string)btnNew.Content == "Cancel")
            {
                int OldTaskId = CurrentTask.id;
                ttfrmControl.BuildTaskfromTaskFilledForm(ref CurrentTask);
                if (RetCode.successful == Session.Controllers.UpdateTask(CurrentTask))
                {

                    UserChange = false;
                    Session.Controllers.ReadTasks(ref TaskList);

                    if (TaskList.Count > 0)
                    {
                        dGridTasks.SelectedIndex = GetIndexByIdFromTaskList(OldTaskId);
                        //dGridTasks.CurrentCell = DataGrid.GetCell(1, GetIndexByIdFromTaskList(OldTaskId));
                        Session.Controllers.ReadTask(((Task)dGridTasks.SelectedCells[0].Item).id, out CurrentTask);
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
                    if (Session.RestService.rRestResponse != null && Session.RestService.rRestResponse.Content != null)
                    {
                        ErrMsg = Environment.NewLine + Session.RestService.rRestResponse.Content;
                    }
                    MessageBox.Show("There was some problem while Updating the Task." + ErrMsg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if ((string)btnUpdate.Content == "Cancel" && (string)btnNew.Content == "Save")
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
                Session.Controllers.ReadTask(((Task)dGridTasks.SelectedCells[0].Item).id, out CurrentTask);
                //FillTaskTrackingForm(RetrievedTask);
                ttfrmControl.FillFormfromTask(CurrentTask);

            }
        }

        private void chkOffline_Checked(object sender, RoutedEventArgs e)
        {
            State.IsOnline = false; ;
        }

        private void chkOffline_Unchecked(object sender, RoutedEventArgs e)
        {
            State.IsOnline = true;
        }

        private void btnDownloadTasks_Click(object sender, RoutedEventArgs e)
        {
            Session.Controllers.GetAndStoreTasks();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (Session.ServerLogin(txtTrigram.Text, txtPassword.Password) == RetCode.successful)
                bdrLogin.BorderBrush = Brushes.Green;
        }
    }
}
