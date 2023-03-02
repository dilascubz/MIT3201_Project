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

using SD = System.Drawing;

namespace StakeholderManagement
{
    public partial class Visits : System.Web.UI.Page
    {
        byte[] Attachmentbytes = null;
        UploadedFile uploadedAttachment;

        public string UserImage = "/images/DP/dummy.png";
        string USerName = "admin";
        public string UserId = "";
        string RequestId = "";

        BLLUserCategory bLLUserCategory = new BLLUserCategory();
        private BLLSignUp objBLLSignUp = new BLLSignUp();
        private UserConfig objUserConfig = new UserConfig();
        DataTable dtUserDetails = new DataTable();
        DataTable dtcon = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (Session["UserId"] != null)
                {
                    if (!IsPostBack)
                    {


                        LoadUserDetails();
                        cmbCustomer.Visible = false;
                        lblCustomer.Visible = false;

                        //   LoadConfig();
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




        public static byte[] ImageToByte(System.Drawing.Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }



        public void LoadUserDetails()
        {
            DataView viewUserDetails = (DataView)SqlGetIdwise.Select(DataSourceSelectArguments.Empty);
            dtUserDetails = viewUserDetails.ToTable();
            //SreGetUserDetailsByRetailerId

            DataRow dr = dtUserDetails.Rows[0];
            txtFirstName.Text = dr["FName"].ToString();
            txtLastName.Text = dr["LName"].ToString();


            txtAddress1.Text = dr["AddressLine1"].ToString();
            txtAddress2.Text = dr["AddressLine2"].ToString();
            txtAddress3.Text = dr["AddressLine3"].ToString();
            dtDOB.Value = dr["DOB"].ToString();


            txtEmail.Text = dr["Email"].ToString();
            txtTelephone.Text = dr["MobileNo"].ToString();

            txtBankName.Text = dr["BankName"].ToString();
            txtBranch.Value = dr["BankBranch"].ToString();
            txtAcc.Text = dr["BankAcc"].ToString();
            txtWorkAddress.Text = dr["WorkAddress"].ToString();


            spWorkEx.Value = dr["WorkExperience"].ToString();
            txtWorkEducational.Text = dr["Educational"].ToString();
            cmbStakeHolderType.Value = dr["StakeHolderTypeId"].ToString();

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



        }

        private void LoadConfig()
        {
            DataView ConfigDetails = (DataView)SqlConfig.Select(DataSourceSelectArguments.Empty);
            dtcon = ConfigDetails.ToTable();

            if (dtcon.Rows.Count > 0)
            {
                if (dtcon.Rows.Count > 0)
                {
                    RequestId = dtcon.Rows[0]["OrderNo"].ToString();
                }
            }
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
            SqlDataUserDetails.UpdateParameters["AddressLine2"].DefaultValue = txtAddress2.Text;
            SqlDataUserDetails.UpdateParameters["AddressLine3"].DefaultValue = txtAddress3.Text;
            SqlDataUserDetails.UpdateParameters["StakeHolderTypeId"].DefaultValue = cmbStakeHolderType.Value.ToString();
            SqlDataUserDetails.UpdateParameters["Email"].DefaultValue = txtEmail.Text.ToString();
            SqlDataUserDetails.UpdateParameters["MobileNo"].DefaultValue = txtTelephone.Text;
            SqlDataUserDetails.UpdateParameters["DOB"].DefaultValue = dtDOB.Value.ToString();

            SqlDataUserDetails.UpdateParameters["BankName"].DefaultValue = txtBankName.Text;
            SqlDataUserDetails.UpdateParameters["BankAcc"].DefaultValue = txtAcc.Text;
            SqlDataUserDetails.UpdateParameters["BankBranch"].DefaultValue = txtBranch.Text;

            SqlDataUserDetails.UpdateParameters["WorkAddress"].DefaultValue = txtWorkAddress.Text;
            //SqlDataUserDetails.UpdateParameters["WorkExperience"].DefaultValue = spWorkEx.Value.ToString();
            SqlDataUserDetails.UpdateParameters["WorkEducational"].DefaultValue = txtWorkEducational.Text.ToString();
            SqlDataUserDetails.UpdateParameters["GPSlat"].DefaultValue = txtLat.Text;
            SqlDataUserDetails.UpdateParameters["GPSLong"].DefaultValue = txtLong.Text;


            SqlDataUserDetails.UpdateParameters["OtherEducational"].DefaultValue = txtOtherEducational.Text;
            SqlDataUserDetails.UpdateParameters["Image"].DefaultValue = Attachmentbytes.ToString();

            SqlDataUserDetails.Update();

        }




        public void InsertVisitStatus()
        {
            LoadConfig();
            int CustomerId = 0;
            SqlGetIdwise.InsertParameters["VisitDetailNo"].DefaultValue = RequestId;
            SqlGetIdwise.InsertParameters["UserId"].DefaultValue = Session["StakeId"].ToString();

            SqlGetIdwise.InsertParameters["ASOAccId"].DefaultValue = Session["ASOAcc"].ToString();
            SqlGetIdwise.InsertParameters["VisitRemarkId"].DefaultValue = cmbVisitStatus.SelectedItem.Value.ToString();

            if (cmbVisitStatus.SelectedItem == null)
            {


                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message", "alert('" + "Please Select a Visit Remark " + "')", true);
                return;




            }

            if (cmbVisitStatus.SelectedItem.Text == "Successful")
            {

                if (cmbCustomer.SelectedItem == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message", "alert('" + "Please Select a Customer " + "')", true);
                    return;

                }

                CustomerId = Convert.ToInt32(cmbCustomer.SelectedItem.Value.ToString());
            }
            else
            {
                CustomerId = 0;
            }

            SqlGetIdwise.InsertParameters["CustomerId"].DefaultValue = CustomerId.ToString();
            SqlGetIdwise.Insert();

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
                Response.Redirect("~/UserAccounts.aspx");
            }

        }


        public void GetUserImage(string Username)
        {
            if (Username != null)
            {
                string query = "select UserImageString from stakeholder where FName='" + Username + "'";

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
            UpdateUserDetails();
            InsertVisitStatus();
            LoadUserDetails();

            string strPage = "Default.aspx"; // getting page url from web.config;

            string scriptText = "alert('Sucessfully Saved.'); window.location='" + Request.ApplicationPath + strPage + "'";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message!", scriptText, true);
            //txtCity.Text = GPSlat;

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
                    string query = "update Stakeholder set UserImageString='" + ImageName + "' where UserId='" + UserId + "'";
                    if (bLLUserCategory.ExcuteQuery(query))
                        UserImage = "images/DP/" + ImageName;
                }


                //UploadingUtils.RemoveFileWithDelay(resultFileName, resultFilePath, 5);
                //string url = ResolveClientUrl(resultFileUrl);
                //var sizeInKilobytes = uploadedFile.ContentLength / 1024;
                //string sizeText = sizeInKilobytes.ToString() + " KB";
                //e.CallbackData = fileName + "|" + url + "|" + sizeText

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "message", "alert('" + ex.ToString() + "');", true);
            }
        }


        protected void cmbVisitStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVisitStatus.SelectedItem.Text == "Successful")
            {
                cmbCustomer.Visible = true;
                lblCustomer.Visible = true;

            }
            else
            {
                cmbCustomer.Visible = false;
                lblCustomer.Visible = false;
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

            {
                Response.Redirect("~/UserAccounts.aspx");
            }
        }
    }
}
