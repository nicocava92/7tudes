<%@ Page Title="Welcome to the Seven Tudes Assessment" Language="VB" MasterPageFile="free.master" Trace="False" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Free_Default" StylesheetTheme="Freev2" %>
<%@ Register TagName=Progress TagPrefix=pr Src="Progress.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <pr:Progress runat=server ID=ProgressInfo pPageNo=1   /> 

    <table cellpadding="20">
        <tr>
            <td colspan="2">
            <h3>Are you considering overseas expansion?</h3>
            </td>
        </tr><tr>
            <td width="50%" valign="top">
                <p>International expansion initiatives are often an essential part of a company’s growth strategy. And, most companies are meticulous in their analysis of the external conditions that await them abroad.  Frequently overlooked however, are the internal barriers that can sabotage their venture before it has a chance to take off.  We have developed the Seven Tudes survey to capture data reflecting your perception of your organization’s preparedness regarding the fundamental internal areas. </p>
                <br />
                <asp:Button runat="server" ID="btnStart" Text="Take the Seven Tudes Survey Now" CssClass="btn btn-primary btn300" />
                <br /><br />
                <p>Upon completion of the 5 minute, 28 question (4 per tude) survey, you will see your score in a spider chart infographic. This will help you identify which “tudes” your organization did right as well as the “tudes that preclude,” so you can avoid them in the future. You can even email the results to yourself. Thanks for participating in our survey and sharing your information and experience. By doing so, you are contributing to ongoing academic research.</p>
                <br />
                <asp:Button runat="server" ID="btnAbout" Text="Learn about the Seven Tudes Survey" CssClass="btn btn-primary btn300" />
            </td>
            <td valign="top" align="center">
                <img src="images/7tudes_circumplex.png" />
            </td>
        </tr>
    </table>

</asp:Content>
