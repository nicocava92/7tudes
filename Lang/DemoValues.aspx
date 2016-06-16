<%@ Page Language="VB" Trace="False" Debug="False" MasterPageFile="lang.master" ValidateRequest="False"
    StylesheetTheme="Lang" AutoEventWireup="false" CodeFile="DemoValues.aspx.vb"
    Inherits="Lang_DemoValues" Title="Demographics Values" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Section">
        Demographics Values&nbsp; &nbsp; &nbsp; (Current Search:
        <asp:Label runat="server" ID="txtSearch" Text="" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="CurrentSearch" Text="" Font-Italic="true"></asp:Label>)</div>
    <table>
        <tr>
            <td colspan="3">
                Please select each Demographic listed in the table on the left and enter the appropriate
                translations for each of the values listed to the right.
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td>
                <asp:Label runat="server" ID="Message" CssClass="error" EnableViewState="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" runat="server" id="tdDemo">
                <asp:SqlDataSource runat="server" ID="rsDemo" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
                    SelectCommand="SELECT [DemoNo], [Question] FROM [Demographics] where LanguageID=1 Order by DemoNo">
                </asp:SqlDataSource>
                <asp:GridView runat="server" ID="tabDemo" DataSourceID="rsDemo" DataKeyNames="DemoNo"
                    SelectedIndex="0" SelectedRowStyle-CssClass="selrow" AutoGenerateColumns="False"
                    HeaderStyle-CssClass="headrow" EnableModelValidation="True">
                    <FooterStyle CssClass="footrow" />
                    <Columns>
                        <asp:BoundField DataField="DemoNo" HeaderText="Row ID" />
                        <asp:TemplateField HeaderText="Select Demographic">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                    Text='<%# Eval("Question") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <SelectedRowStyle CssClass="selrow"></SelectedRowStyle>
                </asp:GridView>
            </td>
            <td width="15">
            </td>
            <td valign="top">
                <asp:SqlDataSource ID="rsA" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
                    SelectCommand="SELECT AutoID, [LanguageID], [DemoNo], [SortOrder], [EnglishShowValue], [ShowValue], Question FROM [Lang_DemoValues] WHERE ([LanguageID] = @LanguageID) AND ([DemoNo] = @DemoNo) and  (@txtSearch='zz') OR ([LanguageID] = @LanguageID) and (@txtSearch<>'zz') and (CharIndex(@txtSearch, IsNull(EnglishShowValue, '')+ ' -- ' +IsNull(ShowValue, ''))>0) ORDER BY [SortOrder]">
                    <SelectParameters>
                        <asp:CookieParameter CookieName="LanguageID" Name="LanguageID" Type="Int16" />
                        <asp:ControlParameter ControlID="tabDemo" Name="DemoNo" PropertyName="SelectedValue"
                            Type="Int16" />
                        <asp:ControlParameter ControlID="txtSearch" Name="txtSearch" PropertyName="Text"
                            Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <%-- <asp:FormView runat="server" ID="DemoInfo" DataSourceID="rsA" EnableModelValidation="True">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="Question_Self" Font-Bold="True" Text='<%# Eval("Question") %>'></asp:Label>
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:FormView>--%>
                <asp:GridView ID="tabA" runat="server" Width="750px" CellPadding="4" DataSourceID="rsA"
                    EmptyDataText="No matching text at this time." AutoGenerateColumns="False" ShowFooter="True"
                    EnableModelValidation="True">
                    <HeaderStyle CssClass="headrow" />
                    <FooterStyle CssClass="footrow" />
                    <AlternatingRowStyle CssClass="altrow" />
                    <Columns>
                        <asp:TemplateField HeaderText="Row ID">
                            <ItemTemplate>
                                <asp:Label ID="AutoID" runat="server" Text='<%# Eval("AutoID") %>' Visible="False"></asp:Label>
                                <asp:Label ID="RowID" runat="server" Text='<%# Eval("DemoNo") & ". " & Eval("SortOrder") %>'
                                    Visible="True"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Display Value">
                            <ItemStyle VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="EnglishShowValue" runat="server" Text='<%# Eval("EnglishShowValue") %>'></asp:Label>
                                <br />
                                <asp:TextBox ID="ShowValue" SkinID="1" runat="server" Text='<%# Bind("ShowValue") %>'
                                    Columns="70"></asp:TextBox>
                                <br />
                                Max. Allowed:
                                <asp:Label runat="server" ID="maxlength1" ForeColor="Green" Text='<%# Len(Eval("EnglishShowValue")) %>'></asp:Label>&nbsp
                                &nbsp; Chars Left:
                                <asp:Label runat="server" ID="charsleft1"></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Button runat="server" ID="btnSave" Text="Save Changes" CommandName="Save" />
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
