using System;
using System.Data;
using System.Data.SqlClient;

namespace DALCSCL
{
    public class DALSysUsers
    {
        private DALCommon objDALCommon = new DALCommon();

        public DataSet GetActiveDesignations()
        {
            return objDALCommon.ExecuteProcedure_select("sgetActiveDesignations");
        }

        public DataSet GetActiveDivisions()
        {
            return objDALCommon.ExecuteProcedure_select("sgetActiveDivisions");
        }

        public DataSet GetSysUsers()
        {
            return objDALCommon.ExecuteProcedure_select("sgetSysUsers");
        }

        public int AddSysUser(string Name, string Address, string ContactNo, string Email, bool ADUser, int DesignationId, int DivisionId, int UserCategoryId, string UserLoginId, bool Active, string strUserName)
        {
            SqlParameter[] Parameters = new SqlParameter[11];

            Parameters[0] = new SqlParameter("@Name", Name);
            Parameters[1] = new SqlParameter("@Address", Address);
            Parameters[2] = new SqlParameter("@ContactNo", ContactNo);
            Parameters[3] = new SqlParameter("@Email", Email);
            Parameters[4] = new SqlParameter("@ADUser", ADUser);
            Parameters[5] = new SqlParameter("@DesignationId", DesignationId);
            Parameters[6] = new SqlParameter("@DivisionId", DivisionId);
            Parameters[7] = new SqlParameter("@UserCategoryId", UserCategoryId);
            Parameters[8] = new SqlParameter("@UserLoginId", UserLoginId);
            Parameters[9] = new SqlParameter("@Active", Active);
            Parameters[10] = new SqlParameter("@CreatedBy", strUserName);

            return objDALCommon.ExecuteProcedure("sinSysUser", CommandType.StoredProcedure, Parameters);
        }

        public int DeleteSysUser(int Id)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@Id", Id);
            return objDALCommon.ExecuteProcedure("sdeSysUser", CommandType.StoredProcedure, Parameters);
        }

        public string DeleteSysUserSecurity(string UserLoginId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@UserLoginId", UserLoginId);
            return objDALCommon.ExecuteProcedure("sdeSysSecurity", CommandType.StoredProcedure, Parameters).ToString();
        }

        public DataSet GetPreviousUserLoginId()
        {
            try
            {
                return objDALCommon.ReturnDataSet("SELECT UserLoginId FROM SysUserSecurity");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet GetExistingADUserList()
        {
            return objDALCommon.ReturnDataSet("SELECT Name, UserLoginID FROM [dbo].[SystemUser] WHERE ADUser = 1");
        }

        public DataSet GetUserId(string UserLoginId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@UserLoginId", UserLoginId);
            return objDALCommon.ExecuteProcedure_select("SgetUserId", Parameters);
        }

        public int AddUserConfig(int UserId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];

            Parameters[0] = new SqlParameter("@UserId", UserId);

            return objDALCommon.ExecuteProcedure("sinUserConfig", CommandType.StoredProcedure, Parameters);
        }

        public DataSet GetDesignationId(string DesignationName)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@DesignationName", DesignationName);
            return objDALCommon.ExecuteProcedure_select("sreGetDesignationId", Parameters);
        }

        public DataSet GetDivisionId(string DivisionName)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@DivisionName", DivisionName);
            return objDALCommon.ExecuteProcedure_select("sreGetDivisionId", Parameters);
        }

        public DataSet GetUserCategoryId(string UserCategoryName)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@UserCategoryName", UserCategoryName);
            return objDALCommon.ExecuteProcedure_select("sreGetUserCategoryId", Parameters);
        }
    }
}
