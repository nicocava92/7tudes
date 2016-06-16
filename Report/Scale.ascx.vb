
Partial Class Report_Scale2
    Inherits System.Web.UI.UserControl

    Function fsHtml(ByVal s1 As String) As String
        fsHtml = Replace(s1, "<br>", " ")
    End Function

    Protected Sub tabScale_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles tabScale.ItemDataBound
        If e.Item.ItemIndex = 0 Then
            Me.profile_scaleheading.Text = e.Item.DataItem("profile_scaleheading")
        End If
    End Sub
End Class
