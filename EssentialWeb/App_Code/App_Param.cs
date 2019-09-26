using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace EssentialWeb.App_Code
{
    public struct App_Param
    {
        internal int _admin_id;         //_OALogin_Code
        internal string _Name;      //_OALogin_ID
        internal string _Email;    //_User_Name  
        internal int _Level_Id;
        public object admin_id
        {
            get
            {
                return _admin_id;
            }
            set
            {

            }
        }
        public object Name
        {
            get
            {
                return _Name;
            }
            set
            {

            }
        }
        public object Email
        {
            get
            {
                return _Email;
            }
            set
            {

            }
        }

        public object Level_Id
        {

            get
            {
                return _Level_Id;
            }
            set
            {

            }
        }

        //public class AdminAppParam
        //{
        public static void AdminInitUSer(int admin_id, string Name, string Email, int CalledFrom, int Level_Id)
        {
            App_Param ObjAdmin_Param = new App_Param();

            ObjAdmin_Param._admin_id = admin_id;
            ObjAdmin_Param._Name = Name;
            ObjAdmin_Param._Email = Email;
            ObjAdmin_Param.Level_Id = Level_Id;

            ObjAdmin_Param._admin_id = admin_id;
            ObjAdmin_Param._Name = Name;
            ObjAdmin_Param._Email = Email;
            ObjAdmin_Param._Level_Id = Level_Id;
            if (CalledFrom == 1)
                System.Web.HttpContext.Current.Session["Admin_Param"] = ObjAdmin_Param;
            else if (CalledFrom == 2)
                System.Web.HttpContext.Current.Session["User_Param"] = ObjAdmin_Param;
            else if (CalledFrom == 3)
                System.Web.HttpContext.Current.Session["Vendor_Param"] = ObjAdmin_Param;
        }
        //}
    }
}