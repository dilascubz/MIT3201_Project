using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLLRMS;
using System.Data;
using System.Net;


namespace StakeholderManagement
{
    public partial class Exercises : System.Web.UI.Page
    {

        BLLNotification BLLFeedback = new BLLNotification();
        BLLFeedback objfeedback = new BLLFeedback();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                DevExpress.Web.ASPxWebControl.RedirectOnCallback("Login.aspx");
            }
        }





        protected void cmbStakeHolderType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmbStakeHolderId_Init(object sender, EventArgs e)
        {

        }

        protected void btnExercises_Click(object sender, EventArgs e)
        {

        }

        protected void gdVisitRecords_CellEditorInitialize(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewEditorEventArgs e)
        {

        }

        protected void gdVisitRecords_CommandButtonInitialize(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewCommandButtonEventArgs e)
        {

        }

        protected void cmbStakeHolderId_Init1(object sender, EventArgs e)
        {

        }

        protected void dtFromDate_DateChanged(object sender, EventArgs e)
        {

        }

        protected void dtToDate_DateChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            gdExercises.DataSource = "";
            gdExercises.DataBind();

            if (txtSearch.Text == "" || txtSearch.Text == null)
            {
                ScriptManager.RegisterClientScriptBlock(btnSearch, btnSearch.GetType(), "message", "alert('" + "Please Enter A Name" + "');", true);
                return;
            }

            DataSet dsExercises;

          
            dsExercises = objfeedback.GetExercises(txtSearch.Text);
            gdExercises.DataSource = dsExercises;
            gdExercises.DataBind();
        
        }

        protected void cmbExerciseMode_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataSet dsExercises;
            dsExercises = objfeedback.GetExercisesType(1,Convert.ToInt32(cmbExerciseMode.SelectedItem.Value));
            gdExercises.DataSource = dsExercises;
            gdExercises.DataBind();

        }

    }
}