<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="adduseradmin.aspx.cs" Inherits="EssentialWeb.admin.adduseradmin" %>
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
    <asp:Label ID="lblcategory" runat="server" Text="Add New User" Style="font-weight:bolder; color: black; font-size:30px;"></asp:Label> </center><br />
  
             
         <div class="col-sm-3" style="padding-top:10px;"> <label for="ddlstore" class="" style="line-height:0px;text-align:center;">Store</label></div>
 <asp:DropDownList ID="ddlstore" runat="server"  CssClass="form-control dropdown-toggle"  AutoPostBack="true"></asp:DropDownList>
    <center> <asp:RequiredFieldValidator runat="server" InitialValue = "Select Store" ControlToValidate="ddlstore" ErrorMessage="Please Select Store" ForeColor="Red"></asp:RequiredFieldValidator> </center>

            <div class="col-sm-3" style="padding-top:10px;"> <label for="ddladminuser" class="" style="line-height:0px;text-align:center;">User Type</label></div>
           <asp:DropDownList ID="ddladminuser" runat="server" CssClass="form-control dropdown-toggle" AutoPostBack="true"></asp:DropDownList>
<center><asp:RequiredFieldValidator ID="rfv1" runat="server" InitialValue = "Select User Type" ControlToValidate="ddladminuser" ErrorMessage="Please select user type" ForeColor="Red"></asp:RequiredFieldValidator> </center>
                     
              
                       <div class="col-sm-3" style="padding-top:10px;"> <label for="usradm_text" class="" style="line-height:0px;">Name</label></div>    
             <asp:TextBox ID="usradm_text" runat="server" Cssclass="form-control" placeholder="User Name" required> </asp:TextBox>
            <br />
                
              <div class="col-sm-3" style="padding-top:10px;"> <label for="usrpass_text" class="" style="line-height:0px;">Password</label></div>    
             <asp:TextBox ID="usrpass_text" runat="server" Cssclass="form-control" TextMode="Password" placeholder="Password" required> </asp:TextBox>
            <br />

                <div class="col-sm-3" style="padding-top:10px;"> <label for="usrmob_text" class="" style="line-height:0px;">Mobile</label></div>    
             <asp:TextBox ID="usrmob_text" runat="server" Cssclass="form-control" placeholder="Mobile" required> </asp:TextBox>
            <br />
          
            <div class="col-sm-3" style="padding-top:10px;"> <label for="usremail_text" class="" style="line-height:0px;">Email</label></div>    
             <asp:TextBox ID="usremail_text" runat="server" Cssclass="form-control" placeholder="Email" required> </asp:TextBox>
            <br />
                    
         <div class="col-auto"  style=" color:black; padding-bottom:40px; padding-left:80px">
                <div class="form-check mb-2">
            <asp:CheckBox ID="chkbxusr" runat="server"  Checked="true"/>
        <label class="form-check-label" for="chkbxusr">
          IsActive
        </label>
      </div>
       <asp:Button ID="Button1" runat="server"  Text="Save" OnClick="Btnsaveadmusr_Click" CssClass="btn btn-primary mb-2"/> &nbsp;
        <asp:Button ID="Button2" runat="server"  OnClick="btncancladm_Click" Text="Cancel" CssClass="btn btn-default btn-danger" CausesValidation="false" UseSubmitBehavior="false"/>
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
