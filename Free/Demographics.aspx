<%@ Page Language="VB" Trace="false" Debug="false" StylesheetTheme="Freev2" Culture="auto" UICulture="auto" MasterPageFile="free.master" AutoEventWireup="false" CodeFile="Demographics.aspx.vb" Inherits="Survey_Self_SurveyA" Title="Demographics" %>
<%@ Register TagName="Progress" TagPrefix="pr" Src="Progress.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <pr:Progress runat="server" ID="ProgressInfo" pPageNo="1"   />

    <asp:SqlDataSource ID="rsQ" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
        ProviderName="<%$ ConnectionStrings:c7tudes.ProviderName %>" SelectCommand="SELECT [DemoNo] as QNo, ShowQNo_Self as ShowQNo, [Question], [IsRequired], [SortOrder], [SaveValue], [ShowValue] FROM [qryDemographics] WHERE (DemoNo in (1,5,6)) and  (([SurveyTypeID] = @SurveyTypeID) AND ([LanguageID] = @LanguageID)) ORDER BY [DemoNo], [SortOrder]">
        <SelectParameters>
            <asp:CookieParameter CookieName="SurveyTypeID" Name="SurveyTypeID" Type="Int16" DefaultValue="1" />
            <asp:CookieParameter CookieName="LanguageID" Name="LanguageID" Type="Int16" DefaultValue="1" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    <table cellpadding="20">
        <tr>
            <td>

            <asp:Label runat="server" ID="demog_heading" Text='<%$ Resources:LangText, demog_heading %>' Font-Bold="True" CssClass="pageheader"></asp:Label>
            <br />
            <br />
            <asp:Label runat="server" ID="demog_instr" ForeColor="red" Text='<%$ Resources:LangText, demog_instr %>'></asp:Label>
            <br />
            <br />
            <table runat="server" id="tabDemo" cellpadding="5" cellspacing="0" border="0">
    
            </table>
            <table cellpadding="5" cellspacing="0">
                <tr>
                    <td align="right">
                        <%--<asp:Label runat=server ID=demog_rptnote Text='<%$ Resources:LangText, demog_rptnote %>'></asp:Label><br /><br />--%>
                        <%-- <asp:Button runat="server" ID="btnPrev" CausesValidation="False" Text='<%$ Resources:Langtext, questions_btnprev CommandName="Prev" />--%>
                        <asp:Button runat="server" ID="btnNext" Text='<%$ Resources:Langtext, questions_btncomplete %>' CommandName="Next" CausesValidation="True" CssClass="btn btn-primary btn300" />
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary runat="server" ID="valsumm1" ShowMessageBox="True" ShowSummary="False" HeaderText='<%$ Resources:Langtext, demog_valsumm1 %>' EnableClientScript="True" />
            
            </td>
        </tr>
    </table>

</asp:Content>
