using System;
using System.Data;
using DALMPRS;

namespace BLLMPRS
{
    public  class BLLRearing
    {
        private DALRearing objRearingDAL;

        public BLLRearing()
        {
            objRearingDAL = new DALRearing();
        }

        //----------------------------------------BLLRearingComplete

        public DataSet GetPONoRearingComplete()
        {
            return objRearingDAL.GetPONoRearingComplete();
        }

        public int PrintCount(string strPO)
        {
            strPO = strPO.Replace("'", "`");
            if (string.IsNullOrEmpty(strPO.Trim()))
            {
                throw new ApplicationException("Please check the input values.");
            }

            return objRearingDAL.PrintCount(strPO);
        }

        public int InitPrintCount(string strPO, string strUserID)
        {
            strPO = strPO.Replace("'", "`");
            if (string.IsNullOrEmpty(strPO.Trim()))
            {
                throw new ApplicationException("Please check the input values.");
            }

            return objRearingDAL.InitPrintCount(strPO, strUserID);
        }

        public DataSet GetAllTransactionsByPeriod(string strYear, string strMonth, string strType)
        {
            return objRearingDAL.GetPONoRearingComplete(strYear, strMonth, strType);
        }



        //-------------------------------------BLLRearing

        public DataSet GetPORearing()
        {
            return objRearingDAL.GetPORearing();
        }

        public DataSet SBDetails(string strPO)
        {
            if (string.IsNullOrEmpty(strPO.Trim()))
            {
                throw new ApplicationException("Please check the input values.");
            }

            return objRearingDAL.SBDetails(strPO);
        }

        public DataSet MortalityDetails(string strPO)
        {
            if (string.IsNullOrEmpty(strPO.Trim()))
            {
                throw new ApplicationException("Please check the input values.");
            }

            return objRearingDAL.MortalityDetails(strPO);
        }

        public DataSet FinalWeightPayable(string strPO)
        {
            if (string.IsNullOrEmpty(strPO.Trim()))
            {
                throw new ApplicationException("Please check the input values.");
            }

            return objRearingDAL.FinalWeightPayable(strPO);
        }

        public DataSet TotAvgWt(string strPO)
        {
            if (string.IsNullOrEmpty(strPO.Trim()))
            {
                throw new ApplicationException("Please check the input values.");
            }

            return objRearingDAL.TotAvgWt(strPO);
        }

        public DataSet TotFeedDrugVaccCost(string strPO)
        {
            if (string.IsNullOrEmpty(strPO.Trim()))
            {
                throw new ApplicationException("Please check the input values.");
            }

            return objRearingDAL.TotFeedDrugVaccCost(strPO);
        }

        public DataSet BirdCatchingFee(string strPO)
        {
            if (string.IsNullOrEmpty(strPO.Trim()))
            {
                throw new ApplicationException("Please check the input values.");
            }

            return objRearingDAL.BirdCatchingFee(strPO);
        }

        public DataSet IssueDOCCost(string strPO)
        {
            if (string.IsNullOrEmpty(strPO.Trim()))
            {
                throw new ApplicationException("Please check the input values.");
            }

            return objRearingDAL.IssueDOCCost(strPO);
        }

        public DataSet FRSheetPenalty(string strPO)
        {
            if (string.IsNullOrEmpty(strPO.Trim()))
            {
                throw new ApplicationException("Please check the input values.");
            }

            return objRearingDAL.FRSheetPenalty(strPO);
        }

        public DataSet AvgAge(string strPO)
        {
            if (string.IsNullOrEmpty(strPO.Trim()))
            {
                throw new ApplicationException("Please check the input values.");
            }

            return objRearingDAL.AvgAge(strPO);
        }

        public DataSet FcrDetails(string strPO)
        {
            if (string.IsNullOrEmpty(strPO.Trim()))
            {
                throw new ApplicationException("Please check the input values.");
            }

            return objRearingDAL.FcrDetails(strPO);
        }

        public int UpdateRearing(string strPo, decimal decFCR, decimal decTotSBPenalty1, decimal decTotSBPenalty2, decimal decMortality, decimal decBPI, double dblFinalWeightPaymentValue, double dblFinalIncentivePaymentValue, double dblTotalCost, double dblTotBirdCatchingFee, double dblFinalRearingFee, string strUserID)
        {
            if (string.IsNullOrEmpty(strPo.Trim()))
            {
                throw new ApplicationException("Please check the input values.");
            }

            strPo = strPo.Replace("'", "`");
            return objRearingDAL.UpdateRearing(strPo, decFCR, decTotSBPenalty1, decTotSBPenalty2, decMortality, decBPI, dblFinalWeightPaymentValue, dblFinalIncentivePaymentValue, dblTotalCost, dblTotBirdCatchingFee, dblFinalRearingFee, strUserID);
        }


        //--------------BLLRearingDelete



        public int ReversePO(string strPO, string strUserID)
        {
            strPO = strPO.Replace("'", "`");
            return objRearingDAL.ReversePO(strPO, strUserID);
        }

        public int DeletePO(string strPO)
        {
            strPO = strPO.Replace("'", "`");
            return objRearingDAL.DeletePO(strPO);
        }

        //public DataSet GetPORearing()
        //{
        //    return objRearingDAL.GetPORearing();
        //}

        public DataSet GetPODelete(string strPO)
        {
            return objRearingDAL.GetPODelete(strPO);
        }

        public DataSet DeleteRearing(string strPONo)
        {
            return objRearingDAL.DeleteRearing(strPONo);
        }

        public DataSet CheckDelete(string strPO)
        {
            strPO = strPO.Replace("'", "`");
            return objRearingDAL.CheckDelete(strPO);
        }

        public DataSet CheckImport4Process(string strPO)
        {
            strPO = strPO.Replace("'", "`");
            return objRearingDAL.CheckImport4Process(strPO);
        }

        public DataSet CheckPrinted(string strPO)
        {
            strPO = strPO.Replace("'", "`");
            return objRearingDAL.CheckPrinted(strPO);
        }

        public DataSet CheckPermission(string strGroup, string strTaskName)
        {
            strGroup = strGroup.Replace("'", "`");
            strTaskName = strTaskName.Replace("'", "`");
            return objRearingDAL.CheckPermission(strGroup, strTaskName);
        }
    }


}
