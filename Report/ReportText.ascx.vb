
Partial Class SelfRpt_ReportText
    Inherits System.Web.UI.UserControl

    Public Property pPID() As Integer
        Get
            Return PID.Text
        End Get

        Set(ByVal Value As Integer)
            PID.Text = Value
        End Set
    End Property

    Public Property pSectionName() As String
        Get
            Return SectionName.Text
        End Get

        Set(ByVal Value As String)
            SectionName.Text = Value
        End Set
    End Property

    Protected Sub tabText_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles tabText.RowDataBound
        Dim L1 As Label, div1 As HtmlGenericControl
        If e.Row.RowType = DataControlRowType.DataRow Then
            L1 = e.Row.FindControl("Heading1")
            If CF.NullToString(e.Row.DataItem("Content1")) = "" Then
                L1.CssClass = "heading2"
                div1 = e.Row.FindControl("space1")
                div1.Visible = False
            ElseIf L1.Text = "" Then
                div1 = e.Row.FindControl("space1")
                div1.Visible = False
            Else
                L1.Font.Bold = True
            End If
        End If
    End Sub

    Function fsHtml(ByVal s1 As String)
        fsHtml = Replace(S1, vbCrLf, "<br>")
    End Function
End Class
