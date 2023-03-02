using System.Data;
using DALMPRS;


namespace BLLMPRS
{
    public partial class BLLTaxTypeRefrence
    {
        private DALTaxTypeRefrence objdalTaxDAL;

        public BLLTaxTypeRefrence()
        {
            objdalTaxDAL = new DALTaxTypeRefrence();
        }

        public DataSet SelectAllUserGroups()
        {
            return objdalTaxDAL.SelectAllTaxType();
        }

        public int UpdateTaxType(string strId, string strDescription, decimal decPercentage, bool bitStatus)
        {
            return objdalTaxDAL.UpdateTaxType(strId, strDescription, decPercentage, bitStatus);
        }



        public DataSet GetAllTax()
        {
            return objdalTaxDAL.GetAllTax();
        }

        public object GetTax(string strTaxCode)
        {
            return objdalTaxDAL.GetTax(strTaxCode);
        }


        //--------------------BLLTransporterTax
        public DataSet GetTaxByTransporter(string strTransporterCode)
        {
            return objdalTaxDAL.GetTaxByTransporter(strTransporterCode);
        }

        public DataSet GetWHTaxByTransporter(string strTransporterCode)
        {
            return objdalTaxDAL.GetWHTaxByTransporter(strTransporterCode);
        }

        public DataSet GetAllTaxByTransporter(string strTransporterCode)
        {
            return objdalTaxDAL.GetAllTaxByTransporter(strTransporterCode);
        }

        public int InsertTransporterTax(string strTransporterCode, string strTaxCode)
        {
            return objdalTaxDAL.InsertTransporterTax(strTransporterCode, strTaxCode);
        }

        public int InsertTransporterWHTax(string strTransporterCode, string strTaxCode, decimal decWHTax)
        {
            return objdalTaxDAL.InsertTransporterWHTax(strTransporterCode, strTaxCode, decWHTax);
        }

        public int DeleteTransporterTax(string strTransporterCode)
        {
            return objdalTaxDAL.DeleteTransporterTax(strTransporterCode);
        }

    }
}

