using System.Data;
using System.Data.SqlClient;

namespace DALCSCL
{
    public class DALNotification
    {
        private DALCommon objDALCommon = new DALCommon();

        public DataSet GetAvailabilityCount()
        {
            return objDALCommon.ExecuteProcedure_select("sreGetAvailabilityCount");
        }

        public DataSet GetVisitDetails(int StakeholderId, string fromdate, string ToDate)
        {
            SqlParameter[] Parameters = new SqlParameter[3];


            Parameters[0] = new SqlParameter("@fromdate", fromdate);

            Parameters[1] = new SqlParameter("@todate", ToDate);
            Parameters[2] = new SqlParameter("@StakeHolderId", StakeholderId);
            return objDALCommon.ExecuteProcedure_select("sgetViewVisits", Parameters);
        }

        public DataSet GetVisitt(int Usercategory, int ASO)
        {
            SqlParameter[] Parameters = new SqlParameter[2];


            Parameters[0] = new SqlParameter("@Usercategory", Usercategory);

            Parameters[1] = new SqlParameter("@ASO", ASO);
            return objDALCommon.ExecuteProcedure_select("sreGetUsers", Parameters);
        }


        public DataSet GetVisitRecords(int Usercategory, int ASO, int StakeholderType)
        {
            SqlParameter[] Parameters = new SqlParameter[3];

            Parameters[0] = new SqlParameter("@Usercategory", Usercategory);
            Parameters[1] = new SqlParameter("@ASO", ASO);

            Parameters[2] = new SqlParameter("@stakeholderType", StakeholderType);

            return objDALCommon.ExecuteProcedure_select("sreGetVisitUsers", Parameters);
        }



        public DataSet GetAllASO(int Usercategory, int ASO)
        {
            SqlParameter[] Parameters = new SqlParameter[2];


            Parameters[0] = new SqlParameter("@Usercategory", Usercategory);

            Parameters[1] = new SqlParameter("@ASO", ASO);

            return objDALCommon.ExecuteProcedure_select("sreGetASOUsersID", Parameters);
        }

        public int LeaderBoardDetails(string Username, string subject, string description, string name,  byte[] Image,int RepAmount)
        {
            SqlParameter[] Parameters = new SqlParameter[6];

            Parameters[0] = new SqlParameter("@Description", description);
            Parameters[1] = new SqlParameter("@Subject", subject);
            Parameters[2] = new SqlParameter("@Name", name);
          
            Parameters[3] = new SqlParameter("@UserLoginId", Username);
            Parameters[4] = new SqlParameter("@ImgUser", Image);
            Parameters[5] = new SqlParameter("@CountTime", RepAmount);
            return objDALCommon.ExecuteProcedure("sinLeaderBoard", CommandType.StoredProcedure, Parameters);
        }


    }
}
