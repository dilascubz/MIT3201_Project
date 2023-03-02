using System.Data;
using System.Data.SqlClient;

namespace DALCSCL
{
    public class DALForgetPassword
    {
        private DALCommon objDALCommon = new DALCommon();

        public DataSet CheckUser(string UserName)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@UserName", UserName);
            return objDALCommon.ExecuteProcedure_select("SreCheckUser", Parameters);

        }

        public int SendVerificationCode(string UserName, int Code)
        {
            SqlParameter[] Parameters = new SqlParameter[2];

            Parameters[0] = new SqlParameter("@UserName", UserName);
            Parameters[1] = new SqlParameter("@Code", Code);

            return objDALCommon.ExecuteProcedure("SinForgetPassword", CommandType.StoredProcedure, Parameters);
        }
    }
}
