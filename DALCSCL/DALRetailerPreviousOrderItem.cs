using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DALCSCL
{
    public class DALRetailerPreviousOrderItem
    {
        private DALCommon objDALCommon = new DALCommon();
        public DataSet GetRetailerOrderDetailsToGrid(string OrderNumber, string RetailerId)
        {
            SqlParameter[] Parameters = new SqlParameter[2];

            Parameters[0] = new SqlParameter("@OrderId", OrderNumber);
            Parameters[1] = new SqlParameter("@RetailerId", RetailerId);

            return objDALCommon.ExecuteProcedure_select("sreRetailerPreviousItemDetails", Parameters);
        }


        public int InsertChat(string UserName, string Message, string DateTime, string UserId)
        {
            SqlParameter[] Parameters = new SqlParameter[2];

            Parameters[0] = new SqlParameter("@OrderId", UserName);
            Parameters[1] = new SqlParameter("@RetailerId", Message);
            Parameters[1] = new SqlParameter("@RetailerId", Message);
            Parameters[1] = new SqlParameter("@RetailerId", Message);



            return objDALCommon.ExecuteProcedure("sreRetailerPreviousItemDetails", CommandType.StoredProcedure, Parameters);
        }




        public DataSet GetASMwiseASOs(int ASMAccId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@ASMAccId", ASMAccId);       
            return objDALCommon.ExecuteProcedure_select("sreGetAllASOforASM", Parameters);
        }



        public DataSet GetStakeHolderBirthday(int ASOAccId, string FromDate,string ToDate,int Month)
        {
            SqlParameter[] parameters = new SqlParameter[4];

            parameters[0] = new SqlParameter("@ASOAccId", ASOAccId);
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@MonthId", Month);
            return objDALCommon.ExecuteProcedure_select("sregetstakeholderBirthdays", parameters);
        }

        public DataSet GetStakeholderReports(int ASOAccId, string FromDate,string ToDate)
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@ASOAccId", ASOAccId);
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            return objDALCommon.ExecuteProcedure_select("sregetstakeholderReports", parameters);
        }

        public DataSet GetDigitalLeadsReport(int ASOAccId, string FromDate, string ToDate,int StakeHolderId)
        {
            SqlParameter[] parameters = new SqlParameter[4];

            parameters[0] = new SqlParameter("@ASOAccId", ASOAccId);
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@StakeHolderid", StakeHolderId);
            return objDALCommon.ExecuteProcedure_select("sregetDigitalReports", parameters);
        }

        public DataSet HomeOwnerProductivity(int ASOAccId,string FromDate, string ToDate,int LeadType)
        {
            SqlParameter[] parameters = new SqlParameter[4];

            parameters[0] = new SqlParameter("@ASOAccId", ASOAccId);
            parameters[1] = new SqlParameter("@FromDate", FromDate);
            parameters[2] = new SqlParameter("@ToDate", ToDate);
            parameters[3] = new SqlParameter("@LeadType", LeadType);

            return objDALCommon.ExecuteProcedure_select("sregetHomeOwnerProductivityOld", parameters);
        }


        public DataSet HomeOwnerProductivityGrid(int ASOAccId)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@ASOAccId", ASOAccId);
           

            return objDALCommon.ExecuteProcedure_select("sregetHomeOwnerProductivity", parameters);
        }

    }




}
