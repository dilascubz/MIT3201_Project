using System;
using System.Data;
using DALMPRS;



namespace BLLMPRS
{
    public partial class BLLTransporter
    {
        private DALTransporter objdalTransporterDAL;
        private DALTransporter FeeReversalProcessDAL;

        public BLLTransporter()
        {
            objdalTransporterDAL = new DALTransporter();
        }

        public DataSet GetAllTransporters()
        {
            return objdalTransporterDAL.GetAllTransporters();
        }

        public DataSet GetTransporterByCode(string strTransporterCode)
        {
            return objdalTransporterDAL.GetTransporterByCode(strTransporterCode);
        }

        public int InsertRecord(string strCode, string strName, string strAddress1, string strAddress2, string strAddress3, string strContact, string strFax, string strEmail, string strVATNo, string strRemarks, bool bStatus)
        {
            return objdalTransporterDAL.InsertRecord(strCode, strName, strAddress1, strAddress2, strAddress3, strContact, strFax, strEmail, strVATNo, strRemarks, bStatus);
        }

        public int UpdateRecord(int nId, string strCode, string strName, string strAddress1, string strAddress2, string strAddress3, string strContact, string strFax, string strEmail, string strVATNo, string strRemarks, bool bStatus)
        {
            return objdalTransporterDAL.UpdateRecord(nId, strCode, strName, strAddress1, strAddress2, strAddress3, strContact, strFax, strEmail, strVATNo, strRemarks, bStatus);
        }

        public int DeleteRecord(int nId, string strCode)
        {
            objdalTransporterDAL.DeleteRecord(nId, strCode);
            return default;
        }


        //------------------------bllTransporterFeeReversalProcess

        // ()

        public string GetTransporterTransactionHeaderIdByPeriod(DateTime datePeriod)
        {
            return objdalTransporterDAL.GetTransporterTransactionHeaderIdByPeriod(datePeriod);
        }

        public bool GetReversalTransactionHeaderId(DateTime datePeriod)
        {
            return objdalTransporterDAL.GetReversalTransactionHeaderId(datePeriod);
        }

        public bool GetTransporterTransactionHeaderIdFromTransactionDetail(string strTransporterTransactionHeaderId)
        {
            return objdalTransporterDAL.GetTransporterTransactionHeaderIdFromTransactionDetail(strTransporterTransactionHeaderId);
        }

        public DataSet GetTransporterHeaderById(string strTransporterTransactionHeaderId)
        {
            return objdalTransporterDAL.GetTransporterHeaderById(strTransporterTransactionHeaderId);
        }

        public void TranspoterTransactionReversalProcess(string strTransporterTransactionHeaderId, string strUserId)
        {
            objdalTransporterDAL.TranspoterTransactionReversalProcess(strTransporterTransactionHeaderId, strUserId);
        }

        public void UpdateImport4ProcessTF(string strFromDate, string strToDate)
        {
            objdalTransporterDAL.UpdateImport4ProcessTF(strFromDate, strToDate);

        }


        //--------------------------------------------bllTransporterTransaction


        public DataSet GetAllTransactionsByPeriod(string dateDate, string strName)
        {
            return objdalTransporterDAL.GetAllTransactionsByPeriod(dateDate, strName);
        }

        public DataSet GetTransactionDetailById(string Id)
        {
            return objdalTransporterDAL.GetTransactionDetailById(Id);
        }

        // '********** Additions *******************************************************************************************				
        public DataSet GetAllAddtionsByTransactionId(string Id)
        {
            return objdalTransporterDAL.GetAllAddtionsByTransactionId(Id);
        }

        public DataSet GetAllMiscellaneousAdditions()
        {
            return objdalTransporterDAL.GetAllMiscellaneousAdditions();
        }

        public int InsertAdditions(string strTransporterTxnID, string strMiscID, decimal decAmount, char chrType, string strUserId)
        {
            // check whether the discount amount is exeeded				
            objdalTransporterDAL.InsertAdditions(strTransporterTxnID, strMiscID, decAmount, strUserId);
            objdalTransporterDAL.UpdateFinalTransportFee(strTransporterTxnID);
            return default;
        }

        public int DeleteAdditions(string strTransporterTxnID, string strMiscID)
        {
            objdalTransporterDAL.DeleteAdditions(strTransporterTxnID, strMiscID);
            objdalTransporterDAL.UpdateFinalTransportFee(strTransporterTxnID);
            return default;
        }

        // ********** Deductions *******************************************************************************************				
        public DataSet GetAllDeductionsByTransactionId(string Id)
        {
            return objdalTransporterDAL.GetAllDeductionsByTransactionId(Id);
        }

        public DataSet GetAllMiscellaneousDeductions()
        {
            return objdalTransporterDAL.GetAllMiscellaneousDeductions();
        }

        public int InsertDeductions(string strTransporterTxnID, string strMiscID, decimal decAmount, char chrType, string strUserId)
        {
            var objdalTranspoterTransactionTypeReferenceDAL = new DALTransporterTransactionTypeReference();
            if (Convert.ToString(chrType) == "D")
            {
                if (objdalTransporterDAL.GetFinalTransportFeeById(strTransporterTxnID) - objdalTranspoterTransactionTypeReferenceDAL.GetExistingDeductionsById(strTransporterTxnID) < Convert.ToDouble(decAmount))
                {
                    throw new ApplicationException("Final Discount Amount Exceeded.");
                }
            }

            objdalTransporterDAL.InsertDeductions(strTransporterTxnID, strMiscID, decAmount, strUserId);
            objdalTransporterDAL.UpdateFinalTransportFee(strTransporterTxnID);
            return default;
        }

        public int DeleteDeductions(string strTransporterTxnID, string strMiscID)
        {
            objdalTransporterDAL.DeleteAdditions(strTransporterTxnID, strMiscID);
            objdalTransporterDAL.UpdateFinalTransportFee(strTransporterTxnID);
            return default;
        }

        public int UpdateNetPayablePrintSatatusById(string strId, decimal decTotalTaxAmount, decimal decNetPayable)
        {
            return objdalTransporterDAL.UpdateNetPayablePrintSatatusById(strId, decTotalTaxAmount, decNetPayable);
        }




        //--------------------------- bllTransporterTransactionListing				


        public DataSet GetAllTransactionsByPeriodTransactions(string dateDate, string strName)
        {
            return objdalTransporterDAL.GetAllTransactionsByPeriodTransactions(dateDate, strName);
        }

        public int DeleteTempTransporterPrintStatement(string strUserID)
        {
            objdalTransporterDAL.DeleteTempTransporterPrintStatement(strUserID);
            return default;
        }

        public object InsertTransporterPrintStatement(string strID, string strMode, string strUserID)
        {
            return objdalTransporterDAL.InsertTransporterPrintStatement(strID, strMode, strUserID);
        }

        public object InsertTransporterProformaPrintStatement(string strID, string strMode, string strUserID)
        {
            return objdalTransporterDAL.InsertTransporterProformaPrintStatement(strID, strMode, strUserID);
        }






    }
}