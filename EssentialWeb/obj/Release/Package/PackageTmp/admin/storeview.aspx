<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="storeview.aspx.cs" Inherits="EssentialWeb.admin.storeview" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
        // <![CDATA[
        var CustomPager = {
            gotoBox_Init: function (s, e) {
                s.SetText(1 + dg.GetPageIndex());
            },
            gotoBox_KeyPress: function (s, e) {
                if (e.htmlEvent.keyCode != 13)
                    return;
                e.htmlEvent.cancelBubble = true;
                e.htmlEvent.returnValue = false;
                CustomPager.applyGotoBoxValue(s);
            },
            gotoBox_ValueChanged: function (s, e) {
                CustomPager.applyGotoBoxValue(s);
            },
            applyGotoBoxValue: function (textBox) {
                var pageIndex = parseInt(textBox.GetText()) - 1;
                if (pageIndex < 0)
                    pageIndex = 0;
                dg.GotoPage(pageIndex);
            },
            combo_SelectedIndexChanged: function (s, e) {
                dg.PerformCallback(s.GetSelectedItem().text + '|PagerCombo');
            }
        };
        // ]]>
    </script>
    <script type="text/javascript">
        // <![CDATA[
        function btnFldChooser_Click(s, e) {
            if (dg.IsCustomizationWindowVisible())
                dg.HideCustomizationWindow();
            else
                dg.ShowCustomizationWindow();
            UpdateButtonText();
        }
        function dg_CustomizationWindowCloseUp(s, e) {
            UpdateButtonText();
        }
        function UpdateButtonText() {
            var text = dg.IsCustomizationWindowVisible() ? "Hide" : "Show";
            text += " Customization Window";
            btnFldChooser.SetText(text);
        }
        // ]]> 
    </script>
    </asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Content2" runat="server">

    <div id="review_form" style="padding: 10px 20px 10px 20px" class="col-inner">
        <div class="review-form-inner has-border">
            <div class="pages">
                <%--<h1>Feedback View</h1>--%>
                <div style="text-align: center; color:rgba(0, 0, 0, 0.92); font-weight: 500">
            <h3>Store View</h3>
        </div>
                <section class="bg-white one-col">
                    <section class="bg-white-border">
                        <table style="margin-bottom: 16px">
                            <tr>
                               <td style="padding-right: 12px">
                                    <dx:ASPxButton runat="server" ID="btnFldChooser" ClientInstanceName="btnFldChooser"
                                        Text="Show Customization Window"
                                        UseSubmitBehavior="false" AutoPostBack="false">
                                        <ClientSideEvents Click="btnFldChooser_Click" />
                                    </dx:ASPxButton>
                                </td>

                          <%--    <td style="padding-right: 4px">
                                    <dx:ASPxLabel ID="lblGroupBy" runat="server" Text="Group By :"></dx:ASPxLabel>
                                </td>

                                <td style="padding-right: 4px">
                                    <dx:ASPxComboBox runat="server" ID="cbFields" ValueType="System.Int32" SelectedIndex="0">
                                        <Items>
                                            <dx:ListEditItem Text="No Group" Value="0" />
                                            <dx:ListEditItem Text="Customer Name" Value="1" />
                                            <dx:ListEditItem Text="Mobile No" Value="2" />--%>
                                            <%--<dx:ListEditItem Text="" Value="3" />
                                                                                 </Items>
                                        <ClientSideEvents SelectedIndexChanged="function(s) { dg.PerformCallback(s.GetValue()+'|FeildGrp') }" />
                                    </dx:ASPxComboBox>
                                </td>

                                <td style="padding-right: 4px">
                                    <dx:ASPxButton runat="server" ID="btnCollapse" Text="-" ToolTip="Collapse All Rows" UseSubmitBehavior="false"
                                        AutoPostBack="false">
                                        <ClientSideEvents Click="function() {dg.CollapseAll()}" />
                                    </dx:ASPxButton>
                                </td>

                                <td style="padding-right: 16px">
                                    <dx:ASPxButton runat="server" ID="btnExpand" Text="+" ToolTip="Expand All Rows" UseSubmitBehavior="false"
                                        AutoPostBack="false">
                                        <ClientSideEvents Click="function() { dg.ExpandAll() }" />
                                    </dx:ASPxButton>
                                </td>--%>

                                <td style="padding-right: 4px">
                                    <dx:ASPxImage ID="lblExport" runat="server" Text="Export to :" />
                                </td>

                                <td style="padding-right: 4px">
                                    <dx:ASPxButton ID="btnPDFExport" runat="server" Text="PDF" UseSubmitBehavior="false"
                                        OnClick="btnPDFExport_Click" />
                                </td>

                                <td style="padding-right: 16px">
                                    <dx:ASPxButton ID="btnXlsExport" runat="server" Text="XLS" UseSubmitBehavior="False"
                                        OnClick="btnXlsExport_Click" />
                                </td>

                                <td style="padding-right: 4px">
                                    <dx:ASPxLabel ID="lblAdd" runat="server" Text="Add :"></dx:ASPxLabel>
                                </td>

                                <td style="padding-right: 4px">
                                    <dx:ASPxButton ID="btnAddNewRecord" runat="server" Text="New Record" UseSubmitBehavior="false" OnClick="btnAddNewRecord_Click">
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                        </table>
                        <p>

                        <%--    <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="dg" runat="server" Width="100%" EnableRowsCache="False" KeyFieldName="Feedback_Id"
                        OnCustomCallback="dg_CustomCallback" OnStartRowEditing="dg_StartRowEditing"  OnRowDeleting="dg_RowDeleting"                                          
                        OnLoad="dg_Load" OnCustomErrorText="dg_CustomErrorText">--%>
              <dx:ASPxGridView ID="dg" ClientInstanceName="dg" runat="server" Width="100%" EnableRowsCache="False" KeyFieldName="Store_Id"
                        OnCustomCallback="dg_CustomCallback" OnStartRowEditing="dg_StartRowEditing"  OnRowDeleting="dg_RowDeleting"                                          
                        OnLoad="dg_Load" OnCustomErrorText="dg_CustomErrorText">

                                    <settings showfilterrow="True" showgrouppanel="True" showfilterrowmenu="true" showpreview="true"></settings>
                                    <settingscookies enabled="false" />
                                    <settingsbehavior confirmdelete="true" columnresizemode="NextColumn" />
                                    <settingstext title="Dgains Portal" confirmdelete="Are you sure you want to delete ??" />
                                    <settingspager pagesize="10" showseparators="true" seofriendly="Disabled" />
                                    <settingscustomizationwindow enabled="True" />
                                    <clientsideevents customizationwindowcloseup="dg_CustomizationWindowCloseUp" />

                                <Columns>
                                    <dx:GridViewCommandColumn VisibleIndex="0" Caption=" " Width="5%">
                                        <ClearFilterButton Visible="true" />
                                        <EditButton Visible="true" Text="Update"/>                                       
                                        <DeleteButton Visible="True" />
                                    </dx:GridViewCommandColumn>                                                             
                                   
                                    <dx:GridViewDataTextColumn FieldName="Store_Name" Caption="Store Name" Width="20%" Settings-AllowGroup="true">
                                        <Settings AutoFilterCondition="Contains" />
                                    </dx:GridViewDataTextColumn>


                                    <dx:GridViewDataDateColumn FieldName="isActive" Caption="isActive" Width="10%" Visible="true" Settings-AllowGroup="True">
                                        <Settings AutoFilterCondition="Contains" />
                                    </dx:GridViewDataDateColumn>

                              

                           <%--         <dx:GridViewDataCheckColumn FieldName="Remark" Caption="Remark" Width="20%" Visible="true" Settings-AllowGroup="True">
                                        <Settings AutoFilterCondition="Contains" />
                                    </dx:GridViewDataCheckColumn>--%>
                                   <%-- <dx:GridViewDataTextColumn FieldName="Add1" Caption="Add1" Width="30%" Visible="true" Settings-AllowGroup="False">
                                        <Settings AutoFilterCondition="Contains" />
                                    </dx:GridViewDataTextColumn>--%>

