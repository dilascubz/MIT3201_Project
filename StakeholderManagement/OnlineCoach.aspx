<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OnlineCoach.aspx.cs" Inherits="StakeholderManagement.OnlineCoach" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Page Banner Section Start -->
    <div class="page-banner-section section" style="background-image: url(assets2/images/TitleBg.jpg)">
        <div class="container">
            <div class="row">
                <div class="page-banner-content col">
                    <h1>Online Coaches</h1>
                    <ul class="page-breadcrumb">
                        <li><a href="index.html">Requests</a></li>
                        <li><a href="my-account.html">Online Coaches</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Banner Section End -->

    <div class="page-section section section-padding">
        <div class="container overflow-x-auto">


            <div class="col-lg-12 col-md-6 col-12 mb-20">
                <dx:BootstrapCardView ID="grdOnlineCoaches"
                    DataSourceID="odsCoaches"
                    EnableCardsCache="false" runat="server">
                    <CssClasses Card="animated-card" />

                    <SettingsPager ItemsPerPage="6"></SettingsPager>
                    <SettingsLayout CardColSpanLg="4" CardColSpanMd="6" CardColSpanSm="12" />
                    <Columns>
                        <dx:BootstrapCardViewBinaryImageColumn FieldName="Photo">
                            <PropertiesBinaryImage ImageWidth="70px" ImageHeight="70px" />
                        </dx:BootstrapCardViewBinaryImageColumn>
                        <dx:BootstrapCardViewColumn FieldName="FirstName" />
                        <dx:BootstrapCardViewColumn FieldName="LastName" />
                        <dx:BootstrapCardViewColumn FieldName="FullName" UnboundType="String" UnboundExpression="[FirstName] + '&nbsp;' + [LastName]" />
                        <dx:BootstrapCardViewColumn FieldName="TelNo" />
                        <dx:BootstrapCardViewColumn FieldName="Email" />
                        <dx:BootstrapCardViewColumn FieldName="MobileNo" />
                        <dx:BootstrapCardViewColumn FieldName="Address" />
                    </Columns>
                    <Templates>
                        <Card>

                            <dx:BootstrapBinaryImage Width="100%" ID="Photo" runat="server" Value='<%# Eval("PhotoImage") %>' />
                            <div class="info">
                                <p><%# Eval("FullName") %></p>
                                <span><%# Eval("Email") %></span>
                                <div class="address">
                                    <span><%# Eval("Email") %></span>
                                    <br />
                                    <span><%# Eval("Address") %></span>
                                </div>
                            </div>






                        </Card>
                    </Templates>
                    <SettingsPager ItemsPerPage="6"></SettingsPager>
                    <SettingsLayout CardColSpanLg="4" CardColSpanMd="6" CardColSpanSm="12" />

                </dx:BootstrapCardView>



                <dx:BootstrapGridView runat="server" DataSourceID="odsCoaches"
                    KeyFieldName="Id" PreviewFieldName="FirstName">
                    <Settings ShowPreview="true" />
                    <Templates>
                        <PreviewRow>
                            <div class="media">
                                <div class="media-left">
                                    <dx:BootstrapBinaryImage ID="BinaryImage" runat="server" Value='<%# Eval("PhotoImage") %>' />
                                </div>
                                <div class="media-body">
                                    <asp:Literal runat="server" Text="<%# Container.Text %>"></asp:Literal>
                                </div>
                            </div>
                        </PreviewRow>
                    </Templates>
                    <Columns>
                    </Columns>
                    <SettingsPager PageSize="3"></SettingsPager>
                </dx:BootstrapGridView>






            </div>
        </div>

    </div>

    <asp:SqlDataSource ID="odsCoaches" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="sreGetOnlineCoaches" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="UserCategoryId" SessionField="UserCategoryId" Type="Int32" />
        </SelectParameters>

    </asp:SqlDataSource>

</asp:Content>
