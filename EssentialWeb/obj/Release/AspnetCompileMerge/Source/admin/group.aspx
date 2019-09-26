<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="group.aspx.cs" Inherits="EssentialWeb.admin.group" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content2" runat="server">

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="main">
                       <div class="row" style="padding-top:40px;">
                <div class="col-sm-4"></div>
             <div class="col-sm-4 m-auto" style="box-sizing:border-box;background-color: #f2f2f2; border-radius: 5px;">
  <Center>
<asp:Label ID="lblgroup" runat="server" Text="Add New Group" Style="font-weight:bolder; color: black; font-size:30px;"></asp:Label></center><br />
     <center> <asp:TextBox ID="Group_txt" runat="server" Cssclass="form-control" placeholder="Group Name" required></asp:TextBox>
  </Center><br />
       <div class="col-auto"  style=" color:black; padding-bottom:40px; padding-left:80px">
      <div class="form-check mb-2">
          <asp:CheckBox ID="isactive_group" runat="server" Checked="true"/>  
        <label class="form-check-label" for="isactive_group">
          IsActive
        </label>
      </div>
            <asp:Button ID="Button1" runat="server"  Text="Save" OnClick="btnsavgrp_Click" CssClass="btn btn-primary mb-2"/>&nbsp;
        <asp:Button ID="Button2" runat="server"  OnClick="btngrpcancl_Click" Text="Cancel" Cssclass="btn btn-default btn-danger"  CausesValidation="false" UseSubmitBehavior="false"/>
                  </div>
                 </div>
       </div>
           </ContentTemplate>
    </asp:UpdatePanel>
    <div class="col-sm-"></div>

<script type="text/javascript">

    $(document).ready(function () {

        $("#main").hide(0).delay(100).fadeIn(1000);
    });

</script>
 </asp:Content>
