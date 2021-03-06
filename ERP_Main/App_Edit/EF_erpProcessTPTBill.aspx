<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" ClientIDMode="Static" CodeFile="EF_erpProcessTPTBill.aspx.vb" Inherits="EF_erpProcessTPTBill" title="Edit: Process Transporter Bill" %>
<asp:Content ID="CPHerpProcessTPTBill" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
  <asp:Label ID="LabelerpProcessTPTBill" runat="server" Text="&nbsp;Edit: Process Transporter Bill"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLerpProcessTPTBill" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLerpProcessTPTBill"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "erpProcessTPTBill"
    runat = "server" />
<asp:FormView ID="FVerpProcessTPTBill"
	runat = "server"
	DataKeyNames = "SerialNo"
	DataSourceID = "ODSerpProcessTPTBill"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <table style="width: 100%;">
      <tr>
        <td style="vertical-align: top;">
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
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="Label3" runat="server" ForeColor="#CC6633" Text="Clubed No :" /></b>
              </td>
              <td>
                <asp:TextBox ID="TextBox1"
                  Text='<%# Bind("ClubbingNo") %>'
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
                  <asp:Label ID="Label2" runat="server" ForeColor="#CC6633" Text="IR Number No :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_IRNumber"
                  Text='<%# Bind("IRNumber") %>'
                  ToolTip="Value of Serial No."
                  Enabled="False"
                  CssClass="mypktxt"
                  Width="70px"
                  Style="text-align: right"
                  runat="server" />
                <input type="button" id="getIRData" value="Get Payment Details from ERP" onclick="script_erpProcessTPTBill.getIRData('F_IRNumber','F_ProjectID');" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_PTRNo" runat="server" Text="PTR No :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_PTRNo"
                  Text='<%# Bind("PTRNo") %>'
                  Width="70px"
                  CssClass="mytxt"
                  onfocus="return this.select();"
                  ValidationGroup="erpProcessTPTBill"
                  onblur="this.value=this.value.replace(/\'/g,'');"
                  ToolTip="Enter value for PTR No."
                  MaxLength="10"
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
                  Style="text-align: right"
                  Width="70px"
                  CssClass="mytxt"
                  ValidationGroup="erpProcessTPTBill"
                  MaxLength="20"
                  onfocus="return this.select();"
                  onblur="return dc(this,2);"
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
                  Width="70px"
                  CssClass="mytxt"
                  onfocus="return this.select();"
                  ValidationGroup="erpProcessTPTBill"
                  runat="server" />
                <asp:Image ID="ImageButtonPTRDate" runat="server" ToolTip="Click to open calendar" Style="cursor: pointer" ImageUrl="~/Images/cal.png" />
                <AJX:CalendarExtender
                  ID="CEPTRDate"
                  TargetControlID="F_PTRDate"
                  Format="dd/MM/yyyy"
                  runat="server" CssClass="MyCalendar" PopupButtonID="ImageButtonPTRDate" />
                <AJX:MaskedEditExtender
                  ID="MEEPTRDate"
                  runat="server"
                  Mask="99/99/9999"
                  MaskType="Date"
                  CultureName="en-GB"
                  MessageValidatorTip="true"
                  InputDirection="LeftToRight"
                  ErrorTooltipEnabled="true"
                  TargetControlID="F_PTRDate" />
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
                  Width="100px"
                  CssClass="mytxt"
                  onfocus="return this.select();"
                  ValidationGroup="erpProcessTPTBill"
                  onblur="this.value=this.value.replace(/\'/g,'');"
                  ToolTip="Enter value for Bank Voucher No."
                  MaxLength="15"
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
                  Style="text-align: right"
                  Width="70px"
                  CssClass="mytxt"
                  ValidationGroup="erpProcessTPTBill"
                  MaxLength="20"
                  onfocus="return this.select();"
                  onblur="return dc(this,2);"
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
                  Width="70px"
                  CssClass="mytxt"
                  onfocus="return this.select();"
                  ValidationGroup="erpProcessTPTBill"
                  runat="server" />
                <asp:Image ID="ImageButtonBankVCHDate" runat="server" ToolTip="Click to open calendar" Style="cursor: pointer" ImageUrl="~/Images/cal.png" />
                <AJX:CalendarExtender
                  ID="CEBankVCHDate"
                  TargetControlID="F_BankVCHDate"
                  Format="dd/MM/yyyy"
                  runat="server" CssClass="MyCalendar" PopupButtonID="ImageButtonBankVCHDate" />
                <AJX:MaskedEditExtender
                  ID="MEEBankVCHDate"
                  runat="server"
                  Mask="99/99/9999"
                  MaskType="Date"
                  CultureName="en-GB"
                  MessageValidatorTip="true"
                  InputDirection="LeftToRight"
                  ErrorTooltipEnabled="true"
                  TargetControlID="F_BankVCHDate" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="Label1" BackColor="Yellow" runat="server" Text="Close when Payment Adjusted :" /></b>
              </td>
              <td>
                <asp:DropDownList
                  ID="F_NewBillStatus"
                  Width="200px"
                  Text='<%# Bind("NewBillStatus") %>'
                  CssClass="myfktxt"
                  runat="Server">
                  <asp:ListItem Text="----Select----" Value="" />
                  <asp:ListItem Text="Closed" Value="8" />
                </asp:DropDownList>
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_ReasonID" runat="server" Text="Reason ID :" /></b>
              </td>
              <td>
                <LGM:LC_erpTPTBillReasons
                  ID="F_ReasonID"
                  SelectedValue='<%# Bind("ReasonID") %>'
                  OrderBy="DisplayField"
                  DataTextField="DisplayField"
                  DataValueField="PrimaryKey"
                  IncludeDefault="true"
                  DefaultText="-- Select --"
                  Width="350px"
                  CssClass="myfktxt"
                  runat="Server" />
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
                  Width="350px" Height="40px" TextMode="MultiLine"
                  CssClass="mytxt"
                  onfocus="return this.select();"
                  ValidationGroup="erpProcessTPTBill"
                  onblur="this.value=this.value.replace(/\'/g,'');"
                  ToolTip="Enter value for Accounts Remarks."
                  MaxLength="500"
                  runat="server" />
                <asp:Button ID="cmdSaveNReturn" runat="server" Text="Save And Return" OnClientClick="return confirm('Save and Return document?');" OnClick="SaveAndReturn" CommandArgument='<%#Eval("SerialNo") %>' />
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
        <td style="vertical-align: top;">
          <table>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_DiscReturnedToByAC" runat="server" Text="Forwarded To [Accounts Emp.] :" /></b>
              </td>
              <td>
                <asp:TextBox
                  ID="F_DiscReturnedToByAC"
                  Width="56px"
                  Text='<%# Bind("DiscReturnedToByAC") %>'
                  Enabled="False"
                  ToolTip="Value of Disc.Doc. Returned To."
                  CssClass="dmyfktxt"
                  runat="Server" />
                <asp:Label
                  ID="F_DiscReturnedToByAC_Display"
                  Text='<%# Eval("aspnet_Users4_UserFullName") %>'
                  runat="Server" />
              </td>
            </tr>
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
      </tr>
      <tr>
        <td style="vertical-align: top;">
          <table>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_TPTCode" runat="server" Text="Transporter Code :" /></b>
              </td>
              <td>
                <asp:TextBox
                  ID="F_TPTCode"
                  Width="63px"
                  Text='<%# Bind("TPTCode") %>'
                  Enabled="False"
                  ToolTip="Value of Transporter Code."
                  CssClass="dmyfktxt"
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
                  <asp:Label ID="L_TPTBillNo" runat="server" Text="Transporter Bill No. :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_TPTBillNo"
                  Text='<%# Bind("TPTBillNo") %>'
                  ToolTip="Value of Transporter Bill No.."
                  Enabled="False"
                  Width="210px"
                  CssClass="dmytxt"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_TPTBillDate" runat="server" Text="Transporter Bill Date :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_TPTBillDate"
                  Text='<%# Bind("TPTBillDate") %>'
                  ToolTip="Value of Transporter Bill Date."
                  Enabled="False"
                  Width="140px"
                  CssClass="dmytxt"
                  runat="server" />
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
                  ToolTip="Value of Tpt. Bill Amount."
                  Enabled="False"
                  Width="126px"
                  CssClass="dmytxt"
                  Style="text-align: right"
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
                  ToolTip="Value of Tpt. Bill Received On."
                  Enabled="False"
                  Width="140px"
                  CssClass="dmytxt"
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
                  ToolTip="Value of GR Nos.."
                  Enabled="False"
                  Width="350px" Height="40px"
                  CssClass="dmytxt"
                  runat="server" />
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
                  ToolTip="Value of Purchase Order No.."
                  Enabled="False"
                  Width="63px"
                  CssClass="dmytxt"
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
                  Width="42px"
                  Text='<%# Bind("ProjectID") %>'
                  Enabled="False"
                  ToolTip="Value of Project ID."
                  CssClass="dmyfktxt"
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
                  <asp:Label ID="L_ChequeNo" runat="server" Text="Cheque No :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_ChequeNo"
                  Text='<%# Bind("ChequeNo") %>'
                  ToolTip="Value of Cheque No."
                  Enabled="False"
                  Width="140px"
                  CssClass="dmytxt"
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
                  ToolTip="Value of Logistics Remarks."
                  Enabled="False"
                  Width="350px" Height="40px"
                  CssClass="dmytxt"
                  runat="server" />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" /></b>
              </td>
              <td>
                <asp:TextBox
                  ID="F_CreatedBy"
                  Width="56px"
                  Text='<%# Bind("CreatedBy") %>'
                  Enabled="False"
                  ToolTip="Value of Created By."
                  CssClass="dmyfktxt"
                  runat="Server" />
                <asp:Label
                  ID="F_CreatedBy_Display"
                  Text='<%# Eval("aspnet_Users7_UserFullName") %>'
                  runat="Server" />
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
        <td style="vertical-align: top;">
          <table>
            <tr>
              <td class="alignright">
                <b>
                  <asp:Label ID="L_BasicFreightValue" runat="server" Text="Basic Freight Charge :" /></b>
              </td>
              <td>
                <asp:TextBox ID="F_BasicFreightValue"
                  Text='<%# Bind("BasicFreightValue") %>'
                  ToolTip="Value of Basic Freight Value."
                  Enabled="False"
                  Width="126px"
                  CssClass="dmytxt"
                  Style="text-align: right"
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
                  ToolTip="Value of Basic Freight Value ODC."
                  Enabled="False"
                  Width="126px"
                  CssClass="dmytxt"
                  Style="text-align: right"
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
                  ToolTip="Value of Detention at Loading Point."
                  Enabled="False"
                  Width="126px"
                  CssClass="dmytxt"
                  Style="text-align: right"
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
                  Width="70px"
                  CssClass="dmytxt"
                  Enabled="false"
                  Style="text-align: right"
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
                  CssClass="dmytxt"
                  Enabled="false"
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
                  Width="70px"
                  CssClass="dmytxt"
                  Enabled="false"
                  Style="text-align: right"
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
                  Width="70px"
                  Style="text-align: right"
                  CssClass="dmytxt"
                  Enabled="false"
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
                  CssClass="dmytxt"
                  Enabled="false"
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
                  Width="70px"
                  CssClass="dmytxt"
                  Enabled="false"
                  Style="text-align: right"
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
                  Width="70px"
                  CssClass="dmytxt"
                  Enabled="false"
                  Style="text-align: right"
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
                  Width="70px"
                  CssClass="dmytxt"
                  Enabled="false"
                  Style="text-align: right"
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
                  ToolTip="Value of ODC Charges In Contract."
                  Enabled="False"
                  Width="126px"
                  CssClass="dmytxt"
                  Style="text-align: right"
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
                  ToolTip="Value of ODC Charges Out Of Contract."
                  Enabled="False"
                  Width="126px"
                  CssClass="dmytxt"
                  Style="text-align: right"
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
                  ToolTip="Value of Empty Return Charges."
                  Enabled="False"
                  Width="126px"
                  CssClass="dmytxt"
                  Style="text-align: right"
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
                  ToolTip="Value of RTO Challan Amount."
                  Enabled="False"
                  Width="126px"
                  CssClass="dmytxt"
                  Style="text-align: right"
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
                  ToolTip="Value of Other Amount."
                  Enabled="False"
                  Width="126px"
                  CssClass="dmytxt"
                  Style="text-align: right"
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
                          Style="text-align: Right"
                          Enabled="False"
                          CssClass="dmytxt"
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
                          Style="text-align: Right"
                          Enabled="False"
                          CssClass="dmytxt"
                          runat="server" />
                      </td>
                      <td class="alignright">
                        <asp:Label ID="L_IGSTAmount" runat="server" Text="IGST Amount :" />&nbsp;
                      </td>
                      <td>
                        <asp:TextBox ID="F_IGSTAmount"
                          Text='<%# Bind("IGSTAmount") %>'
                          Width="168px"
                          Style="text-align: right"
                          Enabled="False"
                          CssClass="dmytxt"
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
                          Style="text-align: Right"
                          Enabled="False"
                          CssClass="dmytxt"
                          runat="server" />
                      </td>
                      <td class="alignright">
                        <asp:Label ID="L_CGSTAmount" runat="server" Text="CGST Amount :" />&nbsp;
                      </td>
                      <td>
                        <asp:TextBox ID="F_CGSTAmount"
                          Text='<%# Bind("CGSTAmount") %>'
                          Enabled="False"
                          CssClass="dmytxt"
                          Width="168px"
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
                          Style="text-align: Right"
                          Enabled="False"
                          CssClass="dmytxt"
                          runat="server" />
                      </td>
                      <td class="alignright">
                        <asp:Label ID="L_SGSTAmount" runat="server" Text="SGST Amount :" />&nbsp;
                      </td>
                      <td>
                        <asp:TextBox ID="F_SGSTAmount"
                          Text='<%# Bind("SGSTAmount") %>'
                          Width="168px"
                          Enabled="False"
                          CssClass="dmytxt"
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
                          Style="text-align: Right"
                          Enabled="False"
                          CssClass="dmytxt"
                          runat="server" />
                      </td>
                      <td class="alignright">
                        <asp:Label ID="L_CessAmount" runat="server" Text="Cess Amount :" />&nbsp;
                      </td>
                      <td>
                        <asp:TextBox ID="F_CessAmount"
                          Text='<%# Bind("CessAmount") %>'
                          Width="168px"
                          Enabled="False"
                          CssClass="dmytxt"
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
                  ToolTip="Value of Total Bill Passed Amount."
                  Enabled="False"
                  BackColor="Aqua"
                  Width="126px"
                  CssClass="dmytxt"
                  Style="text-align: right"
                  runat="server" />
              </td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSerpProcessTPTBill"
  DataObjectTypeName = "SIS.ERP.erpProcessTPTBill"
  SelectMethod = "erpProcessTPTBillGetByID"
  UpdateMethod="UZ_erpProcessTPTBillUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpProcessTPTBill"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
  </div>
</asp:Content>
