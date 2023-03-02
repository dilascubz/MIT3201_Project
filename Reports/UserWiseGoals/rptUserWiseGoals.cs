using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Reports.UserWiseGoals
{
    public partial class rptUserWiseGoals : DevExpress.XtraReports.UI.XtraReport
    {
        public rptUserWiseGoals()
        {
            InitializeComponent();
        }

        private void rptUserWiseGoals_DataSourceDemanded(object sender, EventArgs e)
        {
            //sgetProductsTableAdapter.Fill(dsStock1.sgetProducts);
            sreGetUserWiseBMITableAdapter.Fill(dsUserWise1.sreGetUserWiseBMI, Convert.ToInt32(UserId.Value.ToString()));
        }
    }
}
