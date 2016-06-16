
Partial Class Report_Profile3
    Inherits System.Web.UI.Page

    Dim iQNo As Integer, i1 As Integer
    Dim MasterPID As Long
    Dim Has360 As Boolean, bIsComposite As Boolean
    Dim dvReportLabels As System.Data.DataView, dvRels As System.Data.DataView
    Dim ptemp1 As Report_Pyramid3
    Dim ptemp2 As Report_Gaps3
    Dim L1 As Label, L2 As Label
    Dim sCulture As String, sDateFormat As String


    Dim iRecodeCount As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dv1 As System.Data.DataView, i1 As Integer, ctl As Control
        'dv1 = CF.DataView_Get("Select Top 1 QNo from Results_Q where PID In (" & Request.QueryString("PIDList") & ") and RelID>1")
        'Me.pGaps.Visible = (dv1.Table.Rows.Count = 1)
        'Me.pHighLow.Visible = Me.pGaps.Visible
        dv1 = Me.rsPyr.Select(DataSourceSelectArguments.Empty)
        ReportLabels_Set()

        Branding.BrandLogo_Set(Me.brandlogo, dv1.Table.Rows(0)("BrandCode"))

        Me.cover_pname.Text = dv1.Table.Rows(0)("PName")
        If InStr(Me.cover_pname.Text, "Multi-Group Composite") > 0 Then
            Me.cover_pname.Text = Replace(Me.cover_pname.Text, " Multi-", " Multi-")
        End If

        'Me.cover_reportdate.Text = Format(dv1.Table.Rows(0)("ReportDate"), "MMMM yyyy")
        'Me.cover_reportdate.Text = ReportDate_Get(dv1.Table.Rows(0)("ReportDate"), "MMMM") ', "MMMM yyyy")
        Me.cover_reportdate.Text = ReportDate_Get(dv1.Table.Rows(0)("ReportDate"))

        'MasterPID_set()
        MasterPID = dv1.Table.Rows(0)("PID")
        Has360 = dv1.Table.Rows(0)("Has360")
        bIsComposite = (dv1.Table.Rows(0)("GroupCode") = 1)

        Me.pRR2.Visible = Has360
        Me.pGaps_Overview.Visible = Has360
        Me.pGaps.Visible = Has360
        If Has360 Then
            Me.graph_static1.Src = "../images/graph_360.png"
            For i1 = 2 To 5
                L1 = Me.pCategories_Overview.FindControl("score1_" & i1)
                L1.Text = Replace(ReportLabel_Get("profile_relscores"), "|relname|", fsRelName(i1))

                L2 = Me.pDimensions_Overview.FindControl("score2_" & i1)
                L2.Text = L1.Text
            Next
        Else
            Me.graph_static1.Src = "../images/graph_self.png"
            For i1 = 0 To Me.Form.Controls(1).Controls.Count - 1
                Trace.Warn(Me.Form.Controls(1).Controls(i1).ID & "=" & Me.Form.Controls(1).Controls(i1).Controls.Count)
            Next
            For i1 = 2 To 6
                ctl = Me.pCategories_Overview.FindControl("legrow1_" & i1)
                ctl.Visible = False

                ctl = Me.pDimensions_Overview.FindControl("legrow2_" & i1)
                ctl.Visible = False
            Next
        End If
        Me.graph_static2.Src = Me.graph_static1.Src
        Me.pKid.Visible = Has360
        Me.reporttextC2.Visible = Has360
        Me.tabTally.Visible = Has360
        If Has360 Then
            Me.cover_reporttype.Text = ReportLabel_Get("profile_360") '"360 Seven Tudes"
        Else
            Me.cover_reporttype.Text = ReportLabel_Get("profile_self") ' "Energy Self Profile"
        End If


        'Language text
        'ReportLabels_Set()
        Me.profile_symbols.Text = ReportLabel_Get("profile_symbols")
        Me.profile_symbols2.Text = Me.profile_symbols.Text
        Me.profile_fd1.Text = ReportLabel_Get("profile_feedbackdetail")
        Me.profile_toc.Text = ReportLabel_Get("profile_toc")

        Me.profile_rr1.Text = ReportLabel_Get("profile_rr")
        Me.profile_rr2.Text = ReportLabel_Get("profile_rr")
        Me.profile_rr3.Text = ReportLabel_Get("profile_rr")
        Me.profile_rr4.Text = ReportLabel_Get("profile_rr")

        Me.profile_overviewofresults2.Text = ReportLabel_Get("profile_overviewofresults")
        Me.profile_overviewofresults4.Text = ReportLabel_Get("profile_overviewofresults")

        Me.profile_selfscore1.Text = ReportLabel_Get("profile_selfscore")
        Me.profile_normscore1.Text = ReportLabel_Get("profile_normscore")
        Me.profile_selfscore2.Text = ReportLabel_Get("profile_selfscore")
        Me.profile_normscore2.Text = ReportLabel_Get("profile_normscore")

        Me.profile_additionalresources.Text = ReportLabel_Get("profile_additionalresources")
        Me.profile_keytakeaways.Text = ReportLabel_Get("profile_keytakeaways")

    End Sub

    Sub ReportLabels_Set()
        Dim sLanguageID As String


        If dvReportLabels Is Nothing Then
            sLanguageID = 1
            If Request.QueryString("LanguageID") <> "" Then
                sLanguageID = Request.QueryString("LanguageID")
            End If

            'Set Culture
            dvReportLabels = CF.DataView_Get("Select Top 1 Culture, (Select Top 1 KeyValue from Resx where LanguageID=Languages.LanguageID and KeyName='date_report') as date_report from Languages where LanguageID=" & sLanguageID)
            sCulture = dvReportLabels.Table.Rows(0)("Culture")
            sDateFormat = dvReportLabels.Table.Rows(0)("date_report")

            'Set actual Report Labels
            dvReportLabels = CF.DataView_Get("Select KeyName, KeyValue from ReportLabels where LanguageID=" & sLanguageID & " order by KeyName")
        End If

        Me.profile_gap1.Text = ReportLabel_Get("profile_gap1")
        Me.profile_gap2.Text = ReportLabel_Get("profile_gap2")
        Me.profile_gap3.Text = ReportLabel_Get("profile_gap3")
        Me.profile_gap4.Text = ReportLabel_Get("profile_gap4")
        Me.profile_gap5.Text = ReportLabel_Get("profile_gap5")
        Me.profile_gapoverview.Text = ReportLabel_Get("profile_gapoverview")
        Me.profile_allrights.Text = ReportLabel_Get("profile_allrights")
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


    Protected Sub tabCommentQ_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles tabCommentQ.ItemDataBound
        Dim p1 As Panel
        p1 = e.Item.FindControl("QHeader")
        If e.Item.DataItem("QNo") = iQNo Then
            p1.Visible = False
        Else
            p1.Visible = True
            iQNo = e.Item.DataItem("QNo")
        End If

        'No comments
        Dim b1 As BulletedList
        b1 = e.Item.FindControl("Comments")
        'Trace.Warn("Comment Count=" & b1.Items.Count)

        If bIsComposite Then
            'b1.Items.Add("Individual responses are omitted to ensure privacy and confidentiality.")
            b1.Items.Add(ReportLabel_Get("profile_omittedprivacy"))
            b1.BulletStyle = BulletStyle.CustomImage
            b1.BulletImageUrl = "../images/spacer.jpg"
            b1.Font.Italic = True
        ElseIf b1.Items.Count = 0 Then
            'b1.Items.Add("No comments provided.")
            b1.Items.Add(ReportLabel_Get("profile_nocomments"))
            b1.BulletStyle = BulletStyle.CustomImage
            b1.BulletImageUrl = "../images/spacer.jpg"
            b1.Font.Italic = True
        End If

        L1 = e.Item.FindControl("profile_fd1")
        L1.Text = ReportLabel_Get("profile_feedbackdetail")


        L1 = e.Item.FindControl("profile_oeq")
        L1.Text = ReportLabel_Get("profile_oeq")

    End Sub


    Sub tabQ_Load(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType <> DataControlRowType.DataRow Then Exit Sub
        If e.Row.DataItem("IsComment") = "True" Then
            e.Row.Cells.Clear()
            Exit Sub
        End If
        If CF.NullToString(e.Row.DataItem("Avg1")) = "" Then
            e.Row.Cells(2).Text = "--"
        End If
    End Sub

    Protected Sub tabQ2_Load(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
        Else
            Exit Sub
        End If
        If e.Item.DataItem("QNo") <= 4 Then
            e.Item.Controls.Clear()
            Exit Sub
        End If
        Trace.Warn(e.Item.DataItem("QNo"))

        'Load Comments

        Dim b1 As BulletedList
        b1 = e.Item.FindControl("Comment")
        If bIsComposite Then
            'b1.Items.Add("Individual responses are omitted to ensure privacy and confidentiality.")
            b1.Items.Add(ReportLabel_Get("profile_omittedprivacy"))
        ElseIf b1.Items.Count = 0 Then
            'b1.Items.Add("No comments provided.")
            b1.Items.Add(ReportLabel_Get("profile_nocomments"))
        End If

        b1.BulletStyle = BulletStyle.CustomImage
        b1.BulletImageUrl = "../images/spacer.jpg"
        b1.Font.Italic = True

    End Sub

    Protected Sub tabAudit_Load(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
        Else
            Exit Sub
        End If
        Dim iValue As Single
        iValue = CF.NullToZero(e.Row.DataItem("A" & e.Row.DataItem("QNo")))
        e.Row.Cells(1).Text = CInt(100 * iValue / 7) & "%"

    End Sub



    Sub tabTally1_Load(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        'Trace.Warn(e.Row.Parent.Parent.Parent.Parent.ID)

        'HeaderText
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Text = ReportLabel_Get("profile_tallyrel")
            e.Row.Cells(1).Text = ReportLabel_Get("profile_tallycount")
            iRecodeCount = 0
            Exit Sub
        End If



        Dim L1 As Label
        L1 = e.Row.Parent.Parent.Parent.FindControl("PID")
        Trace.Warn(L1.Text)
        If e.Row.RowType <> DataControlRowType.DataRow Then Exit Sub

        'Show only the rows for the current participant
        If e.Row.DataItem("PID") = L1.Text Then
            'IsRecoded
            If CF.NullToZero(e.Row.DataItem("IsRecoded")) > 0 Then
                'L1 = e.Row.Parent.Parent.Parent.FindControl("IsRecoded")
                'L1.Visible = True
                L1 = e.Row.Parent.Parent.Parent.FindControl("profile_recoded")
                L1.Visible = True
            End If
            iRecodecount = e.Row.DataItem("RelCount")
        Else
            e.Row.Cells.Clear()
        End If



    End Sub

    Function fsBool(ByVal s1) As String
        If CF.NullToString(s1) = "" Then
            fsBool = ""
        Else
            fsBool = "(*)"
        End If
    End Function


    'Protected Sub tabTally_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabTally.PreRender
    '    If Me.tabTally.Items.Count = 1 Then
    '        Dim L1 As Label
    '        L1 = Me.tabTally.Items(0).FindControl("PName")
    '        L1.Visible = False

    '        L1 = Me.tabTally.Items(0).FindControl("ReportDate")
    '        L1.Visible = False

    '    End If
    'End Sub

    Protected Sub reporttextA1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles reporttextA1.PreRender
        Me.reporttextA1.pPID = MasterPID
    End Sub

    Protected Sub reporttextA2_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles reporttextA2.PreRender
        Me.reporttextA2.pPID = MasterPID
    End Sub

    Sub MasterPID_set()
        If MasterPID > 0 Then Exit Sub

        Trace.Warn("Setting MasterPID")
        Dim dv1 As System.Data.DataView
        dv1 = Me.rsPyr.Select(DataSourceSelectArguments.Empty)
        MasterPID = dv1.Table.Rows(0)("PID")
        Has360 = dv1.Table.Rows(0)("Has360")
        Me.pRR2.Visible = Has360
        Me.pGaps_Overview.Visible = Has360
        Me.pGaps.Visible = Has360
        Me.legend2.Visible = Has360
        Me.legend3.Visible = Has360
        Me.legend4.Visible = Has360

    End Sub

    Protected Sub reporttextB_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles reporttextB.PreRender
        Me.reporttextB.pPID = MasterPID
    End Sub

    Protected Sub reporttextC1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles reporttextC1.PreRender
        Me.reporttextC1.pPID = MasterPID
    End Sub

    Protected Sub reporttextC2_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles reporttextC2.PreRender
        Me.reporttextC2.pPID = MasterPID
    End Sub
    Protected Sub TOC1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles TOC1.PreRender
        If Has360 Then
            Me.TOC1.pSurveyTypeID = 2
        Else
            Me.TOC1.pSurveyTypeID = 1
        End If
    End Sub

    Protected Sub reporttextD_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles reporttextD.PreRender
        Me.reporttextD.pPID = MasterPID

    End Sub

    Protected Sub reporttextE_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles reporttextE.PreRender
        Me.reporttextE.pPID = MasterPID

    End Sub

    Protected Sub tabRels_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles tabRels.ItemDataBound
        If CF.NullToString(e.Item.DataItem("IsRecoded")) <> "" Then
            Dim L1 As Label
            L1 = e.Item.FindControl("profile_recoded_gaps")
            L1.Visible = True
            L1.Text = "<br>" & ReportLabel_Get("profile_recoded_gaps")
        End If

        'gaps
        ptemp2 = e.Item.FindControl("gap1")
        ptemp2.plargestgaps = ReportLabel_Get("gaps_largestgaps")
        ptemp2.pnoresponses = ReportLabel_Get("gaps_noresponses")
        ptemp2.pdimension = ReportLabel_Get("gaps_dimension")
        ptemp2.pfactor = ReportLabel_Get("gaps_factor")
        ptemp2.pselfscore = ReportLabel_Get("gaps_selfscore")
        ptemp2.praterscore = ReportLabel_Get("gaps_raterscore")
        ptemp2.pgap = ReportLabel_Get("gaps_gap")

        '"Overiew of Results" label
        L1 = e.Item.FindControl("profile_overviewofresults")
        L1.Text = ReportLabel_Get("profile_overviewofresults")

        'Gap Analysis Label
        L1 = e.Item.FindControl("Relname")
        L1.Text = ReportLabel_Get("profile_gapanalysis") & " -- " & e.Item.DataItem("RelName")
    End Sub

    Protected Sub tabPyr_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles tabPyr.ItemDataBound
        ptemp1 = e.Item.FindControl("pyr1")
        If Has360 Then
            ptemp1.para1 = ReportLabel_Get("pyr_para1_360")
        Else
            ptemp1.para1 = ReportLabel_Get("pyr_para1_self")
        End If
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

        'Overview of results label
        L1 = e.Item.FindControl("profile_overviewofresults")
        L1.Text = ReportLabel_Get("profile_overviewofresults")


    End Sub

    Protected Sub tabCat_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles tabCat.ItemDataBound
        L1 = e.Item.FindControl("CatName")
        L1.Text = ReportLabel_Get("profile_dimsumm") & " -- " & e.Item.DataItem("CatName")


        L1 = e.Item.FindControl("profile_overviewofresults")
        L1.Text = ReportLabel_Get("profile_overviewofresults")


    End Sub

    Protected Sub tabAuditMain_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles tabAuditMain.ItemDataBound
        L1 = e.Item.FindControl("profile_fd1")
        L1.Text = ReportLabel_Get("profile_feedbackdetail")

    End Sub

    Protected Sub tabDim_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles tabDim.ItemDataBound
        L1 = e.Item.FindControl("profile_fd1")
        L1.Text = ReportLabel_Get("profile_feedbackdetail")
    End Sub

    Protected Sub tabParticipant_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles tabParticipant.ItemDataBound
        L1 = e.Item.FindControl("profile_fd1")
        L1.Text = ReportLabel_Get("profile_feedbackdetail")

        L1 = e.Item.FindControl("profile_cf")
        L1.Text = ReportLabel_Get("profile_cf")

    End Sub

    Protected Sub tabTally_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles tabTally.ItemDataBound
        L1 = e.Item.FindControl("profile_recoded")

        If iRecodeCount >= 2 Then
            L1.Text = ReportLabel_Get("profile_recoded_combined")
        Else
            L1.Text = ReportLabel_Get("profile_recoded_suppressed")
        End If
    End Sub

    Protected Sub tabSR_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles tabSR.ItemDataBound
        L1 = e.Item.FindControl("profile_overviewofresults")
        L1.Text = ReportLabel_Get("profile_overviewofresults")
    End Sub

    Function fsRelname(ByVal iRelID As Integer) As String
        If dvRels Is Nothing Then
            dvRels = Me.rsRels.Select(DataSourceSelectArguments.Empty)
        End If

        For i1 = 0 To dvRels.Table.Rows.Count - 1
            If dvRels.Table.Rows(i1)("RelID") = IRelID Then
                fsRelname = dvRels.Table.Rows(i1)("RelName")
                Exit Function
            End If
        Next
        fsRelname = iRelID & " relname not found"
    End Function

    Function ReportDate_Get_Orig(dReportDate As Date, sFormat As String) As String
        ReportDate_Get_Orig = dReportDate.ToString(sFormat, New System.Globalization.CultureInfo(sCulture)) & " " & dReportDate.Year
    End Function

    Function ReportDate_Get(dReportDate As Date) As String
        ReportDate_Get = Emailsv4.LangDate_Get(dReportDate, sDateFormat, sCulture)
    End Function

    Protected Sub Page_PreInit(sender As Object, e As System.EventArgs) Handles Me.PreInit
        'If Request.QueryString("LanguageID") = 6 Then
        '    Me.Theme = "JP"
        'End If
    End Sub
End Class
