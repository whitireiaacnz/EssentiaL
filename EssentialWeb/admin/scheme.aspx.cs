using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using EssentialWeb.App_Code;
using System.Drawing;
using ClassLibrary;
namespace EssentialWeb.admin
{
    public partial class scheme : System.Web.UI.Page
    {
        LoginAdmin Objadminlogin = new LoginAdmin();
        DataSet dsALogin = new DataSet();
        int admin_id, Level_Id;
        string Name, Password, Email;
        Scheme objScheme = new Scheme();
        int recid, Flag;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Adminlogin"] != null)
            {
                dsALogin = (DataSet)Session["Adminlogin"];

                Name = dsALogin.Tables[0].Rows[0]["Name"].ToString();
                Password = dsALogin.Tables[0].Rows[0]["Password"].ToString();
                Email = dsALogin.Tables[0].Rows[0]["Email"].ToString();
                admin_id = Convert.ToInt32(dsALogin.Tables[0].Rows[0]["admin_id"].ToString());
                Level_Id = Convert.ToInt32(dsALogin.Tables[0].Rows[0]["Level_Id"].ToString());
            }

            else
            {
                Response.Redirect(SiteCommon.AdminLoginURL);
            }
            recid = crypt.DecryptToInt(Request.QueryString["code"]);
            recid = Convert.ToInt32(recid) <= 0 ? 0 : recid;

            Flag = crypt.DecryptToInt(Request.QueryString["flag"]);
            Flag = Convert.ToInt32(Flag) <= 0 ? 1 : Flag;

            if ((!IsPostBack))
            {
                if (recid != 0)
                {
                    lblschem.Text = "Update Scheme";
                    AccessData();
                }
            }
        }

        private void AccessData()
        {
            DataSet ds = new DataSet();
            ds = objScheme.GetSchemeView(recid,"");

            if (ds.Tables[0].Rows.Count > 0)
            {
                TextBox1.Text = ds.Tables[0].Rows[0]["Scheme_Name"].ToString();
                chkIsActive.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["isActive"].ToString());
                msptxt.Text = (ds.Tables[0].Rows[0]["msp"].ToString());
                bptxt.Text = (ds.Tables[0].Rows[0]["bp"].ToString());

            }
        }
        protected void btnsavschm_Click(object sender, EventArgs e)
        {
              DataSet ds = new DataSet();

              ds = objScheme.GetSchemeView(0, TextBox1.Text);

              if (ds.Tables[0].Rows.Count >= 1 && Flag == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Scheme Name Already Exists');", true);
            }
            else
            {

                saveScheme();
                if (Flag == 2)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Scheme updated Successfully'); window.location='" + Request.ApplicationPath + "Admin/SchemeView.aspx';", true);
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Scheme added Successfully'); window.location='" + Request.ApplicationPath + "Admin/SchemeView.aspx';", true);
            }
        }

        public void GetScheme()
        {
            DataSet ds = new DataSet();
            ds = objScheme.GetScheme();
        }

        public void saveScheme()
        {
            DataSet ds1 = new DataSet();

            int Scheme_Id, Alteredby, CreatedBy;
            float msp, bp;
            string SchemeName;
            bool isActive;
            DateTime CreatedDate, AlteredDate;


            Scheme_Id = recid;
            SchemeName = TextBox1.Text;
            msp = Convert.ToSingle(msptxt.Text);
            bp = Convert.ToSingle(bptxt.Text);
            isActive = chkIsActive.Checked;
            CreatedBy = 1;
            CreatedDate = DateTime.Now;
            Alteredby = 1;
            AlteredDate = DateTime.Now;

            ds1 = objScheme.SaveScheme(Flag, Scheme_Id, SchemeName, msp, bp, isActive, CreatedBy, CreatedDate, Alteredby, AlteredDate);
        }


        protected void btnschmcancl_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/SchemeView.aspx");
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}