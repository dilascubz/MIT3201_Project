namespace Reports.Stock
{
    partial class rptStocks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptStocks));
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.lblCompnytitle = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.picboxlogo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.XrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.XrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.XrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.XrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.sreGetUserWiseBMITableAdapter = new Reports.UserWiseGoals.dsUserWiseTableAdapters.sreGetUserWiseBMITableAdapter();
            this.sgetHealthUserDetailsTableAdapter = new Reports.DailyUsers.dsusersTableAdapters.sgetHealthUserDetailsTableAdapter();
            this.sgetProductsTableAdapter = new Reports.Stock.DsStockTableAdapters.sgetProductsTableAdapter();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.dsStock1 = new Reports.Stock.DsStock();
            ((System.ComponentModel.ISupportInitialize)(this.dsStock1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblCompnytitle,
            this.XrLabel2,
            this.picboxlogo,
            this.XrLabel9,
            this.XrLabel6,
            this.XrLabel10,
            this.XrLabel11});
            this.TopMargin.HeightF = 212F;
            this.TopMargin.Name = "TopMargin";
            // 
            // lblCompnytitle
            // 
            this.lblCompnytitle.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.lblCompnytitle.LocationFloat = new DevExpress.Utils.PointFloat(121.1805F, 0F);
            this.lblCompnytitle.Multiline = true;
            this.lblCompnytitle.Name = "lblCompnytitle";
            this.lblCompnytitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCompnytitle.SizeF = new System.Drawing.SizeF(690.8195F, 28.20834F);
            this.lblCompnytitle.StylePriority.UseFont = false;
            this.lblCompnytitle.StylePriority.UseTextAlignment = false;
            this.lblCompnytitle.Text = "HealthScore-Fitness Application";
            this.lblCompnytitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // XrLabel2
            // 
            this.XrLabel2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.XrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 111.7222F);
            this.XrLabel2.Name = "XrLabel2";
            this.XrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel2.SizeF = new System.Drawing.SizeF(568.75F, 23.00001F);
            this.XrLabel2.StylePriority.UseFont = false;
            this.XrLabel2.Text = "Product  Stocks";
            // 
            // picboxlogo
            // 
            this.picboxlogo.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("picboxlogo.ImageSource"));
            this.picboxlogo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.picboxlogo.Name = "picboxlogo";
            this.picboxlogo.SizeF = new System.Drawing.SizeF(121.1805F, 82.78703F);
            this.picboxlogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            this.picboxlogo.Visible = false;
            // 
            // XrLabel9
            // 
            this.XrLabel9.BorderColor = System.Drawing.Color.Black;
            this.XrLabel9.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(0F, 166.3889F);
            this.XrLabel9.Name = "XrLabel9";
            this.XrLabel9.SizeF = new System.Drawing.SizeF(105.1897F, 45.41667F);
            this.XrLabel9.StylePriority.UseBorderColor = false;
            this.XrLabel9.StylePriority.UseBorders = false;
            this.XrLabel9.StylePriority.UseTextAlignment = false;
            this.XrLabel9.Text = "Item Code";
            this.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XrLabel6
            // 
            this.XrLabel6.BorderColor = System.Drawing.Color.Black;
            this.XrLabel6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(452.7082F, 166.3889F);
            this.XrLabel6.Multiline = true;
            this.XrLabel6.Name = "XrLabel6";
            this.XrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel6.SizeF = new System.Drawing.SizeF(204.1332F, 45.41667F);
            this.XrLabel6.StylePriority.UseBorderColor = false;
            this.XrLabel6.StylePriority.UseBorders = false;
            this.XrLabel6.StylePriority.UseTextAlignment = false;
            this.XrLabel6.Text = "Qty";
            this.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XrLabel10
            // 
            this.XrLabel10.BorderColor = System.Drawing.Color.Black;
            this.XrLabel10.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(105.1897F, 166.3889F);
            this.XrLabel10.Name = "XrLabel10";
            this.XrLabel10.SizeF = new System.Drawing.SizeF(187.3871F, 45.41667F);
            this.XrLabel10.StylePriority.UseBorderColor = false;
            this.XrLabel10.StylePriority.UseBorders = false;
            this.XrLabel10.StylePriority.UseTextAlignment = false;
            this.XrLabel10.Text = "Item Name";
            this.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XrLabel11
            // 
            this.XrLabel11.BorderColor = System.Drawing.Color.Black;
            this.XrLabel11.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(292.5768F, 166.3889F);
            this.XrLabel11.Multiline = true;
            this.XrLabel11.Name = "XrLabel11";
            this.XrLabel11.SizeF = new System.Drawing.SizeF(160.1314F, 45.41667F);
            this.XrLabel11.StylePriority.UseBorderColor = false;
            this.XrLabel11.StylePriority.UseBorders = false;
            this.XrLabel11.StylePriority.UseTextAlignment = false;
            this.XrLabel11.Text = "Unit Price (Rs.)";
            this.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 2.083333F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel1});
            this.Detail.HeightF = 25.16664F;
            this.Detail.Name = "Detail";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Qty]")});
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(452.7082F, 0F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(204.1332F, 23F);
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.Text = "xrLabel5";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[WholeSalePrice]")});
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(292.5768F, 1.458295F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(160.1314F, 23F);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.Text = "xrLabel4";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Name]")});
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(105.1897F, 1.458295F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(187.3871F, 23F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.Text = "xrLabel3";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Code]")});
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(105.1897F, 23F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.Text = "xrLabel1";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrPageInfo3,
            this.XrPageInfo2,
            this.XrLabel17});
            this.PageFooter.HeightF = 25F;
            this.PageFooter.Name = "PageFooter";
            // 
            // XrPageInfo3
            // 
            this.XrPageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(748.1245F, 0F);
            this.XrPageInfo3.Name = "XrPageInfo3";
            this.XrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrPageInfo3.SizeF = new System.Drawing.SizeF(48.95831F, 23F);
            this.XrPageInfo3.StylePriority.UseTextAlignment = false;
            this.XrPageInfo3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // XrPageInfo2
            // 
            this.XrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(576.2495F, 0F);
            this.XrPageInfo2.Name = "XrPageInfo2";
            this.XrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.XrPageInfo2.SizeF = new System.Drawing.SizeF(171.8749F, 23F);
            this.XrPageInfo2.StylePriority.UseTextAlignment = false;
            this.XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.XrPageInfo2.TextFormatString = "{0:dd-MMM-yy hh:mm tt}";
            // 
            // XrLabel17
            // 
            this.XrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 0F);
            this.XrLabel17.Name = "XrLabel17";
            this.XrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel17.SizeF = new System.Drawing.SizeF(446.9374F, 22.99999F);
            this.XrLabel17.Text = "© HealthScore Fitness Application .All Rights Reserved.";
            // 
            // sreGetUserWiseBMITableAdapter
            // 
            this.sreGetUserWiseBMITableAdapter.ClearBeforeFill = true;
            // 
            // sgetHealthUserDetailsTableAdapter
            // 
            this.sgetHealthUserDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // sgetProductsTableAdapter
            // 
            this.sgetProductsTableAdapter.ClearBeforeFill = true;
            // 
            // ReportFooter
            // 
            this.ReportFooter.HeightF = 0F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // dsStock1
            // 
            this.dsStock1.DataSetName = "DsStock";
            this.dsStock1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rptStocks
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.PageFooter,
            this.ReportFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.dsStock1});
            this.DataMember = "sgetProducts";
            this.DataSource = this.dsStock1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(5, 0, 212, 2);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "20.2";
            this.DataSourceDemanded += new System.EventHandler<System.EventArgs>(this.rptStocks_DataSourceDemanded);
            ((System.ComponentModel.ISupportInitialize)(this.dsStock1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel2;
        internal DevExpress.XtraReports.UI.XRPictureBox picboxlogo;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel9;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel6;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel10;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel11;
        private UserWiseGoals.dsUserWiseTableAdapters.sreGetUserWiseBMITableAdapter sreGetUserWiseBMITableAdapter;
        private DailyUsers.dsusersTableAdapters.sgetHealthUserDetailsTableAdapter sgetHealthUserDetailsTableAdapter;
        private DsStockTableAdapters.sgetProductsTableAdapter sgetProductsTableAdapter;
        internal DevExpress.XtraReports.UI.XRLabel lblCompnytitle;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DsStock dsStock1;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo3;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo2;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel17;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
    }
}
