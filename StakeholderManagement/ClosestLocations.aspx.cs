using System.Runtime.Serialization.Json;
using GoogleMaps.LocationServices;
using System;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Web.UI;
using DevExpress.Web;
using Microsoft.VisualBasic; // Install-Package Microsoft.VisualBasic
using Microsoft.VisualBasic.CompilerServices; // Install-Package Microsoft.VisualBasic

using System.Configuration;
using Subgurim.Controles;
using Subgurim.Controles.GoogleChartIconMaker;
using System.Web;
using System.Web.UI.WebControls;

namespace StakeholderManagement


{

    public partial class ClosestLocations : System.Web.UI.Page
    {


        private GMarkerOptions mOpts = new GMarkerOptions();
        private GInfoWindowOptions windowOptions = new GInfoWindowOptions();
        private GDirection direction = new GDirection("From", "To", "OK");
        private string host = HttpContext.Current.Request.Url.Host;
        private GMarker marker = new GMarker();
        private GMarker marker2 = new GMarker();
        private GMarker Xmarker = new GMarker();
        // Dim marker2 As New GMarker()
        private GIcon icon = new GIcon();
        private GIcon icon2 = new GIcon();
        private GIcon icon3 = new GIcon();
        private string strDetails;
        DataTable dtUserDetails = new DataTable();
        DataTable dtCurrentLocation = new DataTable();
        string Name;
        double GP;
        double GLong;

        double XGP;
        double XGlong;

        protected void Page_Load(object sender, EventArgs e)
        {



            // BindMarketDistributor()
            //   BindSalesrep(strFilterSQL);

            // ============ Reset Map
            resetMap();
            //btnsubmit.Enabled = true;
            //btnsubmit.Visible = true;
            //if (dtfrom.Date == (default))
            //{
            //    dtfrom.Date = DateTime.Now;
            //}



        }













        private void PlotCurrentLocation()
        {
            var dsDetails = new DataSet();
            var IconWidth = default(int);
            var IconHeight = default(int);
            var dsDetailsProductive = new DataSet();
            var dsDetailsunProductive = new DataSet();
            var dsDetailsUnProductiveDetails = new DataSet();
            string address;
            string distributor;
            string route;
            string contact;
            string Sales = "";
            var dsOutletStatus = new DataSet();
            Session["latLong"] = 0;
            Session["J"] = 0;
            Session["K"] = 0;
            var dscustomerpreorder = new DataSet();
            int i = 0;
            int cusid;
            string Customername;
            var dsInvoiceAllItems = new DataSet();
            var dsIsProductive = new DataSet();

            var Iconx = new GIcon();

            //  dsIsProductive = objBLL.GetTransacstionAsSequence(cmbSalesrep.Value, dtfrom.Date);
            int _chkCustomer;
            bool _IsProductive;
            DataView viewUserDetails = (DataView)sqlCurrentLocation.Select(DataSourceSelectArguments.Empty);
            dtCurrentLocation = viewUserDetails.ToTable();
            var Location = new GLatLng();


            XGP = Convert.ToDouble(dtCurrentLocation.Rows[0]["GPSLat"].ToString());
            XGlong = Convert.ToDouble(dtCurrentLocation.Rows[0]["GPSLong"].ToString());


            Location.lat = XGP;
            Location.lng = XGlong;


            Iconx.flatIconOptions = new FlatIconOptions(IconWidth, IconHeight, Color.Blue, Color.AliceBlue, "O", Color.White, 12,FlatIconOptions.flatIconShapeEnum.circle );
            Xmarker = new GMarker(Location, Iconx);

           




            var commonInfoWindowX = new GInfoWindow(Xmarker, "Current Location", false, GListener.Event.mouseover);

            //// ============add marker and the common window to GMAP
            // GMap1.Add(marker)
            GMap1.Add(commonInfoWindowX);
            GMap1.setCenter(new GLatLng(XGP, XGlong), 13);

        }

