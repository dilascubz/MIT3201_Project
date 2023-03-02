<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StakeholderManagement._Default" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <%--    <div class="hero-section section">
        <div class="hero-slider hero-slider-one fix">
            <div class="hero-item" style="background-image: url(assets2/images/hero/hero-1.jpg)">
                <div class="hero-content">
                    <h1>Get 35% off
                        <br>
                        Latest Baby Product</h1>
                    <a href="#">SHOP NOW</a>
                </div>
            </div>
            <div class="hero-item" style="background-image: url(assets2/images/hero/hero-2.jpg)">
                <div class="hero-content">
                    <h1>Get 35% off
                        <br>
                        Latest Baby Product</h1>
                    <a href="#">SHOP NOW</a>
                </div>
            </div>
        </div>
    </div>--%>


    <style>
        .dxisControl {
            width: 100% !important;
            height: auto !important;
        }

            .dxisControl > .dxis-passePartout {
                position: relative;
                background-color: #000000;
                width: 100% !important;
                height: 100% !important;
            }

            .dxisControl .dxis-imageArea {
                margin: 0 auto;
                position: relative;
                overflow: hidden;
                min-height: 100%;
                width: 100%;
            }

            .dxisControl .dxis-slidePanel, .dxisControl .dxis-nbSlidePanel, .dxisControl .dxis-nbSlidePanelWrapper {
                position: static;
                width: 100vh;
                height: 595px !important;
            }

            .dxisControl .dxis-prevBtnVertWrapper, .dxisControl .dxis-prevBtnVertOutsideWrapper, .dxisControl .dxis-nextBtnVertWrapper, .dxisControl .dxis-nextBtnVertOutsideWrapper, .dxisControl .dxis-prevBtnHorWrapper, .dxisControl .dxis-prevBtnHorOutsideWrapper, .dxisControl .dxis-nextBtnHorWrapper, .dxisControl .dxis-nextBtnHorOutsideWrapper {
                cursor: pointer;
                z-index: 1;
                position: absolute;
                background-color: rgba(235, 199, 4, 0.75);
                border-radius: 50%;
                width: 50px;
                height: 50px;
                margin: 10px;
            }

            .dxisControl .dxis-nextBtnHor {
                margin: 10px 0px 0px 18px;
            }

            .dxisControl .dxis-prevBtnHor {
                margin: 10px 0px 0px 12px;
            }
    </style>

    <style>
        .dxbs-cardview .dxbs-card {
            margin-bottom: 1em;
            position: relative;
            padding: 0;
            height: 300px;
        }

        .cart {
            font-size: 4rem !important;
        }

        .card img {
            display: block;
            height: 200px;
            margin: auto;
        }

        .info:hover {
            background: black !important;
            opacity: 0.8 !important;
        }

        .info {
            position: absolute;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            color: white;
            background-color: black;
            opacity: 0;
            text-align: center;
            transition: all 0.4s ease-in-out;
            -webkit-transition: all 0.4s ease-in-out;
            -moz-transition: all 0.4s ease-in-out;
            -ms-transition: all 0.4s ease-in-out;
            -o-transition: all 0.4s ease-in-out;
        }

            .info:hover {
                opacity: 0.8;
            }

            .info .address {
                padding-bottom: 20px;
            }


        .card .info p,
        .card .info span {
            font-size: 15pt;
            color: white;
            opacity: 0;
            -webkit-transition: all 0.3s ease-out;
            -moz-transition: all 0.3s ease-out;
            -ms-transition: all 0.3s ease-out;
            -o-transition: all 0.3s ease-out;
            transition: all 0.3s ease-out;
            -moz-transform: scale(0);
            -webkit-transform: scale(0);
            -o-transform: scale(0);
            -ms-transform: scale(0);
            transform: scale(0);
        }

        .card .info .address span {
            font-size: 16pt;
        }

        .card:hover .info p,
        .card:hover .info span {
            opacity: 1;
            -moz-transform: scale(1);
            -webkit-transform: scale(1);
            -o-transform: scale(1);
            -ms-transform: scale(1);
            transform: scale(1);
        }

        .card-title1 {
            font-size: 24px;
            color: #e5bf00;
            margin-top: 25%;
            width: 100%
        }

        .card-description {
            margin-top: 20px;
        }
    </style>
    <div class="hero-section section">
        <dx:ASPxImageSlider ID="ASPxImageSlider1" runat="server"
            ClientInstanceName="ImageSlider" ShowNavigationBar="false"
            EnableViewState="False" EnableTheming="False" 
            DataSourceID="SqlAdvertisements" ImageContentBytesField="AdImage">


            <SettingsNavigationBar ThumbnailsModeNavigationButtonVisibility="None" />

            <SettingsAutoGeneratedImages ImageCacheFolder="~/Thumb/" />
        </dx:ASPxImageSlider>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" 
        SelectCommand="SELECT  [Id], [PromoImage] FROM [Promotions] where Id=2"></asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlAdvertisements" runat="server" 
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" 
        SelectCommand="sreGetAdvertisements" SelectCommandType="StoredProcedure">


        <SelectParameters>
            <asp:SessionParameter Name="StakeHolderTypeId" SessionField="StakeholderId" Type="Int32" />
            <asp:SessionParameter Name="UserCategoryId" SessionField="UserCategoryId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>


    <asp:SqlDataSource ID="SqlPromotions" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="sreGetPromotions" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="StakeHolderTypeId" SessionField="StakeholderId" Type="Int32" />
            <asp:SessionParameter Name="UserCategoryId" SessionField="UserCategoryId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>



    <asp:SqlDataSource ID="SqlProductions" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="sreGetProductions" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="StakeHolderTypeId" SessionField="StakeholderId" Type="Int32" />
            <asp:SessionParameter Name="UserCategoryId" SessionField="UserCategoryId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>


    <!-- Banner Section Start -->
    <div class="banner-section section mt-40">
        <div class="container-fluid">
            <div class="row">
                <div class="section-title text-center col mb-30">
                    <h1>Lets Get Healthy</h1>

                </div>
            </div>
            <div class="row row-10 mbn-20">

                <div class="col-lg-12 col-md-6 col-12 mb-20">
                    <dx:BootstrapCardView runat="server" DataSourceID="SqlPromotions" EnableCardsCache="false">
                        <CssClasses Card="animated-card" />
                        <Templates>
                            <Card>
                                <dx:BootstrapBinaryImage ID="Photo" Width="100%" runat="server" Value='<%# Eval("PromoImage") %>' />
                            </Card>
                        </Templates>
                        <SettingsPager ItemsPerPage="3" AlwaysShowPager="false"></SettingsPager>
                        <SettingsLayout CardColSpanLg="4" CardColSpanMd="4" CardColSpanSm="12" />
                    </dx:BootstrapCardView>




                    <%--   <dx:ASPxImageGallery ID="ASPxImageSlixder2" runat="server"
                            ClientInstanceName="ImageSlider" ShowNavigationBar="false" Width="100" 
                            EnableViewState="False" EnableTheming="False" DataSourceID="SqlPromotions"
                            ImageContentBytesField="AdImage">
                         <SettingsFolder ImageCacheFolder="~\Thumb\" />


                   <a href="#" class="banner banner-2">
                               <img src="assets2/images/banner/banner-2.jpg" alt="Banner Image">
                        <div class="content">
                            <h1>New Arrival
                                <br>
                                Baby’s Shoe
                                <br>
                                GET 30% OFF</h1>
                            <a href="#" data-hover="SHOP NOW">SHOP NOW</a>
                        </div>--%>
                    <%-- <div class="banner banner-1 content-left content-middle">
                 
                    </div>--%>
                </div>

                <%--       <div class="col-lg-12 col-md-6 col-12 mb-20">
                    <a href="#" class="banner banner-2">

                        <dx:BootstrapCardView runat="server" Width="50" DataSourceID="SqlPromotions" EnableCardsCache="false">
                            <CssClasses Card="animated-card" />
                            <Templates>
                                <Card>
                                    <dx:BootstrapBinaryImage ID="Photo" Width="500" Height="200" runat="server" Value='<%# Eval("AdImage") %>' />

                                </Card>
                            </Templates>
                            <SettingsPager ItemsPerPage="6"></SettingsPager>
                            <SettingsLayout CardColSpanLg="4" CardColSpanMd="6" CardColSpanSm="12" />
                        </dx:BootstrapCardView>

                        <%-- <img src="assets2/images/banner/banner-2.jpg" alt="Banner Image">

                        <div class="content bg-theme-one">
                            <h1>New Toy’s for your Baby</h1>
                        </div>

                        <span class="banner-offer">25% off</span>

                    </a>
                </div>--%>

                <%-- <div class="col-lg-4 col-md-6 col-12 mb-20">
                    <div class="banner banner-1 content-left content-top">

                        <a href="#" class="image">
                            <img src="assets2/images/banner/banner-3.jpg" alt="Banner Image"></a>

                        <div class="content">
                            <h1>Trendy
                                <br>
                                Collections</h1>
                            <a href="#" data-hover="SHOP NOW">SHOP NOW</a>
                        </div>

                    </div>
                </div>--%>
            </div>
        </div>
    </div>
    <!-- Banner Section End -->


