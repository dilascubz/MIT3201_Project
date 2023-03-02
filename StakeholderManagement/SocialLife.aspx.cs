using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLLRMS;
using System.Data;
using System.Net;



using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

using SD = System.Drawing;
using DevExpress.Web;

namespace StakeholderManagement
{
    public partial class SocialLife : System.Web.UI.Page
    {

        BLLNotification BLLFeedback = new BLLNotification();
        BLLSocial objSocial = new BLLSocial();
        BLLFeedback objfeedback = new BLLFeedback();
        byte[] Attachmentbytes = null;
        UploadedFile uploadedAttachment;



        public string UserImage = "/images/DP/dummy.png";
        string USerName = "admin";
        public string UserId = "";

        BLLUserCategory bLLUserCategory = new BLLUserCategory();
        private BLLSignUp objBLLSignUp = new BLLSignUp();
        private UserConfig objUserConfig = new UserConfig();
        DataTable dtUserDetails = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserId"] != null)
                {
                    if (!IsPostBack)
                    {
                        LoadUserDetails();

                    }
                    //txtEmail.Enabled = false;
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }

            }
            catch (Exception ex)
            {
                DevExpress.Web.ASPxWebControl.RedirectOnCallback("Login.aspx");
            }
        }



        public void LoadUserDetails()
        {
            DataView viewUserDetails = (DataView)srsUserDetailsGenerator.Select(DataSourceSelectArguments.Empty);
            dtUserDetails = viewUserDetails.ToTable();

            DataRow dr = dtUserDetails.Rows[0];

            imgViewer.ContentBytes = (byte[])dr["Image"];
            txtcomment.Text = dr["Description"].ToString();




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
            int i = objSocial.UpdateComments(Convert.ToInt32(Session["SocialId"].ToString()), userComments.Text, Session["UserId"].ToString());


            if (i > 0)
            {
                ScriptManager.RegisterClientScriptBlock(btnSearch, btnSearch.GetType(), "message", "alert('" + "Succesfully Added" + "');", true);
                userComments.Text = "";
                return;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + "Error occured.Please try again." + "'); window.location='Login.aspx';", true);
            }


        }

        protected void cmbExerciseMode_SelectedIndexChanged(object sender, EventArgs e)
        {

            //DataSet dsExercises;
            //dsExercises = objfeedback.GetExercisesType(1,Convert.ToInt32(cmbExerciseMode.SelectedItem.Value));
            //gdExercises.DataSource = dsExercises;
            //gdExercises.DataBind();


        }

    }
}