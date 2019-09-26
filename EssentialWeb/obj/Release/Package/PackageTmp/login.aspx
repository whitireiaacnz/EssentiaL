<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="EssentialWeb.Login"  EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="bower_components/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../bower_components/metisMenu/dist/metisMenu.min.css" rel="stylesheet"/>
    <link href="../dist/css/sb-admin-2.css" rel="stylesheet"/>
    <link href="../bower_components/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
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
                                <asp:TextBox ID="txtemail" class="form-control" placeholder="E-mail" required="true" name="email" autofocus="true" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtpassword" class="form-control" placeholder="Password" required="true" type="password" autofocus="true" runat="server"></asp:TextBox>
                            </div>
                            <div class="checkbox">
                                <label>
                                    <asp:CheckBox ID="chklogin" runat="server" />
                                    Remember Me
                                </label>
                            </div>
                            <asp:Button ID="btn_login" class="btn btn-lg btn-primary btn-block" runat="server" Text="Login" OnClick="btn_login_Click" />
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
