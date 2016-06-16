Imports Microsoft.VisualBasic
Imports PPIExceptionHelper

Public Class Emailsv4
    Public Shared Sub Email_Process(ByVal drRater As System.Data.DataRow, ByVal drE As System.Data.DataRow, ByVal IsInvite As Boolean)
        Dim sSql As String
        Dim sSurveyList As String, dv1 As System.Data.DataView
        Dim sDueDate As String, dDueDate As DateTime, i1 As Integer
        Dim sSubject As String, sMessage As String, sUrl As String
        Dim sFrom As String

        Dim RelID As String, SurveyType As String, PrevPID As String

        RelID = drE("RelID")
        SurveyType = drE("SurveyType")
        PrevPID = CF.NullToString(drRater("PrevPID"))

        If IsInvite Then
            sSubject = drE("Subject")
            sMessage = drE("Message")
        Else
            sSubject = drE("ReminderSubject")
            sMessage = drE("ReminderMessage") & "<br><br>" & drE("Message")
        End If

        sUrl = ConfigurationManager.AppSettings("URL")
        sUrl &= "/"
        'If drE("LanguageID") > 1 Then - disabled on 9/19/2013 - send lang link to all users
        sUrl = sUrl & "lang_"
        'End If
        sUrl = sUrl & drRater("BrandCode") & ".aspx"
        If drE("RelID") = 1 And drE("SurveyType") = "Energy" Then sUrl &= "?self"
        If drE("RelID") = 1 And drE("SurveyType") = "Energy T2" Then sUrl &= "?self2&show=2" 'skip language selection for now. Go to /survey
        If drE("RelID") = 0 And drE("SurveyType") = "Energy T2" Or drE("RelID") = 0 And PrevPID <> "" Then sUrl &= "?self2&show=2" 'skip language selection for now. Go to /survey
        If drE("RelID") = 1 And drE("SurveyType") = "NorthStar Assessment" Then sUrl = ConfigurationManager.AppSettings("URL") & "/Self_CHLogin.aspx" '01-06-16 - MG - 'skips lang selection (sets English) and goes to English login

        sUrl = "<a href=""" & sUrl & """>" & sUrl & "</a>"

        'Substitutions
        sMessage = Replace(sMessage, "|ViewEmail|", ViewEmail_Get())
        sMessage = Replace(sMessage, "|ParticipantName|", drRater("FirstName") & " " & drRater("LastName"))
        sMessage = Replace(sMessage, "|GroupCode|", drRater("GroupCode"))
        sMessage = Replace(sMessage, "|ParticipantID|", drRater("ParticipantID"))
        sMessage = Replace(sMessage, "|RaterPassword|", drRater("RaterPassword"))
        sMessage = Replace(sMessage, "|URL|", sUrl)
        dDueDate = drRater("DueDate")
        sDueDate = LangDate_Get(dDueDate, drRater("datefmt"), drRater("Culture"))
        sMessage = Replace(sMessage, "|DueDate|", sDueDate)

        sMessage = Replace(sMessage, "|RaterID|", drRater("RaterID"))

        'SurveyList
        If drE("RelID") = 1 Then
            If InStr(sMessage, "|SurveysList|") > 0 Then
                sSurveyList = "<ul>"

                sSql = "Select * from qryResponseStatus2A where 1=1" ' where surveyTypeID<>5 "
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
                            'sSurveyList = sSurveyList & " - " & dv1.Table.Rows(i1)("DateCompleted")
                            sSurveyList = sSurveyList & " - " & RaterReg_Get(dv1.Table.Rows(i1)("selfhome_raterreg"), dv1.Table.Rows(i1)("DateCompleted"))
                        Else
                            If CF.NullToString(dv1.Table.Rows(i1)("DateEntered")) = "" Then
                                'sSurveyList = sSurveyList & " - not started"
                                sSurveyList = sSurveyList & " - " & dv1.Table.Rows(i1)("notstarted")
                            ElseIf CF.NullToString(dv1.Table.Rows(i1)("DateCompleted")) = "" Then
                                dDueDate = dv1.Table.Rows(i1)("DateEntered")
                                sDueDate = LangDate_Get(dDueDate, dv1.Table.Rows(i1)("datefmt"), dv1.Table.Rows(i1)("Culture"))
                                sSurveyList = sSurveyList & " - " & dv1.Table.Rows(i1)("startedon") & " " & sDueDate
                            Else
                                dDueDate = dv1.Table.Rows(i1)("DateCompleted")
                                sDueDate = LangDate_Get(dDueDate, dv1.Table.Rows(i1)("datefmt"), dv1.Table.Rows(i1)("Culture"))
                                sSurveyList = sSurveyList & " - " & dv1.Table.Rows(i1)("completedon") & " " & sDueDate
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
        sMessage = Replace(sMessage, vbCrLf, "<br>")

        'Arial font
        sMessage = "<div style=""font-family:Arial; font-size:small;"">" & sMessage & "</div>"
        System.Web.HttpContext.Current.Trace.Warn(sMessage)

        Dim sEmailResult As String

        'update date code
        'Send message
        System.Web.HttpContext.Current.Trace.Warn("Rel ID - " & drE("RelID"))
        If drE("RelID") = 1 Then
            'Try 'MG Added Try Catch 04/21/14
            System.Web.HttpContext.Current.Trace.Warn("SMTP -  " & ConfigurationManager.AppSettings("sender") & "," & drRater("EmailAddress") & "," & "" & "," & sSubject & "," & sMessage)
            sEmailResult = CF.Email_Send(ConfigurationManager.AppSettings("sender"), drRater("EmailAddress"), "", sSubject, sMessage)

            If sEmailResult <> String.Empty Then
                Throw New ApplicationException(String.Format("The following error occurred while sending scheduled email (RelID ==1): {0}", sEmailResult))
            End If

            'Catch e As System.Exception
            'CF.Email_Send("server@performaceprograms.com", "matt@performanceprograms.com", "", sSubject, sMessage + "-" + sFrom)
            'End Try
            sSql = "Update Participants Set "
        Else
            sFrom = Chr(34) & drRater("FirstName") & " " & drRater("LastName") & Chr(34) & "<" & drRater("ParticipantEmailAddress") & ">"
            'Try 'MG Added Try Catch 04/21/14
            sEmailResult = CF.Email_Send(sFrom, drRater("EmailAddress"), "", sSubject, sMessage)

            If sEmailResult <> String.Empty Then
                Throw New ApplicationException(String.Format("The following error occurred while sending scheduled email: {0}", sEmailResult))
            End If

            'Catch e As System.Exception
            'CF.Email_Send("server@performaceprograms.com", "matt@performanceprograms.com", "", sSubject, sMessage + "-" + sFrom)
            'End Try
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

    Public Shared Function LangDate_Get(d1 As Date, sFormat As String, sCulture As String) As String
        LangDate_Get = d1.ToString(sFormat, New System.Globalization.CultureInfo(sCulture))
    End Function

    Public Shared Function RaterReg_Get(sResx As String, sxy As String) As String
        RaterReg_Get = sResx 'Resources.Langtext.selfhome_raterreg
        RaterReg_Get = Replace(RaterReg_Get, "|x|", Left(sxy, InStr(sxy, "@") - 1))
        RaterReg_Get = Replace(RaterReg_Get, "|y|", Mid(sxy, InStr(sxy, "@") + 1))
    End Function

    Public Shared Function ViewEmail_Get() As String
        Dim s1 As String
        HttpContext.Current.Trace.Warn("Start")
        If IsNothing(HttpContext.Current.Application("ViewEmail_Link")) Then
            Dim dv1 As System.Data.DataView

            dv1 = CF.DataView_Get("Exec ViewEmail_Show")
            s1 = dv1.Table.Rows(0)(0)
            s1 = "<a href=""https://energyprofile.perfprog.com/ViewEmail/Default.aspx?RaterID=|RaterID|z|RaterPassword|""><span style=""color:red;"">" & s1 & "</span></a></font>"
            HttpContext.Current.Application.Lock()
            HttpContext.Current.Application("ViewEmail_Link") = s1
            HttpContext.Current.Application.UnLock()
            HttpContext.Current.Trace.Warn("Initialzed")
        End If

        ViewEmail_Get = HttpContext.Current.Application("ViewEmail_Link")
    End Function

End Class
