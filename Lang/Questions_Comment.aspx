<%@ Page Language="VB" Trace="false" Debug="false" MasterPageFile="lang.master" StylesheetTheme="Lang"
    AutoEventWireup="false" CodeFile="Questions_Comment.aspx.vb" Inherits="Lang_CommentQ"
    ValidateRequest="False" Title="Comment Questions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:SqlDataSource ID="rsA" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
        SelectCommand="SELECT [LanguageID], [QNo], AutoID, Question_Self, Question_Raters, Question_Family, [EnglishSelf] as EnglishQuestion_Self, IsNull(EnglishRaters, '') as EnglishQuestion_Raters, ISNULL(EnglishFamily, '') as EnglishQuestion_Family FROM [Lang_Questions_Comment] WHERE ([LanguageID] = @LanguageID) and  ((@txtSearch='zz') OR (CharIndex(@txtSearch, IsNull(Question_Self, '')+ ' -- ' +IsNull(Question_Raters, '')+ ' -- ' +IsNull(Question_Family, ''))>0)) ORDER BY [QNo]">
        <SelectParameters>
            <asp:CookieParameter CookieName="LanguageID" Name="LanguageID" Type="Byte" />
            <asp:ControlParameter ControlID="txtSearch" Name="txtSearch" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <div class="Section">
        Comment Questions&nbsp; &nbsp; &nbsp; (Current Search:
        <asp:Label runat="server" ID="txtSearch" Text="" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="CurrentSearch" Text="" Font-Italic="true"></asp:Label>)</div>
    <asp:Label runat="server" ID="Message" CssClass="error" EnableViewState="False"></asp:Label><br />
    <asp:GridView ID="tabA" runat="server" Width="350px" CellPadding="4" DataSourceID="rsA"
        EmptyDataText="No matching text at this time." AutoGenerateColumns="False" ShowFooter="True">
        <HeaderStyle CssClass="headrow" />
        <FooterStyle CssClass="footrow" />
        <AlternatingRowStyle CssClass="altrow" />
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
                    <asp:Label ID="EnglishQuestion_Self" runat="server" Text='<%# Eval("EnglishQuestion_Self") %>'></asp:Label>
                    <br />
                    <asp:TextBox ID="Question_Self" runat="server" Text='<%# Bind("Question_Self") %>'
                        TextMode="MultiLine" Rows="5" Columns="35" SkinID="1"></asp:TextBox><br />
                    Max. Allowed:
                    <asp:Label runat="server" ID="maxlength1" ForeColor="Green" Text='<%# Len(Eval("EnglishQuestion_Self")) %>'></asp:Label>&nbsp;
                    &nbsp; Chars Left:
                    <asp:Label runat="server" ID="charsleft1"></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Bottom" HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Raters Question">
                <ItemTemplate>
                    <asp:Label ID="EnglishQuestion_Raters" runat="server" Text='<%# Eval("EnglishQuestion_Raters") %>'></asp:Label>
                    <br />
                    <asp:TextBox ID="Question_Raters" runat="server" Text='<%# Bind("Question_Raters") %>'
                        TextMode="MultiLine" Rows="5" Columns="35" SkinID="2"></asp:TextBox><br />
                    Max. Allowed:
                    <asp:Label runat="server" ID="maxlength2" ForeColor="Green" Text='<%# Len(Eval("EnglishQuestion_Raters")) %>'></asp:Label>&nbsp;
                    &nbsp; Chars Left:
                    <asp:Label runat="server" ID="charsleft2"></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Bottom" HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Family Question">
                <ItemTemplate>
                    <asp:Label ID="EnglishQuestion_Family" runat="server" Text='<%# Eval("EnglishQuestion_Family") %>'></asp:Label>
                    <br />
                    <asp:TextBox ID="Question_Family" runat="server" Text='<%# Bind("Question_Family") %>'
                        TextMode="MultiLine" Rows="5" Columns="35" SkinID="3"></asp:TextBox><br />
                    Max. Allowed:
                    <asp:Label runat="server" ID="maxlength3" ForeColor="Green" Text='<%# Len(Eval("EnglishQuestion_Family")) %>'></asp:Label>&nbsp;
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
