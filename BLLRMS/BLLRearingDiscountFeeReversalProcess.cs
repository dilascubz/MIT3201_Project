using System.Data;
using System.Data.SqlClient;
using DALMPRS;

namespace BLLMPRS
{
    public class DALFeedback
    {
        DALCommon objDALCommon = new DALCommon();

        public int AddFeedback(string Name, string Feedback, string Email, string Telephone, string CreatedBy)
        {
            SqlParameter[] parameters = new SqlParameter[5];

            parameters[0] = new SqlParameter("@Name", Name);
            parameters[1] = new SqlParameter("@Feedback", Feedback);
            parameters[2] = new SqlParameter("@Email", Email);
            parameters[3] = new SqlParameter("@Telephone", Telephone);
            parameters[4] = new SqlParameter("@CreatedBy", CreatedBy);

            return objDALCommon.ExecuteProcedure("sinFeedback", CommandType.StoredProcedure, parameters);
        }

        public DataSet CheckFeedbackExist(string Name, string Feedback, string Email, string Telephone, string CreatedBy)
        {
            SqlParameter[] parameters = new SqlParameter[5];

            parameters[0] = new SqlParameter("@Name", Name);
            parameters[1] = new SqlParameter("@Feedback", Feedback);
            parameters[2] = new SqlParameter("@Email", Email);
            parameters[3] = new SqlParameter("@Telephone", Telephone);
            parameters[4] = new SqlParameter("@CreatedBy", CreatedBy);

            return objDALCommon.ExecuteProcedure_select("sreGetFeedbackExist", parameters);
        }
    }
}
