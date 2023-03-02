using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLLRMS;

namespace StakeholderManagement
{

    public partial class _Default : Page
    {
        private BLLSecurity objBLLSecurity = new BLLSecurity();


        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserId"] == null)
            //{
            //    if (Page.IsCallback)
            //    {
            //        DevExpress.Web.ASPxWebControl.RedirectOnCallback("~/Login.aspx");
            //    }

            //    else
            //    {
            //        Response.Redirect("Login.aspx", true);
            //    }
            //}
        }



       
    }
}