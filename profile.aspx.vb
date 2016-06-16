Imports Microsoft.VisualBasic
Imports WebSupergoo.ABCpdf9
Imports ChartDirector
Partial Class Free_profile
    Inherits System.Web.UI.Page
    Dim dvReportlabels As System.Data.DataView
    Dim sCulture As String, sReportFileName As String

    'Personal/Context vars
    Dim aPersonalSum(0) As Double, aPersonalAvg As Double
    Dim iPersonalAvg As Double
    Dim aContextUcl(0) As Double, aContextLcl(0) As Double, aContextAvg(0) As Double, aContextLabel(0) As String
    Dim dvPersonal As System.Data.DataView, drDim As System.Data.DataRow
    Dim iPersonalContext As Double

    Dim i1 As Integer, aData() As String, tabData As Table



    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Request.QueryString("PID") = "" Then Exit Sub
        
        If Request.QueryString("Print") = "Y" Then
            Me.tabshow.Visible = False
            Me.ProgressInfo.Visible = False
        End If


        If Not Page.IsPostBack Then
            Me.PID.Text = Request.QueryString("PID")
        End If

        'no needed - run when questions page is saved
        CF.Runquery("Exec Results_Calc " & Request.QueryString("PID"))

        'Me.pyr1.pPID = Me.PID.Text
        'Pyr_Set()

        aContextLabel = {"Attitude", "Aptitude", "Magnitude", "Latitude", "Rectitude", "Exactitude", "Fortitude"}
        aContextUcl = {3.928045, 3.88949, 4.183985, 3.757035, 3.808475, 3.82306, 3.975715}
        aContextLcl = {3.216555, 3.08891, 3.465615, 3.002165, 3.050325, 3.02574, 3.207085}

        'DataSource_DataBind(Me.cPersonal)
        dvPersonal = Me.cPersonal.Select(DataSourceSelectArguments.Empty)
        iPersonalAvg = 0

        For Each drDim In dvPersonal.Table.Rows

            ReDim Preserve aPersonalSum(i1)

            aPersonalSum(i1) = drDim("SelfScore")
            iPersonalAvg = iPersonalAvg + drDim("SelfScore")
            Trace.Warn("ROW: " & i1 & "=" & drDim("SelfScore"))

            i1 += 1