<%--                                    <dx:GridViewDataTextColumn FieldName="Email" Caption="Email" Width="15%" Settings-AllowGroup="true">
                                        <Settings AutoFilterCondition="Contains" />
                                    </dx:GridViewDataTextColumn>

                                    <dx:GridViewDataTextColumn FieldName="Mob1" Caption="Mobile" Width="15%" Settings-AllowGroup="False">
                                        <Settings AutoFilterCondition="Contains" />
                                    </dx:GridViewDataTextColumn>--%>

                                   <%-- <dx:GridViewDataCheckColumn FieldName="isActive" Caption="isActive" Width="8%" Settings-AllowSort="False" Settings-AllowGroup="False" Settings-AllowAutoFilter="False" />--%>
                                </Columns>

                                    <GroupSummary>
                                    <dx:ASPxSummaryItem FieldName="Remark" SummaryType="Count" />
                                </GroupSummary>

                                    <Templates>
                                    <PagerBar>
                                        <table>
                                            <tr>
                                                <td>
                                                    <dx:ASPxButton runat="server" ID="FirstButton" Text="First (T)" AccessKey="T" Enabled="<%# Container.Grid.PageIndex > 0 %>"
                                                        AutoPostBack="false">
                                                        <ClientSideEvents Click="function() { dg.GotoPage(0) }" />
                                                    </dx:ASPxButton>
                                                </td>

                                                <td>
                                                    <dx:ASPxButton runat="server" ID="PrevButton" Text="Prev (P)" AccessKey="P" Enabled="<%# Container.Grid.PageIndex > 0 %>"
                                                        AutoPostBack="false">
                                                        <ClientSideEvents Click="function() { dg.PrevPage() }" />
                                                    </dx:ASPxButton>
                                                </td>

                                                <td>
                                                    <dx:ASPxTextBox runat="server" ID="GotoBox" Width="30">
                                                        <ClientSideEvents Init="CustomPager.gotoBox_Init" ValueChanged="CustomPager.gotoBox_ValueChanged"
                                                            KeyPress="CustomPager.gotoBox_KeyPress" />
                                                    </dx:ASPxTextBox>
                                                </td>

                                                <td>
                                                    <span style="white-space: nowrap">of
                                                    <%# Container.Grid.PageCount %>
                                                    </span>
                                                </td>

                                                <td>
                                                    <dx:ASPxButton runat="server" ID="NextButton" Text="Next (N)" AccessKey="N" Enabled="<%# Container.Grid.PageIndex < Container.Grid.PageCount - 1 %>"
                                                        AutoPostBack="false">
                                                        <ClientSideEvents Click="function() { dg.NextPage() }" />
                                                    </dx:ASPxButton>
                                                </td>
                                                <td>
                                                    <dx:ASPxButton runat="server" ID="LastButton" Text="Last (L)" AccessKey="L" Enabled="<%# Container.Grid.PageIndex < Container.Grid.PageCount - 1 %>"
                                                        AutoPostBack="false">
                                                        <ClientSideEvents Click="function() { dg.GotoPage(dg.GetPageCount() - 1); }" />
                                                    </dx:ASPxButton>
                                                </td>
                                                <td style="width: 53%"></td>
                                                <td style="white-space: nowrap">
                                                    <span style="white-space: nowrap">Records per page (R) : </span>
                                                </td>
                                                <td>
                                                    <dx:ASPxComboBox runat="server" ID="Combo" Width="60" DropDownWidth="50" ValueType="System.Int32"
                                                        OnLoad="Combo_Load" AccessKey="R">
                                                        <Items>
                                                            <dx:ListEditItem Value="10" />
                                                            <dx:ListEditItem Value="30" />
                                                            <dx:ListEditItem Value="50" />
                                                            <dx:ListEditItem Value="100" />
                                                        </Items>
                                                        <ClientSideEvents SelectedIndexChanged="CustomPager.combo_SelectedIndexChanged" />
                                                    </dx:ASPxComboBox>
                                            </tr>
                                        </table>
                                    </PagerBar>

                                </Templates>

                                </dx:ASPxGridView>
                                <dx:ASPxGridViewExporter ID="dgExport" runat="server" GridViewID="dg"></dx:ASPxGridViewExporter>
                        </p>
                        <asp:PlaceHolder ID="phpermission" runat="server" Visible="false">
                            <asp:Label ID="Label1" runat="server" Text="You dont have access to view this module !!" CssClass="redtext-bold"></asp:Label>
                            <asp:Label ID="Label2" runat="server" Text="Please contact your System Administrator !!" CssClass="redtext-bold"></asp:Label>
                        </asp:PlaceHolder>
                    </section>
                </section>
            </div>
        </div>
    </div>

</asp:Content>
