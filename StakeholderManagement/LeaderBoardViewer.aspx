<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeaderBoardViewer.aspx.cs" Inherits="StakeholderManagement.LeaderBoardViewer" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Page Banner Section Start -->
    <div class="page-banner-section section" style="background-image: url(assets2/images/TitleBg.jpg)">
        <div class="container">
            <div class="row">
                <div class="page-banner-content col">
                    <h1>LeaderBoard Chart</h1>
                    <ul class="page-breadcrumb">
                        <li><a href="index.html">LeaderBoard Chart</a></li>
                        <li><a href="my-account.html">LeaderBoard Chart</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Banner Section End LeaderBoardViewer -->


    <div class="page-section section section-padding">
        <div class="container  overflow-x-auto">
            <dx:BootstrapGridView runat="server" ID="gdQuatations" KeyFieldName="Id" 
                DataSourceID="SqlLeaderBoardViwer"
                CssClasses-HeaderRow="grid-headers-custom">

                <SettingsEditing Mode="Inline"></SettingsEditing>
                <SettingsDataSecurity AllowEdit="true" AllowDelete="false" AllowInsert="true" />

                <SettingsBootstrap Striped="true" />
                <Columns>



                    <dx:BootstrapGridViewCommandColumn ShowEditButton="false" ShowDeleteButton="false" ShowNewButtonInHeader="false" ButtonRenderMode="Button" Width="60px" />

                    <dx:BootstrapGridViewTextColumn FieldName="Id" VisibleIndex="1" Visible="False">
                    </dx:BootstrapGridViewTextColumn>


                    <dx:BootstrapGridViewTextColumn FieldName="Name" Visible="true" VisibleIndex="2" Width="200px" Caption="User Name">
                        <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>


                    <dx:BootstrapGridViewTextColumn FieldName="Subject" Visible="true" VisibleIndex="2" Width="100px" Caption="Fitness Exercise">
                        <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true">
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>

                    <dx:BootstrapGridViewTextColumn FieldName="Description" Visible="true" VisibleIndex="4" Width="300px" Caption="Description">
                        <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true">
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>



                    <dx:BootstrapGridViewTextColumn FieldName="CountTime" Visible="true" VisibleIndex="4" Width="300px" Caption="Marks">
                        <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true">
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>




<%--                    <dx:BootstrapGridViewBinaryImageColumn PropertiesBinaryImage-ImageHeight="50" PropertiesBinaryImage-ImageWidth="50" FieldName="PromoImage" VisibleIndex="9">
                        <PropertiesBinaryImage>
                        </PropertiesBinaryImage>
                        <DataItemTemplate>
                            <dx:ASPxImageZoom runat="server" ID="zoom" LargeImageLoadMode="OnPageLoad" ShowHintText="false"
                                ImageContentBytes='<%# Eval("PromoImage") %>' LargeImageContentBytes='<%# Eval("PromoImage") %>' EnableZoomMode="False">
                                <SettingsAutoGeneratedImages ImageCacheFolder="~/Thumb/" ImageHeight="60px" LargeImageWidth="1200px"></SettingsAutoGeneratedImages>
                                <SettingsZoomMode ZoomWindowWidth="350" ZoomWindowHeight="350" ZoomWindowPosition="Bottom" />


                            </dx:ASPxImageZoom>
                        </DataItemTemplate>
                    </dx:BootstrapGridViewBinaryImageColumn>--%>



                </Columns>
                <SettingsPager Mode="ShowAllRecords" />
            </dx:BootstrapGridView>
        </div>
    </div>

    <asp:SqlDataSource ID="SqlLeaderBoardViwer" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="SELECT h.Id,[Subject], [Description],CountTime, L.[UserId],(FName+LName) As Name FROM [LeaderBoards] L  INNER JOIN healthuser h on h.id=L.UserId  where MONTH(getdate())=Month(L.createdDateTime)order by COuntTime desc"></asp:SqlDataSource>



</asp:Content>
