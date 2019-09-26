using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace EssentialWeb.App_Code
{
    public class SiteCommon
    {
        // Default User Login
        public static string DefaultURL = "~/Default.aspx";
        public static string LoginURL = "";

        // Admin Login
        public static string AdminDefaultURL = "~/admindefault.aspx";
        public static string AdminLoginURL = "~/AdminLogin.aspx";

        public static DataSet adminlogin(int admin_id, string Name, string Password, string Email)
        {
            DataTable tbl_admin = new DataTable();
            DataSet ds_adminLogin = new DataSet();
            DataRow dr;

            tbl_admin.TableName = "admin";
            tbl_admin.Columns.Add("admin_id");
            tbl_admin.Columns.Add("Name");
            tbl_admin.Columns.Add("Password");
            tbl_admin.Columns.Add("Email");

            dr = tbl_admin.Rows.Add();
            dr["admin_id"] = admin_id;
            dr["Name"] = Name;
            dr["Password"] = Password;
            dr["Email"] = Email;

            ds_adminLogin.Tables.Add(tbl_admin);

            return ds_adminLogin;
        }

    }
}