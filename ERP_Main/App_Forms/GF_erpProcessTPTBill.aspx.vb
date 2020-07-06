Imports System.Web.Script.Serialization
Partial Class GF_erpProcessTPTBill
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ERP_Main/App_Display/DF_erpProcessTPTBill.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVerpProcessTPTBill_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVerpProcessTPTBill.RowCommand
    ErrorMsg.Visible = False
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVerpProcessTPTBill.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim RedirectUrl As String = TBLerpProcessTPTBill.EditUrl & "?SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVerpProcessTPTBill.DataKeys(e.CommandArgument).Values("SerialNo")
        SIS.ERP.erpProcessTPTBill.ApproveWF(SerialNo)
        GVerpProcessTPTBill.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "rejectwf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVerpProcessTPTBill.DataKeys(e.CommandArgument).Values("SerialNo")
        SIS.ERP.erpProcessTPTBill.RejectWF(SerialNo)
        GVerpProcessTPTBill.DataBind()
      Catch ex As Exception
        ErrorMsg.Text = ex.Message
        ErrorMsg.Visible = True
      End Try
    End If
    If e.CommandName.ToLower = "completewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVerpProcessTPTBill.DataKeys(e.CommandArgument).Values("SerialNo")
        SIS.ERP.erpProcessTPTBill.CompleteWF(SerialNo)
        GVerpProcessTPTBill.DataBind()
      Catch ex As Exception
        ErrorMsg.Text = ex.Message
        ErrorMsg.Visible = True
      End Try
    End If
    If e.CommandName.ToLower = "unlockwf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVerpProcessTPTBill.DataKeys(e.CommandArgument).Values("SerialNo")
        SIS.ERP.erpProcessTPTBill.UnlockWF(SerialNo)
        GVerpProcessTPTBill.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVerpProcessTPTBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVerpProcessTPTBill.Init
    DataClassName = "GerpProcessTPTBill"
    SetGridView = GVerpProcessTPTBill
  End Sub
  Protected Sub TBLerpProcessTPTBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpProcessTPTBill.Init
    SetToolBar = TBLerpProcessTPTBill
  End Sub
  Protected Sub F_TPTCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_TPTCode.TextChanged
    Session("F_TPTCode") = F_TPTCode.Text
    Session("F_TPTCode_Display") = F_TPTCode_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function TPTCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrTransporters.SelectvrTransportersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_ProjectID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ProjectID.TextChanged
    Session("F_ProjectID") = F_ProjectID.Text
    Session("F_ProjectID_Display") = F_ProjectID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_BillStatus_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_BillStatus.TextChanged
    Session("F_BillStatus") = F_BillStatus.Text
    Session("F_BillStatus_Display") = F_BillStatus_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function BillStatusCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ERP.erpTPTBillStatus.SelecterpTPTBillStatusAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_TPTCode_Display.Text = String.Empty
    If Not Session("F_TPTCode_Display") Is Nothing Then
      If Session("F_TPTCode_Display") <> String.Empty Then
        F_TPTCode_Display.Text = Session("F_TPTCode_Display")
      End If
    End If
    F_TPTCode.Text = String.Empty
    If Not Session("F_TPTCode") Is Nothing Then
      If Session("F_TPTCode") <> String.Empty Then
        F_TPTCode.Text = Session("F_TPTCode")
      End If
    End If
    Dim strScriptTPTCode As String = "<script type=""text/javascript""> " &
      "function ACETPTCode_Selected(sender, e) {" &
      "  var F_TPTCode = $get('" & F_TPTCode.ClientID & "');" &
      "  var F_TPTCode_Display = $get('" & F_TPTCode_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_TPTCode.value = p[0];" &
      "  F_TPTCode_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_TPTCode") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_TPTCode", strScriptTPTCode)
    End If
    Dim strScriptPopulatingTPTCode As String = "<script type=""text/javascript""> " &
      "function ACETPTCode_Populating(o,e) {" &
      "  var p = $get('" & F_TPTCode.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACETPTCode_Populated(o,e) {" &
      "  var p = $get('" & F_TPTCode.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_TPTCodePopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_TPTCodePopulating", strScriptPopulatingTPTCode)
    End If
    F_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        F_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    F_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        F_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim strScriptProjectID As String = "<script type=""text/javascript""> " &
      "function ACEProjectID_Selected(sender, e) {" &
      "  var F_ProjectID = $get('" & F_ProjectID.ClientID & "');" &
      "  var F_ProjectID_Display = $get('" & F_ProjectID_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_ProjectID.value = p[0];" &
      "  F_ProjectID_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProjectID", strScriptProjectID)
    End If
    Dim strScriptPopulatingProjectID As String = "<script type=""text/javascript""> " &
      "function ACEProjectID_Populating(o,e) {" &
      "  var p = $get('" & F_ProjectID.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACEProjectID_Populated(o,e) {" &
      "  var p = $get('" & F_ProjectID.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProjectIDPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProjectIDPopulating", strScriptPopulatingProjectID)
    End If
    F_BillStatus_Display.Text = String.Empty
    If Not Session("F_BillStatus_Display") Is Nothing Then
      If Session("F_BillStatus_Display") <> String.Empty Then
        F_BillStatus_Display.Text = Session("F_BillStatus_Display")
      End If
    End If
    F_BillStatus.Text = String.Empty
    If Not Session("F_BillStatus") Is Nothing Then
      If Session("F_BillStatus") <> String.Empty Then
        F_BillStatus.Text = Session("F_BillStatus")
      End If
    End If
    Dim strScriptBillStatus As String = "<script type=""text/javascript""> " &
      "function ACEBillStatus_Selected(sender, e) {" &
      "  var F_BillStatus = $get('" & F_BillStatus.ClientID & "');" &
      "  var F_BillStatus_Display = $get('" & F_BillStatus_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_BillStatus.value = p[0];" &
      "  F_BillStatus_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_BillStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_BillStatus", strScriptBillStatus)
    End If
    Dim strScriptPopulatingBillStatus As String = "<script type=""text/javascript""> " &
      "function ACEBillStatus_Populating(o,e) {" &
      "  var p = $get('" & F_BillStatus.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACEBillStatus_Populated(o,e) {" &
      "  var p = $get('" & F_BillStatus.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_BillStatusPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_BillStatusPopulating", strScriptPopulatingBillStatus)
    End If
    Dim validateScriptTPTCode As String = "<script type=""text/javascript"">" &
      "  function validate_TPTCode(o) {" &
      "    validated_FK_ERP_TransporterBill_TPTCode_main = true;" &
      "    validate_FK_ERP_TransporterBill_TPTCode(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateTPTCode") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateTPTCode", validateScriptTPTCode)
    End If
    Dim validateScriptProjectID As String = "<script type=""text/javascript"">" &
      "  function validate_ProjectID(o) {" &
      "    validated_FK_ERP_TransporterBill_ProjectID_main = true;" &
      "    validate_FK_ERP_TransporterBill_ProjectID(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProjectID", validateScriptProjectID)
    End If
    Dim validateScriptBillStatus As String = "<script type=""text/javascript"">" &
      "  function validate_BillStatus(o) {" &
      "    validated_FK_ERP_TransporterBill_BillStatus_main = true;" &
      "    validate_FK_ERP_TransporterBill_BillStatus(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateBillStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateBillStatus", validateScriptBillStatus)
    End If
    Dim validateScriptFK_ERP_TransporterBill_BillStatus As String = "<script type=""text/javascript"">" &
      "  function validate_FK_ERP_TransporterBill_BillStatus(o) {" &
      "    var value = o.id;" &
      "    var BillStatus = $get('" & F_BillStatus.ClientID & "');" &
      "    try{" &
      "    if(BillStatus.value==''){" &
      "      if(validated_FK_ERP_TransporterBill_BillStatus.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + BillStatus.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_ERP_TransporterBill_BillStatus(value, validated_FK_ERP_TransporterBill_BillStatus);" &
      "  }" &
      "  validated_FK_ERP_TransporterBill_BillStatus_main = false;" &
      "  function validated_FK_ERP_TransporterBill_BillStatus(result) {" &
      "    var p = result.split('|');" &
      "    var o = $get(p[1]);" &
      "    var o_d = $get(p[1]+'_Display');" &
      "    try{o_d.innerHTML = p[2];}catch(ex){}" &
      "    o.style.backgroundImage  = 'none';" &
      "    if(p[0]=='1'){" &
      "      o.value='';" &
      "      try{o_d.innerHTML = '';}catch(ex){}" &
      "      __doPostBack(o.id, o.value);" &
      "    }" &
      "    else" &
      "      __doPostBack(o.id, o.value);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ERP_TransporterBill_BillStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ERP_TransporterBill_BillStatus", validateScriptFK_ERP_TransporterBill_BillStatus)
    End If
    Dim validateScriptFK_ERP_TransporterBill_ProjectID As String = "<script type=""text/javascript"">" &
      "  function validate_FK_ERP_TransporterBill_ProjectID(o) {" &
      "    var value = o.id;" &
      "    var ProjectID = $get('" & F_ProjectID.ClientID & "');" &
      "    try{" &
      "    if(ProjectID.value==''){" &
      "      if(validated_FK_ERP_TransporterBill_ProjectID.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + ProjectID.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_ERP_TransporterBill_ProjectID(value, validated_FK_ERP_TransporterBill_ProjectID);" &
      "  }" &
      "  validated_FK_ERP_TransporterBill_ProjectID_main = false;" &
      "  function validated_FK_ERP_TransporterBill_ProjectID(result) {" &
      "    var p = result.split('|');" &
      "    var o = $get(p[1]);" &
      "    var o_d = $get(p[1]+'_Display');" &
      "    try{o_d.innerHTML = p[2];}catch(ex){}" &
      "    o.style.backgroundImage  = 'none';" &
      "    if(p[0]=='1'){" &
      "      o.value='';" &
      "      try{o_d.innerHTML = '';}catch(ex){}" &
      "      __doPostBack(o.id, o.value);" &
      "    }" &
      "    else" &
      "      __doPostBack(o.id, o.value);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ERP_TransporterBill_ProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ERP_TransporterBill_ProjectID", validateScriptFK_ERP_TransporterBill_ProjectID)
    End If
    Dim validateScriptFK_ERP_TransporterBill_TPTCode As String = "<script type=""text/javascript"">" &
      "  function validate_FK_ERP_TransporterBill_TPTCode(o) {" &
      "    var value = o.id;" &
      "    var TPTCode = $get('" & F_TPTCode.ClientID & "');" &
      "    try{" &
      "    if(TPTCode.value==''){" &
      "      if(validated_FK_ERP_TransporterBill_TPTCode.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + TPTCode.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_ERP_TransporterBill_TPTCode(value, validated_FK_ERP_TransporterBill_TPTCode);" &
      "  }" &
      "  validated_FK_ERP_TransporterBill_TPTCode_main = false;" &
      "  function validated_FK_ERP_TransporterBill_TPTCode(result) {" &
      "    var p = result.split('|');" &
      "    var o = $get(p[1]);" &
      "    var o_d = $get(p[1]+'_Display');" &
      "    try{o_d.innerHTML = p[2];}catch(ex){}" &
      "    o.style.backgroundImage  = 'none';" &
      "    if(p[0]=='1'){" &
      "      o.value='';" &
      "      try{o_d.innerHTML = '';}catch(ex){}" &
      "      __doPostBack(o.id, o.value);" &
      "    }" &
      "    else" &
      "      __doPostBack(o.id, o.value);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ERP_TransporterBill_TPTCode") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ERP_TransporterBill_TPTCode", validateScriptFK_ERP_TransporterBill_TPTCode)
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_ERP_TransporterBill_BillStatus(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim BillStatus As String = aVal(1)
    If BillStatus = "" Then BillStatus = 0
    Dim oVar As SIS.ERP.erpTPTBillStatus = SIS.ERP.erpTPTBillStatus.erpTPTBillStatusGetByID(BillStatus)
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
End Class
