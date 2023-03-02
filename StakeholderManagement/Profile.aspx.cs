using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLLRMS;
using DevExpress.Web;
using StakeholderManagement.ServiceReference1;

using System.Data;
using System.Data.SqlClient;

using SD = System.Drawing;

namespace StakeholderManagement
{
    public partial class Profile : System.Web.UI.Page
    {
        byte[] Attachmentbytes = null;
        UploadedFile uploadedAttachment;


        public String username = "promotionexecutive@ceylonsteel.com";
        public String password = "Mkt@#123";

        public string UserImage = "/images/DP/dummy.png";
        string USerName = "admin";
        public string UserId = "";

        BLLUserCategory bLLUserCategory = new BLLUserCategory();
        private BLLSignUp objBLLSignUp = new BLLSignUp();
        private UserConfig objUserConfig = new UserConfig();
        DataTable dtUserDetails = new DataTable();


        BulkSMSClient bulkSMS = new BulkSMSClient();
        public const string constring = "Data Source = 10.5.2.221; Initial Catalog = CSCL_Health; Persist Security Info=True;User ID = SFATestUser; Password=57Twq5TBR8PFJAJv";
     
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


        public string UpdateCreatedCustomers(int SalesRepAccId)
        {



            //HttpRequestMessage request = new System.Net.Http.HttpRequestMessage();
            SqlConnection con = new SqlConnection(constring);
            try
            {



//                SqlCommand com = new SqlCommand(SQL, con);



                SqlCommand cmd = new SqlCommand("sp_Add_contact10", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SalesRepAccId", SqlDbType.Int).Value = SalesRepAccId;


                // com.Parameters.AddWithValue("@wareHouseId", SalesRepAccId);
               



                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    // Common.TransSuceeded = true;
                    // return request.CreateResponse(HttpStatusCode.Created);
                    return "true";
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    return "false";
                    //Common.TransSuceeded = false;
                  //  return request.CreateResponse(HttpStatusCode.BadRequest);

                }
                finally
                {
                    con.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static byte[] ImageToByte(System.Drawing.Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }


     
        public void sendBulk()
        {
            //invoke business method
            sms sms = new sms();
            sms.account_no = "42050491";
            sms.username = username;
            sms.password = password;
            sms.send_id = "94706790201";           //94706790201
            sms.language = "1";
            sms.sms_content = "Hii";
            sms.bulk_start_date = "2021-12-16 13:05:50";
            sms.bulk_end_date = "2021-12-18 11:35:50";
            sms.campaign_name = "CSCL";
            String[] numList = new string[1];
            numList[0] = "0769734149";
            sms.number_list = numList;
            sms.add_block_notification = "";


            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "message", "alert('" + bulkSMS.SendBulk(sms) + "');", true);

            //    Console.WriteLine("SendBulk ::" + bulkSMS.SendBulk(sms));
            //  Console.Read();
        }



        public void LoadUserDetails()
        {
            DataView viewUserDetails = (DataView)SqlDataUserDetails.Select(DataSourceSelectArguments.Empty);
            dtUserDetails = viewUserDetails.ToTable();

            DataRow dr = dtUserDetails.Rows[0];
            txtFirstName.Text = dr["FName"].ToString();
            txtLastName.Text = dr["LName"].ToString();
            txtAddress1.Text = dr["AddressLine"].ToString();
            dtDOB.Value = dr["DOB"].ToString();
            txtEmail.Text = dr["Email"].ToString();
            txtTelephone.Text = dr["MobileNo"].ToString();
            txtHeight.Text = dr["Height"].ToString();
            txtWeight.Text = dr["Weight"].ToString();


            //txtAcc.Text = dr["BankAcc"].ToString();
            //txtWorkAddress.Text = dr["WorkAddress"].ToString();
            //spWorkEx.Value = dr["WorkExperience"].ToString();

            cmbStakeHolderType.Value = dr["FitnessTypeId"].ToString();

            if (dr["UserImage"] != null)
            {
                //  imgViewer.ContentBytes = (byte[])dr["UserImage"];
            }

            if (dr["GPSLat"].ToString() != "" || dr["GPSLong"].ToString() != "")
            {
                txtLat.Text = dr["GPSLat"].ToString();
                txtLong.Text = dr["GPSLong"].ToString();
            }
            else
            {
                txtLat.Text = "6.9240";
                txtLong.Text = "79.8604";
            }

            NonHomeOwner.Visible = false;

            HomeOwner.Visible = true;
            //if (dr["FitnessTypeId"].ToString() == "1")
            //{
            //    NonHomeOwner.Visible = false;

            //    HomeOwner.Visible = true;
            //    cmbStakeHolderType.Enabled = false;

            //    txtDesignation.Value = dr["Designation"].ToString();
            //    txtWorkAddress .Value = dr["Designation"].ToString();


            //}
            //else
            //{
            //    NonHomeOwner.Visible = true;
            //    HomeOwner.Visible = false;

            //    cmbStakeHolderType.Enabled = true;


            //}
        }



        public void UpdateUserDetails()
        {
            if (Attachmentbytes == null)
            {
                string resultFilePath = Server.MapPath("~/assets/images/no-image.gif");
                Bitmap bitmap = new Bitmap(resultFilePath);
                Attachmentbytes = ImageToByte(bitmap);
            }

            SqlDataUserDetails.UpdateParameters["StakeholderId"].DefaultValue = Session["UserId"].ToString();
            SqlDataUserDetails.UpdateParameters["firstName"].DefaultValue = txtFirstName.Text;
            SqlDataUserDetails.UpdateParameters["LastName"].DefaultValue = txtLastName.Text;
            SqlDataUserDetails.UpdateParameters["AddressLine1"].DefaultValue = txtAddress1.Text;

            SqlDataUserDetails.UpdateParameters["FitnessTypeId"].DefaultValue = cmbStakeHolderType.Value.ToString();
            SqlDataUserDetails.UpdateParameters["Email"].DefaultValue = txtEmail.Text.ToString();
            SqlDataUserDetails.UpdateParameters["MobileNo"].DefaultValue = txtTelephone.Text;
            SqlDataUserDetails.UpdateParameters["DOB"].DefaultValue = dtDOB.Value.ToString();
            SqlDataUserDetails.UpdateParameters["Height"].DefaultValue = txtHeight.Text;
            SqlDataUserDetails.UpdateParameters["Weight"].DefaultValue = txtWeight.Text;
            SqlDataUserDetails.UpdateParameters["BankBranch"].DefaultValue = txtWeight.Text;
            SqlDataUserDetails.UpdateParameters["WorkAddress"].DefaultValue = txtWorkAddress.Text;
            //    SqlDataUserDetails.UpdateParameters["WorkExperience"].DefaultValue = spWorkEx.Value.ToString();
            SqlDataUserDetails.UpdateParameters["WorkEducational"].DefaultValue = "";
            SqlDataUserDetails.UpdateParameters["GPSlat"].DefaultValue = txtLat.Text;
            SqlDataUserDetails.UpdateParameters["GPSLong"].DefaultValue = txtLong.Text;



            SqlDataUserDetails.UpdateParameters["Image"].DefaultValue = Attachmentbytes.ToString();

            SqlDataUserDetails.Update();

        }

        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            {
                Response.Redirect("~/Default.aspx");
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

        private MemoryStream BytearrayToStream(byte[] arr)
        {
            return new MemoryStream(arr, 0, arr.Length);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtWeight.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(btnSave , btnSave.GetType(), "message", "alert('" + "Please Enter the Weight" + "');", true);
                return; 
            }


            if (txtHeight.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, btnSave.GetType(), "message", "alert('" + "Please Enter the Height" + "');", true);
                return;
            }

            UpdateUserDetails();
            LoadUserDetails();



            string strPage = "Default.aspx"; // getting page url from web.config;

            string scriptText = "alert('Sucessfully Saved.'); window.location='" + Request.ApplicationPath + strPage + "'";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message!", scriptText, true);


        }


        public static string GPSlat;
        public static string GPSlong;
        [WebMethod]
        public static void SendGPSCordinates(string plat, string plong)
        {

            GPSlat = plat;
            GPSlong = plong;

        }

        protected void imgViewer_ValueChanged(object sender, EventArgs e)
        {

        }

        protected void ImgUploader_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            try
            {
                uploadedAttachment = e.UploadedFile;

                using (System.IO.Stream fs = uploadedAttachment.FileContent)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        Attachmentbytes = br.ReadBytes((Int32)fs.Length);
                    }
                }

