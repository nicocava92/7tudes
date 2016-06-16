
Partial Class Free_Questions1
    Inherits System.Web.UI.Page


    Sub Response_Save()
        Dim sSql As String, sFrom As String, sTo As String
        Dim iGroupCode As Integer, PID As Long
        Dim dv1 As System.Data.DataView

        iGroupCode = 7868

        sTo = "IPAddress"
        sFrom = "'" & Request.ServerVariables("REMOTE_ADDR") & "'"

        Dim grid1 As GridView
        Dim gr As GridViewRow, lQNo As Label, resp1 As RadioButtonList

        sSql = ""
        grid1 = Me.tabQ
        For Each gr In grid1.Rows
            If gr.RowType = DataControlRowType.DataRow Then
                lQNo = gr.FindControl("QNo")
                resp1 = gr.FindControl("Resp")
                Trace.Warn(lQNo.Text & "=" & resp1.SelectedValue)
                sFrom = sFrom & ", " & resp1.SelectedValue
                sTo = sTo & ", Q" & lQNo.Text
            End If
        Next

        Trace.Warn(sTo)
        Trace.Warn(sFrom)

        sSql = "Exec Free_Insert " & iGroupCode & ", '" & Replace(sFrom, "'", "''") & "', '" & sTo & "'"
        Trace.Warn(sSql)
        dv1 = CF.DataView_Get(sSql)
        PID = dv1.Table.Rows(0)("PID")
        Trace.Warn(PID)
        Response.Cookies("PID").Value = PID
        Response.Redirect("Demographics.aspx")

    End Sub




    Protected Sub headrow_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles headrow.PreRender
        Dim TR As HtmlTableRow, tc As HtmlTableCell, i1 As Integer, dvQ As System.Data.DataView

        TR = Me.headrow
        If dvQ Is Nothing Then
            Trace.Warn("Prerender dvQ")
            dvQ = Me.rsQ.Select(DataSourceSelectArguments.Empty)
        End If

        For i1 = 1 To 7
            tc = New HtmlTableCell
            TR.Cells.Add(tc)
            tc.VAlign = "bottom"
            tc.Align = "center"
            'tc.Width = 86 '600/7
            tc.InnerHtml = "<strong>" & dvQ.Table.Rows(0)("RespText" & i1) & "</strong>"
        Next
    End Sub

    Protected Sub tabQ_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles tabQ.RowCommand
        If e.CommandName = "Next" Then
            Response_Save()
        End If
    End Sub

    Protected Sub tabQ_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles tabQ.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
        Else
            Exit Sub
        End If

        Dim L1 As Label
        L1 = e.Row.FindControl("ShowQNo")
        L1.Text = e.Row.RowIndex + 1 & ". "
    End Sub
End Class
