using System;
using System.Data;
using DALMPRS; // Install-Package Microsoft.VisualBasic
using DevExpress.Web.ASPxSpreadsheet.Internal.Forms;


namespace BLLMPRS
{
    public partial class BLLSpecialAllowanceRetentionCalculation
    {
        private DALSpecialAllowanceRetentionCalculation objdalAllowanceRetentionCalculationDAL;
        private BLLTransporter objdalDealerTransactionTypeReferenceDAL;

        public BLLSpecialAllowanceRetentionCalculation()
        {
            objdalAllowanceRetentionCalculationDAL = new DALSpecialAllowanceRetentionCalculation();
            objdalDealerTransactionTypeReferenceDAL = new BLLTransporter();
        }

        public DataSet GetAllTransactionsByPeriod(DateTime dateDate)
        {
            return objdalAllowanceRetentionCalculationDAL.GetAllTransactionsByPeriod(dateDate);
        }

        public int UpdateRetention(string strId, decimal decRetentionRate)
        {
            DataSet dsAllowanceTransaction;
            //  MessageBox.Show("in");
            dsAllowanceTransaction = objdalAllowanceRetentionCalculationDAL.GetSpecialAllowanceTransactionsById(strId);
            if (dsAllowanceTransaction.Tables[0].Rows.Count != 0)
            {
                decimal decFinalAmount = Convert.ToDecimal(dsAllowanceTransaction.Tables[0].Rows[0]["FinalAmount"]);
                decimal decRetentionAmount = Convert.ToDecimal((dsAllowanceTransaction.Tables[0].Rows[0]["GrossAllowanceAmount"], decRetentionRate / 100m));
                //  MessageBox.Show("in");
                if (decFinalAmount < decRetentionAmount)
                {
                    // Throw New ApplicationException("Retention Amount Exceeds Final Discount.")
                    return default;
                }
            }

            return objdalAllowanceRetentionCalculationDAL.UpdateRetention(strId, decRetentionRate);
        }

        public int UpdateFinalDiscountFee(string strDealerTxnId)
        {
            return objdalAllowanceRetentionCalculationDAL.UpdateFinalAllowanceFee(strDealerTxnId);
        }
    }
}