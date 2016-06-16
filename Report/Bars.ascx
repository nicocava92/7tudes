<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Bars.ascx.vb" Inherits="Report_Bars" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>
<%@ Register TagName="legend" TagPrefix="uc" Src="Legend.ascx" %>
<asp:Label runat="server" ID="PID" Visible="False"></asp:Label>
<asp:Label runat="server" ID="SrcName" Visible="False"></asp:Label>
<asp:Label runat="server" ID="PageNo" Visible="False" ForeColor="Red"></asp:Label>
<asp:Label runat="server" ID="RelID" Visible="False" Text=""></asp:Label>
<asp:Label runat="server" ID="NormText" Visible="False" Text=""></asp:Label>
<asp:SqlDataSource ID="rsData" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
    SelectCommandType="StoredProcedure">
    <SelectParameters>
        <asp:ControlParameter ControlID="PID" Name="Pid" PropertyName="Text" Type="Int32" />
        <asp:ControlParameter ControlID="PageNo" Name="PageNo" Type="Int32" />
        <asp:QueryStringParameter Name="LanguageID" QueryStringField="LanguageID" Type="String"
            DefaultValue="0" />
        <asp:QueryStringParameter Name="NormID" QueryStringField="NormID" Type="String" DefaultValue="0" />
    </SelectParameters>
</asp:SqlDataSource>
<asp:GridView ID="tabData" runat="server" DataSourceID="rsData" CellPadding="1" AutoGenerateColumns="False"
    ShowHeader="False" GridLines="None" ShowFooter="False">
    <Columns>
        <asp:BoundField DataField="ItemNo" HeaderText="ItemNo" SortExpression="ItemNo">
            <ItemStyle VerticalAlign="Top" Width="20px" />
        </asp:BoundField>
        <asp:BoundField DataField="ItemDesc" HtmlEncode="False" HeaderText="ItemDesc" SortExpression="ItemDesc">
            <ItemStyle VerticalAlign="Top" Width="300px" />
        </asp:BoundField>
        <asp:TemplateField>
            <ItemTemplate>
                <chart:WebChartViewer ID="chart1" runat="server" />
            </ItemTemplate>
            <ItemStyle VerticalAlign="Top" Width="400px" />
            <FooterTemplate>
                <%--Legend:--%>
            </FooterTemplate>
        </asp:TemplateField>
    </Columns>
    <AlternatingRowStyle CssClass="altrow" />
</asp:GridView>
<%--<asp:GridView HorizontalAlign="Right" GridLines="None" runat="server" ID="tabLegend" CellPadding=0 CellSpacing=0
    DataSourceID="rsData" AutoGenerateColumns="False" ShowHeader="False" ShowFooter="True">
    <Columns>
        <asp:TemplateField>
            
            <ItemTemplate>
                <uc:legend runat="server" ID="legend1" pPID='<%# Eval("PID") %>' />
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Right" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>--%>
    <uc:legend runat=server ID=legend1   />


