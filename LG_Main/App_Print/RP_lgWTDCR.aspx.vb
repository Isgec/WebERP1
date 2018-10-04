Partial Class RP_lgWTDCR
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/LG_Main/App_Display/DF_lgWTDCR.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?DocPK=" & aVal(0) & "&DCRID=" & aVal(1) & "&DCRLine=" & aVal(2)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
		Dim DocPK As Int64 = CType(aVal(0),Int64)
		Dim DCRID As String = CType(aVal(1),String)
		Dim DCRLine As Int32 = CType(aVal(2),Int32)
		Dim oVar As SIS.LG.lgWTDCR = SIS.LG.lgWTDCR.lgWTDCRGetByID(DocPK,DCRID,DCRLine)
    Dim oTbl As New Table
    oTbl.Width = 1000
    Dim oCol As TableCell = Nothing
    Dim oRow As TableRow = Nothing
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "DocPK"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DocPK
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.LG_WTDocument2_DocumentID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "DCR ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DCRID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "DCR Line"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DCRLine
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Document ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DocumentID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Revision"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.Revision
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Iteration"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.Iteration
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Status"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.Status
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Project ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ProjectID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.LG_Projects1_ProjectDescription
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "DCR Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DCRDescription
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "DCR Created On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DCRCreatedOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "DCR Category"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DCRCategory
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Request Priority"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.RequestPriority
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Approval Required Date"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ApprovalRequiredDate
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "DCR State"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DCRState
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    form1.Controls.Add(oTbl)
  End Sub
End Class
