using DALRMS;
using System.Data;
using DALCSCL;

namespace BLLRMS
{
    public class BLLSocial
    {
        private DALSocial objSocial = new DALSocial();

        public DataSet GetCompanyItems(int CompanyId)
        {

            return objSocial.GetCompanyItems(CompanyId);
        }

    
        public DataSet GetOrderDetailsToGrid(string OrderNumber, string CompanyId)
        {

            return objSocial.GetOrderDetailsToGrid(OrderNumber, CompanyId);
        }


        public int UpdateComments(int CommentId, string Comment, string Username)
        {

            return objSocial.SocialComments(CommentId, Comment, Username);
        }



    }
}
