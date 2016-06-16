<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ExceptionTest.aspx.vb" Inherits="ExceptionTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>
        Exception Test
    </h1>

        <br />
        <br />


        <asp:Button ID="btnUnhandled" runat="server" Text="Generate Unhandled Exception (always fatal)" />

        <br />
        <br />
        <br />
        <br />

        <asp:Button ID="btnHandledFatal" runat="server" Text="Generate Fatal Handled Exception" />

        <br />
        <br />

        <asp:Button ID="btnHandledNonFatal" runat="server" Text="Generate Non-Fatal Handled Exception" />

        <br />
        <br />

        <asp:Button ID="btnLogEvent" runat="server" Text="Generate Non-Error Event" />

    
    </div>
    </form>
</body>
</html>
