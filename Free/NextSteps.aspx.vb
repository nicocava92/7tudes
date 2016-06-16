
Partial Class Free_Actions
    Inherits System.Web.UI.Page

    Protected Sub btnContactInfo_Click(sender As Object, e As System.EventArgs) Handles btnContactInfo.Click
        Dim sSql As String, T1 As TextBox, i1 As Integer
        Dim sActions As String
        sActions = ""
        For i1 = 0 To Me.chk1.Items.Count - 1
            If chk1.Items(i1).Selected Then
                Trace.Warn(Me.chk1.Items(i1).Text)
                sActions &= ", " & Me.chk1.Items(i1).Text
            End If
        Next
        If sActions <> "" Then sActions = Mid(sActions, 2)

        sSql = "Update Participants Set "
        sSql = sSql & " Firstname='" & Replace(Me.FirstName.Text, "'", "''") & "'"
        sSql = sSql & ", Lastname='" & Replace(Me.LastName.Text, "'", "''") & "'"
        sSql = sSql & ", EmailAddress='" & Replace(Me.EmailAddress.Text, "'", "''") & "'"

        sSql = sSql & ", PhoneNum='" & Replace(Me.PhoneNum.Text, "'", "''") & "'"
        sSql = sSql & ", ContactType='" & Replace(Me.ContactType.SelectedValue, "'", "''") & "'"
        sSql = sSql & ", ContactTime='" & Replace(Me.ContactTime.SelectedValue, "'", "''") & "'"
        sSql = sSql & ", InfoType='" & Replace(sActions, "'", "''") & "'"

        sSql = sSql & " where PID='" & Request.QueryString("PID") & "'"
        Trace.Warn(sSql)
        CF.Runquery(sSql)

        'Send email to whom?
        CF.Email_Send(ConfigurationManager.AppSettings("sender"), "info@hpinstitute.com", "", "Free Profile Contact Request", fsMessage(sActions))

        Me.Message.Text = "Thank you. We will be in touch with you very soon."
    End Sub

    Function fsMessage(sActions As String) As String
        fsMessage = "<table cellpadding=4 cellspacing=0>"
        fsMessage &= tr_append("FirstName", Me.FirstName.Text)
        fsMessage &= tr_append("LastName", Me.LastName.Text)
        fsMessage &= tr_append("EmailAddress", Me.EmailAddress.Text)
        fsMessage &= tr_append("PhoneNum", Me.PhoneNum.Text)
        fsMessage &= tr_append("ContactType", Me.ContactType.SelectedValue)
        fsMessage &= tr_append("ContactTime", Me.ContactTime.SelectedValue)
        fsMessage &= tr_append("Info Type", sActions)
        fsMessage &= "</table>"
    End Function

    Function tr_append(sFieldName As String, sValue As String) As String
        tr_append = "<tr>"
        tr_append &= "<td valign=top>" & sFieldName & "</td>"
        tr_append &= "<td valign=top>" & sValue & "</td>"
        tr_append &= "</tr>"
    End Function
End Class
