using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ClassLibrary;
using System.Configuration;
using EssentialWeb.App_Code;
using System.IO;
using System.Net.Mail;
using System.Net;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;
using DevExpress.Data;
namespace EssentialWeb
{
    public partial class pricelistview : System.Web.UI.Page
    {

        PriceList objPricelist = new PriceList();
        LoginAdmin Objadminlogin = new LoginAdmin();
        DataSet dsALogin = new DataSet();
        int admin_id;

        SiteCommon objCommon = new SiteCommon();

        string Name, Password, Email;
        int recid, Flag;
        private string NewScheduleRedirect = @"~/admin/pricelist.aspx";     
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

            ScheduleDisplay();
        }

        public void ScheduleDisplay()
        {
            DataSet ds = new DataSet();
            //ds = ObjSchedule.Sp_GetBrand(0, Partners_Id);
            ds = objPricelist.GetPriceListView(0);
            dg.DataSource = ds;
            dg.DataBind();
        }
        protected void btnAddNewRecord_Click(object sender, EventArgs e)
        {
            int id = 0;
            Response.Redirect(NewScheduleRedirect + "?flag=MQA=&code=" + crypt.EncryptInteger(id));
        }

        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            dgExport.WriteXlsxToResponse();
        }

        private void ApplyLayout(int layoutIndex)
        {
            dg.BeginUpdate();
            try
            {
                dg.ClearSort();
                switch (layoutIndex)
                {
                    case 1:
                        {
                            dg.GroupBy(dg.Columns["MSP"]);
                            break;
                        }

                    case 2:
                        {
                            dg.GroupBy(dg.Columns["Dp"]);
                            break;
                        }
                    case 3:
                        {
                            dg.GroupBy(dg.Columns[""]);
                            dg.GroupBy(dg.Columns[""]);
                            break;
                        }
                }

            }

            finally
            {
                dg.EndUpdate();
            }
        }

        protected void dg_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] parakey = e.Parameters.Split('|');

            if (parakey[1] == "FeildGrp")
                ApplyLayout(Int32.Parse(parakey[0]));
            else if (parakey[1] == "PagerCombo")
            {
                GridPageSize = int.Parse(parakey[0]);
                dg.SettingsPager.PageSize = GridPageSize;
                dg.DataBind();
            }
        }


        protected int GridPageSize
        {
            get
            {
                if (Session["partnerlogin"] == null)
                    return dg.SettingsPager.PageSize;
                return System.Convert.ToInt32(Session["partnerlogin"]);
            }
            set
            {
                Session["partnerlogin"] = value;
            }
        }

        protected void dg_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            int id = Convert.ToInt32(dg.GetRowValuesByKeyValue(e.EditingKeyValue, "PriceList_Id"));
            ASPxWebControl.RedirectOnCallback(NewScheduleRedirect + "?flag=MgA=&code=" + crypt.EncryptInteger(id));

        }

        protected void dg_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int id = Convert.ToInt32(e.Keys["PriceList_Id"]);
            objCommon.DeleteMasters("tbl_PriceList", "PriceList_Id", id, true);
            e.Cancel = true;
            ScheduleDisplay();

        }
        protected void dg_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack))
            {
                for (int i = 0; i <= dg.Columns.Count - 1; i++)
                {
                    if (dg.Columns[i] is GridViewCommandColumn)
                    {
                        break;
                    }
                }
            }
        }

        protected void dg_CustomErrorText(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomErrorTextEventArgs e)
        {
            if (e.Exception is System.Data.SqlClient.SqlException)
                e.ErrorText = "Can not delete entry as it is already referenced in another module !!";
            else
                e.ErrorText = "Internal error occured !! Please try after some time !!";
        }
        protected void dg_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewColumnDisplayTextEventArgs e)
        {

        }
        protected void Combo_Load(object sender, EventArgs e)
        {
            ASPxComboBox s = sender as ASPxComboBox;
            s.Value = dg.SettingsPager.PageSize;
        }
        protected void btnPDFExport_Click(object sender, EventArgs e)
        {

        }

    }
}