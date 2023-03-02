using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Reports.UserDataCalculation
{
    public partial class rptUserDataCalculation : DevExpress.XtraReports.UI.XtraReport
    {
        public rptUserDataCalculation()
        {
            InitializeComponent();
        }

        private void rptUserDataCalculation_DataSourceDemanded(object sender, EventArgs e)
        {
            // Stp_GetCustomerWiseMontlySalesTableAdapter.Fill(Ds_CustomerWiseMonthlySales1.stp_GetCustomerWiseMontlySales, intArea.Value, intYear.Value, intRoute.Value)
           // dsUse
        }
    }
}
