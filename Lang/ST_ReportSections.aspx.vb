
Partial Class Lang_ST_ReportSections
    Inherits System.Web.UI.Page
    Dim T1 As TextBox, l1 As Label
    Protected Sub tabA_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles tabA.RowCommand
        If e.CommandName = "Save" Then
            Data_Save()
        End If
    End Sub

    Sub Data_Save()
        Dim gr As GridViewRow, T1 As TextBox, sSql As String, L1 As Label

        For Each gr In Me.tabA.Rows
            If gr.RowType = DataControlRowType.DataRow Then
                L1 = gr.FindControl("RecordID")

                sSql = "Update ST_ReportSections Set "

                T1 = gr.FindControl("ReportCategory")
                sSql &= " ReportCategory=N'" & Replace(T1.Text, "'", "''") & "'"

                sSql = sSql & " where RecordID=" & L1.Text
                Trace.Warn(sSql)
                CF.Runquery(sSql)
            End If
        Next
        Me.Message.Text = "Your changes have been saved."
    End Sub

    Protected Sub tabA_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles tabA.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
        Else
            Exit Sub
        End If

        l1 = e.Row.FindControl("EnglishReportCategory")
        If l1.Text = "" Then
            T1 = e.Row.FindControl("ReportCategory")
            T1.Visible = False
        End If

        Lang.lang_count(e)
    End Sub

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.txtSearch.Text = Server.UrlDecode(Request.Cookies("txtSearch").Value)
        If Request.Cookies("txtSearch").Value = "zz" Then
            Me.CurrentSearch.Text = "none"
        Else
            Me.CurrentSearch.Text = Server.UrlDecode(Request.Cookies("txtSearch").Value)
        End If
    End Sub
End Class
