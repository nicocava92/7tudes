<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PPIGeneralError.aspx.vb" Inherits="PPIGeneralError" %>

<%@ Register Src="~/Controls/PageBanner.ascx" TagPrefix="uc1" TagName="PageBanner" %>
<%@ Register Src="~/Controls/GA.ascx" TagPrefix="uc1" TagName="GA" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>General Site Error</title>
        <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7; IE=EDGE; chrome=1">
    <style type="text/css">
	html, body{
      font-family: Arial,Verdana,sans-serif;
      line-height:22px;
      background-color:#F2F2F2;
    }
     #header {
        background-color:#ffffff;
	    height:100px;
    }
    #section {
        margin:50px;
    }
    .content {
        margin-left: auto;
        margin-right: auto;
        width: 40%;
        color:#000;
    }
    </style>
</head>
<body>
    <uc1:PageBanner runat="server" ID="PageBanner" />

    <form id="form1" runat="server">
    <div id="header">
           <div class="content">
            <img runat="server" id="brandlogo" src="images/hpilogo.jpg" style="margin-top:10px;"/>
           </div>
    </div>
    <div id="section">
        <div class="content" style="margin-top:50px;">
        <asp:Label runat="server" ID="show_error_message"></asp:Label>
        </div>
    </div>
    </form>

</body>
</html>
