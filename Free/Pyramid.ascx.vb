Imports ChartDirector

Partial Class Report_Pyramid3
    Inherits System.Web.UI.UserControl
    Dim iSelf(9) As Double
    Dim iOthers(9) As Double
    Dim i1 As Integer
    Dim c1 As ChartDirector.WebChartViewer
    Dim Labels(9) As String

    Public Property pPID() As Integer
        Get
            Return PID.Text
        End Get

        Set(ByVal Value As Integer)
            PID.Text = Value
        End Set
    End Property

    Public Property para2() As String
        Get
            Return Me.pyr_para2.Text
        End Get

        Set(ByVal Value As String)
            Me.pyr_para2.Text = Value
        End Set
    End Property

    Public Property para1() As String
        Get
            Return Me.pyr_para1.Text
        End Get

        Set(ByVal Value As String)
            Me.pyr_para1.Text = Value
        End Set
    End Property

    Public Property fullyengaged() As String
        Get
            Return Me.pyr_fullyengaged.Text
        End Get

        Set(ByVal Value As String)
            Me.pyr_fullyengaged.Text = Value
        End Set
    End Property

    Public Property engaged() As String
        Get
            Return Me.pyr_engaged.Text
        End Get

        Set(ByVal Value As String)
            Me.pyr_engaged.Text = Value
        End Set
    End Property

    Public Property disengaged() As String
        Get
            Return Me.pyr_disengaged.Text
        End Get

        Set(ByVal Value As String)
            Me.pyr_disengaged.Text = Value
        End Set
    End Property

    Public Property seriouslydisengaged() As String
        Get
            Return Me.pyr_seriouslydisengaged.Text
        End Get

        Set(ByVal Value As String)
            Me.pyr_seriouslydisengaged.Text = Value
        End Set
    End Property

    Public Property plabel_self() As String
        Get
            Return Me.label_self.Text
        End Get

        Set(ByVal Value As String)
            Me.label_self.Text = Value
        End Set
    End Property

    Public Property plabel_others() As String
        Get
            Return Me.label_others.Text
        End Get

        Set(ByVal Value As String)
            Me.label_others.Text = Value
        End Set
    End Property

    Public Property pheading() As String
        Get
            Return Me.pyr_heading.Text
        End Get

        Set(ByVal Value As String)
            Me.pyr_heading.Text = Value
        End Set
    End Property


    Sub Pyramid_Draw(ByVal Avg() As Double, ByVal c1 As ChartDirector.WebChartViewer)
        Dim i1 As Integer
        Chart.setLicenseCode("DEVP-348S-FXXS-WHSU-9B5A-E259")
        Trace.Warn("Drawing ")
        ' The data for the pyramid chart
        'Dim data() As Double = {65, 35, 75, 25, 86, 14, 95, 5}

        ' The pLabels for the pyramid chart
        'Dim Labels() As String = {"Physical", "", "Emotional", "", "Mental", "", "Spiritual", ""}

        ' The colors for the pyramid layers
        'Dim colors() As Integer = {&H66AAEE, Chart.Transparent, &HEEBB22, Chart.Transparent, &HCCCCCC, Chart.Transparent, &HCC88FF, Chart.Transparent}
        Dim colors() As Integer = {&H88EC641, Chart.Transparent, &H843C4DD, Chart.Transparent, &H8B42E34, Chart.Transparent, &H8FCB817, Chart.Transparent}

        ' Create a PyramidChart object of size 360 x 360 pixels
        Dim c As PyramidChart = New PyramidChart(500, 300)

        ' Set the pyramid center at (180, 180), and width x height to 150 x 180 pixels
        'c.setPyramidSize(200, 192, 100, 352)
        c.setPyramidSize(270, 150, 150, 250)

        'c.setViewAngle(15, 15)
        c.setGradientShading(1, 1)
        'c.adjustBrightness(1, 1)

        ' Set the pyramid data and pLabels
        c.setData(Avg, Labels)

        ' Set the layer colors to the given colors
        c.setColors2(Chart.DataColor, colors)

        ' Add labels at the center of the pyramid layers using Arial Bold font. The
        ' labels will have two lines showing the layer name and percentage.
        'c.setCenterLabel("{label}<*br*>{percent}%", "Arial Bold")
        'c.setLeftLabel("{label}<*br*>{percent}%", "Arial Bold")
        'c.setBorder(&H0) ' border

        c.setLayerGap(0.0000001)

        'Note: the following code must be executed only after PyramidChart.setData
        For i1 = 0 To UBound(colors)
            If colors(i1) = Chart.Transparent Then
                'show border and label only for non-transparent layers
                'c.getLayer(i1).setLayerBorder(colors(i1 - 1), 5)
                c.getLayer(i1).setLayerBorder(colors(i1 - 1), 1)
            Else
                'c.getLayer(i1).setLayerBorder(colors(i1), 5)
                c.getLayer(i1).setLayerBorder(colors(i1), 1)
                c.getLayer(i1).setLeftLabel(Labels(i1) & "<*br*>{value}%")
            End If
        Next

        'c.setLayerBorder(&H0)
        ' Output the chart
        c1.Image = c.makeWebImage(Chart.PNG)
    End Sub


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        PyrData_Load()
    End Sub

    Sub PyrData_Load()
        Dim dv1 As System.Data.DataView, iCatNo As Integer
        'Exit Sub
        Dim iSum1 As Integer, iSum9 As Integer
        Dim iCount1 As Integer, iCount9 As Integer
        Trace.Warn(">>>>>>" & Me.PID.Text)
        dv1 = Me.rsData.Select(DataSourceSelectArguments.Empty)
        For i1 = 0 To dv1.Table.Rows.Count - 1
            iCatNo = (dv1.Table.Rows(i1)("ItemNo") - 1) * 2


            iSelf(iCatNo) = CInt(CF.NullToZero(dv1.Table.Rows(i1)("Avg1")))
            Trace.Warn(">>>>>" & iCatNo)
            iSelf(iCatNo + 1) = 100 - iSelf(iCatNo)

            iOthers(iCatNo) = CInt(CF.NullToZero(dv1.Table.Rows(i1)("Avg9")))
            iOthers(iCatNo + 1) = 100 - iOthers(iCatNo)

            Labels(iCatNo) = CF.NullToString(dv1.Table.Rows(i1)("ItemName"))
            If Right(Labels(iCatNo), 4) = "ssig" Then
                Labels(iCatNo) = Left(Labels(iCatNo), 8) & "-<*br*>" & Mid(Labels(iCatNo), 9)
            End If

            Labels(iCatNo + 1) = ""

            If iSelf(iCatNo) > 0 Then
                iSum1 = iSum1 + iSelf(iCatNo)
                iCount1 = iCount1 + 1
            End If

            If iOthers(iCatNo) > 0 Then
                iSum9 = iSum9 + iOthers(iCatNo)
                iCount9 = iCount9 + 1
            End If
        Next

        Pyramid_Draw(iSelf, Me.pyr1)
        If iOthers(0) > 0 Then
            Pyramid_Draw(iOthers, Me.pyr9)
            'Me.pyramid_3601.Visible = True
        Else
            Me.pyr9.Visible = False
            Me.raters_pyr.Visible = False
            Me.raters_score.Visible = False
            'Me.raters_text.Visible = False
            'Me.pyramid_3601.Visible = False
        End If
        'Me.pyrmaid_self1.Visible = Not Me.pyramid_3601.Visible

        'Overall Scores
        If iCount1 = 0 Then
            Me.SelfScore.Text = "0%"
        Else
            Me.SelfScore.Text = CInt(iSum1 / iCount1) & "%"
        End If

        If iCount9 = 0 Then
            Me.OthersScore.Text = "0%"
        Else
            Me.OthersScore.Text = CInt(iSum9 / iCount9) & "%"
        End If
    End Sub
End Class
