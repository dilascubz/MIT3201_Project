﻿<%@ Page Title="Password Change" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="zx.aspx.cs" Inherits="StakeholderManagement.zx" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .thumbnail {
            position: relative;
            overflow: hidden;
        }

        .caption {
            position: absolute;
            top: 0;
            right: 0;
            background: rgba(90, 90, 90, 0.75);
            width: 100%;
            height: 100%;
            padding: 2%;
            display: none;
            text-align: left;
            color: #fff !important;
            z-index: 2;
        }
    </style>
    <script>

        $(document).ready(function () {
            $("[rel='tooltip']").tooltip();

            $('.thumbnail').hover(
                function () {
                    $(this).find('.caption').slideDown(250); //.fadeIn(250)
                },
                function () {
                    $(this).find('.caption').slideUp(250); //.fadeOut(205)
                }
            );
        });
    </script>

    <div class="main-page">
        <div class="page-title-box">
            <div class="row align-items-center ">
                <div class="col-md-8">
                    <div class="page-title-box">
                        <h4 class="page-title">Advertisement</h4>
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item">
                                <a href="javascript:void(0);"></a>
                            </li>
                            <li class="breadcrumb-item active">Accounts</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container2">
        <div class="row">


           

              <dx:ASPxImageSlider ID="ASPxImageSlider1" runat="server" ClientInstanceName="ImageSlider"
                EnableViewState="False" EnableTheming="False" DataSourceID="SqlAdvertisements" ImageContentBytesField="AdImage">


                <SettingsNavigationBar ThumbnailsModeNavigationButtonVisibility="None" />

                <SettingsAutoGeneratedImages ImageCacheFolder="~/Thumb/" />
            </dx:ASPxImageSlider>

            <!-- TH6 -->


        </div>
        <!--/row -->
          <!--/row -->
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommand="SELECT  [Id], [PromoImage] FROM [Promotions] where Id=2"></asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlAdvertisements" runat="server" ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommand="sreGetAdvertisements" SelectCommandType="StoredProcedure">


            <SelectParameters>
                <asp:SessionParameter Name="StakeHolderTypeId" SessionField="StakeholderId" Type="Int32" />
                 <asp:SessionParameter Name="UserCategoryId" SessionField="UserCategoryId" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    <!-- end container -->
    <!-- end page-title -->
</asp:Content>