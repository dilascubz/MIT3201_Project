using System.Data;
using System.Data.SqlClient;

namespace DALCSCL
{

    public class DALSignUp
    {
        private DALCommon objDALCommon = new DALCommon();

        public DataSet CheckUser(string MobileNo, string Email)
        {
            SqlParameter[] Parameters = new SqlParameter[2];


            Parameters[0] = new SqlParameter("@MobileNo", MobileNo);
            Parameters[1] = new SqlParameter("@Email", Email);

            return objDALCommon.ExecuteProcedure_select("SreCheckUser", Parameters);

        }

        public int SendVerificationCode(string UserName, int Code)
        {
            SqlParameter[] Parameters = new SqlParameter[2];

            Parameters[0] = new SqlParameter("@UserName", UserName);
            Parameters[1] = new SqlParameter("@Code", Code);

            return objDALCommon.ExecuteProcedure("SreSignupVerifyCodeSend", CommandType.StoredProcedure, Parameters);
        }


        public int RegisterNewUser(string NIC, string Username, string Password, int StakeHolderTypeId,
            string Fname, string LName, string MobileNo, string Email,
            string Address1, string Address2, string Address3, string GPSLat, string GPSLong, byte[] Image, string DOB,
            string BankBranch, string BankAcc, string BankName, string EducationalTypeId, string WorkAdd,
            string Designation, int WorkExperience, string EncUserName, int ASOAccId,
            string Gender,
            int Height, float Weight


            )
        {
            SqlParameter[] Parameters = new SqlParameter[28];

            Parameters[0] = new SqlParameter("@Email", Email);
            Parameters[1] = new SqlParameter("@NIC", NIC);

            Parameters[2] = new SqlParameter("@Password", Password);

            Parameters[3] = new SqlParameter("@StakeHolderMode", "User");
            Parameters[4] = new SqlParameter("@FitnessTypeId", StakeHolderTypeId);
            Parameters[5] = new SqlParameter("@FName", Fname);
            Parameters[6] = new SqlParameter("@LName", LName);
            Parameters[7] = new SqlParameter("@Username", Username);
            Parameters[8] = new SqlParameter("@MobileNo", MobileNo);

            Parameters[9] = new SqlParameter("@Address1", Address1);
            Parameters[10] = new SqlParameter("@Address2", Address2);
            Parameters[11] = new SqlParameter("@Address3", Address3);

            Parameters[12] = new SqlParameter("@GPSLat", GPSLat);
            Parameters[13] = new SqlParameter("@GPSLong", GPSLong);

            Parameters[14] = new SqlParameter("@BankBranch", BankBranch);
            Parameters[15] = new SqlParameter("@BankAcc", BankAcc);
            Parameters[16] = new SqlParameter("@Bank", BankName);

            Parameters[17] = new SqlParameter("@DOB", DOB);
            Parameters[18] = new SqlParameter("@EducationalTypeId", EducationalTypeId);
            Parameters[19] = new SqlParameter("@WorkAddress", WorkAdd);
            Parameters[20] = new SqlParameter("@Designation", Designation);
            Parameters[21] = new SqlParameter("@WorkExp", WorkExperience);

            Parameters[22] = new SqlParameter("@Image", Image);
            Parameters[23] = new SqlParameter("@Usexrname", EncUserName);
            Parameters[24] = new SqlParameter("@ASOACC", ASOAccId);
            Parameters[25] = new SqlParameter("@Gender", Gender);
            Parameters[26] = new SqlParameter("@Height", Height);

            Parameters[27] = new SqlParameter("@Weight", Weight);

            return objDALCommon.ExecuteProcedure("SinRegisterHealthUser", CommandType.StoredProcedure, Parameters);


        }

        public int RegisterNewCompany(string NIC, string Username, string Password, int StakeHolderTypeId,
          string Fname, string LName, string MobileNo, string Email,
          string Address1, string Address2, string Address3, string GPSLat, string GPSLong, byte[] Image, string DOB,
          string BankBranch, string BankAcc, string BankName, string EducationalTypeId, string WorkAdd, string OtherAddress, int WorkExperience, string EncUserName
         , int ASOAcc)
        {
            SqlParameter[] Parameters = new SqlParameter[25];

            Parameters[0] = new SqlParameter("@Email", Email);
            Parameters[1] = new SqlParameter("@NIC", NIC);

            Parameters[2] = new SqlParameter("@Password", Password);

            Parameters[3] = new SqlParameter("@StakeHolderMode", "User");
            Parameters[4] = new SqlParameter("@StakeholderTypeId", StakeHolderTypeId);
            Parameters[5] = new SqlParameter("@FxName", Fname);
            Parameters[6] = new SqlParameter("@LName", LName);
            Parameters[7] = new SqlParameter("@Username", Username);
            Parameters[8] = new SqlParameter("@MobileNo", MobileNo);

            Parameters[9] = new SqlParameter("@Address1", Address1);
            Parameters[10] = new SqlParameter("@Address2", Address2);
            Parameters[11] = new SqlParameter("@Address3", Address3);

            Parameters[12] = new SqlParameter("@GPSLat", GPSLat);
            Parameters[13] = new SqlParameter("@GPSLong", GPSLong);

            Parameters[14] = new SqlParameter("@BankBranch", BankBranch);
            Parameters[15] = new SqlParameter("@BankAcc", BankAcc);
            Parameters[16] = new SqlParameter("@Bank", BankName);

            Parameters[17] = new SqlParameter("@DOB", DOB);
            Parameters[18] = new SqlParameter("@EducationalTypeId", EducationalTypeId);
            Parameters[19] = new SqlParameter("@WorkAddress", WorkAdd);
            Parameters[20] = new SqlParameter("@OtherWork", OtherAddress);
            Parameters[21] = new SqlParameter("@WorkExp", WorkExperience);

            Parameters[22] = new SqlParameter("@Image", Image);
            Parameters[23] = new SqlParameter("@Usexrname", EncUserName);
            Parameters[24] = new SqlParameter("@ASOACC", ASOAcc);

            return objDALCommon.ExecuteProcedure("SinRegisterNewCompany", CommandType.StoredProcedure, Parameters);


        }



        public DataSet CheckEmailExists(string Name, string Type)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Name", Name);
            parameters[1] = new SqlParameter("@Type", Type);

            return objDALCommon.ExecuteProcedure_select("sreCheckNameExists", parameters);
        }

        public DataSet CheckrNICExists(string Code, string Type)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Code", Code);
            parameters[1] = new SqlParameter("@Type", Type);

            return objDALCommon.ExecuteProcedure_select("sreCheckCodeExists", parameters);
        }

        public DataSet CheckBusinessNoExists(string Code, string Type)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Code", Code);
            parameters[1] = new SqlParameter("@Type", Type);

            return objDALCommon.ExecuteProcedure_select("sreCheckCodeExists", parameters);
        }
    }


}
