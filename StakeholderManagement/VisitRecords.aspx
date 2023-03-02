<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VisitRecords.aspx.cs" Inherits="StakeholderManagement.VisitRecords" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Page Banner Section Start -->
    <div class="page-banner-section section" style="background-image: url(assets2/images/TitleBg.jpg)">
        <div class="container">
            <div class="row">
                <div class="page-banner-content col">
                    <h1>View Records</h1>
                    <ul class="page-breadcrumb">
                        <li><a href="index.html">Masters</a></li>
                        <li><a href="my-account.html">View Records</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Banner Section End -->


    <div class="page-section section section-padding">
        <div class="container">


            <div class="row">
                <div class="col-md-6">
                    <asp:Label runat="server" Text="ASO Name"></asp:Label>

                    <%--  DataSourceID="SqlGetUsers"  TextField="FName"  ValueField="Id"--%>

                    <dx:BootstrapComboBox OnInit="cmbStakeHolderId_Init"
                        ID="cmbASO"
                        OnSelectedIndexChanged="cmbASO_SelectedIndexChanged" runat="server">

                        <ValidationSettings ValidationGroup="SignUpValidation">
                            <RequiredField ErrorText="Please Select an ASO" IsRequired="True" />

                        </ValidationSettings>
                        <%--   <Items>
                            <dx:BootstrapListEditItem Text="Select All" Value="0" />
                        </Items>--%>
                    </dx:BootstrapComboBox>
                </div>




            </div>



            <div class="row">


                <div class="col-md-6">
                    <asp:Label runat="server" Text="Stakeholder Type"></asp:Label>

                    <dx:BootstrapComboBox ID="cmbStakeHolderType" DataSourceID="odsStakeholderTypes"
                        OnSelectedIndexChanged="cmbStakeHolderType_SelectedIndexChanged"  AutoPostBack="true"
                        TextField="Name" ValueField="Id" NullText="Select Stakeholder"
                        runat="server">

                     <%--   <ValidationSettings ValidationGroup="SignUpValidation">
                            <RequiredField ErrorText="Please Select a Stakeholder Type" IsRequired="True" />

                        </ValidationSettings>--%>
                    </dx:BootstrapComboBox>
                </div>



                <div class="col-md-6">
                    <asp:Label runat="server" Text="Stakeholder Name"></asp:Label>

                    <%--  DataSourceID="SqlGetUsers"  TextField="FName"  ValueField="Id"--%>

                    <dx:BootstrapComboBox OnInit="cmbStakeHolderId_Init"
                        ID="cmbStakeHolderId"
                        OnSelectedIndexChanged="cmbStakeHolderId_SelectedIndexChanged" runat="server">

                        <ValidationSettings ValidationGroup="SignUpValidation">
                            <RequiredField ErrorText="Please Select a StakeHolder" IsRequired="True" />

                        </ValidationSettings>
                        <%--   <Items>
                            <dx:BootstrapListEditItem Text="Select All" Value="0" />
                        </Items>--%>
                    </dx:BootstrapComboBox>
                </div>

            </div>
            <div class="row">
                <div class="col-md-6">
                    <asp:Label runat="server" Text="From Date"></asp:Label>
                    <dx:BootstrapDateEdit ID="dtFromDate" OnDateChanged="dtpFromDate_DateChanged" runat="server">

                        <ValidationSettings ValidationGroup="SignUpValidation">
                            <RequiredField ErrorText="From Date is Required" IsRequired="True" />

                        </ValidationSettings>
                    </dx:BootstrapDateEdit>
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" Text="To Date"></asp:Label>


                    <dx:BootstrapDateEdit ID="dtToDate" AutoPostBack="true" OnDateChanged="dtpToDate_DateChanged" runat="server">
                        <ValidationSettings ValidationGroup="SignUpValidation">
                            <RequiredField ErrorText="To Date is Required" IsRequired="True" />

                        </ValidationSettings>

                    </dx:BootstrapDateEdit>
                </div>
            </div>
            <br />


            <div class="row">
                <div class="col-md-6">

                    <dx:BootstrapButton ID="btnVisits" Text="Generate" OnClick="btnVisits_Click" CssClasses-Control="btn-style" runat="server">
                        <ClientSideEvents Click="function(s, e) { 
                                                    if(ASPxClientEdit.ValidateGroup('SignUpValidation'))
                                                    {
                                                        e.processOnServer=true;
                                                        fbq('track', 'CompleteRegistration');
                                                    }
                                                    else
                                                    {
                                                    e.processOnServer=false;
                                                    } 
                                                }" />

                    </dx:BootstrapButton>
                </div>
                <div class="col-md-6">
                </div>
            </div>
            <br />
            <br />

            <div class="row">
                <div class="col-md-12 overflow-x-auto">
                    <dx:BootstrapGridView runat="server" ID="gdVisitRecords"
                        KeyFieldName="VisitDetailNo"
                        OnCellEditorInitialize="gdVisitRecords_CellEditorInitialize"
                        OnRowValidating="gdVisitRecords_RowValidating"
                        OnRowInserting="gdVisitRecords_RowInserting"
                        OnRowUpdating="gdVisitRecords_RowUpdating"
                        OnCommandButtonInitialize="gdVisitRecords_CommandButtonInitialize"
                        AutoGenerateColumns="False"
                        CssClasses-HeaderRow="grid-headers-custom">
                        <SettingsEditing Mode="Inline"></SettingsEditing>
                        <SettingsDataSecurity AllowEdit="true" AllowDelete="false" AllowInsert="true" />

                        <SettingsBootstrap Striped="true" />
                        <Columns>
                            <%--<dx:BootstrapGridViewCommandColumn ShowEditButton="true" ShowDeleteButton="false" ShowNewButtonInHeader="true" ButtonRenderMode="Button" Width="100px" />--%>

                            <dx:BootstrapGridViewTextColumn FieldName="VisitDetailNo" VisibleIndex="1" Visible="False">
                            </dx:BootstrapGridViewTextColumn>

                            <dx:BootstrapGridViewTextColumn Visible="false">
                                <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required" />
                            </dx:BootstrapGridViewTextColumn>


                            <%--<dx:BootstrapGridViewCheckColumn FieldName="Active" VisibleIndex="5" Caption="Active">
                        </dx:BootstrapGridViewCheckColumn>--%>


                            <dx:BootstrapGridViewTextColumn FieldName="Name" Visible="true" VisibleIndex="2" Width="300px" Caption="Name">
                            </dx:BootstrapGridViewTextColumn>

                            <dx:BootstrapGridViewDateColumn FieldName="VisitDate" Visible="true" VisibleIndex="2" Width="100px" Caption="Visited Date">
                                <PropertiesDateEdit ValidationSettings-RequiredField-IsRequired="true">
                                </PropertiesDateEdit>
                            </dx:BootstrapGridViewDateColumn>


                            <dx:BootstrapGridViewTextColumn FieldName="Remark" Visible="true" VisibleIndex="2" Width="100px" Caption="Remark">
                            </dx:BootstrapGridViewTextColumn>

                            <dx:BootstrapGridViewTextColumn FieldName="Customer" Visible="true" VisibleIndex="2" Width="100px" Caption="Customer Name">
                            </dx:BootstrapGridViewTextColumn>



                        </Columns>
                        <SettingsPager Mode="ShowAllRecords" />
                    </dx:BootstrapGridView>
                </div>
            </div>


        </div>
    </div>
    <asp:SqlDataSource ID="odsStakeholderTypes" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="sreGetstakeholdertypesAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>


    <asp:SqlDataSource ID="SqlVisitRecords" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="sgetViewVisits" SelectCommandType="StoredProcedure">

        <SelectParameters>
            <asp:ControlParameter ControlID="dtFromDate" PropertyName="Date" Name="fromdate"
                Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="dtToDate" PropertyName="Date" Name="todate"
                Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="cmbStakeHolderId" PropertyName="Value" Name="StakeholderId"
                Type="Int32"></asp:ControlParameter>

        </SelectParameters>

    </asp:SqlDataSource>


    <%--    <asp:SqlDataSource ID="SqlGetUsers" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="sreGetUsers" SelectCommandType="StoredProcedure">


        <SelectParameters>
            <asp:SessionParameter Name="Usercategory" SessionField="UserCategoryId" Type="Int32" />
            <asp:SessionParameter Name="ASO" SessionField="ASOAcc" Type="Int32" />

        </SelectParameters>

    </asp:SqlDataSource>--%>
</asp:Content>
