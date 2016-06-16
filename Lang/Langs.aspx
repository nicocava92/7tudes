<%@ Page Language="VB" MasterPageFile="lang.master" StyleSheetTheme="Lang" AutoEventWireup="false" CodeFile="Langs.aspx.vb" Inherits="Lang_Langs" title="Languages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource ID="rsLang" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
        DeleteCommand="DELETE FROM [Languages] WHERE [LanguageID] = @LanguageID" 
        InsertCommand="INSERT INTO [Languages] ([LanguageName]) VALUES (@LanguageName)"
        SelectCommand="SELECT [LanguageID], [LanguageName] FROM [Languages] ORDER BY [LanguageID]"
        UpdateCommand="UPDATE [Languages] SET [LanguageName] = @LanguageName WHERE [LanguageID] = @LanguageID">
        <DeleteParameters>
            <asp:Parameter Name="LanguageID" Type="Byte" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="LanguageName" Type="String" />
            <asp:Parameter Name="LanguageID" Type="Byte" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="LanguageName" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="tabLang" runat="server" DataSourceID=rsLang AutoGenerateColumns=True
     CellPadding=5 CellSpacing=0 HeaderStyle-CssClass="headrow"
      AlternatingRowStyle-CssClass="altrow" 
     AutoGenerateEditButton="true">
    </asp:GridView>
    <asp:TextBox runat=server ID=NewLanguageName></asp:TextBox>
    <asp:Button runat=server ID="btnInsert" Text="Create New Language" />
</asp:Content>

