using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLLRMS;

namespace StakeholderManagement
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        BLLChangePassword objPassword = new BLLChangePassword();
        UserConfig objUser = new UserConfig();

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

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtPassword.Text == txtPasswordConfirm.Text)
            {

                int i = objPassword.ChangePassword(Session["Username"].ToString(), objUser.EncryptStringF(txtPassword.Text));
                if (i > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + "Password changed successfully." + "'); window.location='Login.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + "Error occured.Please try again." + "'); window.location='Login.aspx';", true);
                }


            }

        }
    }
}