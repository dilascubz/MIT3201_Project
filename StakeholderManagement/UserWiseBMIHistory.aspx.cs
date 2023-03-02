using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using DevExpress.Export;
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
    public partial class UserWiseBMIHistory : System.Web.UI.Page
    {
        byte[] Imgbytes = null;
        // public string UserImage = "/images/DP/dummy.png";

        public string UserImage = "/assets2/images/hero/hero-1.jpg";


        // public string UserImage = "/images/DP/RangaRanga.jpg";

        public string UserId = "";
        string USerName = "admin";
        BLLSecurity bLLSecurity = new BLLSecurity();
        BLLUserCategory bLLUserCategory = new BLLUserCategory();
        BLLAddProductCategory productCategory = new BLLAddProductCategory();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserId"] == null)
            {
                if (Page.IsCallback)
                {
                    DevExpress.Web.ASPxWebControl.RedirectOnCallback("~/Login.aspx");
                }

                else
                {
                    Response.Redirect("Login.aspx", true);
                }


            }
            else
            {
                USerName = Session["UserName"].ToString();
                UserId = Session["UserId"].ToString();



                GetUserImage(USerName);

            }
        }
        protected void gdPromotions_CommandButtonInitialize(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewCommandButtonEventArgs e)
        {

        }


        public static byte[] ImageToByte(System.Drawing.Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }


        protected void gdPromotions_CellEditorInitialize(object sender, BootstrapGridViewEditorEventArgs e)
        {


        }




        private void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn gridViewColumn, string errorText)
        {
            if (errors.ContainsKey(gridViewColumn))
            {
                return;
            }
            errors[gridViewColumn] = errorText;
        }





        public void GetUserImage(string UserNme)
        {
            if (USerName != null)
            {
                string query = "select UserImageString from HealthUser where UserId='" + UserId + "'";

                string ImageName = bLLUserCategory.GetQuery(query, "UserImageString");
                if (ImageName != "")
                    UserImage = "images/DP/" + ImageName;

            }
        }










    }
}