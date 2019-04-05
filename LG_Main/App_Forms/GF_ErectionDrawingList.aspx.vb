Partial Class GF_ErectionDrawingList
	Inherits SIS.SYS.GridBase

  Private Sub GVerpEvaluateByIT_Init(sender As Object, e As EventArgs) Handles GVerpEvaluateByIT.Init
    DataClassName = "GerpEvaluateByIT"
    SetGridView = GVerpEvaluateByIT
  End Sub

  Private Sub TBLerpEvaluateByIT_Init(sender As Object, e As EventArgs) Handles TBLerpEvaluateByIT.Init
    SetToolBar = TBLerpEvaluateByIT
  End Sub
End Class
