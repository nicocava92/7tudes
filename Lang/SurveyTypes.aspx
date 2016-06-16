<%@ Page Language="VB" Trace="False" Debug="False" MasterPageFile="lang.master" StylesheetTheme="Lang"
    AutoEventWireup="false" CodeFile="SurveyTypes.aspx.vb" Inherits="Lang_SurveyTypes"
    ValidateRequest="False" Title="Survey Types" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:SqlDataSource ID="rsA" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
        SelectCommand="SELECT AutoID,  [LanguageID], [SurveyTypeID], SurveyTypeName, ReportFooter, ISNULL(EnglishSurveyTypeName, '') as EnglishSurveyTypeName, IsNull(EnglishReportFooter, '') as EnglishReportFooter FROM [Lang_SurveyTypes] WHERE SurveyTypeID<=6 and ([LanguageID] = @LanguageID) and  ((@txtSearch='zz') OR (CharIndex(@txtSearch, ISNULL(SurveyTypeName, '') + ' -- ' + ISNULL(ReportFooter, '') + ' -- ' + ISNULL(EnglishSurveyTypeName, '') + ' -- ' + ISNULL(EnglishReportFooter, ''))>0)) ORDER BY [SurveyTypeID]">
        <SelectParameters>
            <asp:CookieParameter CookieName="LanguageID" Name="LanguageID" Type="Byte" />
            <asp:ControlParameter ControlID="txtSearch" Name="txtSearch" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <div class="Section">
        Survey Types&nbsp; &nbsp; &nbsp; (Current Search:
        <asp:Label runat="server" ID="txtSearch" Text="" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="CurrentSearch" Text="" Font-Italic="true"></asp:Label>)</div>
    <asp:Label runat="server" ID="Message" CssClass="error" EnableViewState="False"></asp:Label><br />
    <asp:GridView ID="tabA" runat="server" Width="350px" CellPadding="4" DataSourceID="rsA"
        EmptyDataText="No matching text at this time." AutoGenerateColumns="False" ShowFooter="True">
        <HeaderStyle CssClass="headrow" />
        <FooterStyle CssClass="footrow" />
        <AlternatingRowStyle CssClass="altrow" />
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label ID="SurveyTypeID" runat="server" Text='<%# Eval("SurveyTypeID") %>'></asp:Label>
                    <asp:Label ID="AutoID" runat="server" Visible="False" Text='<%# Eval("AutoID") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Survey Type Name">
                <ItemTemplate>
                    <asp:Label ID="EnglishSurveyTypeName" runat="server" Text='<%# Eval("EnglishSurveyTypeName") %>'></asp:Label>
                    <br />
                    <asp:TextBox ID="SurveyTypeName" runat="server" Text='<%# Bind("SurveyTypeName") %>'
                        SkinID="1" Columns="60"></asp:TextBox><br />
                    Max. Allowed:
                    <asp:Label runat="server" ID="maxlength1" ForeColor="Green" Text='<%# Len(Eval("EnglishSurveyTypeName")) %>'></asp:Label>&nbsp;
                    &nbsp; Chars Left:
                    <asp:Label runat="server" ID="charsleft1"></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Report Footer">
                <ItemTemplate>
                    <asp:Label ID="EnglishReportFooter" runat="server" Text='<%# Eval("EnglishReportFooter") %>'></asp:Label>
                    <br />
                    <asp:TextBox ID="ReportFooter" runat="server" Text='<%# Bind("ReportFooter") %>'
                        Columns="80" SkinID="2"></asp:TextBox><br />
                    Max. Allowed:
                    <asp:Label runat="server" ID="maxlength2" ForeColor="Green" Text='<%# Len(Eval("EnglishReportFooter")) %>'></asp:Label>&nbsp;
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
