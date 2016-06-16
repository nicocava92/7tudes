
Partial Class Report_TOC1
    Inherits System.Web.UI.UserControl

    Public Property pSurveyTypeID() As Integer
        Get
            Return Me.SurveyTypeID.Text
        End Get

        Set(ByVal Value As Integer)
            Me.SurveyTypeID.Text = Value
        End Set
    End Property
    Protected Sub tabData_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles tabData.RowDataBound
        Dim L1 As Label

        If e.Row.RowType = DataControlRowType.DataRow Then
        Else
            Exit Sub
        End If

        If IsNumeric(e.Row.DataItem("SectionID")) Then
            e.Row.Cells(0).Font.Bold = True
        Else
            e.Row.Cells(0).Style.Add("padding-left", "20px")
            L1 = e.Row.FindControl("Spacer")
            L1.Visible = False
        End If
    End Sub


End Class
