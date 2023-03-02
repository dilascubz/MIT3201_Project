using System;
using System.Data;
using DALMPRS;



namespace BLLMPRS
{
    public partial class BLLTransporterTransactionTypeReference
    {
        private DALTransporterTransactionTypeReference objdalTransporterTransactionTypeReferenceDAL;

        public BLLTransporterTransactionTypeReference()
        {
            objdalTransporterTransactionTypeReferenceDAL = new DALTransporterTransactionTypeReference();
        }

        public DataSet SelectAllTransporterTransactionType()
        {
            return objdalTransporterTransactionTypeReferenceDAL.SelectAllTransporterTransactionType();
        }

        public int UpdateTransporterTransactionType(string strId, string strDescription, char chrType, bool bitStatus)
        {
            return objdalTransporterTransactionTypeReferenceDAL.UpdateTransporterTransactionType(strId, strDescription, chrType, bitStatus);
        }

        public int InsertTransporterTransactionType(string strDescription, char chrType, bool bitStatus, string strUserID)
        {
            return objdalTransporterTransactionTypeReferenceDAL.InsertTransporterTransactionType(strDescription, chrType, bitStatus, strUserID);
        }

        public int DeleteTransporterTransactionType(string strID)
        {
            return objdalTransporterTransactionTypeReferenceDAL.DeleteTransporterTransactionType(strID);
        }



        //-----------------BLLTransporterFreeProcess


        public string GetTransportHeaderIdByPeriod(DateTime datePeriod)
        {
            return objdalTransporterTransactionTypeReferenceDAL.GetTransportHeaderIdByPeriod(datePeriod);
        }

        public DataSet GetPOHeaderByFinalLbdaDate(string strFromDate, string strToDate)
        {
            return objdalTransporterTransactionTypeReferenceDAL.GetPOHeaderByFinalLbdaDate(strFromDate, strToDate);
        }

        public DataSet GetPODetailByPONo(string strFromDate, string strToDate)
        {
            return objdalTransporterTransactionTypeReferenceDAL.GetPODetailByPONo(strFromDate, strToDate);
        }

        public string InsertTransporterTransactionHeader(string strPeriod, string strUserID)
        {
            return objdalTransporterTransactionTypeReferenceDAL.InsertTransporterTransactionHeader(strPeriod, strUserID);
        }

        public void InsertTransporterTransactionDetail(string strTransporterCode, int nTransportedBirds, decimal decTransportRate, decimal decGrossTransportFee, decimal decCDPenalty, decimal decDOAPenalty, decimal decNetTransportFee, decimal decFinalTransportFee, string decTransporterTransactionHeaderId)
        {
            objdalTransporterTransactionTypeReferenceDAL.InsertTransporterTransactionDetail(strTransporterCode, nTransportedBirds, decTransportRate, decGrossTransportFee, decCDPenalty, decDOAPenalty, decNetTransportFee, decFinalTransportFee, decTransporterTransactionHeaderId);
        }

        public void UpdateImport4ProcessTF(string strFromDate, string strToDate)
        {
            objdalTransporterTransactionTypeReferenceDAL.UpdateImport4ProcessTF(strFromDate, strToDate);
        }

    }


}