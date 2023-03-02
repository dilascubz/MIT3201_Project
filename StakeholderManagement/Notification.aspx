<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Notification.aspx.cs" Inherits="StakeholderManagement.Notification" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Page Banner Section Start -->
    <div class="page-banner-section section" style="background-image: url(assets2/images/TitleBg.jpg)">
        <div class="container">
            <div class="row">
                <div class="page-banner-content col">
                    <h1>Notification</h1>
                    <ul class="page-breadcrumb">
                        <li><a href="index.html">Transactions</a></li>
                        <li><a href="my-account.html">Notification</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Banner Section End -->

    <div class="page-section section section-padding">
        <div class="container overflow-x-auto">

            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server" Text="StakeHolder Type"></asp:Label>
                    <dx:BootstrapComboBox ID="cmbStakeholder" DataSourceID="SqlStakeHolderTypes" TextField="Name" ValueField="Id" NullText="Select Stakeholder" SelectedIndex="-1" runat="server">
                        <ValidationSettings ValidationGroup="Validations">
                            <RequiredField ErrorText="StakeHolder Type is Required" IsRequired="True" />
                            <%--                                                    <RegularExpression ErrorText="Address Line 2 Invalid" ValidationExpression="^[a-zA-Z0-9. ():,'&quot;/-]*$" />--%>
                        </ValidationSettings>
                    </dx:BootstrapComboBox>
                </div>
            </div>
            <div class="row">
                <%-- <div class="col-md-4 row-space text-right">
                <dx:BootstrapButton runat="server" ID="btnSave"  Text="Confirm" CssClasses-Control="btn-style" CssClasses-Icon="fas fa-save noti-icon">
                </dx:BootstrapButton>
            </div>--%>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server" Text="Notification Type"></asp:Label>
                    <dx:BootstrapComboBox ID="cmbNotificationType" AutoPostBack="true" OnSelectedIndexChanged="cmbNotificationType_SelectedIndexChanged"
                        NullText="Select Notification Type" SelectedIndex="-1" runat="server">
                        <Items>
                            <dx:BootstrapListEditItem Text="Email" Value="1" />
                            <dx:BootstrapListEditItem Text="SMS" Value="2" />
                        </Items>

                        <ValidationSettings ValidationGroup="Validations">
                            <RequiredField ErrorText="Notification Type is Required" IsRequired="True" />
                            <%--                                                    <RegularExpression ErrorText="Address Line 2 Invalid" ValidationExpression="^[a-zA-Z0-9. ():,'&quot;/-]*$" />--%>
                        </ValidationSettings>
                    </dx:BootstrapComboBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 row-space text-right">
                </div>
            </div>
            <div class="row">
                <%-- <div class="col-md-4 row-space text-right">
                <dx:BootstrapButton runat="server" ID="btnSave"  Text="Confirm" CssClasses-Control="btn-style" CssClasses-Icon="fas fa-save noti-icon">
                </dx:BootstrapButton>
            </div>--%>
            </div>
            <asp:Panel runat="server" ID="Email" Visible="false">
                <div class="row">
                    <div class="col-md-4">
                        <asp:Label runat="server" Text="Email Subject"></asp:Label>
                        <dx:BootstrapTextBox ID="txtSubject" MaxLength="50" runat="server">
                            <ValidationSettings ValidationGroup="Validations">
                                <%--                                                    <RegularExpression ErrorText="Address Line 2 Invalid" ValidationExpression="^[a-zA-Z0-9. ():,'&quot;/-]*$" />--%>
                            </ValidationSettings>
                        </dx:BootstrapTextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-4">
                        <asp:Label runat="server" Text="Email "></asp:Label>
                        <dx:BootstrapMemo ID="txtMemo" MaxLength="70" runat="server">
                            <ValidationSettings ValidationGroup="Validations">
                                <RequiredField ErrorText="A Message is Required" IsRequired="True" />
                                <%--                                                    <RegularExpression ErrorText="Address Line 2 Invalid" ValidationExpression="^[a-zA-Z0-9. ():,'&quot;/-]*$" />--%>
                            </ValidationSettings>
                        </dx:BootstrapMemo>
                    </div>
                </div>
            </asp:Panel>

            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server" ID="lblMessage" Text="Message"></asp:Label>
                    <dx:BootstrapMemo ID="txtSMS" MaxLength="70" runat="server">
                        <ValidationSettings ValidationGroup="Validations">
                            <RequiredField ErrorText="A Message is Required" IsRequired="True" />
                            <%--                                                    <RegularExpression ErrorText="Address Line 2 Invalid" ValidationExpression="^[a-zA-Z0-9. ():,'&quot;/-]*$" />--%>
                        </ValidationSettings>
                    </dx:BootstrapMemo>
                </div>

            </div>
            <div class="row">
                <div class="col-md-4 row-space text-right">
                    <dx:BootstrapButton runat="server" ID="btnSave" OnClick="btnSave_Click" Text="Notify"
                        CssClasses-Control="btn-style" CssClasses-Icon="fas fa-save noti-icon">


                        <ClientSideEvents Click="function(s, e) { 
                                                    if(ASPxClientEdit.ValidateGroup('Validations'))
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
            </div>
        </div>
        <!-- end page-title -->
    </div>
    <asp:SqlDataSource ID="SqlStakeHolderTypes" runat="server" ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommand="sreGetstakeholdertypes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <%--     SelectCommand="sreNotify"    SelectCommandType="StoredProcedure"--%>

    <asp:SqlDataSource ID="NotificationSave" runat="server" ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        UpdateCommand="sreNotify" UpdateCommandType="StoredProcedure">
        <UpdateParameters>

            <asp:ControlParameter ControlID="cmbStakeholder" Name="StakeHolderType" PropertyName="Value" Type="Int32" />
            <asp:ControlParameter ControlID="cmbNotificationType" Name="Type" PropertyName="Value" Type="Int32" />
            <asp:ControlParameter ControlID="txtSubject" Name="Subject" PropertyName="Text" Type="String" />

            <asp:ControlParameter ControlID="txtMemo" Name="Email" PropertyName="Text" Type="String" />

            <asp:ControlParameter ControlID="txtSMS" Name="SMS" PropertyName="Text" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
