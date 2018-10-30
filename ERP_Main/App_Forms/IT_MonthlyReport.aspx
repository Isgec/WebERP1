<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="IT_MonthlyReport.aspx.vb" Inherits="IT_MonthlyReport" %>
<asp:Content ID="CPHlgDMisg" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLlgDMisg" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabellgDMisg" runat="server" Text="&nbsp;IT Monthly Report"  Width ="100%" CssClass="sis_formheading" Font-Bold="True" Font-Size="Medium"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <asp:UpdateProgress ID="UPGSlgDMisg" runat="server" AssociatedUpdatePanelID="UPNLlgDMisg" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <script type="text/javascript">
      var pcnt = 0;
       function script_download() {
       	pcnt = pcnt + 1;
       	var nam = 'wdwd' + pcnt;
       	var url = self.location.href.replace('App_Forms/IT_MonthlyReport.aspx', 'App_Downloads/ITMonthlyReport.aspx');
       	url = url + '?fd=' + $get('F_Month').value;
       	window.open(url, nam, 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1');
       	return false;
       }
    </script>
    <br />
    <br />
    <table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="Label1" runat="server" Text="Select Month:" /></b>
				</td>
				<td>
          <asp:DropDownList ID="F_Month" runat="server" style="width:100px;" ClientIDMode="Static">
            <asp:ListItem Value="01" Text="JANUARY"></asp:ListItem>
            <asp:ListItem Value="02" Text="FEBRUARY"></asp:ListItem>
            <asp:ListItem Value="03" Text="MARCH"></asp:ListItem>
            <asp:ListItem Value="04" Text="APRIL"></asp:ListItem>
            <asp:ListItem Value="05" Text="MAY"></asp:ListItem>
            <asp:ListItem Value="06" Text="JUNE"></asp:ListItem>
            <asp:ListItem Value="07" Text="JULY"></asp:ListItem>
            <asp:ListItem Value="08" Text="AUGUST"></asp:ListItem>
            <asp:ListItem Value="09" Text="SEPTEMBER"></asp:ListItem>
            <asp:ListItem Value="10" Text="OCTOBER"></asp:ListItem>
            <asp:ListItem Value="11" Text="NOVEMBER"></asp:ListItem>
            <asp:ListItem Value="12" Text="DECEMBER"></asp:ListItem>
          </asp:DropDownList>
				</td>
				<td>
					<input type="button" onclick="return script_download();" value=" Download " />
				</td>
			</tr>
    </table>
  </td></tr></table>
  </ContentTemplate>
</asp:UpdatePanel>
</div>
</asp:Content>
