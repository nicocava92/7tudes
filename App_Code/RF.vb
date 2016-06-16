Imports Microsoft.VisualBasic
Imports WebSupergoo.ABCpdf9
Imports PPIExceptionHelper

Public Class RF


    Public Shared Sub Reports_Calc(ByVal sList As String)
        Dim aPID() As String, iSecsPer As Integer
        iSecsPer = 40
        aPID = Split(sList, ",")
        CF.Runquery("Exec Batch_Calc '" & sList & "'", iSecsPer * (UBound(aPID) + 1))

    End Sub

    Public Shared Sub Reports_Print(ByVal sList As String, Optional iSurveyTypeID As Integer = 1)
        'Use iSurveyTypeID=99 for the T1T2 report

        'Must be Pipe-delimited 
        Dim aList() As String, i1 As Integer
        Dim theDoc
        Dim dvPrev As System.Data.DataView

        XSettings.License = "810-031-225-276-6105-881"

        theDoc = New Doc

        If sList <> "" Then
            aList = Split(sList, "|")
            For i1 = 0 To UBound(aList)
                Trace_Warn(aList(i1))
                If iSurveyTypeID = 99 Then
                    Call T1T2_Generate(aList(i1), iSurveyTypeID, theDoc)
                Else
                    Call One_Generate(aList(i1), iSurveyTypeID, theDoc)
                End If

                'GoTo ExitSub

                '2014-11-07 - T1 and T1T2
                If iSurveyTypeID = 1 Then
                    dvPrev = CF.DataView_Get("Select Top 1 IsNull(PrevPID, 0) as T1ID from Participants where PID=" & aList(i1))
                    If dvPrev.Table.Rows(0)("T1ID") > 0 Then
                        Call One_Generate(dvPrev.Table.Rows(0)("T1ID"), iSurveyTypeID, theDoc)
                        Call T1T2_Generate(aList(i1), 99, theDoc)
                    End If
                End If

            Next
        Else
            'Nothing to do 
            Trace_Warn("No parameters specified.")
            Exit Sub
        End If

