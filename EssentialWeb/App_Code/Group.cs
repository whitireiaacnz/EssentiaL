using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibrary;
using System.Data;
using System.Data.SqlClient;

namespace EssentialWeb.App_Code
{
    public class Group
    {
        DAL objDal = new DAL();
        public DataSet GetGroup()
        {
            DataSet ds = new DataSet();
            objDal.RunProc("Sp_GetGroup", ref ds);
            return ds;
        }
        public DataSet SaveGroup(int Flag, int Group_Id, string Group_Name, 
         bool isActive, int CreatedBy, DateTime CreatedDate, int Alteredby, DateTime AlteredDate)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sqlpara = new[]
            {
            objDal.MakeInParams("@Flag",SqlDbType.Int,0,Flag),
            objDal.MakeInParams("@Group_id",SqlDbType.Int,0,Group_Id),
            objDal.MakeInParams("@Group_Name",SqlDbType.NVarChar,0,Group_Name),
            //objDal.MakeInParams("@isReserved",SqlDbType.Int,0,isReserved),            
            objDal.MakeInParams("@isActive",SqlDbType.Bit,0,isActive),
            objDal.MakeInParams("@CreatedBy",SqlDbType.Int,0,CreatedBy),
            objDal.MakeInParams("@CreatedDate",SqlDbType.DateTime,0,CreatedDate),
            objDal.MakeInParams("@Alteredby",SqlDbType.Int,0,Alteredby),
            objDal.MakeInParams("@AlteredDate",SqlDbType.DateTime,0,AlteredDate)};

            objDal.RunProc("sp_saveGroup", sqlpara, ref ds);

            return ds;
        }

        public DataSet GetGroupView(int Group_Id, string Group_Name)
        {
            DataSet ds = new DataSet();
            SqlParameter[] sqlpara = new[] { 
          objDal.MakeInParams("@Group_Id",SqlDbType.Int,0,Group_Id),
             objDal.MakeInParams("@Group_Name",SqlDbType.NVarChar,0,Group_Name)};

            objDal.RunProc("Sp_GetGroup", sqlpara, ref ds);

            return ds;
        }

    }
}