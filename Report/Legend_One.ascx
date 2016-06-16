<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Legend_One.ascx.vb" Inherits="Report_Legend2" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>
<asp:Label runat=server ID=RelID Visible=False></asp:Label>
<chart:WebChartViewer ID="chart1" runat="server" />
