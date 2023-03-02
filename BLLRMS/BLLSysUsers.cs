using DALRMS;
using System.Data;
using DALCSCL;


namespace BLLRMS
{
    public class BLLSysUsers
    {
        private DALSysUsers objDALSysUsers = new DALSysUsers();
        private UserConfig objUserConfig = new UserConfig();
        private BLLSecurity objBLLSecurity = new BLLSecurity();

        //---Get Designation---
        public DataSet GetActiveDesignations()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(FillDesignation());
            return ds;
        }

        public DataTable FillDesignation()
        {
            DataSet dsDesignation = null;

            string strDesignation = "";
            string keyid;
            dsDesignation = new DataSet();
            dsDesignation = objDALSysUsers.GetActiveDesignations();

            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Id", typeof(int));

            for (int I = 0; I <= dsDesignation.Tables[0].Rows.Count - 1; I++)
            {
                strDesignation = dsDesignation.Tables[0].Rows[I]["Name"].ToString();
                keyid = dsDesignation.Tables[0].Rows[I]["Id"].ToString();

                dt.Rows.Add(strDesignation, keyid);
            }

            return dt;
        }

        //---Get Divisions---
        public DataSet GetActiveDivisions()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(FillDivisions());
            return ds;
        }

        public DataTable FillDivisions()
        {
            DataSet dsDivision = null;

            string strDivision = "";
            string keyid;
            dsDivision = new DataSet();
            dsDivision = objDALSysUsers.GetActiveDivisions();

            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Id", typeof(int));

            for (int I = 0; I <= dsDivision.Tables[0].Rows.Count - 1; I++)
            {
                strDivision = dsDivision.Tables[0].Rows[I]["Name"].ToString();
                keyid = dsDivision.Tables[0].Rows[I]["Id"].ToString();

                dt.Rows.Add(strDivision, keyid);
            }

            return dt;
        }

        //---Get System Users---
        public DataSet GetSysUsers()
        {
            return objDALSysUsers.GetSysUsers();
        }

        public int AddSysUser(string Name, string Address, string ContactNo, string Email, bool ADUser, int DesignationId, int DivisionId, int UserCategoryId, string UserLoginId, bool Active, string strUserName)
        {
            return objDALSysUsers.AddSysUser(Name, Address, ContactNo, Email, ADUser, DesignationId, DivisionId, UserCategoryId, UserLoginId, Active, strUserName);
        }

        public string GetUserSecurityUserID(string userId)
        {
            string struserId = "";
            struserId = objUserConfig.EncryptStringF(userId);
            return struserId;
        }

        public int DeleteSysUser(int Id)
        {
            return objDALSysUsers.DeleteSysUser(Id);
        }

        public string DeleteSysUserSecurity(string UserLoginId)
        {
            return objDALSysUsers.DeleteSysUserSecurity(UserLoginId);
        }

        public DataSet GetPreviousUserLoginId()
        {
            return objDALSysUsers.GetPreviousUserLoginId();
        }

        public DataSet GetExistingADUserList()
        {
            return objDALSysUsers.GetExistingADUserList();
        }

        public DataSet GetUserId(string UserLoginId)
        {
            return objDALSysUsers.GetUserId(UserLoginId);
        }

        public int AddUserConfig(int UserId)
        {
            return objDALSysUsers.AddUserConfig(UserId);
        }

        public DataSet GetDesignationId(string DesignationName)
        {
            return objDALSysUsers.GetDesignationId(DesignationName);
        }

        public DataSet GetDivisionId(string DivisionName)
        {
            return objDALSysUsers.GetDivisionId(DivisionName);
        }

        public DataSet GetUserCategoryId(string UserCategoryName)
        {
            string enUserCategoryName = "";
            enUserCategoryName = objUserConfig.EncryptStringF(UserCategoryName);
            return objDALSysUsers.GetUserCategoryId(enUserCategoryName);
        }


       
    }
}
