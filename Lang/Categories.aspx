<%@ Page Language="VB" Trace="false" Debug="false" MasterPageFile="lang.master" StylesheetTheme="Lang"
    AutoEventWireup="false" CodeFile="Categories.aspx.vb" Inherits="Lang_Categories"
    ValidateRequest="False" Title="Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:SqlDataSource ID="rsA" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
        SelectCommand="SELECT AutoID,  [LanguageID], [CatNo], CatName, CatDesc, [EnglishCatName], EnglishCatDesc FROM [Lang_Categories] WHERE ([LanguageID] = @LanguageID) and  ((@txtSearch='zz') OR (CharIndex(@txtSearch, IsNull(CatName, '') + ' -- ' + Isnull(EnglishCatName, '')+ '  -- ' + IsNull(CatDesc, '') + ' -- ' + Isnull(EnglishCatDesc, ''))>0))  ORDER BY [CatNo]">
        <SelectParameters>
            <asp:CookieParameter CookieName="LanguageID" Name="LanguageID" Type="Byte" />
            <asp:ControlParameter ControlID="txtSearch" Name="txtSearch" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <div class="Section">
        Categories&nbsp; &nbsp; &nbsp; (Current Search:
        <asp:Label runat="server" ID="txtSearch" Text="" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="CurrentSearch" Text="" Font-Italic="true"></asp:Label>)</div>
    <asp:Label runat="server" ID="Message" CssClass="error" EnableViewState="False"></asp:Label><br />
    <asp:GridView ID="tabA" runat="server" Width="350px" CellPadding="4" DataSourceID="rsA"
        AutoGenerateColumns="False" ShowFooter="True" EnableModelValidation="True">
        <HeaderStyle CssClass="headrow" />
        <FooterStyle CssClass="footrow" />
        <AlternatingRowStyle CssClass="altrow" />
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label ID="CatNo" runat="server" Text='<%# Eval("CatNo") %>'></asp:Label>
                    <asp:Label ID="AutoID" runat="server" Visible="False" Text='<%# Eval("AutoID") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category Name">
                <ItemTemplate>
                    <asp:Label ID="EnglishCatName" runat="server" Text='<%# Eval("EnglishCatName") %>'></asp:Label>
                    <br />
                    <asp:TextBox ID="CatName" runat="server" Text='<%# Bind("CatName") %>' SkinID="1"
                        Columns="60"></asp:TextBox><br />
                    Max. Allowed:
                    <asp:Label runat="server" ID="maxlength1" ForeColor="Green" Text='<%# Len(Eval("EnglishCatName")) %>'></asp:Label>&nbsp;
                    &nbsp; Chars Left:
                    <asp:Label runat="server" ID="charsleft1"></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category Desc">
                <ItemTemplate>
                    <asp:Label ID="EnglishCatDesc" runat="server" Text='<%# Eval("EnglishCatDesc") %>'></asp:Label>
                    <br />
                    <asp:TextBox ID="CatDesc" runat="server" Text='<%# Bind("CatDesc") %>' TextMode="MultiLine"
                        SkinID="2" Rows="8" Columns="60"></asp:TextBox><br />
                    Max. Allowed:
                    <asp:Label runat="server" ID="maxlength2" ForeColor="Green" Text='<%# Len(Eval("EnglishCatDesc")) %>'></asp:Label>&nbsp;
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
