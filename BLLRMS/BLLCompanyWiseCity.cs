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
    public class BLLCompanyWiseCity
    {
        DALCompanyWiseCity objDALCompanyWiseCity = new DALCompanyWiseCity();

        public DataSet GetCompany()
        {
            return objDALCompanyWiseCity.GetCompany();
        }

        public DataSet GetCity()
        {
            return objDALCompanyWiseCity.GetCity();
        }

        public DataSet GetCompanyWiseCityToGrid()
        {
            return objDALCompanyWiseCity.GetCompanyWiseCityToGrid();
        }

        public DataSet InsertCompanyWiseCity(int CompanyId, string Id)
        {

            return objDALCompanyWiseCity.InsertCompanyWiseCity(CompanyId,Id);
        }

        public DataSet UpdateCompanyWiseCity(int CityId, int Id, bool IsDeliveryAvailable)
        {

            return objDALCompanyWiseCity.UpdateCompanyWiseCity( CityId, IsDeliveryAvailable, Id);
        }

        public DataSet CheckCompanyWiseCity(int CityId, int CompanyId)
        {
            return objDALCompanyWiseCity.CheckCompanyWiseCity(CityId, CompanyId);
        }
    }
}
