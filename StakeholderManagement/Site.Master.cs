using BLLRMS;
using DevExpress.Web;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Web;
using System.Web.UI;
using SD = System.Drawing;

namespace StakeholderManagement
{
    public partial class SiteMaster : MasterPage
    {

        BLLUserCategory bLLUserCategory = new BLLUserCategory();
        private BLLSecurity objbllsecurity = new BLLSecurity();

        public string UserImage = "/images/DP/dummy.png";
        string USerName = "admin";
        public string Promotions = "";
        public string Logins = "";
        public string MyProfile = "";

        public string BMIIndex = "";
        

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
                USerName = Session["UserName"].ToString();
                string[] tokens = USerName.Split(' ');
                USerName = tokens[0];
                lbluser.Text = USerName;
                GetUserImage(USerName);
                GetUserBMI(USerName);
                Promotions = "New Promotion ABC is added";
                //BMIIndex = "";
                Logins = "Log Out";
                LoadMenuByUserCategoryAccess();
            }
        }

        public void GetUserImage(string Username)
        {
            if (Username != null)
            {
                string query = "select UserImageString from HealthUser where FName='" + Username + "'";

                string ImageName = bLLUserCategory.GetQuery(query, "UserImageString");
                if (ImageName != "")
                    UserImage = "images/DP/" + ImageName;
            }
        }
        public void GetUserBMI(string Username)
        {
            if (Username != null)
            {
                string query = "select BMIIndex from HealthUser where FName='" + Username + "'";

                string BMI = bLLUserCategory.GetQuery(query, "BMIIndex");
                if (BMI != "")
                    BMIIndex =  BMI;
            }
        }

        public void GetBMIIndex(string Username)
        {
            if (Username != null)
            {
                string query = "select BMIIndex from HealthUser where FName='" + Username + "'";

                string BMValue = bLLUserCategory.GetQuery(query, "UserImageString");
                if (BMValue != "")
                    BMIIndex = BMValue;
            }
        }

        private SD.Image RezizeImage(SD.Image img, int maxWidth, int maxHeight)
        {
            if (img.Height < maxHeight && img.Width < maxWidth) return img;
            using (img)
            {
                Double xRatio = (double)img.Width / maxWidth;
                Double yRatio = (double)img.Height / maxHeight;
                Double ratio = Math.Max(xRatio, yRatio);
                int nnx = (int)Math.Floor(img.Width / ratio);
                int nny = (int)Math.Floor(img.Height / ratio);
                Bitmap cpy = new Bitmap(nnx, nny, SD.Imaging.PixelFormat.Format32bppArgb);
                using (Graphics gr = Graphics.FromImage(cpy))
                {
                    gr.Clear(Color.Transparent);

                    // This is said to give best quality when resizing images
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    gr.DrawImage(img,
                        new Rectangle(0, 0, nnx, nny),
                        new Rectangle(0, 0, img.Width, img.Height),
                        GraphicsUnit.Pixel);
                }
                return cpy;
            }

        }

        private void LoadMenuByUserCategoryAccess()
        {
            int UserCategoryId = Convert.ToInt32(Session["UserCategoryId"].ToString());

            if (UserCategoryId == 3)
            {
                MyProfile = "My Profile";
            }
            else
            {
                MyProfile = "";
            }

            DataSet dsMenuItems = null;
            string menuName = "";
            dsMenuItems = objbllsecurity.GetMenuByUserCategoryAccess(UserCategoryId);

            if (dsMenuItems.Tables[0].Rows.Count != 0)
            {
                for (int j = 0; j <= dsMenuItems.Tables[0].Rows.Count - 1; j++)
                {
                    menuName = dsMenuItems.Tables[0].Rows[j]["Menu"].ToString();
                    TopMenuLink.Items.FindByName(menuName).Visible = true;
                }
            }
        }


        private MemoryStream BytearrayToStream(byte[] arr)
        {
            return new MemoryStream(arr, 0, arr.Length);
        }

        protected void btnChat_Click(object sender, EventArgs e)

        {
            if (Session["UserId"] != null)
            {


            }


            if (Page.IsCallback)
                ASPxWebControl.RedirectOnCallback("~/UserChat.aspx");



            //Response.Redirect("UserChat.aspx", true);
        }
    }
}