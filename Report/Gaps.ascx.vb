Imports ChartDirector
Partial Class Report_Gaps3
    Inherits System.Web.UI.UserControl
    Dim dataX(2) As Double
    Dim c1 As ChartDirector.WebChartViewer

    Public Property pPID() As Integer
        Get
            Return PID.Text
        End Get

        Set(ByVal Value As Integer)
            PID.Text = Value
        End Set
    End Property


    Public Property pRelID() As Integer
        Get
            Return RelID.Text
        End Get

        Set(ByVal Value As Integer)
            RelID.Text = Value
        End Set
    End Property

    Public Property plargestgaps() As String
        Get
            Return Me.largestgaps.Text
        End Get

        Set(ByVal Value As String)
            Me.largestgaps.Text = Value
        End Set
    End Property

    Public Property pdimension() As String
        Get
            Return Me.gaps_dimension.Text
        End Get

        Set(ByVal Value As String)
            Me.gaps_dimension.Text = Value
        End Set
    End Property

    Public Property pfactor() As String
        Get
            Return Me.gaps_factor.Text
        End Get

        Set(ByVal Value As String)
            Me.gaps_factor.Text = Value
        End Set
    End Property

    Public Property pselfscore() As String
        Get
            Return Me.gaps_selfscore.Text
        End Get

        Set(ByVal Value As String)
            Me.gaps_selfscore.Text = Value
        End Set
    End Property

    Public Property praterscore() As String
        Get
            Return Me.gaps_raterscore.Text
        End Get

        Set(ByVal Value As String)
            Me.gaps_raterscore.Text = Value
        End Set
    End Property

    Public Property pgap() As String
        Get
            Return Me.gaps_gap.Text
        End Get

        Set(ByVal Value As String)
            Me.gaps_gap.Text = Value
        End Set
    End Property


    Public Property pnoresponses() As String
        Get
            Return Me.noresponses.Text
        End Get

        Set(ByVal Value As String)
            Me.noresponses.Text = Value
        End Set
    End Property


    Sub Gaps_Draw(ByVal dataX() As Double, ByVal iRelID As Int16, ByVal chart1 As WebChartViewer)
        Chart.setLicenseCode("DEVP-348S-FXXS-WHSU-9B5A-E259")

        ' In this example, the data points are unevenly spaced on the x-axis
        Dim dataY() As Double = {1, 1}
        'Dim dataX() As Double = {4.5, 4.0}

        ' Data points are assigned different symbols based on point type
        Dim pointType() As Double = {0, 2}
        Dim labels() As String = {0, 1, 2, 3, 4, 5, 6, 7} ', "2002", "2003", "2004", "2005"}

        ' Create a XYChart object of size 600 x 300 pixels, with a light purple (ffccff)
        ' background, black border, 1 pixel 3D border effect and rounded corners.
        Dim c As XYChart = New XYChart(400, 60) ', &HFFFFFF, &HFFFFFF, 0)
        'c.setBackground(&HFF)
        c.setPlotArea(10, 10, 380, 30, -1, -1, &H0, Chart.Transparent, c.dashLineColor(&H0, Chart.DotLine))

        'chart1.Image = c.makeWebImage(Chart.PNG)
        'Exit Sub

        Dim layer As LineLayer
        If dataX(0) > dataX(1) Then
            layer = c.addLineLayer(dataY, &H6600)   'green
        Else
            layer = c.addLineLayer(dataY, &HCC0000) 'red
        End If

        layer.setXData((dataX))
        layer.setLineWidth(14)
        ' Set axis labels to use Arial Bold font

        c.yAxis().setTickColor(&HFFFFFF)
        c.yAxis().setLabelStyle("Arial Bold", "0", &HFFFFFF)
        c.xAxis().setLabelStyle("Arial Bold", "8", &H0)

        c.xAxis().setLabels(labels)
        c.xAxis().setMargin(8, 8)

        ' output the chart
        chart1.Image = c.makeWebImage(Chart.PNG)

    End Sub



    'Protected Sub tabGaps_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles tabGaps.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        dataX(0) = e.Row.DataItem("RaterAvg")
    '        dataX(1) = e.Row.DataItem("SelfAvg")
    '        c1 = e.Row.FindControl("chart1")
    '        Gaps_Draw(dataX, Me.RelID.Text, c1)
    '    End If

    'End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Trace.Warn("Prerendering " & Me.RelID.Text)
        Dim dv As System.Data.DataView, i1 As Integer, dt As System.Data.DataTable
        Dim dr As System.Data.DataRow, dc As System.Data.DataColumn

        'Get the view
        dv = Me.rsGaps.Select(DataSourceSelectArguments.Empty)
        dv.Sort = "AbsGap Desc"

        While dv.Count > 3
            dv.Item(3).Delete()
        End While

        Me.tabHighest.DataSource = dv
        Me.tabHighest.DataBind()



    End Sub

   



    Protected Sub tabGaps_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles tabGaps.RowDataBound
        If e.Row.RowType = DataControlRowType.EmptyDataRow Then
            Dim L1 As Label
            L1 = e.Row.FindControl("noresponses")
            L1.Text = Me.noresponses.Text
            Exit Sub
        End If

       

    End Sub

    Protected Sub tabHighest_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles tabHighest.RowDataBound
        If e.Row.RowType = DataControlRowType.EmptyDataRow Then
            Dim L1 As Label
            L1 = e.Row.FindControl("noresponses")
            L1.Text = Me.noresponses.Text
            Exit Sub
        End If


        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Text = Me.gaps_dimension.Text
            e.Row.Cells(1).Text = Me.gaps_factor.Text
            e.Row.Cells(2).Text = Me.gaps_gap.Text


            Me.tabGaps.HeaderRow.Cells(0).Text = Me.gaps_dimension.Text
            Me.tabGaps.HeaderRow.Cells(1).Text = Me.gaps_factor.Text
            Me.tabGaps.HeaderRow.Cells(2).Text = Me.gaps_selfscore.Text
            Me.tabGaps.HeaderRow.Cells(3).Text = Me.gaps_raterscore.Text
            Me.tabGaps.HeaderRow.Cells(4).Text = Me.gaps_gap.Text
        End If
    End Sub
End Class
