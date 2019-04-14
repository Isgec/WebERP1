<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" ClientIDMode="Static" CodeFile="EF_erpCreateTPTBill.aspx.vb" Inherits="EF_erpCreateTPTBill" title="Edit: Create Transporter Bill" %>
<asp:Content ID="CPHerpCreateTPTBill" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
  <asp:Label ID="LabelerpCreateTPTBill" runat="server" Text="&nbsp;Edit: Create Transporter Bill"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLerpCreateTPTBill" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLerpCreateTPTBill"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_erpCreateTPTBill.aspx?pk="
    ValidationGroup = "erpCreateTPTBill"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVerpCreateTPTBill"
	runat = "server"
	DataKeyNames = "SerialNo"
	DataSourceID = "ODSerpCreateTPTBill"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
    <table style="width:100%;">
			<tr>
				<td style="vertical-align:top;" >
          <table>
            <tr>
            <td class="alignright">
                <asp:Label ID="L_RecordType" runat="server" Font-Bold="true" Text='<%# Bind("RecordType") %>'></asp:Label>:
              </td>
              <td>
                <asp:Label
                  ID="F_BillType"
                  CssClass="dypktxt"
                  Enabled="false"
                  Text='<%# Bind("BillType") %>'
                  runat="server"/>
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_SerialNo"
                  Text='<%# Bind("SerialNo") %>'
                  ToolTip="Value of Serial No."
                  Enabled="False"
                  CssClass="mypktxt"
                  Width="70px"
                  Style="text-align: right"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="Label2" runat="server" ForeColor="#CC6633" Text="IR Number :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_IRNumber"
                  runat="server"
                  CssClass="dmytxt"
                  MaxLength="10"
                  Width="90px"
                  Enabled="false"
                  ValidationGroup="erpCreateTPTBill"
                  Text='<%# Bind("IRNumber") %>' />
                <input type="button" id="getIRData" value="Get IR Details from ERP" disabled="disabled" onclick="script_erpCreateTPTBill.getIRData('ctl00_cph1_FVerpCreateTPTBill_F_IRNumber');" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_TPTBillNo" runat="server" Text="Transporter Bill No. :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_TPTBillNo"
                  Text='<%# Bind("TPTBillNo") %>'
                  Width="210px"
                  CssClass="dmytxt"
                  Enabled="false"
                  onfocus="return this.select();"
                  ValidationGroup="erpCreateTPTBill"
                  onblur="this.value=this.value.replace(/\'/g,'');"
                  ToolTip="Enter value for Transporter Bill No.."
                  MaxLength="30"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_TPTBillDate" runat="server" Text="Transporter Bill Date :" /></b>
              </td>
              <td style="vertical-align: bottom">
                <asp:TextBox ID="F_TPTBillDate"
                  Text='<%# Bind("TPTBillDate") %>'
                  Width="90px"
                  CssClass="dmytxt"
                  Enabled="false"
                  onfocus="return this.select();"
                  ValidationGroup="erpCreateTPTBill"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_TPTBillReceivedOn" runat="server" Text="Tpt. Bill Received On :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_TPTBillReceivedOn"
                  Text='<%# Bind("TPTBillReceivedOn") %>'
                  Width="90px"
                  CssClass="dmytxt"
                  Enabled="false"
                  onfocus="return this.select();"
                  ValidationGroup="erpCreateTPTBill"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_GRNos" runat="server" Text="GR Nos. :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_GRNos"
                  Text='<%# Bind("GRNos") %>'
                  Width="350px" 
                  CssClass="dmytxt"
                  Enabled="false"
                  onfocus="return this.select();"
                  onblur="this.value=this.value.replace(/\'/g,'');"
                  ToolTip="Enter value for GR Nos.."
                  MaxLength="500"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_TPTCode" runat="server" Text="Transporter Code :" /></b>
              </td>
              <td>
                <asp:TextBox
                  ID="F_TPTCode"
                  CssClass="dmytxt"
                  Enabled="false"
                  Text='<%# Bind("TPTCode") %>'
                  AutoCompleteType="None"
                  Width="90px"
                  onfocus="return this.select();"
                  ToolTip="Enter value for Transporter Code."
                  ValidationGroup="erpCreateTPTBill"
                  onblur="script_erpCreateTPTBill.validate_TPTCode(this);"
                  runat="Server" />
                <asp:Label
                  ID="F_TPTCode_Display"
                  Text='<%# Eval("VR_Transporters10_TransporterName") %>'
                  runat="Server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_PONumber" runat="server" Text="Purchase Order No. :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_PONumber"
                  Text='<%# Bind("PONumber") %>'
                  Width="90px"
                  CssClass="dmytxt"
                  Enabled="false"
                  onfocus="return this.select();"
                  ValidationGroup="erpCreateTPTBill"
                  onblur="this.value=this.value.replace(/\'/g,'');"
                  ToolTip="Enter value for Purchase Order No.."
                  MaxLength="9"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_ProjectID" runat="server" Text="Project ID :" /></b>
              </td>
              <td>
                <asp:TextBox
                  ID="F_ProjectID"
                  CssClass="dmytxt"
                  Enabled="false"
                  Text='<%# Bind("ProjectID") %>'
                  AutoCompleteType="None"
                  Width="60px"
                  onfocus="return this.select();"
                  ToolTip="Enter value for Project ID."
                  ValidationGroup="erpCreateTPTBill"
                  onblur="script_erpCreateTPTBill.validate_ProjectID(this);"
                  runat="Server" />
                <asp:Label
                  ID="F_ProjectID_Display"
                  Text='<%# Eval("IDM_Projects9_Description") %>'
                  runat="Server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_TPTBillAmount" runat="server" Text="Tpt. Bill Amount :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_TPTBillAmount"
                  Text='<%# Bind("TPTBillAmount") %>'
                  Style="text-align: right"
                  Width="90px"
                  CssClass="dmytxt"
                  Enabled="false"
                  ValidationGroup="erpCreateTPTBill"
                  MaxLength="20"
                  onfocus="return this.select();"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="Label1" runat="server" Text="Concerned Person [Materials] :" /></b>
              </td>
              <td>
                <asp:TextBox
                  ID="F_CreatedBy"
                  CssClass="myfktxt"
                  Width="56px"
                  Text='<%# Bind("CreatedBy") %>'
                  AutoCompleteType="None"
                  onfocus="return this.select();"
                  ToolTip="Enter value for Concerned Person [Materials]."
                  ValidationGroup="erpCreateTPTBill"
                  onblur="script_erpCreateTPTBill.validate_CreatedBy(this);"
                  runat="Server" />
                <asp:Label
                  ID="F_CreatedBy_Display"
                  Text='<%# Eval("aspnet_Users7_UserFullName") %>'
                  runat="Server" />
                <asp:RequiredFieldValidator
                  ID="RFVCreatedBy"
                  runat="server"
                  ControlToValidate="F_CreatedBy"
                  Text="Forwarded To [Accounts Emp.] is required."
                  ErrorMessage="[Required!]"
                  Display="Dynamic"
                  EnableClientScript="true"
                  ValidationGroup="erpCreateTPTBill"
                  SetFocusOnError="true" />
                <AJX:AutoCompleteExtender
                  ID="ACECreatedBy"
                  BehaviorID="B_ACECreatedBy"
                  ContextKey=""
                  UseContextKey="true"
                  ServiceMethod="CreatedByCompletionList"
                  TargetControlID="F_CreatedBy"
                  EnableCaching="false"
                  CompletionInterval="100"
                  FirstRowSelected="true"
                  MinimumPrefixLength="1"
                  OnClientItemSelected="script_erpCreateTPTBill.ACECreatedBy_Selected"
                  OnClientPopulating="script_erpCreateTPTBill.ACECreatedBy_Populating"
                  OnClientPopulated="script_erpCreateTPTBill.ACECreatedBy_Populated"
                  CompletionSetCount="10"
                  CompletionListCssClass="autocomplete_completionListElement"
                  CompletionListItemCssClass="autocomplete_listItem"
                  CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                  runat="Server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_DiscReturnedToByAC" runat="server" Text="Forwarded To [Accounts Emp.] :" /></b>
              </td>
              <td>
                <asp:TextBox
                  ID="F_DiscReturnedToByAC"
                  CssClass="myfktxt"
                  Text='<%# Bind("DiscReturnedToByAC") %>'
                  AutoCompleteType="None"
                  Width="56px"
                  onfocus="return this.select();"
                  ToolTip="Enter value for Forwarded To [Accounts Emp.]."
                  ValidationGroup="erpCreateTPTBill"
                  onblur="script_erpCreateTPTBill.validate_DiscReturnedToByAC(this);"
                  runat="Server" />
                <asp:Label
                  ID="F_DiscReturnedToByAC_Display"
                  Text='<%# Eval("aspnet_Users4_UserFullName") %>'
                  runat="Server" />
                <asp:RequiredFieldValidator
                  ID="RFVDiscReturnedToByAC"
                  runat="server"
                  ControlToValidate="F_DiscReturnedToByAC"
                  Text="Forwarded To [Accounts Emp.] is required."
                  ErrorMessage="[Required!]"
                  Display="Dynamic"
                  EnableClientScript="true"
                  ValidationGroup="erpCreateTPTBill"
                  SetFocusOnError="true" />
                <AJX:AutoCompleteExtender
                  ID="ACEDiscReturnedToByAC"
                  BehaviorID="B_ACEDiscReturnedToByAC"
                  ContextKey=""
                  UseContextKey="true"
                  ServiceMethod="DiscReturnedToByACCompletionList"
                  TargetControlID="F_DiscReturnedToByAC"
                  EnableCaching="false"
                  CompletionInterval="100"
                  FirstRowSelected="true"
                  MinimumPrefixLength="1"
                  OnClientItemSelected="script_erpCreateTPTBill.ACEDiscReturnedToByAC_Selected"
                  OnClientPopulating="script_erpCreateTPTBill.ACEDiscReturnedToByAC_Populating"
                  OnClientPopulated="script_erpCreateTPTBill.ACEDiscReturnedToByAC_Populated"
                  CompletionSetCount="10"
                  CompletionListCssClass="autocomplete_completionListElement"
                  CompletionListItemCssClass="autocomplete_listItem"
                  CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                  runat="Server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_ChequeNo" runat="server" Text="Cheque No :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_ChequeNo"
                  Text='<%# Bind("ChequeNo") %>'
                  Width="140px"
                  CssClass="mytxt"
                  onfocus="return this.select();"
                  onblur="this.value=this.value.replace(/\'/g,'');"
                  ToolTip="Enter value for Cheque No."
                  MaxLength="20"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_LgstRemarks" runat="server" Text="Logistics Remarks :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_LgstRemarks"
                  Text='<%# Bind("LgstRemarks") %>'
                  Width="350px" Height="40px" TextMode="MultiLine"
                  CssClass="mytxt"
                  onfocus="return this.select();"
                  onblur="this.value=this.value.replace(/\'/g,'');"
                  ToolTip="Enter value for Logistics Remarks."
                  MaxLength="500"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_BillStatus" runat="server" Text="Bill Status :" /></b>
              </td>
              <td>
                <asp:TextBox
                  ID="F_BillStatus"
                  Width="70px"
                  Text='<%# Bind("BillStatus") %>'
                  Enabled="False"
                  ToolTip="Value of Bill Status."
                  CssClass="dmyfktxt"
                  runat="Server" />
                <asp:Label
                  ID="F_BillStatus_Display"
                  Text='<%# Eval("ERP_TPTBillStatus8_Description") %>'
                  runat="Server" />
              </td>
            </tr>
          </table>
        </td>
				<td style="vertical-align:top;" >
          <table>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_BasicFreightValue" runat="server" Text="Basic Freight Charge :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_BasicFreightValue"
                  Text='<%# Bind("BasicFreightValue") %>'
                  Style="text-align: right"
                  Width="90px"
                  CssClass="mytxt"
                  MaxLength="23"
                  onfocus="return this.select();"
                  onblur="return dc(this,2);"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_BasicFvODC" runat="server" Text="ODC Charges :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_BasicFvODC"
                  Text='<%# Bind("BasicFvODC") %>'
                  Style="text-align: right"
                  Width="90px"
                  CssClass="mytxt"
                  MaxLength="23"
                  onfocus="return this.select();"
                  onblur="return dc(this,2);"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_DetentionatLP" runat="server" Text="Detention at Loading Point :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_DetentionatLP"
                  Text='<%# Bind("DetentionatLP") %>'
                  Style="text-align: right"
                  Width="90px"
                  CssClass="mytxt"
                  MaxLength="23"
                  onfocus="return this.select();"
                  onblur="return dc(this,2);"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_DetentionatDaysLP" runat="server" Text="Detention Days at Loading Point :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_DetentionatDaysLP"
                  Text='<%# Bind("DetentionatDaysLP") %>'
                  Width="90px"
                  CssClass="mytxt"
                  MaxLength="4"
                  onfocus="return this.select();"
                  onblur="return dc(this,0);"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="LabelLPisISGECWorks" runat="server" Text="Loading Point is ISGEC Works :" /></b>
              </td>
              <td>
                <asp:CheckBox ID="F_LPisISGECWorks"
                  Checked='<%# Bind("LPisISGECWorks") %>'
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_DetentionatULP" runat="server" Text="Detention at UnLoading Point :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_DetentionatULP"
                  Text='<%# Bind("DetentionatULP") %>'
                  Width="90px"
                  CssClass="mytxt"
                  MaxLength="23"
                  onfocus="return this.select();"
                  onblur="return dc(this,2);"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_DetentionatDaysULP" runat="server" Text="Detention Days at Unloading Point :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_DetentionatDaysULP"
                  Text='<%# Bind("DetentionatDaysULP") %>'
                  Width="90px"
                  CssClass="mytxt"
                  MaxLength="4"
                  onfocus="return this.select();"
                  onblur="return dc(this,0);"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="LabelULPisICDCFSPort" runat="server" Text="Unloading Point is ICD/CFS/Port :" /></b>
              </td>
              <td>
                <asp:CheckBox ID="F_ULPisICDCFSPort"
                  Checked='<%# Bind("ULPisICDCFSPort") %>'
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_BackToTownCharges" runat="server" Text="Back to town charges :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_BackToTownCharges"
                  Text='<%# Bind("BackToTownCharges") %>'
                  Width="90px"
                  CssClass="mytxt"
                  MaxLength="23"
                  onfocus="return this.select();"
                  onblur="return dc(this,2);"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_TarpaulinCharges" runat="server" Text="Tarpaulin charges :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_TarpaulinCharges"
                  Text='<%# Bind("TarpaulinCharges") %>'
                  Width="90px"
                  CssClass="mytxt"
                  MaxLength="23"
                  onfocus="return this.select();"
                  onblur="return dc(this,2);"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_WoodenSleeperCharges" runat="server" Text="Wooden Sleeper charges :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_WoodenSleeperCharges"
                  Text='<%# Bind("WoodenSleeperCharges") %>'
                  Width="90px"
                  CssClass="mytxt"
                  MaxLength="23"
                  onfocus="return this.select();"
                  onblur="return dc(this,2);"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_ODCChargesInContract" runat="server" Text="Additional ODC Charges In Contract :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_ODCChargesInContract"
                  Text='<%# Bind("ODCChargesInContract") %>'
                  Style="text-align: right"
                  Width="90px"
                  CssClass="mytxt"
                  MaxLength="23"
                  onfocus="return this.select();"
                  onblur="return dc(this,2);"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_ODCChargesOutOfContract" runat="server" Text="Additional ODC Charges Out Of Contract :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_ODCChargesOutOfContract"
                  Text='<%# Bind("ODCChargesOutOfContract") %>'
                  Style="text-align: right"
                  Width="90px"
                  CssClass="mytxt"
                  MaxLength="23"
                  onfocus="return this.select();"
                  onblur="return dc(this,2);"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_EmptyReturnCharges" runat="server" Text="Empty Return Charges :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_EmptyReturnCharges"
                  Text='<%# Bind("EmptyReturnCharges") %>'
                  Style="text-align: right"
                  Width="90px"
                  CssClass="mytxt"
                  MaxLength="23"
                  onfocus="return this.select();"
                  onblur="return dc(this,2);"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_RTOChallanAmount" runat="server" Text="RTO Challan Amount :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_RTOChallanAmount"
                  Text='<%# Bind("RTOChallanAmount") %>'
                  Style="text-align: right"
                  Width="90px"
                  CssClass="mytxt"
                  MaxLength="23"
                  onfocus="return this.select();"
                  onblur="return dc(this,2);"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_OtherAmount" runat="server" Text="Other Charges :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_OtherAmount"
                  Text='<%# Bind("OtherAmount") %>'
                  Style="text-align: right"
                  Width="90px"
                  CssClass="mytxt"
                  MaxLength="23"
                  onfocus="return this.select();"
                  onblur="return dc(this,2);"
                  runat="server" />
              </td>
            </tr>
            <tr>
                <td colspan="2">
                  <table>
                    <tr>
                      <td class="alignright">
                        <asp:Label ID="L_AssessableValue" runat="server" Text="Basic / Assessable Value :" /><span style="color: red">*</span>
                      </td>
                      <td colspan="3">
                        <asp:TextBox ID="F_AssessableValue"
                          Text='<%# Bind("AssessableValue") %>'
                          Width="168px"
                          CssClass="mytxt"
                          Style="text-align: Right"
                          ValidationGroup="spmtSupplierBill"
                          MaxLength="20"
                          onfocus="return this.select();"
                          onblur="return validate_tots(this,2);"
                          runat="server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="alignright">
                        <asp:Label ID="L_IGSTRate" runat="server" Text="IGST % [Rate] :" />
                      </td>
                      <td>
                        <asp:TextBox ID="F_IGSTRate"
                          Text='<%# Bind("IGSTRate") %>'
                          Width="168px"
                          CssClass="mytxt"
                          Style="text-align: Right"
                          ValidationGroup="spmtSupplierBill"
                          MaxLength="20"
                          onfocus="return this.select();"
                          onblur="return validate_tots(this,2);"
                          runat="server" />
                      </td>
                      <td class="alignright">
                        <asp:Label ID="L_IGSTAmount" runat="server" Text="IGST Amount :" />&nbsp;
                      </td>
                      <td>
                        <asp:TextBox ID="F_IGSTAmount"
                          Text='<%# Bind("IGSTAmount") %>'
                          Width="168px"
                          CssClass="mytxt"
                          Style="text-align: right"
                          ValidationGroup="spmtSupplierBill"
                          MaxLength="20"
                          onfocus="return this.select();"
                          onblur="return validate_tots(this,2);"
                          runat="server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="alignright">
                        <asp:Label ID="L_CGSTRate" runat="server" Text="CGST % [Rate] :" />
                      </td>
                      <td>
                        <asp:TextBox ID="F_CGSTRate"
                          Text='<%# Bind("CGSTRate") %>'
                          Width="168px"
                          CssClass="mytxt"
                          Style="text-align: Right"
                          ValidationGroup="spmtSupplierBill"
                          MaxLength="20"
                          onfocus="return this.select();"
                          onblur="return validate_tots(this,2);"
                          runat="server" />
                      </td>
                      <td class="alignright">
                        <asp:Label ID="L_CGSTAmount" runat="server" Text="CGST Amount :" />&nbsp;
                      </td>
                      <td>
                        <asp:TextBox ID="F_CGSTAmount"
                          Text='<%# Bind("CGSTAmount") %>'
                          ValidationGroup="spmtSupplierBill"
                          MaxLength="20"
                          onfocus="return this.select();"
                          onblur="return validate_tots(this,2);"
                          Width="168px"
                          CssClass="mytxt"
                          Style="text-align: right"
                          runat="server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="alignright">
                        <asp:Label ID="L_SGSTRate" runat="server" Text="SGST % [Rate] :" />
                      </td>
                      <td>
                        <asp:TextBox ID="F_SGSTRate"
                          Text='<%# Bind("SGSTRate") %>'
                          Width="168px"
                          CssClass="mytxt"
                          Style="text-align: Right"
                          ValidationGroup="spmtSupplierBill"
                          MaxLength="20"
                          onfocus="return this.select();"
                          onblur="return validate_tots(this,2);"
                          runat="server" />
                      </td>
                      <td class="alignright">
                        <asp:Label ID="L_SGSTAmount" runat="server" Text="SGST Amount :" />&nbsp;
                      </td>
                      <td>
                        <asp:TextBox ID="F_SGSTAmount"
                          Text='<%# Bind("SGSTAmount") %>'
                          ValidationGroup="spmtSupplierBill"
                          MaxLength="20"
                          onfocus="return this.select();"
                          onblur="return validate_tots(this,2);"
                          Width="168px"
                          CssClass="mytxt"
                          Style="text-align: right"
                          runat="server" />
                      </td>
                    </tr>
                    <tr style="display:none;">
                      <td class="alignright">
                        <asp:Label ID="L_CessRate" runat="server" Text="Cess % [Rate] :" />
                      </td>
                      <td>
                        <asp:TextBox ID="F_CessRate"
                          Text='<%# Bind("CessRate") %>'
                          Width="168px"
                          CssClass="mytxt"
                          Style="text-align: Right"
                          ValidationGroup="spmtSupplierBill"
                          MaxLength="20"
                          onfocus="return this.select();"
                          onblur="return validate_tots(this,2);"
                          runat="server" />
                      </td>
                      <td class="alignright">
                        <asp:Label ID="L_CessAmount" runat="server" Text="Cess Amount :" />&nbsp;
                      </td>
                      <td>
                        <asp:TextBox ID="F_CessAmount"
                          Text='<%# Bind("CessAmount") %>'
                          ValidationGroup="spmtSupplierBill"
                          MaxLength="20"
                          onfocus="return this.select();"
                          onblur="return validate_tots(this,2);"
                          Width="168px"
                          CssClass="mytxt"
                          Style="text-align: right"
                          runat="server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="alignright">
                        <asp:Label ID="L_TotalGST" runat="server" Text="Total GST :" />&nbsp;
                      </td>
                      <td>
                        <asp:TextBox ID="F_TotalGST"
                          Text='<%# Bind("TotalGST") %>'
                          Enabled="False"
                          ToolTip="Value of Total GST."
                          Width="168px"
                          CssClass="dmytxt"
                          Style="text-align: right"
                          runat="server" />
                      </td>
                      <td class="alignright">
                        <asp:Label ID="L_TotalAmount" runat="server" Text="Total Amount :" />&nbsp;
                      </td>
                      <td>
                        <asp:TextBox ID="F_TotalAmount"
                          Text='<%# Bind("TotalAmount") %>'
                          Enabled="False"
                          ToolTip="Value of Total Amount."
                          Width="168px"
                          CssClass="dmytxt"
                          Style="text-align: right"
                          runat="server" />
                      </td>
                    </tr>
                  </table>
                </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_TotalBillPassedAmount" runat="server" Text="Total Bill Passed Amount :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_TotalBillPassedAmount"
                  Text='<%# Bind("TotalBillPassedAmount") %>'
                  Enabled="False"
                  BackColor="Aqua"
                  Width="126px"
                  CssClass="dmytxt"
                  Style="text-align: right"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_CreatedOn" runat="server" Text="Created On :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_CreatedOn"
                  Text='<%# Bind("CreatedOn") %>'
                  ToolTip="Value of Created On."
                  Enabled="False"
                  Width="140px"
                  CssClass="dmytxt"
                  runat="server" />
              </td>
            </tr>
          </table>
        </td>
			</tr>
        <tr><td colspan="2" style="border-top: solid 1pt LightGrey" ></td></tr>
			<tr>
				<td style="vertical-align:top;" >
          <table>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_FWDToAccountsOn" runat="server" Text="Forwarded To Accounts On :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_FWDToAccountsOn"
                  Text='<%# Bind("FWDToAccountsOn") %>'
                  ToolTip="Value of Forwarded To Accounts On."
                  Enabled="False"
                  Width="140px"
                  CssClass="dmytxt"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_FWDToAccountsBy" runat="server" Text="Forwarded To Accounts By :" /></b>
              </td>
              <td>
                <asp:TextBox
                  ID="F_FWDToAccountsBy"
                  Width="56px"
                  Text='<%# Bind("FWDToAccountsBy") %>'
                  Enabled="False"
                  ToolTip="Value of Forwarded To Accounts By."
                  CssClass="dmyfktxt"
                  runat="Server" />
                <asp:Label
                  ID="F_FWDToAccountsBy_Display"
                  Text='<%# Eval("aspnet_Users1_UserFullName") %>'
                  runat="Server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_RECDByAccountsOn" runat="server" Text="Received In Accounts On :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_RECDByAccountsOn"
                  Text='<%# Bind("RECDByAccountsOn") %>'
                  ToolTip="Value of Received In Accounts On."
                  Enabled="False"
                  Width="140px"
                  CssClass="dmytxt"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_RECDinAccountsBy" runat="server" Text="Received In Accounts By :" /></b>
              </td>
              <td>
                <asp:TextBox
                  ID="F_RECDinAccountsBy"
                  Width="56px"
                  Text='<%# Bind("RECDinAccountsBy") %>'
                  Enabled="False"
                  ToolTip="Value of Received In Accounts By."
                  CssClass="dmyfktxt"
                  runat="Server" />
                <asp:Label
                  ID="F_RECDinAccountsBy_Display"
                  Text='<%# Eval("aspnet_Users2_UserFullName") %>'
                  runat="Server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_DiscReturnedByACOn" runat="server" Text="Disc.Doc. Returned By A/c On :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_DiscReturnedByACOn"
                  Text='<%# Bind("DiscReturnedByACOn") %>'
                  ToolTip="Value of Disc.Doc. Returned By A/c On."
                  Enabled="False"
                  Width="140px"
                  CssClass="dmytxt"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_DiscReturnedinAcBy" runat="server" Text="Disc.Doc. Returned By :" /></b>
              </td>
              <td>
                <asp:TextBox
                  ID="F_DiscReturnedinAcBy"
                  Width="56px"
                  Text='<%# Bind("DiscReturnedinAcBy") %>'
                  Enabled="False"
                  ToolTip="Value of Disc.Doc. Returned By."
                  CssClass="dmyfktxt"
                  runat="Server" />
                <asp:Label
                  ID="F_DiscReturnedinAcBy_Display"
                  Text='<%# Eval("aspnet_Users3_UserFullName") %>'
                  runat="Server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_DiscRecdInLgstBy" runat="server" Text="Disc.Doc. Received in Logistics By :" /></b>
              </td>
              <td>
                <asp:TextBox
                  ID="F_DiscRecdInLgstBy"
                  Width="56px"
                  Text='<%# Bind("DiscRecdInLgstBy") %>'
                  Enabled="False"
                  ToolTip="Value of Disc.Doc. Received in Logistics By."
                  CssClass="dmyfktxt"
                  runat="Server" />
                <asp:Label
                  ID="F_DiscRecdInLgstBy_Display"
                  Text='<%# Eval("aspnet_Users5_UserFullName") %>'
                  runat="Server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_DiscRecdInLgstOn" runat="server" Text="Disc.Doc. Received in Logistics On :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_DiscRecdInLgstOn"
                  Text='<%# Bind("DiscRecdInLgstOn") %>'
                  ToolTip="Value of Disc.Doc. Received in Logistics On."
                  Enabled="False"
                  Width="140px"
                  CssClass="dmytxt"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_ReFwdToAcBy" runat="server" Text="Re-Submitted to Accounts By :" /></b>
              </td>
              <td>
                <asp:TextBox
                  ID="F_ReFwdToAcBy"
                  Width="56px"
                  Text='<%# Bind("ReFwdToAcBy") %>'
                  Enabled="False"
                  ToolTip="Value of Re-Submitted to Accounts By."
                  CssClass="dmyfktxt"
                  runat="Server" />
                <asp:Label
                  ID="F_ReFwdToAcBy_Display"
                  Text='<%# Eval("aspnet_Users6_UserFullName") %>'
                  runat="Server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_ReFwdToACOn" runat="server" Text="Re-Submitted to Accounts On :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_ReFwdToACOn"
                  Text='<%# Bind("ReFwdToACOn") %>'
                  ToolTip="Value of Re-Submitted to Accounts On."
                  Enabled="False"
                  Width="140px"
                  CssClass="dmytxt"
                  runat="server" />
              </td>
            </tr>
          </table>
        </td>
				<td style="vertical-align:top;" >
          <table>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_PTRNo" runat="server" Text="PTR No :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_PTRNo"
                  Text='<%# Bind("PTRNo") %>'
                  ToolTip="Value of PTR No."
                  Enabled="False"
                  Width="70px"
                  CssClass="dmytxt"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_PTRAmount" runat="server" Text="PTR Amount :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_PTRAmount"
                  Text='<%# Bind("PTRAmount") %>'
                  ToolTip="Value of PTR Amount."
                  Enabled="False"
                  BackColor="Aqua"
                  Width="126px"
                  CssClass="dmytxt"
                  Style="text-align: right"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_PTRDate" runat="server" Text="PTR Date :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_PTRDate"
                  Text='<%# Bind("PTRDate") %>'
                  ToolTip="Value of PTR Date."
                  Enabled="False"
                  Width="140px"
                  CssClass="dmytxt"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_BankVCHNo" runat="server" Text="Bank Voucher No :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_BankVCHNo"
                  Text='<%# Bind("BankVCHNo") %>'
                  ToolTip="Value of Bank Voucher No."
                  Enabled="False"
                  Width="70px"
                  CssClass="dmytxt"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_BankVCHAmount" runat="server" Text="Bank Voucher Amount :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_BankVCHAmount"
                  Text='<%# Bind("BankVCHAmount") %>'
                  ToolTip="Value of Bank Voucher Amount."
                  Enabled="False"
                  BackColor="Aqua"
                  Width="126px"
                  CssClass="dmytxt"
                  Style="text-align: right"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_BankVCHDate" runat="server" Text="Bank Voucher Date :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_BankVCHDate"
                  Text='<%# Bind("BankVCHDate") %>'
                  ToolTip="Value of Bank Voucher Date."
                  Enabled="False"
                  Width="140px"
                  CssClass="dmytxt"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_AccountsRemarks" runat="server" Text="Accounts Remarks :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_AccountsRemarks"
                  Text='<%# Bind("AccountsRemarks") %>'
                  ToolTip="Value of Accounts Remarks."
                  Enabled="False"
                  Width="350px" Height="40px"
                  CssClass="dmytxt"
                  runat="server" />
              </td>
            </tr>
          </table>
        </td>
			</tr>
    </table>
	<br />
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSerpCreateTPTBill"
  DataObjectTypeName = "SIS.ERP.erpCreateTPTBill"
  SelectMethod = "erpCreateTPTBillGetByID"
  UpdateMethod="UZ_erpCreateTPTBillUpdate"
  DeleteMethod="UZ_erpCreateTPTBillDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpCreateTPTBill"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
