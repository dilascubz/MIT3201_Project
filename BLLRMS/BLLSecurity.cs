using DALRMS;
using Microsoft.VisualBasic;
using System;
using System.Data;
using DALCSCL;
using DALCSCL;

namespace BLLRMS
{
    public class BLLSecurity
    {
        private DALSecurity objDALSecurity = new DALSecurity();
        private UserConfig objUserConfig = new UserConfig();

        public DataSet CheckUserLoginIdExist(string UserLoginId)
        {
            //string strEncUserId = "";
            //strEncUserId = objUserConfig.EncryptStringF(UserLoginId);

            return objDALSecurity.CheckUserLoginIdExist(UserLoginId);
        }

        public int AddSecurityDetailTemp(string UserLoginId, string Password, string Type, bool ADflg, string UserCategoryNameEnc, bool Active, bool Deleted, string strUserName)
        {
            string strEncUserLoginId = "";
            string strEncType = "";
            string strEncPassword = "";

            strEncUserLoginId = objUserConfig.EncryptStringF(UserLoginId);
            strEncType = objUserConfig.EncryptStringF(Type);
            strEncPassword = objUserConfig.EncryptStringF(Password);

            if (Password == "")
            {
                return objDALSecurity.AddSecurityDetailTemp(strEncUserLoginId, Password, strEncType, ADflg, UserCategoryNameEnc, Active, Deleted, strUserName);
            }
            else
            {
                return objDALSecurity.AddSecurityDetailTemp(strEncUserLoginId, strEncPassword, strEncType, ADflg, UserCategoryNameEnc, Active, Deleted, strUserName);
            }
        }

        public DataSet GetSecurityDetailByUserLoginId(string UserId)
        {
            string strEncUserId = "";
            strEncUserId = objUserConfig.EncryptStringF(Strings.LCase(UserId));

            return objDALSecurity.GetSecurityDetailByUserLoginId(strEncUserId);
        }

        public int UpdateSysUser(int Id, string Name, string Address, string ContactNo, string Email, bool ADUser, int DesignationId, int DivisionId, int UserCategoryId, string UserLoginId, bool Active, string strUserName, string strEncUserName, string strDecUserName, string strEncPassword, string strDecUserCategory)
        {
            string strEncUserId = "";
            strEncUserId = objUserConfig.EncryptStringF(strEncUserName);

            string strecPassword = "";
            if (strEncPassword != null)
            {
                strecPassword = objUserConfig.EncryptStringF(strEncPassword);
            }

            return objDALSecurity.UpdateSysUser(Id, Name, Address, ContactNo, Email, ADUser, DesignationId, DivisionId, UserCategoryId, UserLoginId, Active, strUserName, strEncUserId, strEncUserName, strecPassword, strDecUserCategory);
        }

        public DataSet GetUserbyUserLoginId(string UserLoginId)
        {
            string strEncUserId = objUserConfig.EncryptStringF(UserLoginId);

            return objDALSecurity.GetUserbyUserLoginId(strEncUserId);
        }

        public DataSet CheckUserLoginIdPwd(string UserLoginId, string Password)
        {
            string strEncUserLoginId = "";
            strEncUserLoginId = objUserConfig.EncryptStringF(UserLoginId);
            string strEncPassword = "";
            strEncPassword = objUserConfig.EncryptStringF(Password);

            return objDALSecurity.CheckUserLoginIdPwd(strEncUserLoginId, strEncPassword);
        }

        public DataSet GetNamebyUserLoginId(string UserLoginId, int userCategoryId)
        {
            return objDALSecurity.GetNamebyUserLoginId(UserLoginId, userCategoryId);
        }


        public DataSet GetStakeHolderTypeId(string UserName)
        {
            return objDALSecurity.GetUserStakeHOlderType(UserName);
        }

        public DataSet GetASOUser(string Username)
        {
            return objDALSecurity.GetASOUserAcc(Username);
        }


        public DataSet GetASOUserAccId(int ASOID)
        {
            return objDALSecurity.GetASOAccId(ASOID);
        }
        public DataSet GetRetailerIDbyUserLoginId(string UserLoginId)
        {
            return objDALSecurity.GetRetailerIDbyUserLoginId(UserLoginId);
        }



        public string GetUserCategory(string username)
        {
            string strEncUserId = "";
            strEncUserId = objUserConfig.EncryptStringF(username);
            DataSet ds = objDALSecurity.GetUserCategory(strEncUserId);

            String UserCategoryName = "";
            if (ds.Tables[0].Rows.Count > 0)
            { UserCategoryName = ds.Tables[0].Rows[0][0].ToString(); }

            return objUserConfig.DecryptStringF(UserCategoryName);
        }

        public DataSet CheckUserHaveDivision(string UserLoginId)
        {
            return objDALSecurity.CheckUserHaveDivision(UserLoginId);
        }

        public int AddUserLoginHistory(string UserLoginId, string LoginDateTime, string IPAddress, string GPSLat, string GPSLong)
        {
            return objDALSecurity.AddUserLoginHistory(UserLoginId, LoginDateTime, IPAddress, GPSLat, GPSLong);
        }

        public DataSet GetCompanyId(string UserLoginId)
        {
            return objDALSecurity.GetCompanyId(UserLoginId);
        }

        public int InsertImage(byte[] NImage)
        {
            return objDALSecurity.UpdateImages(NImage);
        }

        public DataSet GetMenuByUserCategoryAccess(int UserCategoryId)
        {
            return objDALSecurity.GetMenuByUserCategoryAccess(UserCategoryId);
        }
    }
}
