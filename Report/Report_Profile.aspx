<%@ Page Language="VB" Trace="false" Debug="false" EnableViewState="False" MasterPageFile="~/Report/report.master"
    AutoEventWireup="false" CodeFile="Report_Profile.aspx.vb" Inherits="Report_Profile3"
    Title="Untitled Page" StylesheetTheme="Report" %>

<%@ Register TagName="bar" TagPrefix="uc" Src="Bars.ascx" %>
<%@ Register TagName="pyr" TagPrefix="uc" Src="Pyramid.ascx" %>
<%@ Register TagName="gap" TagPrefix="uc" Src="Gaps.ascx" %>
<%@ Register TagName="legend" TagPrefix="uc" Src="Legend_One.ascx" %>
<%@ Register TagName="scale" TagPrefix="uc" Src="Scale.ascx" %>
<%@ Register TagName="TOC" TagPrefix="uc" Src="TOC.ascx" %>
<%@ Register TagName="addlrscs" TagPrefix="uc" Src="AddlRscs.ascx" %>
<%@ Register TagName="reporttext" TagPrefix="uc" Src="Reporttext.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <asp:Panel runat="server" ID="pCover">
        <table border="0" bordercolor="red" height="1000" width="751" style="background-image: url('../images/Cover80.jpg')">
            <tr>
                <td valign="top" align="center">
                    <img runat="server" id="brandlogo" src="../images/hpilogo.jpg" visible="false" />
                </td>
            </tr>
            <tr>
                <td valign="bottom" style="padding-bottom: 170px; padding-left:115px;">
                    <asp:Label runat="server" ID="cover_reporttype" CssClass="heading1" ForeColor="White" Font-Bold="True"></asp:Label>
                    <div style="height: 10px;"></div>
                    <asp:Label runat="server" ID="cover_pname" CssClass="heading2" ForeColor="White" Font-Bold="true" Width="600"></asp:Label>
                    <div style="height: 5px;"></div>
                    <asp:Label runat="server" ID="cover_reportdate" CssClass="heading3" ForeColor="White" Font-Bold="True"></asp:Label>
                    <div style="height: 10px;"></div>
                    <asp:Label runat="server" ID="profile_allrights" ForeColor="White" Font-Size="Smaller"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    <asp:Panel runat="server" ID="pTOC">
        <div style="page-break-before:always">&nbsp;</div>
        
        <table width="100%" border="0" class="pageheading">
            <tr>
                <td valign="top" class="heading1">
                    <%--Table of Contents--%>
                    <asp:Label runat="server" ID="profile_toc"></asp:Label>
                </td>
                <td valign="top" align="right" class="pname">
                    <asp:Label runat="server" ID="PName" Text='<%# Eval("PName") %>'></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="ReportDate"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <uc:TOC runat="server" ID="TOC1" />
    </asp:Panel>
    
    <asp:Panel runat="server" ID="pRR1">
        <div style="page-break-before:always">&nbsp;</div>
        
        <table width="100%" border="0" class="pageheading">
            <tr>
                <td valign="top" class="heading1">
                    <%--Reading this Report--%>
                    <asp:Label runat="server" ID="profile_rr1"></asp:Label>
                </td>
                <td valign="top" align="right" class="pname">
                    <asp:Label runat="server" ID="Label8" Text='<%# Eval("PName") %>'></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="Label9"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <uc:reporttext runat="server" ID="reporttextA1" pSectionName="A1" />
    </asp:Panel>
    
    <asp:Panel runat="server" ID="pRR2">
        <div style="page-break-before:always">&nbsp;</div>
        
        <table width="100%" border="0" class="pageheading">
            <tr>
                <td valign="top" class="heading1">
                    <%--Reading this Report--%>
                    <asp:Label runat="server" ID="profile_rr2"></asp:Label>
                </td>
                <td valign="top" align="right" class="pname">
                    <asp:Label runat="server" ID="Label1" Text='<%# Eval("PName") %>'></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="Label4"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <uc:reporttext runat="server" ID="reporttextA2" pSectionName="A2" />
    </asp:Panel>
    
    <asp:Panel runat="server" ID="pRR3">
        <div style="page-break-before:always">&nbsp;</div>
        
        <table width="100%" border="0" class="pageheading">
            <tr>
                <td valign="top" class="heading1">
                    <%--Reading this Report--%>
                    <asp:Label runat="server" ID="profile_rr4"></asp:Label>
                </td>
                <td valign="top" align="right" class="pname">
                    <asp:Label runat="server" ID="Label5" Text='<%# Eval("PName") %>'></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="Label6"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <uc:reporttext runat="server" ID="reporttextB" pSectionName="B" />
    </asp:Panel>
    
    <asp:Panel runat="server" ID="pRR4">
        <div style="page-break-before:always">&nbsp;</div>
        
        <table width="100%" border="0" class="pageheading">
            <tr>
                <td valign="top" class="heading1">
                    <%--Reading this Report--%>
                    <asp:Label runat="server" ID="profile_rr3"></asp:Label>
                </td>
                <td valign="top" align="right" class="pname">
                    <asp:Label runat="server" ID="Label7" Text='<%# Eval("PName") %>'></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="Label16"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <uc:reporttext runat="server" ID="reporttextC1" pSectionName="C1" />
        <asp:Repeater runat="server" ID="tabTally" DataSourceID="rsPyr">
            <ItemTemplate>
                <td>
                    <asp:Label runat="server" ID="PID" Text='<%# Eval("PID") %>' Visible="False"></asp:Label>
                    <asp:Label runat="server" ID="PName" Text='<%# Eval("PName") %>' Visible="True"></asp:Label>
                    <asp:Label runat="server" ID="ReportDate" Text='<%# "<br>" & ReportDate_Get(Eval("ReportDate")) & "<br /><br />" %>'
                        Visible="True"></asp:Label>
                    <asp:SqlDataSource runat="server" ID="rsRels_Kids" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
                        SelectCommand="rptRelsKids_Get" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="PidList" QueryStringField="PIDList" Type="String" />
                            <asp:QueryStringParameter DefaultValue="1" Name="LanguageID" QueryStringField="LanguageID"
                                Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:GridView runat="server" ID="tabTally1" OnRowDataBound="tabTally1_Load" DataSourceID="rsRels_Kids"
                        ShowFooter="false" CellPadding="5" CellSpacing="0" HeaderStyle-CssClass="headrow"
                        AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="RelName" HeaderText="Relationship" HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="RelCount" HeaderText="Count" ItemStyle-HorizontalAlign="right"
                                HeaderStyle-HorizontalAlign="Right" />
                        </Columns>
                    </asp:GridView>
                    <asp:Label runat="server" ID="profile_recoded" Text="(*) Results for peers and direct reports were combined to ensure anonymity."
                        Visible="False"></asp:Label><br />
                </td>
                <td width="10">
                </td>
            </ItemTemplate>
        </asp:Repeater>
        <br />
        <uc:reporttext runat="server" ID="reporttextC2" pSectionName="C2" />
    </asp:Panel>
    
    <asp:Panel runat="server" ID="pPyr">
        <div style="page-break-before:always">&nbsp;</div>
        
        <asp:SqlDataSource ID="rsPyr" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
            SelectCommand="rptParticipants_Get" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter Name="PidList" QueryStringField="PIDList" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Repeater runat="server" ID="tabPyr" DataSourceID="rsPyr">
            <ItemTemplate>
                <asp:Label runat="server" ID="PID" Text='<%# Eval("PID") %>' Visible="False"></asp:Label>
                <table width="100%" border="0" class="pageheading">
                    <tr>
                        <td valign="top" class="heading1">
                            <%--Overview of Results--%>
                            <asp:Label runat="server" ID="profile_overviewofresults"></asp:Label>
                        </td>
                        <td valign="top" align="right" class="pname">
                            <asp:Label runat="server" ID="PName" Text='<%# Eval("PName") %>'></asp:Label>
                            <br />
                            <asp:Label runat="server" ID="ReportDate" Text='<%# ReportDate_Get(Eval("ReportDate")) %>'></asp:Label>
                        </td>
                    </tr>
                </table>
                <uc:pyr runat="server" ID="pyr1" pPID='<%# Eval("PID") %>'></uc:pyr>
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
    
    <asp:Panel runat="server" ID="pGaps_Overview">
        <div style="page-break-before:always">&nbsp;</div>
        
        <table width="100%" border="0" class="pageheading">
            <tr>
                <td valign="top" class="heading1">
                    <%--Overview of Results--%>
                    <asp:Label runat="server" ID="profile_overviewofresults2"></asp:Label>
                </td>
                <td valign="top" align="right" class="pname">
                    <asp:Label runat="server" ID="Label2" Text='<%# Eval("PName") %>'></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="Label3" Text='<%# ReportDate_Get(Eval("ReportDate")) %>'></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <span class="heading2">B.
            <%--Gap Analysis by Rater Group -- Overview--%><asp:Label runat="server" ID="profile_gapoverview"></asp:Label></span>
        <br />
        <br />
        <%--The Gap Analysis is intended to identify areas in which there are gaps or differences
        in how you see yourself and how others see you. The three largest factor gaps are
        indentified by rater category, or perspective group. This additional point of reference
        illustrates your strengths and challenges by that group.--%>
        <asp:Label runat="server" ID="profile_gap1"></asp:Label>
        <br />
        <br />
        <%--Negative gaps mean that you scored yourself higher than you were scored by others,
        while positive gaps meant that others scored you higher than you scored yourself.
        The more aligned your perceptions of yourself are to what others see, the healthier
        the overall solutions typically are. The larger the discrepancy, the more potentially
        dysfunctional the lack of alignment might be.--%>
        <asp:Label runat="server" ID="profile_gap2"></asp:Label>
        <br />
        <br />
        <%--Questions you can ask yourself to identify the reasons for the gaps are:--%>
        <asp:Label runat="server" ID="profile_gap3"></asp:Label>
        <ol>
            <li>
                <%--If you rated yourself higher than others, do you tend, as a rule, to overestimate
                your abilities and understate your weaknesses?--%>
                <asp:Label runat="server" ID="profile_gap4"></asp:Label></li>
            <li>
                <%--If you rated yourself lower than others, do you, as a general rule, possess a highly
                critical inner voice (self talk)? Are you overly hard on yourself? Do you have a
                strong need for perfectionism?--%>
                <asp:Label runat="server" ID="profile_gap5"></asp:Label></li>
        </ol>
    </asp:Panel>
    
    <asp:Panel runat="server" ID="pGaps">
        <asp:SqlDataSource runat="server" ID="rsRels" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
            SelectCommand="rptRels_Get" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter Name="PidList" QueryStringField="PIDList" Type="String" />
                <asp:QueryStringParameter DefaultValue="1" Name="LanguageID" QueryStringField="LanguageID"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Repeater runat="server" ID="tabRels" DataSourceID="rsRels">
            <ItemTemplate>
                <div style="page-break-before:always">&nbsp;</div>
                
                <asp:Label runat="server" ID="PID" Text='<%# Eval("PID") %>' Visible="False"></asp:Label>
                <table width="100%" border="0" class="pageheading">
                    <tr>
                        <td valign="top" class="heading1">
                            <%--Overview of Results--%>
                            <asp:Label runat="server" ID="profile_overviewofresults"></asp:Label>
                        </td>
                        <td valign="top" align="right" class="pname">
                            <asp:Label runat="server" ID="PName" Text='<%# Eval("PName") %>'></asp:Label>
                            <br />
                            <asp:Label runat="server" ID="ReportDate" Text='<%# ReportDate_Get(Eval("ReportDate")) %>'></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label runat="server" ID="RelName" Text='<%# "Gap Analysis -- " & Eval("RelName") %>'
                    CssClass="heading2"></asp:Label>
                <asp:Label runat="server" ID="profile_recoded_gaps" Visible="False" Font-Italic="True"></asp:Label>
                <br />
                <br />
                <uc:gap runat="server" ID="gap1" pPID='<%# Eval("PID") %>' pRelID='<%# Eval("RelID") %>'>
                </uc:gap>
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
    
    <asp:Panel runat="server" ID="pCategories_Overview">
        <div style="page-break-before:always">&nbsp;</div>
        
        <table width="100%" border="0" class="pageheading">
            <tr>
                <td valign="top" class="heading1">
                    <%--Overview of Results--%>
                    <asp:Label runat="server" ID="profile_overviewofresults4"></asp:Label>
                </td>
                <td valign="top" align="right" class="pname">
                    <asp:Label runat="server" ID="Label10" Text='<%# Eval("PName") %>'></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="Label11" Text='<%# ReportDate_Get(Eval("ReportDate")) %>'></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <uc:reporttext runat="server" ID="reporttextE" pSectionName="E" />
        <table id="Table1" cellpadding="0" cellspacing="0" runat="server" border="0">
            <tr>
                <td colspan="2">
                    <br />
                    <img runat="server" id="graph_static1" />
                </td>
            </tr>
            <tr>
                <td width="40">
                    <uc:legend runat="server" ID="legend1" pRelID="1" />
                </td>
                <td width="700">
                    <%--score based on your responses--%>
                    <asp:Label runat="server" ID="profile_selfscore1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="40">
                    <uc:legend runat="server" ID="legend6" pRelID="6" />
                </td>
                <td width="700">
                    <%--norm score--%>
                    <asp:Label runat="server" ID="profile_normscore1"></asp:Label>
                </td>
            </tr>
            <tr runat="server" id="legrow1_2">
                <td width="40">
                    <uc:legend runat="server" ID="legend2" pRelID="2" />
                </td>
                <td width="700">
                    <%--score based on Supervisor responses--%><asp:Label runat="server" ID="score1_2"></asp:Label>
                </td>
            </tr>
            <tr runat="server" id="legrow1_3">
                <td width="40">
                    <uc:legend runat="server" ID="legend3" pRelID="3" />
                </td>
                <td width="700">
                    <%--score based on Peer responses--%><asp:Label runat="server" ID="score1_3"></asp:Label>
                </td>
            </tr>
            <tr runat="server" id="legrow1_4">
                <td width="40">
                    <uc:legend runat="server" ID="legend4" pRelID="4" />
                </td>
                <td width="700">
                    <%--score based on Direct Report responses--%><asp:Label runat="server" ID="score1_4"></asp:Label>
                </td>
            </tr>
            <tr runat="server" id="legrow1_5">
                <td width="40">
                    <uc:legend runat="server" ID="legend5" pRelID="5" />
                </td>
                <td width="700">
                    <%--score based on Family member/Friend responses--%><asp:Label runat="server" ID="score1_5"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" runat="server" id="legrow1_6" style="padding-top: 10px;">
                    <i>
                        <%--Note: If a symbol does not appear in a graphic there were either no rater responses
                        in that perspective group or questions were not asked to that rater group. Some
                        questions were only asked of Family/Friends, therefore only a triangle will appear
                        on those items/questions.--%>
                        <asp:Label runat="server" ID="profile_symbols"></asp:Label></i>
                </td>
            </tr>
        </table>
        <uc:scale runat="server" ID="scale1" />
    </asp:Panel>
    
    <asp:Panel runat="server" ID="pCategories">
        <asp:SqlDataSource ID="rsCat" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
            SelectCommand="RptCategories_Get" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter Name="PidList" QueryStringField="PIDList" Type="String" />
                <asp:QueryStringParameter Name="LanguageID" QueryStringField="LanguageID" Type="Int16"
                    DefaultValue="1" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Repeater runat="server" ID="tabCat" DataSourceID="rsCat">
            <ItemTemplate>
                <div style="page-break-before:always">&nbsp;</div>
                
                <asp:Label runat="server" ID="CatNo" Text='<%# Eval("CatNo") %>' Visible="False"></asp:Label>
                <asp:Label runat="server" ID="PID" Text='<%# Eval("PID") %>' Visible="False"></asp:Label>
                <table width="100%" border="0" class="pageheading">
                    <tr>
                        <td valign="top" class="heading1">
                            <%--Overview of Results--%>
                            <asp:Label runat="server" ID="profile_overviewofresults"></asp:Label>
                        </td>
                        <td valign="top" align="right" class="pname">
                            <asp:Label runat="server" ID="PName" Text='<%# Eval("PName") %>'></asp:Label>
                            <br />
                            <asp:Label runat="server" ID="ReportDate" Text='<%# ReportDate_Get(Eval("ReportDate")) %>'></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label runat="server" ID="CatName" Text='<%# "Dimension Summary -- " & Eval("CatName") %>'
                    CssClass="heading2"></asp:Label>
                <br />
                <br />
                <div class="note">
                    <asp:Label runat="server" ID="CatDesc" Text='<%# Eval("CatDesc") %>'></asp:Label>
                </div>
                <br />
                <br />
                <uc:bar runat="server" ID="bars1" pPID='<%# Eval("PID") %>' pSrcName="ResultsDim_Get"
                    pPageNo='<%# Eval("CatNo") %>' pNormText='<%# ReportLabel_Get("profile_normscore") %>'>
                </uc:bar>
                <uc:scale runat="server" ID="scale1" />
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
    
    <asp:Panel runat="server" ID="pStressRecovery">
        <asp:SqlDataSource ID="rsSR" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
            SelectCommand="rptSRCategories_Get" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter Name="PidList" QueryStringField="PIDList" Type="String" />
                <asp:QueryStringParameter Name="LanguageID" QueryStringField="LanguageID" Type="Int16"
                    DefaultValue="1" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Repeater runat="server" ID="tabSR" DataSourceID="rsSR">
            <ItemTemplate>
                <div style="page-break-before:always">&nbsp;</div>
                
                <asp:Label runat="server" ID="SRCatNo" Text='<%# Eval("SRCatNo") %>' Visible="false"></asp:Label>
                <asp:Label runat="server" ID="PID" Text='<%# Eval("PID") %>' Visible="False"></asp:Label>
                <table width="100%" border="0" class="pageheading">
                    <tr>
                        <td valign="top" class="heading1">
                            <%--Overview of Results--%>
                            <asp:Label runat="server" ID="profile_overviewofresults"></asp:Label>
                        </td>
                        <td valign="top" align="right" class="pname">
                            <asp:Label runat="server" ID="PName" Text='<%# Eval("PName") %>'></asp:Label>
                            <br />
                            <asp:Label runat="server" ID="ReportDate" Text='<%# ReportDate_Get(Eval("ReportDate")) %>'></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <uc:reporttext runat="server" ID="reporttextF" pSectionName="F" pPID='<%# Eval("PID") %>' />
                <div class="note">
                    <asp:Label runat="server" ID="SRDesc" Text='<%# Eval("SRCatDesc") %>'></asp:Label>
                </div>
                <br />
                <br />
                <uc:bar runat="server" ID="bars1" pPID='<%# Eval("PID") %>' pSrcName="ResultsSR_Get"
                    pPageNo='<%# Eval("SRCatNo") %>' pNormText='<%# ReportLabel_Get("profile_normscore") %>'>
                </uc:bar>
                <uc:scale runat="server" ID="scale1" />
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
    
    <asp:Panel runat="server" ID="pDimensions_Overview">
        <div style="page-break-before:always">&nbsp;</div>
        
        <table width="100%" border="0" class="pageheading">
            <tr>
                <td valign="top" class="heading1">
                    <%--Feedback Detail--%>
                    <asp:Label runat="server" ID="profile_fd1"></asp:Label>
                </td>
                <td valign="top" align="right" class="pname">
                    <asp:Label runat="server" ID="Label12" Text='<%# Eval("PName") %>'></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="Label13" Text='<%# ReportDate_Get(Eval("ReportDate")) %>'></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <uc:reporttext runat="server" ID="reporttextD" pSectionName="D" />
        <table id="Table2" runat="server" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="2">
                    <br />
                    <img runat="server" id="graph_static2" />
                </td>
            </tr>
            <tr>
                <td width="40">
                    <uc:legend runat="server" ID="legend7" pRelID="1" />
                </td>
                <td width="700">
                    <%--score based on your responses--%><asp:Label runat="server" ID="profile_selfscore2"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="40">
                    <uc:legend runat="server" ID="legend8" pRelID="6" />
                </td>
                <td width="700">
                    <%--norm score--%><asp:Label runat="server" ID="profile_normscore2"></asp:Label>
                </td>
            </tr>
            <tr runat="server" id="legrow2_2">
                <td width="40">
                    <uc:legend runat="server" ID="legend9" pRelID="2" />
                </td>
                <td width="700">
                    <%--score based on Supervisor responses--%><asp:Label runat="server" ID="score2_2"></asp:Label>
                </td>
            </tr>
            <tr runat="server" id="legrow2_3">
                <td width="40">
                    <uc:legend runat="server" ID="legend10" pRelID="3" />
                </td>
                <td width="700">
                    <%--score based on Peer responses--%><asp:Label runat="server" ID="score2_3"></asp:Label>
                </td>
            </tr>
            <tr runat="server" id="legrow2_4">
                <td width="40">
                    <uc:legend runat="server" ID="legend11" pRelID="4" />
                </td>
                <td width="700">
                    <%--score based on Direct Report responses--%><asp:Label runat="server" ID="score2_4"></asp:Label>
                </td>
            </tr>
            <tr runat="server" id="legrow2_5">
                <td width="40">
                    <uc:legend runat="server" ID="legend12" pRelID="5" />
                </td>
                <td width="700">
                    <%--score based on Family member/Friend responses--%><asp:Label runat="server" ID="score2_5"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" runat="server" id="legrow2_6" style="padding-top: 10px;">
                    <i>
                        <%--Note: If a symbol does not appear in a graphic there were either no rater responses
                        in that perspective group or questions were not asked to that rater group. Some
                        questions were only asked of Family/Friends, therefore only a triangle will appear
                        on those items/questions.--%><asp:Label runat="server" ID="profile_symbols2"></asp:Label></i>
                </td>
            </tr>
        </table>
        <uc:scale runat="server" ID="scale2" />
    </asp:Panel>
    
    <asp:Panel runat="server" ID="pDimensions">
        <asp:SqlDataSource ID="rsDim" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
            SelectCommand="RptDimensions_Get" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter Name="PidList" QueryStringField="PIDList" Type="String" />
                <asp:QueryStringParameter Name="LanguageID" QueryStringField="LanguageID" Type="Int16"
                    DefaultValue="1" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Repeater runat="server" ID="tabDim" DataSourceID="rsDim">
            <ItemTemplate>
                <div style="page-break-before:always">&nbsp;</div>
                
                <asp:Label runat="server" ID="CatNo" Text='<%# Eval("CatNo") %>' Visible="False"></asp:Label>
                <asp:Label runat="server" ID="DimNo" Text='<%# Eval("DimNo") %>' Visible="False"></asp:Label>
                <asp:Label runat="server" ID="PID" Text='<%# Eval("PID") %>' Visible="False"></asp:Label>
                <table width="100%" border="0" class="pageheading">
                    <tr>
                        <td valign="top" class="heading1">
                            <%--Feedback Detail--%>
                            <asp:Label runat="server" ID="profile_fd1"></asp:Label>
                        </td>
                        <td valign="top" align="right" class="pname">
                            <asp:Label runat="server" ID="PName" Text='<%# Eval("PName") %>'></asp:Label>
                            <br />
                            <asp:Label runat="server" ID="ReportDate" Text='<%# ReportDate_Get(Eval("ReportDate")) %>'></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label runat="server" ID="CatName" Text='<%# Eval("CatName") %>' CssClass="heading2"></asp:Label>
                &#151
                <asp:Label runat="server" ID="DimName" Text='<%# Eval("DimName") %>' CssClass="heading2"></asp:Label>
                <br />
                <br />
                <div class="note">
                    <asp:Label runat="server" ID="DimDesc" Text='<%# Eval("DimDesc") %>'></asp:Label>
                </div>
                <br />
                <uc:bar runat="server" ID="bars1" pPID='<%# Eval("PID") %>' pSrcName="ResultsQ_Get"
                    pPageNo='<%# Eval("DimNo") %>' pNormText='<%# ReportLabel_Get("profile_normscore") %>'>
                </uc:bar>
                &nbsp;
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
    
    <asp:Panel runat="server" ID="pOEQ">
        <asp:SqlDataSource ID="rsCommentQ" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
            SelectCommand="rptOEQs_Get" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter Name="PidList" QueryStringField="PIDList" Type="String" />
                <asp:QueryStringParameter DefaultValue="1" Name="LanguageID" QueryStringField="LanguageID"
                    Type="Int16" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Repeater ID="tabCommentQ" runat="server" DataSourceID="rsCommentQ">
            <ItemTemplate>
                <asp:Panel runat="server" ID="QHeader">
                    <div style="page-break-before:always">&nbsp;</div>
                    
                    <table width="100%" border="0" class="pageheading">
                        <tr>
                            <td valign="top" class="heading1">
                                <%--Feedback Detail--%>
                                <asp:Label runat="server" ID="profile_fd1"></asp:Label>
                            </td>
                            <td valign="top" align="right" class="pname">
                                <asp:Label runat="server" ID="PName" Text='<%# Eval("PName") %>'></asp:Label>
                                <br />
                                <asp:Label runat="server" ID="ReportDate" Text='<%# ReportDate_Get(Eval("ReportDate")) %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <span class="heading2">B.
                        <%--Open-ended Questions--%>
                        <asp:Label runat="server" ID="profile_oeq"></asp:Label>
                    </span>
                    <br />
                    <br />
                    <div class="heading4">
                        <asp:Label runat="server" ID="PID" Text='<%# Eval("PID") %>' Visible="False"></asp:Label>
                        <asp:Label runat="server" ID="QNo" Text='<%# Eval("QNo") %>' Font-Bold="True"></asp:Label>.
                        <asp:Label runat="server" ID="Question" Text='<%# Eval("Question_Self") %>' Font-Bold="True"></asp:Label>
                    </div>
                    <br />
                </asp:Panel>
                <asp:Label runat="server" ID="RelID" Visible="false" Text='<%# Eval("RelID") %>'></asp:Label>
                <asp:Label runat="server" ID="RelName" Text='<%# Eval("Relname") %>' Font-Bold="True"></asp:Label>
                <asp:SqlDataSource ID="rsOEQResp" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
                    SelectCommand="rptOEQResp2_Get" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="PID" Name="PID" />
                        <asp:ControlParameter ControlID="RelID" Name="RelID" />
                        <asp:ControlParameter ControlID="QNo" Name="QNo" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:BulletedList runat="server" ID="Comments" DataSourceID="rsOEQResp" DataTextField="Comment">
                </asp:BulletedList>
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
    
    <asp:Panel runat="server" ID="pKid">
        <asp:SqlDataSource ID="rsParticipant" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
            SelectCommand="rptParticipants_Get" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter Name="PidList" QueryStringField="PIDList" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Repeater ID="tabParticipant" runat="server" DataSourceID="rsParticipant">
            <ItemTemplate>
                <div style="page-break-before:always">&nbsp;</div>
                
                <!-- Page Heading -->
                <table width="100%" border="0" class="pageheading">
                    <tr>
                        <td valign="top" class="heading1">
                            <%--Feedback Detail--%>
                            <asp:Label runat="server" ID="profile_fd1"></asp:Label>
                        </td>
                        <td valign="top" align="right" class="pname">
                            <asp:Label runat="server" ID="PName" Text='<%# Eval("PName") %>'></asp:Label>
                            <br />
                            <asp:Label runat="server" ID="ReportDate" Text='<%# ReportDate_Get(Eval("ReportDate")) %>'></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <span class="heading2">C.
                    <%--Children's Feedback--%>
                    <asp:Label runat="server" ID="profile_cf"></asp:Label></span>
                <br />
                <br />
                <asp:Label runat="server" ID="PID" Text='<%# Eval("PID") %>' Visible="False"></asp:Label>
                <asp:SqlDataSource runat="server" ID="rsQ" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
                    SelectCommand="SELECT [QNo], [Question], [Avg1], Iscomment, PID FROM [rptQuestions_Kid] WHERE ([PID] = @PID) and (LanguageID=@LanguageID) ORDER BY [QNo]">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="PID" Name="PID" Type="Int32" />
                        <asp:QueryStringParameter DefaultValue="1" Name="LanguageID" QueryStringField="LanguageID" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:GridView ID="tabQ" runat="server" DataSourceID="rsQ" AutoGenerateColumns="False"
                    ShowHeader="False" BorderStyle="None" GridLines="None" CellPadding="10" CellSpacing="0"
                    AlternatingRowStyle-CssClass="altrow" OnRowDataBound="tabQ_Load">
                    <Columns>
                        <asp:TemplateField ItemStyle-VerticalAlign="Top">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="QNo" Text='<%# Eval("QNo") & ". " %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="35" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Question" ItemStyle-Width="500" HeaderText="" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Avg1" ItemStyle-VerticalAlign="Top" ItemStyle-Width="55"
                            HeaderText="" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:0.00}" />
                    </Columns>
                </asp:GridView>
                <br />
                <!-- Comments -->
                <table cellpadding="10" cellspacing="0">
                    <asp:Repeater runat="server" ID="tabQ2" DataSourceID="rsQ" OnItemDataBound="tabQ2_Load">
                        <ItemTemplate>
                            <tr>
                                <td valign="top" width="35">
                                    <asp:Label runat="server" ID="QNo" Text='<%# Eval("QNo") %>'></asp:Label>
                                    <asp:Label runat="server" ID="PID" Text='<%# Eval("PID") %>' Visible="False"></asp:Label>
                                </td>
                                <td valign="top" width="550">
                                    <asp:Label runat="server" ID="Question" Text='<%# Eval("Question") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:SqlDataSource ID="rsResp" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
                                        SelectCommand="rptKidOEQResp_Get" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="PID" Name="PID" Type="Int32" />
                                            <asp:ControlParameter ControlID="QNo" Name="QNo" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:BulletedList runat="server" ID="Comment" DataSourceID="rsResp" DataTextField="Comment">
                                    </asp:BulletedList>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
    
   <asp:Panel runat="server" ID="pAudit">
        <asp:Repeater runat="server" ID="tabAuditMain" DataSourceID="rsParticipant">
            <ItemTemplate>
                <div style="page-break-before:always">&nbsp;</div>
                
                <table width="100%" border="0" class="pageheading">
                    <tr>
                        <td valign="top" class="heading1">
                            <%--Feedback Detail--%>
                            <asp:Label runat="server" ID="profile_fd1"></asp:Label>
                        </td>
                        <td valign="top" align="right" class="pname">
                            <asp:Label runat="server" ID="Label17" Text='<%# Eval("PName") %>'></asp:Label>
                            <br />
                            <asp:Label runat="server" ID="Label18" Text='<%#ReportDate_Get(Eval("ReportDate")) %>'></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <uc:reporttext runat="server" ID="reporttextG" pSectionName="G" pPID='<%# Eval("PID") %>' />
                <br />
                <asp:Label runat="server" ID="PID" Text='<%# Eval("PID") %>' Visible="False"></asp:Label>
                <%--<asp:SqlDataSource ID="rsAudit" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
                    SelectCommand="ResultsAudit_Get" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter Name="PIDList" Type="String" ControlID="PID" />
                        <asp:QueryStringParameter Name="LanguageID" Type="String" DefaultValue="1" QueryStringField="LanguageID" />
                    </SelectParameters>
                </asp:SqlDataSource>--%>
               <%-- <asp:GridView ID="tabAudit" runat="server" DataSourceID="rsAudit" GridLines="None"
                    BorderStyle="Solid" BorderWidth="1" CellPadding="10" CellSpacing="0" AutoGenerateColumns="false"
                    ShowHeader="False" AlternatingRowStyle-CssClass="altrow" OnRowDataBound="tabAudit_Load">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="Question" Text='<%# EVal("QNo") & ". " & Eval("Question") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="Resp"></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>--%>

                <uc:bar runat="server" ID="bars1" pPID='<%# Eval("PID") %>' pSrcName="ResultsAuditBars_Get"
                    pPageNo="1" pNormText='<%# ReportLabel_Get("profile_normscore") %>'>
                </uc:bar>
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
    <!-- Additional Resources -->
    <div style="page-break-before:always">&nbsp;</div>
    
    <table width="100%" border="0" class="pageheading">
        <tr>
            <td valign="top" class="heading1">
                <asp:Label runat="server" ID="profile_additionalresources"></asp:Label>
            </td>
            <td valign="top" align="right" class="pname">
                <asp:Label runat="server" ID="Label14" Text='<%# Eval("PName") %>'></asp:Label>
                <br />
                <asp:Label runat="server" ID="Label15" Text='<%# ReportDate_Get(Eval("ReportDate")) %>'></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <asp:Label runat="server" ID="profile_keytakeaways" CssClass="heading2"></asp:Label>
    <br />
    <br />
    <uc:addlrscs runat="server" ID="ar1" pLineCount="25" />
</asp:Content>
