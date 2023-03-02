using DALRMS;
using System.Data;
using DALCSCL;

namespace BLLRMS
{
    public class BLLChangePassword
    {
        private DALChangePassword objDALChangePassword = new DALChangePassword();

        public int ChangePassword(string UserName, string Password)
        {
            return objDALChangePassword.ChangePassword(UserName, Password);
        }

    }
}
