
Partial Class Free_Default
    Inherits System.Web.UI.Page

    Protected Sub btnStart_Click(sender As Object, e As System.EventArgs) Handles btnStart.Click
        Response.Redirect("Questions1.aspx")
    End Sub

    Protected Sub btnAbout_Click(sender As Object, e As System.EventArgs) Handles btnAbout.Click
        Response.Redirect("AboutSevenTudes.aspx")
    End Sub

End Class
