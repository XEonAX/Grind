Imports RestSharp

Public Class Form1


    Dim rRestClient As New RestClient
    Dim rRestResponse As RestResponse
    Dim rRestRequest As New RestRequest
    Public TaskList As SortableBindingList(Of Task)
    Dim JSONDeserilizer As New Deserializers.JsonDeserializer
    Private _ActiveTask As New Task
    Public Event TaskChanged(ByVal sender As Object, ByVal e As EventArgs)
    Property ActiveTask As Task
        Get
            Return _ActiveTask
        End Get
        Set(value As Task)
            _ActiveTask = value
            RaiseEvent TaskChanged(ActiveTask, EventArgs.Empty)
        End Set
    End Property

    Public Sub CurrentTaskChangedHandler(ByVal sender As Object, ByVal e As EventArgs) Handles Me.TaskChanged
        FillTaskTrackingForm(sender)
    End Sub
    Private Sub RefreshToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        Uri.TryCreate("http://localhost:4567/", UriKind.Absolute, rRestClient.BaseUrl)
        rRestRequest.Resource = "taskslist"
        rRestRequest.Method = Method.GET
        rRestResponse = rRestClient.Execute(rRestRequest)
        TaskList = JSONDeserilizer.Deserialize(Of SortableBindingList(Of Task))(rRestResponse)

        dGridTasks.DataSource = TaskList
    End Sub

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        dGridTasks.AutoGenerateColumns = False
        dGridTasks.DataSource = TaskList
        bsTask.DataSource = ActiveTask
    End Sub

  
    Private Sub dGridTasks_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dGridTasks.SelectionChanged

        Uri.TryCreate("http://localhost:4567/", UriKind.Absolute, rRestClient.BaseUrl)
        rRestRequest = New RestRequest
        rRestRequest.Resource = "task/{id}"
        rRestRequest.AddUrlSegment("id", dGridTasks.CurrentRow.Index + 1)
        rRestRequest.Method = Method.GET
        rRestResponse = rRestClient.Execute(rRestRequest)
        ActiveTask = JSONDeserilizer.Deserialize(Of Task)(rRestResponse)

    End Sub

    Private Sub bsTask_DataMemberChanged(sender As System.Object, e As System.EventArgs) Handles bsTask.DataMemberChanged
        Debug.Print(sender.ToString)
    End Sub

    Private Sub bsTask_CurrentChanged(sender As System.Object, e As System.EventArgs) Handles bsTask.CurrentChanged
        Debug.Print(sender.ToString)
    End Sub

    Private Sub bsTask_ListChanged(sender As System.Object, e As System.ComponentModel.ListChangedEventArgs) Handles bsTask.ListChanged
        Debug.Print(sender.ToString)
    End Sub

    Private Sub FillTaskTrackingForm(sender As Object)

    End Sub

End Class
