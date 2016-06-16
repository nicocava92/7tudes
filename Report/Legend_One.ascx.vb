Imports ChartDirector

Partial Class Report_Legend2
    Inherits System.Web.UI.UserControl
    Public Property pRelID() As Integer
        Get
            Return RelID.Text
        End Get

        Set(ByVal Value As Integer)
            RelID.Text = Value
        End Set
    End Property

    Sub Legend_Draw(ByVal c1 As ChartDirector.WebChartViewer, ByVal iWhich As Integer)
        Chart.setLicenseCode("DEVP-348S-FXXS-WHSU-9B5A-E259")
        Dim Labelsx() As String = {" "}

        Dim c As XYChart = New XYChart(30, 30) 'was 750

        c.setPlotArea(0, 0, 20, 20, Chart.Transparent, Chart.Transparent, Chart.Transparent, Chart.Transparent, Chart.Transparent)
        c.swapXY()
        'c.yAxis().setMargin(8, 8)
        Trace.Warn(iWhich)
        Dim legend1 As LegendBox = c.addLegend(0, 0, False)
        legend1.setBackground(Chart.Transparent)
        legend1.setKeySpacing(15)
        legend1.setKeySize(15)
        If iWhich = 1 Then
            legend1.addKey(0, " ", &HCCCCCC, 10)
            legend1.setFontSize(10)
        ElseIf iWhich = 2 Then
            Dim scatter2 As ScatterLayer = c.addScatterLayer(New Double() {Chart.NoValue}, New Double() {Chart.NoValue}, " ", Chart.DiamondSymbol, 14, &H8000)
        ElseIf iWhich = 3 Then
            Dim scatter3 As ScatterLayer = c.addScatterLayer(New Double() {Chart.NoValue}, New Double() {Chart.NoValue}, " ", Chart.CircleSymbol, 14, &H8000)
        ElseIf iWhich = 4 Then
            Dim scatter4 As ScatterLayer = c.addScatterLayer(New Double() {Chart.NoValue}, New Double() {Chart.NoValue}, " ", Chart.SquareSymbol, 14, &H8000)
        ElseIf iWhich = 5 Then
            Dim scatter5 As ScatterLayer = c.addScatterLayer(New Double() {Chart.NoValue}, New Double() {Chart.NoValue}, " ", Chart.TriangleSymbol, 14, &H8000)
        ElseIf iWhich = 6 Then
            c.addScatterLayer(New Double() {Chart.NoValue}, New Double() {Chart.NoValue}, " ").getDataSet(0).setDataSymbol4((New Integer() {-100, 0, -100, 1000, 100, 1000, 100, 0}), 20, &HFF0000, &HFF0000)
        End If

        c1.Image = c.makeWebImage(Chart.PNG)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Legend_Draw(Me.chart1, Me.RelID.Text)
    End Sub
End Class
