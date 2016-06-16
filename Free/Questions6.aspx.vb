
Partial Class Free_Questions6
    Inherits System.Web.UI.Page


    Sub Response_Save()
        Dim sSql As String, sFrom As String, sTo As String
        Dim iGroupCode As Integer, PID As Long
        Dim dv1 As System.Data.DataView

        iGroupCode = 7868

        sTo = ""
        sFrom = ""

        Dim grid1 As GridView
        Dim gr As GridViewRow, lQNo As Label, resp1 As RadioButtonList

        sSql = ""
        grid1 = Me.tabQ
        For Each gr In grid1.Rows
            If gr.RowType = DataControlRowType.DataRow Then
                lQNo = gr.FindControl("QNo")
                resp1 = gr.FindControl("Resp")
                Trace.Warn(lQNo.Text & "=" & resp1.SelectedValue)
                sFrom = resp1.SelectedValue
                sTo = "Q" & lQNo.Text
            End If
        Next

        'Trace.Warn("TO: " & sTo)
        'Trace.Warn("FROM: " & sFrom)

        'sSql = "Exec Free_Insert " & iGroupCode & ", '" & Replace(sFrom, "'", "''") & "', '" & sTo & "'"
        sSql = "Update Responses Set " & sTo & " = " & sFrom & " where RespID=(select Top 1 RespID from Responses where tempPID='" & Request.Cookies("PID").Value & "')"
        'Trace.Warn(sSql)
        dv1 = CF.DataView_Get(sSql)
        'PID = dv1.Table.Rows(0)("PID")
        'Trace.Warn(PID)
        'Response.Cookies("PID").Value = PID
        Response.Redirect("Questions7.aspx")

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
        L1.Text = e.Row.RowIndex + 6 & ". "
    End Sub
End Class
