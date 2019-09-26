using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibrary;
using System.Data;
using System.Data.SqlClient;

namespace EssentialWeb.App_Code
{
    public class Adduseradmin
    {
        DAL objDal = new DAL();
        public DataSet GetAddUserAdmin()
        {
            DataSet ds = new DataSet();
            objDal.RunProc("Sp_getAddUserAdmin", ref ds);
            return ds;
        }

        public DataSet SaveAddUserAdmin(int Flag, int admin_id, string Name, string Password, string Email, string Mobile, int Level_Id,int Store_ID, bool isActive, int CreatedBy, DateTime CreatedDate, int Alteredby, DateTime AlteredDate)
        {

            DataSet ds = new DataSet();
            SqlParameter[] sqlpara = new[]
            {
            objDal.MakeInParams("@Flag",SqlDbType.Int,0,Flag),
            objDal.MakeInParams("@admin_id",SqlDbType.Int,0,admin_id),
            objDal.MakeInParams("@Name",SqlDbType.NVarChar,0,Name),
            objDal.MakeInParams("@Password", SqlDbType.NVarChar,0,Password),
            //objDal.MakeInParams("@isReserved",SqlDbType.Int,0,isReserved),            
            objDal.MakeInParams("@Email",SqlDbType.NVarChar,0,Email),
            objDal.MakeInParams("@Mobile",SqlDbType.NVarChar,0,Mobile),
            objDal.MakeInParams("@Level_Id",SqlDbType.Int,0,Level_Id),
            objDal.MakeInParams("@Store_ID",SqlDbType.Int,0,Store_ID),
            objDal.MakeInParams("@isActive",SqlDbType.Bit,0,isActive),
            objDal.MakeInParams("@CreatedBy",SqlDbType.Int,0,CreatedBy),
            objDal.MakeInParams("@CreatedDate",SqlDbType.DateTime,0,CreatedDate),
            objDal.MakeInParams("@Alteredby",SqlDbType.Int,0,Alteredby),
            objDal.MakeInParams("@AlteredDate",SqlDbType.DateTime,0,AlteredDate)};

            objDal.RunProc("sp_saveAddUserAdmin", sqlpara, ref ds);

            return ds;
        }

         public DataSet GetAddUserAdminView(int admin_id, string Name)
      {
          DataSet ds = new DataSet();
          SqlParameter[] sqlpara = new[] { 
          objDal.MakeInParams("@admin_id",SqlDbType.Int,0,admin_id),
          objDal.MakeInParams("@Name",SqlDbType.NVarChar,0,Name)};

          objDal.RunProc("Sp_getAddUserAdmin", sqlpara, ref ds);

          return ds;
      }
    }
}