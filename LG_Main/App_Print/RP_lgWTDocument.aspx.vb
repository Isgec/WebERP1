Partial Class RP_lgWTDocument
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/LG_Main/App_Display/DF_lgWTDocument.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?DocPK=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
		Dim DocPK As Int64 = CType(aVal(0),Int64)
		Dim oVar As SIS.LG.lgWTDocument = SIS.LG.lgWTDocument.lgWTDocumentGetByID(DocPK)
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
    oCol.Text = "Created On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.CreatedOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Updated On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.UpdatedOn
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
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    form1.Controls.Add(oTbl)
    Dim olgWTFiles As List(Of SIS.LG.lgWTFile) = SIS.LG.lgWTFile.UZ_lgWTFileSelectList(0, 999, "", False, "", DocPK)
    oTbl = New Table
    oTbl.GridLines = GridLines.Both
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "DocPK"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Document ID"
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
    For Each olgWTFile As SIS.LG.lgWTFile In olgWTFiles
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = olgWTFile.DocPK
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.LG_WTDocument2_DocumentID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.FilePK
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.DocumentID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.Revision
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.Iteration
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.Status
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.CreatedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.UpdatedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.Title
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.DocType
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.Attachment
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.ProjectID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.LG_Projects1_ProjectDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.ElementID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.ProjectDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.ElementDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.DiskFileName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.category
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.fileSize
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.FileNumber
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.path
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.DownloadedFileLocation
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTFile.DownloadedFileName
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
    Next
    form1.Controls.Add(oTbl)
    Dim olgWTAttachments As List(Of SIS.LG.lgWTAttachment) = SIS.LG.lgWTAttachment.UZ_lgWTAttachmentSelectList(0, 999, "", False, "", DocPK)
    oTbl = New Table
    oTbl.GridLines = GridLines.Both
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "DocPK"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Document ID"
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
    For Each olgWTAttachment As SIS.LG.lgWTAttachment In olgWTAttachments
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = olgWTAttachment.DocPK
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.LG_WTDocument2_DocumentID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.FilePK
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.DocumentID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.Revision
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.Iteration
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.Status
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.CreatedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.UpdatedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.Title
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.DocType
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.Attachment
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.ProjectID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.LG_Projects1_ProjectDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.ElementID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.ProjectDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.ElementDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.DiskFileName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.category
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.fileSize
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.FileNumber
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.path
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.DownloadedFileLocation
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttachment.DownloadedFileName
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
    Next
    form1.Controls.Add(oTbl)
    Dim olgWTAttributess As List(Of SIS.LG.lgWTAttributes) = SIS.LG.lgWTAttributes.UZ_lgWTAttributesSelectList(0, 999, "", False, "", DocPK)
    oTbl = New Table
    oTbl.GridLines = GridLines.Both
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "DocPK"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Document ID"
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
    For Each olgWTAttributes As SIS.LG.lgWTAttributes In olgWTAttributess
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = olgWTAttributes.DocPK
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttributes.LG_WTDocument1_DocumentID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttributes.displayName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttributes.DocumentID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttributes.Revision
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttributes.Iteration
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttributes.Status
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTAttributes.value
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
    Next
    form1.Controls.Add(oTbl)
    Dim olgWTDCRs As List(Of SIS.LG.lgWTDCR) = SIS.LG.lgWTDCR.UZ_lgWTDCRSelectList(0, 999, "", False, "", DocPK)
    oTbl = New Table
    oTbl.GridLines = GridLines.Both
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "DocPK"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Document ID"
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
    For Each olgWTDCR As SIS.LG.lgWTDCR In olgWTDCRs
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = olgWTDCR.DocPK
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTDCR.LG_WTDocument2_DocumentID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTDCR.DCRID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTDCR.DCRLine
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTDCR.DocumentID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTDCR.Revision
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTDCR.Iteration
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTDCR.Status
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTDCR.ProjectID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTDCR.LG_Projects1_ProjectDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTDCR.DCRDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTDCR.DCRCreatedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTDCR.DCRCategory
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTDCR.RequestPriority
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTDCR.ApprovalRequiredDate
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = olgWTDCR.DCRState
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
    Next
    form1.Controls.Add(oTbl)
  End Sub
End Class
