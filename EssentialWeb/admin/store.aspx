<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="store.aspx.cs" Inherits="EssentialWeb.admin.store" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content2" runat="server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="main">
              <div class="row" style="padding-top:40px;">
                <div class="col-sm-4"></div>
             <div class="col-sm-4 m-auto" style="box-sizing:border-box;background-color: #f2f2f2; border-radius: 5px;">
<center>
    <asp:Label ID="lblstor" runat="server" Text="Add New Store" Style="font-weight:bolder; color: black; font-size:30px;" ></asp:Label></center><br />
 <center>  
 <asp:TextBox ID="TextBox1" runat="server" Cssclass="form-control" OnTextChanged="TextBox1_TextChanged" placeholder="Store Name" required></asp:TextBox><br />
     <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Enter Store Name" ForeColor="Red"></asp:RequiredFieldValidator>--%>
<asp:TextBox ID="add1_text" runat="server" Cssclass="form-control"  placeholder="Enter Address Line 1" required></asp:TextBox><br />
 <asp:TextBox ID="add2_text" runat="server" Cssclass="form-control"  placeholder="Enter Address Line 2" required></asp:TextBox><br /> 
<asp:TextBox ID="cityname_text" runat="server" Cssclass="form-control"  placeholder="Enter City Name" required></asp:TextBox><br /> 
<asp:TextBox ID="statename_text" runat="server" Cssclass="form-control"  placeholder="Enter State Name" required></asp:TextBox><br />
 <asp:TextBox ID="pincode_text" runat="server" Cssclass="form-control"  placeholder="Enter Pincode"  required></asp:TextBox><br /> 

</center><br />

     <div class="col-auto"  style=" color:black; padding-bottom:40px; padding-left:80px">
      <div class="form-check mb-2">
          <asp:CheckBox ID="chkIsActive" runat="server"  Checked="true"/>
        <label class="form-check-label" for="chkIsActive">
          IsActive
        </label>
      </div>
          <asp:Button ID="Button1" runat="server" OnClick="btnsavstore_Click" Text="Save" CssClass="btn btn-primary mb-2" />&nbsp;
          <asp:Button ID="Button2" runat="server"  OnClick="btnsavecancl_Click" Text="Cancel" CssClass="btn btn-default btn-danger"  CausesValidation="false" UseSubmitBehavior="false"/>
         </div>
          </div>
                  </div>
        </ContentTemplate>
    </asp:UpdatePanel>
         <div class="col-sm-"></div>

    <script type="text/javascript">

        $(document).ready(function () {

            $("#main").hide(0).delay(100).fadeIn(1000);
        })

    </script>

</asp:Content>
