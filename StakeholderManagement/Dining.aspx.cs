using DevExpress.Web.Bootstrap;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLLRMS;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using DevExpress.Web;

namespace StakeholderManagement
{
    public partial class Dining : System.Web.UI.Page
    {
        byte[] Imgbytes = null;
        private BLLAddProductCategory objProuduct = new BLLAddProductCategory();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gdAdvertisement_CellEditorInitialize(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewEditorEventArgs e)
        {

        }

        protected void gdAdvertisement_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            if (Session["UserId"] != null)
            {
                int success;
                string Name = null;
                string Code = null;

                if (e.NewValues["Name"] != null)
                {
                    Name = e.NewValues["Name"].ToString();
                }


                if (e.NewValues["AdImage"] == null)
                {
                    Imgbytes = (byte[])e.NewValues["AdImage"];

                    string resultFilePath = Server.MapPath("~/assets/images/no-image.gif");
                    Bitmap bitmap = new Bitmap(resultFilePath);
                    e.NewValues["AdImage"] = ImageToByte(bitmap);
                }



                if (e.NewValues["AdImage"] != null)
                {
                    Imgbytes = (byte[])e.NewValues["AdImage"];
                }

                if (e.NewValues["StakeHolderType"] == null)
                {
                    e.NewValues["StakeHolderType"] = "";
                }

                if (e.NewValues["FromDate"] == null)
                {
                    e.NewValues["FromDate"] = "0";
                }

                if (e.NewValues["ToDate"] == null)
                {
                    e.NewValues["ToDate"] = "0";
                }

                bool Active = Convert.ToBoolean(e.NewValues["Active"]);


                success = objProuduct.AddAdvertisements(Convert.ToInt32(e.NewValues["StakeHolderType"]),

                    Name, (e.NewValues["FromDate"]).ToString(), (e.NewValues["ToDate"]).ToString(), Imgbytes, Session["UserId"].ToString(), Active);
                if (success >= 1)
                {
                    e.Cancel = true;
                    gdAdvertisement.CancelEdit();
                    ((BootstrapGridView)sender).JSProperties["cpInsertNote"] = "Successfully Inserted.";
                }
                else
                {
                    e.Cancel = true;
                    gdAdvertisement.CancelEdit();
                    ((BootstrapGridView)sender).JSProperties["cpInsertNote"] = "Inserting Failed.";
                }
            }
            else
            {
                DevExpress.Web.ASPxWebControl.RedirectOnCallback("Login.aspx");
            }



            e.NewValues["UserLoginId"] = Session["UserId"].ToString();
        }


        public static byte[] ImageToByte(System.Drawing.Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }



        protected void gdAdvertisement_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

            if (Session["UserId"] != null)
            {
                int success;
                string Name = null;
                string Code = null;

                if (e.NewValues["Name"] != null)
                {
                    Name = e.NewValues["Name"].ToString();
                }

                if (e.NewValues["Code"] != null)
                {
                    Code = e.NewValues["Code"].ToString();
                }



                if (e.NewValues["StakeHolderType"] == null)
                {
                    e.NewValues["StakeHolderType"] = "";
                }

                if (e.NewValues["FromDate"] == null)
                {
                    e.NewValues["FromDate"] = "0";
                }

                if (e.NewValues["ToDate"] == null)
                {
                    e.NewValues["ToDate"] = "0";
                }

                if (e.NewValues["AdImage"] == null)
                {
                    Imgbytes = (byte[])e.NewValues["AdImage"];

                    string resultFilePath = Server.MapPath("~/assets/images/no-image.gif");
                    Bitmap bitmap = new Bitmap(resultFilePath);
                    e.NewValues["AdImage"] = ImageToByte(bitmap);
                }


                if (e.NewValues["AdImage"] != null)
                {
                    Imgbytes = (byte[])e.NewValues["AdImage"];
                }
                bool Active = Convert.ToBoolean(e.NewValues["Active"]);




                success = objProuduct.UpDateAdvertisemtny
                (Convert.ToInt32(e.NewValues["StakeHolderType"]),
              Name, (e.NewValues["FromDate"]).ToString(), (e.NewValues["ToDate"]).ToString(), Imgbytes, Session["UserId"].ToString()
              , Active, Convert.ToInt32(e.Keys["Id"].ToString()));


                if (success >= 1)
                {
                    e.Cancel = true;
                    gdAdvertisement.CancelEdit();
                    ((BootstrapGridView)sender).JSProperties["cpInsertNote"] = "Successfully Updated.";
                }
                else
                {
                    e.Cancel = true;
                    gdAdvertisement.CancelEdit();
                    ((BootstrapGridView)sender).JSProperties["cpInsertNote"] = "Updating Failed.";
                }
            }
            else
            {
                DevExpress.Web.ASPxWebControl.RedirectOnCallback("Login.aspx");
            }


