Imports Microsoft.VisualBasic

Public Class Baseclass
    Inherits System.Web.UI.Page
    Protected Overrides Sub InitializeCulture()
        Dim _culture As String
        If Request.Cookies("txtCulture") Is Nothing Then
            _culture = "en-US"
        Else
            _culture = Request.Cookies("txtCulture").Value
        End If
        Dim ci As New System.Globalization.CultureInfo(_culture)
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        System.Threading.Thread.CurrentThread.CurrentUICulture = ci
        MyBase.InitializeCulture()
    End Sub


    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        Dim sCurrent As String

        MyBase.OnInit(e)

        sCurrent = fsCurrent()
        If sCurrent <> "" Then
            ViewStateUserKey = "!@" & sCurrent & "*^"
        End If

    End Sub

    Function fsCurrent() As String
        If Request.Cookies.Count = 0 Then
            fsCurrent = ""
        ElseIf Request.Cookies("GroupCode") Is Nothing Then
            fsCurrent = ""
        Else
            fsCurrent = Request.Cookies("GroupCode").Value
            If Request.Cookies("ParticipantID") Is Nothing Then
                'for register page
                fsCurrent = fsCurrent & "-999-999"
            Else
                fsCurrent = fsCurrent & "-" & Request.Cookies("ParticipantID").Value
                fsCurrent = fsCurrent & "-" & Request.Cookies("RaterID").Value
            End If


        End If

    End Function
End Class
