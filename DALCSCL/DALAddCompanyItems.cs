using System.Data;
using System.Data.SqlClient;

namespace DALCSCL
{
    public class DALAddCompanyItems
    {
        private DALCommon objDALCommon = new DALCommon();

        public DataSet GetCompanyItems(int CompanyId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@CompanyId", CompanyId);
            return objDALCommon.ExecuteProcedure_select("SreGetCompanyItems", Parameters);
        }
        public DataSet GetOrderDetailsToGrid(string OrderNumber, string CompanyId)
        {
            SqlParameter[] Parameters = new SqlParameter[2];

            Parameters[0] = new SqlParameter("@OrderId", OrderNumber);
            Parameters[1] = new SqlParameter("@CompanyId", CompanyId);

            return objDALCommon.ExecuteProcedure_select("sreGetItemDetails", Parameters);
        }

        public int UpdateOrderDetailsNo(string OrderNumber, int CompanyId)
        {
            SqlParameter[] Parameters = new SqlParameter[2];

            Parameters[0] = new SqlParameter("@OrderNo", OrderNumber);
            Parameters[1] = new SqlParameter("@ComapnyId", CompanyId);

            return objDALCommon.ExecuteProcedure("supComfirmOrder", CommandType.StoredProcedure, Parameters);
        }

        public int UpdatePreOrderDetailQty(string OrderNo, int ItemId, int Qty, string UserId)
        {
            SqlParameter[] Parameters = new SqlParameter[4];

            Parameters[0] = new SqlParameter("@OrderNo", OrderNo);
            Parameters[1] = new SqlParameter("@ItemId", ItemId);
            Parameters[2] = new SqlParameter("@Qty", Qty);
            Parameters[3] = new SqlParameter("@UserId", UserId);

            return objDALCommon.ExecuteProcedure("supPreOrderDetailQty", CommandType.StoredProcedure, Parameters);
        }

        public int CancelOrders(string OrderNumber, int ComapnyId, string CancelReason)
        {
            SqlParameter[] Parameters = new SqlParameter[3];

            Parameters[0] = new SqlParameter("@OrderNo", OrderNumber);
            Parameters[1] = new SqlParameter("@ComapnyId", ComapnyId);
            Parameters[2] = new SqlParameter("@CancelReason", CancelReason); 

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
