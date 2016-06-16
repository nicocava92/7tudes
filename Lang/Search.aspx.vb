
Partial Class Lang_Search
    Inherits System.Web.UI.Page
   

    Protected Sub btnSearch_Click(sender As Object, e As System.EventArgs) Handles btnSearch.Click

        If Me.txtSearch.Text = "" Then
            Response.Cookies("txtSearch").Value = "zz"
        Else
            Response.Cookies("txtSearch").Value = Server.UrlEncode(Me.txtSearch.Text)

        End If


        Me.rsA.DataBind()
        Me.tabA.DataBind()
    End Sub

    Protected Sub tabA_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles tabA.RowDataBound
        Dim hl1 As HyperLink


        If e.Row.RowType = DataControlRowType.DataRow Then
            hl1 = e.Row.Cells(0).FindControl("HyperLink1")
            'If InStr(LCase(hl1.NavigateUrl), "surveylabels.aspx") > 0 Then
            '    If InStr(LCase(e.Row.Cells(1).Text), "rpt_") > 0 Then
            '        Trace.Warn(hl1.NavigateUrl & " " & e.Row.Cells(1).Text)
            '        hl1.NavigateUrl = Replace(hl1.NavigateUrl, "Type=S", "Type=R")
            '        hl1.Text = hl1.NavigateUrl
            '    End If
            'End If

            'If InStr(LCase(hl1.NavigateUrl), "demovalues.aspx") > 0 Then
            '    hl1.NavigateUrl &= "?DemoNo=" & e.Row.Cells(1).Text
            '    hl1.Text = hl1.NavigateUrl
            'End If

            'If InStr(LCase(hl1.NavigateUrl), "questions_health_scale.aspx") > 0 Then
            '    hl1.NavigateUrl &= "?QNo=" & e.Row.Cells(1).Text
            '    hl1.Text = hl1.NavigateUrl
            'End If
        End If
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As System.EventArgs) Handles btnClear.Click
        Me.txtSearch.Text = ""
        btnSearch_Click(sender, e)
    End Sub
End Class
