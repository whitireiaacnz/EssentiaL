using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using EssentialWeb.App_Code;
//using System.Drawing;
using ClassLibrary;

namespace EssentialWeb.admin
{
    public partial class brand : System.Web.UI.Page
    {
       // SqlConnection con = new SqlConnection("Data Source=192.168.1.251;Initial Catalog=essential;User ID=sa;Password=admin@123");

        LoginAdmin Objadminlogin = new LoginAdmin();
        DataSet dsALogin = new DataSet();
        int admin_id;
        string Name, Password, Email;
        Brand objBrand = new Brand();
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
                    lblbrand.Text = "Update Brand";
                    AccessData();


                }

            }
        }

        private void AccessData()
        {
            DataSet ds = new DataSet();
            ds = objBrand.GetBrandView(recid,"");

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtBrand.Text = ds.Tables[0].Rows[0]["Brand_Name"].ToString();
                chkIsActive.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["isActive"].ToString());
            }
        }

        protected void btnsavbrnd_Click(object sender, EventArgs e)
        {

            //DataSet ds2 = new DataSet();
            //ds2 = objBrand.GetBrandView(0);
            //string t = TextBox1.Text;
            //string s = ds2.Tables[0].Rows[0]["Brand_Name"].ToString();
            //if (s.Contains(t))
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Brand Name Already Exists');", true);
            //}
            //else
            //{
            //    saveBrand();
            //}

            //SqlDataAdapter da = new SqlDataAdapter("Select Brand_Name from tbl_Brand where Brand_Name='" + TextBox1.Text + "'",con);
            //DataTable dt = new DataTable();
            //da.Fill(dt);

            DataSet ds = new DataSet();

            ds = objBrand.GetBrandView(0, txtBrand.Text);

            if (ds.Tables[0].Rows.Count >= 1 && Flag==1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Brand Name Already Exists');", true);
            }
            else
            {
                saveBrand();

                if (Flag == 2)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Brand updated Successfully'); window.location='" + Request.ApplicationPath + "Admin/BrandView.aspx';", true);
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Brand added Successfully'); window.location='" + Request.ApplicationPath + "Admin/BrandView.aspx';", true);
            }
        }


        public void GetBrand()
        {
            DataSet ds = new DataSet();
            ds = objBrand.GetBrand();
        }
        public void saveBrand()
        {
            DataSet ds1 = new DataSet();

            int Brand_Id, Alteredby, CreatedBy;
            string BrandName;
            bool isActive;
            DateTime CreatedDate, AlteredDate;

            Brand_Id = recid;
            BrandName = txtBrand.Text;
            isActive = chkIsActive.Checked;
            CreatedBy = 1;
            CreatedDate = DateTime.Now;
            Alteredby = 1;
            AlteredDate = DateTime.Now;

            ds1 = objBrand.SaveBrand(Flag, Brand_Id, BrandName, isActive, CreatedBy, CreatedDate, Alteredby, AlteredDate);
        }

        protected void btnbrndcancl_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/BrandView.aspx");
        }

    }
}