
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLLRMS;

namespace StakeholderManagement
{
    public partial class UserChat : System.Web.UI.Page
    {
        public string UserName = "Scubz";
        //   public string UserName = "admin";
        public string UserImage = "~/assets/images/no-image.gif";
        // ConnClass ConnC = new ConnClass();

        public string UserId = "";
        BLLUserCategory bLLUserCategory = new BLLUserCategory();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                if (!IsPostBack)
                {
                    if (Session["UserName"] != null)
                    {
                        UserName = Session["UserName"].ToString();
                        UserId = Session["UserId"].ToString();
                        GetUserImage(UserName);
                    }
                    else
                        Response.Redirect("Login.aspx");


                }


                //txtEmail.Enabled = false;
            }
            else
            {
                Response.Redirect("~/Login.aspx");

            }

        }
        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
        protected void btnChangePicModel_Click(object sender, EventArgs e)
        {


        }

        public void GetUserImage(string Username)
        {
            if (Username != null)
            {
                string query = "select UserImageString from HealthUser where UserId='" + UserId + "'";

                string ImageName = bLLUserCategory.GetQuery(query, "UserImageString");
                if (ImageName != "")
                    UserImage = "images/DP/RangaRanga.jpg";
            }


        }





    }
}
