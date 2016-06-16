
Partial Class Lang_Export
    Inherits System.Web.UI.Page
    Dim sSql As String, sConn As String, sCols As String, sFileName As String
    Dim sFrom As String, sTo As String
    Dim cmdl As New System.Data.OleDb.OleDbCommand
    Dim c1 As System.Data.OleDb.OleDbConnection

    Dim dv1 As System.Data.DataView, col1 As System.Data.DataColumn, row1 As System.Data.DataRow

    Protected Sub btnExport_Click(sender As Object, e As System.EventArgs) Handles btnExport.Click
        'Create file and delete if it exists
        sFileName = "downloads\Translations_" & Request.Cookies("LanguageName").Value & ".xls"
        sFileName = Server.MapPath(sFileName)
        Trace.Warn(sFileName)
        If CF.FileExists(sFileName) Then CF.File_Delete(sFileName)

        'open connection
        sConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & sFileName & ";Extended Properties='Excel 8.0'"
        c1 = New System.Data.OleDb.OleDbConnection(sConn)
        c1.Open()

        'add sheets
        Sheet_Add("Categories")
        Sheet_Add("Demographics")
        Sheet_Add("DemoValues")
        Sheet_Add("Dimensions")
        Sheet_Add("Emails")
        Sheet_Add("Emails_Service")

        Sheet_Add("Questions")
        Sheet_Add("Questions_Audit")
        Sheet_Add("Questions_Comment")
        Sheet_Add("Questions_Health")
        Sheet_Add("Questions_Health_Scale")
        Sheet_Add("Questions_Kid")
        Sheet_Add("Questions_ST_1")
        Sheet_Add("Questions_ST_2")

        Sheet_Add("Rels")
        Sheet_Add("ReportLabels")
        Sheet_Add("ReportText")
        Sheet_Add("ReportText_ST")
        Sheet_Add("Resx")

        Sheet_Add("Scale")
        Sheet_Add("SRCategories")
        Sheet_Add("SRDimensions")
        Sheet_Add("ST_ReportSections")
        Sheet_Add("ST_ReportText_Q22")
        Sheet_Add("SurveyTypes")

        Sheet_Add("TableOfContents")

        'Close conn
        cmdl.Dispose()
        c1.Close()

        'Send file
        System.Web.HttpContext.Current.Response.Clear()
        System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" & CF.JustFileName(sFileName))
        System.Web.HttpContext.Current.Response.ContentType = "application/vnd.xls"
        System.Web.HttpContext.Current.Response.WriteFile(sFileName)

        System.Web.HttpContext.Current.Response.End()
    End Sub




    Sub Sheet_Add(sName As String)
        dv1 = CF.DataView_Get("Select * from Lang_" & sName & " where LanguageID=" & Request.Cookies("LanguageID").Value)
        cmdl.Connection = c1

        'Create empty sheet
        sCols = ""
        For Each col1 In dv1.Table.Columns
            sCols = sCols & ", " & col1.ColumnName & " text"
        Next
        sCols = Mid(sCols, 2)

        sSql = "CREATE TABLE " & sName & "(" & sCols & ")"
        Trace.Warn(sSql)
        cmdl.CommandText = sSql
        cmdl.ExecuteNonQuery()

        'Append rows
        For Each row1 In dv1.Table.Rows
            sTo = ""
            sFrom = ""
            For Each col1 In dv1.Table.Columns
                sTo = sTo & ", " & col1.ColumnName
                sFrom = sFrom & ", '" & Replace(CF.NullToString(row1(col1.ColumnName)), "'", "''") & "'"
            Next
            sSql = "Insert into " & sName & "(" & Mid(sTo, 2) & ") Select " & Mid(sFrom, 2)
            Trace.Warn(sSql)
            cmdl.CommandText = sSql
            cmdl.ExecuteNonQuery()
        Next

    End Sub


End Class
