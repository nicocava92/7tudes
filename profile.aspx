<%@ Page Title="" Language="VB" MasterPageFile="free.master" AutoEventWireup="false" Trace="false" StylesheetTheme="Freev2" CodeFile="profile.aspx.vb" Inherits="Free_profile" %>
<%@ Register TagName="Progress" TagPrefix="pr" Src="Progress.ascx" %>
<%@ Register TagPrefix="chart" Namespace="ChartDirector" Assembly="netchartdir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <pr:Progress runat="server" ID="ProgressInfo" pPageNo="1"   />

    <br />
    <asp:Label runat=server ID=Message CssClass="alert alert-success rounded" style="display:none;"></asp:Label>
    <asp:SqlDataSource runat="server" ID="cPersonal" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
                ProviderName="<%$ ConnectionStrings:c7tudes.ProviderName %>" SelectCommand="SELECT [DimNo], [DimName], [Norm1], [SelfScore], [ScoreVsTarget], [scoreclass] FROM [rptParticipantScores_Norms] WHERE ([PID] = @PID) ORDER BY [DimNo]">
        <SelectParameters>
            <asp:QueryStringParameter Name="PID" QueryStringField="PID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <table cellpadding="20">
        <tr>
            <td>
            <div style="width: 800px;text-align: center;">
                <table style="width: 800px;">
                    <tr>
                        <td width="500" align="left" valign="top" style="padding-top:20px; font-size:12pt;">
                            The spider graph provides a breakdown of your &#39;Tudes score by area. The shaded band represents what we call the "Proceed with Caution" area. Based on our research, companies who score outside (higher than) the band are typically successful in their initiative. Scores that land within the band point to potential trouble areas and are those most likely to benefit from using this diagnostic tool to address them prior to undertaking the initiative. 
                        </td>
                        <td width="300">
                            <chart:WebChartViewer ID="chartPersonal" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>

            <asp:GridView ID="tabPersonal" runat="server" AutoGenerateColumns="False" DataSourceID="cPersonal" Width="800" border="0" CellPadding="0" CellSpacing="0" BorderWidth="0" ShowHeader="True" ShowFooter="False">
                <Columns>

                    <asp:TemplateField ItemStyle-CssClass="resultsGrid">
                        <HeaderTemplate>
                        <table cellspacing="0" cellpadding="0" border="0" style="background-color: #e2e2e2;">
                            <td><asp:Label ID="tude" runat="server" Width="150" Font-Size="Medium" Font-Bold="True">'TUDE</asp:Label></td>
                            <td><asp:Label ID="score" runat="server" Width="145" Font-Size="Medium" Font-Bold="True" CssClass="centered">Score</asp:Label></td>
                            <td><asp:Label ID="target" runat="server" Width="145" Font-Size="Medium" Font-Bold="True" CssClass="centered">Target</asp:Label></td>
                            <td><asp:Label ID="gap" runat="server" Width="140" Font-Size="Medium" Font-Bold="True" CssClass="centered">Gap</asp:Label></td>
                            <td><asp:Label ID="gonogo" runat="server" Width="85" Font-Size="Medium" Font-Bold="True" CssClass="pull-right">Go / No Go</asp:Label></td>
                        </table>
                        </HeaderTemplate>
                         <ItemTemplate>
                        <table cellspacing="0" cellpadding="0" border="0">
                            <td><asp:Label runat="server" ID="DimName" Visible="True" Text='<%# Eval("DimName")%>' Width="140" Font-Size="Medium" Font-Bold="True"></asp:Label></td>
                            <td><asp:Label runat="server" ID="SelfScore" Visible="True" Text='<%# Eval("SelfScore")%>' Width="140" Font-Size="Medium" CssClass="centered"></asp:Label></td>
                            <td><asp:Label runat="server" ID="Norm1" Visible="True" Text='<%# Eval("Norm1")%>' Width="140" Font-Size="Medium" CssClass="centered"></asp:Label></td>
                            <td><asp:Label runat="server" ID="ScoreVsTarget" Text='<%# Eval("ScoreVsTarget")%>' Width="140" Font-Size="Medium" CssClass="centered"></asp:Label></td>
                            <td runat="server" ID="scoreclass" class='<%# Eval("scoreclass")%>'>&nbsp;</td>
                        </table>
                        <asp:Label runat="server" ID="DimNo" Visible="False" Text='<%# Eval("DimNo")%>'></asp:Label>
                        </ItemTemplate>
                </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <table style="width: 800px;">
                <tr>
                    <td width="400">
                        <table border="0" class="table" style="width: 400px; font-size:11pt;">
                          <tr>
                            <th scope="row" class="centered" style="font-size:12pt;background-color: #e2e2e2;">> 3.9</th>
                            <td style="font-size:12pt;">Full Steam Ahead</td>
                            <td class="fullsteamahead">&nbsp;</td>
                          </tr>
                          <tr>
                            <th scope="row" class="centered" style="font-size:12pt;background-color: #e2e2e2;">3.5 - 3.9</th>
                            <td style="font-size:12pt;">Proceed with Caution</td>
                            <td class="caution">&nbsp;</td>
                          </tr>
                          <tr>
                            <th scope="row" class="centered" style="font-size:12pt;background-color: #e2e2e2;">3.2 - 3.5</th>
                            <td style="font-size:12pt;">Regroup and Reassess</td>
                            <td class="regroup">&nbsp;</td>
                          </tr>
                          <tr>
                            <th scope="row" class="centered" style="font-size:12pt;background-color: #e2e2e2;">< 3.2</th>
                            <td style="font-size:12pt;">Do Not Pursue</td>
                            <td class="donotpursue">&nbsp;</td>
                          </tr>
                        </table>
                    </td>
                    <td width="300" align="center" valign="top">
                        <table border="0" style="width:205px; height:157px;">
                          <tr>
                            <td runat="server" ID="AvgScoreClass" style="text-align: center;  background-image: url('images/result_background_white.png'); z-index:1000;background-repeat: no-repeat;">
                                <asp:Label runat="server" ID="Percent" Visible="True" Text='' Font-Bold="True" ForeColor="White" Font-Size="30"></asp:Label><br />
                                <asp:Label runat="server" ID="AvgScore" Visible="True" Text='' Font-Size="Small" Font-Bold="True" ForeColor="White"></asp:Label>
                            </td>
                          </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <b>For more information visit </b><a href="http://www.seventudes.com" target="_blank">www.seventudes.com</a>.

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
