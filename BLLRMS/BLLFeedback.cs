using DALRMS;
using System.Data;
using DALCSCL;

namespace BLLRMS
{
    public class BLLFeedback
    {
        private DALFeedback objDALFeedback = new DALFeedback();

        public int AddFeedback(string Name, string Feedback, string Email, string Telephone, string CreatedBy)
        {
            return objDALFeedback.AddFeedback(Name, Feedback, Email, Telephone, CreatedBy);
        }

        public DataSet CheckFeedbackExist(string Name, string Feedback, string Email, string Telephone, string CreatedBy)
        {
            return objDALFeedback.CheckFeedbackExist(Name, Feedback, Email, Telephone, CreatedBy);
        }


        public int  AddChat(string Name, string Feedback,string UserName)
        {
            return objDALFeedback.InsertChat(Name, Feedback,UserName);
        }

        public DataSet  GetChat(string Name, int Feedback)
        {
            return objDALFeedback.GetChatHistory(Name, Feedback);
        }


        public DataSet GetExercises(string Name)
        {
            return objDALFeedback.GetExercises(Name);
        }

        public DataSet GetExercisesType(int ExerciseTypeId, int ExerciseModeId)
        {
            return objDALFeedback.GetExercisesType(ExerciseTypeId, ExerciseModeId);
        }

    }
}
