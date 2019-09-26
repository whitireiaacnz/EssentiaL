<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="pricelist.aspx.cs" Inherits="EssentialWeb.admin.pricelist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Content2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                   <div class="container">
                       <div class="row" style="padding-top:20px;">
                        <div class="col-sm-2"></div>
                          <div class="col-sm-6 m-auto" style="box-sizing:border-box;background-color: #f2f2f2; border-radius: 5px;" >
                         <div class="row" style="padding-top:20px;">
                        
              
                       <div class="lab" style="text-align:center;padding-bottom:10px;"> 
                <asp:Label ID="Label1" runat="server" style="font-weight:bolder;font-size:30px; color: black;" Text="Add Price List"></asp:Label>
                       </div> 
            
                    

                    <div class="col-sm-4 " >  <label for="ddlItem" class="" style="line-height:30px;text-align:center;">Item</label></div>
 <div class="col-sm-8"><asp:DropDownList ID="ddlItem" runat="server" CssClass="form-control dropdown-toggle"  AutoPostBack="true" ></asp:DropDownList></div><br />
<center><asp:RequiredFieldValidator runat="server" InitialValue = "Select Item" ControlToValidate="ddlItem" ErrorMessage="Please Select an Item" ForeColor="Red"></asp:RequiredFieldValidator> </center>
  
                    
                    <div class="col-sm-4">    <label for="mrp_text" class="" style="line-height:30px;text-align:center;">MRP</label>  </div>        
<div class="col-sm-8"><asp:TextBox ID="mrp_text" runat="server" Placeholder="Enter MRP.." CssClass="form-control"  required></asp:TextBox> <br /></div>
       
             
         <div class="col-sm-4"> <label for="dprice_text" class="" style="line-height:30px;">Display price</label>  </div>                        
 <div class="col-sm-8"><asp:TextBox ID="dprice_text" runat="server" Placeholder="Enter Display Price.." CssClass="form-control" required ></asp:TextBox><br /></div>


    <div class="col-sm-4">       <label for="dscnt_text" class="" style="line-height:30px;">Discount Price</label> </div>
     <div class="col-sm-8">  <asp:TextBox ID="dscnt_text" runat="server" Placeholder="Enter Discount.." CssClass="form-control" required ></asp:TextBox> <br /></div>

    
        <div class="col-sm-4"> <label for="ddlScheme" class="" style="line-height:30px;">Scheme</label>  </div>
    <div class="col-sm-8"> <asp:DropDownList ID="ddlScheme" runat="server" CssClass="form-control dropdown-toggle" AutoPostBack="true"  OnSelectedIndexChanged="ddlScheme_SelectedIndexChanged"></asp:DropDownList></div><br />
  <center><asp:RequiredFieldValidator runat="server" InitialValue = "Select Scheme" ControlToValidate="ddlScheme" ErrorMessage="Please Select a Scheme" ForeColor="Red"></asp:RequiredFieldValidator> </center>
     
    
  <div class="col-sm-4">    <label for="msp_text" class="" style="line-height:30px;">MSP</label>  </div> 
  <div class="col-sm-8"> <asp:TextBox ID="msp_text" runat="server" Placeholder="Enter MSP.." CssClass="form-control" Enabled="false"  required></asp:TextBox> <br /></div>
   
   
    <div class="col-sm-4">    <label for="bstprice_text" class="" style="line-height:30px;">Best Price</label> </div>
     <div class="col-sm-8"> <asp:TextBox ID="bstprice_text" runat="server" Placeholder="Enter Best Price.." CssClass="form-control" Enabled="false" required ></asp:TextBox> <br /></div>
 

<div class="col-sm-4">  <label for="isapp_text" class="" style="line-height:30px;">IsApplicable From</label>    </div>
  <div class="col-sm-8">     <asp:TextBox ID="isapp_text" runat="server" Placeholder="Enter Date.." CssClass="form-control" Textmode="Date" required></asp:TextBox> <br /></div>

 <div class="col-auto" style=" color:black; padding-bottom:40px; padding-left:190px">
                    <div class="form-check mb-2">
                    <asp:CheckBox ID="chkIsActive" runat="server" Checked="true"/>  
                        <label class="form-check-label" for="chkIsActive">
                      IsActive
                     </label>
                      </div>
                    
      <asp:Button ID="Button1" runat="server"  Text="Save" OnClick="savprice_Click" CssClass="btn btn-primary mb-2" /> &nbsp;
                    <asp:Button ID="Button2" runat="server" OnClick="btnprcecancl_Click" Text="Cancel"  CssClass="btn btn-default btn-danger"  CausesValidation="false" UseSubmitBehavior="false"/>  
                     </div>
                     </div>
                      </div>
                           
                            </div>
                       </div>

                      </ContentTemplate>
                    </asp:UpdatePanel> 
       
   

    <script type="text/javascript">

        $(document).ready(function ()
        {
            $(".container").hide(0).delay(100).fadeIn(1000);

        })

    </script>                 
            

</asp:Content>
