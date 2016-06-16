<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Legend.ascx.vb" Inherits="Report_Legend1" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>
<asp:Label runat=server ID=PID Visible=False></asp:Label>
<asp:Label runat=server ID=NormText Visible=False></asp:Label>
<center>
<asp:Label runat=server ID=Has360></asp:Label>
<chart:WebChartViewer ID="chart1" runat="server" />
<%--<uc:scale runat=server ID=scale1 />
--%>
</center>
