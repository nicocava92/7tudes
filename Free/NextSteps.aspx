<%@ Page Title="Next steps" Trace="false" Debug="false" Language="VB" MasterPageFile="free.master"
    AutoEventWireup="false" StylesheetTheme="Freev2" CodeFile="NextSteps.aspx.vb" Inherits="Free_Actions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="4" cellspacing="0">
        <tr>
            <td align="left" valign="top" width="350">
                <b>Next Steps</b>
                <ul>
                    <li>Sign up for the free <a href="http://www.hpinstitute.com" target="rel">Corporate
                        Athlete® Edge e-newsletter</a></li>
                    <li>Purchase an individual one-year license to the new interactive Energy for Performance®
                        e-Course (link to registration page- TBD) </li>
                    <li>Attend a 2.5 day <a href="https://www.hpinstitute.com/training-solutions/corporate-athlete"
                        target="rel">Corporate Athlete® Course</a></li>
                    <li>Bring <a href="https://www.hpinstitute.com/training-solutions" target="rel">Energy
                        Management training</a> to your organization </li>
                    <li>Gain insights into achievement and innovative energy management techniques as described
                        in <a href="https://www.hpinstitute.com/research-press/publications" target="rel">The
                            Only Way to Win book</a> by Human Performance Institute co-founder and thought
                        leader Dr. Jim Loehr </li>
                    <li>Tell a friend </li>
                </ul>
            </td>
            <td align="left" width="25" style="border-right: 1px solid red;">
            </td>
            <td align="left" width="25">
            </td>
            <td align="left" valign="top" width="350">
                <b>Request more information</b>
                <asp:CheckBoxList runat="server" ID="chk1" RepeatDirection="Vertical" RepeatColumns="1">
                    <asp:ListItem Text="Training programs for you"></asp:ListItem>
                    <asp:ListItem Text="Training program for your team or organization"></asp:ListItem>
                    <asp:ListItem Text="NEW Energy for Performance® e-Course"></asp:ListItem>
                    <asp:ListItem Text="Sustainability Tools"></asp:ListItem>
                    <asp:ListItem Text="Books and materials"></asp:ListItem>
                </asp:CheckBoxList>
                <br />
                Please provide your contact information (optional)
                <table cellpadding="4" cellspacing="0">
                    <tr>
                        <td>
                            <i>First Name:</i>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="FirstName"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <i>Last Name:</i>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="LastName"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <i>Email Address:<asp:RequiredFieldValidator runat="server" ID="reqEmailAddress" ControlToValidate="EmailAddress"
                                ValidationGroup="email"></asp:RequiredFieldValidator><br />
                            <asp:RegularExpressionValidator runat="server" ID="regEmailAddress" ControlToValidate="EmailAddress"
                                ValidationGroup="email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                <asp:ValidationSummary runat="server" ID="valsumm1" ValidationGroup="email" ShowMessageBox="true"
                    ShowSummary="false" HeaderText="Please provide a valid email address" /></i>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="EmailAddress"></asp:TextBox>
                            
                
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <i>Phone:</i>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="PhoneNum"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <i>Best way to contact:</i>
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ContactType">
                                <asp:ListItem Text="Email" Value="Email"></asp:ListItem>
                                <asp:ListItem Text="Phone" Value="Phone"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <i>If by phone, what time:</i>
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ContactTime">
                                <asp:ListItem Text="8AM-Noon" Value="8AM_Noon"></asp:ListItem>
                                <asp:ListItem Text="Noon-5PM" Value="Noon-5PM"></asp:ListItem>
                                <asp:ListItem Text="5-9PM" Value="5-9PM"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button runat="server" ID="btnContactInfo" Text="Submit" ValidationGroup="email" />
                            <br />
                            <br />
                            <asp:Label runat="server" ID="Message" CssClass="err" EnableViewState="false"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
