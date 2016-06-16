<%@ Page Language="VB" Trace="false" Debug="false" MasterPageFile="lang.master" StylesheetTheme="Lang"
    AutoEventWireup="false" CodeFile="Rels.aspx.vb" Inherits="Lang_Rels" ValidateRequest="False"
    Title="Relationships" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:SqlDataSource ID="rsA" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
        SelectCommand="SELECT AutoID,  [LanguageID], [RelID], ISNULL(RelName, '') as RelName, IsNull(RelDesc, '') as RelDesc, [EnglishRelName], IsNull(EnglishRelDesc, '') as EnglishRelDesc FROM [Lang_Rels] WHERE ([LanguageID] = @LanguageID) and  ((@txtSearch='zz') OR (CharIndex(@txtSearch, IsNull(RelName, '')+ ' -- ' +IsNull(RelDesc, '')+ ' -- ' +IsNull(EnglishRelName, '')+ ' -- ' +IsNull(EnglishRelDesc, ''))>0)) ORDER BY [RelID]">
        <SelectParameters>
            <asp:CookieParameter CookieName="LanguageID" Name="LanguageID" Type="Byte" />
            <asp:ControlParameter ControlID="txtSearch" Name="txtSearch" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <div class="Section">
        Relationships&nbsp; &nbsp; &nbsp; (Current Search:
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
                    <asp:Label ID="RelID" runat="server" Text='<%# Eval("RelID") %>'></asp:Label>
                    <asp:Label ID="AutoID" runat="server" Visible="False" Text='<%# Eval("AutoID") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dimension Name">
                <ItemTemplate>
                    <asp:Label ID="EnglishRelName" runat="server" Text='<%# Eval("EnglishRelName") %>'></asp:Label>
                    <br />
                    <asp:TextBox ID="RelName" runat="server" Text='<%# Bind("RelName") %>' SkinID="1"
                        Columns="50"></asp:TextBox><br />
                    Max. Allowed:
                    <asp:Label runat="server" ID="maxlength1" ForeColor="Green" Text='<%# Len(Eval("EnglishRelName")) %>'></asp:Label>&nbsp;
                    &nbsp; Chars Left:
                    <asp:Label runat="server" ID="charsleft1"></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dimension Desc">
                <ItemTemplate>
                    <asp:Label ID="EnglishRelDesc" runat="server" Text='<%# Eval("EnglishRelDesc") %>'></asp:Label>
                    <br />
                    <asp:TextBox ID="RelDesc" runat="server" Text='<%# Bind("RelDesc") %>' TextMode="MultiLine"
                        SkinID="2" Rows="2" Columns="60"></asp:TextBox><br />
                    Max. Allowed:
                    <asp:Label runat="server" ID="maxlength2" ForeColor="Green" Text='<%# Len(Eval("EnglishRelDesc")) %>'></asp:Label>&nbsp;
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