ExitSub:
        theDoc = Nothing
    End Sub

    Public Shared Sub One_Generate(ByVal sPIDList, ByVal iSurveyTypeID, ByVal theDoc)
        Dim sUrl, theID
        Dim i1 As Integer, sFooter As String, sParticipantName As String
        Dim dv As System.Data.DataView, sPId As Long, sPageNo As String
        Dim sReportFileName As String, sSuffix As String, sDateName As String
        Dim sLang As Integer

        theDoc.Clear()
        ' Try to obtain html page 10 times
        theDoc.HtmlOptions.RetryCount = 10
        ' The page must be obtained in less then 60 seconds
        theDoc.HtmlOptions.TimeOut = 60000 '60 seconds

        RF.Trace_Warn(("Exec rptReportInfo_Get '" & sPIDList & "', " & iSurveyTypeID))

        dv = CF.DataView_Get("Exec rptReportInfoLANG_Get '" & sPIDList & "', " & iSurveyTypeID)
        sPageNo = dv.Table.Rows(0)("pdf_pageno")
        sFooter = dv.Table.Rows(0)("ReportFooter")
        sLang = dv.Table.Rows(0)("LanguageID")
        sUrl = ConfigurationManager.AppSettings("url_report").ToString
        sUrl += dv.Table.Rows(0)("ReportName")
        If iSurveyTypeID = 1 Then
            'July 12, 2012: suppress report generation if there are no results
            If CF.NullToString(dv.Table.Rows(0)("ReportDate")) = "" Then
                RF.Trace_Warn("Results missing.. aborting")
                CF.Email_Send(ConfigurationManager.AppSettings("sender"), "", "", "Error - report gen missing results", sPIDList)
                Exit Sub
            End If


            sUrl &= "?PIDList=" & sPIDList & "&LanguageID=" & dv.Table.Rows(0)("LanguageID")
            If dv.Table.Rows(0)("Has360") = 1 Then
                sFooter = dv.Table.Rows(0)("profile_360")
            Else
                sFooter = dv.Table.Rows(0)("profile_self")
            End If
        Else
            sUrl &= "?PID=" & sPIDList & "&LanguageID=" & dv.Table.Rows(0)("LanguageID")
            sFooter = dv.Table.Rows(0)("ReportFooter")
        End If

        Dim RandomClass As New Random()
        sUrl &= "&A=" & RandomClass.Next()
        RF.Trace_Warn(sUrl)
        'Exit Sub

        sDateName = dv.Table.Rows(0)("txtDateGenerated")
        sParticipantName = dv.Table.Rows(0)("PName")
        sPId = dv.Table.Rows(0)("PID")
        sSuffix = CF.NullToString(dv.Table.Rows(0)("ReportSuffix"))

        'Footer Text
        'sFooter = "<font face=Garamond size=2>" & sFooter & "</font>"
        sFooter = "<font size=2>" & sFooter & "</font>"

        'Create PDF
        theDoc.Rect.Position(52, 42) 'was 52
        theDoc.Rect.Width = 520
        theDoc.Rect.Height = 730 'was 720
        theDoc.Page = theDoc.AddPage()


        theID = theDoc.AddImageUrl(sUrl, True, 0, False)
        Do
            If Not theDoc.Chainable(theID) Then Exit Do
            theDoc.Page = theDoc.AddPage()
            theID = theDoc.AddImageToChain(theID)
        Loop

        For i1 = 1 To theDoc.PageCount
            theDoc.PageNumber = i1
            theDoc.Flatten()
        Next


        'Add Footer line 
        'theDoc.Rect.Position(52, 40)
        'theDoc.Rect.Width = 520
        'theDoc.Rect.Height = 2
        'theDoc.Color.String = "0 0 0"
        'For i1 = 2 To theDoc.PageCount
        '    theDoc.PageNumber = i1
        '    theDoc.FillRect()
        'Next i1


        'Add Participant Name in footer
        theDoc.Rect.Position(270, 18)
        theDoc.Rect.Width = 150
        theDoc.Rect.Height = 20
        If sLang = 12 Then
            theDoc.Font = theDoc.EmbedFont("Malgun Gothic", "Unicode", False, True)
        Else
            theDoc.Font = theDoc.EmbedFont("MS PGothic", "Unicode", False, True)
        End If
        If iSurveyTypeID > 1 Then
            For i1 = 2 To theDoc.PageCount
                theDoc.PageNumber = i1
                'theDoc.AddHTML(sFooter)
                theDoc.AddHTML("<font size=2 color=#000000>" & sParticipantName & "</font>")
            Next i1
        End If

        'Add Footer Text 
        theDoc.Rect.Position(55, 18)
        theDoc.Rect.Width = 150
        theDoc.Rect.Height = 20
        theDoc.HPos = 0.0
        For i1 = 2 To theDoc.PageCount
            theDoc.PageNumber = i1
            'theDoc.AddHTML("<font size=2 color=#000000>" & sParticipantName & "</font>")
            theDoc.AddHTML(sFooter)
        Next i1



        'Add Page Number
        theDoc.Rect.Position(520, 18)
        theDoc.Rect.Width = 50
        theDoc.Rect.Height = 20
        theDoc.HPos = 0.0
        For i1 = 2 To theDoc.PageCount
            theDoc.PageNumber = i1
            theDoc.AddHTML("<font size=2 color=#000000>" & Replace(sPageNo, "|nn|", i1 - 1) & "</font>")
        Next i1

        sReportFileName = AF.fsReportFileName(dv.Table.Rows(0)("GroupCode"), dv.Table.Rows(0)("ParticipantID"), sParticipantName, sSuffix)
        sReportFileName = System.Web.HttpContext.Current.Server.MapPath(sReportFileName)
        RF.Trace_Warn(sReportFileName)
        theDoc.Save(sReportFileName)

        'Set date
        CF.Runquery("Update Participants set " & sDateName & "=getDate() where PID=" & dv.Table.Rows(0)("PID"))

    End Sub

    Public Shared Sub Trace_Warn(ByVal s1 As String)
        System.Web.HttpContext.Current.Trace.Warn(s1)
    End Sub

    Public Shared Sub T1T2_Generate(ByVal sPIDList, ByVal iSurveyTypeID, ByVal theDoc)
        Dim sUrl, theID
        Dim i1 As Integer, sFooter As String, sParticipantName As String
        Dim dv As System.Data.DataView, sPId As Long, sPageNo As String
        Dim sReportFileName As String, sSuffix As String, sDateName As String
        Dim sLang As Integer

        theDoc.Clear()
        theDoc.HtmlOptions.TimeOut = 60000 '60 seconds

        dv = CF.DataView_Get("Exec rptT1T2Info_Get '" & sPIDList & "'")
        sPageNo = dv.Table.Rows(0)("pdf_pageno")
        sFooter = dv.Table.Rows(0)("ReportFooter")
        sLang = dv.Table.Rows(0)("LanguageID")
        sUrl = ConfigurationManager.AppSettings("url_report").ToString
        sUrl += dv.Table.Rows(0)("ReportName")
        sUrl &= "?PIDList=" & sPIDList '& "&LanguageID=" & dv.Table.Rows(0)("LanguageID")
        sFooter = dv.Table.Rows(0)("ReportFooter")


        Dim RandomClass As New Random()
        sUrl &= "&A=" & RandomClass.Next()
        RF.Trace_Warn(sUrl)
        'Exit Sub

        sDateName = dv.Table.Rows(0)("txtDateGenerated")
        sParticipantName = dv.Table.Rows(0)("PName")
        sPId = dv.Table.Rows(0)("PID")
        sSuffix = CF.NullToString(dv.Table.Rows(0)("ReportSuffix"))

        'Footer Text
        'sFooter = "<font face=Garamond size=2>" & sFooter & "</font>"
        sFooter = "<font size=2>" & sFooter & "</font>"

        'Create PDF
        theDoc.Rect.Position(52, 42) 'was 52
        theDoc.Rect.Width = 520
        theDoc.Rect.Height = 730 'was 720
        theDoc.Page = theDoc.AddPage()


        theID = theDoc.AddImageUrl(sUrl, True, 0, False)
        Do
            If Not theDoc.Chainable(theID) Then Exit Do
            theDoc.Page = theDoc.AddPage()
            theID = theDoc.AddImageToChain(theID)
        Loop

        For i1 = 1 To theDoc.PageCount
            theDoc.PageNumber = i1
            theDoc.Flatten()
        Next


        'Add Footer line 
        theDoc.Rect.Position(52, 40)
        theDoc.Rect.Width = 520
        theDoc.Rect.Height = 2
        theDoc.Color.String = "0 0 0"
        For i1 = 2 To theDoc.PageCount
            theDoc.PageNumber = i1
            theDoc.FillRect()
        Next i1

        'Add Footer Text 
        theDoc.Rect.Position(270, 18)
        theDoc.Rect.Width = 150
        theDoc.Rect.Height = 20
        If sLang = 12 Then
            theDoc.Font = theDoc.EmbedFont("Malgun Gothic", "Unicode", False, True)
        Else
            theDoc.Font = theDoc.EmbedFont("MS PGothic", "Unicode", False, True)
        End If
        For i1 = 2 To theDoc.PageCount
            theDoc.PageNumber = i1
            theDoc.AddHTML(sFooter)
        Next i1

        'Add Participant Name in footer
        If iSurveyTypeID > 1 Then
            theDoc.Rect.Position(55, 18)
            theDoc.Rect.Width = 150
            theDoc.Rect.Height = 20
            theDoc.HPos = 0.0
            For i1 = 2 To theDoc.PageCount
                theDoc.PageNumber = i1
                theDoc.AddHTML("<font size=2 color=#000000>" & sParticipantName & "</font>")
            Next i1
        End If


        'Add Page Number
        theDoc.Rect.Position(520, 18)
        theDoc.Rect.Width = 50
        theDoc.Rect.Height = 20
        theDoc.HPos = 0.0
        For i1 = 2 To theDoc.PageCount
            theDoc.PageNumber = i1
            theDoc.AddHTML("<font size=2 color=#000000>" & Replace(sPageNo, "|nn|", i1 - 1) & "</font>")
        Next i1

        sReportFileName = AF.fsReportFileName(dv.Table.Rows(0)("GroupCode"), dv.Table.Rows(0)("ParticipantID"), sParticipantName, sSuffix)
        sReportFileName = System.Web.HttpContext.Current.Server.MapPath(sReportFileName)
        RF.Trace_Warn(sReportFileName)
        theDoc.Save(sReportFileName)

        'Set date
        CF.Runquery("Update Participants set " & sDateName & "=getDate() where PID=" & dv.Table.Rows(0)("PID"))

    End Sub

    Public Shared Sub Reports_Email(ByVal iGroupCode As Long, ByVal sList As String,
        Optional IsCompositeReport As Boolean = False, Optional sCompositeEmailTo As String = "")

        Dim dvE As System.Data.DataView, sSubject As String, sSrcMessage As String, sMessage As String
        Dim sFileNames(0) As String, sSql As String
        Dim sEmailAddress As String, sParticipantName As String, sOneFileName As String
        Dim iCount As Integer, dvP As System.Data.DataView, gr As System.Data.DataRow
        Dim sSentList As String
        Dim sGroupName As String
        Dim sSurveyTypeID As Integer

        Trace_Warn(sList)

        Try
            sSentList = ""
            If IsCompositeReport Then
                'was qryEmails_service3
                dvE = CF.DataView_Get("Select Subject, Message, FromAddress, GroupName, SurveyTypeID from qryEmails_Service47 where GroupCode=" & iGroupCode & " order by EmailType")
            Else
                'was qryEmails_service2
                dvE = CF.DataView_Get("Select Subject, Message, FromAddress from qryEmails_Service16 where GroupCode=" & iGroupCode & " order by EmailType")
            End If

            iCount = 0
            dvP = CF.DataView_Get("Select * from qryParticipants_T1T2 where PID In (" & Replace(sList, "|", ",") & ")")
            For Each gr In dvP.Table.Rows
                ReDim sFileNames(0)

                'Decide which email message to use based on PrevPID
                'If there is a PrevPID use the T2 message
                If CF.NullToString(gr("PrevPID")) = "" Then
                    sSubject = dvE.Table.Rows(0)("Subject")
                    sSrcMessage = dvE.Table.Rows(0)("Message")
                Else
                    sSubject = dvE.Table.Rows(1)("Subject")
                    sSrcMessage = dvE.Table.Rows(1)("Message")
                End If
                sSrcMessage = Replace(sSrcMessage, vbCrLf, "<br>")

                If IsCompositeReport Then
                    sGroupName = dvE.Table.Rows(0)("GroupName")
                    sSubject = Replace(sSubject, "|GroupName|", sGroupName)
                    sSurveyTypeID = dvE.Table.Rows(0)("SurveyTypeID")

                    '07-18-14 Added to handle Self Composite Reports.  If Self Survey Type. simply change '360 Energey' with 'Self'
                    If sSurveyTypeID = 1 Then
                        sSubject = Replace(sSubject, "360 Energy", "Self")
                        sSrcMessage = Replace(sSrcMessage, "360 Energy", "Self")
                    End If
                End If

                'Get ParticipantName and sEmailAddress
                sEmailAddress = CF.NullToString(gr("EmailAddress"))
                sCompositeEmailTo = CF.NullToString(sCompositeEmailTo)

                'For composite reports, use email address in the "CoachUserName" field
                If IsCompositeReport Then
                    If sCompositeEmailTo = "" Then
                        sEmailAddress = "matt@performanceprograms.com"
                    Else
                        sEmailAddress = sCompositeEmailTo
                    End If
                End If

                sParticipantName = gr("FirstName") & " " & gr("LastName")
                Trace_Warn(sEmailAddress & " " & sParticipantName)

                'Find report files
                sOneFileName = System.Web.HttpContext.Current.Server.MapPath(AF.fsReportFileName(gr("GroupCode"), gr("ParticipantID"), sParticipantName, ""))
                If CF.FileExists(sOneFileName) Then
                    Trace_Warn("attach file=" & sOneFileName)
                    If sFileNames(0) <> "" Then ReDim Preserve sFileNames(UBound(sFileNames) + 1)
                    sFileNames(UBound(sFileNames)) = sOneFileName
                End If

                sOneFileName = System.Web.HttpContext.Current.Server.MapPath(AF.fsReportFileName(gr("GroupCode"), gr("ParticipantID"), sParticipantName, "(ST)"))
                If CF.FileExists(sOneFileName) Then
                    Trace_Warn("attach file=" & sOneFileName)
                    If sFileNames(0) <> "" Then ReDim Preserve sFileNames(UBound(sFileNames) + 1)
                    sFileNames(UBound(sFileNames)) = sOneFileName
                End If

                'T1-T2 based on PrevPID being non null
                If CF.NullToString(gr("PrevPID")) <> "" Then
                    'T1T2 report
                    'sParticipantName is same as the one set up above
                    sOneFileName = System.Web.HttpContext.Current.Server.MapPath(AF.fsReportFileName(gr("GroupCode"), gr("ParticipantID"), sParticipantName, "(T1T2)"))
                    If CF.FileExists(sOneFileName) Then
                        Trace_Warn("attach file=" & sOneFileName)
                        If sFileNames(0) <> "" Then ReDim Preserve sFileNames(UBound(sFileNames) + 1)
                        sFileNames(UBound(sFileNames)) = sOneFileName
                    End If

                    'Profle report for T1
                    sParticipantName = gr("PrevFirstName") & " " & gr("PrevLastName")
                    sOneFileName = System.Web.HttpContext.Current.Server.MapPath(AF.fsReportFileName(gr("PrevGroupCode"), gr("PrevParticipantID"), sParticipantName, ""))
                    If CF.FileExists(sOneFileName) Then
                        Trace_Warn("attach file=" & sOneFileName)
                        If sFileNames(0) <> "" Then ReDim Preserve sFileNames(UBound(sFileNames) + 1)
                        sFileNames(UBound(sFileNames)) = sOneFileName
                    End If
                End If

                'Send email to sEmailAddress
                If sFileNames(0) <> "" Then
                    sMessage = Replace(sSrcMessage, "|ParticipantName|", sParticipantName)

                    'Arial font
                    sMessage = "<div style=""font-family:Arial; font-size:small;"">" & sMessage & "</div>"
                    Trace_Warn(sMessage)

                    'Send
                    Try
                        Dim sSendResult = CF.Email_Send(ConfigurationManager.AppSettings("sender"), sEmailAddress, "", sSubject, sMessage, sFileNames)

                        If sSendResult <> String.Empty Then
                            Throw New ApplicationException("An error occurred while sending reports")
                        End If
                    Catch ex As Exception
                        Dim sExResult As String = PPIExceptionTools.HandleException(ex, PPIEventType.NonFatalError)
                    End Try

                    'Update Date Sent
                    sSql = "Update Participants set ReportSentDate=getDate() where PID=" & gr("PID")
                    Trace_Warn(sSql)
                    CF.Runquery(sSql)

                    iCount = iCount + 1

                    sSentList = sSentList & "<br>" & gr("GroupCode") & "--" & gr("ParticipantID") & " " & sParticipantName
                End If
                'NextRpt:
            Next

            'Send email to appropriate admin
            If iCount > 0 Then
                sSentList = "The below reports were emailed: " & sSentList
            End If
            Trace_Warn(sSentList)
            'dvE.Table.Rows(0)("FromAddress")
            CF.Email_Send(ConfigurationManager.AppSettings("sender"), dvE.Table.Rows(0)("FromAddress"), "", "Group Code: " & iGroupCode & ": " & iCount & " reports emailed", sSentList)

        Catch ex As Exception
            PPIExceptionTools.HandleException(ex, PPIEventType.NonFatalError)
            Throw ex    'rethrow
        End Try
    End Sub
End Class
