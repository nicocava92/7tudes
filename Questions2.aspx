<%@ Page Title="Seven Tudes" Trace="false" Debug="false" Language="VB" MasterPageFile="free.master" StylesheetTheme="Freev2" AutoEventWireup="false" CodeFile="Questions2.aspx.vb" Inherits="Free_Questions2" %>
<%@ Register TagName=Progress TagPrefix=pr Src="Progress.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <pr:Progress runat=server ID=ProgressInfo pPageNo=1   />
    <div style="width:100%;padding:10px;padding-right:25px;padding-bottom:0px;"><span class="xofy">Page 2 of 7</span></div> 

    <asp:SqlDataSource runat="server" ID="rsQ" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
        SelectCommand="SELECT [QNo], [Question_Self] as Question, Stem, [ShowQNo_Self] as ShowQno, RespText1, RespText2, RespText3, RespText4, RespText5 FROM [Questions] inner join Scale on Questions.LanguageID=Scale.LanguageID WHERE (Questions.[LanguageID] = @LanguageID) and QNo BETWEEN 5 AND 8 ">
        <SelectParameters>
            <asp:CookieParameter CookieName="LanguageID" DefaultValue="1" Name="LanguageID" Type="Byte" />
        </SelectParameters>
    </asp:SqlDataSource>
    <div class="tude aptitude">APTITUDE</div>
    <div class="stem">Does your company have the right experiential resources to succeed?  Key players have adequate...:</div>
    <table>
        <tr>
            <td>
                <asp:GridView ID="tabQ" runat="server" AutoGenerateColumns="False" DataSourceID="rsQ" border="0" CellPadding="0" CellSpacing="0" BorderWidth="0" ShowHeader="False" ShowFooter="True" AlternatingRowStyle-CssClass="altrow">
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:RequiredFieldValidator runat="server" ID="reqResp" ValidationGroup="valgroup" ControlToValidate="Resp" Text="*" Enabled="True" CssClass="required"></asp:RequiredFieldValidator>
                                <asp:Label runat="server" ID="ShowQNo" Font-Bold="true"></asp:Label>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Question") %>' Font-Bold="true"></asp:Label>
                                <asp:Label runat="server" ID="QNo" Visible="False" Text='<%# Eval("QNo") %>' Font-Bold="true"></asp:Label>
                                <div style="padding-left:50px; padding-top:15px;">
                                    <asp:RadioButtonList runat="server" ID="Resp" CellPadding="0" CellSpacing="0" BorderWidth="0" RepeatDirection="vertical" >
                                        <asp:ListItem Text="(1) Strongly Disagree" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="(2) Disagree" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="(3) Neither Agree nor Disagree" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="(4) Agree" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="(5) Strongly Agree" Value="5"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:ValidationSummary runat="server" ID="valsumm1" ValidationGroup="valgroup" CssClass="alert alert-danger rounded" ShowMessageBox="False" HeaderText='<%$ Resources:LangText, profile_reqdmissing %>' />
                                <asp:Button runat="server" ID="btnNext" ValidationGroup="valgroup" Text='<%$ Resources:Langtext, questions_btnnext %>' CommandName="Next" CssClass="btn btn-primary btn200"/>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
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
