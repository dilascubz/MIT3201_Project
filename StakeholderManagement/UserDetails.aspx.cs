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
namespace StakeholderManagement
{
    //ss
    public partial class UserDetails : System.Web.UI.Page
    {
        private static BLLSignUp objBLLUsers = new BLLSignUp();
        //  private static BLLCommonFunctions objBLLCommonFunctions = new BLLCommonFunctions();
        private UserConfig objUserConfig = new UserConfig();


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


        protected void gdPromotions_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            if (Session["UserId"] == null)
            {
                /*string email = "";
                string contact = "";

                int success;


                DataSet dsCheck = objBLLAddEditCompanyDetails.IsCompanyExitis(e.NewValues["UserId"].ToString());
                if (dsCheck.Tables[0].Rows.Count != 0)
                {
                    e.Cancel = true;
                    GridCompany.CancelEdit();
                    ((BootstrapGridView)sender).JSProperties["cpInsertNote"] = "UserId Exists";
                }*/


                DevExpress.Web.ASPxWebControl.RedirectOnCallback("Login.aspx");
            }

            e.NewValues["UserLoginId"] = Session["UserId"].ToString();

        }

        protected void gdPromotions_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            if (Session["UserId"] == null)
            {
                /*string email = "";
                string contact = "";

                int success;


                DataSet dsCheck = objBLLAddEditCompanyDetails.IsCompanyExitis(e.NewValues["UserId"].ToString());
                if (dsCheck.Tables[0].Rows.Count != 0)
                {
                    e.Cancel = true;
                    GridCompany.CancelEdit();
                    ((BootstrapGridView)sender).JSProperties["cpInsertNote"] = "UserId Exists";
                }*/


                DevExpress.Web.ASPxWebControl.RedirectOnCallback("Login.aspx");
            }

            e.NewValues["UserLoginId"] = Session["UserId"].ToString();
        }

        protected void gdPromotions_CellEditorInitialize(object sender, BootstrapGridViewEditorEventArgs e)
        {

        }



        protected void btnDispatch_Click(object sender, EventArgs e)
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

        protected void gdDetailedAccounts_BeforePerformDataSelect(object sender, EventArgs e)
        {
            BootstrapGridView gridd = sender as BootstrapGridView;
            int i = Convert.ToInt32(gridd.GetMasterRowKeyValue());
            SqlGetUsers.SelectParameters[0].DefaultValue = i.ToString();
        }


        protected void gdAccounts_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            DataSet dsCheck = default(DataSet);


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

        protected void gdAccounts_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
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


                //int success = objBLLUsers.RegisterNewUser(e.NewValues["Email"].ToString(),
                //    e.NewValues["NIC"].ToString().ToLower(),
                //    e.NewValues["FName"].ToString().ToLower(),
                //    e.NewValues["LName"].ToString().ToLower()
                //    , objUserConfig.EncryptStringF("test123"), Convert.ToInt32(e.NewValues["StakeHolderTypeId"]),
                //   objUserConfig.EncryptStringF(e.NewValues["NIC"].ToString()),
                //    e.NewValues["MobileNo"].ToString(),
                //    e.NewValues["AddressLine1"].ToString(), e.NewValues["AddressLine2"].ToString(),
                //    e.NewValues["AddressLine3"].ToString(),
                //    null, null, e.NewValues["BankBranch"].ToString(),
                //    e.NewValues["BankAcc"].ToString(),
                //    e.NewValues["BankName"].ToString(), null,
                //    e.NewValues["DOB"].ToString(), (e.NewValues["Educational"].ToString()),

                //          e.NewValues["WorkAddress"].ToString(),
                //          "", Convert.ToInt32(e.NewValues["WorkExperience"].ToString()),
                //         Convert.ToInt32(Session["ASOAcc"].ToString()),
                //          "", false, "", 0, 0, 0, ""

                //          );

                int success = 0;

                if (success >= 1)
                {
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
    }
}