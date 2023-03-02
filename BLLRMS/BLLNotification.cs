using DALRMS;
using System.Data;
using DALCSCL;

namespace BLLRMS
{
    public class BLLNotification
    {
        private DALNotification objDALNotification = new DALNotification();

        public DataSet GetAvailabilityCount()
        {
            return objDALNotification.GetAvailabilityCount();
        }

    
        public DataSet GetVisitDetails( string fromdate, string todate,int StakeholderId)
        {
            return objDALNotification.GetVisitDetails(StakeholderId, fromdate, todate);
        }

        public DataSet GetVisitRecords(int Uategory, int ASO,int StakeHolderTypeId)
        {
            return objDALNotification.GetVisitRecords(Uategory, ASO,StakeHolderTypeId);
        }

        public DataSet GetAllActiveASO(int Uategory, int ASO)
        {
            return objDALNotification.GetAllASO(Uategory, ASO);
        }


        public int LeaderBoardDetails(string username,string subject,string Description,string Name, byte[] image,int RepAmount)
        {
            return objDALNotification.LeaderBoardDetails(username, subject,Description, Name, image, RepAmount);
        }
    }
}
