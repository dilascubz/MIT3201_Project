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
    public partial class Drinking : System.Web.UI.Page
    {
        byte[] Imgbytes = null;
        private BLLAddProductCategory objProuduct = new BLLAddProductCategory();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gdAdvertisement_CellEditorInitialize(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewEditorEventArgs e)
        {

        }



        public static byte[] ImageToByte(System.Drawing.Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }






        private void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn gridViewColumn, string errorText)
        {
            if (errors.ContainsKey(gridViewColumn))
            {
                return;
            }
            errors[gridViewColumn] = errorText;
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

        protected void gdWaterIntake_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

            if (e.NewValues["Liters"] is null)
            {
                AddError(e.Errors, gdWaterIntake.Columns["Liters"], "Please enter bank");
            }

        }

        protected void gdWaterIntake_CommandButtonInitialize(object sender, BootstrapGridViewCommandButtonEventArgs e)
        {

        }
    }


}