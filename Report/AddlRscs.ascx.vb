
Partial Class Report_AddlRscs2
    Inherits System.Web.UI.UserControl

    Public Property pLineCount() As Integer
        Get
            Return Me.LineCount.Text
        End Get

        Set(ByVal Value As Integer)
            Me.LineCount.Text = Value
        End Set
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim hr1 As HtmlGenericControl, i1 As Integer

        For i1 = 1 To Me.LineCount.Text
            hr1 = New HtmlGenericControl
            Me.p1.Controls.Add(hr1)
            hr1.InnerHtml = "<hr><br>"
        Next

    End Sub
End Class
