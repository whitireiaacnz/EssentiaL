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
using System.IO;
using System.Net.Mail;
using System.Net;
using EssentialWeb.App_Code;

namespace EssentialWeb.App_Code
{
    public class LoginAdmin
    {
        SiteCommon sc = new SiteCommon();
        DAL Objdal = new DAL();

        public static string AdminDefaultURL = "~/Admin/AdminDefault.aspx";
        public static string AdminLoginURL = "~/Admin/AdminLogin.aspx";
        public static string AdminLogoutURL = "~/Admin/AdminLogout.aspx";
        public static string UserDefaultURL = "~/default.aspx";
        public static string UserLoginURL = "~/login.aspx";
        public static string UserLogoutURL = "~/Admin/AdminLogout.aspx"; 
        public void ValidateAdminLogin(String Name, String Password, ref int admin_id, ref String Email, ref int Level_Id)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sqlpara = new[]
            {
               Objdal.MakeInParams("@Name", SqlDbType.NVarChar,0,Name),
               Objdal.MakeInParams("@Password", SqlDbType.NVarChar,0,Password),
               Objdal.MakeOutParams("@admin_id", SqlDbType.Int,0),
               Objdal.MakeOutParams("@Email", SqlDbType.NVarChar,100),
               Objdal.MakeOutParams("@Level_Id",SqlDbType.Int,0)
            };

            Objdal.RunProc("ValidateAdminLogin", sqlpara);
            if (!DBNull.Value.Equals(sqlpara[2].Value) && !DBNull.Value.Equals(sqlpara[4].Value))
            {
                admin_id = Convert.ToInt32(sqlpara[2].Value);
                Email = Convert.ToString(sqlpara[3].Value);
                Level_Id = Convert.ToInt32(sqlpara[4].Value);
            }            
        }
        public static DataSet adlogin(string Name, string Password, int admin_id, string Email,int Level_Id)
        {
            DataTable tbl_admin = new DataTable();
            DataSet ad_Login = new DataSet();
            DataRow dr;

            tbl_admin.TableName = "tbl_user";
            tbl_admin.Columns.Add("Name");
            tbl_admin.Columns.Add("Password");
            tbl_admin.Columns.Add("admin_id");
            tbl_admin.Columns.Add("Email");
            tbl_admin.Columns.Add("Level_Id");

            dr = tbl_admin.Rows.Add();
            dr["Name"] = Name;
            dr["Password"] = Password;
            dr["admin_id"] = admin_id;
            dr["Email"] = Email;
            dr["Level_Id"] = Level_Id;

            ad_Login.Tables.Add(tbl_admin);
            return ad_Login;

        }
    }
}