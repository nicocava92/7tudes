<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Pyramid.ascx.vb" Inherits="Report_Pyramid3" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>
<asp:Label runat="server" ID="PID" Visible="False"></asp:Label>
<asp:SqlDataSource ID="rsData" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
    SelectCommandType="StoredProcedure" SelectCommand="ResultsCat_Get">
    <SelectParameters>
        <asp:ControlParameter ControlID="PID" Name="Pid" PropertyName="Text" Type="Int32" />
    </SelectParameters>
</asp:SqlDataSource>
<br />
<span class="heading2"><%--Overall Engagement Pyramid--%><asp:Label runat=server ID=pyr_heading></asp:Label></span>
<br />
<br />
<table style="width:720px;">
    <tr>
        <td valign="top" align="center">
            <chart:WebChartViewer runat="server" ID="pyr1" />
        </td>
        <td valign="top" align="center" runat="server" id="raters_pyr">
            <chart:WebChartViewer runat="server" ID="pyr9" />
        </td>
    </tr>
    <tr>
        <td align="center" class="heading2">
            <%--Self:--%>
            <asp:Label runat=server ID=label_self></asp:Label>
            <asp:Label runat="server" ID="SelfScore"></asp:Label></td>
        <td align="center" class="heading2" runat="server" id="raters_score">
            <%--Others:--%><asp:Label runat=server ID=label_others></asp:Label>
            <asp:Label runat="server" ID="OthersScore"></asp:Label></td>
    </tr>
</table>
<br />
<div class="heading4">
    <%--<asp:Label runat=server ID=pyrmaid_self1 Text="The above pyramid shows the breakdown of your Overall Engagement score."></asp:Label> 
<asp:Label runat=server ID=pyramid_3601 Text="The above pyramids show the breakdown of your Overall Engagement score."></asp:Label> 
--%>
    <asp:Label runat="server" ID="pyr_para1"></asp:Label>
    <%--<asp:Label runat=server ID=raters_text Text="The pyramid on the left is based on your answers and the pyramid on the right is a combined score of your raters' assessment of your overall engagement."></asp:Label>
--%>
    <br />
    <br />
    <%--Each dimension is shown in a different color. The numerical value of each dimension is 
listed to the left of the pyramid under that dimension name. The value shows your 
engagement in that dimension as a percentage. The volume of color in each dimension 
corresponds to the percentage of engagement given to the left of the pyramid.--%>
    <asp:Label runat="server" ID="pyr_para2"></asp:Label>
    <br />
    <br />
    <ul>
        <li>
            <%--<b>Fully Engaged (85% and above):</b> This suggests that your energy management skills are excellent. Your level of engagement is sufficient to fully ignite your talent and skill.--%>
            <asp:Label runat="server" ID="pyr_fullyengaged"></asp:Label>
        </li>
        <li>
            <%--<b>Engaged (70% to 84%):</b> This suggests that your energy management skills are high, but not sufficient to fully ignite your talent and skill. You must work to expand your level of engagement.
--%>
        <asp:Label runat="server" ID="pyr_engaged"></asp:Label>
        </li>
        <li>
            <%--<b>Disengaged (51% to 69%):</b> This suggests that significant obstacles stand in the way of fully igniting your talent and skill. To become an extraordinary performer, you must build significantly stronger
energy management skills.
--%>
        <asp:Label runat="server" ID="pyr_disengaged"></asp:Label></li>
        <li>
            <%--<b>Seriously Disengaged (50% and below):</b> Your level of disengagement not only significantly undermines your ability to fully ignite your talent and skill, but also prompts disengagement in others. When levels of disengagement such as this persist over time, your health, happiness and productivity can be seriously compromised.
--%>
        <asp:Label runat="server" ID="pyr_seriouslydisengaged"></asp:Label></li>
    </ul>
</div>