            //DevExpress.Web.ASPxWebControl.RedirectOnCallback("Login.aspx");
            ////}
            //e.NewValues["UserLoginId"] = Session["UserId"].ToString();

            //DevExpress.Web.ASPxWebControl.RedirectOnCallback("Login.aspx");
            ////e.NewValues["UserLoginId"] = Session["UserId"].ToString();

            // e.NewValues["UserLoginId"] = Session["UserId"].ToString();
        }

        protected void gdAdvertisement_CommandButtonInitialize(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewCommandButtonEventArgs e)
        {


        }

        protected void gdAdvertisement_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

            DateTime FromDate = Convert.ToDateTime((e.NewValues["FromDate"]).ToString());
            DateTime Todate = Convert.ToDateTime((e.NewValues["ToDate"]).ToString());

            if ((FromDate.Date) > (Todate.Date))
            {
                string script = "alert(\"FromDate should be less than ToDate\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                return;
            }



            //DataSet dsCheck = default(DataSet);


            //if (gdAdvertisement.IsNewRowEditing)
            //{
            //    if (e.NewValues["Name"] != null)
            //    {
            //        dsCheck = objProuduct.CheckPromotionsNameExists(e.NewValues["Name"].ToString().Trim(), "Promotion");

            //        if (dsCheck.Tables[0].Rows.Count != 0)
            //        {
            //            AddError(e.Errors, gdAdvertisement.Columns["Name"], "* Name already exists");
            //        }
            //    }

            //    if (e.NewValues["Code"] != null)
            //    {
            //        dsCheck = objProuduct.CheckPromotionCodeExists(e.NewValues["Code"].ToString().Trim(), "Promotion");

            //        if (dsCheck.Tables[0].Rows.Count != 0)
            //        {
            //            AddError(e.Errors, gdAdvertisement.Columns["Code"], "* Code already exists");
            //        }
            //    }
            //}

            //else
            //{
            //    if (e.NewValues["Name"] != null)
            //    {
            //        if (e.NewValues["Name"].ToString().ToLower() != e.OldValues["Name"].ToString().ToLower())
            //        {
            //            dsCheck = objProuduct.CheckPromotionsNameExists(e.NewValues["Name"].ToString().Trim(), "Promotion");

            //            if (dsCheck.Tables[0].Rows.Count != 0)
            //            {
            //                if (e.NewValues["Name"].ToString().Trim() != e.OldValues["Name"].ToString().Trim())
            //                {
            //                    AddError(e.Errors, gdAdvertisement.Columns["Name"], "* Name already exists");
            //                }
            //            }
            //        }
            //    }

            //    if (e.NewValues["Code"] != null)
            //    {
            //        if (e.NewValues["Code"].ToString().ToLower() != e.OldValues["Code"].ToString().ToLower())
            //        {
            //            dsCheck = objProuduct.CheckPromotionCodeExists(e.NewValues["Code"].ToString().Trim(), "Promotion");

            //            if (dsCheck.Tables[0].Rows.Count != 0)
            //            {
            //                if (e.NewValues["Code"].ToString().Trim() != e.OldValues["Code"].ToString().Trim())
            //                {
            //                    AddError(e.Errors, gdAdvertisement.Columns["Code"], "* Code already exists");
            //                }
            //            }
            //        }
            //    }
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




        protected void gdAdvertisement_AfterPerformCallback(object sender, DevExpress.Web.ASPxGridViewAfterPerformCallbackEventArgs e)
        {

        }

        protected void gdAdvertisement_CommandButtonInitialize1(object sender, BootstrapGridViewCommandButtonEventArgs e)
        {
            if (Session["UserCategoryId"].ToString() == "1")
            {

                if (e.ButtonType == ColumnCommandButtonType.Edit)
                {
                }

                if (e.ButtonType == ColumnCommandButtonType.Edit)
                {
                    e.Visible = true;

                }
                if (e.ButtonType == ColumnCommandButtonType.New)
                {
                    e.Visible = true;

                }
            }
            else
            {
                if (e.ButtonType == ColumnCommandButtonType.Edit)
                {
                    e.Visible = false;
                }
                if (e.ButtonType == ColumnCommandButtonType.New)
                {
                    e.Visible = false;

                }
            }
        }
    }


}