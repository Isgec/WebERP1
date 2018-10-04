Partial Class RP_lgWTAttachment
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/LG_Main/App_Display/DF_lgWTAttachment.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?DocPK=" & aVal(0) & "&FilePK=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
		Dim DocPK As Int64 = CType(aVal(0),Int64)
		Dim FilePK As Int64 = CType(aVal(1),Int64)
		Dim oVar As SIS.LG.lgWTAttachment = SIS.LG.lgWTAttachment.lgWTAttachmentGetByID(DocPK,FilePK)
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
    oCol.Text = "FilePK"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.FilePK
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
    oCol.Text = "Created On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.CreatedOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Updated On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.UpdatedOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Title"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.Title
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Doc Type"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DocType
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Attachment"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.Attachment
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
    oCol.Text = "Element ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ElementID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Project Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ProjectDescription
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Element Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ElementDescription
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Disk File Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DiskFileName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Category"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.category
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "File Size"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.fileSize
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "File Number"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.FileNumber
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Path"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.path
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Downloaded File Location"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DownloadedFileLocation
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Downloaded File Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DownloadedFileName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    form1.Controls.Add(oTbl)
  End Sub
End Class
