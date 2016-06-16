<%@ Page Language="VB" Trace="false" Debug="false" MasterPageFile="lang.master" StylesheetTheme="Lang"
    AutoEventWireup="false" CodeFile="Scale.aspx.vb" Inherits="Lang_Scale" ValidateRequest="False"
    Title="Scale Labels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:SqlDataSource ID="rsA" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
        SelectCommand="SELECT AutoID,  [LanguageID], RespText1, RespText2, respText3, RespText4, RespText5, RespText6, RespText7, English1 as EnglishRespText1, English2 as EnglishRespTExt2, English3 as EnglishRespText3, English4 as EnglishRespText4, English5 as EnglishRespText5, English6 as EnglishRespText6, English7 as EnglishRespText7 FROM [Lang_Scale] WHERE ([LanguageID] = @LanguageID) and  ((@txtSearch='zz') OR (CharIndex(@txtSearch, IsNull(English1, '')+ ' -- ' +IsNull(RespText1, '')+ ' -- ' +IsNull(English2, '')+ ' -- ' +IsNull(RespText2, '')+ ' -- '+IsNull(English3, '')+ ' -- ' +IsNull(RespText3, '')+ ' -- '+IsNull(English4, '')+ ' -- ' +IsNull(RespText4, '')+ ' -- '+IsNull(English5, '')+ ' -- ' +IsNull(RespText5, '')+ ' -- '+IsNull(English6, '')+ ' -- ' +IsNull(RespText6, '')+ ' -- '+IsNull(English7, '')+IsNull(RespText7, ''))>0)) ">
        <SelectParameters>
            <asp:CookieParameter CookieName="LanguageID" Name="LanguageID" Type="Byte" />
            <asp:ControlParameter ControlID="txtSearch" Name="txtSearch" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <div class="Section">
        Scale Labels&nbsp; &nbsp; &nbsp; (Current Search:
        <asp:Label runat="server" ID="txtSearch" Text="" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="CurrentSearch" Text="" Font-Italic="true"></asp:Label>)</div>
    <asp:Label runat="server" ID="Message" CssClass="error" EnableViewState="False"></asp:Label><br />
    <asp:GridView ID="tabA" runat="server" Width="500px" CellPadding="4" DataSourceID="rsA"
        EmptyDataText="No matching text at this time." AutoGenerateColumns="False" ShowFooter="True">
        <HeaderStyle CssClass="headrow" />
        <FooterStyle CssClass="footrow" />
        <AlternatingRowStyle CssClass="altrow" />
        <Columns>
            <asp:TemplateField HeaderText="Scale Text">
                <ItemTemplate>
                    <asp:Label ID="AutoID" runat="server" Visible="False" Text='<%# Eval("AutoID") %>'></asp:Label>
                    <table border="1" cellpadding="3" cellspacing="0">
                        <tr>
                            <td valign="top">
                                1.
                            </td>
                            <td valign="top">
                                <asp:Label runat="server" ID="EnglishRespText1" Text='<%# Eval("EnglishRespText1") %>'></asp:Label>
                            </td>
                            <td valign="top">
                                <asp:TextBox runat="server" ID="respText1" Text='<%# Eval("RespText1") %>' TextMode="MultiLine"
                                    Rows="3" Columns="50" SkinID="1"></asp:TextBox>
                                <br />
                                Max. Allowed:
                                <asp:Label runat="server" ID="maxlength1" ForeColor="Green" Text='<%# Len(Eval("EnglishRespText1")) %>'></asp:Label>&nbsp;
                                &nbsp; Chars Left:
                                <asp:Label runat="server" ID="charsleft1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                2.
                            </td>
                            <td valign="top">
                                <asp:Label runat="server" ID="EnglishRespText2" Text='<%# Eval("EnglishRespText2") %>'></asp:Label>
                            </td>
                            <td valign="top">
                                <asp:TextBox runat="server" ID="RespText2" Text='<%# Eval("RespText2") %>' TextMode="MultiLine"
                                    Rows="3" Columns="50" SkinID="2"></asp:TextBox><br />
                                Max. Allowed:
                                <asp:Label runat="server" ID="maxlength2" ForeColor="Green" Text='<%# Len(Eval("EnglishRespText2")) %>'></asp:Label>&nbsp;
                                &nbsp; Chars Left:
                                <asp:Label runat="server" ID="charsleft2"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                3.
                            </td>
                            <td valign="top">
                                <asp:Label runat="server" ID="EnglishRespText3" Text='<%# Eval("EnglishRespText3") %>'></asp:Label>
                            </td>
                            <td valign="top">
                                <asp:TextBox runat="server" ID="RespText3" Text='<%# Eval("RespText3") %>' TextMode="MultiLine"
                                    Rows="3" Columns="50" SkinID="3"></asp:TextBox><br />
                                Max. Allowed:
                                <asp:Label runat="server" ID="maxlength3" ForeColor="Green" Text='<%# Len(Eval("EnglishRespText3")) %>'></asp:Label>&nbsp;
                                &nbsp; Chars Left:
                                <asp:Label runat="server" ID="charsleft3"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                4.
                            </td>
                            <td valign="top">
                                <asp:Label runat="server" ID="EnglishRespText4" Text='<%# Eval("EnglishRespText4") %>'></asp:Label>
                            </td>
                            <td valign="top">
                                <asp:TextBox runat="server" ID="RespText4" Text='<%# Eval("RespText4") %>' TextMode="MultiLine"
                                    Rows="3" Columns="50" SkinID="4"></asp:TextBox><br />
                                Max. Allowed:
                                <asp:Label runat="server" ID="maxlength4" ForeColor="Green" Text='<%# Len(Eval("EnglishRespText4")) %>'></asp:Label>&nbsp;
                                &nbsp; Chars Left:
                                <asp:Label runat="server" ID="charsleft4"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                5.
                            </td>
                            <td valign="top">
                                <asp:Label runat="server" ID="EnglishRespText5" Text='<%# Eval("EnglishRespText5") %>'></asp:Label>
                            </td>
                            <td valign="top">
                                <asp:TextBox runat="server" ID="RespText5" Text='<%# Eval("RespText5") %>' TextMode="MultiLine"
                                    Rows="3" Columns="50" SkinID="5"></asp:TextBox><br />
                                Max. Allowed:
                                <asp:Label runat="server" ID="maxlength5" ForeColor="Green" Text='<%# Len(Eval("EnglishRespText5")) %>'></asp:Label>&nbsp;
                                &nbsp; Chars Left:
                                <asp:Label runat="server" ID="charsleft5"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                6.
                            </td>
                            <td valign="top">
                                <asp:Label runat="server" ID="EnglishRespText6" Text='<%# Eval("EnglishRespText6") %>'></asp:Label>
                            </td>
                            <td valign="top">
                                <asp:TextBox runat="server" ID="RespText6" Text='<%# Eval("RespText6") %>' TextMode="MultiLine"
                                    Rows="3" Columns="50" SkinID="6"></asp:TextBox><br />
                                Max. Allowed:
                                <asp:Label runat="server" ID="maxlength6" ForeColor="Green" Text='<%# Len(Eval("EnglishRespText6")) %>'></asp:Label>&nbsp;
                                &nbsp; Chars Left:
                                <asp:Label runat="server" ID="charsleft6"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                7.
                            </td>
                            <td valign="top">
                                <asp:Label runat="server" ID="EnglishRespText7" Text='<%# Eval("EnglishRespText7") %>'></asp:Label>
                            </td>
                            <td valign="top">
                                <asp:TextBox runat="server" ID="RespText7" Text='<%# Eval("RespText7") %>' TextMode="MultiLine"
                                    Rows="3" Columns="50" SkinID="7"></asp:TextBox><br />
                                Max. Allowed:
                                <asp:Label runat="server" ID="maxlength7" ForeColor="Green" Text='<%# Len(Eval("EnglishRespText7")) %>'></asp:Label>&nbsp;
                                &nbsp; Chars Left:
                                <asp:Label runat="server" ID="charsleft7"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle VerticalAlign="Top" />
                <FooterTemplate>
                    <asp:Button runat="server" ID="btnSave" Text="Save Changes" CommandName="Save" />
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Right" CssClass="footrow" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
