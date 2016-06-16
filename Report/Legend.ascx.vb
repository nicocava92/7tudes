Imports ChartDirector

Partial Class Report_Legend1
    Inherits System.Web.UI.UserControl


    Public Property pNormText() As String
        Get
            Return NormText.Text
        End Get

        Set(ByVal Value As String)
            NormText.Text = Value
        End Set
    End Property


    Sub Legend_Draw(ByVal c1 As ChartDirector.WebChartViewer, ByVal sHas360 As String)
        Chart.setLicenseCode("DEVP-348S-FXXS-WHSU-9B5A-E259")
        Dim Labelsx() As String = {""}
        Dim c As XYChart
        If sHas360 = "True" Then
            c = New XYChart(610, 70) 'was 600
            c.setPlotArea(0, 0, 600, 60, -1, -1, Chart.Transparent)
        Else
            c = New XYChart(200, 70) 'was 150
            c.setPlotArea(0, 0, 130, 60, -1, -1, Chart.Transparent)
        End If
        c.swapXY()
        'c.yAxis().setMargin(8, 8)

        Dim dv As System.Data.DataView, sLanguageID As String
        If Request.QueryString("LanguageID") = "" Then
            sLanguageID = "1"
        Else
            sLanguageID = Request.QueryString("LanguageID")
        End If
        dv = CF.DataView_Get("Select Relname from Rels where RelID<=5 and LanguageID=" & sLanguageID & " order by RelID")

        If sHas360 = "True" Then

            Dim scatter2 As ScatterLayer = c.addScatterLayer(New Double() {Chart.NoValue}, New Double() {Chart.NoValue}, dv.Table.Rows(1)("RelName"), Chart.DiamondSymbol, 14, &H8000)
            Dim scatter3 As ScatterLayer = c.addScatterLayer(New Double() {Chart.NoValue}, New Double() {Chart.NoValue}, dv.Table.Rows(2)("RelName"), Chart.CircleSymbol, 14, &H8000)
            Dim scatter4 As ScatterLayer = c.addScatterLayer(New Double() {Chart.NoValue}, New Double() {Chart.NoValue}, dv.Table.Rows(3)("RelName"), Chart.SquareSymbol, 14, &H8000)
            Dim scatter5 As ScatterLayer = c.addScatterLayer(New Double() {Chart.NoValue}, New Double() {Chart.NoValue}, dv.Table.Rows(4)("RelName"), Chart.TriangleSymbol, 14, &H8000)
        End If

        Dim legend1 As LegendBox = c.addLegend(12, 10, False)
        legend1.setKeySpacing(15)
        legend1.setKeySize(15)
        legend1.setFontSize(8)
        legend1.addKey(0, dv.Table.Rows(0)("RelName"), &HCCCCCC, 10)
        c.addScatterLayer(New Double() {Chart.NoValue}, New Double() {Chart.NoValue}, Me.NormText.Text).getDataSet(0).setDataSymbol4((New Integer() {-100, 0, -100, 1000, 100, 1000, 100, 0}), 20, &HFF0000, &HFF0000)
        c1.Image = c.makeWebImage(Chart.PNG)

    End Sub

    Public Property pHas360() As String
        Get
            Return Me.Has360.Text
        End Get

        Set(ByVal Value As String)
            Me.Has360.Text = Value
        End Set
    End Property

    Protected Sub Has360_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Has360.PreRender
        Trace.Warn("A Prerender=" & Me.Has360.Text)
        
        Legend_Draw(Me.chart1, Me.Has360.Text)
        Me.Has360.Visible = False
    End Sub
End Class
