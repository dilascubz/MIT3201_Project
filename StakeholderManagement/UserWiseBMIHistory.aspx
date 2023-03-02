<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserWiseBMIHistory.aspx.cs" Inherits="StakeholderManagement.UserWiseBMIHistory" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Page Banner Section Start -->
    <div class="page-banner-section section" style="background-image: url(assets2/images/TitleBg.jpg)">
        <div class="container">
            <div class="row">
                <div class="page-banner-content col">
                    <h1>UserWise BMI History</h1>
                    <ul class="page-breadcrumb">
                        <li><a href="index.html">Masters</a></li>
                        <li><a href="my-account.html">UserWise BMI History</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Banner Section End -->

    <div class="page-section section section-padding">
        <div class="container  overflow-x-auto">
            <dx:BootstrapGridView runat="server" ID="gdBMIHistory" KeyFieldName="Id"
                DataSourceID="SqlBMIWiseHistory"
                AutoGenerateColumns="False"
                CssClasses-HeaderRow="grid-headers-custom">

                <SettingsEditing Mode="Inline"></SettingsEditing>
                <SettingsDataSecurity AllowEdit="true" AllowDelete="false" AllowInsert="true" />

                <SettingsBootstrap Striped="true" />
                <Columns>




                    <dx:BootstrapGridViewTextColumn FieldName="Id" VisibleIndex="1" Visible="False">
                    </dx:BootstrapGridViewTextColumn>


                    

                    <dx:BootstrapGridViewTextColumn FieldName="CreatedBy" Visible="true" VisibleIndex="1" Width="100px" Caption="User">
                        <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true">
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>

                    <dx:BootstrapGridViewTextColumn FieldName="Weight" Visible="true" VisibleIndex="2" Width="300px" Caption="Weight">
                        <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>


                    <dx:BootstrapGridViewTextColumn FieldName="Height" Visible="true" VisibleIndex="2" Width="300px" Caption="Height">
                    </dx:BootstrapGridViewTextColumn>



                    <dx:BootstrapGridViewTextColumn FieldName="BMIIndex" Visible="true" VisibleIndex="4" Width="100px" Caption="BMI Index">
                        <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true">
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>

                    <dx:BootstrapGridViewDateColumn FieldName="CreatedDateTime" Visible="true" VisibleIndex="2" Width="100px" Caption="Created Date">
                        <PropertiesDateEdit ValidationSettings-RequiredField-IsRequired="true">
                        </PropertiesDateEdit>
                    </dx:BootstrapGridViewDateColumn>
                </Columns>
                <SettingsPager Mode="ShowAllRecords" />
            </dx:BootstrapGridView>
        </div>
    </div>




    <asp:SqlDataSource ID="SqlBMIWiseHistory" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="sreGetUserWiseBMIHistory"
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="UserId" SessionField="UserId" Type="String" />
        </SelectParameters>

    </asp:SqlDataSource>




</asp:Content>
