Imports Microsoft.VisualBasic
Imports WebSupergoo.ABCpdf9
Partial Class Free_profile
    Inherits System.Web.UI.Page
    Dim dvReportlabels As System.Data.DataView
    Dim sCulture As String, sReportFileName As String

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

        Me.pyr1.pPID = Me.PID.Text
        Pyr_Set()
    End Sub

    Sub Pyr_Set()
        Dim ptemp1 As Report_Pyramid3, L1 As Label

        ptemp1 = Me.pyr1
        ptemp1.para1 = ReportLabel_Get("pyr_para1_self")
       
        ptemp1.para2 = ReportLabel_Get("pyr_para2")
        ptemp1.fullyengaged = ReportLabel_Get("pyr_fullyengaged")
        ptemp1.engaged = ReportLabel_Get("pyr_engaged")
        ptemp1.disengaged = ReportLabel_Get("pyr_disengaged")
        ptemp1.seriouslydisengaged = ReportLabel_Get("pyr_seriouslydisengaged")

        'Rels
        ptemp1.plabel_self = ReportLabel_Get("label_self")
        ptemp1.plabel_others = ReportLabel_Get("label_others")

        'TOC
        ptemp1.pheading = ReportLabel_Get("pyr_heading")

        
    End Sub

    Function ReportLabel_Get(ByVal sKeyName As String) As String
        Dim i1 As Integer

        If dvReportLabels Is Nothing Then ReportLabels_Set()

        For i1 = 0 To dvReportLabels.Table.Rows.Count - 1
            If dvReportLabels.Table.Rows(i1)("KeyName") = sKeyName Then
                ReportLabel_Get = dvReportLabels.Table.Rows(i1)("KeyValue")
                Exit Function
            End If
        Next
        ReportLabel_Get = sKeyName & " not found"
    End Function

    Sub ReportLabels_Set()
        Dim sLanguageID As String


        If dvReportLabels Is Nothing Then
            sLanguageID = 1
            If Request.QueryString("LanguageID") <> "" Then
                sLanguageID = Request.QueryString("LanguageID")
            End If

            'Set Culture
            dvReportLabels = CF.DataView_Get("Select Top 1 Culture from Languages where LanguageID=" & sLanguageID)
            sCulture = dvReportLabels.Table.Rows(0)("Culture")

            'Set actual Report Labels
            dvReportLabels = CF.DataView_Get("Select KeyName, KeyValue from ReportLabels where LanguageID=" & sLanguageID & " order by KeyName")
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

        CF.Email_Send(ConfigurationManager.AppSettings("sender"), Me.EmailAddress.Text, "", "Your Seven Tudes Results", fsMessage(), sPDF)

        'Save Email Address
        sSql = "Update Participants set EmailAddress='" & Me.EmailAddress.Text & "' where PID=" & Me.PID.Text
        Trace.Warn(sSql)
        CF.Runquery(sSql)

        Me.Message.Attributes.Add("style", "display:block")
        Me.Message.Text = "Your results have been emailed." '& Me.EmailAddress.Text

    End Sub

    Function fsMessage() As String
        fsMessage = "<!doctype html><html><head><meta name=""viewport"" content=""width=device-width""><meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8""><title>Johnson & Johnson - Human Performance Institute</title></head>"
        fsMessage &= "<body bgcolor=""#EEEEEE"" style=""font-family:Arial, Helvetica, sans-serif;font-size:11pt;"">"
        fsMessage &= "<table align=""center"" width=""800"" cellpadding=""0"" cellspacing=""0"" style=""background-color:#fff; margin: 0px auto; border:1px solid #BBBBBB; padding:30px;""><tr><td><img src=""http://energyprofile.ppistaging.com/images/jnjhpi_free_trans_logo.png"" width=""300"" title=""Johnson & Johnson: Human Performance Institute"" alt=""Johnson & Johnson: Human Performance Institute""/></td></tr>"
        fsMessage &= "<tr><td valign=""top"" style=""padding:30px; border-top:4px solid #AAA; font-family:Arial, Helvetica, sans-serif;font-size:11pt;"">"
        fsMessage &= "<p>Thank you for taking the free online Seven Tudes from the Johnson & Johnson Human Performance Institute. Attached you will find your report. The scores provide a broad picture of your engagement in each of the four energy dimensions and your preliminary overall engagement score. Read the definitions of each engagement level to help you interpret your overall engagement score.</p>"
        fsMessage &= "<p>Should you have any questions, please contact us at <a href=""mailto:info@hpinstitute.com"">info@hpinstitute.com</a> or 407.438.9911. To learn more about Johnson & Johnson Human Performance Institute’s training solutions for individuals, teams and organizations, visit <a href=""http://www.jjhpi.com"">www.jjhpi.com.</a></p>"
        fsMessage &= "<p>The Johnson & Johnson Human Performance Institute Team</p></td></tr>"
        fsMessage &= "<tr><td style=""padding:30px; background-color: #fff; border-top:3px solid #AAA;""><TABLE><TR><TD width=""175""><A title=""Click here to learn more About Us"" href=""https://www.jjhpi.com"" alt=""Click here to learn more About Us"" height=""77"" width=""238"" target=""_blank""><IMG title=""Johnson & Johnson: Human Performance Institute"" alt=""Johnson & Johnson: Human Performance Institute"" src=""http://energyprofile.ppistaging.com/images/jnjhpi_free_trans_logo.png"" width=""150""></A></TD><TD><DIV style=""padding: 10px; paddin-left: 0px; color:#808285; font-size:10pt;font-family:Arial, Helvetica, sans-serif;"">If you are experiencing technical difficulties, please contact us by email.<br/>For questions about completing the survey please contact us at 1.407.438.9911 or by email.</TD></TR></TABLE></td></tr>"
        fsMessage &= "<tr><td style=""padding:10px; background-color: #002d5d; font-size:10pt; color:#fff; text-align:center;font-family:Arial, Helvetica, sans-serif;""><p>&copy; Johnson & Johnson Human Performance Institute, division of Johnson & Johnson Health and Wellness Solutions, Inc. 2010 – 2015</p></td></tr></table></body></html>"

        'fsMessage &= "Dear " & Me.EmailAddress.Text & ", "
        'fsMessage &= "<br><br>"
        'fsMessage &= "Thank you for taking the free online Seven Tudes from the Johnson & Johnson Human Performance Institute. Attached you will find your report. The scores provide a broad picture of your engagement in each of the four energy dimensions and your preliminary overall engagement score. Read the definitions of each engagement level to help you interpret your overall engagement score."
        'fsMessage &= "<br><br>"
        ''fsMessage &= "<b>Next Steps</b>"
        ''fsMessage &= "<ul>"
        ''fsMessage &= "<li>Sign up for the free <a href=""http://www.hpinstitute.com"" target=""rel"">Corporate Athlete<sup>&reg;</sup> Edge e-newsletter</a><br>&nbsp; </li>"
        ''fsMessage &= "<li>Attend a 2.5 day <a href=""https://www.hpinstitute.com/training-solutions/corporate-athlete"" target=""rel"">Corporate Athlete<sup>&reg;</sup> Course</a><br>&nbsp; </li>"
        ''fsMessage &= "<li>Bring <a href=""https://www.hpinstitute.com/training-solutions"" target=""rel"">Energy Management training</a> to your organization<br>&nbsp; </li>"
        ''fsMessage &= "<li>Gain insights into achievement and innovative energy management techniques as described in <a href=""https://www.hpinstitute.com/research-press/publications"" target=""rel"">The Only Way to Win book</a> by Human Performance Institute co-founder and thought leader Dr. Jim Loehr <br>&nbsp; </li>"
        ''fsMessage &= "</ul>"

        'fsMessage &= "Should you have any questions, please contact us at <a href=""mailto:info@hpinstitute.com"">info@hpinstitute.com</a> or 407.438.9911."
        'fsMessage &= "<br><br>"
        'fsMessage &= "The Johnson & Johnson Human Performance Institute Team"
        'fsMessage &= "</div>"
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
        sFooter1 = ""
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
            d1.Rect.Height = 60
            d1.HPos = 0.4
            d1.VPos = 0.4
            'd1.FrameRect()

            'd1.Rect.Inset(730, -40)
            d1.Color.String = "0 143 197"
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

        sReportFileName = ConfigurationManager.AppSettings("ReportsFolderName") & PID & ".pdf"
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
