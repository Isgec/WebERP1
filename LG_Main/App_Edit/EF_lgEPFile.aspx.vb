Partial Class EF_lgEPFile
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVlgEPFile_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgEPFile.Init
    DataClassName = "ElgEPFile"
    SetFormView = FVlgEPFile
  End Sub
  Protected Sub TBLlgEPFile_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgEPFile.Init
    SetToolBar = TBLlgEPFile
  End Sub
  Protected Sub FVlgEPFile_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgEPFile.PreRender
		TBLlgEPFile.PrintUrl &= Request.QueryString("DocPK") & "|"
		TBLlgEPFile.PrintUrl &= Request.QueryString("FilePK") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/LG_Main/App_Edit") & "/EF_lgEPFile.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptlgEPFile") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptlgEPFile", mStr)
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.LG.lgProjects.SelectlgProjectsAutoCompleteList(prefixText, count, contextKey)
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
