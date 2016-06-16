<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Scale.ascx.vb" Inherits="Report_Scale2" %>
<asp:SqlDataSource ID="rsScale" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
    SelectCommand="SELECT [LanguageID], [RespText1], [RespText2], [RespText3], [RespText4], [RespText5], [RespText6], [RespText7], (Select top 1 keyvalue from Reportlabels where keyname='profile_scaleheading' and LanguageID=@LanguageID) as profile_scaleheading FROM [Scale] WHERE ([LanguageID] = @LanguageID)">
    <SelectParameters>
        <asp:QueryStringParameter QueryStringField="LanguageId" DefaultValue="1" Name="LanguageID"
            Type="Int16" />
    </SelectParameters>
</asp:SqlDataSource>
<center>
    <br />
    <br />
    <br />
    <%--The scale used is shown below:--%>
    <asp:Label runat="server" ID="profile_scaleheading"></asp:Label>
    <br />
    <br />
    <table cellspacing="0" cellpadding="5" border="0" width="600">
        <tr>
            <asp:Repeater ID="tabScale" runat="server" DataSourceID="rsScale">
                <ItemTemplate>
                    <td valign="top" align="center" class="heading5">
                        <asp:Label runat="server" ID="ScaleID" Text="1"></asp:Label>
                        <br />
                        <asp:Label runat="server" ID="RespText1" Text='<%# fsHTML(Eval("RespText1")) %>'></asp:Label>
                    </td>
                    <td valign="top" align="center" class="heading5">
                        <asp:Label runat="server" ID="Label1" Text="2"></asp:Label>
                        <br />
                        <asp:Label runat="server" ID="Label2" Text='<%# fsHTML(Eval("RespText2")) %>'></asp:Label>
                    </td>
                    <td valign="top" align="center" class="heading5">
                        <asp:Label runat="server" ID="Label3" Text="3"></asp:Label>
                        <br />
                        <asp:Label runat="server" ID="Label4" Text='<%# fsHTML(Eval("RespText3")) %>'></asp:Label>
                    </td>
                    <td valign="top" align="center" class="heading5">
                        <asp:Label runat="server" ID="Label5" Text="4"></asp:Label>
                        <br />
                        <asp:Label runat="server" ID="Label6" Text='<%# fsHTML(Eval("RespText4")) %>'></asp:Label>
                    </td>
                    <td valign="top" align="center" class="heading5">
                        <asp:Label runat="server" ID="Label7" Text="5"></asp:Label>
                        <br />
                        <asp:Label runat="server" ID="Label8" Text='<%# fsHTML(Eval("RespText5")) %>'></asp:Label>
                    </td>
                    <td valign="top" align="center" class="heading5">
                        <asp:Label runat="server" ID="Label9" Text="6"></asp:Label>
                        <br />
                        <asp:Label runat="server" ID="Label10" Text='<%# fsHTML(Eval("RespText6")) %>'></asp:Label>
                    </td>
                    <td valign="top" align="center" class="heading5">
                        <asp:Label runat="server" ID="Label11" Text="7"></asp:Label>
                        <br />
                        <asp:Label runat="server" ID="Label12" Text='<%# fsHTML(Eval("RespText7")) %>'></asp:Label>
                    </td>
                </ItemTemplate>
            </asp:Repeater>
        </tr>
    </table>
</center>
