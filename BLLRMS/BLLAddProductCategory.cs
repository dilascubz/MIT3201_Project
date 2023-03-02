using DALRMS;
using System.Data;
using DALCSCL;

namespace BLLRMS
{
    public class BLLAddProductCategory
    {
        private DALAddProductCategory objDALAddProductCategory = new DALAddProductCategory();

        public DataSet CheckProductCategory(int CompanyId, string Name)
        {
            return objDALAddProductCategory.CheckProductCategory(CompanyId, Name);
        }



        public int AddAdvertisements(int StakeHolderId, string Name, string FromDate, string TOdate, byte[] Image, string UserLogin, bool Active)
        {
            return objDALAddProductCategory.AddAdvertisements(StakeHolderId, Name, FromDate, TOdate, Image, UserLogin, Active);

        }

        public int UpDateAdvertisemtny(int StakeHolderId, string Name, string FromDate, string TOdate, byte[] Image, string UserLogin, bool Active, int ID)
        {
            return objDALAddProductCategory.UpdateAdvertisements(ID, StakeHolderId, Name, FromDate, TOdate, Image, UserLogin, Active);
        }

        public DataSet CheckPromotionsNameExists(string Name, string Type)
        {
            return objDALAddProductCategory.CheckNameExists(Name, Type);
        }

        public DataSet CheckPromotionCodeExists(string Code, string Type)
        {
            return objDALAddProductCategory.CheckrCodeExists(Code, Type);
        }

    }
}
