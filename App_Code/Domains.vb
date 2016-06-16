Imports Microsoft.VisualBasic

Public Class Domains
    Public Shared Sub DomainsList_Set()
        Dim dvD As System.Data.DataView
        dvD = CF.DataView_Get("Select DomainName from EmailDomains order by DomainName")
        HttpRuntime.Cache("dvD") = dvD
        HttpRuntime.Cache("dvDTimeStamp") = Now().ToString
        System.Web.HttpContext.Current.Trace.Warn("DomainsList Set. Count=" & dvD.Table.Rows.Count)
    End Sub

    Public Shared Function DomainsList_Get() As System.Data.DataView
        If HttpRuntime.Cache("dvD") Is Nothing Then
            DomainsList_Set()
        End If

        DomainsList_Get = HttpRuntime.Cache("dvD")
    End Function

    Public Shared Function DomainsTimestamp_Get() As String
        If HttpRuntime.Cache("dvD") Is Nothing Then
            DomainsList_Set()
        End If
        DomainsTimestamp_Get = HttpRuntime.Cache("dvDTimeStamp")
    End Function
End Class
