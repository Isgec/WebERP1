<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" ClientIDMode="Static" CodeFile="EF_erpCreateTPTBill.aspx.vb" Inherits="EF_erpCreateTPTBillx" title="Edit: Transporter Bill" %>
<asp:Content ID="CPHerpCreateTPTBill" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
  <asp:Label ID="LabelerpCreateTPTBill" runat="server" Text="&nbsp;Edit: Transporter Bill to Add Detention Bill"></asp:Label>
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
  <script type="text/javascript">
    function validate_tots(o, p) {
      o.value = o.value.replace(new RegExp('_', 'g'), '');
      var dec = /^\d+(?:\.\d{0,6})?$/;
      var v = o.value;
      if (v.match(dec)) {
        o.value = parseFloat(v).toFixed(p);
      } else {
        o.value = parseFloat('0').toFixed(p);
      }
      var aVal = o.id.split('_');
      var Prefix = aVal[0] + '_';
      var AssessableValue = $get(Prefix + 'AssessableValue');
      var CessRate = $get(Prefix + 'CessRate');
      var CessAmount = $get(Prefix + 'CessAmount');
      var TotalGST = $get(Prefix + 'TotalGST');
      var TotalAmount = $get(Prefix + 'TotalAmount');
      var IGSTRate = $get(Prefix + 'IGSTRate');
      var IGSTAmount = $get(Prefix + 'IGSTAmount');
      var SGSTRate = $get(Prefix + 'SGSTRate');
      var SGSTAmount = $get(Prefix + 'SGSTAmount');
      var CGSTRate = $get(Prefix + 'CGSTRate');
      var CGSTAmount = $get(Prefix + 'CGSTAmount');
      try {
        CessAmount.value = '0.00';
        if (parseFloat(CessRate.value) > 0)
          CessAmount.value = (parseFloat(CessRate.value) * parseFloat(AssessableValue.value) * 0.01).toFixed(2);
        if (parseFloat(IGSTRate.value) > 0)
          IGSTAmount.value = (parseFloat(IGSTRate.value) * parseFloat(AssessableValue.value) * 0.01).toFixed(2);
        if (parseFloat(SGSTRate.value) > 0)
          SGSTAmount.value = (parseFloat(SGSTRate.value) * parseFloat(AssessableValue.value) * 0.01).toFixed(2);
        if (parseFloat(CGSTRate.value) > 0)
          CGSTAmount.value = (parseFloat(CGSTRate.value) * parseFloat(AssessableValue.value) * 0.01).toFixed(2);
        TotalGST.value = (parseFloat(CessAmount.value) + parseFloat(IGSTAmount.value) + parseFloat(SGSTAmount.value) + parseFloat(CGSTAmount.value)).toFixed(2);
        TotalAmount.value = (parseFloat(AssessableValue.value) + parseFloat(TotalGST.value)).toFixed(2);
      } catch (e) { }
    }
  </script>

