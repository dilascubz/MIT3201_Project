using DALRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALCSCL;

namespace BLLRMS
{
    public class BLLUserCategory
    {
        private DALUserCategory objDALUserCategory = new DALUserCategory();
        private UserConfig objUserConfig = new UserConfig();

        public int DeleteCategory(string strCategoryName)
        {
            string strEncCategoryName = "";
            strEncCategoryName = objUserConfig.EncryptStringF(strCategoryName);
            return objDALUserCategory.DeleteCategory(strEncCategoryName);
        }

        public DataSet GetUserCategoryAccessLevelByCategoryName(string strUserCategoryName)
        {
            string strEncUserCategory = "";
            strEncUserCategory = objUserConfig.EncryptStringF(strUserCategoryName);
            return objDALUserCategory.GetUserCategoryAccessLevelByCategoryName(strEncUserCategory);
        }

        public DataSet GetUserCategoryAccessLevelNotSelectedByCategoryName(string strUserCategoryName)
        {
            string strEncUserCategory = "";
            strEncUserCategory = objUserConfig.EncryptStringF(strUserCategoryName);
            return objDALUserCategory.GetUserCategoryAccessLevelNotSelectedByCategoryName(strEncUserCategory);
        }

        public DataSet SelectCategoryAccess(string CategoryName)
        {
            return objDALUserCategory.SelectCategoryAccess(CategoryName);
        }

        public int DeleteCategoryAccess(string CategoryName)
        {
            try
            {
                return objDALUserCategory.DeleteCategoryAccess(CategoryName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int DeleteCategoryAccessLevels(string CategoryName)
        {
            try
            {
                return objDALUserCategory.DeleteCategoryAccessLevels(CategoryName);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Cannot be deleted");
            }
        }

        public int AddCategoryAccessLevels(string CategoryName, string AccessLevel, bool AddCommand, bool EditCommand, bool DeleteCommand, string UserName)
        {
            string strEncUserCategory = "";
            string strEncAccessLevel = "";

            strEncUserCategory = objUserConfig.EncryptStringF(CategoryName);
            strEncAccessLevel = objUserConfig.EncryptStringF(AccessLevel);
            return objDALUserCategory.AddCategoryAccessLevels(strEncUserCategory, strEncAccessLevel, AddCommand, EditCommand, DeleteCommand, UserName);
        }

        public int AddPageGroupAccessLevels(string CategoryName, string AccessLevel, string UserName)
        {
            int functionReturnValue = 0;
            string strEncCategoryName = "";
            string strEncAccessLevel = "";

            strEncCategoryName = objUserConfig.EncryptStringF(CategoryName);
            strEncAccessLevel = objUserConfig.EncryptStringF(AccessLevel);
            if (string.IsNullOrEmpty(CategoryName.Trim()))
            {
                return functionReturnValue;
            }

            return objDALUserCategory.AddPageGroupAccessLevels(strEncCategoryName, strEncAccessLevel, UserName);
        }

        public DataSet GetAccessLevelsByCategoryName(string strUserCategoryName)
        {
            //string strEncUserCategory = "";
            //strEncUserCategory = objUserConfig.EncryptStringF(strUserCategoryName);
            //return objDALUserCategory.GetAccessLevelsByCategoryName(strEncUserCategory);
            return objDALUserCategory.GetAccessLevelsByCategoryName(strUserCategoryName);
        }


        public string GetQuery(string Query, string Column)
        {
            return objDALUserCategory.GetQuery(Query, Column);

        }

        public bool ExcuteQuery(string Query)
        {
            return objDALUserCategory.ExecuteQuery(Query);

        }
    }
}
