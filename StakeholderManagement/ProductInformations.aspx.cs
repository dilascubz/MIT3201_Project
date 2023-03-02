using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLLRMS;

using DevExpress.Web.Bootstrap;
using System.Data;
using System.Net.Mail;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text.RegularExpressions;

namespace StakeholderManagement
{
    public partial class ProductInformations : System.Web.UI.Page
    {

        byte[] Imgbytes = null;
        public string UserImage = "/images/DP/dummy.png";

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

        protected void gdProductsInformation_CellEditorInitialize(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewEditorEventArgs e)
        {

        }

        protected void gdProductsInformation_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            DateTime FromDate = Convert.ToDateTime((e.NewValues["FromDate"]).ToString());
            DateTime Todate = Convert.ToDateTime((e.NewValues["ToDate"]).ToString());

            if (Session["UserId"] != null)
            {
                DataSet dsCheck = default(DataSet);


                if (gdProductsInformation.IsNewRowEditing)
                {
                    if (e.NewValues["Name"] != null)
                    {
                        dsCheck = productCategory.CheckPromotionsNameExists(e.NewValues["Name"].ToString().Trim(), "Promotions");

                        if (dsCheck.Tables[0].Rows.Count != 0)
                        {
                            AddError(e.Errors, gdProductsInformation.Columns["Name"], "* Name already exists");
                        }
                    }

                    if (e.NewValues["Code"] != null)
                    {
                        dsCheck = productCategory.CheckPromotionCodeExists(e.NewValues["Code"].ToString().Trim(), "Promotions");

                        if (dsCheck.Tables[0].Rows.Count != 0)
                        {
                            AddError(e.Errors, gdProductsInformation.Columns["Code"], "* Code already exists");
                        }
                    }
                }

                else
                {
                    if (e.NewValues["Name"] != null)
                    {
                        if (e.NewValues["Name"].ToString().ToLower() != e.OldValues["Name"].ToString().ToLower())
                        {
                            dsCheck = productCategory.CheckPromotionsNameExists(e.NewValues["Name"].ToString().Trim(), "Promotions");

                            if (dsCheck.Tables[0].Rows.Count != 0)
                            {
                                if (e.NewValues["Name"].ToString().Trim() != e.OldValues["Name"].ToString().Trim())
                                {
                                    AddError(e.Errors, gdProductsInformation.Columns["Name"], "* Name already exists");
                                }
                            }
                        }
                    }

                    if (e.NewValues["Code"] != null)
                    {
                        if (e.NewValues["Code"].ToString().ToLower() != e.OldValues["Code"].ToString().ToLower())
                        {
                            dsCheck = productCategory.CheckPromotionCodeExists(e.NewValues["Code"].ToString().Trim(), "Promotions");

                            if (dsCheck.Tables[0].Rows.Count != 0)
                            {
                                if (e.NewValues["Code"].ToString().Trim() != e.OldValues["Code"].ToString().Trim())
                                {
                                    AddError(e.Errors, gdProductsInformation.Columns["Code"], "* Code already exists");
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                DevExpress.Web.ASPxWebControl.RedirectOnCallback("Login.aspx");
            }

        }

        protected void gdProductsInformation_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
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

        protected void gdProductsInformation_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
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

        protected void gdProductsInformation_CommandButtonInitialize(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewCommandButtonEventArgs e)
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

        private void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn gridViewColumn, string errorText)
        {
            if (errors.ContainsKey(gridViewColumn))
            {
                return;
            }
            errors[gridViewColumn] = errorText;
        }

    }
}