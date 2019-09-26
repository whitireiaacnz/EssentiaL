<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="item.aspx.cs" Inherits="EssentialWeb.admin.item" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content2" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                    <ContentTemplate>
                 <div id="main">
                       <div class="row" style="padding-top:20px;">
                        <div class="col-sm-2"></div>
                <div class="col-sm-6 m-auto" style="box-sizing:border-box;background-color: #f2f2f2; border-radius: 5px;" >

                    <center><asp:Label ID="Label1" runat="server" style="font-weight:bolder;font-size:30px; color: black;" Text="Add New Item"></asp:Label></center><br />
               
                    <div class="row">
                <div class="col-sm-4">  <label for="model_text" class="" style="line-height:30px;text-align:center;">Model No</label></div>
           <div class="col-sm-8">          <asp:TextBox ID="model_text" runat="server" Placeholder="Enter Model NO.." CssClass="form-control" required></asp:TextBox> <br /></div></div>

                    <div class="row">
                 <div class="col-sm-4">   <label for="itm_text" class="" style="line-height:30px;text-align:center;">Item Name</label> </div>
           <div class="col-sm-8">     <asp:TextBox ID="itm_text" runat="server" Placeholder="Enter Item Name.." CssClass="form-control"  Enabled="false" required  ></asp:TextBox><br /></div></div>

                    <div class="row">
                    <div class="col-sm-4">  <label for="clr_text" class="" style="line-height:30px;text-align:center;">Item Color</label></div>
            <div class="col-sm-8">      <asp:TextBox ID="clr_text" runat="server" Placeholder="Enter Item Color.." CssClass="form-control"></asp:TextBox> <br /></div></div>   

              <div class="row">
            <div class="col-sm-4">      <label for="sze_text" class="" style="line-height:30px;text-align:center;">Item Size</label></div>
       <div class="col-sm-8">         <asp:TextBox ID="sze_text" runat="server" Placeholder="Enter Item Size.." CssClass="form-control" required ></asp:TextBox><br /></div></div>

                  <div class="row">
                <div class="col-sm-4">       <label for="feture_text" class="" style="line-height:30px;text-align:center;">Item Features</label></div>
       <div class="col-sm-8">       <asp:TextBox ID="feture_text" runat="server" Placeholder="Enter Item Features.." CssClass="form-control" ></asp:TextBox><br /></div></div>
      
                      <div class="row">
                    <div class="col-sm-4">     <label for="ddlBrand" class="" style="line-height:30px;text-align:center;">Brand</label> </div>
                  <div class=" col-sm-8">  <asp:DropDownList ID="ddlBrand" runat="server" CssClass="form-control dropdown-toggle" Height="35px" Font-Size="Medium" AutoPostBack="true" ></asp:DropDownList></div></div>
          <center><asp:RequiredFieldValidator runat="server" InitialValue = "Select Brand" ControlToValidate="ddlBrand" ErrorMessage="Please Select a Brand" ForeColor="Red"></asp:RequiredFieldValidator></center>   
             
             
                    <div class="row">              
         <div class="col-sm-4"> <label for="ddlCategory" class="" style="line-height:30px;text-align:center;">Category</label>  </div>
            <div class="col-sm-8"><asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control dropdown-toggle" Height="35px" Font-Size="Medium" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" ></asp:DropDownList></div></div>
               <center>  <asp:RequiredFieldValidator runat="server" InitialValue = "Select Category" ControlToValidate="ddlCategory" ErrorMessage="Please Select a Category" ForeColor="Red"></asp:RequiredFieldValidator> 
             </center>                          
                                                                                                      
        <%--     <div class="row">
        <div class="col-sm-4">  <label for="ddlScheme" class="" style="line-height:30px;text-align:center;">Scheme</label> </div>
     <div class="col-sm-8"><asp:DropDownList ID="ddlScheme" runat="server" CssClass="btn btn-default dropdown-toggle mr-4" Height="35px" Font-Size="Medium" AutoPostBack="true" style="width:900px;" ></asp:DropDownList><br /></div></div>
        <center><asp:RequiredFieldValidator runat="server" InitialValue = "Select Scheme" ControlToValidate="ddlScheme" ErrorMessage="Please Select a Scheme" ForeColor="Red"></asp:RequiredFieldValidator>
      </center>
                    --%>
                           <div class="row">   
         <div class="col-sm-4">   <label for="ddlGroup" class="" style="line-height:30px;text-align:center;">Group</label></div>       
     <div class="col-sm-8">  <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control dropdown-toggle" Font-Size="Medium" AutoPostBack="true"></asp:DropDownList></div> </div>
          <center> <asp:RequiredFieldValidator runat="server" InitialValue = "Select Group" ControlToValidate="ddlGroup" ErrorMessage="Please Select a Group" ForeColor="Red"></asp:RequiredFieldValidator>
       </center> <br />
                    
                    <%--  <div class="row">
                <div class="col-sm-4"> <label for="ddlItem" class="" style="line-height:30px;text-align:center;">Item</label> </div>
                   <div class="col-sm-8"><asp:DropDownList ID="ddlItem" runat="server" CssClass="form-control dropdown-toggle"  AutoPostBack="true" ></asp:DropDownList></div></div>
      <center><asp:RequiredFieldValidator runat="server" InitialValue = "Select Item" ControlToValidate="ddlItem" ErrorMessage="Please Select an Item" ForeColor="Red"></asp:RequiredFieldValidator> </center>--%>
                    
                <div class="row">
            <div class="col-sm-4"> <label for="mrp_text" class="" style="line-height:30px;text-align:center;">MRP</label> </div>
             <div class="col-sm-8"><asp:TextBox ID="mrp_text" runat="server" Placeholder="Enter MRP.." CssClass="form-control"  required></asp:TextBox> <br /></div> </div>

                    <div class="row">
                 <div class="col-sm-4"> <label for="dprice_text" class="" style="line-height:30px;">Dealer price</label>  </div>                        
 <div class="col-sm-8"><asp:TextBox ID="dprice_text" runat="server" Placeholder="Enter Dealer Price.." CssClass="form-control" required ></asp:TextBox><br /></div></div>
            
                    <div class="row">
             <div class="col-sm-4">       <label for="dscnt_text" class="" style="line-height:30px;">Discount Price</label> </div>
     <div class="col-sm-8">  <asp:TextBox ID="dscnt_text" runat="server" Placeholder="Enter Discount.." CssClass="form-control" required ></asp:TextBox> <br /></div></div>

                    <div class="row"> 
                    <div class="col-sm-4"> <label for="ddlScheme" class="" style="line-height:30px;">Scheme</label>  </div>
    <div class="col-sm-8"> <asp:DropDownList ID="ddlScheme" runat="server" CssClass="form-control dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlScheme_SelectedIndexChanged1" ></asp:DropDownList></div></div>
  <center><asp:RequiredFieldValidator runat="server" InitialValue = "Select Scheme" ControlToValidate="ddlScheme" ErrorMessage="Please Select a Scheme" ForeColor="Red"></asp:RequiredFieldValidator> </center>
                        
                    <div class="row">
                    <div class="col-sm-4">    <label for="msp_text" class="" style="line-height:30px;">MSP</label>  </div> 
  <div class="col-sm-8"> <asp:TextBox ID="msp_text" runat="server" Placeholder="MSP.." CssClass="form-control" Enabled="false"  required></asp:TextBox> <br /></div></div>

                    <div class="row">
                    <div class="col-sm-4">    <label for="bstprice_text" class="" style="line-height:30px;">Best Price</label> </div>
     <div class="col-sm-8"> <asp:TextBox ID="bstprice_text" runat="server" Placeholder="Best Price.." CssClass="form-control" Enabled="false" required ></asp:TextBox> <br /></div></div>

                    <div class="row">
                    <div class="col-sm-4">  <label for="isapp_text" class="" style="line-height:30px;">IsApplicable From</label>    </div>
  <div class="col-sm-8">  <asp:TextBox ID="isapp_text" runat="server" Placeholder="Enter Date.." CssClass="form-control" Textmode="Date" required></asp:TextBox> <br /></div></div>



                          <div class="col-auto" style="color:black; padding-bottom:40px; padding-left:170px">
                    <div class="form-check mb-2">
                    <asp:CheckBox ID="chkIsActive" runat="server" Checked="true"/>  
                        <label class="form-check-label" for="chkIsActive">
                      IsActive
                     </label>
                      </div>
                                       
                <asp:Button ID="Button1" runat="server" OnClick="btnsavitm_Click" Text="Save" CssClass="btn btn-primary mb-2" /> &nbsp;
                    <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="btnitmcancl_Click" CssClass="btn btn-default btn-danger"  CausesValidation="false" UseSubmitBehavior="false"/>
                                  
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
