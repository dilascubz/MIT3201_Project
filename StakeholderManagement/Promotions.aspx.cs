using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using DevExpress.Export;
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
    public partial class Promotions : System.Web.UI.Page
    {
        byte[] Imgbytes = null;
        // public string UserImage = "/images/DP/dummy.png";

        public string UserImage = "/assets2/images/hero/hero-1.jpg";


        // public string UserImage = "/images/DP/RangaRanga.jpg";

        public string UserId = "";
        string USerName = "admin";
        BLLSecurity bLLSecurity = new BLLSecurity();
        BLLUserCategory bLLUserCategory = new BLLUserCategory();
        BLLAddProductCategory productCategory = new BLLAddProductCategory();
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
                UserId = Session["UserId"].ToString();



                GetUserImage(USerName);

            }
        }
        protected void gdPromotions_CommandButtonInitialize(object sender, DevExpress.Web.Bootstrap.BootstrapGridViewCommandButtonEventArgs e)
        {

        }


        protected void gdPromotions_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            if (Session["UserId"] == null)
            {


                DevExpress.Web.ASPxWebControl.RedirectOnCallback("Login.aspx");
            }

            if (e.NewValues["PromoImage"] == null)
            {
                Imgbytes = (byte[])e.NewValues["PromoImage"];

                string resultFilePath = Server.MapPath("~/assets/images/no-image.gif");
                Bitmap bitmap = new Bitmap(resultFilePath);
                e.NewValues["PromoImage"] = ImageToByte(bitmap);
            }
            e.NewValues["UserLoginId"] = Session["UserId"].ToString();

        }

        protected void gdPromotions_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            if (Session["UserId"] == null)
            {
                DevExpress.Web.ASPxWebControl.RedirectOnCallback("Login.aspx");
            }

            if (e.NewValues["PromoImage"] == null)
            {
                Imgbytes = (byte[])e.NewValues["PromoImage"];

                string resultFilePath = Server.MapPath("~/assets/images/no-image.gif");
                Bitmap bitmap = new Bitmap(resultFilePath);
                e.NewValues["PromoImage"] = ImageToByte(bitmap);
            }

            e.NewValues["UserLoginId"] = Session["UserId"].ToString();




        }
        public static byte[] ImageToByte(System.Drawing.Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }


        protected void gdPromotions_CellEditorInitialize(object sender, BootstrapGridViewEditorEventArgs e)
        {


        }



        protected void gdPromotions_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

            DateTime FromDate = Convert.ToDateTime((e.NewValues["FromDate"]).ToString());
            DateTime Todate = Convert.ToDateTime((e.NewValues["ToDate"]).ToString());

            if (Session["UserId"] != null)
            {
                DataSet dsCheck = default(DataSet);


                if (gdPromotions.IsNewRowEditing)
                {
                    if (e.NewValues["Name"] != null)
                    {
                        dsCheck = productCategory.CheckPromotionsNameExists(e.NewValues["Name"].ToString().Trim(), "Promotions");

                        if (dsCheck.Tables[0].Rows.Count != 0)
                        {
                            AddError(e.Errors, gdPromotions.Columns["Name"], "* Name already exists");
                        }
                    }

                    if (e.NewValues["Code"] != null)
                    {
                        dsCheck = productCategory.CheckPromotionCodeExists(e.NewValues["Code"].ToString().Trim(), "Promotions");

                        if (dsCheck.Tables[0].Rows.Count != 0)
                        {
                            AddError(e.Errors, gdPromotions.Columns["Code"], "* Code already exists");
                        }
                    }
                }

                else
                {
                    if (e.NewValues["Name"] != null)
                    {
                        if (e.NewValues["Name"].ToString().ToLower() != e.OldValues["Name"].ToString().ToLower())
                        {
                            dsCheck = productCategory.CheckPromotionsNameExists(e.NewValues["Name"].ToString().Trim(), "Promotions");

                            if (dsCheck.Tables[0].Rows.Count != 0)
                            {
                                if (e.NewValues["Name"].ToString().Trim() != e.OldValues["Name"].ToString().Trim())
                                {
                                    AddError(e.Errors, gdPromotions.Columns["Name"], "* Name already exists");
                                }
                            }
                        }
                    }

                    if (e.NewValues["Code"] != null)
                    {
                        if (e.NewValues["Code"].ToString().ToLower() != e.OldValues["Code"].ToString().ToLower())
                        {
                            dsCheck = productCategory.CheckPromotionCodeExists(e.NewValues["Code"].ToString().Trim(), "Promotions");

                            if (dsCheck.Tables[0].Rows.Count != 0)
                            {
                                if (e.NewValues["Code"].ToString().Trim() != e.OldValues["Code"].ToString().Trim())
                                {
                                    AddError(e.Errors, gdPromotions.Columns["Code"], "* Code already exists");
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                DevExpress.Web.ASPxWebControl.RedirectOnCallback("Login.aspx");
            }
        }

        private void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn gridViewColumn, string errorText)
        {
            if (errors.ContainsKey(gridViewColumn))
            {
                return;
            }
            errors[gridViewColumn] = errorText;
        }



        void SendEmailToComapany(String CompanyId, String OrderNo, string strTitle)
        {
            try
            {
                string Email = "dilasphone@gmail.com";
                Session["CompanyID"] = CompanyId;
                Session["OrderNo"] = OrderNo;
                DataView viewPreOrderDetailToEmail = (DataView)SqlGetPromotions.Select(DataSourceSelectArguments.Empty);
                DataTable dtPreOrderDetailToEmail = viewPreOrderDetailToEmail.ToTable(true, "Name", "Active");

                DataTable Emailadd = viewPreOrderDetailToEmail.ToTable(true, "Name");

                if (dtPreOrderDetailToEmail.Rows.Count != 0)
                {
                    DataRow dr = dtPreOrderDetailToEmail.Rows[0];

                    string EmailBody = "<h2>Prima Home Delivery - " + strTitle + "</h2>" + dr["Name"] +
                        "<br/><br/>  <img src=cid:myImageID>";
                    EmailBody += "<table border=\"10\"  > <tr> <td> <h5>Order No</h5> </td> <td> <h5> : " + OrderNo + "</h5> </td> </tr> <tr> <td> <h5>Customer</h5> </td> <td> <h5> : " + dr["Name"] + "</h5></td></tr>   " +
                       "<tr> <td> <h5>Outlet Name</h5> </td> <td> <h5> : " + dr["Name"] + "</h5></td></tr>  " +
                        "<tr> <td> <h5>Mobile No</h5> </td> <td> <h5> : " + dr["Name"] + "</h5></td></tr>  " +
                          "<tr> <td> <h5>Address</h5> </td> <td> <h5> : " + dr["Name"] + " " + dr["Name"] + " " + dr["Name"] + "</h5></td></tr>  " +
                          "<tr> <td> <h5>Location</h5> </td> <td> <a> http://maps.google.com/maps?q=" + dr["Name"] + "," + dr["Name"] + "</a></td></tr>" +
                        "</table> " +
                        "<br/> " +


                        "<table border=\"10\"  width=\"50%\" height=\"100%\">" +
                                             "<tr>" +
                                               "<th>Item Name</th>" +
                                               "<th>Qty</th>" +
                                               "</tr>";




                    for (int i = 0; i < dtPreOrderDetailToEmail.Rows.Count; i++)
                    {

                        dr = dtPreOrderDetailToEmail.Rows[i];
                        // drItm = dtPreOrderDetailToEmail.Rows[0];
                        EmailBody += "<tr> <td align =\"center\"> " + dr["Name"].ToString() + "</td>"
                                                               + "<td align =\"center\"> " + dr["Name"].ToString() + "</td>"
                                                                + "</tr>";

                    }

                    for (int i = 0; i < Emailadd.Rows.Count; i++)
                    {
                        //  Email = Email + Emailadd.Rows[i]["Name"].ToString() + ";";
                    }
                    if (Email != ";")
                    {
                        Email.Remove(Email.Length - 1);
                        EmailBody += "</table>";
                        //SendMail(Email, "Prima Home Delivery -" + strTitle, EmailBody);
                    }
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void GetUserImage(string UserNme)
        {
            if (USerName != null)
            {
                string query = "select UserImageString from HealthUser where UserId='" + UserId + "'";

                string ImageName = bLLUserCategory.GetQuery(query, "UserImageString");
                if (ImageName != "")
                    UserImage = "images/DP/" + ImageName;




            }
        }



        public void SendMail(int PromotionId)
        {
            string mSMTPUsrName = "";
            string mSMTPPassword = "";
            int StakeHolderType;
            string AdminEmail = "";

           
            try
            {
                DataView UserEmail = (DataView)dsUserEmail.Select(DataSourceSelectArguments.Empty);
                DataTable dtEmaildetails = UserEmail.ToTable();
                DataRow drEmail = null;

                if (dtEmaildetails.Rows.Count != 0)
                {
                    drEmail = dtEmaildetails.Rows[0];
                    AdminEmail = drEmail["Email"].ToString();
                }



                string mMailServer = "10.5.2.12";
                string mTo = AdminEmail;
                string mFrom = AdminEmail;



                //   string mSubject1 = subject;
                //   string sMessage = message;
              
                //DataView UserEmails = (DataView)SqlGetPromotions.Select(DataSourceSelectArguments.Empty);
                //DataTable dtUserEmails = UserEmails.ToTable(true, "Name", "Active");

                Session["PromotionId"] = PromotionId.ToString();

                DataView viewPreOrderDetailToEmail = (DataView)SqlPromoId.Select(DataSourceSelectArguments.Empty);
                DataTable dtPreOrderDetailToEmail = viewPreOrderDetailToEmail.ToTable(true, "Name", "Active", "FromDate", "ToDate", "Description","StakeHolderType");

                DataTable Emailadd = viewPreOrderDetailToEmail.ToTable(true, "Name");
                DataRow dr = null;

                if (dtPreOrderDetailToEmail.Rows.Count != 0)
                {
                    dr = dtPreOrderDetailToEmail.Rows[0];
                    StakeHolderType = Convert.ToInt32(dr["StakeHolderType"].ToString());
                    Session["StakeEmails"] = StakeHolderType.ToString();
                }

                DataView dsStakeHolderEmails = (DataView)SqlStakeholderEmails.Select(DataSourceSelectArguments.Empty);
                DataTable dtStakeHolderToEmail = dsStakeHolderEmails.ToTable();


                for (int i = 0; i> dtStakeHolderToEmail.Rows.Count - 1; i++)
                {
                
                }

            
                MailAddress fromMail = new MailAddress(mFrom);
                System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential(mSMTPUsrName, mSMTPPassword);
                MailMessage SentMessage = new MailMessage();

                SmtpClient mySmtpClient = new SmtpClient(mMailServer);
                using (mySmtpClient)
                {
                    MailMessage newMail = new MailMessage();
                    newMail.To.Add(new MailAddress(mTo));
                    newMail.From = fromMail;
                    newMail.Subject = "Lanwa StakeHolder - Promotions";
                    newMail.IsBodyHtml = true;

                    var inlineLogo = new LinkedResource(Server.MapPath(UserImage), "image/png");
                    inlineLogo.ContentId = Guid.NewGuid().ToString();


                    string EmailBody = "<h2>Promotion Details  </ h2 ><br/> ";


                    EmailBody += "<p>Please find the details of our latest promotions</p>" +
                        "</br>" +
                       "<table > <tr> <td> <h2>Name</h2> </td> <td> <h2> : " + dr["Name"] + "</h2></td></tr>  " +
                       "<tr> <td> <h3>Description No</h3> </td> <td> <h3> : " + dr["Description"] + " </h3></td></tr>  " +
                        "<tr> <td> <h3>From</h3> </td> <td> <h3> : " + dr["FromDate"] + "</h3></td>" +
                          "<tr> <td> <h3>To</h3> </td> <td> <h3> : " + dr["ToDate"] + "</h3></td>" +
                     
                       "</table>  "

                        //  

                        //"<p>From Date : " + dr["FromDate"] + " </p>" +
                        //"<p>To Date : " + dr["ToDate"] + " </p>" +
                        //"<p>Description : " + dr["Description"] + " </p>"
                        ;

                    //EmailBody += " <table> <tr>  <td> Date	:	26-Jun-2021</td>" +
                    //    "</br>" +
                    //    "<tr>  <td>Name	:	Perera, Ranga (PMS) </td>  </tr>"
                    //    ;



                    //                    EmailBody += "<p></p>";

                    //EmailBody += "<table border=\"10\"  > <tr> <td> <h5>Order No</h5> </td> <td>" +

                    //    "</tr> <tr> <td> <h5>Promotion</h5> </td> <td> <h5> : " + dr["Name"] + "</h5></td></tr>   " +
                    //   "<tr> <td> <h5>Outlet Name</h5> </td> <td> <h5> : " + dr["Name"] + "</h5></td></tr>  " +
                    //    "<tr> <td> <h5>Mobile No</h5> </td> <td> <h5> : " + dr["Name"] + "</h5></td></tr>  " +
                    //       "</table> " +
                    //    "<br/> " +


                    //    "<table border=\"10\"  width=\"50%\" height=\"100%\">" +
                    //                         "<tr>" +
                    //                           "<th>Item Name</th>" +
                    //                           "<th>Qty</th>" +
                    //                           "</tr>";




                    string body = string.Format(@"      
                      
            <img src=""cid:{0}"" />
            <p>Have a Lovely Day</p>
        ", inlineLogo.ContentId);


                    string FullMail = EmailBody + body;

                    var view2 = AlternateView.CreateAlternateViewFromString(FullMail, null, "text/html");
                    view2.LinkedResources.Add(inlineLogo);
                    newMail.AlternateViews.Add(view2);

                    mySmtpClient.Send(newMail);
                }

                mySmtpClient = null;



            }
            catch (Exception ex)

            {
                Console.WriteLine(ex.Message);
                throw ex;
            }


        }



        public void UpdateUserDetails()
        {
            SqlGetPromotions.UpdateParameters["Imgbytes"].DefaultValue = Imgbytes.ToString();
            SqlGetPromotions.Update();

        }

    
        protected void btnSend_Click(object sender, EventArgs e)
        {

        }

        protected void gdPromotions_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            var clickedRowIndex = e.VisibleIndex;
            var keyValue = grid.GetRowValues(clickedRowIndex, grid.KeyFieldName);

            SendMail(Convert.ToInt32(keyValue));
        }
    }
}