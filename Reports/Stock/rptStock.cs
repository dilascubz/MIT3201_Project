using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Reports.Sales
{
    public partial class rptStock : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStock()
        {
            InitializeComponent();
        }

        private void rptStock_DataSourceDemanded(object sender, EventArgs e)
        {
            sgetProductsTableAdapter.Fill(dsStock1.sgetProducts);
        }
    }
}
