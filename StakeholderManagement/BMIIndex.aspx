﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BMIIndex.aspx.cs"
    Inherits="StakeholderManagement.BMIIndex" %>



<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>


<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<%@ Register Assembly="DevExpress.XtraReports.v20.2.Web.WebForms, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Page Banner Section Start -->
    <div class="page-banner-section section" style="background-image: url(assets2/images/TitleBg.jpg)">
        <div class="container">
            <div class="row">
                <div class="page-banner-content col">
                    <h1>Userwise Details</h1>
                    <ul class="page-breadcrumb">
                        <li><a>Masters</a></li>
                        <li><a>Promotions</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Banner Section End -->

    <div class="page-section section section-padding">
        <div class="container">

            <div class="container-fluid">
                <div class="row mt-2">
                </div>


                <div class="row">


                    <div class="col-md-6">
                        <asp:Label runat="server" Text="User Name"></asp:Label>

                        <dx:BootstrapComboBox ID="ddlFitnessType" DataSourceID="SqlSreUserWise"
                            TextField="FullName" ValueField="Id" NullText="Select User"
                            runat="server">
                        </dx:BootstrapComboBox>
                    </div>



                    <div class="col-md-6">
                        <asp:Label runat="server" Text=""></asp:Label>

                        <%--  DataSourceID="SqlGetUsers"  TextField="FName"  ValueField="Id"--%>
                    </div>

                </div>





                <div class="row">
                    <div class="col-md-6">

                        <dx:BootstrapButton ID="btnGenerate" Text="Generate" OnClick="btnGenerate_Click" CssClasses-Control="btn-style" runat="server">
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

                <div class="row mt-4">
                    <div class="col-md-12">
                        <dx:ReportToolbar ID="ReportToolbar1" runat="server" ShowDefaultButtons="True" Width="100%"
                            ReportViewerID="rptUsers" Theme="MetropolisBlue">
                            <Items>
                                <dx:ReportToolbarButton ItemKind="Search" />
                                <dx:ReportToolbarSeparator />
                                <dx:ReportToolbarButton ItemKind="PrintReport" />

                                <dx:ReportToolbarSeparator />
                                <dx:ReportToolbarButton Enabled="False" ItemKind="FirstPage" />
                                <dx:ReportToolbarButton Enabled="False" ItemKind="PreviousPage" />
                                <dx:ReportToolbarLabel ItemKind="PageLabel" />
                                <dx:ReportToolbarComboBox ItemKind="PageNumber" Width="65px">
                                </dx:ReportToolbarComboBox>
                                <dx:ReportToolbarLabel ItemKind="OfLabel" />
                                <dx:ReportToolbarTextBox IsReadOnly="True" ItemKind="PageCount" />
                                <dx:ReportToolbarButton ItemKind="NextPage" />
                                <dx:ReportToolbarButton ItemKind="LastPage" />
                                <dx:ReportToolbarSeparator />
                                <dx:ReportToolbarButton ItemKind="SaveToDisk" />
                                <dx:ReportToolbarButton ItemKind="SaveToWindow" />
                                <dx:ReportToolbarComboBox ItemKind="SaveFormat" Width="70px">
                                    <Elements>
                                        <dx:ListElement Value="pdf" />
                                        <dx:ListElement Value="xls" />
                                        <dx:ListElement Value="xlsx" />
                                        <dx:ListElement Value="rtf" />
                                        <dx:ListElement Value="mht" />
                                        <dx:ListElement Value="html" />
                                        <dx:ListElement Value="txt" />
                                        <dx:ListElement Value="csv" />
                                        <dx:ListElement Value="png" />
                                    </Elements>
                                </dx:ReportToolbarComboBox>
                            </Items>
                            <Styles>
                                <LabelStyle>
                                    <Margins MarginLeft="3px" MarginRight="3px" />
                                </LabelStyle>
                            </Styles>
                        </dx:ReportToolbar>
                    </div>
                    <div class="col-md-12">
                        <dx:ReportViewer ID="rptUsers" runat="server" AutoSize="true" Height="500px" Width="700px">
                        </dx:ReportViewer>
                    </div>
                </div>
            </div>

        </div>
    </div>


    <asp:SqlDataSource ID="SqlSreUserWise" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="sreHealthUserWiseId" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="Id" SessionField="HealthId" Type="Int32" />
       <%--     <asp:SessionParameter Name="UserCategoryId" SessionField="UserCategoryId" Type="Int32" />--%>

        </SelectParameters>
    </asp:SqlDataSource>



    <asp:AdRotator ID="AdRotator1" runat="server" />
    <%-- <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="1200px" HeaderText="ASM Incentive" CssFilePath="~/App_Themes/RedLine/{0}/styles.css" CssPostfix="RedLine">
        <PanelCollection>
            <dx:PanelContent ID="PanelContent1" runat="server" SupportsDisabledAttribute="True">
                
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxRoundPanel>--%>
</asp:Content>
