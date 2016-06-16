
Imports PPIExceptionHelper

Partial Class ExceptionTest
    Inherits System.Web.UI.Page

    Protected Sub btnUnhandled_Click(sender As Object, e As EventArgs) Handles btnUnhandled.Click
        Dim i As Integer = 0
        Dim j As Integer = 9 / i

        'global.asax will handle the error

    End Sub

    Protected Sub btnHandledFatal_Click(sender As Object, e As EventArgs) Handles btnHandledFatal.Click

        Try
            Dim i As Integer = 0
            Dim j As Integer = 9 / i
        Catch ex As Exception
            Dim sResult As String = PPIExceptionTools.HandleException(ex, PPIEventType.FatalError)
            Response.Write(sResult)
            System.Diagnostics.Debug.WriteLine(sResult)
        End Try

    End Sub

    Protected Sub btnHandledNonFatal_Click(sender As Object, e As EventArgs) Handles btnHandledNonFatal.Click
        Try
            Dim i As Integer = 0
            Dim j As Integer = 9 / i
            'CF.Runquery("sdfasdafsdf", 60)
        Catch ex As Exception
            Dim sResult As String = PPIExceptionTools.HandleException(ex, PPIEventType.NonFatalError)

            Response.Write(String.Format("Return value from exception service (empty string is good): {0}", sResult))
            System.Diagnostics.Debug.WriteLine(sResult)
        End Try

    End Sub

    Protected Sub btnLogEvent_Click(sender As Object, e As EventArgs) Handles btnLogEvent.Click

        Dim sResult As String = PPIExceptionTools.LogEvent("This is a test of logging an event")

        Response.Write(String.Format("Return value from exception service (empty string is good): {0}", sResult))
        System.Diagnostics.Debug.WriteLine(sResult)

    End Sub


End Class
