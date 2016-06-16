<%@ Page Title="Welcome to the Free Seven Tudes" Language="VB" MasterPageFile="free.master" Trace="False" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Free_Default" StylesheetTheme="Freev2" %>
<%@ Register TagName=Progress TagPrefix=pr Src="Progress.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <pr:Progress runat=server ID=ProgressInfo pPageNo=1   /> 

    <table cellpadding="20">
        <tr>
            <td colspan="2">
            <h3>Are you leading with your best energy?</h3>
            </td>
        </tr><tr>
            <td width="50%" valign="top">
                <p>We believe that energy is the ultimate competitive advantage. Based on pioneering research and results with elite performers including world-class athletes, military, surgeons and Fortune 500 CEOs over thirty years, the Johnson & Johnson Human Performance Institute has identified groundbreaking insights on the subject of human energy. Increasing and sustaining energy leads to full engagement which in turn can propel higher performance, better teamwork, deeper relationships, and stronger leadership.</p>
                <br />
                <p>In terms of energy, being fully engaged and achieving your best self occurs when you are physically energized, emotionally connected, mentally focused, and spiritually aligned. This free Seven Tudes provides a snapshot of your current energy management skills to help you increase your levels of energy in all dimensions.</p>
                <br /><br />
                <asp:Button runat="server" ID="btnStart" Text="BEGIN FREE Seven Tudes" CssClass="btn btn-primary btn300" />
            </td>
            <td valign="top" align="center">
                <img src="pyramid.png" />
            </td>
        </tr>
    </table>

</asp:Content>
