<%@ Page Language="VB" Trace="false" Debug="false" MasterPageFile="lang.master" StylesheetTheme="Lang"
    AutoEventWireup="false" CodeFile="Dimensions.aspx.vb" Inherits="Lang_Dimensions"
    ValidateRequest="False" Title="Dimensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:SqlDataSource ID="rsA" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
        SelectCommand="SELECT AutoID,  [LanguageID], [DimNo], DimName, DimDesc, [EnglishDimName], EnglishDimDesc FROM [Lang_Dimensions] WHERE ([LanguageID] = @LanguageID) and  ((@txtSearch='zz') OR (CharIndex(@txtSearch, IsNull(EnglishDimName, '')+ ' -- ' +IsNull(EnglishDimDesc, '')+ ' -- ' +IsNull(DimName, '')+ ' -- ' +IsNull(DimDesc, ''))>0)) ORDER BY [DimNo]">
        <SelectParameters>
            <asp:CookieParameter CookieName="LanguageID" Name="LanguageID" Type="Byte" />
            <asp:ControlParameter ControlID="txtSearch" Name="txtSearch" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <div class="Section">
        Dimensions&nbsp; &nbsp; &nbsp; (Current Search:
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
                    <asp:Label ID="DimNo" runat="server" Text='<%# Eval("DimNo") %>'></asp:Label>
                    <asp:Label ID="AutoID" runat="server" Visible="False" Text='<%# Eval("AutoID") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dimension Name">
                <ItemTemplate>
                    <asp:Label ID="EnglishDimName" runat="server" Text='<%# Eval("EnglishDimName") %>'></asp:Label>
                    <br />
                    <asp:TextBox ID="DimName" runat="server" Text='<%# Bind("DimName") %>' SkinID="1"
                        Columns="60"></asp:TextBox>
                    <br />
                    Max. Allowed:
                    <asp:Label runat="server" ID="maxlength1" ForeColor="Green" Text='<%# Len(Eval("EnglishDimName")) %>'></asp:Label>&nbsp
                    &nbsp; Chars Left:
                    <asp:Label runat="server" ID="charsleft1"></asp:Label>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dimension Desc">
                <ItemTemplate>
                    <asp:Label ID="EnglishDimDesc" runat="server" Text='<%# Eval("EnglishDimDesc") %>'></asp:Label>
                    <br />
                    <asp:TextBox ID="DimDesc" runat="server" Text='<%# Bind("DimDesc") %>' TextMode="MultiLine"
                        Rows="8" Columns="80" SkinID="2"></asp:TextBox>
                    <br />
                    Max. Allowed:
                    <asp:Label runat="server" ID="maxlength2" ForeColor="Green" Text='<%# Len(Eval("EnglishDimDesc")) %>'></asp:Label>&nbsp
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
