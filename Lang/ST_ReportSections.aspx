<%@ Page Language="VB" Trace="false" Debug="false" MasterPageFile="lang.master" StylesheetTheme="Lang"
    AutoEventWireup="false" CodeFile="ST_ReportSections.aspx.vb" Inherits="Lang_ST_ReportSections"
    ValidateRequest="False" Title="ST Report Sections" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:SqlDataSource ID="rsA" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
        SelectCommand="SELECT [LanguageID], ReportSortOrder, ReportCategory, ISNULL(EnglishReportCategory, '') as EnglishReportCategory, RecordID FROM [Lang_ST_ReportSections] WHERE ([LanguageID] = @LanguageID) and  ((@txtSearch='zz') OR (CharIndex(@txtSearch, IsNull(ReportCategory, '') + ' -- ' + IsNull(EnglishReportCategory, ''))>0)) ORDER BY ReportSortOrder">
        <SelectParameters>
            <asp:CookieParameter CookieName="LanguageID" Name="LanguageID" Type="Byte" />
            <asp:ControlParameter ControlID="txtSearch" Name="txtSearch" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <div class="Section">
        ST Report Sections&nbsp; &nbsp; &nbsp; (Current Search:
        <asp:Label runat="server" ID="txtSearch" Text="" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="CurrentSearch" Text="" Font-Italic="true"></asp:Label>)</div>
    <asp:Label runat="server" ID="Message" CssClass="error" EnableViewState="False"></asp:Label><br />
    <asp:GridView ID="tabA" runat="server" Width="350px" CellPadding="4" DataSourceID="rsA"
        EmptyDataText="No matching text at this time." AllowPaging="true" PageSize="10"
        PagerSettings-Mode="NumericFirstLast" PagerSettings-Position="TopAndBottom" AutoGenerateColumns="False"
        ShowFooter="True">
        <HeaderStyle CssClass="headrow" />
        <FooterStyle CssClass="footrow" />
        <AlternatingRowStyle CssClass="altrow" />
        <PagerStyle CssClass="pager" />
        <Columns>
            <asp:TemplateField HeaderText="Row ID">
                <ItemTemplate>
                    <asp:Label ID="ReportSortOrder" runat="server" Text='<%# Eval("ReportSortOrder") %>'></asp:Label>
                    <asp:Label ID="RecordID" runat="server" Text='<%# Eval("RecordID") %>' Visible="false"></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Section Name">
                <ItemTemplate>
                    <asp:Label ID="EnglishReportCategory" runat="server" Text='<%# Eval("EnglishReportCategory") %>'></asp:Label>
                    <br />
                    <asp:TextBox ID="ReportCategory" runat="server" Text='<%# Bind("ReportCategory") %>'
                        Columns="80" SkinID="3"></asp:TextBox><br />
                    Max. Allowed:
                    <asp:Label runat="server" ID="maxlength3" ForeColor="Green" Text='<%# Len(Eval("EnglishReportCategory")) %>'></asp:Label>&nbsp
                    &nbsp; Chars Left:
                    <asp:Label runat="server" ID="charsleft3"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Button runat="server" ID="btnSave" Text="Save Changes" CommandName="Save" />
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Right" />
                <ItemStyle VerticalAlign="Bottom" HorizontalAlign="Left" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
