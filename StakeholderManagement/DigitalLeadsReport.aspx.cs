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
    public partial class DigitalLeadsReport : System.Web.UI.Page
    {
        private static BLLSignUp objBLLUsers = new BLLSignUp();
        private static BLLRetailerPreviousOrderItems objASOReports = new BLLRetailerPreviousOrderItems();
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











        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            try
            {
               
                DataSet ds = objASOReports.GetDigitalLeadsReport(Convert.ToInt32(cmbASO.SelectedItem.Value), dtFromDate.Date.ToString(), dtToDate.Date.ToString(), Convert.ToInt32(cmbStakeHolderType.SelectedItem.Value));


                if (ds.Tables[0].Rows.Count != 0)
                {
                    ASPxGridViewExporter1.FileName = "Digital Leads Report";
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

        protected void cmbASM_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsASOAcc = new DataSet();
            if (cmbASM.SelectedItem == null)
            {
                string script = "alert(\"Please Select an ASM\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                return;
            }
            else
            {
                dsASOAcc = objASOReports.GetASMWiseASOAccs(Convert.ToInt32(cmbASM.SelectedItem.Value));
                // Session["ASOAcc"] = dsASOAcc.Tables[0].Rows[0]["Id"];
                //   (Session["ASOAcc"]) = Convert.ToInt32(cmbASO.SelectedItem.Value);
                if ((dsASOAcc != null))
                {
                    if (dsASOAcc.Tables[0].Rows.Count != 0)
                    {



                        cmbASO.TextField = "Territory";
                        cmbASO.ValueField = "SalesRepAccId";
                        cmbASO.DataSource = dsASOAcc;
                        cmbASO.DataBind();
                        cmbASO.Items.Insert(0, new BootstrapListEditItem("Select one", 0));
                        cmbASO.SelectedIndex = 0;
                    }
                    else
                    {
                        dsASOAcc = null/* TODO Change to default(_) if this is not a reference type */;
                        cmbASO.Items.Insert(0, new BootstrapListEditItem("No Data", 0));
                        cmbASO.SelectedIndex = 0;
                    }
                }
                else
                {
                    dsASOAcc = null/* TODO Change to default(_) if this is not a reference type */;
                    cmbASO.Items.Insert(0, new ListEditItem("No Data", 0));
                    cmbASO.SelectedIndex = 0;
                    ScriptManager.RegisterClientScriptBlock(cmbASM, cmbASM.GetType(), "message", "alert('No ASO s for the selected ASM');", true);
                }
            }
        }




        protected void cmbASO_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmbStakeHolderType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        protected void dtFromDate_DateChanged(object sender, EventArgs e)
        {
            if (Session["UserId"] is null)
            {
                Response.Redirect("Login.aspx");
            }

            {
                if (dtFromDate.Date > dtToDate.Date)
                {
                    string script = "alert(\"From Date should be less than To Date\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    return;
                }
            }
        }

        protected void dtToDate_DateChanged(object sender, EventArgs e)
        {
            if (Session["UserId"] is null)
            {
                Response.Redirect("Login.aspx");
            }

            if (dtFromDate.Date > dtToDate.Date)
            {
                string script = "alert(\"From Date should be less than To Date\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                return;
            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        public void BindGrid()
        {

            if (cmbASM.SelectedItem == null)
            {
                string script = "alert(\"Please Select an ASM\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                return;
            }

            if (cmbASO.SelectedItem == null)
            {
                string script = "alert(\"Please Select a ASO\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                return;
            }

            if (cmbStakeHolderType.SelectedItem == null)
            {
                string script = "alert(\"Please Select a StakeHolder Type\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                return;
            }
            if (dtFromDate.Value == null)
            {
                string script = "alert(\"Please Select From Date\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                return;
            }
            if (dtFromDate.Value == null)
            {
                string script = "alert(\"Please Select To Date\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                return;
            }

            DataSet ds = objASOReports.GetDigitalLeadsReport(Convert.ToInt32(cmbASO.SelectedItem.Value),dtFromDate.Date.ToString(), dtToDate.Date.ToString(),Convert.ToInt32(cmbStakeHolderType.SelectedItem.Value));
            gdDigitalLeads.DataSource = ds;
            gdDigitalLeads.DataBind();

        }


        protected void cmbStakeHolderId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}