using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ClassLibrary;

namespace EssentialWeb.App_Code
{
    public class SiteCommon
    {
        private DAL objDal = new DAL();

        // Default User Login
        public static string DefaultURL = "~/Default.aspx";
        //public static string LoginURL = "~/default.aspx";

        // Admin Login
        public static string AdminDefaultURL = "~/admin/admindefault.aspx";
        public static string AdminLoginURL = "~/admin/AdminLogin.aspx";
        public static string UserDefaultURL = "~/default.aspx";
        public static string UserLoginURL = "~/login.aspx";

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

        public static DataSet userlogin(int admin_id, string Name, string Password, string Email, int Level_Id)
        {
            DataTable tbl_admin = new DataTable();
            DataSet ds_adminLogin = new DataSet();
            DataRow dr;

            tbl_admin.TableName = "admin";
            tbl_admin.Columns.Add("admin_id");
            tbl_admin.Columns.Add("Name");
            tbl_admin.Columns.Add("Password");
            tbl_admin.Columns.Add("Email");
            tbl_admin.Columns.Add("Level_Id");

            dr = tbl_admin.Rows.Add();
            dr["admin_id"] = admin_id;
            dr["Name"] = Name;
            dr["Password"] = Password;
            dr["Email"] = Email;
            dr["Level_Id"] = Level_Id;
            ds_adminLogin.Tables.Add(tbl_admin);

            return ds_adminLogin;
        }


        public void DeleteMasters(string TableName, string FldName, int Code, bool @CheckReservedRec)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sqlpara = new[] { objDal.MakeInParams("@TableName", System.Data.SqlDbType.NVarChar, 0, TableName), 
                                        objDal.MakeInParams("@FieldName", System.Data.SqlDbType.NVarChar, 0, FldName), 
                                        objDal.MakeInParams("@Code", System.Data.SqlDbType.Int, 0, Code), 
                                        objDal.MakeInParams("@CheckReservedDesc", System.Data.SqlDbType.Bit, 0, CheckReservedRec)};
            objDal.RunProc("DeleteMasters", sqlpara);
        }

      
    }
}