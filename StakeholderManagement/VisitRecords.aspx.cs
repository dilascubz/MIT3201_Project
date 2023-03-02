using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLLRMS;
using DevExpress.Web.Bootstrap;

namespace StakeholderManagement
{
    public partial class VisitRecords : System.Web.UI.Page
    {
        private BLLNotification bLLNotification = new BLLNotification();
        private BLLSecurity bLLSecurity = new BLLSecurity();
        protected void Page_Load(object sender, EventArgs e)
        {



            if (Session["UserId"] is null)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (Page.IsPostBack == false)
            {

                BindASO();

                if (dtToDate.Date == null)
                {
                    dtToDate.Date = DateTime.Now;
                }
                if (dtFromDate.Date == null)
                {
                    dtFromDate.Date = DateTime.Now;
                }

            }

            else
            {


                if (dtToDate.Date == null)
                {
                    dtToDate.Date = DateTime.Now;



                }
                if (dtFromDate.Date == null)
                {
                    dtFromDate.Date = DateTime.Now;
                }
            }

        }


        private void BindASO()
        {
            try
            {


                if (Convert.ToInt32(Session["ASOAcc"]) > 0)
                {


                }


                var dsDistASO = new DataSet();
                int UserAccId = 0;
                dsDistASO = bLLNotification.GetAllActiveASO(Convert.ToInt32(Session["UserCategoryId"]), Convert.ToInt32(Session["ASOAcc"]));



                cmbASO.Items.Clear();
                if (dsDistASO is object)
                {
                    if (dsDistASO.Tables[0].Rows.Count != 0)
                    {

                        if (dsDistASO.Tables[0].Rows.Count == 1)
                        {
                            cmbASO.TextField = "Name";
                            cmbASO.ValueField = "Id";
                            cmbASO.DataSource = dsDistASO;
                            cmbASO.DataBind();
                           // cmbASO.Items.Insert(0, new BootstrapListEditItem("Select One", 0));

                            // cmbStakeHolderId.Items.Insert(0, new ListItem("Select one", 0));
                        }

                        else
                        {

                            cmbASO.TextField = "Name";
                            cmbASO.ValueField = "Id";
                            cmbASO.DataSource = dsDistASO;
                            cmbASO.DataBind();
                            cmbASO.Items.Insert(0, new BootstrapListEditItem("Select One", 0));
                        }
                        // cmbStakeHolderId.Items.Insert(0, new ListItem("Select one", 0));
                    }
                    else
                    {
                        dsDistASO = null;
                        cmbASO.Items.Insert(0, new BootstrapListEditItem("Select one", 0));

                        //  ddlDistributor.Items.Insert(0, new ListItem("Select one", 0));
                    }
                }
                else
                {
                    dsDistASO = null;
                    cmbASO.Items.Insert(0, new BootstrapListEditItem("Select one", 0));

                    //  ddlDistributor.Items.Insert(0, new ListItem("Select one", 0));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "message", "alert('" + ex.Message + "');", true);
            }
        }


        private void BindUserRecords()
        {
            try
            {
                int StakeHolderTypeId;

                if (Convert.ToInt32(cmbStakeHolderType.SelectedItem.Value) == 0)
                {
                    StakeHolderTypeId = 0;
                }
                else
                {
                    StakeHolderTypeId = Convert.ToInt32(cmbStakeHolderType.SelectedItem.Value);
                }


                var dsDist = new DataSet();
                int UserAccId = 0;
                dsDist = bLLNotification.GetVisitRecords(Convert.ToInt32(Session["UserCategoryId"]), Convert.ToInt32(Session["ASOAcc"]), StakeHolderTypeId);



                cmbStakeHolderId.Items.Clear();
                if (dsDist is object)
                {
                    if (dsDist.Tables[0].Rows.Count != 0)
                    {
                        cmbStakeHolderId.TextField = "FullName";
                        cmbStakeHolderId.ValueField = "Id";
                        cmbStakeHolderId.DataSource = dsDist;
                        cmbStakeHolderId.DataBind();
                        cmbStakeHolderId.Items.Insert(0, new BootstrapListEditItem("Select All", 0));

                        // cmbStakeHolderId.Items.Insert(0, new ListItem("Select one", 0));
                    }
                    else
                    {
                        dsDist = null;
                        cmbStakeHolderId.Items.Insert(0, new BootstrapListEditItem("Select one", 0));

                        //  ddlDistributor.Items.Insert(0, new ListItem("Select one", 0));
                    }
                }
                else
                {
                    dsDist = null;
                    cmbStakeHolderId.Items.Insert(0, new BootstrapListEditItem("Select one", 0));

                    //  ddlDistributor.Items.Insert(0, new ListItem("Select one", 0));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "message", "alert('" + ex.Message + "');", true);
            }
        }


        protected void gdVisitRecords_CellEditorInitialize(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewEditorEventArgs e)
        {

        }

        protected void gdVisitRecords_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

        }

        protected void gdVisitRecords_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

        }


        protected void cmbStakeHolderId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["UserId"] is null)
            {
                Response.Redirect("Login.aspx");
            }
        }


        public void BindGrid()
        {

            if (cmbStakeHolderId.SelectedItem == null)
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

            DataSet ds = bLLNotification.GetVisitDetails(dtFromDate.Date.ToString(), dtToDate.Date.ToString(), Convert.ToInt32(cmbStakeHolderId.SelectedItem.Value));
            gdVisitRecords.DataSource = ds;
            gdVisitRecords.DataBind();

        }

        protected void dtpFromDate_DateChanged(object sender, EventArgs e)
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




        protected void dtpToDate_DateChanged(object sender, EventArgs e)
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

        protected void gdVisitRecords_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

        }

        protected void gdVisitRecords_CommandButtonInitialize(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewCommandButtonEventArgs e)
        {

        }

        protected void gdVisitRecords_CommandButtonInitialize1(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewCommandButtonEventArgs e)
        {

        }

        protected void btnVisits_Click(object sender, EventArgs e)
        {
            if (cmbASO.SelectedItem == null)
            {

                return;
            }


            BindGrid();

        }



        protected void cmbStakeHolderId_Init(object sender, EventArgs e)
        {

            //cmbStakeHolderId.Items.Insert(0, new BootstrapListEditItem("Select one", 0));
            //cmbStakeHolderId.DataBind();

        }

        protected void cmbASO_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbASO.SelectedItem == null)
            //{
            //    string script = "alert(\"Please Select as ASO\");";
            //    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            //}
            //else
            //{
            //    (Session["ASOAcc"]) = Convert.ToInt32(cmbASO.SelectedItem.Value);
            //    BindUserRecords();
            //}

        }

        protected void cmbStakeHolderType_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataSet dsASOAcc = new DataSet();
            if (cmbStakeHolderType.SelectedItem == null)
            {
                string script = "alert(\"Please Select an ASO\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                return;
            }
            else
            {
                dsASOAcc = bLLSecurity.GetASOUserAccId(Convert.ToInt32(cmbASO.SelectedItem.Value));
                Session["ASOAcc"] = dsASOAcc.Tables[0].Rows[0]["Id"];
             //   (Session["ASOAcc"]) = Convert.ToInt32(cmbASO.SelectedItem.Value);
                BindUserRecords();
            }

        }
    }
}