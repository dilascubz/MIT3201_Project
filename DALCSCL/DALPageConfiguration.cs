using System.Data;
using System.Data.SqlClient;

namespace DALCSCL
{
    public class DALPageConfiguration
    {
        DALCommon objDALCommon = new DALCommon();

        public DataSet GetAllUserCategory()
        {
            return objDALCommon.ExecuteProcedure_select("sgetAllUserCategory");
        }

        public DataSet GetUserCategoryDecryptString(int UserCategoryId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];

            Parameters[0] = new SqlParameter("@UserCategoryId", UserCategoryId);
            return objDALCommon.ExecuteProcedure_select("sgetUserCategoryDecryptString", Parameters);
        }

        public int AddUserCategory(string CategoryName, string UserName)
        {
            SqlParameter[] Parameters = new SqlParameter[2];

            Parameters[0] = new SqlParameter("CategoryName", CategoryName);
            Parameters[1] = new SqlParameter("CreatedBy", UserName);

            return objDALCommon.ExecuteProcedure("sinCategory", CommandType.StoredProcedure, Parameters);
        }
    }
}
