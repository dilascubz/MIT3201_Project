using System.Data;
using System.Data.SqlClient;

namespace DALCSCL
{
    public class DALUserCategory
    {
        private DALCommon objDALCommon = new DALCommon();

        public int DeleteCategory(string strCategoryName)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@CategoryName", strCategoryName);

            return objDALCommon.ExecuteProcedure("sdeCategory", CommandType.StoredProcedure, Parameters);
        }

        public DataSet GetUserCategoryAccessLevelByCategoryName(string strUserCategoryName)
        {
            SqlParameter[] Parameters = new SqlParameter[1];

            Parameters[0] = new SqlParameter("@strUserCategoryName", strUserCategoryName);
            return objDALCommon.ExecuteProcedure_select("sGetUserCategoryAccessLevelByCategoryName", Parameters);
        }

        public DataSet GetUserCategoryAccessLevelNotSelectedByCategoryName(string strUserCategoryName)
        {
            SqlParameter[] Parameters = new SqlParameter[1];

            Parameters[0] = new SqlParameter("@strUserCategoryName", strUserCategoryName);
            return objDALCommon.ExecuteProcedure_select("sGetUserCategoryAccessLevelNotSelectedByCategoryName", Parameters);
        }

        public DataSet SelectCategoryAccess(string CategoryName)
        {
            SqlParameter[] Parameters = new SqlParameter[1];

            Parameters[0] = new SqlParameter("@CategoryName", CategoryName);
            return objDALCommon.ExecuteProcedure_select("sGetCategoryAccess", Parameters);
        }

        public int DeleteCategoryAccess(string CategoryName)
        {
            SqlParameter[] Parameters = new SqlParameter[1];

            Parameters[0] = new SqlParameter("@CategoryName", CategoryName);
            return objDALCommon.ExecuteProcedure("sdeUserCategoryAccess", CommandType.StoredProcedure, Parameters);
        }

        public int DeleteCategoryAccessLevels(string CategoryName)
        {
            SqlParameter[] Parameters = new SqlParameter[1];

            Parameters[0] = new SqlParameter("@CategoryName", CategoryName);
            return objDALCommon.ExecuteProcedure("sdeUserCategoryAccessLevel", CommandType.StoredProcedure, Parameters);
        }

        public int AddCategoryAccessLevels(string CategoryName, string AccessLevel, bool AddCommand, bool EditCommand, bool DeleteCommand, string UserName)
        {
            SqlParameter[] Parameters = new SqlParameter[6];

            Parameters[0] = new SqlParameter("@CategoryName", CategoryName);
            Parameters[1] = new SqlParameter("@AccessLevel", AccessLevel);
            Parameters[2] = new SqlParameter("@AddCommand", AddCommand);
            Parameters[3] = new SqlParameter("@EditCommand", EditCommand);
            Parameters[4] = new SqlParameter("@DeleteCommand", DeleteCommand);
            Parameters[5] = new SqlParameter("CreatedBy", UserName);

            return objDALCommon.ExecuteProcedure("sinUserCategoryAccessLevel", CommandType.StoredProcedure, Parameters);
        }

        public int AddPageGroupAccessLevels(string CategoryName, string AccessLevel, string UserName)
        {
            SqlParameter[] Parameters = new SqlParameter[3];

            Parameters[0] = new SqlParameter("CategoryName", CategoryName);
            Parameters[1] = new SqlParameter("AccessLevel", AccessLevel);
            Parameters[2] = new SqlParameter("CreatedBy", UserName);


            return objDALCommon.ExecuteProcedure("sinPageGroupAccessLevel", CommandType.StoredProcedure, Parameters);
        }

        public DataSet GetAccessLevelsByCategoryName(string strUserCategoryName)
        {
            SqlParameter[] Parameters = new SqlParameter[1];

            Parameters[0] = new SqlParameter("@strUserCategoryName", strUserCategoryName);
            return objDALCommon.ExecuteProcedure_select("sGetAccessLevelsByCategoryName", Parameters);
        }


        public string GetQuery(string Query, string Column)
        {
            return objDALCommon.GetColumnVal(Query, Column);

        }

        public bool ExecuteQuery(string Query)
        {
            return objDALCommon.ExecuteQuery(Query);

        }


    }
}
