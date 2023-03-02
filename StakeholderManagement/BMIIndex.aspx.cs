using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraReports;
using Reports.UserWiseGoals;
using DevExpress.XtraReports.UI;
using System.Data;

namespace StakeholderManagement
{
    public partial class BMIIndex : System.Web.UI.Page
    {

        rptUserWiseGoals report = new rptUserWiseGoals();

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
            }
            if (Session["isclick"] == "1")
            {
                rptUsers.Report = CreateReport();
            }

        }

        public XtraReport CreateReport()
        {

            try
            {

                report.UserId.Value = Convert.ToInt32(ddlFitnessType.Value);
                report.CreateDocument();

            }
            catch (Exception ex)
            {
            }

            return report;
        }

        protected void ddlFitnessType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsASOAcc = new DataSet();
            if (ddlFitnessType.SelectedItem == null)
            {
                string script = "alert(\"Please Select a Fitness Type\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                return;
            }
            else
            {

            }
        }

        protected void cmbStakeHolderId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        protected void dtFromDate_DateChanged(object sender, EventArgs e)
        {

        }

        protected void dtToDate_DateChanged(object sender, EventArgs e)
        {


        }

        protected void cmbStakeHolderId_Init(object sender, EventArgs e)
        {

        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            Session["isclick"] = "1";
            rptUsers.Report = CreateReport();
        }
    }
}