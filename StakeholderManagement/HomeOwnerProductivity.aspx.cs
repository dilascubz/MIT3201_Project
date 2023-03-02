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
    public partial class HomeOwnerProductivity : System.Web.UI.Page
    {
        private static BLLSignUp objBLLUsers = new BLLSignUp();
        //  private static BLLCommonFunctions objBLLCommonFunctions = new BLLCommonFunctions();
        private UserConfig objUserConfig = new UserConfig();
        DataTable dtUserDetails = new DataTable();
        DataTable dtHomeUserDetails = new DataTable();
        private static BLLRetailerPreviousOrderItems objASOReports = new BLLRetailerPreviousOrderItems();
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

        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = objASOReports.GetHomeOwnerProductivity(Convert.ToInt32(cmbASM.SelectedItem.Value));
             


                if (ds.Tables[0].Rows.Count != 0)
                {
                    ASPxGridViewExporter1.FileName = "Home Owner Productivity";
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

        protected void cmbStakeHolderType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        

        protected void btnProcess_Click(object sender, EventArgs e)
        {
          //  BindGrid();
        }

        protected void cmbStakeHolderId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void BindGrid()
        {

            if (cmbASM.SelectedItem == null)
            {
                string script = "alert(\"Please Select a StakeHolder Type\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                return;
            }

            if (cmbASO.SelectedItem == null)
            {
                string script = "alert(\"Please Select a StakeHolder Type\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                return;
            }

            DataSet ds = objASOReports.GetHomeOwnerProductivity(Convert.ToInt32(cmbASM.SelectedItem.Value)," "," ",1);
            gdHomeOwner.DataSource = ds;
            gdHomeOwner.DataBind();

        }



        protected void dtToDate_DateChanged(object sender, EventArgs e)
        {
          
        }
    }
}