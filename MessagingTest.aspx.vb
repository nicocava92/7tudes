Imports PPIMessagingHelper.PPIMessaging

Partial Class MessagingTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim sFrom As String = "surverys@performanceprograms.com"
        Dim sTo As String = "clifford@spielman.com "    'added space
        Dim sBody As String = "Test message from Cliff.  This is the body of the message."
        Dim sSubject As String = "Test message from Cliff"

        Dim arrAtt(0) As String

        arrAtt(0) = Server.MapPath("~/reports/11119-1348 Michelle Parker.pdf")
        'arrAtt(1) = Server.MapPath("~/reports/11119-1348 Michelle Parker(ST).pdf")
        'arrAtt(2) = Server.MapPath("~/reports/All 11119 Reports.zip")

        Dim sSendResult As String = CF.Email_Send(sFrom, sTo, "", "Test message from Cliff", sBody)     'test with an attachment

        'Dim objClient As PPIMessagingHelper.PPIMessaging.PPIMessagingTools = New PPIMessagingHelper.PPIMessaging.PPIMessagingTools()
        'Dim arrAtt(1) As String

        'arrAtt(0) = Server.MapPath("~/reports/11119-1348 Michelle Parker.pdf")
        'arrAtt(1) = Server.MapPath("~/reports/11119-1348 Michelle Parker(ST).pdf")
        'Dim objFrom As PPIMailAddress = New PPIMailAddress()
        'objFrom.EmailAddress = "surverys@performanceprograms.com"
        'objFrom.EmailName = "Test Person"

        'Dim sSendResult As String = PPIMessagingTools.SendEmail(objFrom, sTo, String.Empty, String.Empty, sSubject, sBody, arrAtt)

        Response.Write(String.Format("<br/>Send Result: {0}", sSendResult))

    End Sub
End Class
