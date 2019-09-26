using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibrary;
using System.Data;
using System.Data.SqlClient;


namespace EssentialWeb.App_Code
{
    public class Scheme
    {
        DAL objDal = new DAL();
        public DataSet GetScheme()
        {
            DataSet ds = new DataSet();
            objDal.RunProc("Sp_GetScheme", ref ds);
            return ds;

        }

       public DataSet SaveScheme(int Flag, int Scheme_Id, string Scheme_Name, float msp, float bp,
       bool isActive, int CreatedBy, DateTime CreatedDate, int Alteredby, DateTime AlteredDate)
        {
            DataSet ds = new DataSet();
          SqlParameter[] sqlpara = new[]
          {
              objDal.MakeInParams("@Flag",SqlDbType.Int,0,Flag),
            objDal.MakeInParams("@Scheme_id",SqlDbType.Int,0,Scheme_Id),
            objDal.MakeInParams("@msp",SqlDbType.Float,0,msp),
            objDal.MakeInParams("@bp",SqlDbType.Float,0,bp),
            objDal.MakeInParams("@Scheme_Name",SqlDbType.NVarChar,0,Scheme_Name),
            //objDal.MakeInParams("@isReserved",SqlDbType.Int,0,isReserved),            
            objDal.MakeInParams("@isActive",SqlDbType.Bit,0,isActive),
            objDal.MakeInParams("@CreatedBy",SqlDbType.Int,0,CreatedBy),
            objDal.MakeInParams("@CreatedDate",SqlDbType.DateTime,0,CreatedDate),
            objDal.MakeInParams("@Alteredby",SqlDbType.Int,0,Alteredby),
            objDal.MakeInParams("@AlteredDate",SqlDbType.DateTime,0,AlteredDate)
          };

          objDal.RunProc("sp_saveScheme", sqlpara, ref ds);

          return ds;
      }
        

         public DataSet GetSchemeView(int Scheme_Id, string Scheme_Name)
      {
          DataSet ds = new DataSet();
          SqlParameter[] sqlpara = new[] { 
          objDal.MakeInParams("@Scheme_Id",SqlDbType.Int,0,Scheme_Id),
          objDal.MakeInParams("@Scheme_Name",SqlDbType.NVarChar,0,Scheme_Name)
          // objDal.MakeInParams("@admin_id",SqlDbType.Int,0,admin_id)
          };

          objDal.RunProc("Sp_GetScheme", sqlpara, ref ds);

          return ds;
      }

   }
}

   