<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_lgProjects.aspx.vb" Inherits="GF_lgProjects" title="Maintain List: Projects" %>
<asp:Content ID="CPHlgProjects" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLlgProjects" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabellgProjects" runat="server" Text="&nbsp;List: Projects" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLlgProjects"
      ToolType = "lgNMGrid"
      EditUrl = "~/LG_Main/App_Edit/EF_lgProjects.aspx"
      AddUrl = "~/LG_Main/App_Create/AF_lgProjects.aspx"
      ValidationGroup = "lgProjects"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSlgProjects" runat="server" AssociatedUpdatePanelID="UPNLlgProjects" DisplayAfter="100">
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
    </script>
    <asp:GridView ID="GVlgProjects" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSlgProjects" DataKeyNames="ProjectID">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
              <td><asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ProjectID" SortExpression="ProjectID">
          <ItemTemplate>
            <asp:Label ID="LabelProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project Description" SortExpression="ProjectDescription">
          <ItemTemplate>
            <asp:Label ID="LabelProjectDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectDescription") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSlgProjects"
      runat = "server"
      DataObjectTypeName = "SIS.LG.lgProjects"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "lgProjectsSelectList"
      TypeName = "SIS.LG.lgProjects"
      SelectCountMethod = "lgProjectsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVlgProjects" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
