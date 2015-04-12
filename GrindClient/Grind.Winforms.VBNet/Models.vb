Imports System
Imports System.Collections.Generic
Imports System.ComponentModel

Public Class Person
    Public Property Id As Integer
    Public Property Name As String
    Public Property Trigram As String
    Public Property State As String
    Public Property Level As String
    Public Property InternalObjectId As String
    Public Property UnreadObjectsCount As Integer
    Public Property DocumentsCount As Integer
    Public Property TasksCount As Integer
End Class

Public Class Document
    Public Property TaskId As Integer
    Public Property Id As Integer
    Public Property Name As String
    Public Property Data As Object
    Public Property Path As String
    Public Property DeveloperId As Integer
    Public Property InternalObjectId As String
    Public Property CreatedAt As DateTime
    Public Property UpdatedAt As DateTime
End Class

Public Class Task
    Public Property Id As Integer
    Public Property DeveloperId As Integer
    Public Property ReviewerId As Integer
    Public Property Name As String
    Public Property TaskStatus As eTaskStatus
    Public Property TaskType As String
    Public Property Abstract As String
    Public ReadOnly Property TaskName As String
        Get
            Return Me.Name + " - " + Me.Abstract
        End Get
    End Property
    Public Property BugType As String
    Public Property InternalObjectId As String
    Public Property Approved As Boolean
    Public Property Description As String
    Public Property Analysis As String
    Public Property Investigation As String
    Public Property CommentsCount As Integer
    Public Property DocumentsCount As Integer
    Public Property OpenDate As DateTime
    Public Property AnalysisDate As DateTime
    Public Property PromotionDate As DateTime
    Public Property ReviewDate As DateTime
    Public Property CorrectionDate As DateTime
    Public Property CollectionDate As DateTime
    Public Property ClosedDate As DateTime
    Public Property ModifiedDate As DateTime
    Public Property TargetDate As DateTime
    Public Property CreatedAt As DateTime
    Public Property UpdatedAt As DateTime
    Public ReadOnly Property DeveloperName As String
        Get
            Return Me.Developer.Name
        End Get
    End Property
    Public ReadOnly Property ReviewerName As String
        Get
            Return Me.Reviewer.Name
        End Get
    End Property

    Public Property Developer As Person
    Public Property Reviewer As Person
    Public Property Documents As List(Of Document)
    Enum eTaskStatus
        Open = 0
        Analysis
        Review
        Correction
        Promotion
        Colection
        Closed
    End Enum

End Class