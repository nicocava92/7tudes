<%@ Page Title="Free Seven Tudes" Trace="false" Debug="false" Language="VB" MasterPageFile="free.master" StylesheetTheme="Freev2" AutoEventWireup="false" CodeFile="Questions.aspx.vb" Inherits="Free_Questions1" %>
<%@ Register TagName=Progress TagPrefix=pr Src="Progress.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <pr:Progress runat=server ID=ProgressInfo pPageNo=1   /> 

    <asp:SqlDataSource runat="server" ID="rsQ" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
        SelectCommand="SELECT [QNo], [Question_Self] as Question, [ShowQNo_Self] as ShowQno, RespText1, RespText2, RespText3, RespText4, RespText5, RespText6, RespText7  FROM [Questions] inner join Scale on Questions.LanguageID=Scale.LanguageID WHERE (Questions.[LanguageID] = @LanguageID) and QNo in (102, 98, 83, 31, 42, 46, 51, 67, 60, 1, 20, 23) ORDER BY [QNo]">
        <SelectParameters>
            <asp:CookieParameter CookieName="LanguageID" DefaultValue="1" Name="LanguageID" Type="Byte" />
        </SelectParameters>
    </asp:SqlDataSource>
    <table>
        <tr>
            <td style="padding-left: 43px">
                <table border="0">
                    <tr runat="server" id="headrow" class="headrow"></tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-left: 43px">
                <asp:Label runat="server" ID="ParticipantName" CssClass="yellow"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <%--<asp:Panel runat=server ID=p1 Height=450 ScrollBars=Auto>--%>
                <asp:GridView ID="tabQ" runat="server" AutoGenerateColumns="False" DataSourceID="rsQ" border="0" CellPadding="5" CellSpacing="0" BorderWidth="0" ShowHeader="False" ShowFooter="True" AlternatingRowStyle-CssClass="altrow">
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:RequiredFieldValidator runat="server" ID="reqResp" ValidationGroup="valgroup" ControlToValidate="Resp" Text="*" Enabled="True" CssClass="required"></asp:RequiredFieldValidator>
                                <asp:Label runat="server" ID="ShowQNo" Font-Bold="true"></asp:Label>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Question") %>' Font-Bold="true"></asp:Label>
                                <asp:Label runat="server" ID="QNo" Visible="False" Text='<%# Eval("QNo") %>' Font-Bold="true"></asp:Label>
                                <div align="center">
                                    <asp:RadioButtonList runat="server" ID="Resp" CellPadding="3" CssClass="centered" BorderWidth="0" RepeatDirection="horizontal">
                                        <asp:ListItem Text="<br>1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="<br>2" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="<br>3" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="<br>4" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="<br>5" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="<br>6" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="<br>7" Value="7"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom"/>
                            <ItemStyle VerticalAlign="Middle"/>
                            <FooterTemplate>
                                <table align="right">
                                    <tr>
                                        <td valign="top">
                                            <asp:Button runat="server" ID="btnNext" ValidationGroup="valgroup" Text='<%$ Resources:Langtext, questions_btnnext %>'
                                                CommandName="Next" CssClass="btn btn-primary btn200"/>
                                            <br />
                                            <asp:ValidationSummary runat="server" ID="valsumm1" ValidationGroup="valgroup" ShowMessageBox="True"
                                                HeaderText='<%$ Resources:LangText, profile_reqdmissing %>' />
                                        </td>
                                    </tr>
                                </table>
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <%--    </asp:Panel>
                --%>
            </td>
        </tr>
    </table>
    <script type="text/javascript" language="javascript">
        function value_set(qno, resp) {
            //alert(resp);
            var e1;
            e1 = document.getElementById('T' + qno);
            e1.value = resp;

        }

        function check_all() {
            //alert('checking');
            var s1 = new String('');

            for (var i1 = 1; i1 <= 12; i1++) {
                //alert(i1);
                e1 = document.getElementById('T' + i1);
                //alert(e1.value);
                if (e1.value == '') s1 = s1 + ', ' + i1;
            }

            if (s1 == '') return (true);
            s1 = s1.substr(2);
            alert("Please respond to questions " + s1);
            return (false);
        }

        
    </script>
</asp:Content>
