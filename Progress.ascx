<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Progress.ascx.vb" Inherits="Survey_Progress" %>

<asp:TextBox runat=server ID=MyPageNo Visible=False></asp:TextBox>
<asp:TextBox runat=server ID=MyMaxPageNo Visible=False></asp:TextBox>

<div class="row">
    <ul class="breadcrumb1">
        <li width="200" runat=server id="step1"><asp:HyperLink runat=server ID=hlRatings Text='Introduction' NavigateURL=""></asp:HyperLink> </li>
        <li width="200" runat=server id="step2"><asp:HyperLink runat=server ID=hlComments Text='Questionnaire' NavigateUrl="" ></asp:HyperLink></li>
        <li width="200" runat=server id="step3"><asp:HyperLink runat=server ID=hlAudit Text='Demographics' NavigateUrl="" ></asp:HyperLink></li>
        <li width="200" runat=server id="step4"><asp:HyperLink runat=server ID=hlDemographics Text='Results' NavigateUrl=""  ></asp:HyperLink></li>
    </ul>
</div>


  