<%--     #############################################################


    <!-- Product Section Start -->
    <div class="product-section section section-padding">
        <div class="container">

            <div class="row">
                <div class="section-title text-center col mb-30">
                    <h1>All Products</h1>
                    <p>All products find here</p>
                </div>
            </div>

            <%--  <div class="row mbn-40">
                <dx:BootstrapCardView Visible="false" runat="server" EnableCardsCache="false">
                    <CssClasses Card="animated-card" />
                    <Columns>
                        <dx:BootstrapCardViewBinaryImageColumn FieldName="Photo">
                            <PropertiesBinaryImage ImageWidth="150px" ImageHeight="150px" />
                        </dx:BootstrapCardViewBinaryImageColumn>
                        <dx:BootstrapCardViewColumn FieldName="FirstName" />
                        <dx:BootstrapCardViewColumn FieldName="LastName" />
                        <dx:BootstrapCardViewColumn FieldName="FullName" UnboundType="String" UnboundExpression="[FirstName] + ' ' + [LastName]" />
                        <dx:BootstrapCardViewColumn FieldName="Title" />
                        <dx:BootstrapCardViewColumn FieldName="Country" />
                        <dx:BootstrapCardViewColumn FieldName="City" />
                        <dx:BootstrapCardViewColumn FieldName="Location" UnboundType="String" UnboundExpression="[Country] + ' ' + [City]" />
                        <dx:BootstrapCardViewColumn FieldName="Address" />
                    </Columns>
                    <Templates>
                        <Card>
                            <dx:BootstrapBinaryImage ID="Photo" runat="server" Value='<%# Eval("Photo") %>' />
                            <div class="info">
                                <p><%# Eval("FullName") %></p>
                                <span><%# Eval("Title") %></span>
                                <div class="address">
                                    <span><%# Eval("Location") %></span>
                                    <br />
                                    <span><%# Eval("Address") %></span>
                                </div>
                            </div>
                        </Card>
                    </Templates>


                    <SettingsPager ItemsPerPage="6"></SettingsPager>
                    <SettingsLayout CardColSpanLg="4" CardColSpanMd="6" CardColSpanSm="12" />
                </dx:BootstrapCardView>









                
                <dx:BootstrapCardView runat="server"  EnableCardsCache="false">
                    <CssClasses Card="Card" />
                    <SettingsPager Mode="EndlessPaging">
                    </SettingsPager>

                    

                    <SettingsText EmptyCard="No items to display." />

                    <StylesExport>
                        <Card BorderSize="1" BorderSides="All"></Card>

                        <Group BorderSize="1" BorderSides="All"></Group>

                        <TabbedGroup BorderSize="1" BorderSides="All"></TabbedGroup>

                        <Tab BorderSize="1"></Tab>
                    </StylesExport>

                    <Columns>
                        <dx:BootstrapCardViewBinaryImageColumn FieldName="PromoImage">
                            <PropertiesBinaryImage ImageWidth="150px" ImageHeight="150px" />
                        </dx:BootstrapCardViewBinaryImageColumn>
                        <dx:BootstrapCardViewColumn FieldName="Name" />
                        <dx:BootstrapCardViewColumn FieldName="Description" />
                        <dx:BootstrapCardViewColumn FieldName="Code" />

                    </Columns>
                    <Templates>
                        <Card>
                            <dx:BootstrapBinaryImage ID="Photo" Width="100%" runat="server" Value='<%# Eval("PromoImage") %>' />
                            <div class="info">
                                <p class="card-title1"><%# Eval("Name") %></p>
                                <span class="card-description"><%# Eval("Description") %></span>
                                <div class="address">
                                    <span><%# Eval("Code") %></span>

                                </div>
                            </div>
                        </Card>
                    </Templates>
                    <SettingsLayout CardColSpanLg="4" CardColSpanMd="4" CardColSpanSm="12" />
                </dx:BootstrapCardView>

            </div>




            <dx:BootstrapCardView runat="server" DataSourceID="SqlProductions" 
                EnableCardsCache="false" AutoGenerateColumns="true">
                <CssClasses Card="animated-card" />
                <SettingsPager Mode="ShowPager" ItemsPerPage="15">
                </SettingsPager>

                <Columns>
                    <dx:BootstrapCardViewBinaryImageColumn FieldName="PromoImage">
                        <PropertiesBinaryImage ImageWidth="250px" ImageHeight="250px" />
                    </dx:BootstrapCardViewBinaryImageColumn>
                    <dx:BootstrapCardViewColumn FieldName="Name" />
                    <dx:BootstrapCardViewColumn FieldName="Description" />
                    <dx:BootstrapCardViewColumn FieldName="Code" />

                </Columns>
                <Templates>
                    <Card>
                        <dx:BootstrapBinaryImage ID="Photo" Width="100%" runat="server" Value='<%# Eval("PromoImage") %>' />
                        <div class="info">
                            <p><%# Eval("Name") %></p>
                            <span><%# Eval("Description") %></span>
                            <div class="address">
                                <span><%# Eval("Code") %></span>

                            </div>
                        </div>
                    </Card>
                </Templates>
                <SettingsPager ItemsPerPage="3"></SettingsPager>
                <SettingsLayout CardColSpanLg="4" CardColSpanMd="4" CardColSpanSm="12" />
            </dx:BootstrapCardView>
        </div>
    </div>

