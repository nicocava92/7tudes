Imports WebSupergoo.ABCpdf9
Partial Class MakePDF1
    Inherits System.Web.UI.Page

    'Input parameters
    'Profile: PIDList, ST: PID
    'if PIDList is received then SurveyTypeID=1 or 2 - Seven Tudes
    'if PID is received then SurveyTypeID=3 - ST

    'PIDList=List of participants split by "|"
    Dim theDoc

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim aList() As String, i1 As Integer
        XSettings.License = "810-031-225-276-6105-881"
        'Trace.Warn("License=" & XSettings.License)

        theDoc = New Doc

        If Request.QueryString("PIDList") <> "" Then
            aList = Split(Request.QueryString("PIDList"), "|")
            For i1 = 0 To UBound(aList)
                Trace.Warn(aList(i1))
                Call One_Generate(aList(i1), 1)
                'GoTo ExitSub
            Next

        ElseIf Request.QueryString("PID") <> "" Then
            aList = Split(Request.QueryString("PID"), "|")
            For i1 = 0 To UBound(aList)
                Trace.Warn(aList(i1))
                Call One_Generate(aList(i1), 4)
                'GoTo ExitSub
            Next
        ElseIf Request.QueryString("T1T2List") <> "" Then
            RF.Reports_Print(Request.QueryString("t1T2List"), 99)
        Else
            'Nothing to do 
            Trace.Warn("No parameters specified.")
            Exit Sub
        End If
ExitSub:
        theDoc = Nothing
    End Sub

    Sub One_Generate(ByVal sPIDList As String, ByVal iSurveyTypeID As Integer)
        Dim sUrl, theID
        Dim i1 As Integer, sFooter As String, sParticipantName As String
        Dim dv As System.Data.DataView, sPId As Long, sPageNo As String
        Dim sReportFileName As String, sSuffix As String, sDateName As String


        theDoc.Clear()

        Trace.Warn(("Exec rptReportInfo_Get '" & sPIDList & "', " & iSurveyTypeID))

        dv = CF.DataView_Get("Exec rptReportInfoLANG_Get '" & sPIDList & "', " & iSurveyTypeID)
        sPageNo = dv.Table.Rows(0)("pdf_pageno")
        sUrl = ConfigurationManager.AppSettings("url_report").ToString
        sUrl += dv.Table.Rows(0)("ReportName")
        If iSurveyTypeID = 1 Then
            sUrl &= "?PIDList=" & sPIDList & "&LanguageID=" & dv.Table.Rows(0)("LanguageID")
            If dv.Table.Rows(0)("Has360") = 1 Then
                sFooter = dv.Table.Rows(0)("profile_360")
            Else
                sFooter = dv.Table.Rows(0)("profile_self")
            End If
        Else
            sUrl &= "?PID=" & sPIDList
            sFooter = dv.Table.Rows(0)("ReportFooter")
        End If
        sUrl &= "&A=" & Request.QueryString("A") 'Request.QueryString.ToString
        Trace.Warn(sUrl)
        'Exit Sub

        sDateName = dv.Table.Rows(0)("txtDateGenerated")
        sParticipantName = dv.Table.Rows(0)("PName")
        sPId = dv.Table.Rows(0)("PID")
        sSuffix = CF.NullToString(dv.Table.Rows(0)("ReportSuffix"))

        'Footer Text
        sFooter = "<font face=Garamond size=2>" & sFooter & "</font>"

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
                theDoc.AddHTML("<font face=Garamond size=2 color=#000000>" & sParticipantName & "</font>")
            Next i1
        End If


        'Add Page Number
        theDoc.Rect.Position(520, 18)
        theDoc.Rect.Width = 50
        theDoc.Rect.Height = 20
        theDoc.HPos = 0.0
        For i1 = 2 To theDoc.PageCount
            theDoc.PageNumber = i1
            theDoc.AddHTML("<font face=Garamond size=2 color=#000000>" & Replace(sPageNo, "|nn|", i1 - 1) & "</font>")
        Next i1

        sReportFileName = AF.fsReportFileName(dv.Table.Rows(0)("GroupCode"), dv.Table.Rows(0)("ParticipantID"), sParticipantName, sSuffix)
        sReportFileName = Server.MapPath(sReportFileName)
        Trace.Warn(sReportFileName)
        theDoc.Save(sReportFileName)

        'Set date
        CF.Runquery("Update Participants set " & sDateName & "=getDate() where PID=" & dv.Table.Rows(0)("PID"))

    End Sub
End Class
