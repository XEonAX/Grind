Imports RestSharp

Public Class Form1


    Dim rRestClient As New RestClient
    Dim rRestResponse As RestResponse
    Dim rRestRequest As New RestRequest
    Public TaskList As SortableBindingList(Of Task)
    Dim JSONDeserilizer As New Deserializers.JsonDeserializer

    Private Sub RefreshToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        Uri.TryCreate("http://localhost:4567/", UriKind.Absolute, rRestClient.BaseUrl)
        rRestRequest.Resource = "tasks"
        rRestRequest.Method = Method.GET
        rRestResponse = rRestClient.Execute(rRestRequest)
        TaskList = JSONDeserilizer.Deserialize(Of SortableBindingList(Of Task))(rRestResponse)
        GridTasks.DataSource = TaskList
    End Sub

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        GridTasks.DataSource = TaskList
    End Sub
End Class
