Partial Class RP_lgWTAttributes
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/LG_Main/App_Display/DF_lgWTAttributes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?DocPK=" & aVal(0) & "&displayName=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
		Dim DocPK As Int64 = CType(aVal(0),Int64)
		Dim displayName As String = CType(aVal(1),String)
		Dim oVar As SIS.LG.lgWTAttributes = SIS.LG.lgWTAttributes.lgWTAttributesGetByID(DocPK,displayName)
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
    oCol.Text = oVar.LG_WTDocument1_DocumentID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Attribute Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.displayName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Document ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DocumentID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Revision"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.Revision
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Iteration"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.Iteration
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Status"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.Status
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Value"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.value
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    form1.Controls.Add(oTbl)
  End Sub
End Class
