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
using System.Web.Services.Description;
namespace EssentialWeb.admin
{
    public partial class group : System.Web.UI.Page
    {

        LoginAdmin Objadminlogin = new LoginAdmin();
        DataSet dsALogin = new DataSet();
        int admin_id;
        string Name, Password, Email;

        Group objGroup = new Group();
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
                    lblgroup.Text = "Update Group";
                }
            }
        }

        private void AccessData()
        {
            DataSet ds = new DataSet();
            ds = objGroup.GetGroupView(recid,"");

            if (ds.Tables[0].Rows.Count > 0)
            {
                Group_txt.Text = ds.Tables[0].Rows[0]["Group_Name"].ToString();
                isactive_group.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["isActive"].ToString());
            }

        }

        protected void btnsavgrp_Click(object sender, EventArgs e)
        {
              DataSet ds = new DataSet();

              ds = objGroup.GetGroupView(0, Group_txt.Text);

              if (ds.Tables[0].Rows.Count >= 1 && Flag == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Group Name Already Exists');", true);
            }
            else
            {
                saveGroup();
                if (Flag == 2)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Group updated Successfully'); window.location='" + Request.ApplicationPath + "Admin/GroupView.aspx';", true);
                }
                // string message = "Your details have been saved successfully.";
                // string script = "window.onload = function(){ alert('"; script += message; script += "')};";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Group added Successfully'); window.location='" + Request.ApplicationPath + "Admin/GroupView.aspx';", true);
                // Response.Redirect(RedirectURL);

            }
        }
        public void GetGroup()
        {
            DataSet ds = new DataSet();
            ds = objGroup.GetGroup();
        }

        public void saveGroup()
        {
            DataSet ds1 = new DataSet();
            int Group_Id, Alteredby, CreatedBy;
            string GroupName;
            bool isActive;
            DateTime CreatedDate, AlteredDate;

            Group_Id = recid;
            GroupName = Group_txt.Text;
            isActive = isactive_group.Checked;
            CreatedBy = 1;
            CreatedDate = DateTime.Now;
            Alteredby = 1;
            AlteredDate = DateTime.Now;

            ds1 = objGroup.SaveGroup(Flag, Group_Id, GroupName, isActive, CreatedBy, CreatedDate, Alteredby, AlteredDate);
        }

        protected void btngrpcancl_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/GroupView.aspx");
        }

    }
}