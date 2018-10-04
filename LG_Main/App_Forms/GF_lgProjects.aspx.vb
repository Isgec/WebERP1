Partial Class GF_lgProjects
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/LG_Main/App_Display/DF_lgProjects.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ProjectID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVlgProjects_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVlgProjects.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim ProjectID As String = GVlgProjects.DataKeys(e.CommandArgument).Values("ProjectID")  
				Dim RedirectUrl As String = TBLlgProjects.EditUrl & "?ProjectID=" & ProjectID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVlgProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVlgProjects.Init
    DataClassName = "GlgProjects"
    SetGridView = GVlgProjects
  End Sub
  Protected Sub TBLlgProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgProjects.Init
    SetToolBar = TBLlgProjects
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
