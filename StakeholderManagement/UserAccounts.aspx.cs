using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DevExpress.XtraPrinting;
using StakeholderManagement.ServiceReference1;

using GoogleMaps.LocationServices;

using System.IO;

using System.Net;


using DevExpress.Web;
using DevExpress.Web.Bootstrap;
using BLLRMS;
using System.Data;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace StakeholderManagement
{
    public partial class UserAccounts : System.Web.UI.Page
    {
        private static BLLSignUp objBLLUsers = new BLLSignUp();
        //  private static BLLCommonFunctions objBLLCommonFunctions = new BLLCommonFunctions();
        private UserConfig objUserConfig = new UserConfig();
        string latitude1;
        string longitude1;
        BulkSMSClient bulkSMS = new BulkSMSClient();
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


            }
        }

        public static void Address()
        {
            var address = "75 Ninth Avenue 2nd and 4th Floors New York, NY 10011";
            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(address);
            var latitude = point.Latitude;
            var longitude = point.Longitude;
        }


        private void GetLatLongFromAddress(string url2)
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
                Session["GPSLAt"] = latitude1;
                Session["GPSLong"] = longitude1;

            }
            catch (System.Net.WebException exp)
            {

            }

        }


        public void Check()
        {
            // string url = "http://maps.google.com/maps/api/geocode/xml?address=" + address + "&sensor=false";

            string strAddress = "75 Ninth Avenue 2nd and 4th Floors New York, NY 10011";
            string url = "https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyAKWjSdYxPggIZ87XsX8cXnZupDXq1jxt4&address=" + strAddress + "&sensor=false";


            WebRequest request = WebRequest.Create(url);

            using (WebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {

                    DataSet dsResult = new DataSet();
                    dsResult.ReadXml(reader);
                    DataTable dtCoordinates = new DataTable();
                    dtCoordinates.Columns.AddRange(new DataColumn[4] { new DataColumn("Id", typeof(int)),
                    new DataColumn("Address", typeof(string)),
                    new DataColumn("Latitude",typeof(string)),
                    new DataColumn("Longitude",typeof(string)) });
                    foreach (DataRow row in dsResult.Tables["result"].Rows)
                    {
                        string geometry_id = dsResult.Tables["geometry"].Select("result_id = " + row["result_id"].ToString())[0]["geometry_id"].ToString();
                        DataRow location = dsResult.Tables["location"].Select("geometry_id = " + geometry_id)[0];
                        dtCoordinates.Rows.Add(row["result_id"], row["formatted_address"], location["lat"], location["lng"]);
                    }
                }
                //return dtCoordinates;
            }
        }


        public void GeoCode(string url)
        {
            //to Read the Stream
            StreamReader sr = null;

            //The Google Maps API Either return JSON or XML. We are using XML Here
            //Saving the url of the Google API 


            //to Send the request to Web Client 
            WebClient wc = new WebClient();
            try
            {
                sr = new StreamReader(wc.OpenRead(url));
            }
            catch (Exception ex)
            {
                throw new Exception("The Error Occured" + ex.Message);
            }

            try
            {
                XmlTextReader xmlReader = new XmlTextReader(sr);
                bool latread = false;
                bool longread = false;

                while (xmlReader.Read())
                {
                    xmlReader.MoveToElement();
                    switch (xmlReader.Name)
                    {
                        case "lat":

                            if (!latread)
                            {
                                xmlReader.Read();
                                string Latitude = xmlReader.Value.ToString();
                                latread = true;

                            }
                            break;
                        case "lng":
                            if (!longread)
                            {
                                xmlReader.Read();
                                string Lomg = xmlReader.Value.ToString();
                                longread = true;
                            }

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An Error Occured" + ex.Message);
            }
        }

        public static string GetFirstLastName(string url)
        {
            //string url = "http://maps.google.com/maps/api/geocode/xml?address=" + rollNumber + " " + age + " " + email + "&sensor=false";
            WebRequest request = WebRequest.Create(url);
            using (WebResponse response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    var ds = new DataSet("Employee");
                    ds.ReadXml(reader);

                    var dt = new DataTable("Employee");
                    dt.Columns.AddRange(new DataColumn[2]
                    {
                    new DataColumn("Latitude", typeof (string)),
                    new DataColumn("Longitude", typeof (string))
                    });

                    int i = 0;
                    foreach (DataRow row in ds.Tables["result"].Rows)
                    {
                        if (i == 0)
                        {
                            string geometry_id = ds.Tables["geometry"].Select("result_id = " + row["result_id"])[0]["geometry_id"].ToString();

                            DataRow dr = ds.Tables["location"].Select("geometry_id = " + geometry_id)[0];

                            dt.Rows.Add(dr["lat"], dr["lng"]);
                            i = 1;
                        }
                    }
                    return ds.GetXml();
                }
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

            e.NewValues["UserLoginId"] = Session["UserId"].ToString();



            string Address = e.NewValues["AddressLine1"].ToString() + e.NewValues["AddressLine2"].ToString() + e.NewValues["AddressLine3"].ToString();

            string strAddress = "75 Ninth Avenue 2nd and 4th Floors New York, NY 10011"; ;
            string url = "https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyAKWjSdYxPggIZ87XsX8cXnZupDXq1jxt4&address=" + strAddress + "&sensor=true";

            GetLatLongFromAddress(url);
            LoadSMSDetails();
            Session["GPSX"] = latitude1;
            Session["GPSLong"] = longitude1;

        }

        protected void gdPromotions_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            if (Session["UserId"] == null)
            {

                DevExpress.Web.ASPxWebControl.RedirectOnCallback("Login.aspx");
            }

            e.NewValues["UserLoginId"] = Session["UserId"].ToString();
        }

        protected void gdPromotions_CellEditorInitialize(object sender, BootstrapGridViewEditorEventArgs e)
        {

        }



        protected void btnDispatch_Click(object sender, EventArgs e)
        {

        }



        private void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn gridViewColumn, string errorText)
        {
            if (errors.ContainsKey(gridViewColumn))
            {
                return;
            }
            errors[gridViewColumn] = errorText;
        }

        protected void gdDetailedAccounts_BeforePerformDataSelect(object sender, EventArgs e)
        {
            BootstrapGridView gridd = sender as BootstrapGridView;
            int i = Convert.ToInt32(gridd.GetMasterRowKeyValue());
            SqlGetHomeOwners.SelectParameters[0].DefaultValue = i.ToString();
        }





        protected void gdAccounts_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            string lat;
            string longt;
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                bool Active = false;
                if (e.NewValues["Active"] == null)
                {
                    Active = false;
                }
                else
                {
                    Active = true;
                }

                if (Convert.ToBoolean(e.NewValues["Active"]) == true)
                {
                    Active = true;
                }
                else
                {
                    Active = false;
                }

                if (e.NewValues["BankAcc"] == null)
                {
                    e.NewValues["BankAcc"] = "";

                }
                if (e.NewValues["BankName"] == null)
                {
                    e.NewValues["BankName"] = "";

                }

                if (e.NewValues["BankBranch"] == null)
                {
                    e.NewValues["BankBranch"] = "";

                }
                if (e.NewValues["WorkAddress"] == null)
                {
                    e.NewValues["WorkAddress"] = "";

                }


                if (e.NewValues["Designation"] == null)
                {
                    e.NewValues["Designation"] = "";

                }

                if (e.NewValues["AddressLine3"] == null)
                {
                    e.NewValues["AddressLine3"] = "";
                }


                if (Session["StakeHolderTypeId"] == null)
                {
                    Session["StakeHolderTypeId"] = "0";
                }

                if (Session["ASO"] == null)
                {
                    Session["ASO"] = "0";
                }




                //if (e.NewValues["Educational"] == null)
                //{
                //    e.NewValues["Educational"] = "";
                //}

                string Address = e.NewValues["AddressLine1"].ToString() + e.NewValues["AddressLine2"].ToString() + "," + e.NewValues["AddressLine3"].ToString();

                string strAddress = Address; ;
                string url = "https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyAKWjSdYxPggIZ87XsX8cXnZupDXq1jxt4&address=" + strAddress + "&sensor=true";

                LoadSMSDetails();
                try
                {
                    GetLatLongFromAddress(url);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "message", "alert('" + "Please Enter a Correct Address" + "');", true);

                }

                if (Session["GPSLAt"] == null)
                {
                    lat = null;
                }
                else
                    lat = Session["GPSLAt"].ToString();


                if (Session["GPSLong"] == null)
                {
                    longt = null;
                }
                else
                    longt = Session["GPSLong"].ToString();

                //int success = objBLLUsers.RegisterNewUser(e.NewValues["Email"].ToString(),
                //    e.NewValues["NIC"].ToString().ToLower(),
                //    e.NewValues["FName"].ToString().ToLower(),
                //    e.NewValues["LName"].ToString().ToLower()
                //    , objUserConfig.EncryptStringF("test123"), Convert.ToInt32(e.NewValues["StakeHolderTypeId"]),
                //   objUserConfig.EncryptStringF(e.NewValues["NIC"].ToString()),
                //    e.NewValues["MobileNo"].ToString(),
                //    e.NewValues["AddressLine1"].ToString(), e.NewValues["AddressLine2"].ToString(),
                //    e.NewValues["AddressLine3"].ToString(),
                //    lat, longt, e.NewValues["BankBranch"].ToString(),
                //    e.NewValues["BankAcc"].ToString(),
                //    e.NewValues["BankName"].ToString(), null,
                //    e.NewValues["DOB"].ToString(), "",

                //          e.NewValues["WorkAddress"].ToString(),
                //          e.NewValues["Designation"].ToString()
                //          , 0,
                //         //, Convert.ToInt32(e.NewValues["WorkExperience"].ToString()),
                //         Convert.ToInt32(Session["ASOAcc"].ToString()),
                //          "", false, "", 0, 0, 0, ""
                //   );
                int success = 0;
                if (success >= 1)
                {
                    e.Cancel = true;
                    gdAccounts.CancelEdit();
                    gdAccounts.DataBind();
                    ((ASPxGridView)sender).JSProperties["cpInsertNote"] = "Successfully Inserted";
                }
                else
                {
                    e.Cancel = true;
                    gdAccounts.CancelEdit();
                    ((ASPxGridView)sender).JSProperties["cpInsertNote"] = "Inserting Failed";
                }
            }
        }

        protected void gdAccounts_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            DataSet dsCheck = default(DataSet);


            if (gdAccounts.IsNewRowEditing)
            {
                if (e.NewValues["NIC"] != null)
                {
                    dsCheck = objBLLUsers.CheckUser(e.NewValues["NIC"].ToString().Trim(), "");

                    if (dsCheck.Tables[0].Rows.Count != 0)
                    {
                        AddError(e.Errors, gdAccounts.Columns["NIC"], "* NIC already exists");
                    }
                }

                if (e.NewValues["Email"] != null)
                {
                    dsCheck = objBLLUsers.CheckUser("", e.NewValues["Email"].ToString().Trim());

                    if (dsCheck.Tables[0].Rows.Count != 0)
                    {
                        AddError(e.Errors, gdAccounts.Columns["Email"], "* Email already exists");
                    }
                }
            }

            else
            {
                //if (e.NewValues["NIC"] != null)
                //{
                //    if (e.NewValues["NIC"].ToString().ToLower() != e.OldValues["NIC"].ToString().ToLower())
                //    {
                //        dsCheck = objBLLUsers.CheckUser(e.NewValues["NIC"].ToString().Trim(), "");

                //        if (dsCheck.Tables[0].Rows.Count != 0)
                //        {
                //            if (e.NewValues["NIC"].ToString().Trim() != e.OldValues["NIC"].ToString().Trim())
                //            {
                //                AddError(e.Errors, gdAccounts.Columns["Name"], "* NIC already exists");
                //            }
                //        }
                //    }
                //}

                //if (e.NewValues["Email"] != null)
                //{
                //    if (e.NewValues["Email"].ToString().ToLower() != e.OldValues["Email"].ToString().ToLower())
                //    {
                //        dsCheck = objBLLUsers.CheckUser("", e.NewValues["Email"].ToString().Trim());

                //        if (dsCheck.Tables[0].Rows.Count != 0)
                //        {
                //            if (e.NewValues["Email"].ToString().Trim() != e.OldValues["Email"].ToString().Trim())
                //            {
                //                AddError(e.Errors, gdAccounts.Columns["Email"], "* Email already exists");
                //            }
                //        }
                //    }
                //}
            }

        }











        protected void gdHomeOwner_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string lat; string longt;
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                bool Active = false;
                if (e.NewValues["Active"] == null)
                {
                    Active = false;
                }
                else
                {
                    Active = true;
                }

                if (Convert.ToBoolean(e.NewValues["Active"]) == true)
                {
                    Active = true;
                }
                else
                {
                    Active = false;
                }

                if (e.NewValues["BankAcc"] == null)
                {
                    e.NewValues["BankAcc"] = "";

                }
                if (e.NewValues["BankName"] == null)
                {
                    e.NewValues["BankName"] = "";

                }

                if (e.NewValues["BankBranch"] == null)
                {
                    e.NewValues["BankBranch"] = "";

                }
                if (e.NewValues["WorkAddress"] == null)
                {
                    e.NewValues["WorkAddress"] = "";

                }
                if (e.NewValues["AddressLine3"] == null)
                {
                    e.NewValues["AddressLine3"] = "";
                }


                if (Session["ASO"] == null)
                {
                    Session["ASO"] = "0";
                }

                if (e.NewValues["Educational"] == null)
                {
                    e.NewValues["Educational"] = "";
                }

                if (e.NewValues["SiteType"] == null)
                {
                    e.NewValues["SiteType"] = "";
                }

                if (e.NewValues["Source"] == null)
                {
                    e.NewValues["Source"] = "";
                }

                if (e.NewValues["TotalProductReqiurement"] == null)
                {
                    e.NewValues["TotalProductReqiurement"] = "0";
                }

                if (e.NewValues["PurchasedQty"] == null)
                {
                    e.NewValues["PurchasedQty"] = "0";
                }

                if (e.NewValues["SiteCondition"] == null)
                {
                    e.NewValues["SiteCondition"] = "";
                }

                if (e.NewValues["CommercialSite"] == null)
                {
                    e.NewValues["CommercialSite"] = "";
                }

                if (e.NewValues["ProductBrandId"] == null)
                {
                    e.NewValues["ProductBrand"] = "0";

                }


                string Address = e.NewValues["AddressLine1"].ToString() + e.NewValues["AddressLine2"].ToString() + "," + e.NewValues["AddressLine3"].ToString();

                string strAddress = Address; ;
                string url = "https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyAKWjSdYxPggIZ87XsX8cXnZupDXq1jxt4&address=" + strAddress + "&sensor=true";


                try
                {
                    GetLatLongFromAddress(url);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "message", "alert('" + "Please Enter a Correct Address" + "');", true);

                }


                if (Session["GPSLAt"] == null)
                {
                    lat = null;
                }
                else
                    lat = Session["GPSLAt"].ToString();


                if (Session["GPSLong"] == null)
                {
                    longt = null;
                }
                else
                    longt = Session["GPSLong"].ToString();

                LoadSMSDetails();
                int success = 1;

                //int success = objBLLUsers.RegisterNewUser(e.NewValues["Email"].ToString(),
                //    e.NewValues["NIC"].ToString().ToLower(),
                //    e.NewValues["FName"].ToString().ToLower(),
                //    e.NewValues["LName"].ToString().ToLower()
                //    , objUserConfig.EncryptStringF("test123"), 1,
                //   objUserConfig.EncryptStringF(e.NewValues["NIC"].ToString()),
                //    e.NewValues["MobileNo"].ToString(),
                //    e.NewValues["AddressLine1"].ToString(), e.NewValues["AddressLine2"].ToString(),
                //    e.NewValues["AddressLine3"].ToString(),
                //    lat, longt, e.NewValues["BankBranch"].ToString(),
                //    e.NewValues["BankAcc"].ToString(),
                //    e.NewValues["BankName"].ToString(), null,
                //    e.NewValues["DOB"].ToString(), (e.NewValues["Educational"].ToString()),

                //          e.NewValues["WorkAddress"].ToString(),
                //          "", 0,
                //         Convert.ToInt32(Session["ASOAcc"].ToString()),
                //         e.NewValues["SiteType"].ToString(),
                //         Convert.ToBoolean(e.NewValues["CommercialSite"]), e.NewValues["SiteCondition"].ToString(),
                //         Convert.ToInt32(e.NewValues["ProductBrandId"]),
                //          Convert.ToInt32(e.NewValues["TotalProductReqiurement"].ToString()),
                //          Convert.ToInt32(e.NewValues["PurchasedQty"].ToString()),
                //          e.NewValues["Source"].ToString()

                //          );

                if (success >= 1)
                {


                    if (Convert.ToInt32(e.NewValues["ProductBrandId"]) == 0)
                    {
                        sendBulkLanwa(e.NewValues["MobileNo"].ToString(), Session["Fname"].ToString(), e.NewValues["LName"].ToString());
                        sendTestMsg(e.NewValues["MobileNo"].ToString());

                    }
                    else
                    {
                        sendBulkOther(e.NewValues["MobileNo"].ToString(), e.NewValues["FName"].ToString(), e.NewValues["LName"].ToString());
                        sendTestMsg(e.NewValues["MobileNo"].ToString());
                    }


                    gdHomeOwner.JSProperties["cpInsertNote"] = "Successfully Inserted";
                    e.Cancel = true;
                    gdHomeOwner.CancelEdit();
                    gdAccounts.DataBind();
                    // ((ASPxGridView)sender).JSProperties["cpInsertNote"] = "Successfully Inserted";
                }
                else
                {
                    e.Cancel = true;
                    gdHomeOwner.CancelEdit();
                    ((ASPxGridView)sender).JSProperties["cpInsertNote"] = "Inserting Failed";
                }

            }

        }





        public void LoadSMSDetails()
        {
            DataTable dtSMSDetails = new DataTable();

            dtSMSDetails = new DataTable();
            DataView viewUserDetails = (DataView)SqlSMSDetails.Select(DataSourceSelectArguments.Empty);
            dtSMSDetails = viewUserDetails.ToTable();

            DataRow dr = dtSMSDetails.Rows[0];

            string username = dr["UserId"].ToString();
            string password = dr["Password"].ToString();
            string AccountNo = dr["AccountNo"].ToString();
            string SendId = dr["send_id"].ToString();

            Session["username"] = username.ToString();
            Session["SMSPassword"] = password.ToString();
            Session["AccountNo"] = AccountNo.ToString();
            Session["SendId"] = SendId.ToString();

        }



        public void sendBulkLanwa(string number, string Fname, string LName)
        {

            //invoke business method
            sms sms = new sms();
            sms.account_no = Session["AccountNo"].ToString();
            sms.username = Session["username"].ToString();
            sms.password = Session["SMSPassword"].ToString();
            sms.send_id = Session["SendId"].ToString();           //94706790201
            sms.language = "1";

            sms.sms_content = "Dear " + Fname + ' ' + LName + " \n" +
                "Thank you for your loyalty with LANWA. We realize our product is in use at your construction site," +
                " and would like to encourage to call us on any inquiry you may need. Contact your Area Field Officer on " +
                "" + "Thank you  The Management";

            sms.bulk_start_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            sms.bulk_end_date = (DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss"));
            sms.campaign_name = "CSCL";
            String[] numList = new string[1];
            numList[0] = number;
            sms.number_list = numList;
            sms.add_block_notification = "";

            string campkey;
            campkey = bulkSMS.SendBulk(sms);
            Session["campkey"] = campkey.ToString();
            //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "message", "alert('" + bulkSMS.SendBulk(sms) + "');", true);

        }


        public void sendBulkOther(string number, string Fname, string LName)
        {
            //invoke business method
            sms sms = new sms();
            sms.account_no = Session["AccountNo"].ToString(); ;
            sms.username = Session["username"].ToString();
            sms.password = Session["SMSPassword"].ToString();
            sms.send_id = Session["SendId"].ToString();           //94706790201
            sms.language = "1";

            sms.sms_content = "Dear " + Fname + ' ' + LName + " \n" +
                "We realize you are having an ongoing construction site and would like to serve you. " +
                "Please call LANWA Area Sales Officer for any inquiry on 711703614 to offer a fulfilling service on your" +
                " steel requirement.";

            sms.bulk_start_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            sms.bulk_end_date = (DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss"));
            sms.campaign_name = "CSCL";
            String[] numList = new string[1];
            numList[0] = number;
            sms.number_list = numList;
            sms.add_block_notification = "";

            string campkey;
            campkey = bulkSMS.SendBulk(sms);
            Session["campkey"] = campkey.ToString();
            //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "message", "alert('" + bulkSMS.SendBulk(sms) + "');", true);

        }


        public void sendTestMsg(string MobileNo)
        {

            string username = Session["username"].ToString();
            string password = Session["SMSPassword"].ToString();

            String camp_key = Session["campkey"].ToString();
            //"99163963630101979613";
            String mobile_number = MobileNo;
            bulkSMS.SendTestMessage(username, password, camp_key, mobile_number);

        }




        protected void gdAccounts_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            var clickedRowIndex = e.VisibleIndex;
            var keyValue = grid.GetRowValues(clickedRowIndex, grid.KeyFieldName);

            Session["StakeId"] = keyValue.ToString();
            // Response.Redirect("~/UserAccounts.aspx");

            if (Page.IsCallback)
                ASPxWebControl.RedirectOnCallback("~/Visits.aspx");


        }




        //-----------------------------Home Owner---------------------------------


        protected void gdHomeOwner_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {

            ASPxGridView grid = sender as ASPxGridView;
            var clickedRowIndex = e.VisibleIndex;
            var keyValue = grid.GetRowValues(clickedRowIndex, grid.KeyFieldName);

            Session["StakeId"] = keyValue.ToString();
            // Response.Redirect("~/UserAccounts.aspx");

            if (Page.IsCallback)
                ASPxWebControl.RedirectOnCallback("~/Visits.aspx");
        }

        protected void gdHomeOwner_CellEditorInitialize(object sender, BootstrapGridViewEditorEventArgs e)
        {

        }


        protected void gdHomeOwner_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            DataSet dsCheck = default(DataSet);


            if (gdHomeOwner.IsNewRowEditing)
            {
                if (e.NewValues["NIC"] != null)
                {
                    dsCheck = objBLLUsers.CheckUser(e.NewValues["NIC"].ToString().Trim(), "");

                    if (dsCheck.Tables[0].Rows.Count != 0)
                    {
                        AddError(e.Errors, gdHomeOwner.Columns["NIC"], "* NIC already exists");
                    }
                }

                if (e.NewValues["Email"] != null)
                {
                    dsCheck = objBLLUsers.CheckUser("", e.NewValues["Email"].ToString().Trim());

                    if (dsCheck.Tables[0].Rows.Count != 0)
                    {
                        AddError(e.Errors, gdHomeOwner.Columns["Email"], "* Email already exists");
                    }
                }
            }

            else
            {
                //if (e.NewValues["NIC"] != null)
                //{
                //    if (e.NewValues["NIC"].ToString().ToLower() != e.OldValues["NIC"].ToString().ToLower())
                //    {
                //        dsCheck = objBLLUsers.CheckUser(e.NewValues["NIC"].ToString().Trim(), "");

                //        if (dsCheck.Tables[0].Rows.Count != 0)
                //        {
                //            if (e.NewValues["NIC"].ToString().Trim() != e.OldValues["NIC"].ToString().Trim())
                //            {
                //                AddError(e.Errors, gdAccounts.Columns["Name"], "* NIC already exists");
                //            }
                //        }
                //    }
                //}

                //if (e.NewValues["Email"] != null)
                //{
                //    if (e.NewValues["Email"].ToString().ToLower() != e.OldValues["Email"].ToString().ToLower())
                //    {
                //        dsCheck = objBLLUsers.CheckUser("", e.NewValues["Email"].ToString().Trim());

                //        if (dsCheck.Tables[0].Rows.Count != 0)
                //        {
                //            if (e.NewValues["Email"].ToString().Trim() != e.OldValues["Email"].ToString().Trim())
                //            {
                //                AddError(e.Errors, gdAccounts.Columns["Email"], "* Email already exists");
                //            }
                //        }
                //    }
                //}
            }
        }
    }
}