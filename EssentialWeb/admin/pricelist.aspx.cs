using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ClassLibrary;
using System.IO;
using EssentialWeb.App_Code;
using System.Drawing;
namespace EssentialWeb.admin
{
    public partial class pricelist : System.Web.UI.Page
    {
        LoginAdmin Objadminlogin = new LoginAdmin();
        DataSet dsALogin = new DataSet();

        Item objItem = new Item();
        Scheme objScheme = new Scheme();

        int admin_id;
        string Name, Password, Email;
        PriceList objPricelist = new PriceList();
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
                    Label1.Text = "Update Price List";
                    AccessData();
                }
                FillDropDownValue();
            }
        }

        private void AccessData()
        {
            DataSet ds = new DataSet();
            ds = objPricelist.GetPriceListView(recid);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlItem.SelectedValue = ds.Tables[0].Rows[0]["Item_Id"].ToString();
                ddlScheme.SelectedValue = ds.Tables[0].Rows[0]["Scheme_Id"].ToString();
                mrp_text.Text = ds.Tables[0].Rows[0]["MRP"].ToString();
                chkIsActive.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["isActive"].ToString());

                dprice_text.Text = ds.Tables[0].Rows[0]["DP"].ToString();
                msp_text.Text = ds.Tables[0].Rows[0]["MSP"].ToString();
                bstprice_text.Text = ds.Tables[0].Rows[0]["BestPrice"].ToString();
                dscnt_text.Text = ds.Tables[0].Rows[0]["Discounts"].ToString();
                isapp_text.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["IsApplicableFrom"]).ToString("yyyy-MM-dd");
            }
        }

        protected void savprice_Click(object sender, EventArgs e)
        {

            savePriceList();
            if (Flag == 2)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Price updated Successfully'); window.location='" + Request.ApplicationPath + "Admin/PriceListView.aspx';", true);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Price added Successfully'); window.location='" + Request.ApplicationPath + "Admin/PriceListView.aspx';", true);

        }

        protected void btnprcecancl_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/PriceListView.aspx");
        }

        public void GetPriceList()
        {
            DataSet ds = new DataSet();
            ds = objPricelist.GetPriceList();
        }
        protected void ddlScheme_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();
            ds = objPricelist.GetPriceListView(recid);

            DataSet dsScheme = new DataSet();
            dsScheme = objScheme.GetSchemeView(Convert.ToInt32(ddlScheme.SelectedValue),"");

            int PriceList_Id, Item_Id, Scheme_Id, MspCalc, BpCalc, MspF, BpF;
            float MRP, DP, MSP, BestPrice, Discounts, MspPer, BpPer;


            MspPer = Convert.ToSingle(dsScheme.Tables[0].Rows[0]["msp"]);
            BpPer = Convert.ToSingle(dsScheme.Tables[0].Rows[0]["bp"]);

            PriceList_Id = recid;
            Item_Id = Convert.ToInt32(ddlItem.SelectedValue);
            MRP = Convert.ToSingle(mrp_text.Text);
            Scheme_Id = Convert.ToInt32(ddlScheme.SelectedValue);
            DP = Convert.ToSingle(dprice_text.Text);
            MspCalc = Convert.ToInt32((MspPer / 100) * DP);
            BpCalc = Convert.ToInt32((BpPer / 100) * DP);
            MspF = Convert.ToInt32(DP - MspCalc);
            BpF = Convert.ToInt32(DP - BpCalc);
            Discounts = Convert.ToSingle(dscnt_text.Text);
            MSP = MspF - Discounts;
            BestPrice = BpF - Discounts;
            msp_text.Text = MSP.ToString();
            bstprice_text.Text = BestPrice.ToString();
        }

        public void savePriceList()
        {
            DataSet ds = new DataSet();
            ds = objPricelist.GetPriceListView(recid);

            DataSet dsScheme = new DataSet();
            dsScheme = objScheme.GetSchemeView(Convert.ToInt32(ddlScheme.SelectedValue),"");

            int PriceList_Id, Item_Id, Scheme_Id, CreatedBy, Alteredby, MspCalc, BpCalc, MspF, BpF;
            float MRP, DP, MSP, BestPrice, Discounts, MspPer, BpPer;
            bool isActive;
            DateTime isApplicableFrom, CreatedDate, AlteredDate;


            MspPer = Convert.ToSingle(dsScheme.Tables[0].Rows[0]["msp"]);
            BpPer = Convert.ToSingle(dsScheme.Tables[0].Rows[0]["bp"]);

            PriceList_Id = recid;
            Item_Id = Convert.ToInt32(ddlItem.SelectedValue);
            MRP = Convert.ToSingle(mrp_text.Text);
            Scheme_Id = Convert.ToInt32(ddlScheme.SelectedValue);
            DP = Convert.ToSingle(dprice_text.Text);
            MspCalc = Convert.ToInt32((MspPer / 100) * DP);
            BpCalc = Convert.ToInt32((BpPer / 100) * DP);
            MspF = Convert.ToInt32(DP - MspCalc);
            BpF = Convert.ToInt32(DP - BpCalc);
            Discounts = Convert.ToSingle(dscnt_text.Text);
            MSP = MspF - Discounts;
            BestPrice = BpF - Discounts;
            isApplicableFrom = Convert.ToDateTime(isapp_text.Text);
            isActive = chkIsActive.Checked;
            CreatedBy = 1;
            CreatedDate = DateTime.Now;
            Alteredby = 1;
            AlteredDate = DateTime.Now;

            ds = objPricelist.SavePriceList(Flag, PriceList_Id, Item_Id, Scheme_Id, MRP, isApplicableFrom, DP, MSP, BestPrice, Discounts, CreatedBy, CreatedDate, Alteredby, AlteredDate, isActive);

        }

        public void FillDropDownValue()
        {
            DataSet dsItem = new DataSet();
            dsItem = objItem.GetItemView(0);

            ddlItem.DataSource = dsItem;
            ddlItem.DataValueField = "Item_Id";
            ddlItem.DataTextField = "Item_Name";
            ddlItem.DataBind();
            ddlItem.Items.Insert(0, "Select Item");

            DataSet dsScheme = new DataSet();
            dsScheme = objScheme.GetSchemeView(0,"");

            ddlScheme.DataSource = dsScheme;
            ddlScheme.DataValueField = "Scheme_Id";
            ddlScheme.DataTextField = "Scheme_Name";
            ddlScheme.DataBind();
            ddlScheme.Items.Insert(0, "Select Scheme");
        }
         
    }

}