<%@ Page Language="VB" Trace="false" Debug="false" AutoEventWireup="false" MasterPageFile="lang.master"
    Title="Search" CodeFile="Search.aspx.vb" Inherits="Lang_Search" StylesheetTheme="Lang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Section">
        Search</div>
    <table width="700">
        <tr>
            <td colspan="2">
                This page allows you to search for specific key terms or words. The search will
                work for English or the language in progress of being translated. Please type in
                the word or words you would like to search for. The results will be shown below.
                Results are displayed by section name and the count of entries containing the searched
                term(s). Clicking on the link will take you to the appropriate section and will
                show only the entries containing the searched term(s).
                <br />
                <br />
                *Note: you can enter “#lang” (without the quotes) into the search field and it will
                find all entries where translations are missing. Entries missing translations will
                be highlighted in <span class="langmissing">red</span> when NOT in search mode.
                <br />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Search:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtSearch" Width="300"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button runat="server" ID="btnSearch" Text="Search" />&nbsp; &nbsp;
                <asp:Button runat="server" ID="btnClear" Text="Clear Search" />
            </td>
        </tr>
    </table>
    <br />
    <asp:SqlDataSource runat="server" ID="rsA" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
        SelectCommand="Lang_DoSearch_Count" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:CookieParameter CookieName="LanguageID" DefaultValue="1" Name="LanguageID" Type="Int32" />
            <asp:ControlParameter ControlID="txtSearch" Name="search" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView runat="server" ID="tabA" DataSourceID="rsA" AutoGenerateColumns="false"
        AlternatingRowStyle-CssClass="altrow" EmptyDataText="No matches found." HeaderStyle-CssClass="headrow"
        CellPadding="3" CellSpacing="0" ShowHeader="true" GridLines="Both">
        <FooterStyle CssClass="footrow" />
        <Columns>
            <%--<asp:HyperLinkField DataTextField="PageName" DataNavigateUrlFields="PageName" Target="sub1"
                HeaderText="Page Name" />--%><asp:TemplateField HeaderText="Section">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("PageName") %>'
                            Target="sub1" Text='<%# Replace(Eval("PageName"), ".aspx", "") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            <asp:BoundField DataField="Count1" HeaderText="# matches" ItemStyle-HorizontalAlign="Right" />
        </Columns>
    </asp:GridView>
</asp:Content>
