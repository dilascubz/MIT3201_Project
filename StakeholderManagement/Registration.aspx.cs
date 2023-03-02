using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLLRMS;
using DevExpress.Web;
using System.IO;
using System.Web.Services;
using System.Drawing;
using System.Drawing.Drawing2D;
using SD = System.Drawing;
using StakeholderManagement.ServiceReference1;


using System.Data;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Net;

namespace StakeholderManagement
{
    public partial class Registration : System.Web.UI.Page
    {


        public string UserImage = "/images/DP/dummy.png";



        string USerName = "admin";
        byte[] Attachmentbytes = null;
        UploadedFile uploadedAttachment;

        private BLLUserCategory bLLUserCategory = new BLLUserCategory();
        private BLLSignUp objBLLRegister = new BLLSignUp();
        private UserConfig objUserConfig = new UserConfig();

        public String username;
        public String password;

        public String AccountNo;
        public String SendId;


        BulkSMSClient bulkSMS = new BulkSMSClient();

        DataTable dtSMSDetails;

        string StakeHolder = "";
        string latitude1 = "";
        string longitude1 = "";
        protected void Page_Load(object sender, EventArgs e)
        {


            if (IsPostBack == false)
            {
                Session["Panel"] = "0";
                txtUserName.Enabled = true;
                PanelVisibility();

            }


        }





