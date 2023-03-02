<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="StakeholderManagement.ForgetPassword" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script lang="javascript">
        function clBtnLogin_Click() {
            if (document.getElementById("clTxtUsername") != null) {
                //clBtnLogin.performClick();
                var username = document.getElementById("clTxtUsername").value;
            }
        }




        function onPasswordValidation(s, e) {
            var password = e.value;
            if (password == null)
                return;
            if (password.length < 8)
                e.isValid = false;

            var hasLetters = /[A-Za-z]/.test(password);
            var hasNumbers = /\d/.test(password);
            var hasNonalphas = /!@#$&*/.test(password);
            if (hasLetters + hasNumbers + hasNonalphas < 2)
                e.isValid = false;
        }
    </script>
    <div class="main-page">
        <div class="page-title-box">
            <div class="row align-items-center ">
                <div class="col-md-8">
                    <div class="page-title-box">
                        <h4 class="page-title">Forgot Password</h4>
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item">
                                <a href="javascript:void(0);">Stakeholder Management</a>
                            </li>
                            <li class="breadcrumb-item active">Forgot Password</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>
        <!-- end page-title -->

        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text="Username"></asp:Label>
                <dx:BootstrapTextBox runat="server" ID="txtUserName" ClientInstanceName="clTxtUsername">
                    <ValidationSettings CausesValidation="True" ValidationGroup="LoginGroup">
                        <RequiredField ErrorText="Username is Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:BootstrapTextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text=""></asp:Label>
                <dx:BootstrapButton ID="btnSendCode" runat="server" AutoPostBack="false" OnClick="btnSendCode_Click"
                    CssClasses-Control="btn-style"
                    ClientInstanceName="clBtnLogin" ClientEnabled="true"
                    CssClasses-Icon="fas fa-save noti-icon">
                    <ClientSideEvents Click="function(s, e) { if(ASPxClientEdit.ValidateGroup('LoginGroup')){e.processOnServer=true;}else{e.processOnServer=false;}}" />

                </dx:BootstrapButton>


            </div>
        </div>


        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text=""></asp:Label>
                <dx:BootstrapTextBox ID="txtVerificationCode" runat="server" AutoPostBack="false">
                    <ValidationSettings CausesValidation="True" ValidationGroup="VerifiGroup">
                        <RequiredField ErrorText="Verification Code is Required" IsRequired="True" />
                    </ValidationSettings>
                </dx:BootstrapTextBox>


            </div>
        </div>


        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" Text=""></asp:Label>
                <dx:BootstrapButton ID="btnNext" runat="server" AutoPostBack="false"
                    OnClick="btnNext_Click" CssClasses-Control="btn-style"
                    ClientInstanceName="clBtnNext" ClientEnabled="true"
                    CssClasses-Icon="fas fa-save noti-icon">
                    <ClientSideEvents Click="function(s, e) { if(ASPxClientEdit.ValidateGroup('VerifiGroup')){e.processOnServer=true;}else{e.processOnServer=false;}}" />

                </dx:BootstrapButton>


            </div>
        </div>


        <div class="row">
            <div class="col-md-12 row-space text-center">
                Already have an Account?  <a href="Login.aspx">Login</a>
            </div>
        </div>



        <asp:SqlDataSource ID="SqlGetUsers" runat="server"
            ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
            SelectCommand="sreGetUsers" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlStakeHolderTypes" runat="server"
            ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommand="sregetStakeHolderTypes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlGetEducationalLevel" runat="server"
            ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommand="sregetEducationalLevels" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</asp:Content>
