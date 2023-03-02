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
    public partial class ForgetPassword : System.Web.UI.Page
    {
        private static BLLSignUp objBLLUsers = new BLLSignUp();
        //  private static BLLCommonFunctions objBLLCommonFunctions = new BLLCommonFunctions();
        private UserConfig objUserConfig = new UserConfig();
        private BLLForgetPassword objBLLForgetPassword = new BLLForgetPassword();

        protected void Page_Load(object sender, EventArgs e)
        {

            //if (!IsPostBack)
            //{
            //    Session["Username"] = null;
            //    Session["code"] = null;
            //    txtVerificationCode.Enabled = false;
            //    btnNext.Visible = false;
            //}

            //if (Page.IsPostBack == true)
            //{`
            //    if (tbNewPassword.Text != null)
            //    {
            //        string password = tbNewPassword.Text;
            //        tbNewPassword.ClientSideEvents.Init = "function(s, e) {s.SetText('" + password + "');}";
            //    }

            //    if (tbConfirmNewPassword.Text != null)
            //    {
            //        string passwordConfirm = tbConfirmNewPassword.Text;
            //        tbConfirmNewPassword.ClientSideEvents.Init = "function(s, e) {s.SetText('" + passwordConfirm + "');}";
            //    }
            //}

            //if (!IsPostBack)
            //{
            //    Session["Username"] = null;
            //    Session["code"] = null;
            //    txtVerificationCode.Enabled = false;
            //    btnNext.Visible = false;
            //}
        }


        protected void btnSendCode_Click(object sender, EventArgs e)
        {
            int VerificationCode;
            if (objBLLForgetPassword.CheckUser(txtUserName.Text).Tables[0].Rows.Count > 0)
            {
                VerificationCode = GenerateRandomNo();
                txtVerificationCode.Enabled = true;
                txtUserName.Enabled = false;
                btnSendCode.Visible = false;
                btnNext.Visible = true;
                objBLLForgetPassword.SendVerificationCode(txtUserName.Text, VerificationCode);
                Session["Username"] = txtUserName.Text;
                Session["code"] = VerificationCode;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(btnSendCode, btnSendCode.GetType(), "message", "alert('" + "Username is incorrect." + "');", true);
                txtUserName.Focus();
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (txtVerificationCode.Text == Session["code"].ToString())
            {
                Response.Redirect(Server.UrlEncode("ChangePassword.aspx"));
            }
        }

        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        protected void gdAccounts_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

        }

        protected void gdAccounts_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

        }

        protected void gdUsers_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

        }

        protected void gdUsers_RowInserting1(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

        }
    }
}
