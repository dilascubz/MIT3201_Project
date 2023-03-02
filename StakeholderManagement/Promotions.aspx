<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Promotions.aspx.cs" Inherits="StakeholderManagement.Promotions" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Page Banner Section Start -->
    <div class="page-banner-section section" style="background-image: url(assets2/images/TitleBg.jpg)">
        <div class="container">
            <div class="row">
                <div class="page-banner-content col">
                    <h1>Promotions</h1>
                    <ul class="page-breadcrumb">
                        <li><a href="index.html">Masters</a></li>
                        <li><a href="my-account.html">Promotions</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Banner Section End -->

    <div class="page-section section section-padding">
        <div class="container  overflow-x-auto">
            <dx:BootstrapGridView runat="server" ID="gdPromotions" KeyFieldName="Id" DataSourceID="SqlGetPromotions"
                OnCellEditorInitialize="gdPromotions_CellEditorInitialize" OnRowValidating="gdPromotions_RowValidating"
                OnRowInserting="gdPromotions_RowInserting" OnRowUpdating="gdPromotions_RowUpdating" OnCommandButtonInitialize="gdPromotions_CommandButtonInitialize" AutoGenerateColumns="False"
                OnCustomButtonCallback="gdPromotions_CustomButtonCallback"
                CssClasses-HeaderRow="grid-headers-custom">

                <SettingsEditing Mode="Inline"></SettingsEditing>
                <SettingsDataSecurity AllowEdit="true" AllowDelete="false" AllowInsert="true" />

                <SettingsBootstrap Striped="true" />
                <Columns>

                    <dx:BootstrapGridViewCommandColumn ButtonRenderMode="Button" Caption="" VisibleIndex="2">
                        <CustomButtons>
                            <dx:BootstrapGridViewCommandColumnCustomButton Visibility="AllDataRows" ID="Mod" Text="Send Email"></dx:BootstrapGridViewCommandColumnCustomButton>
                        </CustomButtons>

                    </dx:BootstrapGridViewCommandColumn>


                    <dx:BootstrapGridViewCommandColumn ShowEditButton="true" ShowDeleteButton="false" ShowNewButtonInHeader="true" ButtonRenderMode="Button" Width="100px" />

                    <dx:BootstrapGridViewTextColumn FieldName="Id" VisibleIndex="1" Visible="False">
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn Visible="false">
                        <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required" />
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewCheckColumn FieldName="Active" VisibleIndex="5" Caption="Active">
                    </dx:BootstrapGridViewCheckColumn>


                    <dx:BootstrapGridViewTextColumn FieldName="Name" Visible="true" VisibleIndex="2" Width="300px" Caption="Name">
                        <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn FieldName="Code" Visible="true" VisibleIndex="2" Width="100px" Caption="Code">
                        <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true">
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>

                    <dx:BootstrapGridViewTextColumn FieldName="Description" Visible="true" VisibleIndex="4" Width="100px" Caption="Description">
                        <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true">
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>

                    <dx:BootstrapGridViewDateColumn FieldName="FromDate" Visible="true" VisibleIndex="2" Width="100px" Caption="From Date">
                        <PropertiesDateEdit ValidationSettings-RequiredField-IsRequired="true">
                        </PropertiesDateEdit>
                    </dx:BootstrapGridViewDateColumn>

                    <dx:BootstrapGridViewDateColumn FieldName="ToDate" Visible="true" VisibleIndex="2" Width="100px" Caption="To Date">
                        <PropertiesDateEdit ValidationSettings-RequiredField-IsRequired="true">
                        </PropertiesDateEdit>
                    </dx:BootstrapGridViewDateColumn>


                    <dx:BootstrapGridViewBinaryImageColumn PropertiesBinaryImage-ImageHeight="50"
                        PropertiesBinaryImage-ImageWidth="50" FieldName="PromoImage" VisibleIndex="9">
                        <PropertiesBinaryImage>
                        </PropertiesBinaryImage>
                        <DataItemTemplate>
                            <dx:ASPxImageZoom runat="server" ID="zoom" LargeImageLoadMode="OnPageLoad" ShowHintText="false"
                                ImageContentBytes='<%# Eval("PromoImage") %>' LargeImageContentBytes='<%# Eval("PromoImage") %>' EnableZoomMode="False">
                                <SettingsAutoGeneratedImages ImageCacheFolder="~/Thumb/" ImageHeight="60px" LargeImageWidth="1200px"></SettingsAutoGeneratedImages>
                                <SettingsZoomMode ZoomWindowWidth="350" ZoomWindowHeight="350" ZoomWindowPosition="Bottom" />


                            </dx:ASPxImageZoom>
                        </DataItemTemplate>
                    </dx:BootstrapGridViewBinaryImageColumn>



                    <dx:BootstrapGridViewComboBoxColumn FieldName="StakeHolderType" Name="CategoryId" Width="100px" VisibleIndex="3" Caption="Category">
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

    <asp:SqlDataSource ID="SqlGetPromotions" runat="server" SelectCommand="sreGetPromotionSummary"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommandType="StoredProcedure"
        InsertCommand="SinPromotions" InsertCommandType="StoredProcedure" UpdateCommand="SupPromotions" UpdateCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="StakeHolderTypeId" SessionField="StakeholderId" Type="Int32" />
            <asp:SessionParameter Name="UserCategoryId" SessionField="UserCategoryId" Type="Int32" />
        </SelectParameters>
        <InsertParameters>

            <asp:Parameter Name="Active" Type="Boolean" />
            <asp:Parameter Name="Name" />
            <asp:Parameter Name="Code" />
            <asp:Parameter Name="Description" />
            <asp:Parameter Name="StakeHolderType" Type="Int32" />
            <asp:Parameter Name="UserLoginId" Type="String" />
            <asp:Parameter Name="FromDate" Type="String" />
            <asp:Parameter Name="ToDate" Type="String" />
            <asp:Parameter Name="PromoImage" DbType="Binary" />
        </InsertParameters>

        <UpdateParameters>
            <asp:Parameter Name="Id" Type="Int32" />
            <asp:Parameter Name="Active" Type="Boolean" />
            <asp:Parameter Name="PromoImage" DbType="Binary" />
            <asp:Parameter Name="Code" />
            <asp:Parameter Name="Description" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="StakeHolderType" Type="Int32" />
            <asp:Parameter Name="FromDate" Type="String" />
            <asp:Parameter Name="ToDate" Type="String" />
            <asp:Parameter Name="UserLoginId" Type="String" />
        </UpdateParameters>

    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlStakeHolderTypes" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommand="sreGetFitnesstypes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>


    <asp:SqlDataSource ID="SqlPromoId" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="sregetPromotionforId" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="PromotionId" SessionField="PromotionId" Type="Int32" />

        </SelectParameters>

    </asp:SqlDataSource>


     <asp:SqlDataSource ID="SqlStakeholderEmails" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="sregetStakeholderEMails" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="StakeEmails" SessionField="StakeEmails" Type="Int32" />

        </SelectParameters>

    </asp:SqlDataSource>
    

    <asp:SqlDataSource ID="SqlStakeholderwiseEmails" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommand="sregettakeholderwiseEmails" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="StakeHolderTypeId" SessionField="StakeholderId" Type="Int32" />
            <asp:SessionParameter Name="UserCategoryId" SessionField="UserCategoryId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dsUserEmail" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="SreGetAdminEmail"
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="UserId" SessionField="UserId" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
