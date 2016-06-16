<%@ Page Language="VB" Trace="False" Debug="False" MasterPageFile="lang.master" StylesheetTheme="Lang"
    AutoEventWireup="false" CodeFile="TableofContents.aspx.vb" Inherits="Lang_TOC"
    ValidateRequest="False" Title="Table of Contents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:SqlDataSource ID="rsA" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
        SelectCommand="SELECT AutoID,  [LanguageID], [Sectionname], [EnglishSectionName], SurveyTypeName FROM [Lang_TableOfContents] WHERE ([LanguageID] = @LanguageID) and  ((@txtSearch='zz') OR (CharIndex(@txtSearch, IsNull(SectionName, '')+ ' -- ' +IsNull(EnglishSectionName, ''))>0)) ORDER BY [AutoID]">
        <SelectParameters>
            <asp:CookieParameter CookieName="LanguageID" Name="LanguageID" Type="Byte" />
            <asp:ControlParameter ControlID="txtSearch" Name="txtSearch" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <div class="Section">
        Table Of Contents&nbsp; &nbsp; &nbsp; (Current Search:
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
                    <asp:Label ID="AutoID" runat="server" Visible="False" Text='<%# Eval("AutoID") %>'></asp:Label>
                    <asp:Label ID="SurveyTypeName" runat="server" Visible="True" Text='<%# Eval("SurveyTypeName") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Section Name">
                <ItemTemplate>
                    <asp:Label ID="EnglishSectionName" runat="server" Text='<%# Eval("EnglishSectionName") %>'></asp:Label>
                    <br />
                    <asp:TextBox ID="SectionName" runat="server" Columns="80" Text='<%# Bind("SectionName") %>'
                        SkinID="1"></asp:TextBox><br />
                    Max. Allowed:
                    <asp:Label runat="server" ID="maxlength1" ForeColor="Green" Text='<%# Len(Eval("EnglishSectionName")) %>'></asp:Label>&nbsp;
                    &nbsp; Chars Left:
                    <asp:Label runat="server" ID="charsleft1"></asp:Label>
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
