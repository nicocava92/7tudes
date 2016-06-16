
Partial Class Survey_Self_SurveyA
    Inherits Baseclass 'System.Web.UI.Page
    Dim dvQ As System.Data.DataView, dvResp As System.Data.DataView
    Dim drResp As System.Data.DataRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Demographics_Load()
           
        End If
    End Sub


    Sub Demographics_Load()
        Dim i1 As Integer
        Dim dd1 As DropDownList, li1 As ListItem
        Dim tr As HtmlTableRow, tc As HtmlTableCell
        Dim val1 As RequiredFieldValidator
        Dim sClassName As String


        Dim iQNo As Integer
        dvQ = Me.rsQ.Select(DataSourceSelectArguments.Empty)

        'Load Responses
        Responses_Load()

        'dvResp = Me.rsR.Select(DataSourceSelectArguments.Empty)
        iQNo = 0
        sClassName = ""
        For i1 = 0 To dvQ.Table.Rows.Count - 1
            If dvQ.Table.Rows(i1)("Qno") <> iQNo Then

                If sClassName = "" Then
                    sClassName = "altrow"
                Else
                    sClassName = ""
                End If

                'Start new demographic
                tr = New HtmlTableRow
                Me.tabDemo.Rows.Add(tr)
                tr.Attributes.Add("class", sClassName)

                'tc = New HtmlTableCell
                'tr.Cells.Add(tc)
                'tc.Align = "right"
                'tc.VAlign = "top"
                'tc.InnerText = dvQ.Table.Rows(i1)("ShowQNo") & ". "

                tc = New HtmlTableCell
                tr.Cells.Add(tc)
                tc.InnerText = dvQ.Table.Rows(i1)("Question")
                tc.Align = "Left"
                If dvQ.Table.Rows(i1)("Isrequired") Then
                    tc.Attributes.Add("class", "reqd")
                Else

                End If
                'tc.Width = 400
                tc.VAlign = "top"

                tc = New HtmlTableCell
                tr.Cells.Add(tc)
                tc.Align = "Left"
                dd1 = New DropDownList
                tc.Controls.Add(dd1)
                dd1.ID = "D" & dvQ.Table.Rows(i1)("Qno")
                dd1.EnableViewState = False

                'Add Choose one
                li1 = New ListItem
                dd1.Items.Add(li1)
                li1.Text = Resources.Langtext.demog_chooseone
                li1.Value = ""


                'Add ValidationControl to a new cell
                tc = New HtmlTableCell
                tr.Cells.Add(tc)
                tc.Width = 10
                If dvQ.Table.Rows(i1)("IsRequired") Then
                    val1 = New RequiredFieldValidator
                    tc.Controls.Add(val1)
                    val1.ID = "V" & dvQ.Table.Rows(i1)("Qno")
                    val1.ControlToValidate = dd1.ID
                    val1.Text = "&nbsp; *"
                    val1.ErrorMessage = dvQ.Table.Rows(i1)("Question")
                    'val1.ValidationGroup = "valsumm1"
                Else
                    tc.InnerHtml = "&nbsp;"
                End If


            End If

            iQNo = dvQ.Table.Rows(i1)("Qno")


            'Add list item to the current drop-down
            li1 = New ListItem
            li1.Text = dvQ.Table.Rows(i1)("ShowValue")
            li1.Value = dvQ.Table.Rows(i1)("SaveValue")

            If CF.NullToString(dvResp.Table.Rows(0)("D" & iQNo)) <> "" Then
                If CF.NullToString(dvResp.Table.Rows(0)("D" & iQNo)) = li1.Value Then
                    li1.Selected = True
                End If
            End If
            dd1.Items.Add(li1)

        Next

    End Sub

    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Responses_Save()
        Response.Redirect("Profile.aspx?PID=" & Request.Cookies("PID").Value)
    End Sub

    

    Protected Sub Responses_Save()
        'Save Data
        Dim item As String, sFieldName As String, sSql As String

        sSql = "DateCompleted=getDate()"
        For Each item In Request.Form
            sFieldName = Replace(item, "ctl00$ContentPlaceHolder1$", "")
            Trace.Warn(sFieldName & "=" & Request.Form(item))

            If Left(sFieldName, 1) = "D" Then
                If Request.Form(item) = "" Then
                    sSql = sSql & ", " & sFieldName & "=Null"
                Else
                    sSql = sSql & ", " & sFieldName & "=" & Request.Form(item)
                End If
            End If
        Next

        'tempPID is available because Results are calculated in the Questions page
        sSql = "Update Responses Set " & sSql & " where RespID=(select Top 1 RespID from Responses where tempPID='" & Request.Cookies("PID").Value & "')"
        Trace.Warn(sSql)
        CF.Runquery(sSql)


      
    End Sub

    Sub Responses_Load()
        Dim sSql As String, i1 As Integer

        sSql = "RespID"
        For i1 = 1 To 11
            sSql = sSql & ", D" & i1
        Next

        sSql = "Select " & sSql & " from Responses where RespID=(select Top 1 RespID from Responses where tempPID='" & Request.Cookies("PID").Value & "')"
        dvResp = CF.DataView_Get(sSql)
    End Sub

End Class

'To do
' DONE 1. Show Responses
' DONE 2. Save Responses