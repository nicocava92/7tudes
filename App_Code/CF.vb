Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Net
Imports System.Net.Mail
Imports System.Web.Configuration
Imports PPIExceptionHelper
Imports PPIMessagingHelper.PPIMessaging

Public Class CF
    Public Shared Sub Runquery(ByVal s1 As String, Optional ByVal iTimeoutSecs As Integer = 60)
        Dim c1 As SqlClient.SqlConnection, cmd1 As SqlClient.SqlCommand
        Dim sConn As String
        sConn = ConfigurationManager.ConnectionStrings("c7tudes").ConnectionString
        c1 = New SqlClient.SqlConnection(sConn)
        cmd1 = New SqlClient.SqlCommand(s1, c1)
        cmd1.CommandTimeout = iTimeoutSecs
        Try
            c1.Open()
            cmd1.ExecuteNonQuery()
        Catch e As System.Data.SqlClient.SqlException
            s1 = s1 & " Errors: " & e.ToString
            Dim sExResult As String = PPIExceptionTools.HandleException(e, PPIEventType.NonFatalError)
        Catch e As System.Exception
            s1 = s1 & " Errors: " & e.ToString
            Dim sExResult As String = PPIExceptionTools.HandleException(e, PPIEventType.NonFatalError)
        Finally
            c1.Close()
        End Try
    End Sub

    Public Shared Function NullToStringNew(ByVal obj As Object) As String
        If IsNothing(obj) Or IsDBNull(obj) Then
            NullToStringNew = String.Empty
        Else
            NullToStringNew = obj.ToString()
        End If
    End Function
    Public Shared Function NullToString(ByVal obj) As String
        If obj.Equals(DBNull.Value) Then
            NullToString = ""
        Else
            NullToString = obj
        End If

    End Function
    Public Shared Function NullToZero(ByVal obj) As Double
        If obj.Equals(DBNull.Value) Then
            NullToZero = 0
        Else
            NullToZero = obj
        End If

    End Function
    Public Shared Function CleanName(ByVal obj) As String
        Dim objNew As String

        objNew = Replace(obj, "'", "''")
        ' Remove any leading or ending spaces
        objNew = LTrim(objNew)
        objNew = RTrim(objNew)
        CleanName = objNew

    End Function
    Public Shared Function CleanEmail(ByVal obj) As String
        Dim objNew As String

        objNew = Replace(obj, "'", "''")
        ' Remove comma
        'objNew = Replace(objNew, ",", "")
        ' Remove any leading or ending spaces
        objNew = Replace(objNew, " ", "")
        objNew = LTrim(objNew)
        objNew = RTrim(objNew)
        CleanEmail = objNew

    End Function
    Public Shared Sub RunParamQuery(ByVal s1 As String, ByVal aNames() As String, ByVal aValues() As String)
        Dim c1 As SqlClient.SqlConnection, cmd1 As SqlClient.SqlCommand
        Dim sConn As String, i1 As Int16

        sConn = ConfigurationManager.ConnectionStrings("c7tudes").ConnectionString
        'Response.Write(sConn & " " & s1 & "<br>")
        c1 = New SqlClient.SqlConnection(sConn)
        cmd1 = New SqlClient.SqlCommand(s1, c1)


        If aValues.Length > 0 Then
            For i1 = 0 To aValues.Length - 1
                cmd1.Parameters.Add(New System.Data.SqlClient.SqlParameter(aNames(i1), aValues(i1)))
            Next
        End If
        c1.Open()
        cmd1.CommandType = Data.CommandType.StoredProcedure
        cmd1.ExecuteNonQuery()
        c1.Close()
    End Sub

    Public Shared Function DataView_Get(ByVal sSql As String) As System.Data.DataView
        Dim c1 As SqlClient.SqlConnection, cmd1 As SqlClient.SqlCommand
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New System.Data.DataSet

        c1 = New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("c7tudes").ConnectionString)
        cmd1 = New SqlClient.SqlCommand(sSql, c1)
        da.SelectCommand = cmd1
        da.Fill(ds, "tempTable")
        DataView_Get = New DataView(ds.Tables("tempTable"))

        c1.Close()
    End Function
    Public Shared Function RoundIt(ByVal aNumberToRound As Double, Optional ByVal aDecimalPlaces As Double = 0) As Double
        Dim nFactor As Double, nTemp As Double

        nFactor = 10 ^ aDecimalPlaces
        nTemp = (aNumberToRound * nFactor) + 0.5
        RoundIt = Int(CDec(nTemp)) / nFactor

    End Function

    Public Shared Function Email_Send(ByVal sFrom As String, ByVal sRecipient As String, ByVal sCC As String, _
                                ByVal sSubject As String, ByVal sBody As String, Optional sAttachmentNames() As String = Nothing) As String
        Return (Email_Send(sFrom, sRecipient, sCC, sSubject, sBody, PPIMessageType.Other, sAttachmentNames))

    End Function

    Public Shared Function Email_Send(ByVal sFrom As String, ByVal sRecipient As String, ByVal sCC As String, _
                                 ByVal sSubject As String, ByVal sBody As String, eMsgType As PPIMessageType, Optional sAttachmentNames() As String = Nothing) As String
        Dim sSendResult As String
        Dim objFrom As PPIMailAddress = New PPIMailAddress()
        objFrom.EmailAddress = sFrom

        Try
            sSendResult = PPIMessagingTools.SendEmail(objFrom, sRecipient.Replace(",", ";"), sCC, String.Empty, sSubject, sBody, eMsgType, sAttachmentNames)
        Catch ex As Exception
            sSendResult = ex.Message
            Dim sExResult As String = PPIExceptionTools.HandleException(ex, PPIEventType.NonFatalError)
        End Try

        Return (sSendResult)
    End Function

    'Public Shared Sub Email_Send(ByVal from As String, ByVal recipient As String, ByVal cc As String, _
    '                                 ByVal subject As String, ByVal body As String, Optional sAttachmentName() As String = Nothing)

    '    Dim message As New System.Net.Mail.MailMessage

    '    Try

    '        ' From
    '        message.From = New System.Net.Mail.MailAddress(From_Get(from, recipient), "")

    '        ' Recipient(s)
    '        If recipient <> "" Then

    '            If recipient.Contains(",") Or recipient.Contains(";") Then

    '                ' Change all delimiters to semicolon
    '                recipient.Replace(",", ";")

    '                ' Parse and add multiple recipients
    '                Dim RecipientArray() As String = Split(recipient, ";")

    '                For i As Integer = 0 To RecipientArray.Length - 1
    '                    message.To.Add(NullToStringNew(RecipientArray(i)).Trim())
    '                Next

    '            Else

    '                ' Add single recipient
    '                message.To.Add(NullToStringNew(recipient).Trim())

    '            End If

    '        End If

    '        ' Bcc
    '        message.Bcc.Add(ConfigurationManager.AppSettings("bcc"))

    '        ' Subject
    '        message.Subject = subject
    '        message.SubjectEncoding = System.Text.Encoding.UTF8

    '        ' Body
    '        message.Body = body
    '        message.IsBodyHtml = True
    '        message.BodyEncoding = System.Text.Encoding.UTF8

    '        ' Optional Attachment
    '        If sAttachmentName IsNot Nothing Then
    '            For i1 As Integer = 0 To UBound(sAttachmentName)
    '                If sAttachmentName(i1) <> "" Then
    '                    message.Attachments.Add(New System.Net.Mail.Attachment(sAttachmentName(i1)))
    '                End If
    '            Next
    '        End If

    '        ' SmtpClient
    '        Dim smtp As SmtpClient = New System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings("smtpserver"))
    '        smtp.Credentials = New NetworkCredential(ConfigurationManager.AppSettings("sender"), _
    '                                  ConfigurationManager.AppSettings("smtppassword"))
    '        ' Send
    '        smtp.Send(message)

    '    Catch ex As Exception
    '        Dim sExResult As String = PPIExceptionTools.HandleException(ex, PPIEventType.NonFatalError)
    '        Throw New ArgumentException("Email_Send Exception Occured")
    '    End Try

    'End Sub

    Public Shared Function IsValidEmailAddress(s1 As String, sType As String, sBody As String) As Boolean
        Dim mailAddress As System.Net.Mail.MailAddress
        Dim a1() As String, i1 As Integer

        a1 = Split(s1, ";")
        Try
            For i1 = 0 To UBound(a1)
                If Trim(a1(i1)) <> "" Then
                    mailAddress = New System.Net.Mail.MailAddress(a1(i1))
                    IsValidEmailAddress = True
                End If
            Next

        Catch ex As Exception
            Dim sExResult As String = PPIExceptionTools.HandleException(ex, PPIEventType.NonFatalError)
            'CF.Email_Send(ConfigurationManager.AppSettings("sender"), "", "", "7 Tudes Bad Email Address Error - " & sType & " " & s1, sBody)
            IsValidEmailAddress = False
        End Try

    End Function
    Public Shared Function From_Get(sFrom As String, sTo As String) As String
        Dim sFromDomain As String, sToDomain As String, i1 As Integer
        Dim dvD As System.Data.DataView

        sFromDomain = Replace(Mid(sFrom, InStr(sFrom, "@") + 1), ">", "")
        sToDomain = Replace(Mid(sTo, InStr(sTo, "@") + 1), ">", "")
        System.Web.HttpContext.Current.Trace.Warn(sFromDomain)
        System.Web.HttpContext.Current.Trace.Warn(sToDomain)

        'If UCase(sFromDomain) = UCase(sToDomain) Then
        'dvD = Domains.DomainsList_Get()
        'System.Web.HttpContext.Current.Trace.Warn("Count=" & dvD.Table.Rows.Count)
        'For i1 = 0 To dvD.Table.Rows.Count - 1
        'If UCase(dvD.Table.Rows(i1)("DomainName")) = UCase(sFromDomain) Then
        'From_Get = ConfigurationManager.AppSettings("sender")
        'System.Web.HttpContext.Current.Trace.Warn("AAA " & ConfigurationManager.AppSettings("sender"))
        'Exit Function
        'End If
        'Next
        'End If

        'If UCase(sFromDomain) = UCase(sToDomain) Then
        dvD = Domains.DomainsList_Get()
        System.Web.HttpContext.Current.Trace.Warn("Count=" & dvD.Table.Rows.Count)
        For i1 = 0 To dvD.Table.Rows.Count - 1
            If UCase(dvD.Table.Rows(i1)("DomainName")) = UCase(sToDomain) Then
                From_Get = ConfigurationManager.AppSettings("sender")
                System.Web.HttpContext.Current.Trace.Warn("AAA " & ConfigurationManager.AppSettings("sender"))
                Exit Function
            End If
        Next
        'End If

        System.Web.HttpContext.Current.Trace.Warn("BBB " & sFrom)

        From_Get = sFrom

    End Function
    Public Shared Function MaxDay(ByVal iMonth As Integer, ByVal iYear As Integer) As Integer
        Select Case iMonth
            Case 1, 3, 5, 7, 8, 10, 12
                MaxDay = 31
            Case 4, 6, 9, 11
                MaxDay = 30
            Case 2
                If (iYear Mod 4) = 0 Then
                    MaxDay = 29
                Else
                    MaxDay = 28
                End If
        End Select
    End Function
    Public Shared Function FlipName(ByVal s1 As String) As String
        'change "Kaiser, Rob' to "Rob Kaiser"
        Dim a1 As Array
        a1 = Split(s1, ",")
        If a1.Length = 2 Then
            FlipName = Trim(a1(1)) & " " & Trim(a1(0))
        Else
            FlipName = s1
        End If
    End Function
    Public Shared Function fsDate(ByVal dDate As DateTime) As String
        Dim sCulture As String
        sCulture = "es-Mx"

        fsDate = dDate.ToString("d", New System.Globalization.CultureInfo(sCulture))

    End Function
    Public Shared Function FileExists(ByVal FileFullPath As String) As Boolean

        Dim f As New IO.FileInfo(FileFullPath)
        Return f.Exists
    End Function
    Public Shared Function JustFileName(ByVal sFullFileName As String) As String
        JustFileName = Mid(sFullFileName, InStrRev(sFullFileName, "\") + 1)
    End Function
    Public Shared Sub File_Delete(ByVal FileFullPath As String)
        Dim f As New IO.FileInfo(FileFullPath)
        f.Delete()
    End Sub
    Public Shared Sub File_Rename(ByVal fromFileFullPath As String, tofilefullpath As String)
        If CF.FileExists(fromFileFullPath) Then
            If Not CF.FileExists(tofilefullpath) Then
                System.IO.File.Move(fromFileFullPath, tofilefullpath)
            Else
                CF.Email_Send(ConfigurationManager.AppSettings("sender"), "", "", "Dest file exists Error", fromFileFullPath & " ====> " & tofilefullpath)
            End If
        End If

    End Sub

End Class
