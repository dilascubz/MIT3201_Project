using System.Data;
using System.Data.SqlClient;

namespace DALCSCL
{
    public class DALChangePassword
    {
        private DALCommon objDALCommon = new DALCommon();

      

        public int ChangePassword(string UserName, string Password)
        {
            SqlParameter[] Parameters = new SqlParameter[2];

            Parameters[0] = new SqlParameter("@UserName", UserName);
            Parameters[1] = new SqlParameter("@Password", Password);

            return objDALCommon.ExecuteProcedure("SupChangePassword", CommandType.StoredProcedure, Parameters);
        }
    }
}
