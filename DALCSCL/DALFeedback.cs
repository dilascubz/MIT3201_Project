using System.Data;
using System.Data.SqlClient;

namespace DALCSCL
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


        public int InsertChat(string Name, string Message, string UserId)
        {
            SqlParameter[] parameters = new SqlParameter[3];

            parameters[0] = new SqlParameter("@UserName", UserId);
            parameters[1] = new SqlParameter("@Name", Name);
            parameters[2] = new SqlParameter("@Feedback", Message);



            return objDALCommon.ExecuteProcedure("sinChatHistory", CommandType.StoredProcedure, parameters);
        }

        public DataSet GetChatHistory(string Name, int Feedback)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@UserId", Name);
            parameters[1] = new SqlParameter("@UserCategoryId", Feedback);


            return objDALCommon.ExecuteProcedure_select("sregetChatHistory", parameters);
        }

        public DataSet GetExercises(string Name)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@Name", Name);

            return objDALCommon.ExecuteProcedure_select("sgetExerciseTypes", parameters);
        }



        public DataSet GetExercisesType(int ExerciseType, int ExerciseMode)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@ExerciseType", ExerciseType);
            parameters[1] = new SqlParameter("@ExerciseMode", ExerciseMode);

            return objDALCommon.ExecuteProcedure_select("sgetExerciseTypesWise", parameters);
        }
    }
}
