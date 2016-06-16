<%@ Application Language="VB" %>

<%@ Import namespace="PPIExceptionHelper" %>

<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        Dim objEx As Exception = Server.GetLastError()
        
        If Not IsNothing(objEx) Then
            PPIExceptionTools.HandleUnhandledException(objEx)
        Else
            objEx = New ApplicationException("Application_Error event: An unknown error occurred.")
            PPIExceptionTools.HandleUnhandledException(objEx)
        End If
                
        'be sure to clear error
        Try
            Server.ClearError()
        Catch
        End Try
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        
        
    End Sub
       
</script>