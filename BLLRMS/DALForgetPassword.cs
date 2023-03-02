using System.Data;
using DALMPRS;



namespace BLLMPRS
{
    public partial class BLLUserManagement
    {
        private DALUserAddDetails objDALUserManagement;

        public BLLUserManagement()
        {
            objDALUserManagement = new DALUserAddDetails();
        }

        public DataSet GetAllUsers()
        {
            return objDALUserManagement.SelectAllUsers();
        }

        public int InsertUser(string strUserName, string strUserId)
        {
            if (objDALUserManagement.CheckExistingUser(strUserId) == false)
            {
                return objDALUserManagement.InsertUser(strUserName, strUserId);
            }

            return default;
        }

        public DataSet GetAllUsersWithGroup()
        {
            return objDALUserManagement.SelectAllUsersWithGroup();
        }

        public DataSet GetAllUsersGroup()
        {
            return objDALUserManagement.SelectAllGroup();
        }

        public int UpdateUsersGroup(string strUserID, string strGroupName)
        {
            return objDALUserManagement.UpdateUserGroup(strUserID, strGroupName);
        }

        public DataSet GetUserDetailsByUserID(string strUserID)
        {
            return objDALUserManagement.GetUserDetailsByUserID(strUserID);
        }

        public DataSet GetUserGroupAccessByGroup(string strGroup)
        {
            return objDALUserManagement.GetUserGroupAccessByGroup(strGroup);
        }
    }
}