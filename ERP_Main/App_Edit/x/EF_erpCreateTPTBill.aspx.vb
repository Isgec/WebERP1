Imports System.Web.Script.Serialization
Partial Class EF_erpCreateTPTBillx
  Inherits SIS.SYS.UpdateBase


  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Dim oTmp As SIS.ERP.erpCreateTPTBill = Nothing
  Protected Sub ODSerpCreateTPTBill_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSerpCreateTPTBill.Selected
    oTmp = CType(e.ReturnValue, SIS.ERP.erpCreateTPTBill)
    PrimaryKey = oTmp.PrimaryKey
  End Sub
  Protected Sub FVerpCreateTPTBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpCreateTPTBill.Init
    DataClassName = "EerpCreateTPTBill"
    SetFormView = FVerpCreateTPTBill
  End Sub
  Protected Sub TBLerpCreateTPTBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpCreateTPTBill.Init
    SetToolBar = TBLerpCreateTPTBill
  End Sub
  Protected Sub FVerpCreateTPTBill_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpCreateTPTBill.PreRender
    TBLerpCreateTPTBill.EnableDelete = False
    Dim BillType As String = "Freight And Detention Separate Bills"
    Select Case BillType
      Case "Freight And Detention Separate Bills"
        FVerpCreateTPTBill.FindControl("trDet7").Visible = True
        FVerpCreateTPTBill.FindControl("tblFreight").Visible = True
        FVerpCreateTPTBill.FindControl("tblDetention").Visible = True
        CType(FVerpCreateTPTBill.FindControl("D_GRNos"), TextBox).Text = CType(FVerpCreateTPTBill.FindControl("F_GRNos"), TextBox).Text
    End Select
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Create") & "/AF_erpCreateTPTBill.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpCreateTPTBill") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpCreateTPTBill", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVerpCreateTPTBill.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVerpCreateTPTBill.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub

  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function TPTCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrTransporters.SelectvrTransportersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function DiscReturnedToByACCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_ERP_TransporterBill_DiscReturnedToByAc(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim DiscReturnedToByAC As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(DiscReturnedToByAC)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_ERP_TransporterBill_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_ERP_TransporterBill_TPTCode(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim TPTCode As String = CType(aVal(1), String)
    Dim oVar As SIS.VR.vrTransporters = SIS.VR.vrTransporters.vrTransportersGetByID(TPTCode)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function CreatedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_ERP_TransporterBill_CreatedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim CreatedBy As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(CreatedBy)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function getIRData(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim IRNo As String = aVal(1)
    Dim tmp As SIS.ERP.erpCreateTPTBill = Nothing
    Dim mRet As String = "0|" & aVal(0)
    Try
      tmp = SIS.ERP.erpCreateTPTBill.getIRData(IRNo)
      mRet = New JavaScriptSerializer().Serialize(New With {
        .err = False,
        .msg = "",
        .tgt = aVal(0),
        .irdata = New With {
          .TPTBillNo = tmp.TPTBillNo,
          .TPTBillDate = tmp.TPTBillDate,
          .GRNos = tmp.GRNos,
          .TPTCode = tmp.TPTCode,
          .PONumber = tmp.PONumber,
          .ProjectID = tmp.ProjectID,
          .TPTBillAmount = tmp.TPTBillAmount,
          .TPTBillReceivedOn = tmp.TPTBillReceivedOn,
          .AssessableValue = tmp.AssessableValue,
          .IGSTRate = tmp.IGSTRate,
          .IGSTAmount = tmp.IGSTAmount,
          .CGSTRate = tmp.CGSTRate,
          .CGSTAmount = tmp.CGSTAmount,
          .SGSTRate = tmp.SGSTRate,
          .SGSTAmount = tmp.SGSTAmount,
          .CessRate = tmp.CessRate,
          .CessAmount = tmp.CessAmount,
          .TotalGST = tmp.TotalGST,
          .TotalAmount = tmp.TotalAmount
          }
        })
    Catch ex As Exception
      mRet = New JavaScriptSerializer().Serialize(New With {
        .err = True,
        .msg = ex.Message,
        .tgt = aVal(0)
        })
    End Try
    Return mRet
  End Function

  Private Sub FVerpCreateTPTBill_ItemUpdating(sender As Object, e As FormViewUpdateEventArgs) Handles FVerpCreateTPTBill.ItemUpdating
    Dim BillType As String = "Freight And Detention Separate Bills"
    Select Case BillType
      Case "Freight And Detention Separate Bills"
        Dim F_IRNumber As TextBox = FVerpCreateTPTBill.FindControl("F_IRNumber")
        Dim D_IRNumber As TextBox = FVerpCreateTPTBill.FindControl("D_IRNumber")
        Dim F_TPTCode As TextBox = FVerpCreateTPTBill.FindControl("F_TPTCode")
        Dim D_TPTCode As TextBox = FVerpCreateTPTBill.FindControl("D_TPTCode")
        Dim F_PONumber As TextBox = FVerpCreateTPTBill.FindControl("F_PONumber")
        Dim D_PONumber As TextBox = FVerpCreateTPTBill.FindControl("D_PONumber")
        Dim F_ProjectID As TextBox = FVerpCreateTPTBill.FindControl("F_ProjectID")
        Dim D_ProjectID As TextBox = FVerpCreateTPTBill.FindControl("D_ProjectID")
        If F_IRNumber.Text = D_IRNumber.Text Then
          ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Freight and Detention IR No. must be different.") & "');", True)
          e.Cancel = True
          Exit Sub
        End If
        If D_IRNumber.Text = "" Then
          ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Detention IR No. must be filled.") & "');", True)
          e.Cancel = True
          Exit Sub
        End If
        If F_TPTCode.Text <> D_TPTCode.Text Then
          ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Freight and Detention Supplier must be same.") & "');", True)
          e.Cancel = True
          Exit Sub
        End If
        If F_PONumber.Text <> D_PONumber.Text Then
          ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Freight and Detention PO Number must be same.") & "');", True)
          e.Cancel = True
          Exit Sub
        End If
        If F_ProjectID.Text <> D_ProjectID.Text Then
          ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Freight and Detention Project must be same.") & "');", True)
          e.Cancel = True
          Exit Sub
        End If
    End Select
  End Sub
  Private Sub FVerpCreateTPTBill_ItemUpdated(sender As Object, e As FormViewUpdatedEventArgs) Handles FVerpCreateTPTBill.ItemUpdated
    If e.Exception Is Nothing Then
      Dim SerialNo As String = e.NewValues("SerialNo")
      Dim RedirectUrl As String = "~/ERP_Main/App_Edit/EF_erpCreateTPTBill.aspx" & "?SerialNo=" & SerialNo
      Response.Redirect(RedirectUrl)
    End If
  End Sub
End Class
