using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraReports;
using Reports.Stock;

using DevExpress.XtraReports.UI;
using System.Data;

namespace StakeholderManagement
{
    public partial class Stock : System.Web.UI.Page
    {

        rptStocks report = new rptStocks();

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

                if (Session["isclick"] == "1")
                {
                    rptUsers.Report = CreateReport();
                }

            }


        }

        public XtraReport CreateReport()
        {
            try
            {
                report.CreateDocument();

            }
            catch (Exception ex)
            {
            }

            return report;
        }

        protected void ddlFitnessType_SelectedIndexChanged(object sender, EventArgs e)
        {
           
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