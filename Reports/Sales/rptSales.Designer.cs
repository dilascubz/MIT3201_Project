namespace Reports.Sales
{
    partial class rptSales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptSales));
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.sgetHealthUserDetailsTableAdapter = new Reports.DailyUsers.dsusersTableAdapters.sgetHealthUserDetailsTableAdapter();
            this.lblCompnytitle = new DevExpress.XtraReports.UI.XRLabel();
            this.picboxlogo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.XrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.XrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.XrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.XrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblCompnytitle,
            this.XrLabel2,
            this.picboxlogo});
            this.TopMargin.HeightF = 135F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 6.66666F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Name = "Detail";
            // 
            // sgetHealthUserDetailsTableAdapter
            // 
            this.sgetHealthUserDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // lblCompnytitle
            // 
            this.lblCompnytitle.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.lblCompnytitle.LocationFloat = new DevExpress.Utils.PointFloat(121.1805F, 0F);
            this.lblCompnytitle.Multiline = true;
            this.lblCompnytitle.Name = "lblCompnytitle";
            this.lblCompnytitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCompnytitle.SizeF = new System.Drawing.SizeF(702.8195F, 28.20834F);
            this.lblCompnytitle.StylePriority.UseFont = false;
            this.lblCompnytitle.StylePriority.UseTextAlignment = false;
            this.lblCompnytitle.Text = "HealthScore-Fitness Application";
            this.lblCompnytitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            // XrLabel2
            // 
            this.XrLabel2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.XrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 111.7222F);
            this.XrLabel2.Name = "XrLabel2";
            this.XrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel2.SizeF = new System.Drawing.SizeF(568.75F, 23.00001F);
            this.XrLabel2.StylePriority.UseFont = false;
            this.XrLabel2.Text = "Product Sales";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrPageInfo3,
            this.XrPageInfo2,
            this.XrLabel17});
            this.PageFooter.HeightF = 39.99999F;
            this.PageFooter.Name = "PageFooter";
            // 
            // XrPageInfo3
            // 
            this.XrPageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(797.9166F, 16.49996F);
            this.XrPageInfo3.Name = "XrPageInfo3";
            this.XrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrPageInfo3.SizeF = new System.Drawing.SizeF(48.95831F, 23F);
            this.XrPageInfo3.StylePriority.UseTextAlignment = false;
            this.XrPageInfo3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // XrPageInfo2
            // 
            this.XrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(626.0417F, 16.49996F);
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
            this.XrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(59.79217F, 16.49996F);
            this.XrLabel17.Name = "XrLabel17";
            this.XrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel17.SizeF = new System.Drawing.SizeF(446.9374F, 22.99999F);
            this.XrLabel17.Text = "© HealthScore Fitness Application .All Rights Reserved.";
            // 
            // rptSales
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.PageFooter});
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(3, 0, 135, 7);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "20.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DailyUsers.dsusersTableAdapters.sgetHealthUserDetailsTableAdapter sgetHealthUserDetailsTableAdapter;
        internal DevExpress.XtraReports.UI.XRLabel lblCompnytitle;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel2;
        internal DevExpress.XtraReports.UI.XRPictureBox picboxlogo;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo3;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo2;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel17;
    }
}
