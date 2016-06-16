<%@ Page Title="" Language="VB" MasterPageFile="free.master" AutoEventWireup="false" Trace="false" StylesheetTheme="Freev2" CodeFile="profile.aspx.vb" Inherits="Free_profile" %>
<%@ Register TagName="Progress" TagPrefix="pr" Src="Progress.ascx" %>

<%@ Register TagName="pyr" TagPrefix="uc" Src="Pyramid.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <pr:Progress runat="server" ID="ProgressInfo" pPageNo="1"   />

    <br />
    <asp:Label runat=server ID=Message CssClass="alert alert-success rounded" style="display:none;"></asp:Label>

    <table cellpadding="20">
        <tr>
            <td align="left">

            <div style="text-align: left">
                <uc:pyr runat="server" ID="pyr1"></uc:pyr>
            </div>

            </td>
        </tr>
        <tr>
            <td>

            <table runat="server" id="tabshow" cellpadding="10">
                <tr>
                    <td><asp:Label runat=server ID=PID Visible=false></asp:Label>
                        <p><b>Email results to yourself:</b></p>
                        <asp:TextBox runat="server" ID="EmailAddress" Width="250"></asp:TextBox><br />
                        <asp:RequiredFieldValidator runat="server" ID="reqEmailAddress" ControlToValidate="EmailAddress" ValidationGroup="email"></asp:RequiredFieldValidator><br />
                        <asp:RegularExpressionValidator runat="server" ID="regEmailAddress" ControlToValidate="EmailAddress" ValidationGroup="email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <asp:Button runat="server" ID="btnEmail" Text="Send Email" ValidationGroup="email" CssClass="btn btn-primary btn200" />
                        <asp:ValidationSummary runat="server" ID="valsumm1" ValidationGroup="email" ShowMessageBox="true" ShowSummary="false" HeaderText="Please provide a valid email address" />
                    </td>
                    <td width="30">
                    </td>
                    <%-- <td align="left" valign="middle" style="border: 1px solid blue; padding: 10px;">
                        <center><asp:Button runat="server" ID="btnNextSteps" Text="Next Steps" /></center>
                    </td>--%>
                </tr>
            </table>

            </td>
        </tr>
    </table>

</asp:Content>
