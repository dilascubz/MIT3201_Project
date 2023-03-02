using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using DevExpress.XtraPrinting;

using BLLRMS;
using DevExpress.Web;
using DevExpress.Web.Bootstrap;
using System.Data;
using System.Net.Mail;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text.RegularExpressions;

namespace StakeholderManagement
{
    public partial class LeaderBoardViewer : System.Web.UI.Page
    {

        BLLNotification BLLFeedback = new BLLNotification();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                DevExpress.Web.ASPxWebControl.RedirectOnCallback("Login.aspx");
            }
        }

        protected void btnQuatation_Click(object sender, EventArgs e)
        {
          
        }



        public void GetUserDatafromId(string UserId)
        {

        }


     


    }
}