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
    public partial class zx : System.Web.UI.Page
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
            //if (e.ButtonType == ColumnCommandButtonType.Update)
            //{


            //    e.Text = (sender as ASPxGridView).IsNewRowEditing ? "Add" : "Update";



            //}
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


        protected void gdAccounts_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {



                //if (Session["UserId"] == null)
                //{
                //    Response.Redirect("~/Login.aspx");
                //}
                //else
                //{
                //    int Active = 0;
                //    if (e.NewValues["Active"] == null)
                //    {
                //        Active = 0;
                //    }
                //    else
                //    {
                //        Active = 1;
                //    }

                //    if (Convert.ToBoolean(e.NewValues["Active"]) == true)
                //    {
                //        Active = 1;
                //    }
                //    else
                //    {
                //        Active = 0;
                //    }

                //    int success = objBLLUsers.RegisterNewUser(e.NewValues["Email"].ToString(),
                //        e.NewValues["NIC"].ToString().ToLower(),
                //        e.NewValues["Fname"].ToString().ToLower(),
                //        e.NewValues["Lname"].ToString().ToLower()
                //        , objUserConfig.EncryptStringF("test123"), Convert.ToInt32(e.NewValues["StakeHolderTypeId"]),
                //       objUserConfig.EncryptStringF(e.NewValues["NIC"].ToString()),
                //        e.NewValues["MobileNo"].ToString(),
                //        e.NewValues["AddressLine1"].ToString(), e.NewValues["AddressLine2"].ToString(), e.NewValues["AddressLine3"].ToString(),
                //        null, null, e.NewValues["BankBranch"].ToString(),
                //        e.NewValues["BankAcc"].ToString(),
                //        e.NewValues["BankName"].ToString(), null,
                //        e.NewValues["DOB"].ToString(), Convert.ToInt32(e.NewValues["EducationalTypeId"].ToString()),

                //              e.NewValues["WorkAdd"].ToString(),
                //              "", Convert.ToInt32(e.NewValues["WorkExperience"].ToString()));




                //    if (success >= 1)
                //    {
                //        e.Cancel = true;
                //        gdAccounts.CancelEdit();
                //        ((ASPxGridView)sender).JSProperties["cpInsertNote"] = "Successfully Inserted";
                //    }
                //    else
                //    {
                //        e.Cancel = true;
                //        gdAccounts.CancelEdit();
                //        ((ASPxGridView)sender).JSProperties["cpInsertNote"] = "Inserting Failed";
                //    }

                //}

                //DevExpress.Web.ASPxWebControl.RedirectOnCallback("Login.aspx");


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
            //BootstrapGridView gridd = sender as BootstrapGridView;
            //int i = Convert.ToInt32(gridd.GetMasterRowKeyValue());
            //SqlGetUsers.SelectParameters[0].DefaultValue = i.ToString();
        }

        protected void gdAccounts_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

        }
    }
}