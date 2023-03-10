<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dining.aspx.cs" Inherits="StakeholderManagement.Dining" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Page Banner Section Start -->
    <div class="page-banner-section section" style="background-image: url(assets2/images/TitleBg.jpg)">
        <div class="container">
            <div class="row">
                <div class="page-banner-content col">
                    <h1>Add Advertisements</h1>
                    <ul class="page-breadcrumb">
                        <li><a href="index.html">Masters</a></li>
                        <li><a href="my-account.html">Add Advertisements</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Banner Section End -->

    <div class="page-section section section-padding">
        <div class="container overflow-x-auto">

            <dx:BootstrapGridView runat="server" ID="gdAdvertisement" KeyFieldName="Id" DataSourceID="SqlgetAdvertisement"
                OnCellEditorInitialize="gdAdvertisement_CellEditorInitialize" OnAfterPerformCallback="gdAdvertisement_AfterPerformCallback"
                OnRowInserting="gdAdvertisement_RowInserting" OnRowValidating="gdAdvertisement_RowValidating"
                OnRowUpdating="gdAdvertisement_RowUpdating" OnCommandButtonInitialize="gdAdvertisement_CommandButtonInitialize"
                AutoGenerateColumns="False"
                CssClasses-HeaderRow="grid-headers-custom">
                <SettingsEditing Mode="Inline"></SettingsEditing>
                <SettingsDataSecurity AllowEdit="true" AllowDelete="false" AllowInsert="true" />

                <SettingsBootstrap Striped="true" />
                <Columns>
                    <dx:BootstrapGridViewCommandColumn ShowEditButton="true" ShowDeleteButton="false" ShowNewButtonInHeader="true" ButtonRenderMode="Button" Width="100px" />

                    <dx:BootstrapGridViewTextColumn FieldName="Id" VisibleIndex="1" Visible="False">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn Visible="false">
                        <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required" />
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewCheckColumn FieldName="Active" VisibleIndex="5" Caption="Active">
                    </dx:BootstrapGridViewCheckColumn>


                    <dx:BootstrapGridViewTextColumn FieldName="Name" Visible="true" VisibleIndex="2" Width="200px" Caption="Advertisement Name">
                        <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>


                    <dx:BootstrapGridViewDateColumn FieldName="FromDate" Visible="true" VisibleIndex="3" Width="100px" Caption="From Date">
                        <PropertiesDateEdit ValidationSettings-RequiredField-IsRequired="true">
                        </PropertiesDateEdit>
                    </dx:BootstrapGridViewDateColumn>


                    <dx:BootstrapGridViewDateColumn FieldName="ToDate" Visible="true" VisibleIndex="4" Width="100px" Caption="To Date">
                        <PropertiesDateEdit ValidationSettings-RequiredField-IsRequired="true">
                        </PropertiesDateEdit>
                    </dx:BootstrapGridViewDateColumn>
                    <dx:BootstrapGridViewBinaryImageColumn PropertiesBinaryImage-ImageHeight="50" PropertiesBinaryImage-EnableServerResize="true"
                        PropertiesBinaryImage-ImageWidth="50" FieldName="AdImage" VisibleIndex="9" Caption="Advertisement" Name="Image">
                        <PropertiesBinaryImage BinaryStorageMode="Session">
                        </PropertiesBinaryImage>

                        <DataItemTemplate>
                            <dx:ASPxImageZoom runat="server" ID="zoom" LargeImageLoadMode="OnPageLoad" ShowHintText="false"
                                ImageContentBytes='<%# Eval("AdImage") %>' LargeImageContentBytes='<%# Eval("AdImage") %>' EnableZoomMode="False">
                                <SettingsAutoGeneratedImages ImageCacheFolder="~/Thumb/" ImageHeight="60px" LargeImageWidth="1200px" />
                                <SettingsZoomMode ZoomWindowWidth="350" ZoomWindowHeight="350" ZoomWindowPosition="Bottom" />
                            </dx:ASPxImageZoom>
                        </DataItemTemplate>

                    </dx:BootstrapGridViewBinaryImageColumn>


                    <dx:BootstrapGridViewComboBoxColumn FieldName="StakeHolderType" Width="300px" Name="CategoryId" VisibleIndex="5" Caption="Category">
                        <PropertiesComboBox DataSourceID="SqlStakeHolderTypes" TextField="Name" ValueField="Id">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesComboBox>
                    </dx:BootstrapGridViewComboBoxColumn>
                </Columns>
                <SettingsPager Mode="ShowAllRecords" />
            </dx:BootstrapGridView>
        </div>
    </div>

    <asp:SqlDataSource ID="SqlgetAdvertisement" runat="server" SelectCommand="sreGetAdvertisement"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommandType="StoredProcedure">

        <SelectParameters>
            <asp:SessionParameter Name="StakeHolderTypeId" SessionField="StakeholderId" Type="Int32" />
            <asp:SessionParameter Name="UserCategoryId" SessionField="UserCategoryId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlStakeHolderTypes" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommand="sregetStakeHolderTypes"
        SelectCommandType="StoredProcedure"></asp:SqlDataSource>

</asp:Content>
