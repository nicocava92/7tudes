Imports System.Data


Partial Class Index
    Inherits System.Web.UI.Page

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim dv As DataView
        Me.Message.Text = ""
        dv = CType(Me.cAdmin.Select(DataSourceSelectArguments.Empty), DataView)
        If dv.Table.Rows.Count > 0 Then
            Response.Cookies("LanguageID").Value = dv.Table.Rows(0)("LanguageID")
            Response.Cookies("LanguageName").Value = dv.Table.Rows(0)("LanguageName")
            Response.Cookies("txtSearch").Value = "zz"
            Response.Redirect("Search.aspx")
        Else
            Me.Message.Text = "Invalid Login. Please try again."


        End If
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Response.Cookies("LanguageID").Value = ""
        End If

    End Sub
End Class
