<%@ Page Title="Welcome to the Seven Tudes Assessment" Language="VB" MasterPageFile="free.master" Trace="False" AutoEventWireup="false" CodeFile="AboutSevenTudes.aspx.vb" Inherits="Free_About7Tudes" StylesheetTheme="Freev2" %>
<%@ Register TagName=Progress TagPrefix=pr Src="Progress.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <pr:Progress runat=server ID=ProgressInfo pPageNo=1   /> 

    <table cellpadding="20">
        <tr>
            <td>
            <h3>About the Seven Tudes Survey:</h3>
                <table style="width:800px">
                    <tr>
                        <td><img src="images/sample_tables.JPG" /></td>
                        <td><img src="images/sample_graph.JPG" /></td>
                    </tr>
                </table>
                <br />
                <p>The spider graph provides a breakdown of your &#39;Tudes score by area. The shaded band represents what we call the "Proceed with Caution" area. Based on our research, companies who score outside (higher than) the band are typically successful in their initiative. Scores that land within the band point to potential trouble areas and are those most likely to benefit from using this diagnostic tool to address them prior to undertaking the initiative.</p>
                <p>If your experience does not conform to our overall results as described above and you would like to share your insights, please feel free to contact us at <a href="mailto:">surveys@perfprog.com</a>. We’d love to hear from you. </p>
                <p>
                    <br />
                    <iframe width="560" height="315" src="https://www.youtube.com/embed/7iniCFDJQO0" frameborder="0" allowfullscreen></iframe>
                </p>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <h3>Predictive Power:</h3>
                <p>Now that you understand the methodology, you may want to use the survey as a diagnostic tool for an international expansion initiative you are currently undertaking or are planning.</p>
                <div class="well">

                <strong><i>If you would like to improve the likelihood of success, ask yourself some questions about the ‘tudes in your organization:</i></strong>
                    <br /><br />
                <ul>
                    <li>Atti<b>tude</b> — Does your company or division place a priority on global business expansion?</li>
                    <li>Apti<b>tude</b> — Do you have the right experiential resources to succeed abroad?</li>
                    <li>Magni<b>tude</b> — Do you have the ability to align the scale and scope of the overseas opportunity with your company's goals and capabilities? </li>
                    <li>Lati<b>tude</b> — Is there a willingness to adapt company policies and practices to the opportunity?</li>
                    <li>Recti<b>tude</b> — Are you prepared to work within the legal and ethical practices required for market success, while maintaining corporate compliance?</li>
                    <li>Exacti<b>tude</b> — Does your corporate culture tolerate ambiguity and uncertainty both with and without "the numbers"?</li>
                    <li>Forti<b>tude</b> — Is there a corporate commitment to global initiatives in general, even in the face of setbacks?</li>
                </ul>

                </div>
                <p>If you’re not convinced that the answer to each of the questions is a robust “Yes” or you’re unsure that your colleagues are all on board or you just believe your organization 
                    could benefit from identifying potential pitfalls, you can use the 'Tudes diagnostic pack.
                    <%--<br /><br />
                    <asp:Button runat="server" ID="btnLearn" Text="Learn more here" CssClass="btn btn-primary btn300" />  --%> 
                    <br /><br />
                    Submit your group pack and we will score it and return it to you along with some possible corrective actions to consider before you undertake the next initiative.</p>
                <br />
                <asp:Button runat="server" ID="btnStart" Text="Take the Seven Tudes Survey Now" CssClass="btn btn-primary btn300" />
                <br /><br />
            </td>
        </tr>
    </table>

</asp:Content>
