using System.Data;
using DALMPRS;

namespace BLLMPRS
{
    public partial class BLLAgingDealer
    {
        private DALAgingDealer objDAL;

        public BLLAgingDealer()
        {
            objDAL = new DALAgingDealer();
        }

        public DataSet AgingDealers()
        {
            return objDAL.AgingDealers();
        }
    }
}