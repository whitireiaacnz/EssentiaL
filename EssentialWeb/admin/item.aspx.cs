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
    public partial class item : System.Web.UI.Page
    {
        LoginAdmin Objadminlogin = new LoginAdmin();
        DataSet dsALogin = new DataSet();

        Brand objBrand = new Brand();
        Category objCategory = new Category();
        Group objGroup = new Group();
        Scheme objScheme = new Scheme();
        Store objStore = new Store();

        int admin_id;
        string Name, Password, Email;
        Item objItem = new Item();
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
                    Label1.Text = "Upadte Item";
                    AccessData();
                }
                FillDropDownValue();
            }
        }

        private void AccessData()
        {
            DataSet ds = new DataSet();
            ds = objItem.GetItemView(recid);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model_text.Text = ds.Tables[0].Rows[0]["ModelNo"].ToString();
                chkIsActive.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["isActive"].ToString());

                clr_text.Text = ds.Tables[0].Rows[0]["Color"].ToString();
                sze_text.Text = ds.Tables[0].Rows[0]["Size"].ToString();
                feture_text.Text = ds.Tables[0].Rows[0]["Features"].ToString();
                ddlBrand.SelectedValue = ds.Tables[0].Rows[0]["Brand_Id"].ToString();
                ddlCategory.SelectedValue = ds.Tables[0].Rows[0]["Category_Id"].ToString();
                ddlGroup.SelectedValue = ds.Tables[0].Rows[0]["Group_Id"].ToString();
                ddlScheme.SelectedValue = ds.Tables[0].Rows[0]["Scheme_Id"].ToString();
                mrp_text.Text = ds.Tables[0].Rows[0]["MRP"].ToString();
                dprice_text.Text = ds.Tables[0].Rows[0]["DP"].ToString();
                msp_text.Text = ds.Tables[0].Rows[0]["MSP"].ToString();
                bstprice_text.Text = ds.Tables[0].Rows[0]["BestPrice"].ToString();
                dscnt_text.Text = ds.Tables[0].Rows[0]["Discounts"].ToString();
                isapp_text.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["IsApplicableFrom"]).ToString("yyyy-MM-dd");
                itm_text.Text = ds.Tables[0].Rows[0]["Item_Name"].ToString();
                //ddlScheme.SelectedValue = ds.Tables[0].Rows[0]["Scheme_Id"].ToString();
                //ddlStore.SelectedValue = ds.Tables[0].Rows[0]["Store_Id"].ToString();

            }
        }
        protected void btnsavitm_Click(object sender, EventArgs e)
        {

            saveItem();
            if (Flag == 2)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Item updated Successfully'); window.location='" + Request.ApplicationPath + "Admin/ItemView.aspx';", true);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Item added Successfully'); window.location='" + Request.ApplicationPath + "Admin/ItemView.aspx';", true);


        }

        protected void btnitmcancl_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/ItemView.aspx");

        }

        public void GetItem()
        {
            DataSet ds = new DataSet();
            ds = objItem.GetItem();
        }

       
        public void saveItem()
        {
            DataSet ds = new DataSet();

            int Item_Id, Brand_Id, Category_Id, Group_Id, MspCalc, BpCalc, MspF, BpF,Scheme_Id, CreatedBy, Alteredby;
            string Item_Name, ModelNo, Color, Size, Features, Category_Name, Brand_Name, Group_Name, Discounts;
            float MRP, DP, MspPer, MSP, BestPrice, BpPer;
            bool isActive;
            DateTime CreatedDate,isApplicableFrom, AlteredDate;

            DataSet dsScheme = new DataSet();
            dsScheme = objScheme.GetSchemeView(Convert.ToInt32(ddlScheme.SelectedValue),"");

            MspPer = Convert.ToSingle(dsScheme.Tables[0].Rows[0]["msp"]);
            BpPer = Convert.ToSingle(dsScheme.Tables[0].Rows[0]["bp"]);

            Item_Id = recid;
            Brand_Id = Convert.ToInt32(ddlBrand.SelectedValue);
            Category_Id = Convert.ToInt32(ddlCategory.SelectedValue);
            Category_Name = ddlCategory.SelectedItem.Text;
            Brand_Name = ddlBrand.SelectedItem.Text;
            Group_Name = ddlGroup.SelectedItem.Text;
            Group_Id = Convert.ToInt32(ddlGroup.SelectedValue);
            MRP = Convert.ToSingle(mrp_text.Text);
            DP = Convert.ToSingle(dprice_text.Text);
            Scheme_Id = Convert.ToInt32(ddlScheme.SelectedValue);
            //Store_Id = Convert.ToInt32(ddlStore.SelectedValue);
            MspCalc = Convert.ToInt32((MspPer / 100) * DP);
            BpCalc = Convert.ToInt32((BpPer / 100) * DP);
            MspF = Convert.ToInt32(DP - MspCalc);
            BpF = Convert.ToInt32(DP - BpCalc);
            MSP = MspF; 
            BestPrice = BpF;
            Discounts = dscnt_text.Text;
            ModelNo = model_text.Text;
            Color = clr_text.Text;
            Size = sze_text.Text;
            Features = feture_text.Text;
            Item_Name = ModelNo + " " + Brand_Name + " " + Category_Name + " " + Group_Name + " " + Color + " " + Features + " " + Size;
            isApplicableFrom = Convert.ToDateTime(isapp_text.Text);
            isActive = chkIsActive.Checked;
            CreatedBy = 1;
            CreatedDate = DateTime.Now;
            Alteredby = 1;
            AlteredDate = DateTime.Now;

            ds = objItem.SaveItem(Flag, Item_Id, Item_Name, ModelNo, Color, Size, Features, Brand_Id, Category_Id, Group_Id, Scheme_Id, MRP, isApplicableFrom, DP,MSP,BestPrice, Discounts, isActive, CreatedBy, CreatedDate, Alteredby, AlteredDate);

        }

        public void FillDropDownValue()
        {
            DataSet dsBrand = new DataSet();
            dsBrand = objBrand.GetBrandView(0,"");

            ddlBrand.DataSource = dsBrand;
            ddlBrand.DataValueField = "Brand_Id";
            ddlBrand.DataTextField = "Brand_Name";
            ddlBrand.DataBind();
            ddlBrand.Items.Insert(0, "Select Brand");

            DataSet dsCategory = new DataSet();
            dsCategory = objCategory.GetCategoryView(0,"");

            ddlCategory.DataSource = dsCategory;
            ddlCategory.DataValueField = "Category_Id";
            ddlCategory.DataTextField = "Category_Name";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, "Select Category");

            DataSet dsGroup = new DataSet();
            dsGroup = objGroup.GetGroupView(0,"");

            ddlGroup.DataSource = dsGroup;
            ddlGroup.DataValueField = "Group_Id";
            ddlGroup.DataTextField = "Group_Name";
            ddlGroup.DataBind();
            ddlGroup.Items.Insert(0, "Select Group");

            DataSet dsScheme = new DataSet();
            dsScheme = objScheme.GetSchemeView(0,"");

            ddlScheme.DataSource = dsScheme;
            ddlScheme.DataValueField = "Scheme_Id";
            ddlScheme.DataTextField = "Scheme_Name";
            ddlScheme.DataBind();
            ddlScheme.Items.Insert(0, "Select Scheme");

            //DataSet dsStore = new DataSet();
            //dsStore = objStore.GetStoreView(0);

            //ddlStore.DataSource = dsStore;
            //ddlStore.DataValueField = "Store_Id";
            //ddlStore.DataTextField = "Store_Name";
            //ddlStore.DataBind();
            //ddlStore.Items.Insert(0, "Select Store");
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsCategory = new DataSet();
            dsCategory = objCategory.GetCategoryView(Convert.ToInt32(ddlCategory.SelectedValue),"");

            int GroupID = Convert.ToInt32(dsCategory.Tables[0].Rows[0]["Group_Id"]);

            DataSet dsGroup = new DataSet();
            dsGroup = objGroup.GetGroupView(GroupID,"");

            ddlGroup.DataSource = dsGroup;
            ddlGroup.DataValueField = "Group_Id";
            ddlGroup.DataTextField = "Group_Name";
            ddlGroup.DataBind();
            ddlGroup.Items.Insert(0, "Select Group");
        }

        protected void ddlScheme_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DataSet dsScheme = new DataSet();
            dsScheme = objScheme.GetSchemeView(Convert.ToInt32(ddlScheme.SelectedValue),"");

            int Scheme_Id, MspCalc, BpCalc, MspF, BpF, MSP, BestPrice;
            float MRP, DP, MspPer, BpPer;


            MspPer = Convert.ToSingle(dsScheme.Tables[0].Rows[0]["msp"]);
            BpPer = Convert.ToSingle(dsScheme.Tables[0].Rows[0]["bp"]);

            MRP = Convert.ToSingle(mrp_text.Text);
            Scheme_Id = Convert.ToInt32(ddlScheme.SelectedValue);
            DP = Convert.ToSingle(dprice_text.Text);
            MspCalc = Convert.ToInt32((MspPer / 100) * DP);
            BpCalc = Convert.ToInt32((BpPer / 100) * DP);
            MspF = Convert.ToInt32(DP - MspCalc);
            BpF = Convert.ToInt32(DP - BpCalc);
            MSP = MspF;
            BestPrice = BpF;
            msp_text.Text = Convert.ToInt32(MSP).ToString();
            bstprice_text.Text = Convert.ToInt32(BestPrice).ToString();
        }

  protected void dprice_text_TextChanged(object sender,EventArgs e)
        {
            DataSet dsScheme = new DataSet();
            dsScheme = objScheme.GetSchemeView(Convert.ToInt32(ddlScheme.SelectedValue),"");

            int Scheme_Id, MspCalc, BpCalc, MspF, BpF, MSP, BestPrice;
            float MRP, DP, MspPer, BpPer;


            MspPer = Convert.ToSingle(dsScheme.Tables[0].Rows[0]["msp"]);
            BpPer = Convert.ToSingle(dsScheme.Tables[0].Rows[0]["bp"]);

            MRP = Convert.ToSingle(mrp_text.Text);
            Scheme_Id = Convert.ToInt32(ddlScheme.SelectedValue);
            DP = Convert.ToSingle(dprice_text.Text);
            MspCalc = Convert.ToInt32((MspPer / 100) * DP);
            BpCalc = Convert.ToInt32((BpPer / 100) * DP);
            MspF = Convert.ToInt32(DP - MspCalc);
            BpF = Convert.ToInt32(DP - BpCalc);
            MSP = MspF;
            BestPrice = BpF;
            msp_text.Text = Convert.ToInt32(MSP).ToString();
            bstprice_text.Text = Convert.ToInt32(BestPrice).ToString();
        }

    }
}