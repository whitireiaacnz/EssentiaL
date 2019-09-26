using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EssentialWeb.App_Code;
using System.Data;
using System.Data.SqlClient;
namespace EssentialWeb
{
    public partial class User : System.Web.UI.MasterPage
    {
        DataSet dsALogin = new DataSet();
        int admin_id;
        string Name, Password, Email;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != null)
            {
                dsALogin = (DataSet)Session["login"];

                Name = dsALogin.Tables[0].Rows[0]["Name"].ToString();
                lblusername.Text = Name;
                userlogintbtn.Visible = false;
                userlogoutbtn.Visible = true;
                Sales.Visible = true;                
            }
            else if (Session["login"] == null)
            {
                userlogintbtn.Visible = true;
                userlogoutbtn.Visible = false;
                Sales.Visible = false;
            }
        }
        protected void adminlogoutbtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect(SiteCommon.UserLoginURL);
        }
     
    }
}