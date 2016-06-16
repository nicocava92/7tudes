Imports Microsoft.VisualBasic

Public Class Sorter
    Public Shared Sub DualSorter(ByRef arrArray, ByVal DimensionToSort)
        Dim row, j, StartingKeyValue, StartingOtherValue, _
            NewStartingKey, NewStartingOther, _
            swap_pos, OtherDimension
        Const column = 1

        ' Ensure that the user has picked a valid DimensionToSort
        If DimensionToSort = 1 Then
            OtherDimension = 0
        ElseIf DimensionToSort = 0 Then
            OtherDimension = 1
        Else
            'Shoot, invalid value of DimensionToSort
            System.Web.HttpContext.Current.Trace.Warn("Invalid dimension for DimensionToSort: must be value of 1 or 0.")
            Exit Sub
        End If

        For row = 0 To UBound(arrArray, column) - 1
            'Start outer loop.

            'Take a snapshot of the first element
            'in the array because if there is a 
            'smaller value elsewhere in the array 
            'we'll need to do a swap.
            StartingKeyValue = arrArray(row, DimensionToSort)
            StartingOtherValue = arrArray(row, OtherDimension)

            ' Default the Starting values to the First Record
            NewStartingKey = arrArray(row, DimensionToSort)
            NewStartingOther = arrArray(row, OtherDimension)

            swap_pos = row

            For j = row + 1 To UBound(arrArray, column)
                'Start inner loop.
                If arrArray(j, DimensionToSort) < NewStartingKey Then
                    'This is now the lowest number - 
                    'remember it's position.
                    swap_pos = j
                    NewStartingKey = arrArray(j, DimensionToSort)
                    NewStartingOther = arrArray(j, OtherDimension)
                End If
            Next

            If swap_pos <> row Then
                'If we get here then we are about to do a swap
                'within the array.
                arrArray(swap_pos, DimensionToSort) = StartingKeyValue
                arrArray(swap_pos, OtherDimension) = StartingOtherValue

                arrArray(row, DimensionToSort) = NewStartingKey
                arrArray(row, OtherDimension) = NewStartingOther

            End If
        Next
    End Sub

    'http://www.4guysfromrolla.com/webtech/011601-1.shtml

    Public Shared Function And_Add(ByVal s1 As String)
        Dim iPos As Integer
        iPos = InStrRev(s1, ", ")
        If iPos = 0 Then
            And_Add = s1
            Exit Function
        End If
        And_Add = Left(s1, iPos - 1) & " and " & Mid(s1, iPos + 2)
    End Function
End Class
