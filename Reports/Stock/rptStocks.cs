using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Reports.Stock
{
    public partial class rptStocks : DevExpress.XtraReports.UI.XtraReport
    {
        public rptStocks()
        {
            InitializeComponent();
        }

        private void rptStocks_DataSourceDemanded(object sender, EventArgs e)
        {
            sgetProductsTableAdapter.Fill(dsStock1.sgetProducts);

        }
    }
}