<asp:FormView ID="FVerpCreateTPTBill"
	runat = "server"
	DataKeyNames = "SerialNo"
	DataSourceID = "ODSerpCreateTPTBill"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
      <asp:Label ID="L_ErrMsgerpCreateTPTBill" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
      <table style="width:100%;">
        <tr><td colspan="2" style="border-top: solid 1pt LightGrey" ></td></tr>
        <tr id="trDet7" runat="server">
          <td style="text-align:center;">
            <asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Bold="true" Font-Underline="true" Text="FREIGHT" />
          </td>
          <td style="text-align:center;">
            <asp:Label ID="Label3" runat="server" Font-Size="Medium" Font-Bold="true" Font-Underline="true" Text="DETENTION" />
          </td>
        </tr>
        <tr>
          <td>
		        <table id="tblFreight" runat="server">
			        <tr>
				        <td class="alignright">
					        <b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No :" /></b>
				        </td>
				        <td>
					        <asp:TextBox ID="F_SerialNo" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
				        </td>
			        </tr>
			        <tr>
				        <td class="alignright"><b><asp:Label ID="L_irno" runat="server" Text="IR Number :" /></b>
				        </td>
				        <td>
					        <asp:TextBox ID="F_IRNumber" 
					          runat="server" 
						        CssClass = "dmytxt"
                    Enabled="false"
					          MaxLength="10" 
					          Width="90px"
					          ValidationGroup = "erpCreateTPTBill"
					          Text='<%# Bind("IRNumber") %>' />
				        </td>
			        </tr>
			        <tr>
				        <td class="alignright">
					        <b><asp:Label ID="L_TPTBillNo" runat="server" Text="Transporter Bill No. :" /></b>
				        </td>
				        <td>
					        <asp:TextBox ID="F_TPTBillNo"
						        Text='<%# Bind("TPTBillNo") %>'
						        CssClass = "dmytxt"
                    Enabled="false"
                    Width="210px"
						        runat="server" />
				        </td>
			        </tr>
			        <tr>
				        <td class="alignright">
					        <b><asp:Label ID="L_TPTBillDate" runat="server" Text="Transporter Bill Date :" /></b>
				        </td>
				        <td>
					        <asp:TextBox ID="F_TPTBillDate"
						        Text='<%# Bind("TPTBillDate") %>'
                    Width="90px"
						        CssClass = "dmytxt"
                    Enabled="false"
						        runat="server" />
				        </td>
			        </tr>
			        <tr>
				        <td class="alignright">
					        <b><asp:Label ID="L_TPTBillReceivedOn" runat="server" Text="Tpt. Bill Received On :" /></b>
				        </td>
				        <td>
					        <asp:TextBox ID="F_TPTBillReceivedOn"
						        Text='<%# Bind("TPTBillReceivedOn") %>'
                    Width="90px"
						        CssClass = "dmytxt"
                    Enabled="false"
						        runat="server" />
				        </td>
			        </tr>
			        <tr>
				        <td class="alignright">
					        <b><asp:Label ID="L_GRNos" runat="server" Text="GR Nos. :" /></b>
				        </td>
				        <td>
					        <asp:TextBox ID="F_GRNos"
						        Text='<%# Bind("GRNos") %>'
						        CssClass = "dmytxt"
                    Enabled="false"
                    Width="350px" 
						        runat="server" />
				        </td>
			        </tr>
			        <tr>
				        <td class="alignright">
					        <b><asp:Label ID="L_TPTCode" runat="server" Text="Transporter Code :" /></b>
				        </td>
                <td>
					        <asp:TextBox
						        ID = "F_TPTCode"
						        Text='<%# Bind("TPTCode") %>'
                    Width="90px"
						        CssClass = "dmytxt"
                    Enabled="false"
						        Runat="Server" />
					        <asp:Label
						        ID = "F_TPTCode_Display"
						        Text='<%# Eval("VR_Transporters10_TransporterName") %>'
						        Runat="Server" />
                </td>
			        </tr>
			        <tr>
				        <td class="alignright">
					        <b><asp:Label ID="L_PONumber" runat="server" Text="Purchase Order No. :" /></b>
				        </td>
				        <td>
					        <asp:TextBox ID="F_PONumber"
						        Text='<%# Bind("PONumber") %>'
						        CssClass = "dmytxt"
                    Enabled="false"
                    Width="90px"
						        runat="server" />
				        </td>
			        </tr>
			        <tr>
				        <td class="alignright">
					        <b><asp:Label ID="L_ProjectID" runat="server" Text="Project ID :" /></b>
				        </td>
                <td>
					        <asp:TextBox
						        ID = "F_ProjectID"
						        Text='<%# Bind("ProjectID") %>'
						        CssClass = "dmytxt"
                    Enabled="false"
                    Width="90px"
						        Runat="Server" />
					        <asp:Label
						        ID = "F_ProjectID_Display"
						        Text='<%# Eval("IDM_Projects9_Description") %>'
						        Runat="Server" />
                </td>
			        </tr>
			        <tr>
				        <td class="alignright">
					        <b><asp:Label ID="L_TPTBillAmount" runat="server" Text="Tpt. Bill Amount :" /></b>
				        </td>
				        <td>
					        <asp:TextBox ID="F_TPTBillAmount"
						        Text='<%# Bind("TPTBillAmount") %>'
                    Width="100px"
						        CssClass = "dmytxt"
                    Enabled="false"
						        runat="server" />
				        </td>
			        </tr>
			        <tr>
				        <td class="alignright">
					        <b><asp:Label ID="L_BasicFreightValue" runat="server" Text="Basic Freight Charge :" /></b>
				        </td>
				        <td>
					        <asp:TextBox ID="F_BasicFreightValue"
						        Text='<%# Bind("BasicFreightValue") %>'
                    Width="100px"
						        CssClass = "dmytxt"
                    Enabled="false"
						        style="text-align: right"
						        runat="server" />
				        </td>
			        </tr>
			        <tr>
				        <td class="alignright">
					        <b><asp:Label ID="L_BasicFvODC" runat="server" Text="ODC Charges :" /></b>
				        </td>
				        <td>
					        <asp:TextBox ID="F_BasicFvODC"
						        Text='<%# Bind("BasicFvODC") %>'
                    Width="100px"
						        CssClass = "dmytxt"
                    Enabled="false"
						        style="text-align: right"
						        runat="server" />
				        </td>
			        </tr>
			        <tr>
				        <td class="alignright">
					        <b><asp:Label ID="L_ODCChargesInContract" runat="server" Text="Additional ODC Charges In Contract :" /></b>
				        </td>
				        <td>
					        <asp:TextBox ID="F_ODCChargesInContract"
						        Text='<%# Bind("ODCChargesInContract") %>'
                    Width="100px"
						        CssClass = "dmytxt"
                    Enabled="false"
						        style="text-align: right"
						        runat="server" />
				        </td>
			        </tr>
			        <tr>
				        <td class="alignright">
					        <b><asp:Label ID="L_ODCChargesOutOfContract" runat="server" Text="Additional ODC Charges Out Of Contract :" /></b>
				        </td>
				        <td>
					        <asp:TextBox ID="F_ODCChargesOutOfContract"
						        Text='<%# Bind("ODCChargesOutOfContract") %>'
                    Width="100px"
						        CssClass = "dmytxt"
                    Enabled="false"
						        style="text-align: right"
						        runat="server" />
				        </td>
			        </tr>
              <tr>
                <td class="alignright">
                  <b><asp:Label ID="L_BackToTownCharges" runat="server" Text="Back to town charges :" /></b>
                </td>
                <td>
                  <asp:TextBox ID="F_BackToTownCharges"
                    Text='<%# Bind("BackToTownCharges") %>'
                    Width="100px"
						        CssClass = "dmytxt"
                    Enabled="false"
						        style="text-align: right"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b><asp:Label ID="L_TarpaulinCharges" runat="server" Text="Tarpaulin charges :" /></b>
                </td>
                <td>
                  <asp:TextBox ID="F_TarpaulinCharges"
                    Text='<%# Bind("TarpaulinCharges") %>'
                    Width="100px"
						        CssClass = "dmytxt"
                    Enabled="false"
						        style="text-align: right"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b><asp:Label ID="L_WoodenSleeperCharges" runat="server" Text="Wooden Sleeper charges :" /></b>
                </td>
                <td>
                  <asp:TextBox ID="F_WoodenSleeperCharges"
                    Text='<%# Bind("WoodenSleeperCharges") %>'
                    Width="100px"
						        CssClass = "dmytxt"
                    Enabled="false"
						        style="text-align: right"
                    runat="server" />
                </td>
              </tr>
			        <tr>
				        <td class="alignright">
					        <b><asp:Label ID="L_EmptyReturnCharges" runat="server" Text="Empty Return Charges :" /></b>
				        </td>
				        <td>
					        <asp:TextBox ID="F_EmptyReturnCharges"
						        Text='<%# Bind("EmptyReturnCharges") %>'
                    Width="100px"
						        CssClass = "dmytxt"
                    Enabled="false"
						        style="text-align: right"
						        runat="server" />
				        </td>
			        </tr>
			        <tr>
				        <td class="alignright">
					        <b><asp:Label ID="L_RTOChallanAmount" runat="server" Text="RTO Challan Amount :" /></b>
				        </td>
				        <td>
					        <asp:TextBox ID="F_RTOChallanAmount"
						        Text='<%# Bind("RTOChallanAmount") %>'
                    Width="100px"
						        CssClass = "dmytxt"
                    Enabled="false"
						        style="text-align: right"
						        runat="server" />
				        </td>
			        </tr>
			        <tr>
				        <td class="alignright">
					        <b><asp:Label ID="L_OtherAmount" runat="server" Text="Other Charges :" /></b>
				        </td>
				        <td>
					        <asp:TextBox ID="F_OtherAmount"
						        Text='<%# Bind("OtherAmount") %>'
                    Width="100px"
						        CssClass = "dmytxt"
                    Enabled="false"
						        style="text-align: right"
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
						              CssClass = "dmytxt"
                          Enabled="false"
                          Style="text-align: Right"
                          ValidationGroup="spmtSupplierBill"
                          MaxLength="20"
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
						              CssClass = "dmytxt"
                          Enabled="false"
                          ValidationGroup="spmtSupplierBill"
                          MaxLength="20"
                          runat="server" />
                      </td>
                      <td class="alignright">
                        <asp:Label ID="L_IGSTAmount" runat="server" Text="IGST Amount :" />&nbsp;
                      </td>
                      <td>
                        <asp:TextBox ID="F_IGSTAmount"
                          Text='<%# Bind("IGSTAmount") %>'
                          Width="168px"
						              CssClass = "dmytxt"
                          Enabled="false"
                          Style="text-align: right"
                          ValidationGroup="spmtSupplierBill"
                          MaxLength="20"
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
						              CssClass = "dmytxt"
                          Enabled="false"
                          Style="text-align: Right"
                          ValidationGroup="spmtSupplierBill"
                          MaxLength="20"
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
                          Width="168px"
						              CssClass = "dmytxt"
                          Enabled="false"
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
						              CssClass = "dmytxt"
                          Enabled="false"
                          Style="text-align: Right"
                          ValidationGroup="spmtSupplierBill"
                          MaxLength="20"
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
                          Width="168px"
						              CssClass = "dmytxt"
                          Enabled="false"
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
						              CssClass = "dmytxt"
                          Enabled="false"
                          Style="text-align: Right"
                          ValidationGroup="spmtSupplierBill"
                          MaxLength="20"
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
                          Width="168px"
						              CssClass = "dmytxt"
                          Enabled="false"
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
					        <b><asp:Label ID="L_CreatedBy" runat="server" Text="Concerned Person [Materials] :" /></b>
				        </td>
                <td>
					        <asp:TextBox
						        ID = "F_CreatedBy"
						        CssClass = "myfktxt"
                    Width="56px"
						        Text='<%# Bind("CreatedBy") %>'
						        AutoCompleteType = "None"
						        onfocus = "return this.select();"
                    ToolTip="Enter value for Concerned Person [Materials]."
						        ValidationGroup = "erpCreateTPTBill"
                    onblur= "script_erpCreateTPTBill.validate_CreatedBy(this);"
						        Runat="Server" />
					        <asp:Label
						        ID = "F_CreatedBy_Display"
						        Text='<%# Eval("aspnet_Users4_UserFullName") %>'
						        Runat="Server" />
					        <asp:RequiredFieldValidator 
						        ID = "RFVCreatedBy"
						        runat = "server"
						        ControlToValidate = "F_CreatedBy"
						        Text = "Forwarded To [Accounts Emp.] is required."
						        ErrorMessage = "[Required!]"
						        Display = "Dynamic"
						        EnableClientScript = "true"
						        ValidationGroup = "erpCreateTPTBill"
						        SetFocusOnError="true" />
                  <AJX:AutoCompleteExtender
                    ID="ACECreatedBy"
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
						        CompletionListCssClass = "autocomplete_completionListElement"
						        CompletionListItemCssClass = "autocomplete_listItem"
						        CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
                    Runat="Server" />
                </td>
			        </tr>
			        <tr>
				        <td class="alignright">
					        <b><asp:Label ID="L_DiscReturnedToByAC" runat="server" Text="Forwarded To [Accounts Emp.] :" /></b>
				        </td>
                <td>
					        <asp:TextBox
						        ID = "F_DiscReturnedToByAC"
						        CssClass = "myfktxt"
                    Width="56px"
						        Text='<%# Bind("DiscReturnedToByAC") %>'
						        AutoCompleteType = "None"
						        onfocus = "return this.select();"
                    ToolTip="Enter value for Forwarded To [Accounts Emp.]."
						        ValidationGroup = "erpCreateTPTBill"
                    onblur= "script_erpCreateTPTBill.validate_DiscReturnedToByAC(this);"
						        Runat="Server" />
					        <asp:Label
						        ID = "F_DiscReturnedToByAC_Display"
						        Text='<%# Eval("aspnet_Users4_UserFullName") %>'
						        Runat="Server" />
					        <asp:RequiredFieldValidator 
						        ID = "RFVDiscReturnedToByAC"
						        runat = "server"
						        ControlToValidate = "F_DiscReturnedToByAC"
						        Text = "Forwarded To [Accounts Emp.] is required."
						        ErrorMessage = "[Required!]"
						        Display = "Dynamic"
						        EnableClientScript = "true"
						        ValidationGroup = "erpCreateTPTBill"
						        SetFocusOnError="true" />
                  <AJX:AutoCompleteExtender
                    ID="ACEDiscReturnedToByAC"
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
						        CompletionListCssClass = "autocomplete_completionListElement"
						        CompletionListItemCssClass = "autocomplete_listItem"
						        CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
                    Runat="Server" />
                </td>
			        </tr>
			        <tr>
				        <td class="alignright">
					        <b><asp:Label ID="L_LgstRemarks" runat="server" Text="Logistics Remarks :" /></b>
				        </td>
				        <td>
					        <asp:TextBox ID="F_LgstRemarks"
						        Text='<%# Bind("LgstRemarks") %>'
						        CssClass = "mytxt"
						        onfocus = "return this.select();"
                    onblur= "this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter value for Logistics Remarks."
						        MaxLength="500"
                    Width="350px" Height="40px" TextMode="MultiLine"
						        runat="server" />
				        </td>
			        </tr>
		        </table>
          </td>
          <td style="vertical-align:top;">
            <table id="tblDetention" runat="server">
              <tr>
                <td class="alignright">
                  <b><asp:Label ID="M_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No :" /></b>
                </td>
                <td>
                  <asp:TextBox ID="D_SerialNo" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
                </td>
              </tr>
              <tr>
                <td class="alignright"><b><asp:Label ID="M_irno" runat="server" Text="IR Number :" /></b>
                </td>
                <td>
                  <asp:TextBox ID="D_IRNumber" 
                    runat="server" 
                    CssClass="mytxt" 
                    MaxLength="10" 
                    Width="80px"
                    ValidationGroup = "erpCreateTPTBill"
                    Text='<%# Bind("dIRNumber") %>' />
                  <input type="button" id="getDIRData" value="Get IR Details from ERP" onclick="script_erpCreateTPTBill.getIRData('D_IRNumber');" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b><asp:Label ID="M_TPTBillNo" runat="server" Text="Transporter Bill No. :" /></b>
                </td>
                <td>
                  <asp:TextBox ID="D_TPTBillNo"
                    Text='<%# Bind("dTPTBillNo") %>'
						        CssClass = "dmytxt"
                    Enabled="false"
                    Width="210px"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b><asp:Label ID="M_TPTBillDate" runat="server" Text="Transporter Bill Date :" /></b>
                </td>
                <td>
                  <asp:TextBox ID="D_TPTBillDate"
                    Text='<%# Bind("dTPTBillDate") %>'
                    Width="90px"
						        CssClass = "dmytxt"
                    Enabled="false"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b><asp:Label ID="M_TPTBillReceivedOn" runat="server" Text="Tpt. Bill Received On :" /></b>
                </td>
                <td>
                  <asp:TextBox ID="D_TPTBillReceivedOn"
                    Text='<%# Bind("dTPTBillReceivedOn") %>'
                    Width="90px"
						        CssClass = "dmytxt"
                    Enabled="false"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b><asp:Label ID="M_GRNos" runat="server" Text="GR Nos. :" /></b>
                </td>
                <td>
                  <asp:TextBox ID="D_GRNos"
                    Text='<%# Bind("dGRNos") %>'
						        CssClass = "dmytxt"
                    Enabled="false"
                    Width="350px" 
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b><asp:Label ID="M_TPTCode" runat="server" Text="Transporter Code :" /></b>
                </td>
                <td>
                  <asp:TextBox
                    ID = "D_TPTCode"
                    Text='<%# Bind("dTPTCode") %>'
                    Width="90px"
						        CssClass = "dmytxt"
                    Enabled="false"
                    Runat="Server" />
                  <asp:Label
                    ID = "D_TPTCode_Display"
                    Runat="Server" />
