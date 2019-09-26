using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibrary;
using System.Data;
using System.Data.SqlClient;

namespace EssentialWeb.App_Code
{
    public class Item
    {
        DAL objDal = new DAL();
        public DataSet GetItem()
        {
            DataSet ds = new DataSet();
            objDal.RunProc("Sp_GetItem", ref ds);
            return ds;
        }

        public DataSet SaveItem(int Flag, int Item_Id, string Item_Name, string ModelNo, string Color, string Size, string Features, int Brand_Id,
         int Category_Id, int Group_Id,int Scheme_Id,float MRP,DateTime isApplicableFrom,float DP,float MSP, float BestPrice,string Discounts, bool isActive, int CreatedBy, DateTime CreatedDate, int Alteredby, DateTime AlteredDate)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sqlpara = new[]
          {
              objDal.MakeInParams("@Flag",SqlDbType.Int,0,Flag),
               objDal.MakeInParams("@Item_Id",SqlDbType.Int,0,Item_Id),
               objDal.MakeInParams("@Item_Name", SqlDbType.NVarChar,0,Item_Name),
               objDal.MakeInParams("@ModelNo", SqlDbType.NVarChar,0,ModelNo),
               objDal.MakeInParams("@Color", SqlDbType.NVarChar,0,Color),
               objDal.MakeInParams("@Size", SqlDbType.NVarChar,0,Size),
               objDal.MakeInParams("@Features", SqlDbType.NVarChar,0,Features),
               objDal.MakeInParams("@Brand_Id", SqlDbType.Int,0,Brand_Id),
               objDal.MakeInParams("@Category_Id", SqlDbType.Int,0,Category_Id),
               objDal.MakeInParams("@Group_Id", SqlDbType.Int,0,Group_Id),
               objDal.MakeInParams("@Scheme_Id", SqlDbType.Int,0,Scheme_Id),
               objDal.MakeInParams("@MRP",SqlDbType.Float,0,MRP),
               objDal.MakeInParams("@isApplicableFrom",SqlDbType.DateTime,0,isApplicableFrom),
               objDal.MakeInParams("@DP",SqlDbType.Float,0,DP),
               objDal.MakeInParams("@MSP",SqlDbType.Float,0,MSP),
               objDal.MakeInParams("@BestPrice",SqlDbType.Float,0,BestPrice),
               objDal.MakeInParams("@Discounts",SqlDbType.NVarChar,0,Discounts),
               //objDal.MakeInParams("@Store_Id", SqlDbType.Int,0,Store_Id),
               objDal.MakeInParams("@isActive",SqlDbType.Bit,0,isActive),
               objDal.MakeInParams("@CreatedBy",SqlDbType.Int,0,CreatedBy),
               objDal.MakeInParams("@CreatedDate",SqlDbType.DateTime,0,CreatedDate),
               objDal.MakeInParams("@Alteredby",SqlDbType.Int,0,Alteredby),
               objDal.MakeInParams("@AlteredDate",SqlDbType.DateTime,0,AlteredDate)
          };
            objDal.RunProc("sp_saveItem", sqlpara, ref ds);
            return ds;
        }

        public DataSet GetItemView(int Item_Id)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sqlpara = new[] { 
           objDal.MakeInParams("@Item_Id",SqlDbType.Int,0,Item_Id)

         };
    
            objDal.RunProc("Sp_GetItem", sqlpara, ref ds);

            return ds;

        }
    }
}