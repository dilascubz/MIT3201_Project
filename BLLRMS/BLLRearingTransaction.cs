using System.Data;
using DALMPRS;


namespace BLLMPRS
{

    public partial class BLLRearingTransaction
    {
        private DALRearingTransaction objRearingTransactionDAL;
        private DALRearingTransaction objRearingTransactionTypeReferenceDAL;

        public BLLRearingTransaction()
        {
            objRearingTransactionDAL = new DALRearingTransaction();
        }

        // Public Function GetAllTransactionsByPeriod(ByVal dateDate As String, ByVal strName As String) As DataSet
        public DataSet GetAllTransactionsByPeriod(int intYear, int intMonth, string strName)
        {
            return objRearingTransactionDAL.GetAllTransactionsByPeriod(intYear, intMonth, strName);
        }

        public DataSet GetTransactionDetailById(string strPoNo)
        {
            return objRearingTransactionDAL.GetTransactionDetailById(strPoNo);
        }

        public DataSet GetRearingAddition(string strPoNo)
        {
            return objRearingTransactionDAL.GetRearingAddition(strPoNo);
        }

        public DataSet GetRearingDeduction(string strPoNo)
        {
            return objRearingTransactionDAL.GetRearingDeduction(strPoNo);
        }

        // '********** Additions *******************************************************************************************
        public DataSet GetAllAddtionsByTransactionId(string strPoNo)
        {
            return objRearingTransactionDAL.GetAllAddtionsByTransactionId(strPoNo);
        }

        public DataSet GetAllMiscellaneousAdditions()
        {
            return objRearingTransactionDAL.GetAllMiscellaneousAdditions();
        }

        public int InsertAdditions(string strPoNo, string strTransID, double dblAmount, char chrType, string strUserID)
        {
            // check whether the discount amount is exeeded
            objRearingTransactionDAL.InsertAdditions(strPoNo, strTransID, dblAmount, strUserID);
            return default;
        }

        public int DeleteAdditions(string strPoNo, string strTransID, string strUserID)
        {
            objRearingTransactionDAL.DeleteAdditions(strPoNo, strTransID, strUserID);
            return default;
        }

        // ********** Deductions *******************************************************************************************
        public DataSet GetAllDeductionsByTransactionId(string strPoNo)
        {
            return objRearingTransactionDAL.GetAllDeductionsByTransactionId(strPoNo);
        }

        public DataSet GetAllMiscellaneousDeductions()
        {
            return objRearingTransactionDAL.GetAllMiscellaneousDeductions();
        }

        public int InsertDeductions(string strTransporterTxnID, string strTransD, double dblAmount, char chrType, string strUserID)
        {
            objRearingTransactionDAL.InsertDeductions(strTransporterTxnID, strTransD, dblAmount, strUserID);
            return default;
        }

        public int DeleteDeductions(string strPoNo, string strTransID, string strUserID)
        {
            objRearingTransactionDAL.DeleteAdditions(strPoNo, strTransID, strUserID);
            return default;
        }

        public DataSet CheckPrinted(string strPoNo)
        {
            return objRearingTransactionDAL.CheckPrinted(strPoNo);
        }

        public DataSet Import4Process(string strPoNo)
        {
            return objRearingTransactionDAL.Import4Process(strPoNo);
        }



        //-------------------- BLLRearingTransactionTypeReference 

    

        public DataSet SelectAllRearingTransactionType()
        {
            return objRearingTransactionTypeReferenceDAL.SelectAllRearingTransactionType();
        }

        public int UpdateRearingTransactionType(string strId, string strDescription, char chrType, bool bitStatus, string strUserID)
        {
            return objRearingTransactionTypeReferenceDAL.UpdateRearingTransactionType(strId, strDescription, chrType, bitStatus, strUserID);
        }

        public int InsertRearingTransactionType(string strDescription, char chrType, string strUserID)
        {
            return objRearingTransactionTypeReferenceDAL.InsertRearingTransactionType(strDescription, chrType, strUserID);
        }

        public int DeleteRearingTransactionType(string strID, string strUserID)
        {
            return objRearingTransactionTypeReferenceDAL.DeleteRearingTransactionType(strID, strUserID);
        }
    }