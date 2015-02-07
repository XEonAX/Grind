Imports System.ComponentModel

Public Class SortableBindingList(Of T)
    Inherits BindingList(Of T)
    Private sortedList As ArrayList
    Private isSortedValue As Boolean

    Public Sub New()
    End Sub

    Public Sub New(list As IList(Of T))
        For Each o As Object In list
            Me.Add(DirectCast(o, T))
        Next
    End Sub

    Protected Overrides ReadOnly Property SupportsSortingCore() As Boolean
        Get
            Return True
        End Get
    End Property


    Protected Overrides ReadOnly Property IsSortedCore() As Boolean
        Get
            Return isSortedValue
        End Get
    End Property

    Private sortDirectionValue As ListSortDirection
    Private sortPropertyValue As PropertyDescriptor

    Protected Overrides Sub ApplySortCore(prop As PropertyDescriptor, direction As ListSortDirection)
        sortedList = New ArrayList()

        Dim interfaceType As Type = prop.PropertyType.GetInterface("IComparable")

        If interfaceType Is Nothing AndAlso prop.PropertyType.IsValueType Then
            Dim underlyingType As Type = Nullable.GetUnderlyingType(prop.PropertyType)

            If underlyingType IsNot Nothing Then
                interfaceType = underlyingType.GetInterface("IComparable")
            End If
        End If

        If interfaceType IsNot Nothing Then
            sortPropertyValue = prop
            sortDirectionValue = direction

            Dim query As IEnumerable(Of T) = MyBase.Items
            If direction = ListSortDirection.Ascending Then
                query = query.OrderBy(Function(i) prop.GetValue(i))
            Else
                query = query.OrderByDescending(Function(i) prop.GetValue(i))
            End If
            Dim newIndex As Integer = 0
            For Each item As Object In query
                Me.Items(newIndex) = DirectCast(item, T)
                newIndex += 1
            Next
            isSortedValue = True

            Me.OnListChanged(New ListChangedEventArgs(ListChangedType.Reset, -1))
        Else
            Throw New NotSupportedException("Cannot sort by " + prop.Name + ". This" + prop.PropertyType.ToString() + " does not implement IComparable")
        End If
    End Sub

    Protected Overrides ReadOnly Property SortPropertyCore() As PropertyDescriptor
        Get
            Return sortPropertyValue
        End Get
    End Property

    Protected Overrides ReadOnly Property SortDirectionCore() As ListSortDirection
        Get
            Return sortDirectionValue
        End Get
    End Property

End Class
