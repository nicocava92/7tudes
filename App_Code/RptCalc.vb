Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.IO

<WebService(Namespace:="http://EnergyProfile.perfprog.com/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Service
    Inherits System.Web.Services.WebService

    '<WebMethod()> _
    'Public Function HelloWorld() As String
    '    Return "Hello World aaa"
    'End Function

    <WebMethod()> _
    Public Function Results_Calc(ByVal PID As Long) As String
        CF.Runquery("Exec Results_Calc " & PID)
        Results_Calc = ""

    End Function
End Class
