using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Reports.DailyUsers
{
    public partial class rptDailyUsers : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDailyUsers()
        {
            InitializeComponent();
        }

        private void rptDailyUsers_DataSourceDemanded(object sender, EventArgs e)
        {
            // Stp_GetCustomerWiseMontlySalesTableAdapter.Fill(Ds_CustomerWiseMonthlySales1.stp_GetCustomerWiseMontlySales, intArea.Value, intYear.Value, intRoute.Value)
            sgetHealthUserDetailsTableAdapter.Fill(dsusers1.sgetHealthUserDetails, Convert.ToInt32(HealthUser.Value.ToString()),Convert.ToDateTime(Fromdate.Value), Convert.ToDateTime(ToDate.Value));
        }
    }
}
