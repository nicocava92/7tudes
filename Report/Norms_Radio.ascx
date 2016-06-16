<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Norms_Radio.ascx.vb" Inherits="Norms_Radio" %>
<asp:SqlDataSource ID="cNormData" runat="server" ConnectionString="<%$ ConnectionStrings:cQ %>"
    ProviderName="<%$ ConnectionStrings:cQ.ProviderName %>" 
    SelectCommand="SELECT [QNo], [ShowQNo], [Stem], [Choice1], [Choice2], [Choice3], [Choice4], [Choice5], [Choice6], [Choice7], [Choice8], [Choice9], [Norm1], [Norm2], [Norm3], [Norm4], [Norm5], [Norm6], [Norm7], [Norm8], [Norm9] FROM [qryNorms_radio] where ShowQNo=?">
    <SelectParameters>
        <asp:ControlParameter ControlID="ShowQNo" Name="?" PropertyName="Text" />
    </SelectParameters>
</asp:SqlDataSource>
<asp:TextBox runat=server ID=ShowQNo Visible=False></asp:TextBox>
<table width=700 runat=server id=tabNorm cellpadding=3 cellspacing=0 border=1 bordercolor=silver>

</table>

