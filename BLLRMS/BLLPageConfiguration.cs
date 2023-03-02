using DALRMS;
using System.Data;
using DALCSCL;

namespace BLLRMS
{
    public class BLLPageConfiguration
    {
        DALPageConfiguration objDALPageConfig = new DALPageConfiguration();
        UserConfig objUserConfig = new UserConfig();

        //---Get System Users---
        public DataSet GetAllBindUserCategory()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(FillUserCategory());
            return ds;
        }

        public DataTable FillUserCategory()
        {
            DataSet dsCategory = null;

            string strDecGroup = "";
            string keyid;
            dsCategory = new DataSet();
            dsCategory = objDALPageConfig.GetAllUserCategory();

            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Id", typeof(int));
            for (int I = 0; I <= dsCategory.Tables[0].Rows.Count - 1; I++)
            {
                strDecGroup = objUserConfig.DecryptStringF(dsCategory.Tables[0].Rows[I]["Name"].ToString());
                keyid = dsCategory.Tables[0].Rows[I]["Id"].ToString();

                dt.Rows.Add(strDecGroup, keyid);
            }

            return dt;
        }

        public DataSet GetAllUserCategory()
        {
            return objDALPageConfig.GetAllUserCategory();
        }

        public DataSet GetUserCategoryDecryptString(int UserCategoryId)
        {
            return objDALPageConfig.GetUserCategoryDecryptString(UserCategoryId);
        }

        public string GetDecryptString(string UserCategoryName)
        {
            string UserCategoryNameDecrypt = objUserConfig.DecryptStringF(UserCategoryName);
            return UserCategoryNameDecrypt;
        }

        public int AddUserCategory(string CategoryName, string UserName)
        {
            string strEncCategoryName = "";
            strEncCategoryName = objUserConfig.EncryptStringF(CategoryName);
            return objDALPageConfig.AddUserCategory(strEncCategoryName, UserName);
        }





    }
}
