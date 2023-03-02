using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DALMPRS;

namespace BLLMPRS
{
    public class BLLRearingDiscountFeeProcess
    {
        private DALTransporter objdalTransporterDAL;
        private DALTransporter FeeReversalProcessDAL;
        private DALRearingDiscountFeeProcess objdalRearingDiscountFeeProcessDAL;

        public BLLRearingDiscountFeeProcess()
        {
            objdalRearingDiscountFeeProcessDAL = new DALRearingDiscountFeeProcess();
        }

        public string GetRearingDiscountHeaderIdByPeriod(DateTime datePeriod)
        {
            return objdalRearingDiscountFeeProcessDAL.GetRearingDiscountHeaderIdByPeriod(datePeriod);
        }

        public DataSet GetRearingDiscountPODetailByPONo(string strFromDate, string strToDate)
        {
            return objdalRearingDiscountFeeProcessDAL.GetRearingDiscountPODetailByPONo(strFromDate, strToDate);
        }

        public DataSet GetSpecialAllowancePODetailByPONo(string strFromDate, string strToDate, string strDealerCode)
        {
            return objdalRearingDiscountFeeProcessDAL.GetSpecialAllowancePODetailByPONo(strFromDate, strToDate, strDealerCode);
        }

        public string InsertRearingDiscountTransactionHeader(string strPeriod, string strUserID)
        {
            return objdalRearingDiscountFeeProcessDAL.InsertRearingDiscountTransactionHeader(strPeriod, strUserID);
        }

        public string InsertRearingDiscountTransactionDetail(string strDealerCode, string strDealerName, int nTotalIssued, int nReceivedBirds, decimal decRearingDiscountRate, decimal decSpeacialAllowanceRate, decimal decGrossRearingDiscount, decimal decGrossSpecialAllowance, string decRearingDiscountTransactionHeaderId)
        {
            return objdalRearingDiscountFeeProcessDAL.InsertRearingDiscountTransactionDetail(strDealerCode, strDealerName, nTotalIssued, nReceivedBirds, decRearingDiscountRate, decSpeacialAllowanceRate, decGrossRearingDiscount, decGrossSpecialAllowance, decRearingDiscountTransactionHeaderId);
        }

        public void UpdateImport4ProcessRD(string strFromDate, string strToDate)
        {
            objdalRearingDiscountFeeProcessDAL.UpdateImport4ProcessRD(strFromDate, strToDate);
        }


        //---------------------------BLLTransportFeeProcess


        public string GetTransportHeaderIdByPeriod(DateTime datePeriod)
        {
            return objdalRearingDiscountFeeProcessDAL.GetTransportHeaderIdByPeriod(datePeriod);
        }

        public DataSet GetPOHeaderByFinalLbdaDate(string strFromDate, string strToDate)
        {
            return objdalRearingDiscountFeeProcessDAL.GetPOHeaderByFinalLbdaDate(strFromDate, strToDate);
        }

        public DataSet GetPODetailByPONo(string strFromDate, string strToDate)
        {
            return objdalRearingDiscountFeeProcessDAL.GetPODetailByPONo(strFromDate, strToDate);
        }

        public string InsertTransporterTransactionHeader(string strPeriod, string strUserID)
        {
            return objdalRearingDiscountFeeProcessDAL.InsertTransporterTransactionHeader(strPeriod, strUserID);
        }

        public void InsertTransporterTransactionDetail(string strTransporterCode, int nTransportedBirds, decimal decTransportRate, decimal decGrossTransportFee, decimal decCDPenalty, decimal decDOAPenalty, decimal decNetTransportFee, decimal decFinalTransportFee, string decTransporterTransactionHeaderId)
        {
            objdalRearingDiscountFeeProcessDAL.InsertTransporterTransactionDetail(strTransporterCode, nTransportedBirds, decTransportRate, decGrossTransportFee, decCDPenalty, decDOAPenalty, decNetTransportFee, decFinalTransportFee, decTransporterTransactionHeaderId);
        }

        public void UpdateImport4ProcessTF(string strFromDate, string strToDate)
        {
            objdalRearingDiscountFeeProcessDAL.UpdateImport4ProcessTF(strFromDate, strToDate);
        }


    }
}
