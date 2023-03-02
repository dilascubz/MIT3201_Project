using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using DevExpress.Export;
using DevExpress.XtraPrinting;


using DevExpress.Web;
using DevExpress.Web.Bootstrap;
using BLLRMS;
using System.Data;
using System.Net;
using System.Xml.Linq;
using System.Text;

namespace StakeholderManagement
{
    public partial class UserAccountsz : System.Web.UI.Page
    {
        private static BLLSignUp objBLLUsers = new BLLSignUp();
        //  private static BLLCommonFunctions objBLLCommonFunctions = new BLLCommonFunctions();
        private UserConfig objUserConfig = new UserConfig();
        DataTable dtUserDetails = new DataTable();
        DataTable dtHomeUserDetails = new DataTable();

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
        }





        protected void gdPromotions_CommandButtonInitialize(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewCommandButtonEventArgs e)
        {



        }





        protected void btnDispatch_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int success;
            //    int strCompanyId = Convert.ToInt32(Session["StakeHolderId"]);

            //    if (gdAccounts.VisibleRowCount <= 0)
            //    {
            //        ScriptManager.RegisterClientScriptBlock(btnDispatch, btnDispatch.GetType(), "message", "alert('" + "Not Users  To Select." + "');", true);
            //        return;
            //    }

            //    DataTable dtOrderNo = new DataTable();
            //    dtOrderNo.Columns.Add("UserIntId", System.Type.GetType("System.String"));

            //    List<Object> selectedId = gdAccounts.GetSelectedFieldValues("UserId");

            //    foreach (var gr in selectedId)
            //    {
            //        if (dtOrderNo.Rows.Count > 0)
            //        {
            //            if (gr == dtOrderNo.Rows[0]["UserId"])
            //            { }
            //            else
            //            {
            //                dtOrderNo.Rows.Add(gr.ToString().Trim());
            //            }
            //        }
            //        else
            //        {
            //            dtOrderNo.Rows.Add(gr.ToString().Trim());
            //        }
            //       // success = objBLLAddCompanyItems.UpdateOrderDetailsNo(gr.ToString(), strCompanyId);
            //        ScriptManager.RegisterClientScriptBlock(btnDispatch, btnDispatch.GetType(), "message", "alert('" + "Successfully Dispatch ." + "');", true);

            //    }

            //    if (dtOrderNo.Rows.Count > 0)
            //    {
            //        gdAccounts.Selection.UnselectAll();
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterClientScriptBlock(btnDispatch, btnDispatch.GetType(), "message", "alert('" + "Select Orders To Release." + "');", true);
            //        return;
            //    }


            //    //SqlGetOrders.DataBind();
            //    //SqlGetOrderStatus.DataBind();
            //    //GridOrders.DataBind();





            //}
            //catch (Exception ex)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ex", "alert('" + ex.Message + "');", true);
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

        protected void gdDetailedAccounts_BeforePerformDataSelect(object sender, EventArgs e)
        {
            BootstrapGridView gridd = sender as BootstrapGridView;
            int i = Convert.ToInt32(gridd.GetMasterRowKeyValue());
            SqlGetUsers.SelectParameters[0].DefaultValue = i.ToString();
        }





        protected void gdAccounts_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            DataSet dsCheck = default(DataSet);


            if (gdAccounts.IsNewRowEditing)
            {
                if (e.NewValues["NIC"] != null)
                {
                    dsCheck = objBLLUsers.CheckUser(e.NewValues["NIC"].ToString().Trim(), "");

                    if (dsCheck.Tables[0].Rows.Count != 0)
                    {
                        AddError(e.Errors, gdAccounts.Columns["NIC"], "* NIC already exists");
                    }
                }

                if (e.NewValues["Email"] != null)
                {
                    dsCheck = objBLLUsers.CheckUser("", e.NewValues["Email"].ToString().Trim());

                    if (dsCheck.Tables[0].Rows.Count != 0)
                    {
                        AddError(e.Errors, gdAccounts.Columns["Email"], "* Email already exists");
                    }
                }
            }

