<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userlogout.aspx.cs" Inherits="EssentialWeb.userlogout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  
    <link type="text/css" href="css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.8.19.custom.min.js"></script>
    <script src="../js/jquery-1.7.1.min.js"></script>
    <script src="../js/jquery-ui-1.7.3.custom.min.js"></script>
    <link href="../ui-lightness/jquery-ui-1.8.22.custom.css" rel="stylesheet" />
    <link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap-theme.min.css" />
    <link href="../dist/css/sb-admin-2.css" rel="stylesheet" />
    <link href="../dist/css/timeline.css" rel="stylesheet" />

    <link href="bower_components/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <div class="jumbotron" style="text-align:center">    
        <table class="nav-justified">
            <tr>
             <td>
                   You have successfully logged out ....
                    <asp:LinkButton ID="linkloginagain" runat="server" OnClick="linkloginagain_Click">Click Here</asp:LinkButton>&nbsp; to Login again...
             </td>
            </tr>            
    </table>

    </div>
    </form>
</body>
</html>
