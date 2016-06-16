Imports Microsoft.VisualBasic

Public Class Lang
    Public Shared Sub lang_count(e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Dim i1 As Integer, j1 As Integer, L1 As Label, T1 As TextBox
        For j1 = 0 To e.Row.Cells.Count - 1
            For i1 = 0 To e.Row.Cells(j1).Controls.Count - 1
                If e.Row.Cells(j1).Controls(i1).GetType.ToString = "System.Web.UI.WebControls.TextBox" Then
                    T1 = e.Row.Cells(j1).Controls(i1)
                    L1 = e.Row.Cells(j1).FindControl("charsleft" & T1.SkinID)
                    System.Web.HttpContext.Current.Trace.Warn(T1.ID)
                    System.Web.HttpContext.Current.Trace.Warn(L1.ID)

                    If T1.Visible Then
                        T1.Attributes.Add("onkeyup", "count_show('" & T1.ClientID & "', " & Len(e.Row.DataItem("English" & T1.ID)) & ", '" & L1.ClientID & "');")

                        'Grow the TextBox
                        If Len(T1.Text) > T1.Columns Then
                            T1.TextMode = TextBoxMode.MultiLine
                            T1.Rows = Len(T1.Text) / T1.Columns + 2
                        End If

                        'If System.Web.HttpContext.Current.Request.Cookies("txtSearch") Is Nothing Then
                        'ElseIf System.Web.HttpContext.Current.Request.Cookies("txtSearch").Value = "" Then
                        'Else
                        '    If InStr(LCase(T1.Text), LCase(System.Web.HttpContext.Current.Request.Cookies("txtSearch").Value)) > 0 Then
                        '        e.Row.Cells(0).CssClass = "langsearch"
                        '    Else
                        '        L1 = e.Row.FindControl("English" & T1.ID)
                        '        If InStr(LCase(L1.Text), LCase(System.Web.HttpContext.Current.Request.Cookies("txtSearch").Value)) > 0 Then
                        '            e.Row.Cells(0).CssClass = "langsearch"
                        '        End If
                        '    End If
                        'End If


                        '#lang
                        If InStr(T1.Text, "#lang") > 0 Then
                            If e.Row.CssClass <> "langsearch" Then
                                e.Row.Cells(0).CssClass = "langmissing"
                            End If

                        End If
                    Else

                    End If

                End If
            Next
        Next
    End Sub
End Class
