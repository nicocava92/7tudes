<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Gaps.ascx.vb" Inherits="Report_Gaps3" %>
<%@ Register Assembly="netchartdir" Namespace="ChartDirector" TagPrefix="chart" %>
<asp:Label runat=server ID=PID Visible=False></asp:Label>
<asp:Label runat=server ID=RelID Visible=False ForeColor=Red></asp:Label>
<asp:Label runat=server ID=noresponses Visible=False ForeColor=Red></asp:Label>
<asp:Label runat=server ID=gaps_dimension Visible=False Text=D1></asp:Label>
<asp:Label runat=server ID=gaps_factor Visible=False Text=D2></asp:Label>
<asp:Label runat=server ID=gaps_selfscore Visible=False Text=D3></asp:Label>
<asp:Label runat=server ID=gaps_raterscore Visible=False Text=D4></asp:Label>
<asp:Label runat=server ID=gaps_gap Visible=False Text=D5></asp:Label>


<asp:SqlDataSource ID="rsGaps" runat="server" ConnectionString="<%$ ConnectionStrings:c7tudes %>"
        SelectCommand="Gaps_Get" SelectCommandType="StoredProcedure">
        <SelectParameters>
               <asp:ControlParameter ControlID="PID" Name="Pid" PropertyName="Text" Type="Int32" />
            <asp:ControlParameter ControlID="RelID" Name="RelID" Type="Int32" />
            <asp:QueryStringParameter Name="LanguageID" QueryStringField="LanguageID" Type="String" DefaultValue="0" />
        </SelectParameters>
    </asp:SqlDataSource>        
<asp:GridView runat=server ID=tabGaps AutoGenerateColumns=False CellPadding=7 ShowHeader=True DataSourceID=rsGaps>
<Columns>
<%--<asp:TemplateField ItemStyle-Width=270 HeaderText="Category">
<ItemTemplate>
<asp:Label runat=server ID=CatName Text='<%# Eval("CatName") %>' Font-Bold=True></asp:Label><br />
<asp:Label runat=server ID=DimName Text='<%# Eval("DimName") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>--%>
<asp:BoundField DataField=CatName HeaderText="Dimension" />
<asp:BoundField DataField=DimName HeaderText="Factor" />

<asp:BoundField DataField=SelfAvg ItemStyle-Width=35 HeaderText="Self Score" ItemStyle-HorizontalAlign=Right  />
<asp:BoundField DataField=RaterAvg ItemStyle-Width=35 HeaderText="Rater Score"  ItemStyle-HorizontalAlign=Right  />
<asp:BoundField DataField=Gap ItemStyle-Width=55 HeaderText="Gap"  ItemStyle-HorizontalAlign=Right  />
<%--<asp:TemplateField HeaderText="Discrepancy">
    <ItemTemplate>

<chart:WebChartViewer ID="chart1" runat="server" />
    </ItemTemplate>
    <ItemStyle VerticalAlign="Top" Width="410px" />
</asp:TemplateField>--%>
</Columns>
<AlternatingRowStyle CssClass="altrow" />
<HeaderStyle CssClass="headrow" />
<EmptyDataTemplate>
<i><%--No responses provided.--%><asp:Label runat=server ID=noresponses></asp:Label></i>
</EmptyDataTemplate>
</asp:GridView>
<br /><br />
<b><%--Three Largest Gaps--%><asp:Label runat=server ID=largestgaps></asp:Label> </b>
<br /><br />
<asp:GridView runat=server ID=tabHighest AutoGenerateColumns=False HeaderStyle-CssClass="headrow" CellPadding=5 CellSpacing=0>
<Columns>
<asp:BoundField DataField="CatName" HeaderText="Dimension" />
<asp:BoundField DataField="DimName" HeaderText="Factor" />
<asp:BoundField DataField="Gap" HeaderText="Gap" ItemStyle-Width="55" ItemStyle-HorizontalAlign="right"  />
</Columns>
<EmptyDataTemplate>
<i><%--No responses provided.--%><asp:Label runat=server ID=noresponses></asp:Label></i>
</EmptyDataTemplate>

</asp:GridView>