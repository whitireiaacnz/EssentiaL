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
    public partial class store : System.Web.UI.Page
    {
        LoginAdmin Objadminlogin = new LoginAdmin();
        DataSet dsALogin = new DataSet();
        int admin_id;
        string Name, Password, Email;
        Store objStore = new Store();
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
                    lblstor.Text = "Update Store";
                    AccessData();


                }

            }
        }

        private void AccessData()
        {
            DataSet ds = new DataSet();
            ds = objStore.GetStoreView(recid,"");

            if (ds.Tables[0].Rows.Count > 0)
            {
                TextBox1.Text = ds.Tables[0].Rows[0]["Store_Name"].ToString();
                chkIsActive.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["isActive"].ToString());
                add1_text.Text = ds.Tables[0].Rows[0]["Add1"].ToString();
                add2_text.Text = ds.Tables[0].Rows[0]["Add2"].ToString();
                cityname_text.Text = ds.Tables[0].Rows[0]["CityName"].ToString();
                statename_text.Text = ds.Tables[0].Rows[0]["StateName"].ToString();
                pincode_text.Text = ds.Tables[0].Rows[0]["PinCode"].ToString();
            }
        }

        protected void btnsavstore_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            ds = objStore.GetStoreView(0, TextBox1.Text);

            if (ds.Tables[0].Rows.Count >= 1 && Flag == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Store Name Already Exists');", true);
            }
            else
            {
                saveStore();
                if (Flag == 2)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Store updated Successfully'); window.location='" + Request.ApplicationPath + "Admin/StoreView.aspx';", true);
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Store added Successfully'); window.location='" + Request.ApplicationPath + "Admin/StoreView.aspx';", true);
            }
        }

        public void GetStore()
        {
            DataSet ds = new DataSet();
            ds = objStore.GetStore();
        }

        public void saveStore()
        {
            DataSet ds1 = new DataSet();

            int Store_Id, Alteredby, CreatedBy,Pincode;
            string StoreName,CityName, StateName, Add1, Add2; ;
            bool isActive;
            DateTime CreatedDate, AlteredDate;


            Store_Id = recid;
            StoreName = TextBox1.Text;
            Add1 = add1_text.Text;
            Add2 = add2_text.Text;
            StateName = statename_text.Text;
            CityName = cityname_text.Text;
            Pincode = Convert.ToInt32(pincode_text.Text);
            isActive = chkIsActive.Checked;
            CreatedBy = 1;
            CreatedDate = DateTime.Now;
            Alteredby = 1;
            AlteredDate = DateTime.Now;

            ds1 = objStore.SaveStore(Flag, Store_Id, StoreName, Add1, Add2, StateName, CityName, Pincode, isActive, CreatedBy, CreatedDate, Alteredby, AlteredDate);
        }

        protected void btnsavecancl_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/StoreView.aspx");
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}