<%--                    Text='<%# Eval("dVR_Transporters10_TransporterName") %>'--%>
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b><asp:Label ID="M_PONumber" runat="server" Text="Purchase Order No. :" /></b>
                </td>
                <td>
                  <asp:TextBox ID="D_PONumber"
                    Text='<%# Bind("dPONumber") %>'
                    Width="90px"
						        CssClass = "dmytxt"
                    Enabled="false"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b><asp:Label ID="M_ProjectID" runat="server" Text="Project ID :" /></b>
                </td>
                <td>
                  <asp:TextBox
                    ID = "D_ProjectID"
						        CssClass = "dmytxt"
                    Enabled="false"
                    Width="90px"
                    Text='<%# Bind("dProjectID") %>'
                    Runat="Server" />
                  <asp:Label
                    ID = "D_ProjectID_Display"
                    Runat="Server" />
<%--                    Text='<%# Eval("dIDM_Projects9_Description") %>'--%>
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b><asp:Label ID="M_TPTBillAmount" runat="server" Text="Tpt. Bill Amount :" /></b>
                </td>
                <td>
                  <asp:TextBox ID="D_TPTBillAmount"
                    Text='<%# Bind("dTPTBillAmount") %>'
                    Width="100px"
						        CssClass = "dmytxt"
                    Enabled="false"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b><asp:Label ID="M_DetentionatLP" runat="server" Text="Detention at Loading Point :" /></b>
                </td>
                <td>
                  <asp:TextBox ID="D_DetentionatLP"
                    Text='<%# Bind("dDetentionatLP") %>'
                    Width="100px"
						        CssClass = "mytxt"
						        style="text-align: right"
						        onfocus = "return this.select();"
                    onblur="return dc(this,2);"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b><asp:Label ID="M_DetentionatDaysLP" runat="server" Text="Detention Days at Loading Point :" /></b>
                </td>
                <td>
                  <asp:TextBox ID="D_DetentionatDaysLP"
                    Text='<%# Bind("dDetentionatDaysLP") %>'
                    Width="100px"
						        CssClass = "mytxt"
						        style="text-align: right"
						        onfocus = "return this.select();"
                    onblur="return dc(this,0);"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b><asp:Label ID="LabelDLPisISGECWorks" runat="server" Text="Loading Point is ISGEC Works :" /></b>
                </td>
                <td>
                    <asp:CheckBox ID="CheckBoxDLPisISGECWorks"
                      Checked='<%# Bind("dLPisISGECWorks") %>'
                      runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b><asp:Label ID="M_DetentionatULP" runat="server" Text="Detention at UnLoading Point :" /></b>
                </td>
                <td>
                  <asp:TextBox ID="D_DetentionatULP"
                    Text='<%# Bind("dDetentionatULP") %>'
                    Width="100px"
						        CssClass = "mytxt"
						        style="text-align: right"
						        onfocus = "return this.select();"
                    onblur="return dc(this,2);"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b><asp:Label ID="M_DetentionatDaysULP" runat="server" Text="Detention Days at Unloading Point :" /></b>
                </td>
                <td>
                  <asp:TextBox ID="D_DetentionatDaysULP"
                    Text='<%# Bind("dDetentionatDaysULP") %>'
                    Width="100px"
						        CssClass = "mytxt"
						        style="text-align: right"
						        onfocus = "return this.select();"
                    onblur="return dc(this,0);"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b><asp:Label ID="LabelDULPisICDCFSPort" runat="server" Text="Unloading Point is ICD/CFS/Port :" /></b>
                </td>
                <td>
                    <asp:CheckBox ID="CheckBoxDULPisICDCFSPort"
                      Checked='<%# Bind("dULPisICDCFSPort") %>'
                      runat="server" />
                </td>
              </tr>
              <tr>
                <td colspan="2">
                  <table>
                    <tr>
                      <td class="alignright">
                        <asp:Label ID="M_AssessableValue" runat="server" Text="Basic / Assessable Value :" /><span style="color: red">*</span>
                      </td>
                      <td colspan="3">
                        <asp:TextBox ID="D_AssessableValue"
                          Text='<%# Bind("dAssessableValue") %>'
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
                        <asp:Label ID="M_IGSTRate" runat="server" Text="IGST % [Rate] :" />
                      </td>
                      <td>
                        <asp:TextBox ID="D_IGSTRate"
                          Text='<%# Bind("dIGSTRate") %>'
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
                        <asp:Label ID="M_IGSTAmount" runat="server" Text="IGST Amount :" />&nbsp;
                      </td>
                      <td>
                        <asp:TextBox ID="D_IGSTAmount"
                          Text='<%# Bind("dIGSTAmount") %>'
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
                        <asp:Label ID="M_CGSTRate" runat="server" Text="CGST % [Rate] :" />
                      </td>
                      <td>
                        <asp:TextBox ID="D_CGSTRate"
                          Text='<%# Bind("dCGSTRate") %>'
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
                        <asp:Label ID="M_CGSTAmount" runat="server" Text="CGST Amount :" />&nbsp;
                      </td>
                      <td>
                        <asp:TextBox ID="D_CGSTAmount"
                          Text='<%# Bind("dCGSTAmount") %>'
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
                        <asp:Label ID="M_SGSTRate" runat="server" Text="SGST % [Rate] :" />
                      </td>
                      <td>
                        <asp:TextBox ID="D_SGSTRate"
                          Text='<%# Bind("dSGSTRate") %>'
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
                        <asp:Label ID="M_SGSTAmount" runat="server" Text="SGST Amount :" />&nbsp;
                      </td>
                      <td>
                        <asp:TextBox ID="D_SGSTAmount"
                          Text='<%# Bind("dSGSTAmount") %>'
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
                        <asp:Label ID="M_CessRate" runat="server" Text="Cess % [Rate] :" />
                      </td>
                      <td>
                        <asp:TextBox ID="D_CessRate"
                          Text='<%# Bind("dCessRate") %>'
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
                        <asp:Label ID="M_CessAmount" runat="server" Text="Cess Amount :" />&nbsp;
                      </td>
                      <td>
                        <asp:TextBox ID="D_CessAmount"
                          Text='<%# Bind("dCessAmount") %>'
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
                        <asp:Label ID="M_TotalGST" runat="server" Text="Total GST :" />&nbsp;
                      </td>
                      <td>
                        <asp:TextBox ID="D_TotalGST"
                          Text='<%# Bind("dTotalGST") %>'
                          Enabled="False"
                          Width="168px"
                          CssClass="dmytxt"
                          Style="text-align: right"
                          runat="server" />
                      </td>
                      <td class="alignright">
                        <asp:Label ID="M_TotalAmount" runat="server" Text="Total Amount :" />&nbsp;
                      </td>
                      <td>
                        <asp:TextBox ID="D_TotalAmount"
                          Text='<%# Bind("dTotalAmount") %>'
                          Enabled="False"
                          Width="168px"
                          CssClass="dmytxt"
                          Style="text-align: right"
                          runat="server" />
                      </td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
		</div>
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSerpCreateTPTBill"
  DataObjectTypeName = "SIS.ERP.erpCreateTPTBill"
  SelectMethod = "erpCreateTPTBillGetByID"
  UpdateMethod="UZ_erpCreateTPTBillUpdateUnlocked"
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
