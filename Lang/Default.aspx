<%@ Page Language="VB" MasterPageFile="lang.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Index" title="Translator Login" StyleSheetTheme="Lang"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
&nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" Style="position: relative"
        Text="Login" Width="174px"></asp:Label>
    <asp:SqlDataSource ID="cAdmin" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
        ProviderName="<%$ ConnectionStrings:c7tudes.ProviderName %>" SelectCommand="SELECT [UserName], [UserPassword], LanguageID, LanguageName FROM [qryUsersLang] WHERE (([UserName] = @UserName) AND ([UserPassword] = @txtPassword))">
        <SelectParameters>
            <asp:ControlParameter ControlID="UserName" Name="UserName" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="Password" Name="txtPassword" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <table>
        <tr>
            <td>User Name:
            </td>
            <td>
                <asp:TextBox ID="UserName" runat="server" CssClass="box"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="UserName must be entered" ErrorMessage="RequiredFieldValidator" ControlToValidate="UserName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Password:
            </td>
            <td>
                <asp:TextBox ID="Password" TextMode="Password" runat="server" CssClass="box"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="Password must be entered" ErrorMessage="RequiredFieldValidator" ControlToValidate="Password"></asp:RequiredFieldValidator>            
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="Message" Text="" ForeColor="Maroon" runat="server" Style="position: relative"></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>

