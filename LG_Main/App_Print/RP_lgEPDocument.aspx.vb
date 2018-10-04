Partial Class RP_lgEPDocument
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/LG_Main/App_Display/DF_lgEPDocument.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?DocPK=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
		Dim DocPK As Int64 = CType(aVal(0),Int64)
		Dim oVar As SIS.LG.lgEPDocument = SIS.LG.lgEPDocument.lgEPDocumentGetByID(DocPK)
    Dim oTbl As New Table
    oTbl.Width = 1000
    Dim oCol As TableCell = Nothing
    Dim oRow As TableRow = Nothing
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Doc PK"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DocPK
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Document Number"
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
    oCol.Text = "Title"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.Title
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
    oCol.Text = "Doc Type"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DocType
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
    form1.Controls.Add(oTbl)
    Dim olgEPFiles As List(Of SIS.LG.lgEPFile) = SIS.LG.lgEPFile.UZ_lgEPFileSelectList(0, 999, "", False, "", DocPK)
    oTbl = New Table
    oTbl.GridLines = GridLines.Both
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "DocPK"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Document Number"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "FilePK"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Document ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Revision"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Iteration"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Status"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Created On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Updated On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Title"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Doc Type"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Attachment"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Project ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Project Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Element ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Project Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Element Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Disk File Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Category"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "File Size"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "File Number"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Path"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Downloaded File Location"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Downloaded File Name"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    For Each olgEPFile As SIS.LG.lgEPFile In olgEPFiles
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = olgEPFile.DocPK
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.LG_EPDocument1_DocumentID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.FilePK
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.DocumentID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.Revision
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.Iteration
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.Status
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.CreatedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.UpdatedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.Title
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.DocType
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.Attachment
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.ProjectID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.LG_Projects2_ProjectDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.ElementID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.ProjectDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.ElementDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.DiskFileName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.category
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.fileSize
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.FileNumber
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.path
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.DownloadedFileLocation
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPFile.DownloadedFileName
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
    Next
    form1.Controls.Add(oTbl)
    Dim olgEPAttachments As List(Of SIS.LG.lgEPAttachment) = SIS.LG.lgEPAttachment.UZ_lgEPAttachmentSelectList(0, 999, "", False, "", DocPK)
    oTbl = New Table
    oTbl.GridLines = GridLines.Both
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "DocPK"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Document Number"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "FilePK"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Document ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Revision"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Iteration"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Status"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Created On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Updated On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Title"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "DocType"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Attachment"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Project ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Project Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Element ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Project Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Element Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Disk File Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Category"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "File Size"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "File Number"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Path"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Downloaded File Location"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Downloaded File Name"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    For Each olgEPAttachment As SIS.LG.lgEPAttachment In olgEPAttachments
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = olgEPAttachment.DocPK
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.LG_EPDocument1_DocumentID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.FilePK
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.DocumentID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.Revision
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.Iteration
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.Status
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.CreatedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.UpdatedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.Title
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.DocType
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.Attachment
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.ProjectID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.LG_Projects2_ProjectDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.ElementID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.ProjectDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.ElementDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.DiskFileName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.category
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.fileSize
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.FileNumber
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.path
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.DownloadedFileLocation
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttachment.DownloadedFileName
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
    Next
    form1.Controls.Add(oTbl)
    Dim olgEPAttributess As List(Of SIS.LG.lgEPAttributes) = SIS.LG.lgEPAttributes.UZ_lgEPAttributesSelectList(0, 999, "", False, "", DocPK)
    oTbl = New Table
    oTbl.GridLines = GridLines.Both
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "DocPK"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Document Number"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Attribute Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Document ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Revision"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Iteration"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Status"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Value"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    For Each olgEPAttributes As SIS.LG.lgEPAttributes In olgEPAttributess
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = olgEPAttributes.DocPK
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttributes.LG_EPDocument1_DocumentID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttributes.displayName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttributes.DocumentID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttributes.Revision
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttributes.Iteration
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttributes.Status
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPAttributes.value
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
    Next
    form1.Controls.Add(oTbl)
    Dim olgEPDCRs As List(Of SIS.LG.lgEPDCR) = SIS.LG.lgEPDCR.UZ_lgEPDCRSelectList(0, 999, "", False, "", DocPK)
    oTbl = New Table
    oTbl.GridLines = GridLines.Both
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "DocPK"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Document Number"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "DCR ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "DCR Line"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Document ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Revision"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Iteration"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Status"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Project ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Project Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "DCR Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "DCR Created On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "DCR Category"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Request Priority"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Approval Required Date"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "DCR State"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    For Each olgEPDCR As SIS.LG.lgEPDCR In olgEPDCRs
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = olgEPDCR.DocPK
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPDCR.LG_EPDocument1_DocumentID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPDCR.DCRID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPDCR.DCRLine
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPDCR.DocumentID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPDCR.Revision
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPDCR.Iteration
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPDCR.Status
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPDCR.ProjectID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPDCR.LG_Projects2_ProjectDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPDCR.DCRDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPDCR.DCRCreatedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPDCR.DCRCategory
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPDCR.RequestPriority
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPDCR.ApprovalRequiredDate
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgEPDCR.DCRState
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
    Next
    form1.Controls.Add(oTbl)
  End Sub
End Class
