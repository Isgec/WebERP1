<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_ErectionDrawingList_YNR.aspx.vb" Inherits="GF_ErectionDrawingList_YNR" title="List: Released Drawing List For Shop" %>
<asp:Content ID="CPHlgDMisg" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaBH" runat="server" Text="&nbsp;List: Released Documents for Shop"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLlgDMisg" runat="server">
  <ContentTemplate>
    <LGM:ToolBar0 
      ID = "TBLerpEvaluateByIT"
      ToolType="lgNReport"
      SkinID = "tbl_blue"
      runat = "server" />
    <table width="100%"><tr><td class="sis_formview"> 
    <asp:UpdateProgress ID="UPGSlgDMisg" runat="server" AssociatedUpdatePanelID="UPNLlgDMisg" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
       }
      function script_download(id, dy, nid) {
       	pcnt = pcnt + 1;
       	var nam = 'wdwd' + pcnt;
       	var url = self.location.href.replace('App_Forms/GF_ErectionDrawingList_YNR.aspx', 'App_Download/ErectionDocumentList_YNR.aspx');
       	url = url + '?id=' + $get(id).value + '&dy=' + $get(dy).value + '&nid=' + $get(nid).value;
       	window.open(url, nam, 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1');
       	return false;
       }
    </script>

    <br />
    <br />
    <table>
			<tr>
				<td style="text-align:right;"><b>Project ID :</b>
				</td>
				<td><input type="text" id="F_ProjectID" maxlength="6" style="width: 76px; text-transform:uppercase" class="mytxt" />
				</td>
      </tr>
      <tr>
				<td><b>Released or Modified in Last [Days] :</b>
				</td>
				<td><input type="text" id="F_Days" maxlength="6" style="width: 76px" class="mytxt" value="30" />
				</td>
        <tr>
				<td class="alignright">
					<b><asp:Label ID="Label1" runat="server" Text="YamunaNagar WorkShop :" /></b>
				</td>
				<td>
					<select id="F_Shop" style="width:80px" >
						<option value="DRUM" selected="selected">DRUM</option>
						<option value="PIPE">PIPE</option>
						<option value="TUBE">TUBE</option>
						
					</select>
				</td>
			</tr>
      </tr>
      <tr>
				<td colspan="2" style="text-align:right;">
					<input type="button" onclick="return script_download('F_ProjectID','F_Days','F_Shop');" value=" Download " />
				</td>
			</tr>
    </table>
  </td></tr></table>
    <asp:GridView ID="GVerpEvaluateByIT" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ApplID,RequestID">

    </asp:GridView>

  </ContentTemplate>
</asp:UpdatePanel>
</div>
  </div>
</asp:Content>
