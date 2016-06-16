<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ReportText.ascx.vb" Inherits="SelfRpt_ReportText" %>

<asp:Label runat=server ID=PID Visible=false></asp:Label>
<asp:Label runat=server ID=SectionName Visible=False></asp:Label>
<asp:SqlDataSource ID="rsText" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
    SelectCommand="SELECT [PID], [SurveyTypeID], [LanguageID], [SectionName], [SortOrder], [Heading1], [Content1] FROM [qryParticipant_ReportText] WHERE ([PID] = @PID and SectionName=@SectionName) ORDER BY [SortOrder]">
    <SelectParameters>
        <asp:ControlParameter ControlID="PID" DefaultValue="0" Name="PID" PropertyName="Text"
            Type="Int32" />
        <asp:ControlParameter ControlID="SectionName" DefaultValue="" Name="SectionName"
            PropertyName="Text" />
    </SelectParameters>
</asp:SqlDataSource>
<asp:GridView ID="tabText" ShowHeader="False" GridLines="None" runat="server" AutoGenerateColumns="False"
    DataSourceID="rsText">
    <Columns>
        <asp:TemplateField HeaderText="Content1" SortExpression="Content1">
            <ItemTemplate>
                <asp:Label runat="server" ID="Heading1" Text='<%# Eval("Heading1") %>'></asp:Label>
                <span runat="server" id="space1">
                    <br />
                    <br />
                </span>
                <asp:Label ID="Content1" runat="server" Text='<%# FShTML(CF.NullToString(Eval("Content1"))) %>'></asp:Label>
                <br />
                <br />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
