using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALRMS;
using System.Data;

using DALCSCL;
namespace BLLRMS
{
    public class BLLRetailerPreviousOrderItems
    {
        DALRetailerPreviousOrderItem objDALRetailerPreviousOrderItem = new DALRetailerPreviousOrderItem();
        public DataSet GetRetailerOrderDetailsToGrid(string OrderNumber, string RetailerId)
        {

            return objDALRetailerPreviousOrderItem.GetRetailerOrderDetailsToGrid(OrderNumber, RetailerId);
        }

        public DataSet GetASMWiseASOAccs(int ASMAccId)
        {

            return objDALRetailerPreviousOrderItem.GetASMwiseASOs(ASMAccId);
        }



        public DataSet GetStakeHolderBirthdays(int ASOAccId,int Month)
        { 
            return objDALRetailerPreviousOrderItem.GetStakeHolderBirthday(ASOAccId, "", "", Month);
        }


        public DataSet GetStakeHolderReports(int ASOAccId,string FromDate, string Todate)
        {
            return objDALRetailerPreviousOrderItem.GetStakeholderReports(ASOAccId,FromDate,Todate);
        }

        public DataSet GetDigitalLeadsReport(int ASOAccId, string FromDate , string ToDate,int StakeHolderId)
        {
            return objDALRetailerPreviousOrderItem.GetDigitalLeadsReport(ASOAccId,FromDate,ToDate,StakeHolderId);
        }



        public DataSet GetHomeOwnerProductivity(int ASOAccId, string FromDate, string ToDate, int LeadType)
        {
            return objDALRetailerPreviousOrderItem.HomeOwnerProductivity(ASOAccId, FromDate,ToDate,LeadType);
        }



        public DataSet GetHomeOwnerProductivity(int ASOAccId)
        {
            return objDALRetailerPreviousOrderItem.HomeOwnerProductivityGrid(ASOAccId);
        }

    }
}
