using DALRMS;
using System.Data;
using DALCSCL;

namespace BLLRMS
{
    public class BLLSignUp
    {
        private DALSignUp objDALSignUp = new DALSignUp();
        private UserConfig objUserConfig = new UserConfig();


        public int SendVerificationCode(string UserName, int Code)
        {
            return objDALSignUp.SendVerificationCode(UserName, Code);
        }
        public DataSet CheckUser(string NIC, string Email)
        {
            return objDALSignUp.CheckUser(NIC, Email);
        }


        public int RegisterNewUser(string Email, string NIC, string Fname, string Lname, string Password, int StakeHolderTypeId, string UserName,
         string MobileNo, string Address1, string Address2, string Address3, string GPSLat, string GPSLong, string BankBranch, string BankAcc, string BankName,
         byte[] Image, string DOB, string EducationalTypeId, string WorkAddr, string OtherWork, int WorkExperinece, int ASOAccId,
            string Gender, int Height, float Weight)
        {

            return objDALSignUp.RegisterNewUser(Email, Email, Password, StakeHolderTypeId, Fname, Lname, MobileNo, Email, Address1, Address2, Address3,
                GPSLat, GPSLong, Image,
                DOB, BankBranch, BankAcc, BankName, EducationalTypeId, WorkAddr, OtherWork, WorkExperinece, objUserConfig.EncryptStringF(Email), ASOAccId,
                Gender, Height, Weight
                );
        }


        public int RegisterNewCompany(string Email, string NIC, string Fname, string Lname, string Password, int StakeHolderTypeId, string UserName,
        string MobileNo, string Address1, string Address2, string Address3, string GPSLat, string GPSLong, string BankBranch, string BankAcc, string BankName,
        byte[] Image, string DOB, string EducationalTypeId, string WorkAddr, string OtherWork, int WorkExperinece, int ASOAccId)
        {

            return objDALSignUp.RegisterNewCompany(NIC, NIC, Password, StakeHolderTypeId, Fname, Lname, MobileNo, Email, Address1, Address2, Address3, GPSLat, GPSLong, Image,
                DOB, BankBranch, BankAcc, BankName, EducationalTypeId, WorkAddr, OtherWork, WorkExperinece, objUserConfig.EncryptStringF(NIC), ASOAccId);
        }


        public DataSet CheckEmailNameExists(string Name, string Type)
        {
            return objDALSignUp.CheckEmailExists(Name, Type);
        }

        public DataSet CheckNICExists(string Code, string Type)
        {
            return objDALSignUp.CheckrNICExists(Code, Type);
        }

        public DataSet CheckBusinessNoExists(string Code, string Type)
        {
            return objDALSignUp.CheckBusinessNoExists(Code, Type);
        }

    }
}


