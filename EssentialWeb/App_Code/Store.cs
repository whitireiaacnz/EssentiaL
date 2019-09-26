using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibrary;
using System.Data;
using System.Data.SqlClient;

namespace EssentialWeb.App_Code
{
    public class Store
    {
        DAL objDal = new DAL();
        public DataSet GetStore()
        {
            DataSet ds = new DataSet();
            objDal.RunProc("Sp_GetStore", ref ds);
            return ds;
        }
        public DataSet SaveStore(int Flag, int Store_Id, string Store_Name, string Add1, string Add2, string StateName, string CityName, int PinCode,
       bool isActive, int CreatedBy, DateTime CreatedDate, int Alteredby, DateTime AlteredDate)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sqlpara = new[]
            {
            objDal.MakeInParams("@Flag",SqlDbType.Int,0,Flag),
            objDal.MakeInParams("@Store_id",SqlDbType.Int,0,Store_Id),
            objDal.MakeInParams("@Store_Name",SqlDbType.NVarChar,0,Store_Name),
            //objDal.MakeInParams("@isReserved",SqlDbType.Int,0,isReserved),  
             objDal.MakeInParams("@Add1",SqlDbType.NVarChar,0,Add1),
            objDal.MakeInParams("@Add2", SqlDbType.NVarChar,0,Add2),
            objDal.MakeInParams("StateName", SqlDbType.NVarChar,0,StateName),
            objDal.MakeInParams("CityName",SqlDbType.NVarChar,0,CityName),
            objDal.MakeInParams("PinCode",SqlDbType.NVarChar,0,PinCode),
            objDal.MakeInParams("@isActive",SqlDbType.Bit,0,isActive),
            objDal.MakeInParams("@CreatedBy",SqlDbType.Int,0,CreatedBy),
            objDal.MakeInParams("@CreatedDate",SqlDbType.DateTime,0,CreatedDate),
            objDal.MakeInParams("@Alteredby",SqlDbType.Int,0,Alteredby),
            objDal.MakeInParams("@AlteredDate",SqlDbType.DateTime,0,AlteredDate)};

            objDal.RunProc("sp_saveStore", sqlpara, ref ds);

            return ds;
        }
        public DataSet GetStoreView(int Store_Id, string Store_Name)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sqlpara = new[] { 
          objDal.MakeInParams("@Store_Id",SqlDbType.Int,0,Store_Id),
          // objDal.MakeInParams("@admin_id",SqlDbType.Int,0,admin_id)
               objDal.MakeInParams("@Store_Name",SqlDbType.NVarChar,0,Store_Name)
          };

            objDal.RunProc("Sp_GetStore", sqlpara, ref ds);

            return ds;
        }

    }
}