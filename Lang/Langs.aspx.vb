
Partial Class Lang_Langs
    Inherits System.Web.UI.Page

    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        If Me.NewLanguageName.Text = "" Then Exit Sub

        Me.rsLang.InsertParameters("LanguageName").DefaultValue = Me.NewLanguageName.Text
        Me.rsLang.Insert()

        'Create Language containers
        LanguageData_Create(Me.NewLanguageName.Text)
        Me.NewLanguageName.Text = ""
    End Sub


    Sub LanguageData_Create(ByVal sLangName As String)
        Dim dv As System.Data.DataView, iLangID As Integer

        dv = CF.DataView_Get("Select Max(LanguageID) as NewLanguageID from Languages where LanguageName='" & Replace(sLangName, "'", "''") & "'")

        iLangID = dv.Table.Rows(0)(0)

        '''''''''''''''''''''''''''''''''''''''''''
        ' Insert stored procedure calls here 
        '''''''''''''''''''''''''''''''''''''''''''
    End Sub

End Class
