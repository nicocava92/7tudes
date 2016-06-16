Imports Microsoft.VisualBasic

Public Class Emailsv3
    Public Shared Sub Email_Process(ByVal drRater As System.Data.DataRow, ByVal drE As System.Data.DataRow, ByVal IsInvite As Boolean)
        Dim sSql As String
        Dim sSurveyList As String, dv1 As System.Data.DataView
        Dim sDueDate As String, dDueDate As DateTime, i1 As Integer
        Dim sSubject As String, sMessage As String, sUrl As String
        Dim sFrom As String

        If IsInvite Then
            sSubject = drE("Subject")
            sMessage = drE("Message")
        Else
            sSubject = drE("ReminderSubject")
            sMessage = drE("ReminderMessage") & "<br><br>" & drE("Message")
        End If

        sUrl = ConfigurationManager.AppSettings("URL")
        sUrl &= "/"
        If drE("LanguageID") > 1 Then
            sUrl = sUrl & "lang_"
        End If
        sUrl = sUrl & drRater("BrandCode") & ".aspx"
        If drE("RelID") = 1 Then sUrl &= "?self"

        sUrl = "<a href=""" & sUrl & """>" & sUrl & "</a>"

        'Substitutions
        sMessage = Replace(sMessage, "|ParticipantName|", drRater("FirstName") & " " & drRater("LastName"))
        sMessage = Replace(sMessage, "|GroupCode|", drRater("GroupCode"))
        sMessage = Replace(sMessage, "|ParticipantID|", drRater("ParticipantID"))
        sMessage = Replace(sMessage, "|RaterPassword|", drRater("RaterPassword"))
        sMessage = Replace(sMessage, "|URL|", sUrl)
        dDueDate = drRater("DueDate")
        sDueDate = dDueDate.ToString("MMM dd, yyyy")
        sMessage = Replace(sMessage, "|DueDate|", sDueDate)


        'SurveyList
        If drE("RelID") = 1 Then
            If InStr(sMessage, "|SurveysList|") > 0 Then
                sSurveyList = "<ul>"

                sSql = "Select * from qryResponseStatus2 where 1=1" ' where surveyTypeID<>5 "
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
                        If dv1.Table.Rows(i1)("SurveyTypeID") = 5 Then
                            sSurveyList = sSurveyList & " - " & dv1.Table.Rows(i1)("DateCompleted")

                        Else
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

            sSubject = Replace(sSubject, "|ParticipantName|", drRater("FirstName") & " " & drRater("LastName"))

        End If


        'Format message
        System.Web.HttpContext.Current.Trace.Warn(sMessage)

        sMessage = Replace(sMessage, vbCrLf, "<br>")

        'Send message
        'Arial font
        sMessage = "<div style=""font-family:Arial; font-size:small;"">" & sMessage & "</div>"

        'update date code
        If drE("RelID") = 1 Then
            CF.Email_Send(ConfigurationManager.AppSettings("sender"), drRater("EmailAddress"), "", sSubject, sMessage)
            sSql = "Update Participants Set "
        Else
            sFrom = Chr(34) & drRater("FirstName") & " " & drRater("LastName") & Chr(34) & "<" & drRater("ParticipantEmailAddress") & ">"
            CF.Email_Send(sFrom, drRater("EmailAddress"), "", sSubject, sMessage)
            sSql = "Update Raters set "
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
End Class
