
Partial Class Survey_Progress
    Inherits System.Web.UI.UserControl

    Public Property pPageNo() As Integer
        Get
            Return Me.MyPageNo.Text
        End Get
        Set(ByVal value As Integer)
            Me.MyPageNo.Text = value
        End Set
    End Property

    Public Property pMaxPageNo() As Integer
        Get
            Return Me.MyMaxPageNo.Text
        End Get
        Set(ByVal value As Integer)
            Me.MyMaxPageNo.Text = value
        End Set
    End Property


    'Function fsPageXofY(ByVal iThis As Integer, ByVal iMax As Integer)
    '    'fsPageXofY = "(" & Resources.Langtext.pagexofy
    '    fsPageXofY = Resources.Langtext.pagexofy
    '    fsPageXofY = Replace(fsPageXofY, Chr(34) & "xx" & Chr(34), iThis)
    '    fsPageXofY = Replace(fsPageXofY, Chr(34) & "yy" & Chr(34), iMax)
    '    fsPageXofY = fsPageXofY
    '    'fsPageXofY = fsPageXofY & ")"

    'End Function


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Trace.Warn("Progress prerender")

        'Manage the background
        Dim sPageName As String, i1 As Integer

        sPageName = LCase(Request.ServerVariables("SCRIPT_NAME"))
        Trace.Warn(sPageName)
        'If Request.Cookies("RelID").Value = 1 Then
        'For i1 = 0 To 3
        'Me.row1.Cells(i1).Attributes.Add("class", "progress_offpage")
        Me.step1.Attributes.Add("class", "off")
        Me.step2.Attributes.Add("class", "off")
        Me.step3.Attributes.Add("class", "off")
        Me.step4.Attributes.Add("class", "off")
        'Next()
        'Else
        'For i1 = 1 To 4
        '    If i1 <= 2 Then
        '        'Me.row1.Cells(i1).Attributes.Add("class", "progress_offpage")
        '        Me.step1.Attributes.Add("class", "off")
        '        Me.step2.Attributes.Add("class", "off")
        '    Else
        '        'Me.row1.Cells(i1).Attributes.Add("class", "hide")
        '        Me.step3.Attributes.Add("class", "hide")
        '        Me.step4.Attributes.Add("class", "hide")
        '    End If
        'Next
        'End If


        If InStr(sPageName, "_profile") > 0 Then
            'Me.row1.Cells(0).Attributes.Add("class", "progress_currentpage")
            'Me.Pagexofy.Text = fsPageXofY(Me.MyPageNo.Text, Me.MyMaxPageNo.Text)
            Me.step1.Attributes.Add("class", "active")
            'Me.Pagexofy.Text = fsPageXofY(Me.MyPageNo.Text, Me.MyMaxPageNo.Text)
        ElseIf InStr(sPageName, "questions") > 0 Then
            'Me.row1.Cells(1).Attributes.Add("class", "progress_currentpage")
            'Me.row1.Cells(0).Attributes.Add("class", "progress_pastpage")
            Me.step2.Attributes.Add("class", "active")
            Me.step1.Attributes.Add("class", "past")
        ElseIf InStr(sPageName, "demographics") > 0 Then
            'Me.row1.Cells(2).Attributes.Add("class", "progress_currentpage")
            'Me.row1.Cells(0).Attributes.Add("class", "progress_pastpage")
            'Me.row1.Cells(1).Attributes.Add("class", "progress_pastpage")
            Me.step3.Attributes.Add("class", "active")
            Me.step1.Attributes.Add("class", "past")
            Me.step2.Attributes.Add("class", "past")
        ElseIf InStr(sPageName, "profile") > 0 Then
            'Me.row1.Cells(3).Attributes.Add("class", "progress_currentpage")
            'Me.row1.Cells(0).Attributes.Add("class", "progress_pastpage")
            'Me.row1.Cells(1).Attributes.Add("class", "progress_pastpage")
            'Me.row1.Cells(2).Attributes.Add("class", "progress_pastpage")
            Me.step4.Attributes.Add("class", "active")
            Me.step1.Attributes.Add("class", "past")
            Me.step2.Attributes.Add("class", "past")
            Me.step3.Attributes.Add("class", "past")
        Else
            Me.step1.Attributes.Add("class", "active")
        End If

        'Links_Load()

    End Sub

    Sub Links_Load()
        'Make progress bar cells selectively clickable
        Dim dvResp As System.Data.DataView, sSql As String

        'Progress link controlling QNos
        sSql = "IsNull(Q1, 0) as HasRatings, Case When C1 is null then 0 else 1 end as HasComments, IsNull(A1, 0) as HasAudit, IsNull(D1, 0) as HasDemographics "

        'Put it all together
        sSql = "Select " & sSql & " from Responses where RespID=" & Request.Cookies("RespID").Value
        Trace.Warn(sSql)
        dvResp = CF.DataView_Get(sSql)


        Me.hlRatings.Enabled = dvResp.Table.Rows(0)("HasRatings") > 0
        Me.hlComments.Enabled = dvResp.Table.Rows(0)("HasComments") > 0
        Me.hlAudit.Enabled = dvResp.Table.Rows(0)("HasAudit") > 0
        Me.hlDemographics.Enabled = dvResp.Table.Rows(0)("HasDemographics") > 0

    End Sub


End Class
