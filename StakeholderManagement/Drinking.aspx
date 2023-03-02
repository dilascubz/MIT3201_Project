<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Drinking.aspx.cs" Inherits="StakeholderManagement.Drinking" %>

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

            <dx:BootstrapGridView runat="server" ID="gdWaterIntake" KeyFieldName="Id" DataSourceID="SqlgetWaterIntake"
              
             
                OnRowValidating="gdWaterIntake_RowValidating"
                 OnCommandButtonInitialize="gdWaterIntake_CommandButtonInitialize"
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
                    
                    <dx:BootstrapGridViewTextColumn FieldName="Liters" VisibleIndex="1" Visible="true">
                    </dx:BootstrapGridViewTextColumn>




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



    <asp:SqlDataSource ID="SqlgetWaterIntake" runat="server" SelectCommand="sreGetWaterIntake"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommandType="StoredProcedure"
        InsertCommand="SinWaterIntake" InsertCommandType="StoredProcedure" 
        UpdateCommand="SupDrinking" UpdateCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="StakeHolderTypeId" SessionField="StakeholderId" Type="Int32" />
            <asp:SessionParameter Name="UserCategoryId" SessionField="UserCategoryId" Type="Int32" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="Active" Type="Boolean" />
            <asp:Parameter Name="Liters" />
            
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

</asp:Content>
