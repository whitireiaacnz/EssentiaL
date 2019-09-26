using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibrary;
using System.Data;
using System.Data.SqlClient;

namespace EssentialWeb.App_Code
{
       public class Level
    {
           DAL objDal = new DAL();
            public DataSet GetGroup()
           {
               DataSet ds = new DataSet();
               objDal.RunProc("Sp_GetGroup", ref ds);
               return ds;
           }

            public DataSet GetLevelView(int Level_ID)
            {
                DataSet ds = new DataSet();
                SqlParameter[] sqlpara = new[] { 
          objDal.MakeInParams("@Level_ID",SqlDbType.Int,0,Level_ID)};

                objDal.RunProc("Sp_getLevel", sqlpara, ref ds);

                return ds;
            }
    }
}