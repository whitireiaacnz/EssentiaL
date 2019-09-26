using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibrary;
using System.Data;
using System.Data.SqlClient;


namespace EssentialWeb.App_Code
{      
    public class Brand
    {
      DAL objDal = new DAL();
      public DataSet GetBrand()
      {
          DataSet ds = new DataSet();        
          objDal.RunProc("Sp_GetBrand", ref ds);
          return ds;
      }
      public DataSet SaveBrand(int Flag, int Brand_Id, string Brand_Name,
       bool isActive, int CreatedBy, DateTime CreatedDate, int Alteredby, DateTime AlteredDate)
      {
          DataSet ds = new DataSet();
          SqlParameter[] sqlpara = new[]
            {
            objDal.MakeInParams("@Flag",SqlDbType.Int,0,Flag),
            objDal.MakeInParams("@Brand_Id",SqlDbType.Int,0,Brand_Id),
            objDal.MakeInParams("@Brand_Name",SqlDbType.NVarChar,0,Brand_Name),
            //objDal.MakeInParams("@isReserved",SqlDbType.Int,0,isReserved),            
            objDal.MakeInParams("@isActive",SqlDbType.Bit,0,isActive),
            objDal.MakeInParams("@CreatedBy",SqlDbType.Int,0,CreatedBy),
            objDal.MakeInParams("@CreatedDate",SqlDbType.DateTime,0,CreatedDate),
            objDal.MakeInParams("@Alteredby",SqlDbType.Int,0,Alteredby),
            objDal.MakeInParams("@AlteredDate",SqlDbType.DateTime,0,AlteredDate)};

          objDal.RunProc("sp_saveBrand", sqlpara, ref ds);

          return ds;
            }


      public DataSet GetBrandView(int Brand_Id ,string Brand_Name)
      {
          DataSet ds = new DataSet();
          SqlParameter[] sqlpara = new[] 
          { 
          objDal.MakeInParams("@Brand_Id",SqlDbType.Int,0,Brand_Id),
          objDal.MakeInParams("@Brand_Name",SqlDbType.NVarChar,0,Brand_Name)
          // objDal.MakeInParams("@admin_id",SqlDbType.Int,0,admin_id)
          };

          objDal.RunProc("Sp_GetBrand", sqlpara, ref ds);

          return ds;
      }
    
    }
}