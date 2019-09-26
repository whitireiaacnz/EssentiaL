using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EssentialWeb.App_Code;
using System.Data;
using System.Data.SqlClient;

namespace EssentialWeb.admin
{
    public partial class Admin1 : System.Web.UI.MasterPage
    {
        DataSet dsALogin = new DataSet();
        int admin_id;
        string Name, Password, Email;
        protected void Page_Load(object sender, EventArgs e)
        {
             if (Session["Adminlogin"] != null)
            {
                dsALogin = (DataSet)Session["Adminlogin"];

                Name = dsALogin.Tables[0].Rows[0]["Name"].ToString();
                lblusername.Text = Name;
                adminlogintbtn.Visible = false;
                adminlogoutbtn.Visible = true;
                
                //logotadmn.Visible = true;
                //lognadmn.Visible = false;
            }
            else if (Session["Adminlogin"] == null)
            {
                Response.Redirect(SiteCommon.AdminLoginURL);
                //adminlogintbtn.Visible = true;
                //adminlogoutbtn.Visible = false;
                //logotadmn.Visible = false;
                //lognadmn.Visible = true;
                
            }
        }

        protected void adminlogoutbtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/admindefault.aspx");
        }
        }
    }
