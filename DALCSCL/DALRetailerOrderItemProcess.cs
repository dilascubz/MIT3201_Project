using System.Data;
using System.Data.SqlClient;

namespace DALCSCL
{
    public class DALRetailerOrderItemProcess
    {
        private DALCommon objDALCommon = new DALCommon();

        public DataSet GetItemDetails(int Id)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Id", Id);

            return objDALCommon.ExecuteProcedure_select("sreGetItemDetailsForOrder", parameters);
        }

        public DataSet CheckDeliverToCity(int RetailerId, int companyId)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@RetailerId", RetailerId);
            parameters[1] = new SqlParameter("@companyId", companyId);

            return objDALCommon.ExecuteProcedure_select("sreCheckDeliverToCity", parameters);
        }

        public DataSet CheckMinValueByCompany(int CompanyId)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@CompanyId", CompanyId);

            return objDALCommon.ExecuteProcedure_select("sreCheckMinValueByCompany", parameters);
        }
    }
}
