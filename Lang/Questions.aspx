<%@ Page Language="VB" Trace="false" Debug="false" MasterPageFile="lang.master" StylesheetTheme="Lang"
    AutoEventWireup="false" CodeFile="Questions.aspx.vb" Inherits="Lang_Questions"
    ValidateRequest="False" Title="Profile Questions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:SqlDataSource ID="rsA" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
        SelectCommand="SELECT [LanguageID], [QNo], Question_Self, Question_Raters, Question_Family, [EnglishSelf], ISNULL(EnglishRaters, '') as EnglishRaters, ISNULL(EnglishFamily, '') as EnglishFamily, AutoID FROM [Lang_Questions] WHERE ([LanguageID] = @LanguageID) and  ((@txtSearch='zz') OR (CharIndex(@txtSearch, IsNull(Question_Self, '')+ ' -- ' +IsNull(Question_Raters, '')+ ' -- ' +IsNull(Question_Family, '')+ ' -- ' +IsNull(EnglishSelf, '')+ ' -- ' +IsNull(EnglishRaters, '')+ ' -- ' +IsNull(EnglishFamily, ''))>0)) ORDER BY [QNo]">
        <SelectParameters>
            <asp:CookieParameter CookieName="LanguageID" Name="LanguageID" Type="Byte" />
            <asp:ControlParameter ControlID="txtSearch" Name="txtSearch" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <div class="Section">
        Profile Questions&nbsp; &nbsp; &nbsp; (Current Search:
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
                    <asp:Label ID="QNo" runat="server" Text='<%# Eval("QNo") %>'></asp:Label>
                    <asp:Label ID="AutoID" runat="server" Text='<%# Eval("AutoID") %>' Visible="False"></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Self Question">
                <ItemTemplate>
                    <asp:Label ID="EnglishSelf" runat="server" Text='<%# Eval("EnglishSelf") %>'></asp:Label>
                    <br />
                    <asp:TextBox ID="Self" SkinID="1" runat="server" Text='<%# Bind("Question_Self") %>'
                        TextMode="MultiLine" Rows="3" Columns="35"></asp:TextBox><br />
                    Max. Allowed:
                    <asp:Label runat="server" ID="maxlength1" ForeColor="Green" Text='<%# Len(Eval("EnglishSelf")) %>'></asp:Label>&nbsp;
                    &nbsp; Chars Left:
                    <asp:Label runat="server" ID="charsleft1"></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Bottom" HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Raters Question">
                <ItemTemplate>
                    <asp:Label ID="EnglishRaters" runat="server" Text='<%# Eval("EnglishRaters") %>'></asp:Label>
                    <br />
                    <asp:TextBox ID="Raters" runat="server" Text='<%# Bind("Question_Raters") %>' TextMode="MultiLine"
                        Rows="3" SkinID="2" Columns="35"></asp:TextBox><br />
                    Max. Allowed:
                    <asp:Label runat="server" ID="maxlength2" ForeColor="Green" Text='<%# Len(Eval("EnglishRaters")) %>'></asp:Label>&nbsp;
                    &nbsp; Chars Left:
                    <asp:Label runat="server" ID="charsleft2"></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Bottom" HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Family Question">
                <ItemTemplate>
                    <asp:Label ID="EnglishFamily" runat="server" Text='<%# Eval("EnglishFamily") %>'></asp:Label>
                    <br />
                    <asp:TextBox ID="Family" runat="server" Text='<%# Bind("Question_Family") %>' TextMode="MultiLine"
                        Rows="3" Columns="35" SkinID="3"></asp:TextBox><br />
                    Max. Allowed:
                    <asp:Label runat="server" ID="maxlength3" ForeColor="Green" Text='<%# Len(Eval("EnglishFamily")) %>'></asp:Label>&nbsp
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