--%>



    <%--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@--%>





    <%--<div class="product-section section section-padding">
        <div class="container">

            <div class="row">
                <div class="section-title text-center col mb-30">
                    <h1>Popular Products</h1>
                    <p>All popular product find here</p>
                </div>
            </div>

            <div class="row mbn-40">

                <div class="col-xl-3 col-lg-4 col-md-6 col-12 mb-40">

                    <div class="product-item">
                        <div class="product-inner">

                            <div class="image">
                                <img src="assets2/images/product/product-1.jpg" alt="">

                                <div class="image-overlay">
                                    <div class="action-buttons">
                                        <button>add to cart</button>
                                        <button>add to wishlist</button>
                                    </div>
                                </div>

                            </div>

                            <div class="content">

                                <div class="content-left">

                                    <h4 class="title"><a href="single-product.html">Tmart Baby Dress</a></h4>

                                    <div class="ratting">
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star-half-o"></i>
                                        <i class="fa fa-star-o"></i>
                                    </div>

                                    <h5 class="size">Size: <span>S</span><span>M</span><span>L</span><span>XL</span></h5>
                                    <h5 class="color">Color: <span style="background-color: #ffb2b0"></span><span style="background-color: #0271bc"></span><span style="background-color: #efc87c"></span><span style="background-color: #00c183"></span></h5>

                                </div>

                                <div class="content-right">
                                    <span class="price">$25</span>
                                </div>

                            </div>

                        </div>
                    </div>

                </div>

                <div class="col-xl-3 col-lg-4 col-md-6 col-12 mb-40">

                    <div class="product-item">
                        <div class="product-inner">

                            <div class="image">
                                <img src="assets2/images/product/product-2.jpg" alt="">

                                <div class="image-overlay">
                                    <div class="action-buttons">
                                        <button>add to cart</button>
                                        <button>add to wishlist</button>
                                    </div>
                                </div>

                            </div>

                            <div class="content">

                                <div class="content-left">

                                    <h4 class="title"><a href="single-product.html">Jumpsuit Outfits</a></h4>

                                    <div class="ratting">
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                    </div>

                                    <h5 class="size">Size: <span>S</span><span>M</span><span>L</span><span>XL</span></h5>
                                    <h5 class="color">Color: <span style="background-color: #ffb2b0"></span><span style="background-color: #0271bc"></span><span style="background-color: #efc87c"></span><span style="background-color: #00c183"></span></h5>

                                </div>

                                <div class="content-right">
                                    <span class="price">$09</span>
                                </div>

                            </div>

                        </div>
                    </div>

                </div>

                <div class="col-xl-3 col-lg-4 col-md-6 col-12 mb-40">

                    <div class="product-item">
                        <div class="product-inner">

                            <div class="image">
                                <img src="assets2/images/product/product-3.jpg" alt="">

                                <div class="image-overlay">
                                    <div class="action-buttons">
                                        <button>add to cart</button>
                                        <button>add to wishlist</button>
                                    </div>
                                </div>

                            </div>

                            <div class="content">

                                <div class="content-left">

                                    <h4 class="title"><a href="single-product.html">Smart Shirt</a></h4>

                                    <div class="ratting">
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star-o"></i>
                                    </div>

                                    <h5 class="size">Size: <span>S</span><span>M</span><span>L</span><span>XL</span></h5>
                                    <h5 class="color">Color: <span style="background-color: #ffb2b0"></span><span style="background-color: #0271bc"></span><span style="background-color: #efc87c"></span><span style="background-color: #00c183"></span></h5>

                                </div>

                                <div class="content-right">
                                    <span class="price">$18</span>
                                </div>

                            </div>

                        </div>
                    </div>

                </div>

                <div class="col-xl-3 col-lg-4 col-md-6 col-12 mb-40">

                    <div class="product-item">
                        <div class="product-inner">

                            <div class="image">
                                <img src="assets2/images/product/product-4.jpg" alt="">

                                <div class="image-overlay">
                                    <div class="action-buttons">
                                        <button>add to cart</button>
                                        <button>add to wishlist</button>
                                    </div>
                                </div>

                            </div>

                            <div class="content">

                                <div class="content-left">

                                    <h4 class="title"><a href="single-product.html">Kids Shoe</a></h4>

                                    <div class="ratting">
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star-half-o"></i>
                                        <i class="fa fa-star-o"></i>
                                    </div>

                                    <h5 class="size">Size: <span>S</span><span>M</span><span>L</span><span>XL</span></h5>
                                    <h5 class="color">Color: <span style="background-color: #ffb2b0"></span><span style="background-color: #0271bc"></span><span style="background-color: #efc87c"></span><span style="background-color: #00c183"></span></h5>

                                </div>

                                <div class="content-right">
                                    <span class="price">$15</span>
                                </div>

                            </div>

                        </div>
                    </div>

                </div>

                <div class="col-xl-3 col-lg-4 col-md-6 col-12 mb-40">

                    <div class="product-item">
                        <div class="product-inner">

                            <div class="image">
                                <img src="assets2/images/product/product-5.jpg" alt="">

                                <div class="image-overlay">
                                    <div class="action-buttons">
                                        <button>add to cart</button>
                                        <button>add to wishlist</button>
                                    </div>
                                </div>

                            </div>

                            <div class="content">

                                <div class="content-left">

                                    <h4 class="title"><a href="single-product.html">Bowknot Bodysuit</a></h4>

                                    <div class="ratting">
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star-half-o"></i>
                                    </div>

                                    <h5 class="size">Size: <span>S</span><span>M</span><span>L</span><span>XL</span></h5>
                                    <h5 class="color">Color: <span style="background-color: #ffb2b0"></span><span style="background-color: #0271bc"></span><span style="background-color: #efc87c"></span><span style="background-color: #00c183"></span></h5>

                                </div>

                                <div class="content-right">
                                    <span class="price">$12</span>
                                </div>

                            </div>

                        </div>
                    </div>

                </div>

                <div class="col-xl-3 col-lg-4 col-md-6 col-12 mb-40">

                    <div class="product-item">
                        <div class="product-inner">

                            <div class="image">
                                <img src="assets2/images/product/product-6.jpg" alt="">

                                <div class="image-overlay">
                                    <div class="action-buttons">
                                        <button>add to cart</button>
                                        <button>add to wishlist</button>
                                    </div>
                                </div>

                            </div>

                            <div class="content">

                                <div class="content-left">

                                    <h4 class="title"><a href="single-product.html">Striped T-Shirt</a></h4>

                                    <div class="ratting">
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star-o"></i>
                                    </div>

                                    <h5 class="size">Size: <span>S</span><span>M</span><span>L</span><span>XL</span></h5>
                                    <h5 class="color">Color: <span style="background-color: #ffb2b0"></span><span style="background-color: #0271bc"></span><span style="background-color: #efc87c"></span><span style="background-color: #00c183"></span></h5>

                                </div>

                                <div class="content-right">
                                    <span class="price">$12</span>
                                </div>

                            </div>

                        </div>
                    </div>

                </div>

                <div class="col-xl-3 col-lg-4 col-md-6 col-12 mb-40">

                    <div class="product-item">
                        <div class="product-inner">

                            <div class="image">
                                <img src="assets2/images/product/product-7.jpg" alt="">

                                <div class="image-overlay">
                                    <div class="action-buttons">
                                        <button>add to cart</button>
                                        <button>add to wishlist</button>
                                    </div>
                                </div>

                            </div>

                            <div class="content">

                                <div class="content-left">

                                    <h4 class="title"><a href="single-product.html">Kislen Jak Tops</a></h4>

                                    <div class="ratting">
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                    </div>

                                    <h5 class="size">Size: <span>S</span><span>M</span><span>L</span><span>XL</span></h5>
                                    <h5 class="color">Color: <span style="background-color: #ffb2b0"></span><span style="background-color: #0271bc"></span><span style="background-color: #efc87c"></span><span style="background-color: #00c183"></span></h5>

                                </div>

                                <div class="content-right">
                                    <span class="price">$29</span>
                                </div>

                            </div>

                        </div>
                    </div>

                </div>

                <div class="col-xl-3 col-lg-4 col-md-6 col-12 mb-40">

                    <div class="product-item">
                        <div class="product-inner">

                            <div class="image">
                                <img src="assets2/images/product/product-8.jpg" alt="">

                                <div class="image-overlay">
                                    <div class="action-buttons">
                                        <button>add to cart</button>
                                        <button>add to wishlist</button>
                                    </div>
                                </div>

                            </div>

                            <div class="content">

                                <div class="content-left">

                                    <h4 class="title"><a href="single-product.html">Lattic Shirt</a></h4>

                                    <div class="ratting">
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star-o"></i>
                                    </div>

                                    <h5 class="size">Size: <span>S</span><span>M</span><span>L</span><span>XL</span></h5>
                                    <h5 class="color">Color: <span style="background-color: #ffb2b0"></span><span style="background-color: #0271bc"></span><span style="background-color: #efc87c"></span><span style="background-color: #00c183"></span></h5>

                                </div>

                                <div class="content-right">
                                    <span class="price">$08</span>
                                </div>

                            </div>

                        </div>
                    </div>

                </div>

            </div>

        </div>
    </div>--%>
    <!-- Product Section End -->
</asp:Content>
