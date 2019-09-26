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
    public partial class adduseradmin : System.Web.UI.Page
    {
        LoginAdmin Objadminlogin = new LoginAdmin();
        DataSet dsALogin = new DataSet();
        Level objLevel = new Level();
        Store objStore = new Store();
        int admin_id;
        string Name, Password, Email;
        Adduseradmin objaddusradmn = new Adduseradmin();
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
                    AccessData();
                    lblcategory.Text = "Update User";
                }
                FillDropDownValue();
            }
        }

        private void AccessData()
        {
            DataSet ds = new DataSet();
            ds = objaddusradmn.GetAddUserAdminView(recid,"");

            if (ds.Tables[0].Rows.Count > 0)
            {
                usradm_text.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                usrpass_text.Text = ds.Tables[0].Rows[0]["Password"].ToString();
                ddladminuser.Text = ds.Tables[0].Rows[0]["Level_Id"].ToString();
                usrmob_text.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                usremail_text.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                chkbxusr.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["isActive"].ToString());
                ddlstore.Text = ds.Tables[0].Rows[0]["Store_ID"].ToString();
            }
        }

        protected void Btnsaveadmusr_Click(object sender, EventArgs e)
        {
               DataSet ds = new DataSet();

               ds = objaddusradmn.GetAddUserAdminView(0, usradm_text.Text);

               if (ds.Tables[0].Rows.Count >= 1 && Flag == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('User Name Already Exists');", true);
            }
            else
            {
                saveUseradmin();

                if (Flag == 2)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('User updated Successfully'); window.location='" + Request.ApplicationPath + "Admin/adduseradminview.aspx';", true);
                }

            } ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('User added Successfully'); window.location='" + Request.ApplicationPath + "Admin/adduseradminview.aspx';", true);
        }

        public void GetAdminUser()
        {
            DataSet ds2 = new DataSet();
            ds2 = objaddusradmn.GetAddUserAdmin();
        }
        public void saveUseradmin()         
        {
            DataSet ds1 = new DataSet();

            int admin_id, Level_Id,Alteredby, CreatedBy, Store_ID;
            string Name, Password, Email, Mobile;
            bool isActive;
            DateTime CreatedDate, AlteredDate;

            admin_id = recid;
            Name = usradm_text.Text;
            Password = usrpass_text.Text;
            Email = usremail_text.Text;
            Mobile = usrmob_text.Text;
            Level_Id = Convert.ToInt32(ddladminuser.SelectedValue);
            Store_ID = Convert.ToInt32(ddlstore.SelectedValue);
            isActive = chkbxusr.Checked;
            CreatedBy = 1;
            CreatedDate = DateTime.Now;
            Alteredby = 1;
            AlteredDate = DateTime.Now;

            ds1 = objaddusradmn.SaveAddUserAdmin(Flag, admin_id, Name, Password, Email, Mobile, Level_Id,Store_ID, isActive, CreatedBy, CreatedDate, Alteredby, AlteredDate);
        }

        public void FillDropDownValue()
        {
            DataSet dsLevel = new DataSet();
            dsLevel = objLevel.GetLevelView(0);

            ddladminuser.DataSource = dsLevel;
            ddladminuser.DataValueField = "Level_Id";
            ddladminuser.DataTextField = "LevelName";
            ddladminuser.DataBind();
            ddladminuser.Items.Insert(0, "Select User Type");

            DataSet dsStore = new DataSet();
            dsStore = objStore.GetStoreView(0, "");

            ddlstore.DataSource = dsStore;
            ddlstore.DataValueField = "Store_ID";
            ddlstore.DataTextField = "Store_Name";
            ddlstore.DataBind();
            ddlstore.Items.Insert(0, "Select Store");

        }

        protected void btncancladm_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/adduseradminview.aspx");
        }
    }
}