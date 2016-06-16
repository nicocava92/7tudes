
Partial Class Lang_CommentQ
    Inherits System.Web.UI.Page
    Dim L1 As Label, T1 As TextBox

    Protected Sub tabA_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles tabA.RowCommand
        If e.CommandName = "Save" Then
            Data_Save()
        End If
    End Sub

    Sub Data_Save()
        Dim gr As GridViewRow, T1 As TextBox, sSql As String, L1 As Label

        For Each gr In Me.tabA.Rows
            If gr.RowType = DataControlRowType.DataRow Then
                L1 = gr.FindControl("AutoID")

                sSql = "Update Questions_Comment Set "

                T1 = gr.FindControl("Question_Self")
                If T1.Text = "" Then
                    sSql &= " Question_Self=Null"
                Else
                    sSql &= " Question_Self=N'" & Replace(T1.Text, "'", "''") & "'"
                End If


                T1 = gr.FindControl("Question_Raters")
                If T1.Text = "" Then
                    sSql &= ", Question_Raters=Null"
                Else
                    sSql &= ", Question_Raters=N'" & Replace(T1.Text, "'", "''") & "'"
                End If
                'sSql &= ", Question_Raters=N'" & Replace(T1.Text, "'", "''") & "'"

                T1 = gr.FindControl("Question_Family")
                If T1.Text = "" Then
                    sSql &= ", Question_Family=Null"
                Else
                    sSql &= ", Question_Family=N'" & Replace(T1.Text, "'", "''") & "'"
                End If
                'sSql &= ", Question_Family=N'" & Replace(T1.Text, "'", "''") & "'"

                sSql = sSql & " where AutoID=" & L1.Text
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

        L1 = e.Row.FindControl("EnglishQuestion_Raters")
        If L1.Text = "" Then
            T1 = e.Row.FindControl("Question_Raters")
            T1.Visible = False
        End If

        L1 = e.Row.FindControl("EnglishQuestion_Family")
        If L1.Text = "" Then
            T1 = e.Row.FindControl("Question_Family")
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
