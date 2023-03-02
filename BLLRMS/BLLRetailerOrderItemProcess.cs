using DALRMS;
using System.Collections.Generic;
using System.Data;


using System;

using System.Drawing;

using System.IO;
using System.Linq;
using System.Web;
using DALCSCL;

using SD = System.Drawing;

namespace BLLRMS
{
    public class BLLRetailerOrderItemProcess
    {
        DALRetailerOrderItemProcess objDALRetailerOrderItemProcess = new DALRetailerOrderItemProcess();

        public DataSet GetItemDetails(int Id)
        {
            return objDALRetailerOrderItemProcess.GetItemDetails(Id);
        }

        public DataSet CheckDeliverToCity(int RetailerId, int companyId)
        {
            return objDALRetailerOrderItemProcess.CheckDeliverToCity(RetailerId, companyId);
        }

        public DataSet CheckMinValueByCompany(int CompanyId)
        {
            return objDALRetailerOrderItemProcess.CheckMinValueByCompany(CompanyId);
        }



    }


    public class Messages
    {

        public string UserName { get; set; }

        public string Message { get; set; }

        public string Time { get; set; }

        public string UserImage { get; set; }

    }
    public class Users
    {
        public string ConnectionId { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public string LoginTime { get; set; }
    }
}
