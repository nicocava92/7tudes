
Partial Class Norms_Radio
    Inherits System.Web.UI.UserControl

    Const cMaxWidth = 350
    Public Property pShowQNo() As String
        Get
            Return ShowQNo.Text
        End Get

        Set(ByVal Value As String)
            ShowQNo.Text = Value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Norms_Show()
    End Sub


    Sub Norms_Show()
        Dim dv As System.Data.DataView, dr As System.Data.DataRowView
        Dim i1 As Integer, hr1 As Image
        Dim tr1 As HtmlTableRow, tc1 As HtmlTableCell
        dv = Me.cNormData.Select(DataSourceSelectArguments.Empty)
        For Each dr In dv
            For i1 = 1 To 9
                If CF.NullToString(dr("Choice" & i1)) <> "" Then
                    tr1 = New HtmlTableRow
                    Me.tabNorm.Rows.Add(tr1)

                    'Choice text
                    tc1 = New HtmlTableCell
                    tr1.Cells.Add(tc1)
                    tc1.Width = 325
                    tc1.InnerText = dr("Choice" & i1)

                    'Norm percent
                    tc1 = New HtmlTableCell
                    tr1.Cells.Add(tc1)
                    tc1.Align = "Right"
                    tc1.Width = 25
                    tc1.InnerText = dr("Norm" & i1) & "%"

                    'Bar 
                    tc1 = New HtmlTableCell
                    tr1.Cells.Add(tc1)
                    tc1.Width = 350
                    hr1 = New Image
                    tc1.Controls.Add(hr1)
                    hr1.ImageUrl = "../images/bar.jpg"
                    hr1.Height = "6"
                    hr1.Width = CLng(cMaxWidth * CInt(dr("Norm" & i1)) / 100)
                End If
            Next
        Next
    End Sub
End Class
