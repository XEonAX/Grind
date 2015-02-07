Imports RestSharp
Imports System.Collections.ObjectModel

Class MainWindow
    Dim rRestClient As New RestClient
    Dim rRestResponse As RestResponse
    Dim rRestRequest As New RestRequest
    Public TaskList As ObservableCollection(Of Task)
    Dim JSONDeserilizer As New Deserializers.JsonDeserializer
    Private Sub btnRefresh_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles btnRefresh.Click
        Uri.TryCreate("http://localhost:4567/", UriKind.Absolute, rRestClient.BaseUrl)
        rRestRequest.Resource = "tasks"
        rRestRequest.Method = Method.GET
        rRestResponse = rRestClient.Execute(rRestRequest)
        TaskList = JSONDeserilizer.Deserialize(Of ObservableCollection(Of Task))(rRestResponse)
        GridTasks.ItemsSource = TaskList
    End Sub

    Public Sub New()
        TaskList = New ObservableCollection(Of Task)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridTasks.ItemsSource = TaskList
    End Sub
End Class
