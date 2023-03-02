<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="StakeholderManagement.Profile" %>


<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <script>
        function getLocation() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(showPosition);
            } else {
                x.innerHTML = "Geolocation is not supported by this browser.";
            }
        }

        function showPosition(position) {
            x.innerHTML = "Latitude: " + position.coords.latitude +
                "<br>Longitude: " + position.coords.longitude;
            document.getElementById("HiddenField").innerText = position.coords.latitude;

            document.getElementById("HiddenField").value = position.coords.latitude;
            document.getElementById("Hidden2").value = position.coords.longitude;

        }
    </script>

    <!-- Page Banner Section Start -->
    <div class="page-banner-section section" style="background-image: url(assets2/images/TitleBg.jpg)">
        <div class="container">
            <div class="row">
                <div class="page-banner-content col">
                    <h1>My Account</h1>
                    <ul class="page-breadcrumb">
                        <li><a href="index.html">Home</a></li>
                        <li><a href="my-account.html">My Account</a></li>
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
                    <asp:Label runat="server" Text="First Name"></asp:Label>
                    <dx:BootstrapTextBox ID="txtFirstName" runat="server" CssClasses-Control="textbox-cs"
                        CssClasses-NullText="caption-style"
                        ClientInstanceName="clStakeHolderName"
                        Password="False" MaxLength="50">
                        <ClientSideEvents KeyPress="function(s, e) {
                                                            if(e.htmlEvent.keyCode == 13) {
                                                                ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
                                                            }
                                                        }" />
                        <ValidationSettings ValidationGroup="SignUpValidation">
                            <RequiredField ErrorText="First Name is Required" IsRequired="True" />
                            <RegularExpression ErrorText="First Name format Invalid" ValidationExpression="^[a-zA-Z.\s]*$" />
                        </ValidationSettings>
                    </dx:BootstrapTextBox>
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" Text="Last Name"></asp:Label>
                    <dx:BootstrapTextBox ID="txtLastName" runat="server" CssClasses-Control="textbox-cs"
                        CssClasses-NullText="caption-style"
                        ClientInstanceName="clStakeHolderName"
                        Password="False" MaxLength="50">
                        <ClientSideEvents KeyPress="function(s, e) {
                                                            if(e.htmlEvent.keyCode == 13) {
                                                                ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
                                                            }
                                                        }" />
                        <ValidationSettings ValidationGroup="SignUpValidation">
                            <RequiredField ErrorText="Last Name is Required" IsRequired="True" />
                            <RegularExpression ErrorText="Last Name format Invalid" ValidationExpression="^[a-zA-Z.\s]*$" />
                        </ValidationSettings>
                    </dx:BootstrapTextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <asp:Label runat="server" Text="Date of Birth"></asp:Label>
                    <dx:BootstrapDateEdit ID="dtDOB" runat="server">
                    </dx:BootstrapDateEdit>
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" Text="Address"></asp:Label>
                    <dx:BootstrapTextBox ID="txtAddress1" runat="server" CssClasses-Control="textbox-cs">
                        <ValidationSettings ValidationGroup="SignUpValidation">
                            <RequiredField ErrorText="Address  is Required" IsRequired="True" />
                            <RegularExpression ErrorText="Address format Invalid" ValidationExpression="^[a-zA-Z0-9. ():,'&quot;/-]*$" />
                        </ValidationSettings>
                    </dx:BootstrapTextBox>
                </div>
            </div>



            <div class="row">
                <div class="col-md-6">
                    <asp:Label runat="server" Text="UserId"></asp:Label>
                    <dx:BootstrapTextBox Enabled="false" ID="txtEmail" runat="server" CssClasses-Control="textbox-cs">
                        <ValidationSettings ValidationGroup="SignUpValidation">

                            <RequiredField ErrorText="* Email is Required" IsRequired="True" />
                            <RegularExpression ErrorText="* Invalid Email" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
                        </ValidationSettings>
                    </dx:BootstrapTextBox>
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" Text="Telephone"></asp:Label>
                    <dx:BootstrapTextBox ID="txtTelephone" runat="server" CssClasses-Control="textbox-cs">
                        <ValidationSettings ValidationGroup="SignUpValidation">

                            <RequiredField ErrorText="Mobile No is Required" IsRequired="True" />
                            <RegularExpression ErrorText="10 digits only" ValidationExpression="^[0-9]{10}$" />


                        </ValidationSettings>
                    </dx:BootstrapTextBox>
                </div>
            </div>



            <div class="row">
                <div class="col-md-6">
                    <asp:Label runat="server" Text="Fitness Type"></asp:Label>
                    <dx:BootstrapComboBox DataSourceID="SqlStakeHolderTypes" TextField="Name" ValueField="Id" ID="cmbStakeHolderType" runat="server">

                        <ValidationSettings ValidationGroup="SignUpValidation">
                            <RequiredField ErrorText="Stakeholder Type is Required" IsRequired="True" />
                        </ValidationSettings>

                    </dx:BootstrapComboBox>
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" Text="Profile Image"></asp:Label>
                    <%-- <dx:BootstrapBinaryImage OnValueChanged="imgViewer_ValueChanged" ID="imgViewer" runat="server">
                        <EditingSettings Enabled="true" AllowDropOnPreview="true" EmptyValueText="Drop image here" />
                    </dx:BootstrapBinaryImage>--%>

                    <dx:BootstrapUploadControl ID="ImgUploader" FileUploadMode="OnPageLoad"
                        OnFileUploadComplete="ImgUploader_FileUploadComplete"
                        runat="server">
                    </dx:BootstrapUploadControl>
                </div>
            </div>




            <div class="row">
                <div class="col-md-6">
                    <asp:Label runat="server" Visible="false" Text="Address Line 2"></asp:Label>
                    <dx:BootstrapTextBox ID="txtAddress2" Visible="false" runat="server" CssClasses-Control="textbox-cs">
                        <ValidationSettings ValidationGroup="SignUpValidation">
                            <RequiredField ErrorText="Address Line2 is Required" IsRequired="True" />
                            <RegularExpression ErrorText="Address2 format Invalid" ValidationExpression="^[a-zA-Z0-9. ():,'&quot;/-]*$" />
                        </ValidationSettings>
                    </dx:BootstrapTextBox>
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" Visible="false" Text="Address Line 3"></asp:Label>
                    <dx:BootstrapTextBox ID="txtAddress3" Visible="false" runat="server" CssClasses-Control="textbox-cs">
                        <ValidationSettings ValidationGroup="SignUpValidation">
                            <RegularExpression ErrorText="Address3 format Invalid" ValidationExpression="^[a-zA-Z.\s]*$" />
                        </ValidationSettings>
                    </dx:BootstrapTextBox>
                </div>
            </div>




            <hr />
            <div class="row">
                <div class="col-md-6">
                    <asp:Label runat="server" Text="Height(cm)"></asp:Label>
                    <dx:BootstrapTextBox ID="txtHeight" runat="server" CssClasses-Control="textbox-cs">
                    </dx:BootstrapTextBox>
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" Text="Weight(Kg)"></asp:Label>
                    <dx:BootstrapTextBox ID="txtWeight" runat="server" CssClasses-Control="textbox-cs">
                    </dx:BootstrapTextBox>
                </div>
            </div>



            <div class="row">
                <div class="col-md-6">
                    <asp:Label runat="server" Visible="false" Text="Account number"></asp:Label>
                    <dx:BootstrapTextBox ID="txtAcc" Visible="false" runat="server" CssClasses-Control="textbox-cs">
                    </dx:BootstrapTextBox>
                </div>

            </div>
            <hr />


            <asp:Panel ID="NonHomeOwner" runat="server">
                <div class="row">
                    <div class="col-md-6">
                        <asp:Label Visible="false" runat="server" Text="Institute"></asp:Label>
                        <dx:BootstrapTextBox Visible="false" ID="txtInstitute" runat="server" CssClasses-Control="textbox-cs">
                        </dx:BootstrapTextBox>
                    </div>

                    <div class="col-md-6">
                        <asp:Label runat="server" Text="Designation" Visible="false"></asp:Label>
                        <dx:BootstrapTextBox ID="txtDesignation" Visible="false" runat="server" CssClasses-Control="textbox-cs">
                        </dx:BootstrapTextBox>
                    </div>
                </div>
            </asp:Panel>



            <%--       <div class="row">
                    <div class="col-md-6">

                        <asp:Label Visible="false" runat="server" Text="Experience in years"></asp:Label>
                        <dx:BootstrapSpinEdit MaxLength="2" ID="BootstrapSpinEdit1" Visible="false" runat="server">
                        </dx:BootstrapSpinEdit>
                    </div>


                    <div class="col-md-6">
                        <asp:Label runat="server" Visible="false" Text="Other Educational qualifications"></asp:Label>
                        <dx:BootstrapMemo ID="BootstrapMemo1" MaxLength="100" Visible="false" runat="server"></dx:BootstrapMemo>
                    </div>
                </div>
            </asp:Panel>



            <div class="row">
                <div class="col-md-6">
                    <asp:Label runat="server" Text="Work place Address"></asp:Label>
                    <dx:BootstrapTextBox ID="txtWorkAddress" runat="server" CssClasses-Control="textbox-cs">
                    </dx:BootstrapTextBox>
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" Text="Experience in years"></asp:Label>
                    <dx:BootstrapSpinEdit MaxLength="2" ID="spWorkEx" runat="server">
                    </dx:BootstrapSpinEdit>
                </div>
            </div>--%>


            <asp:Panel ID="HomeOwner" Visible="false" runat="server">
                <div class="row">
                    <div class="col-md-6">
                        <asp:Label runat="server" Text=""></asp:Label>
                        <dx:BootstrapTextBox Visible="false" ID="txtdesignation2" runat="server" CssClasses-Control="textbox-cs">
                        </dx:BootstrapTextBox>
                    </div>

                    <div class="col-md-6">
                        <asp:Label runat="server" Text=""></asp:Label>
                        <dx:BootstrapTextBox Visible="false" ID="txtWorkAddress" runat="server" CssClasses-Control="textbox-cs">
                        </dx:BootstrapTextBox>
                    </div>
                </div>


            </asp:Panel>






            <hr />
            <div class="row">
                <div class="col-md-6">
                    <dx:BootstrapButton runat="server" ID="ChangePassword"
                        Text="Change Password" OnClick="ChangePassword_Click"
                        CssClasses-Control="btn-primary-cs"
                        CssClasses-Icon="fas fa-user noti-icon">
                    </dx:BootstrapButton>

                </div>
            </div>


            <div class="row">
                <div class="col-md-12 row-space text-right">
                    <dx:BootstrapButton runat="server" ID="btnBack" Text="Back" OnClick="Unnamed_Click" CssClasses-Control="btn-primary-cs" CssClasses-Icon="fas fa-times noti-icon"></dx:BootstrapButton>
                    <dx:BootstrapButton runat="server" ID="btnSave" OnClick="btnSave_Click" Text="Save" CssClasses-Control="btn-primary-cs" CssClasses-Icon="fas fa-save noti-icon">
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
            </div>
            <dx:BootstrapTextBox ID="txtLong" runat="server" Width="170px" ClientInstanceName="txtLong" Visible="false">
            </dx:BootstrapTextBox>
            <dx:BootstrapTextBox ID="txtLat" runat="server" Width="170px" ClientInstanceName="txtLat" Visible="false">
            </dx:BootstrapTextBox>

        </div>
    </div>

    <asp:SqlDataSource ID="SqlGetEducationalLevel" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommand="sregetEducationalLevels" SelectCommandType="StoredProcedure"></asp:SqlDataSource>


    <asp:SqlDataSource ID="SqlDataGetRetailerType" runat="server" ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="SreGetRetailerType" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlStakeHolderTypes" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="sreGetFitnesstypes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataUserDetails" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="SreGetUserDetailsByStakeHolderId"
        SelectCommandType="StoredProcedure" UpdateCommand="SupUserDetailsByUserId"
        UpdateCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="UserId" SessionField="UserId" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="StakeholderId" Type="string" />
            <asp:Parameter Name="firstName" Type="String" />
            <asp:Parameter Name="LastName" Type="String" />
            <asp:Parameter Name="AddressLine1" Type="String" />
            <asp:Parameter Name="FitnessTypeId" Type="Int32" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="MobileNo" Type="String" />
            <asp:Parameter Name="DOB" Type="String" />
            <asp:Parameter Name="Height" Type="String" />
            <asp:Parameter Name="Weight" Type="String" />
            <asp:Parameter Name="BankBranch" Type="String" />
            <asp:Parameter Name="WorkAddress" Type="String" />
            <asp:Parameter Name="WorkEducational" Type="Int32" />
            <asp:Parameter Name="GPSLat" Type="Single" />
            <asp:Parameter Name="GPSLong" Type="Single" />

            <asp:Parameter Name="Image" Type="String" />

        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