            else
            {
                //if (e.NewValues["NIC"] != null)
                //{
                //    if (e.NewValues["NIC"].ToString().ToLower() != e.OldValues["NIC"].ToString().ToLower())
                //    {
                //        dsCheck = objBLLUsers.CheckUser(e.NewValues["NIC"].ToString().Trim(), "");

                //        if (dsCheck.Tables[0].Rows.Count != 0)
                //        {
                //            if (e.NewValues["NIC"].ToString().Trim() != e.OldValues["NIC"].ToString().Trim())
                //            {
                //                AddError(e.Errors, gdAccounts.Columns["Name"], "* NIC already exists");
                //            }
                //        }
                //    }
                //}

                //if (e.NewValues["Email"] != null)
                //{
                //    if (e.NewValues["Email"].ToString().ToLower() != e.OldValues["Email"].ToString().ToLower())
                //    {
                //        dsCheck = objBLLUsers.CheckUser("", e.NewValues["Email"].ToString().Trim());

                //        if (dsCheck.Tables[0].Rows.Count != 0)
                //        {
                //            if (e.NewValues["Email"].ToString().Trim() != e.OldValues["Email"].ToString().Trim())
                //            {
                //                AddError(e.Errors, gdAccounts.Columns["Email"], "* Email already exists");
                //            }
                //        }
                //    }
                //}
            }
            //DataSet dsCheck = default(DataSet);


