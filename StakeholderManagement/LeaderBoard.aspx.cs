using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using DevExpress.XtraPrinting;

using BLLRMS;
using DevExpress.Web;
using DevExpress.Web.Bootstrap;
using System.Data;
using System.Net.Mail;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text.RegularExpressions;

namespace StakeholderManagement
{
    public partial class LeaderBoard : System.Web.UI.Page
    {

        byte[] Attachmentbytes = null;
        UploadedFile uploadedAttachment;
        UploadedFile uploadedAttachment1;
        UploadedFile uploadedAttachment2;
        BLLNotification BLLFeedback = new BLLNotification();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {



                DevExpress.Web.ASPxWebControl.RedirectOnCallback("Login.aspx");
            }
        }

        protected void btnLeaderBoard_Click(object sender, EventArgs e)
        {
            int i = 0;
            //if (Attachmentbytes == null)
            //{
            //    string resultFilePath = Server.MapPath("~/images/no-image.gif");
            //    Bitmap bitmap = new Bitmap(resultFilePath);
            //    Attachmentbytes = ImageToByte(bitmap);
            //}


            i = BLLFeedback.LeaderBoardDetails(Session["UserId"].ToString(), txtSubject.Text, memoSubject.Text, txtDescription.Text, Attachmentbytes, Convert.ToInt32(TxtRepCounts.Text));




            if (i > 0)
            {
                ScriptManager.RegisterClientScriptBlock(btnLeaderBoard, btnLeaderBoard.GetType(), "message", "alert('" + "Succesfully Added" + "');", true);
                txtSubject.Text = "";
                memoSubject.Text = "";
                txtDescription.Text = "";
                TxtRepCounts.Text = "";
                return;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + "Error occured.Please try again." + "'); window.location='Login.aspx';", true);
            }




        }

        public static byte[] ImageToByte(System.Drawing.Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }


        public void GetUserDatafromId(string UserId)
        {

        }




        protected void ImgUploader_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
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
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "message", "alert('" + ex.ToString() + "');", true);
            }
        }
    }
}