        private void PloXplaces()
        {
            var dsDetails = new DataSet();
            var IconWidth = default(int);
            var IconHeight = default(int);
            var dsDetailsProductive = new DataSet();
            var dsDetailsunProductive = new DataSet();
            var dsDetailsUnProductiveDetails = new DataSet();
            string address;
            string distributor;
            string route;
            string contact;
            string Sales = "";
            var dsOutletStatus = new DataSet();
            Session["latLong"] = 0;
            Session["J"] = 0;
            Session["K"] = 0;
            var dscustomerpreorder = new DataSet();
            int i = 0;
            int cusid;
            string Customername;
            var dsInvoiceAllItems = new DataSet();
            var dsIsProductive = new DataSet();

            //  dsIsProductive = objBLL.GetTransacstionAsSequence(cmbSalesrep.Value, dtfrom.Date);
            int _chkCustomer;
            bool _IsProductive;
            DataView viewUserDetails = (DataView)SqlStakeHolderTypes.Select(DataSourceSelectArguments.Empty);
            dtUserDetails = viewUserDetails.ToTable();


            if (dtUserDetails.Rows.Count != 0)
            {
                var loopTo = dtUserDetails.Rows.Count - 1;
                for (i = 0; i <= loopTo; i++)
                {
                    var latlng = new GLatLng();
                    string erpItemId = "";
                    string itemheader1 = "";
                    string itemname = "";
                    string qty = "";
                    string itemList = "";
                    string itemList2 = "";

                    //SreGetUserDetailsByRetailerId

                    DataRow dr = dtUserDetails.Rows[i];

                    //  Name = dr["FName"].ToString();
                    GP = Convert.ToDouble(dr["GPSLat"].ToString());
                    GLong = Convert.ToDouble(dr["GPSLong"].ToString());


                    itemheader1 = "<table border=1  style=\"font-size:9pt;border-collapse: collapse;\"><tr><th>SKU</th><th>Item Name</th><th>QTY</th></tr>";
                    latlng.lat = GP;
                    latlng.lng = GLong;
                    Session["latLong"] = latlng;
                    cusid = Convert.ToInt32(dr["Id"].ToString());
                    GMap1.mapType = GMapType.GTypes.Normal;
                    var vMyLabel = new Label();

                    // Dim preorderlstheader As String = ("<table border=1 style=""font-size:9pt;border-collapse: collapse;""><tr><th>Reported Time</th><th>Invoice No</th><th>Amount</th><th>Bal Amount</th><th>Time</th></tr>")
                    string preorderlstheader = "";
                    //"<table border=1 style=\"font-size:9pt;border-collapse: collapse;\"><tr><th>Invoice No</th><th>Amount</th><th>Bal Amount</th><th>Time</th></tr>";
                    string preorderdetailslst = "";


                    Session["J"] = Session["J"].ToString() + 1;
                    var icon3 = new GIcon();
                    var icon1 = new GIcon();


                    // ----------Icon Size------------
                    if (Session["J"].ToString().Length == 1)
                    {
                        IconWidth = 20;
                        IconHeight = 20;
                    }
                    else if (Session["J"].ToString().Length == 2)
                    {
                        IconWidth = 25;
                        IconHeight = 25;
                    }
                    else if (Session["J"].ToString().Length == 3)
                    {
                        IconWidth = 30;
                        IconHeight = 30;
                    }

                    //if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dsDetails.Tables[0].Rows[0]["Settle"], 0, false)))
                    //{
                    //    icon3.flatIconOptions = new FlatIconOptions(IconWidth, IconHeight, Color.Blue, Color.Black, Session["J"].ToString(), Color.White, 12, FlatIconOptions.flatIconShapeEnum.roundedrect);
                    //}
                    //else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dsDetails.Tables[0].Rows[0]["Deleted"], 1, false)))
                    //{
                    //    icon3.flatIconOptions = new FlatIconOptions(IconWidth, IconHeight, Color.Red, Color.Black, Session["J"].ToString(), Color.White, 12, FlatIconOptions.flatIconShapeEnum.roundedrect);
                    //}
                    //else
                    //{
                    //    icon3.flatIconOptions = new FlatIconOptions(IconWidth, IconHeight, Color.Green, Color.Black, Session["J"].ToString(), Color.White, 12, FlatIconOptions.flatIconShapeEnum.roundedrect);
                    //}




                    icon3.flatIconOptions = new FlatIconOptions(IconWidth, IconHeight, Color.Green, Color.Black, "X", Color.White, 12, FlatIconOptions.flatIconShapeEnum.roundedrect);

                    marker = new GMarker(latlng, icon3);




                    //// =========Convert lower case string to Camel
                    Customername = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dtUserDetails.Rows[i]["Name"].ToString().ToLower());
                    address = dtUserDetails.Rows[i]["Address1"].ToString().ToLower() + ", " + dtUserDetails.Rows[i]["Address2"].ToString().ToLower() + ", " + dtUserDetails.Rows[i]["Address3"].ToString().ToLower();
                    //// Coordeinates = dsDetails.Tables(0).Rows(i)("GLAT").ToString.ToLower() & "," & dsDetails.Tables(0).Rows(i)("GLONG").ToString.ToLower()

                    if (!Information.IsDBNull(dtUserDetails.Rows[i]["TelNo"]))
                    {
                        contact = Conversions.ToString(dtUserDetails.Rows[i]["TelNo"]);
                    }
                    else
                    {
                        contact = "";
                    }

                    //if (!Information.IsDBNull(dsDetails.Tables[0].Rows[0]["Name"]))
                    //{
                    //    distributor = Conversions.ToString(dsDetails.Tables[0].Rows[0]["Name"]);
                    //}
                    //else
                    //{
                    //    distributor = "";
                    //}

                    //if (!Information.IsDBNull(dsDetails.Tables[0].Rows[0]["RouteName"]))
                    //{
                    //    route = Conversions.ToString(dsDetails.Tables[0].Rows[0]["RouteName"]);
                    //}
                    //else
                    //{
                    //    route = "";
                    //}

                    //if (!Information.IsDBNull(dsDetails.Tables[0].Rows[0]["MobileNo"]))
                    //{
                    //    if (!string.IsNullOrEmpty(contact))
                    //    {
                    //        contact = Conversions.ToString(Operators.ConcatenateObject(contact + "/", dsDetails.Tables[0].Rows[0]["MobileNo"]));
                    //    }
                    //    else
                    //    {
                    //        contact = Conversions.ToString(dsDetails.Tables[0].Rows[0]["MobileNo"]);
                    //    }
                    //}

                    //// =========Convert lower case string to Camel

                    address = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(address);

                    // -----Customer Details
                    string itemheader2 = "";
                    string itemList3 = "";
                    itemheader2 = "<table width=\"300px\" style=\"font-size:9pt;\">";
                    itemList3 = "<tr><td width=100> Name</td><td>:</td><td><b>" + Customername + "</b></td></tr>";
                    // itemList3 = itemList3 + ("<tr><td >Customer Code</td><td>:</td><td>") + regno + ("</td></tr>")
                    itemList3 = itemList3 + "<tr><td>Address</td><td>:</td><td>" + address + "</td></tr>";
                    itemList3 = itemList3 + "<tr><td>Contact No</td><td>:</td><td>" + contact + "</td></tr>";
                    itemList3 = itemList3 + "<tr><td ></td><td></td><td></td></tr>";






                    {
                        itemList3 = itemList3 + "<tr><td  colspan=\"3\" style=\"overflow:hidden;\">" + preorderlstheader + preorderdetailslst + "</td></tr>" + "</table><br/>";
                        strDetails = itemheader2 + itemList3 + "<br/>" + Sales;
                    }



                    //// =======Initialize Gwindow
                    //// Dim commonInfoWindow As New GInfoWindow()
                    var commonInfoWindow = new GInfoWindow(marker, strDetails, false, GListener.Event.mouseover);

                    //// ============add marker and the common window to GMAP
                    // GMap1.Add(marker)
                    GMap1.Add(commonInfoWindow);
                    // GMap1.setCenter(new GLatLng(6.90295d, 79.89388d), 13);

                }

                PlotCurrentLocation();


                //        else if (_IsProductive == false)
                //        {
                //            //    string ReportedTime;
                //            //    string OutletReason;
                //            //    dsDetailsUnProductiveDetails = objBLL.getOutletVisitsatusByCustomer(cmbSalesrep.Value, dtfrom.Date, _chkCustomer); // Unproductive
                //            //    var latlng = new GLatLng();
                //            //    string erpItemId = "";
                //            //    string itemheader1 = "";
                //            //    string itemname = "";
                //            //    string qty = "";
                //            //    string itemList = "";
                //            //    string itemList2 = "";
                //            //    itemheader1 = "<table border=1  style=\"font-size:9pt;border-collapse: collapse;\"><tr><th>SKU</th><th>Item Name</th><th>QTY</th></tr>";
                //            //    latlng.lat = dsDetailsUnProductiveDetails.Tables[0].Rows[0]["GPSLAT"];
                //            //    latlng.lng = dsDetailsUnProductiveDetails.Tables[0].Rows[0]["GPSLONG"];
                //            //    Session("latLong") = latlng;
                //            //    cusid = Conversions.ToInteger(dsDetailsUnProductiveDetails.Tables[0].Rows[0]["customerid"]);
                //            //    GMap1.mapType = GMapType.GTypes.Normal;
                //            //    var vMyLabel = new Label();
                //            //    Session("J") = Session("J") + 1;
                //            //    var icon3 = new GIcon();

                //            //    // ----------Icon Size------------
                //            //    if (Session("J").ToString().Length == 1)
                //            //    {
                //            //        IconWidth = 20;
                //            //        IconHeight = 20;
                //            //    }
                //            //    else if (Session("J").ToString().Length == 2)
                //            //    {
                //            //        IconWidth = 25;
                //            //        IconHeight = 25;
                //            //    }
                //            //    else if (Session("J").ToString().Length == 3)
                //            //    {
                //            //        IconWidth = 30;
                //            //        IconHeight = 30;
                //            //    }

                //            //    icon3.flatIconOptions = new FlatIconOptions(IconWidth, IconHeight, Color.Black, Color.White, Session("J"), Color.White, 12, FlatIconOptions.flatIconShapeEnum.roundedrect);
                //            //    marker = new GMarker(latlng, icon3);


                //            //    // =========Convert lower case string to Camel
                //            //    Customername = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dsDetailsUnProductiveDetails.Tables[0].Rows[0]["Customer"].ToString().ToLower());
                //            //    address = dsDetailsUnProductiveDetails.Tables[0].Rows[0]["Address1"].ToString().ToLower() + ", " + dsDetailsUnProductiveDetails.Tables[0].Rows[0]["Address2"].ToString().ToLower() + ", " + dsDetailsUnProductiveDetails.Tables[0].Rows[0]["Address3"].ToString().ToLower();
                //            //    // Coordeinates = dsDetails.Tables(0).Rows(i)("GLAT").ToString.ToLower() & "," & dsDetails.Tables(0).Rows(i)("GLONG").ToString.ToLower()

                //            //    if (!Information.IsDBNull(dsDetailsUnProductiveDetails.Tables[0].Rows[0]["TelNo"]))
                //            //    {
                //            //        contact = Conversions.ToString(dsDetailsUnProductiveDetails.Tables[0].Rows[0]["TelNo"]);
                //            //    }
                //            //    else
                //            //    {
                //            //        contact = "";
                //            //    }

                //            //    if (!Information.IsDBNull(dsDetailsUnProductiveDetails.Tables[0].Rows[0]["MobileNo"]))
                //            //    {
                //            //        if (!string.IsNullOrEmpty(contact))
                //            //        {
                //            //            contact = Conversions.ToString(Operators.ConcatenateObject(contact + "/", dsDetailsUnProductiveDetails.Tables[0].Rows[0]["MobileNo"]));
                //            //        }
                //            //        else
                //            //        {
                //            //            contact = Conversions.ToString(dsDetailsUnProductiveDetails.Tables[0].Rows[0]["MobileNo"]);
                //            //        }
                //            //    }

                //            //    // =========Convert lower case string to Camel

                //            //    address = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(address);
                //            //    ReportedTime = Conversions.ToString(dsDetailsUnProductiveDetails.Tables[0].Rows[0]["ReportedTime"]);
                //            //    OutletReason = Conversions.ToString(dsDetailsUnProductiveDetails.Tables[0].Rows[0]["reason"]);


                //            //    // -----Customer Details
                //            //    string itemheader2 = "";
                //            //    string itemList3 = "";
                //            //    itemheader2 = "<table width=\"300px\" style=\"font-size:9pt;\">";
                //            //    itemList3 = "<tr><td width=100>Customer Name</td><td>:</td><td><b>" + Customername + "</b></td></tr>";
                //            //    itemList3 = itemList3 + "<tr><td>Address</td><td>:</td><td>" + address + "</td></tr>";
                //            //    itemList3 = itemList3 + "<tr><td>Contact No</td><td>:</td><td>" + contact + "</td></tr>";
                //            //    itemList3 = itemList3 + "<tr><td>Reported Time</td><td>:</td><td>" + ReportedTime + "</td></tr>";
                //            //    itemList3 = itemList3 + "<tr><td>Reason</td><td>:</td><td>" + OutletReason + "</td></tr>";
                //            //    itemList3 = itemList3 + "<tr><td ></td><td></td><td></td></tr>" + "</table><br/>";
                //            //    strDetails = itemheader2 + itemList3 + "<br/>";
                //            //    var commonInfoWindow = new GInfoWindow(marker, strDetails, false, GListener.Event.mouseover);
                //            //    GMap1.Add(commonInfoWindow);
                //        }

                //        if (dsIsProductive.Tables[0].Rows.Count == i + 1)
                //        {

                //            //    // ----------------last invoice
                //            //    var icon4 = new GIcon();
                //            //    icon4.flatIconOptions = new FlatIconOptions(IconWidth, IconHeight, Color.Brown, Color.Black, Session["J"].ToString(), Color.White, 12, FlatIconOptions.flatIconShapeEnum.roundedrect);
                //            //    //// =======Initialize Gwindow
                //            //    var marker4 = new GMarker(Session["latLong"].ToString(), icon4);
                //            //    var commonInfoWindow2 = new GInfoWindow(marker4, strDetails, false, GListener.Event.mouseover);

                //            //    // ============add marker and the common window to GMAP

                //            //    GMap1.Add(commonInfoWindow2);
                //        }
                //    }
                //}
                //}


            }
        }
      
        
        