                USerName = Session["UserName"].ToString();
                UserId = Session["UserId"].ToString();
                string serverPath = HttpContext.Current.Server.MapPath("~/");
                UploadedFile uploadedFile = e.UploadedFile;
                string fileName = uploadedFile.FileName;
                string resultExtension = Path.GetExtension(fileName);
                string resultFileName = Path.ChangeExtension(Path.GetRandomFileName(), resultExtension);

                string FileWithPat = serverPath + @"images/DP/" + USerName + uploadedFile.FileName;

                // string resultFileUrl = "~/Editors/UploadImages/" + resultFileName;
                //string resultFilePath = MapPath(resultFileUrl);

                uploadedFile.SaveAs(FileWithPat);
                SD.Image img = SD.Image.FromFile(FileWithPat);
                SD.Image img1 = RezizeImage(img, 151, 150);
                img1.Save(FileWithPat);
                if (File.Exists(FileWithPat))
                {
                    FileInfo fi = new FileInfo(FileWithPat);
                    string ImageName = fi.Name;
                    string query = "update HealthUser set UserImageString='" + ImageName + "' where UserId='" + UserId + "'";
                    if (bLLUserCategory.ExcuteQuery(query))
                        UserImage = "images/DP/" + ImageName;
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "message", "alert('" + ex.ToString() + "');", true);
            }
        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserPasswordchange.aspx");
        }

    }
}