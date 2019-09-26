using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibrary;
using System.Data;
using System.Data.SqlClient;

namespace EssentialWeb.App_Code
{
    public class PriceList
    {
        DAL objDal = new DAL();
        public DataSet GetPriceList()
        {
            DataSet ds = new DataSet();
            objDal.RunProc("Sp_GetPriceList", ref ds);
            return ds;
        }

        public DataSet SavePriceList(int Flag, int PriceList_Id, int Item_Id, int Scheme_Id, float MRP, DateTime isApplicableFrom, float DP, float MSP, float BestPrice, float Discounts, int CreatedBy, DateTime CreatedDate, int Alteredby, DateTime AlteredDate, bool isActive)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sqlpara = new[]
            {
                objDal.MakeInParams("@Flag",SqlDbType.Int,0,Flag),
                objDal.MakeInParams("@PriceList_Id",SqlDbType.Int,0,PriceList_Id),
               objDal.MakeInParams("@Item_Id",SqlDbType.Int,0,Item_Id),
               objDal.MakeInParams("@Scheme_Id",SqlDbType.Int,0,Scheme_Id),
               objDal.MakeInParams("@MRP", SqlDbType.Float,0,MRP),
               objDal.MakeInParams("@isApplicableFrom", SqlDbType.DateTime,0,isApplicableFrom),
               objDal.MakeInParams("@DP", SqlDbType.Float,0,DP),
               objDal.MakeInParams("@MSP", SqlDbType.Float,0,MSP),
               objDal.MakeInParams("@BestPrice", SqlDbType.Float,0,BestPrice),
               objDal.MakeInParams("@Discounts", SqlDbType.Float,0,Discounts),
               objDal.MakeInParams("@isActive",SqlDbType.Bit,0,isActive),
               objDal.MakeInParams("@CreatedBy",SqlDbType.Int,0,CreatedBy),
               objDal.MakeInParams("@CreatedDate",SqlDbType.DateTime,0,CreatedDate),
               objDal.MakeInParams("@Alteredby",SqlDbType.Int,0,Alteredby),
               objDal.MakeInParams("@AlteredDate",SqlDbType.DateTime,0,AlteredDate)

            };
            objDal.RunProc("sp_savePriceList", sqlpara, ref ds);
            return ds;
        }

        public DataSet GetPriceListView(int PriceList_Id)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sqlpara = new[] { 
           objDal.MakeInParams("@PriceList_Id",SqlDbType.Int,0,PriceList_Id)

         };

            objDal.RunProc("Sp_GetPriceList", sqlpara, ref ds);

            return ds;

        }
    }
}