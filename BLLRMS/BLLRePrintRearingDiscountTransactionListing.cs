using System;
using System.Data;
using DALMPRS;


namespace BLLMPRS
{
    public partial class BLLRePrintTransporterTransactionListing
    {
        private DALRePrintRearingDiscountTransactionListing objdalRePrintTransporterTransactionListingDAL;

        public BLLRePrintTransporterTransactionListing()
        {
            objdalRePrintTransporterTransactionListingDAL = new DALRePrintRearingDiscountTransactionListing();
        }

        public DataSet GetAllTransactionsByPeriod(DateTime dateTxnDate, string strName)
        {
            return objdalRePrintTransporterTransactionListingDAL.GetAllTransactionsByPeriod(dateTxnDate, strName);
        }

        public int DeleteTempTransporterPrintStatement(string strUserID)
        {
            return objdalRePrintTransporterTransactionListingDAL.DeleteTempTransporterPrintStatement(strUserID);
        }

        public int InsertRePrintTransporterPrintStatement(string strID, string strMode, string strUserID)
        {
            return objdalRePrintTransporterTransactionListingDAL.InsertRePrintTransporterPrintStatement(strID, strMode, strUserID);
        }
    }
}