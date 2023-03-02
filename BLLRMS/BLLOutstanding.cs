using System;
using System.Data;
using System.Data.SqlClient;
using DALMPRS;

namespace BLLMPRS
{
    public class DALSecurity
    {
        private DALCommon objDALCommon = new DALCommon();

        public DataSet CheckUserLoginIdExist(string UserLoginId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];

            Parameters[0] = new SqlParameter("@UserLoginId", UserLoginId);
            return objDALCommon.ExecuteProcedure_select("sgetUserLoginIdExist", Parameters);
        }

        public int AddSecurityDetailTemp(string UserLoginId, string Password, string Type, bool ADflg, string UserCategoryName, bool Active, bool Deleted, string strUserName)
        {
            SqlParameter[] Parameters = new SqlParameter[8];

            Parameters[0] = new SqlParameter("@UserLoginId", UserLoginId);
            Parameters[1] = new SqlParameter("@Password", Password);
            Parameters[2] = new SqlParameter("@Type", Type);
            Parameters[3] = new SqlParameter("@ADflg", ADflg);
            Parameters[4] = new SqlParameter("@UserCategoryName", UserCategoryName);
            Parameters[5] = new SqlParameter("@Active", Active);
            Parameters[6] = new SqlParameter("@Deleted", Deleted);
            Parameters[7] = new SqlParameter("@CreatedBy", strUserName);
            return objDALCommon.ExecuteProcedure("sinUserSecurity_Temp", CommandType.StoredProcedure, Parameters);
        }

        public DataSet GetSecurityDetailByUserLoginId(string UserLoginId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];

            Parameters[0] = new SqlParameter("@UserLoginId", UserLoginId);
            return objDALCommon.ExecuteProcedure_select("sgetSecurityDetailByUserLoginId", Parameters);
        }

        public int UpdateSysUser(int Id, string Name, string Address, string ContactNo, string Email, bool ADUser, int DesignationId, int DivisionId, int UserCategoryId, string UserLoginId, bool Active, string strUserName, string strEncUserName, string strDecUserName, string strDecPassword, string strDecUserCategory)
        {
            SqlParameter[] Parameters = new SqlParameter[15];

            Parameters[0] = new SqlParameter("@Id", Id);
            Parameters[1] = new SqlParameter("@Name", Name);
            Parameters[2] = new SqlParameter("@Address", Address);
            Parameters[3] = new SqlParameter("@ContactNo", ContactNo);
            Parameters[4] = new SqlParameter("@Email", Email);
            Parameters[5] = new SqlParameter("@ADUser", ADUser);
            Parameters[6] = new SqlParameter("@DesignationId", DesignationId);
            Parameters[7] = new SqlParameter("@DivisionId", DivisionId);
            Parameters[8] = new SqlParameter("@UserCategoryId", UserCategoryId);
            Parameters[9] = new SqlParameter("@UserLoginId", UserLoginId);
            Parameters[10] = new SqlParameter("@Active", Active);
            Parameters[11] = new SqlParameter("@LastModifiedBy", strUserName);

            Parameters[12] = new SqlParameter("@userNameDecrypt", strEncUserName);
            Parameters[13] = new SqlParameter("@userPasswordDecrypt", strDecPassword);
            Parameters[14] = new SqlParameter("@userCategoryName", strDecUserCategory);

            return objDALCommon.ExecuteProcedure("supSysUser", CommandType.StoredProcedure, Parameters);
        }

        public DataSet GetUserbyUserLoginId(string UserLoginId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];

            Parameters[0] = new SqlParameter("@UserLoginId", UserLoginId);
            return objDALCommon.ExecuteProcedure_select("sgetUserbyUserLoginId", Parameters);
        }

        public DataSet CheckUserLoginIdPwd(string UserLoginId, string Password)
        {
            SqlParameter[] Parameters = new SqlParameter[2];

            Parameters[0] = new SqlParameter("@UserLoginId", UserLoginId);
            Parameters[1] = new SqlParameter("@Password", Password);
            return objDALCommon.ExecuteProcedure_select("sgetUserLoginIdPwd", Parameters);
        }
       

        public DataSet GetRetailerIDbyUserLoginId(string UserLoginId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];

            Parameters[0] = new SqlParameter("@UserLoginId", UserLoginId);
            return objDALCommon.ExecuteProcedure_select("sgetRetailerIdbyUserLoginId", Parameters);
        }
        public DataSet GetNamebyUserLoginId(string UserLoginId,int UerCategoryId)
        {
            SqlParameter[] Parameters = new SqlParameter[2];

            Parameters[0] = new SqlParameter("@UserLoginId", UserLoginId);
            Parameters[1] = new SqlParameter("@UserCategoryId", UerCategoryId);
            return objDALCommon.ExecuteProcedure_select("sgetNamebyUserLoginId", Parameters);
        }

        public DataSet GetCompanyId(string userLoginId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];

            Parameters[0] = new SqlParameter("@UserLoginId", userLoginId);           
            return objDALCommon.ExecuteProcedure_select("sreGetCompanyDetails", Parameters);
        }

        public DataSet GetUserCategory(string strEncUserLoginId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];

            Parameters[0] = new SqlParameter("@UserLoginId", strEncUserLoginId);

            return objDALCommon.ExecuteProcedure_select("sgetUserCategory", Parameters);
        }

        public DataSet CheckUserHaveDivision(string UserLoginId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];

            Parameters[0] = new SqlParameter("@UserLoginId", UserLoginId);
            return objDALCommon.ExecuteProcedure_select("sgetUserHaveDivision", Parameters);
        }

        public int AddUserLoginHistory(string UserLoginId, string LoginDateTime, string IPAddress, string GPSLat, string GPSLong)
        {
            SqlParameter[] Parameters = new SqlParameter[5];

            Parameters[0] = new SqlParameter("@UserLoginId", UserLoginId);
            Parameters[1] = new SqlParameter("@LoginDateTime", LoginDateTime);
            Parameters[2] = new SqlParameter("@IPAddress", IPAddress);
            Parameters[3] = new SqlParameter("@GPSLat", GPSLat);
            Parameters[4] = new SqlParameter("@GPSLong", GPSLong);

            return objDALCommon.ExecuteProcedure("sinUserLoginHistory", CommandType.StoredProcedure, Parameters);
        }

        public DataSet GetMenuByUserCategoryAccess(int UserCategoryId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];

            Parameters[0] = new SqlParameter("@UserCategoryId", UserCategoryId);

            return objDALCommon.ExecuteProcedure_select("sreGetMenuByUserCategoryAccess", Parameters);
        }

    }
}