        private void GetLatLongFromAddress(string url2)
        {
            try
            {
                string url = string.Format(url2);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                try
                {
                    string _byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());

                    WebResponse response = request.GetResponse();
                    XDocument xdoc = XDocument.Load(url);


                    XElement locationElement = xdoc.Element("GeocodeResponse").Element("result").Element("geometry").Element("location");
                    double latitude1 = (double)locationElement.Element("lat");
                    double longitude1 = (double)locationElement.Element("lng");
                    Session["pGPSLat"] = latitude1;
                    Session["pGPSLong"] = longitude1;

                }
                catch (System.Net.WebException exp)
                {

                }
            }
            catch (System.Net.WebException exp)
            {

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "message", "alert(' Please Provide a correct Address');", true);
            }
        }




        public void PanelVisibility()
        {



            if (Session["Panel"].ToString() == "0")
            {
                UserLogin.Visible = true;
                PersonalDetails.Visible = false;


                Social.Visible = false;
                AccountDetails.Visible = false;

            }


            if (Session["Panel"].ToString() == "1")
            {
                PersonalDetails.Visible = true;
                AccountDetails.Visible = false;
                UserLogin.Visible = false;
            }


            if (Session["Panel"].ToString() == "2")
            {
                PersonalDetails.Visible = false;
                AccountDetails.Visible = false;
                UserLogin.Visible = false;
            }


            if (Session["Panel"].ToString() == "3")
            {
                PersonalDetails.Visible = false;
                AccountDetails.Visible = false;
                UserLogin.Visible = false;
            }

            if (Session["Panel"].ToString() == "4")
            {
                PersonalDetails.Visible = false;

                AccountDetails.Visible = false;
                UserLogin.Visible = false;

            }


            if (Session["Panel"].ToString() == "5")
            {
                PersonalDetails.Visible = false;
                Social.Visible = false;
                AccountDetails.Visible = true;
                UserLogin.Visible = false;

            }


            if (Session["Panel"].ToString() == "6")
            {
                PersonalDetails.Visible = false;
                Social.Visible = false;

                AccountDetails.Visible = false;
                UserLogin.Visible = false;
            }


            if (Session["Panel"].ToString() == "7")
            {
                PersonalDetails.Visible = false;

                Social.Visible = true;

                AccountDetails.Visible = false;
                UserLogin.Visible = false;
            }
        }


        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
        public static string GPSlat;
        public static string GPSlong;



        [WebMethod]

        public string getLocation(string location)
        {


            return location;

        }

        [WebMethod]
        public static void SendGPSCordinates(string plat, string plong)
        {

            GPSlat = plat;
            GPSlong = plong;

        }

        protected void imgUploader_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            try
            {
                uploadedAttachment = e.UploadedFile;

                using (Stream fs = uploadedAttachment.FileContent)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        Attachmentbytes = br.ReadBytes((Int32)fs.Length);
                    }
                }

                USerName = txtUserName.Text;
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
                    string query = "update HealthUser set UserImageString='" + ImageName + "' where FName='" + USerName + "'";
                    if (bLLUserCategory.ExcuteQuery(query))
                        UserImage = "images/DP/" + ImageName;
                }



            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "message", "alert('" + ex.ToString() + "');", true);
            }

        }

        protected void btnPersonalNext_Click(object sender, EventArgs e)
        {
            Session["HNowner"] = "User";
            StakeHolder = "User";
            txtUserName.Text = txtemail.Text;
            txtUserName.Enabled = false;

            string value = HiddenField.Value;


            string value2 = Hidden2.Value;

            GPSlat = value;
            GPSlong = value2;


            if (objBLLRegister.CheckUser(" ", txtemail.Text).Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(btnSubmit, btnSubmit.GetType(), "message", "alert('" + "User Already registered !" + "');", true);
                txtemail.Focus();

                return;
            }
            Session["Panel"] = "7";
            PanelVisibility();
        }





        protected void nxt2_Click(object sender, EventArgs e)
        {
            if (StakeHolder != "Company")

                //string value2 = Hidden2.Value;

                Session["Panel"] = "5";

            PanelVisibility();
        }


        protected void prv2_Click(object sender, EventArgs e)
        {
            if (StakeHolder == "User")
            {
                Session["Panel"] = "1";
                PanelVisibility();
            }

        }

        protected void nxt3_Click(object sender, EventArgs e)
        {

            Session["Panel"] = "5";
            PanelVisibility();
        }
        protected void prv4_Click(object sender, EventArgs e)
        {
            if (StakeHolder == "User")
            {
                Session["Panel"] = "3";
                PanelVisibility();
            }
            else
                Session["Panel"] = "2";
            PanelVisibility();
        }

        protected void prv3_Click(object sender, EventArgs e)
        {
            if (StakeHolder != "Company")
            {
                Session["Panel"] = "1";
            }
            else
                Session["Panel"] = "2";




            PanelVisibility();

        }

        protected void nxt4_Click(object sender, EventArgs e)
        {
            txtUserName.Text = txtemail.Text;
            txtUserName.Enabled = false;
            Session["Panel"] = "5";
            PanelVisibility();
        }


        protected void btnHomeOwnernxt_Click(object sender, EventArgs e)
        {
            StakeHolder = "HOUser";
            Session["HNowner"] = "HOUser";
            txtUserName.Text = txtemail.Text;
            txtUserName.Enabled = false;

            string value = HiddenField.Value;


            string value2 = Hidden2.Value;

            GPSlat = value;
            GPSlong = value2;


            if (objBLLRegister.CheckUser(txtTelephone.Text, txtemail.Text).Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(btnSubmit, btnSubmit.GetType(), "message", "alert('" + "User Already registered !" + "');", true);
                txtemail.Focus();
                txtTelephone.Focus();
                return;
            }
            Session["Panel"] = "7";


            PanelVisibility();
            //visible homoeowner work

        }


        protected void btnHomeOwnerWorknext_Click(object sender, EventArgs e)
        {

            Session["Panel"] = "7";
            PanelVisibility();
        }

        protected void btnHomeOwnerWorkPrevious_Click(object sender, EventArgs e)
        {

            Session["Panel"] = "2";
            PanelVisibility();
        }


        protected void btHOSocialPrev_Click(object sender, EventArgs e)
        {

            Session["Panel"] = "1";
            PanelVisibility();
        }

        protected void btnHOSocialNext_Click(object sender, EventArgs e)
        {
            txtUserName.Text = txtemail.Text;
            txtUserName.Enabled = false;
            Session["Panel"] = "5";
            PanelVisibility();

        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                bool CommercialSite = false;
                string Gender;
                int i = 0;


                //-----------------Non User-----------------------


                if (Session["HNowner"].ToString() == "User")
                {

                    #region User


                    if (string.IsNullOrEmpty(txtStakeHolderName.Text))
                    {
                        ScriptManager.RegisterClientScriptBlock(btnSubmit, btnSubmit.GetType(), "message", "alert('" + "Please enter First Name" + "');", true);
                        txtStakeHolderName.Focus();
                        return;
                    }


                    if (string.IsNullOrEmpty(txtSurname.Text))
                    {
                        ScriptManager.RegisterClientScriptBlock(btnSubmit, btnSubmit.GetType(), "message", "alert('" + "Please enter Surname" + "');", true);
                        txtAddress1.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(dtDOB.Text))
                    {
                        ScriptManager.RegisterClientScriptBlock(btnSubmit, btnSubmit.GetType(), "message", "alert('" + "Please enter Date of Birth" + "');", true);
                        txtAddress1.Focus();
                        return;
                    }

                    if (string.IsNullOrEmpty(txtAddress1.Text))
                    {
                        ScriptManager.RegisterClientScriptBlock(btnSubmit, btnSubmit.GetType(), "message", "alert('" + "Please enter Address Line 1" + "');", true);
                        txtAddress1.Focus();
                        return;
                    }

                    //if (string.IsNullOrEmpty(txtAddress2.Text))
                    //{
                    //    ScriptManager.RegisterClientScriptBlock(btnSubmit, btnSubmit.GetType(), "message", "alert('" + "Please enter Address Line 2" + "');", true);
                    //    txtAddress2.Focus();
                    //    return;
                    //}

                    if (chkmale.Checked == true)
                    {
                        Gender = "Male";
                    }
                    else
                        Gender = "Female";

                    //if (string.IsNullOrEmpty(txtNIC.Text))
                    //{
                    //    ScriptManager.RegisterClientScriptBlock(btnSubmit, btnSubmit.GetType(), "message", "alert('" + "Please enter NIC No" + "');", true);
                    //    txtNIC.Focus();
                    //    return;
                    //}

                    if (cmbStakeholder.SelectedIndex == -1)
                    {
                        ScriptManager.RegisterClientScriptBlock(btnSubmit, btnSubmit.GetType(), "message", "alert('" + "Please Select Fitness Type" + "');", true);
                        cmbStakeholder.Focus();
                        return;
                    }

                    if (string.IsNullOrEmpty(txtemail.Text))
                    {
                        ScriptManager.RegisterClientScriptBlock(btnSubmit, btnSubmit.GetType(), "message", "alert('" + "Please enter Email" + "');", true);
                        txtemail.Focus();
                        return;
                    }

                    if (string.IsNullOrEmpty(txtTelephone.Text))
                    {
                        ScriptManager.RegisterClientScriptBlock(btnSubmit, btnSubmit.GetType(), "message", "alert('" + "Please enter Mobile No" + "');", true);
                        txtTelephone.Focus();
                        return;
                    }


                    if (objBLLRegister.CheckUser(txtTelephone.Text, txtemail.Text).Tables[0].Rows.Count > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(btnSubmit, btnSubmit.GetType(), "message", "alert('" + "User Already registered !" + "');", true);
                        txtemail.Focus();
                        txtTelephone.Focus();
                        return;
                    }
                    if (Attachmentbytes == null)
                    {
                        string resultFilePath = Server.MapPath("~/assets/images/no-image.gif");
                        Bitmap bitmap = new Bitmap(resultFilePath);
                        Attachmentbytes = ImageToByte(bitmap);
                    }



                    #endregion

                    if (string.IsNullOrEmpty(txtPassword.Text))
                    {
                        ScriptManager.RegisterClientScriptBlock(btnSubmit, btnSubmit.GetType(), "message", "alert('" + "Please enter Password" + "');", true);
                        txtPassword.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(txtConfirmPassword.Text))
                    {
                        ScriptManager.RegisterClientScriptBlock(btnSubmit, btnSubmit.GetType(), "message", "alert('" + "Please  Confirm Password" + "');", true);
                        txtConfirmPassword.Focus();
                        return;
                    }
                    if (txtPassword.Text != txtConfirmPassword.Text)
                    {
                        ScriptManager.RegisterClientScriptBlock(btnSubmit, btnSubmit.GetType(), "message", "alert('" + "Passwords does not Match" + "');", true);
                        txtPassword.Focus();
                        return;
                    }


                    Session["Fname"] = txtStakeHolderName.Text;
                    Session["Lname"] = txtSurname.Text;
                    Session["DOB"] = dtDOB.Date;
                    //Session["NIC"] = txtNIC.Text;
                    Session["Email"] = txtemail.Text;
                    Session["MobileNo"] = txtTelephone.Text;

                    Session["Address1"] = txtAddress1.Text;
                    Session["Address2"] = txtAddress2.Text;

                    Session["Address3"] = txtAddress3.Text;
                    Session["StakeholderTypeId"] = cmbStakeholder.Value;
                    Session["Password"] = txtPassword.Text;
                    Session["Height"] = txtHeight.Text;
                    Session["Weight"] = txtWeight.Text;
                    Session["FitnessTypeId"] = cmbStakeholder.Value;

                    Session["BankName"] = "";
                    Session["BankBranch"] = "";
                    Session["BankAcc"] = "";
     
                    Session["Gender"] = Gender;



                    Session["WorkExperience"] = "0";

    
                    if (GPSlat == "")
                    {
                        string Address = txtAddress1.Text.ToString();

                        string strAddress = Address; ;
                        string url = "https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyAKWjSdYxPggIZ87XsX8cXnZupDXq1jxt4&address=" + strAddress + "&sensor=true";

                        try
                        {
                            GetLatLongFromAddress(url);
                        }
                        catch
                        {
                            ScriptManager.RegisterClientScriptBlock(btnSubmit, btnSubmit.GetType(), "message", "alert('" + "Please Enter a Correct Address" + "');", true);

                        }
                    }


                    else
                    {

                        Session["pGPSLat"] = GPSlat;
                        Session["pGPSLong"] = GPSlong;
                    }


                    if (GPSlat == "")
                    {
                        string Address = txtAddress1.Text.ToString() + txtAddress2.Text.ToString() + "," + txtAddress3.Text.ToString();

                        string strAddress = Address; ;
                        string url = "https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyAKWjSdYxPggIZ87XsX8cXnZupDXq1jxt4&address=" + strAddress + "&sensor=true";

                        GetLatLongFromAddress(url);

                    }
                
                }



                //-------------------StakeHolder----------------------------







                if (Session["HNowner"].ToString() == "User")
                {

                    i = objBLLRegister.RegisterNewUser(Session["Email"].ToString(), "", Session["Fname"].ToString(),
                      Session["Lname"].ToString(), objUserConfig.EncryptStringF(Session["Password"].ToString()),
                      Convert.ToInt32(Session["StakeholderTypeId"].ToString()),
                      objUserConfig.EncryptStringF(Session["Email"].ToString().ToLower()),

                       Session["MobileNo"].ToString(), Session["Address1"].ToString(),
                       Session["Address2"].ToString(), Session["Address3"].ToString(),
                       Session["pGPSLat"].ToString(), Session["pGPSLong"].ToString(),
                       Session["BankBranch"].ToString(), Session["BankAcc"].ToString(),
                       Session["BankName"].ToString(), Attachmentbytes,
                       Session["DOB"].ToString(),
                       //(Session["EducationalQualification"].ToString()),
                       " ", " ", " "
                      // Session["WorkAddress"].ToString(), Session["Designation"].ToString()

                      , Convert.ToInt32(Session["WorkExperience"]), 0, Session["Gender"].ToString(),
                       Convert.ToInt32(Session["Height"].ToString()),
                       float.Parse(Session["Weight"].ToString())


                      );
                }

                else

                {


                }


                if (i > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + "Account successfully created ." + "'); window.location='Login.aspx';", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + "Error occured.Please try again." + "'); window.location='Login.aspx';", true);
                }

                Session.Clear();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message", "alert('" + "Error" + "');", true);
            }
        }

  

  


   

        public static byte[] ImageToByte(System.Drawing.Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        protected void NonHomeOwner_Click(object sender, EventArgs e)
        {
            StakeHolder = "User";
            PersonalDetails.Visible = true;
            UserLogin.Visible = false;

        }

        protected void HomeOwner_Click(object sender, EventArgs e)
        {

            StakeHolder = "HOUser";

            UserLogin.Visible = false;
        }

        protected void dtDOB_CalendarCustomDisabledDate(object sender, CalendarCustomDisabledDateEventArgs e)
        {
            if (e.Date > System.DateTime.Today)
                e.IsDisabled = true;
        }

        protected void imgUploaderz_FilesUploadComplete(object sender, FilesUploadCompleteEventArgs e)
        {

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


        protected void cmbSiteCondition_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




     
    }

}