        private void resetMap()
        {
            GMap1.reset();
            var dsRoutePlot = new DataSet();
            double RouteGLat;
            double RouteGLong;
            var dsRoutes = new DataSet();



            GMap1.setCenter(new GLatLng(6.90295d, 79.89388d), 13);
        

            GMap1.Add(new GMapUI());
            GMap1.enableHookMouseWheelToZoom = false;
            GMap1.resetDirection();
            GMap1.Key = "AIzaSyCY6RSFWHiTu0IC83rCsER2dSSb3lmMyOs";
            // GMap1.CommercialKey = "IriVETusd4CcjDLY9IQ jR + =="

            if (host.Contains("localhost"))
            {
                GMap1.CommercialKey = "Y9krW5z+ZomVm1CrG7GzCg==";
            }
            else if (host.Contains("acl.lk"))
            {
                GMap1.CommercialKey = "H/Ud1pyhv/8=";
            }
            else
            {
                GMap1.CommercialKey = "++i+KEKu2Eg=";
            }

            GMap1.enableDragging = false;
            GMap1.BackColor = Color.White;
            GMap1.mapType = GMapType.GTypes.Normal;
        }




        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                resetMap();
                PloXplaces();

            }
            // End If
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void LoadUserDetails()
        {
            DataView viewUserDetails = (DataView)SqlStakeHolderTypes.Select(DataSourceSelectArguments.Empty);
            dtUserDetails = viewUserDetails.ToTable();
            //SreGetUserDetailsByRetailerId

            DataRow dr = dtUserDetails.Rows[0];

            // Name = dr["FName"].ToString();
            GP = Convert.ToDouble(dr["GPSLat"].ToString());
            GLong = Convert.ToDouble(dr["GLong"].ToString());




        }



        private void BindGMap(DataTable datatable)
        {
            try
            {
                List<ClosestLocations> AddressList = new List<ClosestLocations>();
                foreach (DataRow dr in datatable.Rows)
                {
                    string FullAddress = "No 1 Wewalpitiya Road Kandy";
                    //string FullAddress = dr["Address"].ToString() + " " + dr["City"].ToString() + ", " + dr["Country"].ToString()
                    //    + " " + dr["StateName"].ToString() + " " + dr["ZipCode"].ToString();
                    ClosestLocations MapAddress = new ClosestLocations();
                    MapAddress.description = FullAddress;
                    var locationService = new GoogleLocationService();
                    //  var point = locationService.GetLatLongFromAddress(FullAddress);
                    MapAddress.lat = GP;
                    MapAddress.lng = GLong;
                    AddressList.Add(MapAddress);
                }
                string jsonString = JsonSerializer<List<ClosestLocations>>(AddressList);
                ScriptManager.RegisterArrayDeclaration(Page, "markers", jsonString);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "GoogleMap();", true);
            }
            catch (Exception ex)
            {
            }
        }

        private string JsonSerializer<T>(T addressList)
        {
            throw new NotImplementedException();
        }

        public ClosestLocations()
        {
            this.Load += Page_Load;
        }
        public string description { get; set; }
        public double lng { get; set; }
        public double lat { get; set; }

    }
}