<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="category.aspx.cs" Inherits="EssentialWeb.admin.category" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content2" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
           <div class="row" style="padding-top:40px;">
            <div class="col-sm-4"></div>
             <div class="col-sm-4 m-auto" style="box-sizing:border-box;background-color: #f2f2f2; border-radius: 5px;">
                 <div class="row" style="padding-top:20px;">
<center>
    <asp:Label ID="lblcategory" runat="server" Text="Add New Category" Style="font-weight:bolder; color: black; font-size:30px;"></asp:Label> </center><br />
  
             
                <div class="col-sm-3" style="padding-top:10px;"> <label for="Category_text" class="" style="line-height:0px;">Category</label></div>    
             <asp:TextBox ID="Category_text" runat="server" Cssclass="form-control" placeholder="Category Name" required> </asp:TextBox>
            <br />

    
   <div class="col-sm-3" style="padding-top:10px;"> <label for="ddlgrp" class="" style="line-height:0px;text-align:center;">Group</label></div>
 <asp:DropDownList ID="ddlgrp" runat="server"  CssClass="form-control dropdown-toggle"  AutoPostBack="true"></asp:DropDownList><br />
    <center> <asp:RequiredFieldValidator runat="server" InitialValue = "Select Group" ControlToValidate="ddlgrp" ErrorMessage="Please Select an Group" ForeColor="Red"></asp:RequiredFieldValidator> </center>
                 

         <div class="col-auto"  style=" color:black; padding-bottom:40px; padding-left:80px">
      <div class="form-check mb-2">
            <asp:CheckBox ID="CheckBox_category" runat="server"  Checked="true"/>
        <label class="form-check-label" for="CheckBox_category">
          IsActive
        </label>
      </div>
      <asp:Button ID="Button1" runat="server"  Text="Save" OnClick="Btnsavecategory_Click" CssClass="btn btn-primary mb-2"/> &nbsp;
        <asp:Button ID="Button2" runat="server"  OnClick="btncatcancl_Click" Text="Cancel" CssClass="btn btn-default btn-danger" CausesValidation="false" UseSubmitBehavior="false"/>
            </div>
                 </div>
               </div>
        </ContentTemplate>
    </asp:UpdatePanel>

     <div class="col-sm-"></div>

    <script type="text/javascript">

        $(document).ready(function () {

            $(".container").hide(0).delay(100).fadeIn(1000);
        });

    </script>
</asp:Content>
