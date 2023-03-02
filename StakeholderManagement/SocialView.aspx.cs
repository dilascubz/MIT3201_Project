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
    public partial class SocialView : System.Web.UI.Page
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

        BLLNotification BLLFeedback = new BLLNotification();

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

        protected void btnQuatation_Click(object sender, EventArgs e)
        {

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


        protected void gdPromotions_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            if (Session["UserId"] == null)
            {


                DevExpress.Web.ASPxWebControl.RedirectOnCallback("Login.aspx");
            }

            if (e.NewValues["Image"] == null)
            {
                Imgbytes = (byte[])e.NewValues["Image"];

                string resultFilePath = Server.MapPath("~/assets/images/no-image.gif");
                Bitmap bitmap = new Bitmap(resultFilePath);
                e.NewValues["Image"] = ImageToByte(bitmap);
            }
            e.NewValues["UserLoginId"] = Session["UserId"].ToString();

        }


        protected void gdPromotions_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            if (Session["UserId"] == null)
            {
                DevExpress.Web.ASPxWebControl.RedirectOnCallback("Login.aspx");
            }

            if (e.NewValues["PromoImage"] == null)
            {
                Imgbytes = (byte[])e.NewValues["PromoImage"];

                string resultFilePath = Server.MapPath("~/assets/images/no-image.gif");
                Bitmap bitmap = new Bitmap(resultFilePath);
                e.NewValues["PromoImage"] = ImageToByte(bitmap);
            }

            e.NewValues["UserLoginId"] = Session["UserId"].ToString();




        }
        public static byte[] ImageToByte(System.Drawing.Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }


        public void GetUserDatafromId(string UserId)
        {

        }


        protected void gdPromotions_CellEditorInitialize(object sender, BootstrapGridViewEditorEventArgs e)
        {


        }



        protected void gdPromotions_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

            //DateTime FromDate = Convert.ToDateTime((e.NewValues["FromDate"]).ToString());
            //DateTime Todate = Convert.ToDateTime((e.NewValues["ToDate"]).ToString());

            ////if (Session["UserId"] != null)
            //{
            //    DataSet dsCheck = default(DataSet);


            //    if (gdPromotions.IsNewRowEditing)
            //    {
            //        if (e.NewValues["Name"] != null)
            //        {
            //            dsCheck = productCategory.CheckPromotionsNameExists(e.NewValues["Name"].ToString().Trim(), "Promotions");

            //            if (dsCheck.Tables[0].Rows.Count != 0)
            //            {
            //                AddError(e.Errors, gdPromotions.Columns["Name"], "* Name already exists");
            //            }
            //        }

            //        if (e.NewValues["Code"] != null)
            //        {
            //            dsCheck = productCategory.CheckPromotionCodeExists(e.NewValues["Code"].ToString().Trim(), "Promotions");

            //            if (dsCheck.Tables[0].Rows.Count != 0)
            //            {
            //                AddError(e.Errors, gdPromotions.Columns["Code"], "* Code already exists");
            //            }
            //        }
            //    }

            //    else
            //    {
            //        if (e.NewValues["Name"] != null)
            //        {
            //            if (e.NewValues["Name"].ToString().ToLower() != e.OldValues["Name"].ToString().ToLower())
            //            {
            //                dsCheck = productCategory.CheckPromotionsNameExists(e.NewValues["Name"].ToString().Trim(), "Promotions");

            //                if (dsCheck.Tables[0].Rows.Count != 0)
            //                {
            //                    if (e.NewValues["Name"].ToString().Trim() != e.OldValues["Name"].ToString().Trim())
            //                    {
            //                        AddError(e.Errors, gdPromotions.Columns["Name"], "* Name already exists");
            //                    }
            //                }
            //            }
            //        }

            //        if (e.NewValues["Code"] != null)
            //        {
            //            if (e.NewValues["Code"].ToString().ToLower() != e.OldValues["Code"].ToString().ToLower())
            //            {
            //                dsCheck = productCategory.CheckPromotionCodeExists(e.NewValues["Code"].ToString().Trim(), "Promotions");

            //                if (dsCheck.Tables[0].Rows.Count != 0)
            //                {
            //                    if (e.NewValues["Code"].ToString().Trim() != e.OldValues["Code"].ToString().Trim())
            //                    {
            //                        AddError(e.Errors, gdPromotions.Columns["Code"], "* Code already exists");
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    DevExpress.Web.ASPxWebControl.RedirectOnCallback("Login.aspx");
            //}
        }

        private void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn gridViewColumn, string errorText)
        {
            if (errors.ContainsKey(gridViewColumn))
            {
                return;
            }
            errors[gridViewColumn] = errorText;
        }

     
        protected void gdPromotions_CommandButtonInitialize(object sender, BootstrapGridViewCommandButtonEventArgs e)
        {

        }

        protected void gdPromotions_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            var clickedRowIndex = e.VisibleIndex;
            var keyValue = grid.GetRowValues(clickedRowIndex, grid.KeyFieldName);
            Session["SocialId"] = keyValue.ToString();
            // SendMail(Convert.ToInt32(keyValue));
            if (Page.IsCallback)
                ASPxWebControl.RedirectOnCallback("~/SocialLife.aspx");
        }

        protected void gdCommentDetails_BeforePerformDataSelect(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                if (Page.IsCallback)
                    DevExpress.Web.ASPxWebControl.RedirectOnCallback("~/Login.aspx");
                else
                    Response.Redirect("~/Login.aspx", true);
            }

            ASPxGridView detail2 = sender as ASPxGridView;
            //GridViewDetailRowTemplateContainer c1 = detail2.NamingContainer as GridViewDetailRowTemplateContainer;
            //ASPxGridView detail1 = c1.Grid;
            var MasterKey = detail2.GetMasterRowKeyValue();
            Session["CommentId"]= detail2.GetMasterRowKeyValue();

            // Session["OrderRequestId"] = sender as ASPxGridView.GetMasterRowKeyValue;
        }
    }
}