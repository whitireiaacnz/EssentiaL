using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EssentialWeb.App_Code;

namespace EssentialWeb
{
    public partial class userlogout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("login");

            System.Web.HttpContext.Current.Session.RemoveAll();
            System.Web.HttpContext.Current.Session.Abandon();

            if ((Request.Cookies["loginCookie"] != null))
            {
                HttpCookie loginCookie;
                loginCookie = new HttpCookie("loginCookie");
                Request.Cookies["loginCookie"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(loginCookie);
            }
        }
        protected void linkloginagain_Click(object sender, EventArgs e)
        {
            Response.Redirect(SiteCommon.UserLoginURL);
        }
    }
}