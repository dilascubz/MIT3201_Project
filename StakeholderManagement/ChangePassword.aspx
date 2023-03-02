<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="StakeholderManagement.ChangePassword" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main-page">
        <div class="page-title-box">
            <div class="row align-items-center ">
                <div class="col-md-8">
                    <div class="page-title-box">
                        <h4 class="page-title">Change Password</h4>
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item">
                                <a href="javascript:void(0);">Stakeholder Management</a>
                            </li>
                            <li class="breadcrumb-item active">Change Password</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>
        <!-- end page-title -->

        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text="Old Password"></asp:Label>
                <dx:BootstrapTextBox runat="server" NullText="Enter Old Password">
                </dx:BootstrapTextBox>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text="New Password"></asp:Label>
                <dx:BootstrapTextBox ID="txtPassword" runat="server" NullText="Enter New Password">
                    <ClientSideEvents Validation="onPasswordValidation" KeyPress="function(s, e) {
                                                            if(e.htmlEvent.keyCode == 13) {
                                                                ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
                                                            }
                                                        }" />
                    <ValidationSettings ValidationGroup="PassValidation" ErrorText="* Password should contain minimum of 8 characters including letters, numbers and/or special characters">
                        <RequiredField IsRequired="True" ErrorText="*Required" />
                    </ValidationSettings>
                </dx:BootstrapTextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text="Re-Enter New Password"></asp:Label>
                <dx:BootstrapTextBox ID="txtPasswordConfirm" runat="server" NullText="Re-Enter New Password">
                    <ClientSideEvents Validation="onPasswordValidation" KeyPress="function(s, e) {
                                                            if(e.htmlEvent.keyCode == 13) {
                                                                ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
                                                            }
                                                        }" />
                    <ValidationSettings ValidationGroup="PassValidation" ErrorText="* Password should contain minimum of 8 characters including letters, numbers and/or special characters">
                        <RequiredField IsRequired="True" ErrorText="*Required" />
                    </ValidationSettings>
                </dx:BootstrapTextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-md-4 row-space text-right">
                <dx:BootstrapButton runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" CssClasses-Control="btn-style" CssClasses-Icon="fas fa-save noti-icon">
                </dx:BootstrapButton>
            </div>
        </div>

    </div>
</asp:Content>
