<%@ Page Language="VB" Trace="false" Debug="false" MasterPageFile="lang.master" StylesheetTheme="Lang"
    AutoEventWireup="false" CodeFile="ReportContent.aspx.vb" Inherits="Lang_ReportText"
    ValidateRequest="False" Title="Report Content" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:SqlDataSource ID="rsA" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
        SelectCommand="SELECT AutoID,  [LanguageID], SurveyTypeName, heading1, Content1, IsNull(EnglishHeading1, '') as EnglishHeading1, IsNull(EnglishContent1, '') as EnglishContent1 FROM [Lang_ReportText] WHERE ([LanguageID] = @LanguageID) and  ((@txtSearch='zz') OR (CharIndex(@txtSearch, IsNull(Heading1, '')+ ' -- ' +IsNull(Content1, '')+ ' -- ' +IsNull(EnglishHeading1, '')+ ' -- ' +IsNull(EnglishContent1, ''))>0)) ORDER BY [AutoID]">
        <SelectParameters>
            <asp:CookieParameter CookieName="LanguageID" Name="LanguageID" Type="Byte" />
            <asp:ControlParameter ControlID="txtSearch" Name="txtSearch" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <div class="Section">
        Report Content&nbsp; &nbsp; &nbsp; (Current Search:
        <asp:Label runat="server" ID="txtSearch" Text="" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="CurrentSearch" Text="" Font-Italic="true"></asp:Label>)</div>
    <br />
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
                    <asp:Label ID="AutoID" runat="server" Visible="True" Text='<%# Eval("AutoID") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Heading">
                <ItemTemplate>
                    <asp:Label ID="EnglishHeading1" runat="server" Text='<%# Eval("Englishheading1") %>'></asp:Label>
                    <br />
                    <asp:TextBox ID="Heading1" runat="server" Text='<%# Bind("Heading1") %>' SkinID="1"
                        Columns="50"></asp:TextBox><br />
                    Max. Allowed:
                    <asp:Label runat="server" ID="maxlength1" ForeColor="Green" Text='<%# Len(Eval("EnglishHeading1")) %>'></asp:Label>&nbsp;
                    &nbsp; Chars Left:
                    <asp:Label runat="server" ID="charsleft1"></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Content">
                <ItemTemplate>
                    <asp:Label ID="EnglishContent1" runat="server" Text='<%# Replace(Eval("EnglishContent1"), Chr(13) & Chr(10), "<br>") %>'></asp:Label>
                    <br />
                    <asp:TextBox ID="Content1" runat="server" Text='<%# Bind("Content1") %>' TextMode="MultiLine"
                        SkinID="2" Rows="8" Columns="80"></asp:TextBox><br />
                    Max. Allowed:
                    <asp:Label runat="server" ID="maxlength2" ForeColor="Green" Text='<%# Len(Eval("EnglishContent1")) %>'></asp:Label>&nbsp;
                    &nbsp; Chars Left:
                    <asp:Label runat="server" ID="charsleft2"></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" HorizontalAlign="Left" />
                <FooterTemplate>
                    <asp:Button runat="server" ID="btnSave" Text="Save Changes" CommandName="Save" />
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Right" CssClass="footrow" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
