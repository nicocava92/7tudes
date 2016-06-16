
Partial Class Lang_Lang
    Inherits System.Web.UI.MasterPage

    Protected Sub btnLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        Cookies_Reset()
        Response.Redirect("default.aspx")
    End Sub

    Protected Sub TableName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TableName.SelectedIndexChanged
        Trace.Warn(Me.TableName.SelectedValue)
        Response.Redirect(Me.TableName.SelectedValue)
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim sName As String
        sName = UCase(Request.ServerVariables("SCRIPT_NAME"))
        If InStr(sName, "DEFAULT.ASPX") > 0 Or InStr(sName, "SEARCH.ASPX") > 0 Then
            Me.div1.Visible = False
        Else
            Me.div1.Visible = True
        End If
        If InStr(sName, "DEFAULT.ASPX") > 0 Then
            Cookies_Reset()
        Else
            Trace.Warn(Request.Cookies.Count)
            If Request.Cookies.Count = 0 Then
                Response.Redirect("Default.aspx?1")
            ElseIf Request.Cookies(0).Value = "" Then
                'Thanks reload comes here
                Response.Redirect("Default.aspx?2")
            Else
                Me.LanguageName.Text = Request.Cookies("LanguageName").Value
            End If
        End If
    End Sub

    Sub Cookies_Reset()
        Dim i1 As Integer
        Trace.Warn(Request.Cookies.Count & " >> " & Response.Cookies.Count)
        'For i1 = 0 To Request.Cookies.Count - 1
        '    Response.Cookies(Request.Cookies(i1).Name).Value = ""
        'Next
        Request.Cookies.Clear()
        Trace.Warn("Master Cookies cleared")
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then TableName_Select()

        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1D)
        Response.Expires = -1500
        Response.CacheControl = "no-cache"

    End Sub

    Sub TableName_Select()
        Dim i1 As Integer, sName As String

        sName = UCase(Request.ServerVariables("SCRIPT_NAME"))
        Trace.Warn(sName)
        For i1 = 0 To Me.TableName.Items.Count - 1
            If InStr(sName, UCase(Me.TableName.Items(i1).Value)) > 0 Then
                Me.TableName.SelectedIndex = i1
                Trace.Warn(Me.TableName.SelectedValue)
                Exit Sub
            End If
        Next
    End Sub
End Class

