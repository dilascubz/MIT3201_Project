using System.Data;
using System.Data.SqlClient;

namespace DALCSCL
{
    public class DALAddProductCategory
    {
        private DALCommon objDALCommon = new DALCommon();

        public DataSet CheckProductCategory(int CompanyId, string Name)
        {
            SqlParameter[] Parameters = new SqlParameter[2];
            Parameters[0] = new SqlParameter("@CompanyID", CompanyId);
            Parameters[1] = new SqlParameter("@Name", Name);
            return objDALCommon.ExecuteProcedure_select("SreCheckProductCategory", Parameters);
        }
        public int AddAdvertisements(int StakeHolderId, string Name, string FromDate, string TOdate, byte[] Image, string UserLogin, bool Active)
        {
            SqlParameter[] Parameters = new SqlParameter[7];
            Parameters[0] = new SqlParameter("@Active", Active);
            Parameters[1] = new SqlParameter("@Name", Name);
            Parameters[2] = new SqlParameter("@StakeHolderType", StakeHolderId);
            Parameters[3] = new SqlParameter("@UserLoginId", UserLogin);

            Parameters[4] = new SqlParameter("@FromDate", FromDate);

            Parameters[5] = new SqlParameter("@ToDate", TOdate);
            Parameters[6] = new SqlParameter("@Image", Image);

            return objDALCommon.ExecuteProcedure("sinAdvertisement", CommandType.StoredProcedure, Parameters);
        }




        public int UpdateAdvertisements(int Ident, int StakeHolderId, string Name, string FromDate, string TOdate, byte[] Image, string UserLogin, bool Active)
        {

            SqlParameter[] Parameters = new SqlParameter[8];
            Parameters[0] = new SqlParameter("@Id", Ident);

            Parameters[1] = new SqlParameter("@Active", Active);
            Parameters[2] = new SqlParameter("@Name", Name);
            Parameters[3] = new SqlParameter("@StakeHolderType", StakeHolderId);
            Parameters[4] = new SqlParameter("@UserLoginId", UserLogin);

            Parameters[5] = new SqlParameter("@FromDate", FromDate);

            Parameters[6] = new SqlParameter("@ToDate", TOdate);
            Parameters[7] = new SqlParameter("@Image", Image);

            return objDALCommon.ExecuteProcedure("supAdvertisement", CommandType.StoredProcedure, Parameters);
        }


        public DataSet CheckNameExists(string Name,string Type)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Name", Name);
            parameters[1] = new SqlParameter("@Type", Type);

            return objDALCommon.ExecuteProcedure_select("sreCheckNameExists", parameters);
        }

        public DataSet CheckrCodeExists(string Code,string Type)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Code", Code);
            parameters[1] = new SqlParameter("@Type", Type);

            return objDALCommon.ExecuteProcedure_select("sreCheckCodeExists", parameters);
        }

    }
}
