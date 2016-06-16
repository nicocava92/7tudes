<%@ Page Title="Welcome to the Seven Tudes Assessment" Language="VB" MasterPageFile="free.master" Trace="False" AutoEventWireup="false" CodeFile="Learn.aspx.vb" Inherits="Free_Learn" StylesheetTheme="Freev2" %>
<%@ Register TagName=Progress TagPrefix=pr Src="Progress.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <pr:Progress runat=server ID=ProgressInfo pPageNo=1   /> 

    <table cellpadding="20">
        <tr>
            <td colspan="2">
            <h3>7 ‘Tudes Diagnostic “Team Pack”: Get all the key stakeholders involved before you begin.  This simple tool will help you.</h3>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <p>By getting your entire team to take the 7 ‘Tudes diagnostic tool, (up to 8 participants) you will not only learn where the potential pitfalls may lie, you will also uncover disparities in perception and attitude regarding your expansion initiative. Additionally, the whole team will be sensitized to the issues that can sabotage the initiative and will become aware of the ‘Tudes required for success.  </p>
                <p>Once you’ve got your team to take the survey, send it to us and we will score it and return it to you along with some possible corrective actions to consider before you undertake the next initiative.	</p>
                <p>If, after seeing your team results, you would like to consider seeking support to identify and address issues, we offer a free monthly webinar during which we will also discuss successful best practices.  Additionally, we offer a standard 2 day training seminar at Thunderbird and University of Hartford as well as other training options. Simply provide the information requested and we will send you the details.</p>
                <%--<br /<br />
                 <asp:Button runat="server" ID="btnStart" Text="Take the 7tudes Survey Now" CssClass="btn btn-primary btn300" />--%>
                <br /><br />
            </td>
            <td>

                <div class="well" style="margin-top:0px;">
                    <asp:Label ID="lFirst" runat="server" Width="150" Font-Size="Medium" Font-Bold="True">First Name</asp:Label>
                    <asp:TextBox ID="pFirst" runat="server" CssClass="box" Visible="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" CssClass="required" ErrorMessage="RequiredFieldValidator" ControlToValidate="pFirst"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lLast" runat="server" Width="150" Font-Size="Medium" Font-Bold="True" CssClass="margint10">Last Name</asp:Label>
                    <asp:TextBox ID="pLast" runat="server" CssClass="box" Visible="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="*" CssClass="required" ErrorMessage="RequiredFieldValidator" ControlToValidate="pLast"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lEmail" runat="server" Width="150" Font-Size="Medium" Font-Bold="True" CssClass="margint10">Email Address</asp:Label>
                    <asp:TextBox ID="pEmail" runat="server" CssClass="box" Visible="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="*" CssClass="required" ErrorMessage="RequiredFieldValidator" ControlToValidate="pEmail"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lCompany" runat="server" Width="150" Font-Size="Medium" Font-Bold="True" CssClass="margint10">Company</asp:Label>
                    <asp:TextBox ID="pCompany" runat="server" CssClass="box" Visible="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Text="*" CssClass="required" ErrorMessage="RequiredFieldValidator" ControlToValidate="pCompany"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lTitle" runat="server" Width="150" Font-Size="Medium" Font-Bold="True" CssClass="margint10">Title</asp:Label>
                    <asp:TextBox ID="pTitle" runat="server" CssClass="box" Visible="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Text="*" CssClass="required" ErrorMessage="RequiredFieldValidator" ControlToValidate="pTitle"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lCountry" runat="server" Width="150" Font-Size="Medium" Font-Bold="True" CssClass="margint10">Country</asp:Label>
                    <asp:TextBox ID="pCountry" runat="server" CssClass="box" Visible="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Text="*" CssClass="required" ErrorMessage="RequiredFieldValidator" ControlToValidate="pCountry"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lTelephone" runat="server" Width="150" Font-Size="Medium" Font-Bold="True" CssClass="margint10">Telephone</asp:Label>
                    <asp:TextBox ID="pTelephone" runat="server" CssClass="box" Visible="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Text="*" CssClass="required" ErrorMessage="RequiredFieldValidator" ControlToValidate="pTelephone"></asp:RequiredFieldValidator>
                    <br /> <br /> 
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary btn200" Visible="true" />
                    <asp:Label ID="Message" Text="" ForeColor="Maroon" runat="server" Style="position: relative"></asp:Label>
                </div>

            </td>
        </tr>
    </table>

</asp:Content>
