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
    public partial class StakeholderBirthday : System.Web.UI.Page
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

            PopulateMonth();
        }




        private void PopulateMonth()
        {
            try
            {
                cmbMonth.Items.Insert(0, new BootstrapListEditItem("Select one", 0));
                cmbMonth.Items.Clear();
                // Dim lt As ListItem = New ListItem
                BootstrapListEditItem lt;

                int i = 1;
                while ((i <= 12))
                {
                    lt = new BootstrapListEditItem();
                    // lt.Text = Convert.ToDateTime((i.ToString + "/1/1900")).ToString("MMMM")

                    string monthName = new DateTime(1, i, 1).ToString("MMMM");
                    lt.Text = monthName;
                    lt.Value = i.ToString();
                   
                    cmbMonth.Items.Add(lt);
                    i = (i + 1);
                }
                //ddlMonth.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true;
            }
            catch (Exception ex)
            {
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


         

        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = objASOReports.GetStakeHolderBirthdays(Convert.ToInt32(cmbASO.SelectedItem.Value), Convert.ToInt32(cmbMonth.SelectedItem.Value));


                if (ds.Tables[0].Rows.Count != 0)
                {
                    ASPxGridViewExporter1.FileName = "Stakeholder Birthday Details";
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
            if (cmbASO.SelectedItem == null)
            {

                return;
            }

            if (cmbASM.SelectedItem == null)
            {

                return;
            }



            //odsStakeHolderBirthdaytest.SelectParameters["ASOAccId"].DefaultValue = cmbASO.SelectedItem.Value.ToString();
            //odsStakeHolderBirthdaytest.SelectParameters["MonthId"].DefaultValue = cmbMonth.SelectedItem.Value.ToString();

            //odsStakeHolderBirthdaytest.Select();

            

          //  BindGrid();
        }


        public void BindGrid()
        {

            if (cmbASM.SelectedItem == null)
            {
                string script = "alert(\"Please Select an ASM \");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                return;
            }


            if (cmbASO.SelectedItem == null)
            {
                string script = "alert(\"Please Select an ASO\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                return;
            }

            if (cmbMonth.SelectedItem == null)
            {
                string script = "alert(\"Please Select a Month\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                return;
            }



            DataSet ds = objASOReports.GetStakeHolderBirthdays(Convert.ToInt32(cmbASO.SelectedItem.Value),Convert.ToInt32(cmbMonth.SelectedItem.Value));
            gdStakeholderBirthday.DataSource = ds;
            gdStakeholderBirthday.DataBind();

        }
        protected void cmbStakeHolderId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}