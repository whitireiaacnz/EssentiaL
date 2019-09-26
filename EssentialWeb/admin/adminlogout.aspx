<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="adminlogout.aspx.cs" Inherits="EssentialWeb.adminlogout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content2" runat="server">

    <div class="jumbotron" style="text-align:center">

            <table class="nav-justified">
                <tr>
                    <td>
                       You have successfully logged out ....
                        <asp:LinkButton ID="linkloginagain" runat="server" OnClick="linkloginagain_Click">Click Here</asp:LinkButton>&nbsp; to Login again...</td>
             
                </tr>

                <tr>
                    <td><br /></td>
                </tr>
                <tr>    
                    <td><br /></td>
                </tr>
                <tr>
                    <td><br /></td>
                </tr>
            </table>    
            <br />
            <br />
            </div>
</asp:Content>
