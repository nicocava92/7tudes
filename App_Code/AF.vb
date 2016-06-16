Imports Microsoft.VisualBasic
Imports System.Web.HttpContext
Public Class AF

    Public Shared Sub Email_Process(ByVal drRater As System.Data.DataRow, ByVal drE As System.Data.DataRow, ByVal IsInvite As Boolean)
        Dim sSql As String
        Dim sSurveyList As String, dv1 As System.Data.DataView
        Dim sDueDate As String, dDueDate As DateTime, i1 As Integer
        Dim sSubject As String, sMessage As String, sUrl As String

        If IsInvite Then
            sSubject = drE("Subject")
            sMessage = drE("Message")
        Else
            sSubject = drE("ReminderSubject")
            sMessage = drE("ReminderMessage") & "<br><br>" & drE("Message")
        End If

        sUrl = ConfigurationManager.AppSettings("URL")
        sUrl &= "/" & drRater("BrandCode") & ".aspx"
        If drRater("RelID") = 1 Then sUrl &= "?self"

        'Substitutions
        sMessage = Replace(sMessage, "|ParticipantName|", drRater("FirstName") & " " & drRater("LastName"))
        sMessage = Replace(sMessage, "|GroupCode|", drRater("GroupCode"))
        sMessage = Replace(sMessage, "|ParticipantID|", drRater("ParticipantID"))
        sMessage = Replace(sMessage, "|RaterPassword|", drRater("RaterPassword"))
        sMessage = Replace(sMessage, "|URL|", sUrl)
        dDueDate = drE("DueDate")
        sDueDate = dDueDate.ToString("MMM dd, yyyy")
        sMessage = Replace(sMessage, "|DueDate|", sDueDate)

        'SurveyList
        If drE("RelID") = 1 Then
            If InStr(sMessage, "|SurveysList|") > 0 Then
                sSurveyList = "<ul>"

                sSql = "Select * from qryresponseStatus where surveyTypeID<>5 "
                sSql = sSql & " and GroupCode=" & drRater("GroupCode")
                sSql = sSql & " and ParticipantID=" & drRater("ParticipantID")
                sSql = sSql & " and RaterPassword=" & drRater("RaterPassword")
                sSql = sSql & " and CycleID=" & drRater("CycleID")
                sSql = sSql & " order by SurveyTypeID"

                dv1 = CF.DataView_Get(sSql)
                For i1 = 0 To dv1.Table.Rows.Count - 1
                    sSurveyList = sSurveyList & "<li>"
                    sSurveyList = sSurveyList & dv1.Table.Rows(i1)("SurveyTypeName")
                    If Not IsInvite Then
                        If CF.NullToString(dv1.Table.Rows(i1)("DateEntered")) = "" Then
                            sSurveyList = sSurveyList & " - not started"
                        ElseIf CF.NullToString(dv1.Table.Rows(i1)("DateCompleted")) = "" Then
                            dDueDate = dv1.Table.Rows(i1)("DateEntered")
                            sDueDate = dDueDate.ToString("MMM dd, yyyy")
                            sSurveyList = sSurveyList & " - started on " & sDueDate
                        Else
                            dDueDate = dv1.Table.Rows(i1)("DateCompleted")
                            sDueDate = dDueDate.ToString("MMM dd, yyyy")
                            sSurveyList = sSurveyList & " - completed on " & sDueDate
                        End If
                    End If
                    sSurveyList = sSurveyList & "</li>"
                Next
                sSurveyList = sSurveyList & "</ul>"
                sMessage = Replace(sMessage, "|SurveysList|", sSurveyList)
                System.Web.HttpContext.Current.Trace.Warn(sMessage)
            End If

        Else
            'rater
            sMessage = Replace(sMessage, "|RaterName|", drRater("RaterFirstName") & " " & drRater("RaterLastName"))
        End If
       

        'Format message
        System.Web.HttpContext.Current.Trace.Warn(sMessage)

        sMessage = Replace(sMessage, vbCrLf, "<br>")

        'Send message
        'update date code
        If drE("RelID") > 1 Then
            CF.Email_Send(drRater("ParticipantEmailAddress"), drRater("EmailAddress"), "", sSubject, sMessage)
            sSql = "Update Raters set "
        Else
            CF.Email_Send(ConfigurationManager.AppSettings("sender"), drRater("EmailAddress"), "", sSubject, sMessage)
            sSql = "Update Participants Set "
        End If
        If IsInvite Then
            sSql = sSql & " emaildate"
        Else
            sSql = sSql & " reminderdate"
        End If
        sSql = sSql & "=getDate() where 1=1"
        sSql = sSql & " and GroupCode=" & drRater("GroupCode")
        sSql = sSql & " and CycleID=" & drRater("CycleID")
        sSql = sSql & " and ParticipantID =" & drRater("ParticipantID")
        If drE("RelID") = 1 Then
        Else
            sSql = sSql & " and RaterPassword=" & drRater("RaterPassword")
        End If


        CF.Runquery(sSql)
    End Sub

    Public Shared Function fsZipFileName(ByVal iGroupCode As Long, Optional ByVal sType As String = "") As String
        Dim sFolderName As String

        sFolderName = ConfigurationManager.AppSettings("ReportsFolderName")
        fsZipFileName = sFolderName & iGroupCode & "_Reports"
        If sType <> "" Then
            fsZipFileName = fsZipFileName & "_" & sType
        End If
        fsZipFileName = fsZipFileName & ".zip"

    End Function

    Public Shared Function fsReportFileName(ByVal sGroupCode As String, ByVal sParticipantID As String, ByVal sParticipantName As String, ByVal sSuffix As String) As String
        Dim sTemp As String
        sTemp = Replace(sParticipantName, "/", " ")
        sTemp = Replace(sTemp, "\", " ")

        fsReportFileName = ConfigurationManager.AppSettings("ReportsFolderName")
        fsReportFileName = fsReportFileName & sGroupCode & "-" & sParticipantID
        fsReportFileName = fsReportFileName & " " & sTemp 'sParticipantName
        fsReportFileName = fsReportFileName & sSuffix
        fsReportFileName = fsReportFileName & ".pdf"

        fsReportFileName = Replace(fsReportFileName, "*", " ")
        fsReportFileName = Replace(fsReportFileName, ":", " ")
        'fsReportFileName = Replace(fsReportFileName, "/", " ")
        'fsReportFileName = Replace(fsReportFileName, "\", " ")
        fsReportFileName = Replace(fsReportFileName, Chr(34), " ")
        fsReportFileName = Replace(fsReportFileName, vbTab, "")
    End Function

    Public Shared Sub Report_Process(ByVal PID As Long)
        Dim sUrl As String, wreq, wresp

        'Calculate 
        CF.Runquery("Exec Batch_Calc '" & PID & "'")

        'Generate
        sUrl = ConfigurationManager.AppSettings("url_report") & "Report_PDF.aspx?"
        sUrl &= "PIDList=" & PID & "&A=" & Now.Second()

        System.Web.HttpContext.Current.Trace.Warn(Today & " == " & sUrl)
        wreq = System.Net.HttpWebRequest.Create(sUrl)
        wresp = wreq.BeginGetResponse(Nothing, Nothing)

    End Sub

    Public Shared Function fsEncrypt(ByVal RaterID As String) As String
        Dim i1 As Integer
        fsEncrypt = ""
        For i1 = 1 To Len(RaterID)
            fsEncrypt &= Chr(97 + Mid(RaterID, i1, 1))
        Next
    End Function


    Public Shared Sub lang_count(e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Dim i1 As Integer, j1 As Integer, L1 As Label, T1 As TextBox
        For j1 = 0 To e.Row.Cells.Count - 1
            For i1 = 0 To e.Row.Cells(j1).Controls.Count - 1
                If e.Row.Cells(j1).Controls(i1).GetType.ToString = "System.Web.UI.WebControls.TextBox" Then
                    T1 = e.Row.Cells(j1).Controls(i1)
                    L1 = e.Row.Cells(j1).FindControl("charsleft" & T1.SkinID)
                    If T1.Visible Then
                        T1.Attributes.Add("onkeyup", "count_show('" & T1.ClientID & "', " & Len(e.Row.DataItem("English" & T1.ID)) & ", '" & L1.ClientID & "');")
                    Else

                    End If

                End If
            Next
        Next
    End Sub
End Class
