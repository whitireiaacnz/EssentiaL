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
namespace EssentialWeb.admin
{
    public partial class admindefault : System.Web.UI.Page
    {
        DataSet dslogin = new DataSet();
        int admin_id;
        string Name1, Password1, Email1;
        int recid1, Flag1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Adminlogin"] != null)
            {
                dslogin = (DataSet)Session["Adminlogin"];

                Name1 = dslogin.Tables[0].Rows[0]["Name"].ToString();
                Password1 = dslogin.Tables[0].Rows[0]["Password"].ToString();
                Email1 = dslogin.Tables[0].Rows[0]["Email"].ToString();
                admin_id = Convert.ToInt32(dslogin.Tables[0].Rows[0]["admin_id"].ToString());
            }
            else
            {
                Response.Redirect(SiteCommon.AdminLoginURL);
            }
        }
    }
}