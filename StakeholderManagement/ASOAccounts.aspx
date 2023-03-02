<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ASOAccounts.aspx.cs" Inherits="StakeholderManagement.ASOAccounts" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <!-- Page Banner Section Start -->
        <div class="page-banner-section section" style="background-image: url(assets2/images/TitleBg.jpg)">
            <div class="container">
                <div class="row">
                    <div class="page-banner-content col">
                        <h1>ASO Accounts</h1>
                        <ul class="page-breadcrumb">
                            <li><a href="index.html">Masters</a></li>
                            <li><a href="my-account.html">ASO Accounts</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <!-- Page Banner Section End -->

        <div class="page-section section section-padding">
            <div class="container overflow-x-auto">

                <dx:BootstrapGridView runat="server" DataSourceID="SqlGetASOUsers" ID="gdASOAccounts" KeyFieldName="Id"
                    OnRowInserting="gdASOAccounts_RowInserting"
                    OnRowValidating="gdASOAccounts_RowValidating"
                    OnRowUpdating="gdASOAccounts_RowUpdating" OnCellEditorInitialize="gdASOAccounts_CellEditorInitialize"
                    OnCommandButtonInitialize="gdASOAccounts_CommandButtonInitialize"
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

                        <dx:BootstrapGridViewTextColumn FieldName="Name" Visible="true" VisibleIndex="2" Width="400px" Caption="Name">
                            <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                            </PropertiesTextEdit>
                        </dx:BootstrapGridViewTextColumn>

                        <dx:BootstrapGridViewTextColumn FieldName="Email" Visible="true" VisibleIndex="2" Width="300px" Caption="Email">
                            <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                            </PropertiesTextEdit>
                        </dx:BootstrapGridViewTextColumn>

                        <dx:BootstrapGridViewTextColumn FieldName="Address" Visible="true" VisibleIndex="2" Width="400px" Caption="Address">
                            <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                            </PropertiesTextEdit>
                        </dx:BootstrapGridViewTextColumn>

                        <dx:BootstrapGridViewTextColumn FieldName="ContactNo" Visible="true" VisibleIndex="2" Width="400px" Caption="Mobile No">
                            <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                            </PropertiesTextEdit>
                        </dx:BootstrapGridViewTextColumn>

                        <dx:BootstrapGridViewTextColumn FieldName="UserId" Visible="true" VisibleIndex="2" Width="400px" Caption="User ID">
                            <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                            </PropertiesTextEdit>
                        </dx:BootstrapGridViewTextColumn>

                        <dx:BootstrapGridViewCheckColumn FieldName="Active" VisibleIndex="5" Caption="Active">
                        </dx:BootstrapGridViewCheckColumn>
                    </Columns>
                    <SettingsPager Mode="ShowAllRecords" />
                </dx:BootstrapGridView>
            </div>
        </div>

        <asp:SqlDataSource ID="SqlGetASOUsers" runat="server" SelectCommand="sreGetASOUsers"
            ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommandType="StoredProcedure"
            InsertCommand="SinASoUsers" InsertCommandType="StoredProcedure" UpdateCommand="SupASoUsers" UpdateCommandType="StoredProcedure">
            <SelectParameters>
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="UserId" Type="String" />
                <asp:Parameter Name="Active" Type="Boolean" />
                <asp:Parameter Name="Name" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="ContactNo" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="UserLoginId" Type="String" />
            </InsertParameters>

            <UpdateParameters>
                <asp:Parameter Name="Id" Type="Int32" />
                <asp:Parameter Name="Active" Type="Boolean" />
                <asp:Parameter Name="ContactNo" Type="String" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="UserLoginId" Type="String" />

            </UpdateParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlGetASOUsersx" runat="server"
            ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommand="sreGetASOUsers"
            SelectCommandType="StoredProcedure"></asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlStakeHolderTypes" runat="server"
            ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" 
            SelectCommand="sregetStakeHolderTypes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
