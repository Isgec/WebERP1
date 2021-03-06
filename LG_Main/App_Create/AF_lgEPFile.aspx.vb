Partial Class AF_lgEPFile
  Inherits SIS.SYS.InsertBase
  Protected Sub FVlgEPFile_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgEPFile.Init
    DataClassName = "AlgEPFile"
    SetFormView = FVlgEPFile
  End Sub
  Protected Sub TBLlgEPFile_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgEPFile.Init
    SetToolBar = TBLlgEPFile
  End Sub
  Protected Sub FVlgEPFile_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgEPFile.PreRender
    Dim oF_DocPK_Display As Label  = FVlgEPFile.FindControl("F_DocPK_Display")
    oF_DocPK_Display.Text = String.Empty
    If Not Session("F_DocPK_Display") Is Nothing Then
      If Session("F_DocPK_Display") <> String.Empty Then
        oF_DocPK_Display.Text = Session("F_DocPK_Display")
      End If
    End If
    Dim oF_DocPK As TextBox  = FVlgEPFile.FindControl("F_DocPK")
    oF_DocPK.Enabled = True
    oF_DocPK.Text = String.Empty
    If Not Session("F_DocPK") Is Nothing Then
      If Session("F_DocPK") <> String.Empty Then
        oF_DocPK.Text = Session("F_DocPK")
      End If
    End If
    Dim oF_ProjectID_Display As Label  = FVlgEPFile.FindControl("F_ProjectID_Display")
    Dim oF_ProjectID As TextBox  = FVlgEPFile.FindControl("F_ProjectID")
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/LG_Main/App_Create") & "/AF_lgEPFile.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptlgEPFile") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptlgEPFile", mStr)
    End If
    If Request.QueryString("DocPK") IsNot Nothing Then
      CType(FVlgEPFile.FindControl("F_DocPK"), TextBox).Text = Request.QueryString("DocPK")
      CType(FVlgEPFile.FindControl("F_DocPK"), TextBox).Enabled = False
    End If
    If Request.QueryString("FilePK") IsNot Nothing Then
      CType(FVlgEPFile.FindControl("F_FilePK"), TextBox).Text = Request.QueryString("FilePK")
      CType(FVlgEPFile.FindControl("F_FilePK"), TextBox).Enabled = False
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function DocPKCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.LG.lgEPDocument.SelectlgEPDocumentAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.LG.lgProjects.SelectlgProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_LG_EPFile_DocPK(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim DocPK As Int64 = CType(aVal(1),Int64)
		Dim oVar As SIS.LG.lgEPDocument = SIS.LG.lgEPDocument.lgEPDocumentGetByID(DocPK)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_LG_EPFile_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim ProjectID As String = CType(aVal(1),String)
		Dim oVar As SIS.LG.lgProjects = SIS.LG.lgProjects.lgProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
