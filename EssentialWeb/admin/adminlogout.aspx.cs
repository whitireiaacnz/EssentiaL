using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClassLibrary;
using System.Configuration;
using EssentialWeb.App_Code;
using System.IO;
using System.Net.Mail;
using System.Net;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;
using DevExpress.Data;

namespace EssentialWeb
{
    public partial class adminlogout : System.Web.UI.Page
    {
        LoginAdmin ObjloginAdmin = new LoginAdmin();
        DataSet dsALogin = new DataSet();
        private int admin_ID;
        private string Login_ID, Email, Pass, Admin_Name;
     
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("Adminlogin");

            System.Web.HttpContext.Current.Session.RemoveAll();
            System.Web.HttpContext.Current.Session.Abandon();

            if ((Request.Cookies["AdminloginCookie"] != null))
            {
                HttpCookie AdminloginCookie;
                AdminloginCookie = new HttpCookie("AdminloginCookie");
                Request.Cookies["AdminloginCookie"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(AdminloginCookie);

            }

        }

        protected void linkloginagain_Click(object sender, EventArgs e)
        {
            //AdminLogoutURL
            Response.Redirect(LoginAdmin.AdminLoginURL);
        }


    }
}