            //if (gdAccounts.IsNewRowEditing)
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
        private void GetLatLongFromAddress(string url2)
        {

            string url = string.Format(url2);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            try
            {
                string _byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());

                WebResponse response = request.GetResponse();
                XDocument xdoc = XDocument.Load(url);
                XElement locationElement = xdoc.Element("GeocodeResponse").Element("result").Element("geometry").Element("location");
                double latitude1 = (double)locationElement.Element("lat");
                double longitude1 = (double)locationElement.Element("lng");
                Session["GPSLAt"] = latitude1;
                Session["GPSLong"] = longitude1;

            }
            catch (System.Net.WebException exp)
            {

            }

        }


        protected void gdAccounts_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            string lat;
            string longt;

            if (Session["UserId"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                bool Active = false;
                if (e.NewValues["Active"] == null)
                {
                    Active = false;
                }
                else
                {
                    Active = true;
                }

                if (Convert.ToBoolean(e.NewValues["Active"]) == true)
                {
                    Active = true;
                }
                else
                {
                    Active = false;
                }

                if (e.NewValues["BankAcc"] == null)
                {
                    e.NewValues["BankAcc"] = "";

                }
                if (e.NewValues["BankName"] == null)
                {
                    e.NewValues["BankName"] = "";

                }

                if (e.NewValues["BankBranch"] == null)
                {
                    e.NewValues["BankBranch"] = "";

                }
                if (e.NewValues["WorkAddress"] == null)
                {
                    e.NewValues["WorkAddress"] = "";

                }
                if (e.NewValues["AddressLine3"] == null)
                {
                    e.NewValues["AddressLine3"] = "";
                }


                if (Session["ASO"] == null)
                {
                    Session["ASO"] = "0";
                }

                if (e.NewValues["CommercialSite"] == null)
                {
                    e.NewValues["CommercialSite"] = "0";
                }

                if (e.NewValues["SiteType"] == null)
                {
                    e.NewValues["SiteType"] = "";
                }

                if (e.NewValues["SiteCondition"] == null)
                {
                    e.NewValues["SiteCondition"] = "";
                }

                if (e.NewValues["PurchasedQty"] == null)
                {
                    e.NewValues["PurchasedQty"] = "0";
                }

                if (e.NewValues["ProductBrandId"] == null)
                {
                    e.NewValues["ProductBrandId"] = "";
                }

                if (e.NewValues["Source"] == null)
                {
                    e.NewValues["Source"] = "";
                }



                if (e.NewValues["PurchasedQty"] == null)
                {
                    e.NewValues["PurchasedQty"] = "";
                }

                if (e.NewValues["WorkExperience"] == null)
                {
                    e.NewValues["WorkExperience"] = "0";
                }

                string Address = e.NewValues["AddressLine1"].ToString() + e.NewValues["AddressLine1"].ToString() + "," + e.NewValues["AddressLine1"].ToString();

                string strAddress = Address; ;
                string url = "https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyAKWjSdYxPggIZ87XsX8cXnZupDXq1jxt4&address=" + strAddress + "&sensor=true";


                try
                {
                    GetLatLongFromAddress(url);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "message", "alert('" + "Please Enter a Correct Address" + "');", true);

                }

                if (Session["GPSLAt"] == null)
                {
                    lat = null;
                }
                else
                    lat = Session["GPSLAt"].ToString();


                if (Session["GPSLong"] == null)
                {
                    longt = null;
                }
                else
                    longt = Session["GPSLong"].ToString();



                //int success = objBLLUsers.RegisterNewUser(e.NewValues["Email"].ToString(),
                // e.NewValues["NIC"].ToString().ToLower(),
                // e.NewValues["FName"].ToString().ToLower(),
                // e.NewValues["LName"].ToString().ToLower()
                // , objUserConfig.EncryptStringF("test123"), Convert.ToInt32(e.NewValues["StakeHolderTypeId"]),
                //objUserConfig.EncryptStringF(e.NewValues["NIC"].ToString()),
                // e.NewValues["MobileNo"].ToString(),
                // e.NewValues["AddressLine1"].ToString(), e.NewValues["AddressLine2"].ToString(),
                // e.NewValues["AddressLine3"].ToString(),
                // null, null, e.NewValues["BankBranch"].ToString(),
                // e.NewValues["BankAcc"].ToString(),
                // e.NewValues["BankName"].ToString(), null,
                // e.NewValues["DOB"].ToString(), "",

                //       e.NewValues["WorkAddress"].ToString(),
                //       "", Convert.ToInt32(e.NewValues["WorkExperience"].ToString()),
                //      Convert.ToInt32(Session["ASOAcc"].ToString()),
                //          "", false, "", 0, 0, 0, ""

                //    //e.NewValues["SiteType"].ToString(),
                //    //Convert.ToBoolean(e.NewValues["CommercialSite"]), e.NewValues["SiteCondition"].ToString(),
                //    //Convert.ToInt32(e.NewValues["ProductBrandId"]),
                //    // Convert.ToInt32(e.NewValues["TotalProductReqiurement"].ToString()),
                //    // Convert.ToInt32(e.NewValues["PurchasedQty"].ToString()),
                //    // e.NewValues["Source"].ToString()

                //    );




                int success = 0;

                if (success >= 1)
                {
                    gdAccounts.JSProperties["cpInsertNote"] = "Successfully Inserted.";
                    e.Cancel = true;
                    gdAccounts.CancelEdit();
                    gdAccounts.DataBind();
                    ((ASPxGridView)sender).JSProperties["cpInsertNote"] = "Successfully Inserted";
                }
                else
                {
                    e.Cancel = true;
                    gdAccounts.CancelEdit();
                    ((ASPxGridView)sender).JSProperties["cpInsertNote"] = "Inserting Failed";
                }

            }

            //DevExpress.Web.ASPxWebControl.RedirectOnCallback("Login.aspx");


        }


        protected void gdAccounts_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            var clickedRowIndex = e.VisibleIndex;
            var keyValue = grid.GetRowValues(clickedRowIndex, grid.KeyFieldName);

            Session["StakeId"] = keyValue.ToString();
            // Response.Redirect("~/UserAccounts.aspx");

            if (Page.IsCallback)
                ASPxWebControl.RedirectOnCallback("~/Visits.aspx");


        }



        //-----------------------------Home Owner---------------------------------


        protected void gdHomeOwner_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {

            ASPxGridView grid = sender as ASPxGridView;
            var clickedRowIndex = e.VisibleIndex;
            var keyValue = grid.GetRowValues(clickedRowIndex, grid.KeyFieldName);

            Session["StakeId"] = keyValue.ToString();
            // Response.Redirect("~/UserAccounts.aspx");

            if (Page.IsCallback)
                ASPxWebControl.RedirectOnCallback("~/Visits.aspx");
        }


        protected void gdHomeOwner_CellEditorInitialize(object sender, BootstrapGridViewEditorEventArgs e)
        {

        }



        protected void gdHomeOwner_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            string lat;
            string longti;
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                bool Active = false;
                if (e.NewValues["Active"] == null)
                {
                    Active = false;
                }
                else
                {
                    Active = true;
                }

                if (Convert.ToBoolean(e.NewValues["Active"]) == true)
                {
                    Active = true;
                }
                else
                {
                    Active = false;
                }

                if (e.NewValues["BankAcc"] == null)
                {
                    e.NewValues["BankAcc"] = "";

                }
                if (e.NewValues["BankName"] == null)
                {
                    e.NewValues["BankName"] = "";

                }

                if (e.NewValues["BankBranch"] == null)
                {
                    e.NewValues["BankBranch"] = "";

                }
                if (e.NewValues["WorkAddress"] == null)
                {
                    e.NewValues["WorkAddress"] = "";

                }
                if (e.NewValues["AddressLine3"] == null)
                {
                    e.NewValues["AddressLine3"] = "";
                }


                if (Session["ASO"] == null)
                {
                    Session["ASO"] = "0";
                }

                if (e.NewValues["Educational"] == null)
                {
                    e.NewValues["Educational"] = "";
                }

                if (e.NewValues["SiteType"] == null)
                {
                    e.NewValues["SiteType"] = "";
                }

                if (e.NewValues["Source"] == null)
                {
                    e.NewValues["Source"] = "";
                }

                if (e.NewValues["TotalProductReqiurement"] == null)
                {
                    e.NewValues["TotalProductReqiurement"] = "0";
                }

                if (e.NewValues["PurchasedQty"] == null)
                {
                    e.NewValues["PurchasedQty"] = "0";
                }

                if (e.NewValues["SiteCondition"] == null)
                {
                    e.NewValues["SiteCondition"] = "";
                }

                if (e.NewValues["CommercialSite"] == null)
                {
                    e.NewValues["CommercialSite"] = "";
                }

                if (e.NewValues["ProductBrandId"] == null)
                {
                    e.NewValues["ProductBrand"] = "0";

                }



                if (e.NewValues["Educational"] == null)
                {
                    e.NewValues["Educational"] = "";
                }

                string Address = e.NewValues["AddressLine1"].ToString() + e.NewValues["AddressLine1"].ToString() + "," + e.NewValues["AddressLine1"].ToString();

                string strAddress = Address; ;
                string url = "https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyAKWjSdYxPggIZ87XsX8cXnZupDXq1jxt4&address=" + strAddress + "&sensor=true";


                try
                {
                    GetLatLongFromAddress(url);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "message", "alert('" + "Please Enter a Correct Address" + "');", true);

                }


                if (Session["GPSLAt"] == null)
                {
                    lat = null;
                }
                else
                    lat = Session["GPSLAt"].ToString();


                if (Session["GPSLong"] == null)
                {
                    longti = null;
                }
                else
                    longti = Session["GPSLong"].ToString();

                //int success = objBLLUsers.RegisterNewUser(e.NewValues["Email"].ToString(),
                //    e.NewValues["NIC"].ToString().ToLower(),
                //    e.NewValues["FName"].ToString().ToLower(),
                //    e.NewValues["LName"].ToString().ToLower()
                //    , objUserConfig.EncryptStringF("test123"), 1,
                //   objUserConfig.EncryptStringF(e.NewValues["NIC"].ToString()),
                //    e.NewValues["MobileNo"].ToString(),
                //    e.NewValues["AddressLine1"].ToString(), e.NewValues["AddressLine2"].ToString(),
                //    e.NewValues["AddressLine3"].ToString(),
                //    null, null, e.NewValues["BankBranch"].ToString(),
                //    e.NewValues["BankAcc"].ToString(),
                //    e.NewValues["BankName"].ToString(), null,
                //    e.NewValues["DOB"].ToString(), (e.NewValues["Educational"].ToString()),

                //          e.NewValues["WorkAddress"].ToString(),
                //          "", 0,
                //         Convert.ToInt32(Session["ASOAcc"].ToString()),
                //         e.NewValues["SiteType"].ToString(),
                //         Convert.ToBoolean(e.NewValues["CommercialSite"]), e.NewValues["SiteCondition"].ToString(),
                //         Convert.ToInt32(e.NewValues["ProductBrandId"]),
                //          Convert.ToInt32(e.NewValues["TotalProductReqiurement"].ToString()),
                //          Convert.ToInt32(e.NewValues["PurchasedQty"].ToString()),
                //          e.NewValues["Source"].ToString()




                //          );



                int success = 0;
                if (success >= 1)
                {
                    e.Cancel = true;
                    gdHomeOwner.CancelEdit();
                    gdAccounts.DataBind();
                    ((ASPxGridView)sender).JSProperties["cpInsertNote"] = "Successfully Inserted";
                }
                else
                {
                    e.Cancel = true;
                    gdHomeOwner.CancelEdit();
                    ((ASPxGridView)sender).JSProperties["cpInsertNote"] = "Inserting Failed";
                }

            }

        }


        protected void gdHomeOwner_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            DataSet dsCheck = default(DataSet);


            if (gdHomeOwner.IsNewRowEditing)
            {
                if (e.NewValues["NIC"] != null)
                {
                    dsCheck = objBLLUsers.CheckUser(e.NewValues["NIC"].ToString().Trim(), "");

                    if (dsCheck.Tables[0].Rows.Count != 0)
                    {
                        AddError(e.Errors, gdHomeOwner.Columns["NIC"], "* NIC already exists");
                    }
                }

                if (e.NewValues["Email"] != null)
                {
                    dsCheck = objBLLUsers.CheckUser("", e.NewValues["Email"].ToString().Trim());

                    if (dsCheck.Tables[0].Rows.Count != 0)
                    {
                        AddError(e.Errors, gdHomeOwner.Columns["Email"], "* Email already exists");
                    }
                }
            }

            else
            {
                //if (e.NewValues["NIC"] != null)
                //{
                //    if (e.NewValues["NIC"].ToString().ToLower() != e.OldValues["NIC"].ToString().ToLower())
                //    {
                //        dsCheck = objBLLUsers.CheckUser(e.NewValues["NIC"].ToString().Trim(), "");

                //        if (dsCheck.Tables[0].Rows.Count != 0)
                //        {
                //            if (e.NewValues["NIC"].ToString().Trim() != e.OldValues["NIC"].ToString().Trim())
                //            {
                //                AddError(e.Errors, gdAccounts.Columns["Name"], "* NIC already exists");
                //            }
                //        }
                //    }
                //}

                //if (e.NewValues["Email"] != null)
                //{
                //    if (e.NewValues["Email"].ToString().ToLower() != e.OldValues["Email"].ToString().ToLower())
                //    {
                //        dsCheck = objBLLUsers.CheckUser("", e.NewValues["Email"].ToString().Trim());

                //        if (dsCheck.Tables[0].Rows.Count != 0)
                //        {
                //            if (e.NewValues["Email"].ToString().Trim() != e.OldValues["Email"].ToString().Trim())
                //            {
                //                AddError(e.Errors, gdAccounts.Columns["Email"], "* Email already exists");
                //            }
                //        }
                //    }
                //}
            }
        }

        protected void gdAccounts_CellEditorInitialize(object sender, BootstrapGridViewEditorEventArgs e)
        {

        }

        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataView viewUserDetails = (DataView)SqlGetUsers.Select(DataSourceSelectArguments.Empty);
                dtUserDetails = viewUserDetails.ToTable();

                if (dtUserDetails.Rows.Count != 0)
                {
                    ASPxGridViewExporter1.FileName = "StakeholderReport";
                    ASPxGridViewExporter1.Landscape = true;
                    ASPxGridViewExporter1.PaperKind = System.Drawing.Printing.PaperKind.A4;
                    //gridVisitHeaderImages.Columns[7].Visible = false;
                    //gridVisitHeaderImages.Columns[8].Visible = false;
                    ASPxGridViewExporter1.WriteXlsxToResponse();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "message", "alert('No Data to Export.');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "message", "alert('" + ex.Message + "');", true);
            }
        }
    }
}