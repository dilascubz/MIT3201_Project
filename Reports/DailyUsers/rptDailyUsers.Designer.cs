namespace Reports.DailyUsers
{
    partial class rptDailyUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptDailyUsers));
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.picboxlogo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.XrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCompnytitle = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.XrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.XrTableCell74 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.dsusers1 = new Reports.DailyUsers.dsusers();
            this.sgetHealthUserDetailsTableAdapter = new Reports.DailyUsers.dsusersTableAdapters.sgetHealthUserDetailsTableAdapter();
            this.HealthUser = new DevExpress.XtraReports.Parameters.Parameter();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.XrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.XrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.Fromdate = new DevExpress.XtraReports.Parameters.Parameter();
            this.ToDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.FitnessType = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.XrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsusers1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel11,
            this.xrLabel1,
            this.xrLabel15,
            this.xrLabel13,
            this.xrLabel12,
            this.xrLabel10,
            this.picboxlogo,
            this.XrLabel2,
            this.lblCompnytitle});
            this.TopMargin.HeightF = 211.8055F;
            this.TopMargin.Name = "TopMargin";
            // 
            // xrLabel15
            // 
            this.xrLabel15.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?ToDate")});
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(151.0417F, 188.5834F);
            this.xrLabel15.Multiline = true;
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel15.Text = "xrLabel15";
            this.xrLabel15.TextFormatString = "{0:dd-MMM-yy}";
            // 
            // xrLabel13
            // 
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(3.178914E-05F, 188.5834F);
            this.xrLabel13.Multiline = true;
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(151.0417F, 23F);
            this.xrLabel13.Text = "To Date";
            // 
            // xrLabel12
            // 
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(0F, 165.5834F);
            this.xrLabel12.Multiline = true;
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(151.0417F, 23F);
            this.xrLabel12.Text = "From Date";
            // 
            // xrLabel10
            // 
            this.xrLabel10.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?Fromdate")});
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(151.0417F, 165.5834F);
            this.xrLabel10.Multiline = true;
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel10.Text = "xrLabel10";
            this.xrLabel10.TextFormatString = "{0:dd-MMM-yy}";
            // 
            // picboxlogo
            // 
            this.picboxlogo.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("picboxlogo.ImageSource"));
            this.picboxlogo.LocationFloat = new DevExpress.Utils.PointFloat(3.532127E-05F, 0F);
            this.picboxlogo.Name = "picboxlogo";
            this.picboxlogo.SizeF = new System.Drawing.SizeF(121.1805F, 82.78703F);
            this.picboxlogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            this.picboxlogo.Visible = false;
            // 
            // XrLabel2
            // 
            this.XrLabel2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.XrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 105.4722F);
            this.XrLabel2.Name = "XrLabel2";
            this.XrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel2.SizeF = new System.Drawing.SizeF(568.75F, 23.00001F);
            this.XrLabel2.StylePriority.UseFont = false;
            this.XrLabel2.Text = "UserWise Report";
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
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3});
            this.Detail.HeightF = 23F;
            this.Detail.Name = "Detail";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel9.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AddressLine1]")});
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(214.5833F, 0F);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(180.2084F, 23F);
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.Text = "xrLabel9";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Email]")});
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(394.7917F, 0F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(151.0416F, 23F);
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.Text = "xrLabel8";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Weight]")});
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(792.7083F, 0F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(158.3335F, 23F);
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.Text = "xrLabel7";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Height]")});
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(647.9167F, 0F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(144.7915F, 23F);
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.Text = "xrLabel6";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Gender]")});
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(545.8333F, 0F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(102.0834F, 23F);
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.Text = "xrLabel5";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[LName]")});
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(100F, 0F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(114.5833F, 23F);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.Text = "xrLabel4";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[FName]")});
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(3.178914E-05F, 0F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.Text = "xrLabel3";
            // 
            // XrTable2
            // 
            this.XrTable2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.XrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrTable2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.XrTable2.LocationFloat = new DevExpress.Utils.PointFloat(3.178914E-05F, 0F);
            this.XrTable2.Name = "XrTable2";
            this.XrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.XrTableRow3});
            this.XrTable2.SizeF = new System.Drawing.SizeF(951.0416F, 24.47919F);
            this.XrTable2.StylePriority.UseBorderColor = false;
            this.XrTable2.StylePriority.UseBorders = false;
            this.XrTable2.StylePriority.UseFont = false;
            // 
            // XrTableRow3
            // 
            this.XrTableRow3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.XrTableRow3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.XrTableCell74,
            this.XrTableCell31,
            this.XrTableCell32,
            this.XrTableCell33,
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3});
            this.XrTableRow3.Name = "XrTableRow3";
            this.XrTableRow3.StylePriority.UseBorderColor = false;
            this.XrTableRow3.StylePriority.UseBorders = false;
            this.XrTableRow3.Weight = 0.5D;
            // 
            // XrTableCell74
            // 
            this.XrTableCell74.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrTableCell74.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.XrTableCell74.Multiline = true;
            this.XrTableCell74.Name = "XrTableCell74";
            this.XrTableCell74.StylePriority.UseBorders = false;
            this.XrTableCell74.StylePriority.UseFont = false;
            this.XrTableCell74.StylePriority.UseTextAlignment = false;
            this.XrTableCell74.Text = "First Name";
            this.XrTableCell74.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.XrTableCell74.Weight = 2.3307411823024164D;
            // 
            // XrTableCell31
            // 
            this.XrTableCell31.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrTableCell31.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.XrTableCell31.Name = "XrTableCell31";
            this.XrTableCell31.StylePriority.UseBorders = false;
            this.XrTableCell31.StylePriority.UseFont = false;
            this.XrTableCell31.StylePriority.UseTextAlignment = false;
            this.XrTableCell31.Text = "Surname";
            this.XrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.XrTableCell31.Weight = 2.6706406383898509D;
            // 
            // XrTableCell32
            // 
            this.XrTableCell32.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrTableCell32.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.XrTableCell32.Multiline = true;
            this.XrTableCell32.Name = "XrTableCell32";
            this.XrTableCell32.StylePriority.UseBorders = false;
            this.XrTableCell32.StylePriority.UseFont = false;
            this.XrTableCell32.StylePriority.UseTextAlignment = false;
            this.XrTableCell32.Text = "Address";
            this.XrTableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.XrTableCell32.Weight = 4.200191069184009D;
            // 
            // XrTableCell33
            // 
            this.XrTableCell33.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrTableCell33.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.XrTableCell33.Multiline = true;
            this.XrTableCell33.Name = "XrTableCell33";
            this.XrTableCell33.StylePriority.UseBorders = false;
            this.XrTableCell33.StylePriority.UseFont = false;
            this.XrTableCell33.StylePriority.UseTextAlignment = false;
            this.XrTableCell33.Text = "Email";
            this.XrTableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.XrTableCell33.Weight = 3.52038836524518D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell1.Multiline = true;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseBorders = false;
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "Gender";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell1.Weight = 2.3792990678865D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseBorders = false;
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "Height";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell2.Weight = 3.3747179539836525D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseBorders = false;
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "Weight";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell3.Weight = 3.6903403455403048D;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrTable2});
            this.GroupHeader1.HeightF = 25.6945F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // dsusers1
            // 
            this.dsusers1.DataSetName = "dsusers";
            this.dsusers1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sgetHealthUserDetailsTableAdapter
            // 
            this.sgetHealthUserDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // HealthUser
            // 
            this.HealthUser.Name = "HealthUser";
            this.HealthUser.Type = typeof(int);
            this.HealthUser.ValueInfo = "0";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrLabel17,
            this.XrPageInfo2,
            this.XrPageInfo3});
            this.PageFooter.HeightF = 23F;
            this.PageFooter.Name = "PageFooter";
            // 
            // XrLabel17
            // 
            this.XrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(54.58384F, 0F);
            this.XrLabel17.Name = "XrLabel17";
            this.XrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel17.SizeF = new System.Drawing.SizeF(446.9374F, 22.99999F);
            this.XrLabel17.Text = "© HealthScore Fitness Application .All Rights Reserved.";
            // 
            // XrPageInfo2
            // 
            this.XrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(618.75F, 0F);
            this.XrPageInfo2.Name = "XrPageInfo2";
            this.XrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.XrPageInfo2.SizeF = new System.Drawing.SizeF(173.9583F, 23F);
            this.XrPageInfo2.StylePriority.UseTextAlignment = false;
            this.XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.XrPageInfo2.TextFormatString = "{0:dd-MMM-yy hh:mm tt}";
            // 
            // XrPageInfo3
            // 
            this.XrPageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(792.7083F, 0F);
            this.XrPageInfo3.Name = "XrPageInfo3";
            this.XrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrPageInfo3.SizeF = new System.Drawing.SizeF(48.95831F, 23F);
            this.XrPageInfo3.StylePriority.UseTextAlignment = false;
            this.XrPageInfo3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Fromdate
            // 
            this.Fromdate.Name = "Fromdate";
            this.Fromdate.Type = typeof(System.DateTime);
            this.Fromdate.ValueInfo = "2022-11-24";
            // 
            // ToDate
            // 
            this.ToDate.Name = "ToDate";
            this.ToDate.Type = typeof(System.DateTime);
            this.ToDate.ValueInfo = "2022-11-24";
            // 
            // xrLabel1
            // 
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 142.5834F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(151.0417F, 23F);
            this.xrLabel1.Text = "Fitness Type";
            // 
            // FitnessType
            // 
            this.FitnessType.Description = "Parameter1";
            this.FitnessType.Name = "FitnessType";
            // 
            // xrLabel11
            // 
            this.xrLabel11.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?FitnessType")});
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(151.0417F, 142.5834F);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel11.Text = "xrLabel11";
            // 
            // rptDailyUsers
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.GroupHeader1,
            this.PageFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.dsusers1});
            this.DataAdapter = this.sgetHealthUserDetailsTableAdapter;
            this.DataMember = "sgetHealthUserDetails";
            this.DataSource = this.dsusers1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(0, 3, 212, 0);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.HealthUser,
            this.Fromdate,
            this.ToDate,
            this.FitnessType});
            this.Version = "20.2";
            this.DataSourceDemanded += new System.EventHandler<System.EventArgs>(this.rptDailyUsers_DataSourceDemanded);
            ((System.ComponentModel.ISupportInitialize)(this.XrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsusers1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        internal DevExpress.XtraReports.UI.XRLabel lblCompnytitle;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel2;
        internal DevExpress.XtraReports.UI.XRTable XrTable2;
        internal DevExpress.XtraReports.UI.XRTableRow XrTableRow3;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell74;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell31;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell32;
        internal DevExpress.XtraReports.UI.XRTableCell XrTableCell33;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        internal DevExpress.XtraReports.UI.XRPictureBox picboxlogo;
        private dsusers dsusers1;
        private dsusersTableAdapters.sgetHealthUserDetailsTableAdapter sgetHealthUserDetailsTableAdapter;
        public DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        public DevExpress.XtraReports.Parameters.Parameter HealthUser;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        internal DevExpress.XtraReports.UI.XRLabel XrLabel17;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo2;
        internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo3;
        public DevExpress.XtraReports.UI.XRLabel xrLabel10;
        public DevExpress.XtraReports.Parameters.Parameter ToDate;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        public DevExpress.XtraReports.Parameters.Parameter Fromdate;
        public DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        public DevExpress.XtraReports.Parameters.Parameter FitnessType;
    }
}
