Imports ChartDirector

Partial Class Report_Bars
    Inherits System.Web.UI.UserControl
    Dim iAvg(6) As Double
    Dim i1 As Integer
    Dim c1 As ChartDirector.WebChartViewer
    Dim barcolor As Int32
    Dim bHas360 As Boolean

    Public Property pPID() As Integer
        Get
            Return PID.Text
        End Get

        Set(ByVal Value As Integer)
            PID.Text = Value
        End Set
    End Property

    Public Property pSrcName() As String
        Get
            Return SrcName.Text
        End Get

        Set(ByVal Value As String)
            SrcName.Text = Value
        End Set
    End Property

    Public Property pNormText() As String
        Get
            Return NormText.Text
        End Get

        Set(ByVal Value As String)
            NormText.Text = Value
        End Set
    End Property

    Public Property pPageNo() As Integer
        Get
            Return PageNo.Text
        End Get

        Set(ByVal Value As Integer)
            PageNo.Text = Value
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

    Sub One_Draw(ByVal Avg() As Double, ByVal iNorm As Double, ByVal iColor As Long, ByVal c1 As ChartDirector.WebChartViewer)
        Dim data0(0) As Double
        Dim data1(0) As Double
        Dim dataY2(0) As Double
        Dim dataX2(0) As Double

        Dim dataY3(0) As Double
        Dim dataX3(0) As Double

        Dim dataY4(0) As Double
        Dim dataX4(0) As Double

        Dim dataY5(0) As Double
        Dim dataX5(0) As Double

        Dim markData(0) As Double
        markData(0) = iNorm

        Chart.setLicenseCode("DEVP-348S-FXXS-WHSU-9B5A-E259")

        ' The data for the bar chart
        'Dim data0() As Double = {5.5}
        'Dim data1() As Double = {1.5}

        'Dim dataY2() As Double = {0}
        'Dim dataX2() As Double = {0.6}

        'Dim dataY3() As Double = {4}
        'Dim dataX3() As Double = {0.3}

        'Dim dataY4() As Double = {5}
        'Dim dataX4() As Double = {-0.3}

        'Dim dataY5() As Double = {7}
        'Dim dataX5() As Double = {-0.6}

        data0(0) = Avg(1)
        data1(0) = 7 - Avg(1)
        dataY2(0) = Avg(2)
        dataX2(0) = 0.6

        dataY3(0) = Avg(3)
        dataX3(0) = 0.3

        dataY4(0) = Avg(4)
        dataX4(0) = -0.3

        dataY5(0) = Avg(5)
        dataX5(0) = -0.6

        ' The labels for the bar chart
        Dim labels() As String = {0, 1, 2, 3, 4, 5, 6, 7} ', "2002", "2003", "2004", "2005"}
        Dim Labelsx() As String = {""}
        
        ' Create a PieChart object of size 600 x 380 pixels.
        Dim c As XYChart = New XYChart(400, 80)
        c.setBackground(&HFFFFFF)

        ' Tentatively set the plotarea at (70, 80) and of 480 x 240 pixels in size. Use
        ' transparent border and white grid lines
        c.setPlotArea(10, 10, 380, 60, -1, -1, &H0, c.dashLineColor(&H0, Chart.DotLine), Chart.Transparent)

        ' Swap the axis so that the bars are drawn horizontally
        c.swapXY()
        c.yAxis.setDateScale2(0, 7, labels)
        c.yAxis().setMargin(8, 8)


        'Add line
        If dataY2(0) > 0 Then
            Dim scatter2 As ScatterLayer = c.addScatterLayer(dataX2, dataY2, "", Chart.DiamondSymbol, 14, &H8000)
        Else
            Dim scatter2 As ScatterLayer = c.addScatterLayer(dataX2, dataY2, "", Chart.DiamondSymbol, 0, &H8000)
        End If
        'Dim scatter2 As ScatterLayer = c.addScatterLayer(dataX2, dataY2).getDataSet(0).setDataSymbol2(Server.MapPath(, "", Chart.DiamondSymbol, 14, &H8000)

        If dataY3(0) > 0 Then
            Dim scatter3 As ScatterLayer = c.addScatterLayer(dataX3, dataY3, "", Chart.CircleSymbol, 14, &H8000)
        Else
            Dim scatter3 As ScatterLayer = c.addScatterLayer(dataX3, dataY3, "", Chart.CircleSymbol, 0, &H8000)
        End If

        If dataY4(0) > 0 Then
            Dim scatter4 As ScatterLayer = c.addScatterLayer(dataX4, dataY4, "", Chart.SquareSymbol, 14, &H8000)
        Else
            Dim scatter4 As ScatterLayer = c.addScatterLayer(dataX4, dataY4, "", Chart.SquareSymbol, 0, &H8000)
        End If

        If dataY5(0) > 0 Then
            Dim scatter5 As ScatterLayer = c.addScatterLayer(dataX5, dataY5, "", Chart.TriangleSymbol, 14, &H8000)
        Else
            Dim scatter5 As ScatterLayer = c.addScatterLayer(dataX5, dataY5, "", Chart.TriangleSymbol, 0, &H8000)
        End If


        'Add Norm Layer
        Dim markLayer As BoxWhiskerLayer = c.addBoxWhiskerLayer(Nothing, Nothing, _
                Nothing, Nothing, markData, -1, &HFF0000)
        markLayer.setLineWidth(3)
        markLayer.setDataGap(0.1)


        ' Add a multi-color bar chart layer using the supplied data. Use bar gradient
        ' lighting with the light intensity from 0.75 to 2.0
        'c.addBarLayer3(data, colors).setBorderColor(Chart.Transparent)
        Dim layer As BarLayer = c.addBarLayer2(Chart.Stack)

        layer.addDataGroup("2001")
        layer.addDataSet(data0, &HCCCCCC) ', "Local")
        'layer.addDataSet(data0, iColor) ', "Local")

        layer.addDataSet(data1, &HFFFFFF) ', "International")

        ' Set y-axes to transparent
        c.xAxis().setColors(Chart.Transparent)
        c.xAxis().setLabels(Labelsx)
        ' Disable ticks on the x-axis by setting the tick color to transparent
        c.yAxis().setTickColor(&H0)

        ' Set the label styles of all axes to 8pt Arial Bold font
        c.xAxis().setLabelStyle("Arial Bold", 8)
        c.yAxis().setLabelStyle("Arial Bold", 8)
        c.yAxis2().setLabelStyle("Arial Bold", 8)

        c.packPlotArea(10, 10, c.getWidth() - 10, c.getHeight() - 10)

        ' Output the chart
        'WebChartViewer1.Image = c.makeWebImage(Chart.PNG)
        c1.Image = c.makeWebImage(Chart.PNG)

    End Sub

    Protected Sub tabData_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabData.PreRender
        If Me.RelID.Text <> "" Then
            Me.tabData.FooterRow.Visible = False
        End If
    End Sub


    Protected Sub tabData_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles tabData.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Me.RelID.Text = "" Then
                For i1 = 1 To 5
                    iAvg(i1) = CF.NullToZero(e.Row.DataItem("Avg" & i1))
                    If i1 > 1 And iAvg(i1) > 0 Then
                        Trace.Warn("tabData Has360=" & True)
                        Trace.Warn(Me.SrcName.Text)
                        Me.bHas360 = True
                    End If

                Next
            Else
                For i1 = 1 To 5
                    If i1 = 1 Or i1 = Me.RelID.Text Then
                        iAvg(i1) = CF.NullToZero(e.Row.DataItem("Avg" & i1))
                    End If
                Next
            End If
            c1 = e.Row.FindControl("chart1")
            barcolor = Int32.Parse(Mid(e.Row.DataItem("ColorCode"), 3), Globalization.NumberStyles.HexNumber)
            Trace.Warn(barcolor)
            One_Draw(iAvg, e.Row.DataItem("Norm1"), barcolor, c1)
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.rsData.SelectCommand = Me.SrcName.Text
        
    End Sub

   

    
    
    'Protected Sub tabLegend_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles tabLegend.RowDataBound
    '    If e.Row.RowIndex > 0 Then
    '        e.Row.Controls.Clear()
    '        Exit Sub
    '    End If
    'End Sub

    Protected Sub legend1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles legend1.PreRender
        If bHas360 Then
            Me.legend1.pHas360 = "True"
        Else
            Me.legend1.pHas360 = "False"
        End If
        Me.legend1.pNormtext = Me.NormText.Text
        'Trace.Warn("Legend Has360=" & Me.legend1.pHas360)
    End Sub
End Class
