Imports System.Xml
Imports System.Xml.Schema
Imports System.IO

Partial Class Lang_Resx_Import
    Inherits System.Web.UI.Page


    Sub Resx_Read(ByVal sXMLFileName As String)
        Dim doc As New XmlDocument, root As XmlNode
        Dim datalist As XmlNodeList, node1 As XmlNode
        Dim sSql As String, i1 As Integer, sText As String

        doc.Load(sXMLFileName)


        root = doc.DocumentElement
        datalist = root.SelectNodes("/root/data")
        i1 = 0
        For Each node1 In datalist
            If node1.Name = "data" Then
                i1 = i1 + 1
                Trace.Warn(node1.Attributes("name").Value)
                Trace.Warn(node1.ChildNodes(1).InnerText)
                sText = node1.ChildNodes(1).InnerText
                sSql = "Insert into resx(LanguageID, KeyName, KeyValue) Select 1 "
                sSql = sSql & ", '" & node1.Attributes("name").Value & "'"
                sSql = sSql & ", '" & Replace(sText, "'", "''") & "'"
                Trace.Warn(sSql)
                CF.Runquery(sSql)
            End If
        Next
    End Sub

    Protected Sub btnRead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRead.Click
        Resx_Read(Server.MapPath("../App_GlobalResources/LangText.resx"))
    End Sub

    Protected Sub btnWrite_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnWrite.Click
        Dim dv As System.Data.DataView, sLangInit As String
        Dim sSrcFileName As String, sDestFileName As String


        dv = CF.DataView_Get("Select LangInit from Languages where LanguageID=" & Request.Cookies("LanguageID").Value)
        sLangInit = dv.Table.Rows(0)("LangInit")
        sSrcFileName = Server.MapPath("../App_GlobalResources/LangText_empty.txt")


        sDestFileName = Server.MapPath("../App_GlobalResources/LangText-" & sLangInit & ".txt")

        'Save old file (if it exists) under another name
        If File.Exists(sDestFileName) Then System.IO.File.Copy(sDestFileName, fsNext(sDestFileName))
        System.IO.File.Copy(sSrcFileName, sDestFileName, True)

        Resx_Write(sDestFileName)
    End Sub

    Sub Resx_Write(ByVal sDestFileName As String)
        Dim f1 As System.IO.StreamWriter, dv As System.Data.DataView
        Dim i1 As Integer, sText As String

        f1 = System.IO.File.AppendText(sDestFileName)
        dv = CF.DataView_Get("Select KeyName, KeyValue from Resx where LanguageID=" & Request.Cookies("LanguageID").Value & " order by AutoID")
        '  <data name="welcome_selfoeq" xml:space="preserve">
        '<value>At the end you will be asked to write in answers to a few open-ended questions.</value>
        '</data>

        For i1 = 0 To dv.Table.Rows.Count - 1
            sText = "<data name=" & Chr(34) & dv.Table.Rows(i1)("KeyName") & Chr(34)
            sText = sText & " xml:space=""preserve"">"
            f1.WriteLine(sText)
            Trace.Warn(sText)

            sText = "<value>" & Server.HtmlEncode(CF.NullToString(dv.Table.Rows(i1)("KeyValue"))) & "</value>"
            f1.WriteLine(sText)
            Trace.Warn(sText)

            f1.WriteLine("</data>")

        Next
        f1.WriteLine("</root>")
        f1.Close()
    End Sub

    Function fsNext(ByVal sFileName As String)
        Dim i1 As Integer

        i1 = 1
        While File.Exists(sFileName & "." & i1)
            i1 = i1 + 1
        End While
        fsNext = sFileName & "." & i1
    End Function
End Class
