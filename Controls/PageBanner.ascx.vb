
Partial Class Controls_PageBanner
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If not running on PROD show banner
        If ConfigurationManager.AppSettings("prod_computername") <> "" Then
            If Not UCase(My.Computer.Name) = UCase(ConfigurationManager.AppSettings("prod_computername")) Then
                parBanner.Visible = True
                lblBanner.Text = My.Computer.Name
            End If
        End If

    End Sub

End Class
