using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StakeholderManagement
{
    public partial class Notification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public void UpdateNotifications()
        {


            NotificationSave.UpdateParameters["StakeHolderType"].DefaultValue = Convert.ToInt32(cmbStakeholder.Value).ToString();
            NotificationSave.UpdateParameters["Type"].DefaultValue = Convert.ToInt32(cmbNotificationType.Value).ToString();


            NotificationSave.UpdateParameters["Subject"].DefaultValue = txtSubject.Text;

            NotificationSave.UpdateParameters["Email"].DefaultValue = txtMemo.Text;

            NotificationSave.UpdateParameters["SMS"].DefaultValue = txtSMS.Text;


            NotificationSave.Update();

        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateNotifications();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message", "alert('" + "Notification Sent." + "');", true);
                return;
            }
            catch (Exception ex)
            {

            }

        }

        protected void cmbNotificationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNotificationType.SelectedItem.Text == "Email")
            {
                Email.Visible = true;
                txtSMS.Visible = false;
                lblMessage.Visible = false;
            }
            else
            {
                Email.Visible = false;
                txtSMS.Visible = true;
                lblMessage.Visible = false; 
            }
        }
    }
}