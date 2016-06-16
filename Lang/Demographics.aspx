<%@ Page Language="VB" Trace="false" Debug="false" MasterPageFile="lang.master" StylesheetTheme="Lang"
    AutoEventWireup="false" CodeFile="Demographics.aspx.vb" Inherits="Lang_Demographics"
    ValidateRequest="False" Title="Demographics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:SqlDataSource ID="rsA" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
        SelectCommand="SELECT AutoID,  [LanguageID], [DemoNo], Question, [EnglishQuestion] FROM [Lang_Demographics] WHERE ([LanguageID] = @LanguageID) and  ((@txtSearch='zz') OR (CharIndex(@txtSearch, IsNull(EnglishQuestion, '')+ ' -- ' +IsNull(Question, ''))>0)) ORDER BY [DemoNo]">
        <SelectParameters>
            <asp:CookieParameter CookieName="LanguageID" Name="LanguageID" Type="Byte" />
            <asp:ControlParameter ControlID="txtSearch" Name="txtSearch" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <div class="Section">
        Demographics&nbsp; &nbsp; &nbsp; (Current Search:
        <asp:Label runat="server" ID="txtSearch" Text="" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="CurrentSearch" Text="" Font-Italic="true"></asp:Label>
        )</div>
    <%-- <br />
    <div class="error">
        <b>Click on the Demographic Values link for each item to enter the values associated
            with each Demographic.</b><br />
    </div>--%>
    <asp:Label runat="server" ID="Message" CssClass="error" EnableViewState="False"></asp:Label><br />
    <asp:GridView ID="tabA" runat="server" Width="350px" CellPadding="4" DataSourceID="rsA"
        EmptyDataText="No matching text at this time." AutoGenerateColumns="False" ShowFooter="True">
        <HeaderStyle CssClass="headrow" />
        <FooterStyle CssClass="footrow" />
        <AlternatingRowStyle CssClass="altrow" />
        <Columns>
            <asp:TemplateField HeaderText="Row ID">
                <ItemTemplate>
                    <asp:Label ID="DemoNo" runat="server" Text='<%# Eval("DemoNo") %>'></asp:Label>
                    <asp:Label ID="AutoID" Visible="False" runat="server" Text='<%# Eval("AutoID") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Question">
                <ItemTemplate>
                    <asp:Label ID="EnglishQuestion" runat="server" Text='<%# Eval("EnglishQuestion") %>'></asp:Label>
                    <br />
                    <asp:TextBox ID="Question" runat="server" SkinID="1" Columns="70" Text='<%# Bind("Question") %>'></asp:TextBox>
                    <br />
                    Max. Allowed:
                    <asp:Label runat="server" ID="maxlength1" ForeColor="Green" Text='<%# Len(Eval("EnglishQuestion")) %>'></asp:Label>&nbsp
                    &nbsp; Chars Left:
                    <asp:Label runat="server" ID="charsleft1"></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" HorizontalAlign="Left" />
                <FooterTemplate>
                    <asp:Button runat="server" ID="btnSave" Text="Save Changes" CommandName="Save" />
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Right" CssClass="footrow" />
            </asp:TemplateField>
            <%--<asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink runat="server" ID="hlValues" Text="Demographic Values" NavigateUrl='<%# "DemoValues.aspx?DemoNo=" & Eval("DemoNo") %>'
                        Target="sub1"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>--%>
        </Columns>
    </asp:GridView>
</asp:Content>
