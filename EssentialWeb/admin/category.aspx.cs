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
    public partial class category : System.Web.UI.Page
    {

        LoginAdmin Objadminlogin = new LoginAdmin();
        DataSet dsALogin = new DataSet();

        Group objGroup = new Group();

        int admin_id;
        string Name, Password, Email;
        Category objCategory = new Category();
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
                    lblcategory.Text = "Update Category";
                }
                FillDropDownValue();
            }
        }

        private void AccessData()
        {
            DataSet ds = new DataSet();
            ds = objCategory.GetCategoryView(recid,"");

            if (ds.Tables[0].Rows.Count > 0)
            {
                Category_text.Text = ds.Tables[0].Rows[0]["Category_Name"].ToString();
                CheckBox_category.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["isActive"].ToString());
                ddlgrp.Text = ds.Tables[0].Rows[0]["Group_Id"].ToString();
            }

        }

        protected void Btnsavecategory_Click(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();

            ds = objCategory.GetCategoryView(0, Category_text.Text);

            if (ds.Tables[0].Rows.Count >= 1 && Flag==1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Category Name Already Exists');", true);
            }
            else
            {
                saveCategory();

                if (Flag == 2)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Category updated Successfully'); window.location='" + Request.ApplicationPath + "Admin/CategoryView.aspx';", true);
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Category added Successfully'); window.location='" + Request.ApplicationPath + "Admin/CategoryView.aspx';", true);
            }
        }

        public void GetCategory()
        {
            DataSet ds2 = new DataSet();
            ds2 = objCategory.GetCategory();

        }

        public void saveCategory()
        {
            DataSet ds1 = new DataSet();

            int Category_Id, Alteredby, CreatedBy, Group_Id;
            string CategoryName;
            bool isActive;
            DateTime CreatedDate, AlteredDate;

            Category_Id = recid;
            CategoryName = Category_text.Text;
            Group_Id = Convert.ToInt32(ddlgrp.SelectedValue);
            isActive = CheckBox_category.Checked;
            CreatedBy = 1;
            CreatedDate = DateTime.Now;
            Alteredby = 1;
            AlteredDate = DateTime.Now;

            ds1 = objCategory.SaveCategory(Flag, Category_Id, CategoryName, Group_Id, isActive, CreatedBy, CreatedDate, Alteredby, AlteredDate);
        }

        public void FillDropDownValue()
        {
            DataSet dsGroup = new DataSet();
            dsGroup = objGroup.GetGroupView(0,"");

            ddlgrp.DataSource = dsGroup;
            ddlgrp.DataValueField = "Group_Id";
            ddlgrp.DataTextField = "Group_Name";
            ddlgrp.DataBind();
            ddlgrp.Items.Insert(0, "Select Group");

        }
        protected void btncatcancl_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/CategoryView.aspx");
        }
    }
}