NextPersonal:
        Next

        'Trace.Warn("aPersonalSum: " & aPersonalSum)

        ' Calc Percentage
        Dim dv As System.Data.DataView, sSql As String
        sSql = "SELECT ROUND(SUM(CAST(ISNULL(Sum1, 0) AS float)) / 140, 2) AS [Percent] FROM [7tudes].[dbo].[Results_Q] WHERE RelID = 1 and PID = " & Request.QueryString("PID")
        Trace.Warn(sSql)

        dv = CF.DataView_Get(sSql)
        Dim Percent As Double
        Percent = dv.Table.Rows(0)("Percent")
        Trace.Warn("Percent: " & Percent)
        Me.Percent.Text = (Percent * 100) & "%"

        ' Average Scores/Results Calc
        aPersonalAvg = Math.Round(iPersonalAvg / i1, 2)
        Me.AvgScore.Text = "AVG " & aPersonalAvg

        If aPersonalAvg < 3.2 Then
            Me.AvgScoreClass.Attributes.Add("class", "donotpursue")
        ElseIf aPersonalAvg >= 3.2 And aPersonalAvg <= 3.5 Then
            Me.AvgScoreClass.Attributes.Add("class", "regroup")
        ElseIf aPersonalAvg > 3.5 And aPersonalAvg <= 3.9 Then
            Me.AvgScoreClass.Attributes.Add("class", "caution")
        Else
            Me.AvgScoreClass.Attributes.Add("class", "fullsteamahead")
        End If

        ' The data for the chart
        DimChart(False, Me.chartPersonal, 0, aContextUcl, aContextLcl, aPersonalSum, aContextLabel)

    End Sub

    Sub DimChart(ByVal IsSmall As Boolean, ByVal chart2 As Object, ByVal iDimNo As Integer, ByVal ucl() As Double, ByVal lcl() As Double, ByVal actual() As Double, ByVal labels() As String)
        'ucl = {3.25, 3.25, 3.25, 3.25, 3.25, 3.25, 3.25}
        'lcl = {2.25, 2.75, 2.25, 2.65, 2.25, 2.55, 2.25}

        Dim iSizeFactor As Single
        'Trace.Warn(iDimNo)
        'Reset Bold attribute
        For i1 = 0 To UBound(labels)
            labels(i1) = Replace(labels(i1), "<*font= Tahoma Bold*>", "")
        Next

        'Set bold attribute of Dim label 
        For i1 = 0 To UBound(labels)
            labels(i1) = "<*font= Tahoma Bold*>" & labels(i1)
        Next

        'start chart
        Dim c As PolarChart
        Chart.setLicenseCode("DEVP-348S-FXXS-WHSU-9B5A-E259")


        iSizeFactor = 2
        c = New PolarChart(230 * iSizeFactor, 190 * iSizeFactor)
        Call c.setPlotArea(120 * iSizeFactor - 5, 90 * iSizeFactor - 10, 70 * iSizeFactor, &HFFFFFF) 'F0F0F0 'was 130 for 3rd parm had to adjust for Travel Expectations

        'Call c.setPlotAreaBg(&H72A492, &HD5E2E5, True)

        c.setBackground(&HFFFFFF)
        c.setBorder(Chart.Transparent) 'transparent



        Call c.addAreaLayer(ucl, &HAEE7FC) 'not transparent green: &HD5E2E5
        Call c.addAreaLayer(lcl, &HFFFFFF) 'transparent
        Call c.addLineLayer(actual, &HF26522).setLineWidth(4)

        Call c.setGridStyle(True)
        'Call c.setGridColor(&HCCCCCC, 1, &HCCCCCC, 1)


        ' Set the labels to the angular axis as spokes.
        Call c.angularAxis().setLabels(labels)
        Call c.angularAxis.setLabelStyle("Tahoma", 9)

        'Call c.angularAxis().addZone(iDimNo - 0.5, iDimNo + 0.5, &H8000FF00) 'transparent


        Call c.radialAxis().setLabelStyle("Tahoma", 6, &H0).setBackground(Chart.Transparent, Chart.Transparent)
        Call c.radialAxis().setColors(Chart.Transparent, &H0, Chart.Transparent, &H0)
        Call c.radialAxis().setLabelGap(1)
        Call c.radialAxis().setLinearScale(0, 5, 1)
        Call c.radialAxis().setTickLength(-3)


        ' output the chart
        chart2.Image = c.makeWebImage(Chart.PNG)

    End Sub

    'Sub Pyr_Set()
    '    Dim ptemp1 As Report_Pyramid3, L1 As Label

    '    ptemp1 = Me.pyr1
    '    ptemp1.para1 = ReportLabel_Get("pyr_para1_self")

    '    ptemp1.para2 = ReportLabel_Get("pyr_para2")
    '    ptemp1.fullyengaged = ReportLabel_Get("pyr_fullyengaged")
    '    ptemp1.engaged = ReportLabel_Get("pyr_engaged")
    '    ptemp1.disengaged = ReportLabel_Get("pyr_disengaged")
    '    ptemp1.seriouslydisengaged = ReportLabel_Get("pyr_seriouslydisengaged")

    '    'Rels
    '    ptemp1.plabel_self = ReportLabel_Get("label_self")
    '    ptemp1.plabel_others = ReportLabel_Get("label_others")

    '    'TOC
    '    ptemp1.pheading = ReportLabel_Get("pyr_heading")


    'End Sub

    Function ReportLabel_Get(ByVal sKeyName As String) As String
        Dim i1 As Integer

        If dvReportlabels Is Nothing Then ReportLabels_Set()

        For i1 = 0 To dvReportlabels.Table.Rows.Count - 1
            If dvReportlabels.Table.Rows(i1)("KeyName") = sKeyName Then
                ReportLabel_Get = dvReportlabels.Table.Rows(i1)("KeyValue")
                Exit Function
            End If
        Next
        ReportLabel_Get = sKeyName & " not found"
    End Function

    Sub ReportLabels_Set()
        Dim sLanguageID As String


        If dvReportlabels Is Nothing Then
            sLanguageID = 1
            If Request.QueryString("LanguageID") <> "" Then
                sLanguageID = Request.QueryString("LanguageID")
            End If

            'Set Culture
            dvReportlabels = CF.DataView_Get("Select Top 1 Culture from Languages where LanguageID=" & sLanguageID)
            sCulture = dvReportlabels.Table.Rows(0)("Culture")

            'Set actual Report Labels
            dvReportlabels = CF.DataView_Get("Select KeyName, KeyValue from ReportLabels where LanguageID=" & sLanguageID & " order by KeyName")
        End If



    End Sub

    'Protected Sub btnNextSteps_Click(sender As Object, e As System.EventArgs) Handles btnNextSteps.Click
    '    Response.Redirect("NextSteps.aspx?PID=" & Request.QueryString("PID"))
    'End Sub

    Protected Sub btnEmail_Click(sender As Object, e As System.EventArgs) Handles btnEmail.Click
        'Send report pdf
        PDF_Make(Me.PID.Text)
        Dim sPDF(0) As String, sSql As String

        sPDF(0) = sReportFileName
        'Send to Me.EmailAddress.Text

        Trace.Warn("Sender: " & ConfigurationManager.AppSettings("sender"))
        Trace.Warn("To: " & Me.EmailAddress.Text)
        Trace.Warn("Message: " & fsMessage())
        Trace.Warn("PDF: " & sReportFileName)

        CF.Email_Send(ConfigurationManager.AppSettings("sender"), Me.EmailAddress.Text, "", "Your Seven Tudes Results", fsMessage(), sPDF)

        'Trace.Warn("Message: " & fsMessage())

        'Save Email Address
        sSql = "Update Participants set EmailAddress='" & Me.EmailAddress.Text & "' where PID=" & Me.PID.Text
        Trace.Warn(sSql)
        CF.Runquery(sSql)

        Me.Message.Attributes.Add("style", "display:block")
        Me.Message.Text = "Your results have been emailed." '& Me.EmailAddress.Text

    End Sub

    Function fsMessage() As String
        fsMessage = "<!doctype html><html><head><meta name=""viewport"" content=""width=device-width""><meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8""><title>Seven Tudes</title></head>"
        fsMessage &= "<body bgcolor=""#EEEEEE"" style=""font-family:Arial, Helvetica, sans-serif;font-size:11pt;"">"
        fsMessage &= "<table align=""center"" width=""800"" cellpadding=""0"" cellspacing=""0"" style=""background-color:#fff; margin: 0px auto; border:1px solid #BBBBBB; padding:30px;""><tr><td><img src=""http://7tudes.ppistaging.com/images/thunderbird_sogm_logo.png""/><img src=""http://7tudes.ppistaging.com/images/university_of_hartford_logo.png""/></td></tr>"
        fsMessage &= "<tr><td valign=""top"" style=""padding:30px; border-top:4px solid #AAA; font-family:Arial, Helvetica, sans-serif;font-size:11pt;"">"
        fsMessage &= "<p>Thank you for taking the free online Seven Tudes. Attached you will find your report. </p>"
        fsMessage &= "<p>Should you have any questions, please contact us.</p>"
        fsMessage &= "<p>For more information visit </b><a href=""http://www.seventudes.com"">www.seventudes.com</a>.</p>"
        fsMessage &= "<p>Team</p></td></tr>"

        'fsMessage &= "<tr><td style=""padding:30px; background-color: #fff; border-top:3px solid #AAA;""><TABLE><TR><TD width=""175""><A title=""Click here to learn more About Us"" href=""https://www.jjhpi.com"" alt=""Click here to learn more About Us"" height=""77"" width=""238"" target=""_blank""><IMG title=""Johnson & Johnson: Human Performance Institute"" alt=""Johnson & Johnson: Human Performance Institute"" src=""http://energyprofile.ppistaging.com/images/jnjhpi_free_trans_logo.png"" width=""150""></A></TD><TD><DIV style=""padding: 10px; paddin-left: 0px; color:#808285; font-size:10pt;font-family:Arial, Helvetica, sans-serif;"">If you are experiencing technical difficulties, please contact us by email.<br/>For questions about completing the survey please contact us at 1.407.438.9911 or by email.</TD></TR></TABLE></td></tr>"
        'fsMessage &= "<tr><td style=""padding:10px; background-color: #002d5d; font-size:10pt; color:#fff; text-align:center;font-family:Arial, Helvetica, sans-serif;""><p>&copy; Johnson & Johnson Human Performance Institute, division of Johnson & Johnson Health and Wellness Solutions, Inc. 2010 – 2015</p></td></tr></table></body></html>"

        fsMessage &= "</table></body></html>"

    End Function
    Sub PDF_Make(PID As Long)
        Dim d1 As Doc
        Dim sUrl As String, theID As Integer
        Dim i1 As Integer, sFooter1 As String, sFooter2 As String, sFooter As String


        XSettings.License = "810-031-225-276-6105-881"

        d1 = New Doc

        sUrl = ConfigurationManager.AppSettings("url_free") & "/profile.aspx?Print=Y&PID=" & PID

        Dim RandomClass As New Random()
        sUrl &= "&A=" & RandomClass.Next()
        RF.Trace_Warn(sUrl)
        'Exit Sub


        'Create PDF
        d1.Rect.Position(52, 42) 'was 52
        d1.Rect.Width = 520
        d1.Rect.Height = 730 'was 720
        d1.Page = d1.AddPage()


        theID = d1.AddImageUrl(sUrl, True, 0, False)
        Do
            If Not d1.Chainable(theID) Then Exit Do
            d1.Page = d1.AddPage()
            theID = d1.AddImageToChain(theID)
        Loop

        'Add Footer line 
        d1.Rect.Position(52, 40)
        d1.Rect.Width = 520
        d1.Rect.Height = 1
        d1.Color.String = "0 0 0"
        For i1 = 1 To d1.PageCount
            d1.PageNumber = i1
            d1.FillRect()
        Next i1

        'Add footer
        sFooter1 = "© 2016 Thunderbird School of Global Management and University of Hartford Barney School of Business. All rights reserved."
        sFooter2 = Today.ToLongDateString()
        sFooter2 = Mid(sFooter2, InStr(sFooter2, ",") + 1)

        sFooter = sFooter1 & ", " & sFooter2
        'sFooter = "<table style=""background-color: #002d5d; padding:20px""><tr><td valign=""middle"">"
        'sFooter &= "<font size=1>© Johnson & Johnson Human Performance Institute, a division of Johnson & Johnson Health and Wellness Solutions, Inc.</font>"
        'sFooter &= "</td><td valign=""middle"" align=""right"" style=""padding-left:50px;""><font size=1>"
        'sFooter &= Mid(Today.ToLongDateString(), InStr(Today.ToLongDateString(), ",") + 1)
        'sFooter &= "</font></td></tr></table>"

        'd1.Font = d1.EmbedFont("Arial", "Unicode", False, True)
        For i1 = 1 To d1.PageCount
            d1.PageNumber = i1

            d1.Rect.Position(0, 0)
            d1.Rect.Width = 640
            d1.Rect.Height = 40
            d1.HPos = 0.4
            d1.VPos = 0.4
            'd1.FrameRect()

            'd1.Rect.Inset(730, -40)
            d1.Color.String = "0 45 93"
            d1.FillRect()

            Dim thePageFont As String = "Arial"
            d1.Font = d1.AddFont(thePageFont)
            d1.FontSize = 8
            d1.Color.String = 255
            d1.AddText(sFooter)

            'd1.Rect.Position(460, 18)
            'd1.Rect.Width = 100
            'd1.Rect.Height = 20
            'd1.HPos = 1.0
            'd1.FrameRect()
            'd1.AddHtml(sFooter2)
        Next i1


        For i1 = 1 To d1.PageCount
            d1.PageNumber = i1
            d1.Flatten()
        Next

        sReportFileName = ConfigurationManager.AppSettings("ReportsFolderName") & "Seven_Tudes_Report_" & PID & ".pdf"
        sReportFileName = System.Web.HttpContext.Current.Server.MapPath(sReportFileName)
        RF.Trace_Warn(sReportFileName)
        d1.Save(sReportFileName)
        d1.Dispose()
        d1 = Nothing
    End Sub

    Protected Sub Page_PreInit(sender As Object, e As System.EventArgs) Handles Me.PreInit
        If Request.QueryString("Print") = "Y" Then
            Me.MasterPageFile = "free_report.master"
        End If
    End Sub
End Class
