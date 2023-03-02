using System.Data;
using System.Data.SqlClient;
using DALMPRS;

namespace BLLMPRS
{
    public class BLLConfiguration
    {
        private DALCommon objDALCommon = new DALCommon();

        public DataSet GetCompanyItems(int CompanyId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@CompanyId", CompanyId);
            return objDALCommon.ExecuteProcedure_select("SreGetCompanyItems", Parameters);
        }
        public DataSet GetOrderDetailsToGrid(string Identification,string UserId)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@Identification", Identification);
            parameters[1] = new SqlParameter("@UserId", UserId);

            return objDALCommon.ExecuteProcedure_select("sreGetDetails", parameters);
            

        }

        public int UpdateOrderDetailsNo(string OrderNumber, int CompanyId)
        {
            SqlParameter[] Parameters = new SqlParameter[2];

            Parameters[0] = new SqlParameter("@OrderNo", OrderNumber);
            Parameters[1] = new SqlParameter("@ComapnyId", CompanyId);

            return objDALCommon.ExecuteProcedure("supComfirmOrder", CommandType.StoredProcedure, Parameters);
        }

        public int UpdatePreOrderDetailQty(string IdentificationNo, string VehicleRegNo,int PassengerCount, string PassengerName, string PassengerNIC, int PassengerMobileNo, string UserId)
        {
            SqlParameter[] Parameters = new SqlParameter[7];

            Parameters[0] = new SqlParameter("@IdentificationNo", IdentificationNo);
            Parameters[1] = new SqlParameter("@VehicleRegNo", VehicleRegNo);
            Parameters[2] = new SqlParameter("@PassengerCountId", PassengerCount);
            Parameters[3] = new SqlParameter("@PassengerName", UserId);
            Parameters[4] = new SqlParameter("@PassengerNIC", PassengerNIC);
            Parameters[5] = new SqlParameter("@PassengerMobileNo", PassengerMobileNo);

            Parameters[6] = new SqlParameter("@UserId", UserId);
           // Parameters[7] = new SqlParameter("@PassengerMobileNo", UserId);



            return objDALCommon.ExecuteProcedure("supPreOrderDetailQty", CommandType.StoredProcedure, Parameters);
        }

        public int CancelOrders(string OrderNumber, int ComapnyId)
        {
            SqlParameter[] Parameters = new SqlParameter[2];

            Parameters[0] = new SqlParameter("@OrderNo", OrderNumber);
            Parameters[1] = new SqlParameter("@ComapnyId", ComapnyId);

            return objDALCommon.ExecuteProcedure("supCancelOrder", CommandType.StoredProcedure, Parameters);
        }

        public DataSet GetCompanyOrderSummary(int CompanyId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@CompanyId", CompanyId);
            return objDALCommon.ExecuteProcedure_select("sregetCompanyOrderSummary", Parameters);
        }
    }
}
