using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ClassLibrary;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Net;
using EssentialWeb.App_Code;
namespace EssentialWeb
{
    public partial class Login : System.Web.UI.Page
    {
        LoginAdmin Objadminlogin = new LoginAdmin();
        DataSet dsALogin = new DataSet();
        private int admin_id, Level_Id;
        private string Name, Password, Email;
        private const string RedirectUrl = "~/default.aspx";
        const int CookieExpiresTime = 12;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != null) Response.Redirect(SiteCommon.UserDefaultURL);
            CheckLoginDataCookie(); // 'Retrive Login Data from Cookie

            if (IsPostBack == false)
            {                
                if (txtemail.Enabled == true) txtemail.Focus();
            }
        }
        protected void CheckLoginDataCookie()
        {
            // Assuming user comes back after several hours. several < 12.
            // Read the cookie from Request.
            HttpCookie AdminloginCookie = Request.Cookies["loginCookie"];
            // No cookie found or cookie expired.
            // Handle the situation here, Redirect the user or simply return;
            if (AdminloginCookie != null)
            {
                // ok - cookie is found.
                // Gracefully check if the cookie has the key-value as expected.

                if (!string.IsNullOrEmpty(AdminloginCookie.Values["Name"]))
                {
                    // Yes userId is found. Mission accomplished.
                    Name = AdminloginCookie.Values["Name"].ToString();
                    Password = AdminloginCookie.Values["Password"].ToString();
                    LoginProcess(1);
                }
            }
        }
        protected void LoginProcess(byte CalledFrom)
        {
            if (CalledFrom == 1)
            {
                Name = Name;
                Password = Password;
            }
            else if (CalledFrom == 2)
            {
                Name = Convert.ToString(txtemail.Text.Trim());
                Password = Convert.ToString(txtpassword.Text.Trim());
            }
            Objadminlogin.ValidateAdminLogin(Name, Password, ref admin_id, ref Email, ref Level_Id);

            if (admin_id != 0 && Level_Id != 1)
            {
                //App_Param.AdminAppParam(admin_id, Name, Email, 2);
                //int Admin_ID, string Admin_Name, string Admin_Email, int CalledFrom
                // App_Param.AdminInitUSer(admin_id, Name, Email, 2);

                Session["login"] = LoginAdmin.adlogin(Name, Password, admin_id, Email, Level_Id);
                if (CalledFrom == 2)
                {
                    //if (chk_Remember.Checked == true) SaveLoginDatatoCookie(); // 'Save Login Values into Cookie
                    //SaveLoginHistory(admin_ID);
                }                
                Response.Redirect(SiteCommon.UserDefaultURL);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Username or password Incorrect');", true);
            }
        }    
        protected void btn_login_Click(object sender, EventArgs e)
        {
            LoginProcess(2);
        }       
    }
}