Imports System.Web.Script.Serialization
Partial Class AF_erpCreateTPTBill
  Inherits SIS.SYS.InsertBase
  Protected Sub FVerpCreateTPTBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpCreateTPTBill.Init
    DataClassName = "AerpCreateTPTBill"
    SetFormView = FVerpCreateTPTBill
  End Sub
  Protected Sub TBLerpCreateTPTBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpCreateTPTBill.Init
    SetToolBar = TBLerpCreateTPTBill
  End Sub
  Protected Sub FVerpCreateTPTBill_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpCreateTPTBill.PreRender
    Dim BillType As String = CType(FVerpCreateTPTBill.FindControl("F_BillType"), DropDownList).SelectedValue
    Select Case BillType
      Case ""
        FVerpCreateTPTBill.FindControl("trDet7").Visible = False
        FVerpCreateTPTBill.FindControl("tblFreight").Visible = False
        FVerpCreateTPTBill.FindControl("tblDetention").Visible = False
      Case "Freight Bill"
        FVerpCreateTPTBill.FindControl("trDet7").Visible = False
        FVerpCreateTPTBill.FindControl("tblFreight").Visible = True
        FVerpCreateTPTBill.FindControl("trDet1").Visible = False
        FVerpCreateTPTBill.FindControl("trDet2").Visible = False
        FVerpCreateTPTBill.FindControl("trDet3").Visible = False
        FVerpCreateTPTBill.FindControl("trDet4").Visible = False
        FVerpCreateTPTBill.FindControl("trDet5").Visible = False
        FVerpCreateTPTBill.FindControl("trDet6").Visible = False
        FVerpCreateTPTBill.FindControl("tblDetention").Visible = False
      Case "Freight Bill With Detention"
        FVerpCreateTPTBill.FindControl("trDet7").Visible = False
        FVerpCreateTPTBill.FindControl("tblFreight").Visible = True
        FVerpCreateTPTBill.FindControl("trDet1").Visible = True
        FVerpCreateTPTBill.FindControl("trDet2").Visible = True
        FVerpCreateTPTBill.FindControl("trDet3").Visible = True
        FVerpCreateTPTBill.FindControl("trDet4").Visible = True
        FVerpCreateTPTBill.FindControl("trDet5").Visible = True
        FVerpCreateTPTBill.FindControl("trDet6").Visible = True
        FVerpCreateTPTBill.FindControl("tblDetention").Visible = False
      Case "Freight And Detention Separate Bills"
        FVerpCreateTPTBill.FindControl("trDet7").Visible = True
        FVerpCreateTPTBill.FindControl("tblFreight").Visible = True
        FVerpCreateTPTBill.FindControl("trDet1").Visible = False
        FVerpCreateTPTBill.FindControl("trDet2").Visible = False
        FVerpCreateTPTBill.FindControl("trDet3").Visible = False
        FVerpCreateTPTBill.FindControl("trDet4").Visible = False
        FVerpCreateTPTBill.FindControl("trDet5").Visible = False
        FVerpCreateTPTBill.FindControl("trDet6").Visible = False
        FVerpCreateTPTBill.FindControl("tblDetention").Visible = True
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
  Public Shared Function DiscReturnedToByACCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function CreatedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
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
      mRet = "0|" & aVal(0) & SIS.ERP.erpCreateTPTBill.getStrIRData(tmp)
      tmp.ErrMessage = "0|" & aVal(0)
    Catch ex As Exception
      mRet = "1|" & aVal(0) & "|" & ex.Message
    End Try
    Return mRet
  End Function

  Private Sub FVerpCreateTPTBill_ItemInserting(sender As Object, e As FormViewInsertEventArgs) Handles FVerpCreateTPTBill.ItemInserting
    Dim BillType As String = CType(FVerpCreateTPTBill.FindControl("F_BillType"), DropDownList).SelectedValue
    Select Case BillType
      Case ""
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Please Select Bill Type.") & "');", True)
        e.Cancel = True
        Exit Sub
      Case "Freight Bill"
      Case "Freight Bill With Detention"
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
End Class
