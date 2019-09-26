<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="EssentialWeb.admin.AdminLogin" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="../bower_components/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <%--   <link href="bower_components/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet"/>--%>
    <link href="../dist/css/sb-admin-2.css" rel="stylesheet" />
    <link href="../bower_components/metisMenu/dist/metisMenu.min.css" rel="stylesheet" />
    <%--    <link href="../dist/css/sb-admin-2.css" rel="stylesheet"/>--%>
    <link href="../bower_components/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div class="login-panel panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Please Sign In</h3>
                        </div>
                        <div class="panel-body">
                            <form role="form">
                                <fieldset>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtUsername" runat="server" placeholder="Username" CssClass="form-control "></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtUserpass" runat="server" CssClass="form-control" placeholder=" Password" onkeypress="return fnAlphaNumericValidation(this,event);" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div class="checkbox">
                                        <label>
                                            <asp:CheckBox ID="chklogin" runat="server" />
                                            Remember Me
                                        </label>
                                    </div>
                                    <asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="btn_Login_Click" Text="Login" class="btn btn-lg btn-primary btn-block" />

                                </fieldset>
                            </form>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>






<%--<asp:Content ID="Content2" ContentPlaceHolderID="Adminbody" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="main"  >
                <div class="row" style="padding-top:50px;">
                        <div class="col-sm-4"></div>
               <div class="col-sm-4 m-auto" style="box-sizing:border-box; background:#f2f2f2; border-radius: 5px;" >
 <center> <asp:Label ID="lbl_Heading" runat="server" ForeColor="#666666" Font-Bold="true" Font-Size="30px" style="padding-top:20px;">ADMIN LOGIN</asp:Label></center>
             <div class="input-group" style="padding-left: 37px; border-radius: 25px; padding-top:10px;">

                <span class=" input-group-addon">
                    <i class="fa fa-user icon" style="color:#131063;"></i>
                </span>

              <asp:TextBox ID="txtUsername" runat="server" placeholder="Username" CssClass="form-control "></asp:TextBox>

            </div>       


            <div class="input-group" style="padding-top: 26px; padding-left: 37px;">
                <span class="input-group-addon">
                    <i class="fa fa-lock"  style="color:#131063;"></i>
                </span>
                <asp:TextBox ID="txtUserpass" runat="server" CssClass="form-control" placeholder=" Password" onkeypress="return fnAlphaNumericValidation(this,event);" TextMode="Password"></asp:TextBox>

            </div>

            <div class="login" style="padding-left: 38px;padding-bottom:20px; padding-top:20px;">
                <asp:Button ID="btn_Login" runat="server" Font-Bold="True" Height="33px" OnClick="btn_Login_Click" Text="Login" Width="84px" class="btn btn-success btn-default" />
                <asp:LinkButton ID="linkforgotpass" runat="server">Forgot Password</asp:LinkButton>
            </div>
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
</asp:Content>--%>
