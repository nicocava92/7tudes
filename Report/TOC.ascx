<%@ Control Language="VB" AutoEventWireup="false" CodeFile="TOC.ascx.vb" Inherits="Report_TOC1" %>
<asp:SqlDataSource ID="rsData" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
    SelectCommand="SELECT [LanguageID], [SurveyTypeID], [SortOrder], [SectionID], [SectionName], [PageNo] FROM [TableOfContents] WHERE ([LanguageID] = @LanguageID) and SurveyTypeID=@SurveyTypeID ORDER BY [SortOrder]">
    <SelectParameters>
        <asp:QueryStringParameter DefaultValue="1" Name="LanguageID" QueryStringField="LanguageID"
            Type="Byte" />
        <asp:ControlParameter ControlID="SurveyTypeID" Name="SurveyTypeID" PropertyName="Text" />
    </SelectParameters>
</asp:SqlDataSource>
<asp:Label runat=server ID=SurveyTypeID Visible=False></asp:Label>
<asp:GridView ID="tabData" ShowHeader="False" runat="server" AutoGenerateColumns="False"
    CellPadding="3" DataKeyNames="LanguageID,SurveyTypeID,SortOrder"
    DataSourceID="rsData" GridLines="None">
    <Columns>
        <asp:TemplateField HeaderText="SectionName" SortExpression="SectionName">
            <ItemTemplate>
                <asp:Label runat="server" ID="Spacer" Text="<br /><br />"></asp:Label>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("SectionID") & ". " & Eval("SectionName") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="400px" />
        </asp:TemplateField>
        <asp:BoundField DataField="PageNo"
            HeaderText="PageNo" SortExpression="PageNo" >
            <ItemStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
        </asp:BoundField>
    </Columns>
</asp:GridView>
