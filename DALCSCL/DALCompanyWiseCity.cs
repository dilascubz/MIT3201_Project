using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DALCSCL
{
    public class DALCompanyWiseCity
    {
        private DALCommon objDALCommon = new DALCommon();

        public DataSet GetCompany()
        {
            return objDALCommon.ExecuteProcedure_select("sreCompany");
        }

        public DataSet GetCity()
        {
            return objDALCommon.ExecuteProcedure_select("sreCity");
        }

        public DataSet GetCompanyWiseCityToGrid()
        {
            return objDALCommon.ExecuteProcedure_select("sreCompanyWiseCity");
        }

        public DataSet InsertCompanyWiseCity(int CompanyId, string CityId)
        {
            SqlParameter[] Parameters = new SqlParameter[2];
            Parameters[0] = new SqlParameter("@CompanyId", CompanyId);
            Parameters[1] = new SqlParameter("@CityId", CityId);

            return objDALCommon.ExecuteProcedure_select("sinCompanyWiseCity", Parameters);
        }

        public DataSet UpdateCompanyWiseCity(int CityId, bool IsDeliveryAvailable, int Id)
        {
            SqlParameter[] Parameters = new SqlParameter[3];
            Parameters[0] = new SqlParameter("@CityId", CityId);
            Parameters[1] = new SqlParameter("@IsDeliveryAvailable", IsDeliveryAvailable);
            Parameters[2] = new SqlParameter("@Id", Id);

            return objDALCommon.ExecuteProcedure_select("supCompanyWiseCity", Parameters);
        }

        public DataSet CheckCompanyWiseCity(int CityId,int CompanyId)
        {
            SqlParameter[] Parameters = new SqlParameter[2];
            Parameters[0] = new SqlParameter("@CityId", CityId);
            Parameters[1] = new SqlParameter("@CompanyId", CompanyId);

            return objDALCommon.ExecuteProcedure_select("sreChkAvaiDel", Parameters);
        }
    }
}
