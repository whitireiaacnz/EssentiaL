using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibrary;
using System.Data;
using System.Data.SqlClient;

namespace EssentialWeb.App_Code
{
    public class Category
    {
        DAL objDal = new DAL();
        public DataSet GetCategory()
        {
            DataSet ds = new DataSet();
            objDal.RunProc("Sp_GetCategory", ref ds);
            return ds;
        }
        public DataSet SaveCategory(int Flag, int Category_Id, string Category_Name, int Group_Id,
         bool isActive, int CreatedBy, DateTime CreatedDate, int Alteredby, DateTime AlteredDate)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sqlpara = new[]
            {
            objDal.MakeInParams("@Flag",SqlDbType.Int,0,Flag),
            objDal.MakeInParams("@Category_id",SqlDbType.Int,0,Category_Id),
            objDal.MakeInParams("@Category_Name",SqlDbType.NVarChar,0,Category_Name),
            objDal.MakeInParams("@Group_Id", SqlDbType.Int,0,Group_Id),
            //objDal.MakeInParams("@isReserved",SqlDbType.Int,0,isReserved),            
            objDal.MakeInParams("@isActive",SqlDbType.Bit,0,isActive),
            objDal.MakeInParams("@CreatedBy",SqlDbType.Int,0,CreatedBy),
            objDal.MakeInParams("@CreatedDate",SqlDbType.DateTime,0,CreatedDate),
            objDal.MakeInParams("@Alteredby",SqlDbType.Int,0,Alteredby),
            objDal.MakeInParams("@AlteredDate",SqlDbType.DateTime,0,AlteredDate)};

            objDal.RunProc("sp_saveCategory", sqlpara, ref ds);

            return ds;
        }
        public DataSet GetCategoryView(int Category_Id, string Category_Name)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sqlpara = new[] { 
          objDal.MakeInParams("@Category_Id",SqlDbType.Int,0,Category_Id),
            objDal.MakeInParams("@Category_Name",SqlDbType.NVarChar,0,Category_Name)
            };

            objDal.RunProc("Sp_GetCategory", sqlpara, ref ds);

            return ds;
        }
    }
}