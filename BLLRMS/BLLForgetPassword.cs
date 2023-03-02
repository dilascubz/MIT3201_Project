using DALRMS;
using System.Data;
using DALCSCL;

namespace BLLRMS
{
    public class BLLForgetPassword
    {
        private DALForgetPassword objDALForgetPassword = new DALForgetPassword();

        public int SendVerificationCode(string UserName, int Code)
        {
            return objDALForgetPassword.SendVerificationCode(UserName,Code);
        }
        public DataSet CheckUser(string UserName)
        {
            return objDALForgetPassword.CheckUser(UserName);
        }

    }
}
