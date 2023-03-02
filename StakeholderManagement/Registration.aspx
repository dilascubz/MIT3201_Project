<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="StakeholderManagement.Registration" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="Lanwa, Stakeholder Management System, Prima, PMS, Software" />
    <title>HealthScore | Health & Fitness System</title>
    <link rel="shortcut icon" href="assets/images/logo2.png" />



    <!-- BASE CSS -->
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="assets/css/Login.css" rel="stylesheet" />
    <link href="assets/css/icons.css" rel="stylesheet" type="text/css" />

    <style>
        .content-left-wrapper {
            background: -webkit-linear-gradient(top, transparent, rgba(0, 0, 0, 0.5));
            background: linear-gradient(to bottom, transparent, rgba(0, 0, 0, 0.5));
        }

        .content-right {
            align-items: normal;
        }

        .btn-person {
            font-size: 22px;
            width: 250px;
            height: 80px;
            border-radius: 100px;
            background: #186ebe;
        }

            .btn-person:hover {
                color: #fff;
                background-color: #003578;
                border-color: #003578;
            }

        .btn-company {
            font-size: 22px;
            width: 250px;
            height: 80px;
            border-radius: 100px;
            background: #0084e1;
            border-color: #e1b300;
        }

            .btn-company:hover {
                color: #fff;
                background-color: #c49c00;
                border-color: #c49c00;
            }

        #demo {
            position: absolute;
            top: 0px;
            left: 0px;
            z-index: 99;
            color: white;
            opacity: 0;
        }
    </style>





</head>



<body>

    <p id="demo"></p>
    <script>
        var x = document.getElementById("demo");

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




        function showPositions(position) {


            $.ajax({
                url: "Registration.aspx/SendGPSCordinates",
                type: 'post',
                dataType: 'json',
                data: JSON.stringify({

                    location: "Latitude: " + position.coords.latitude +
                        ",Longitude: " + position.coords.longitude + ",Accuracy" + position.coords.accuracy
                }),
                contentType: 'application/json',
                success: function (data) {
                    alert('Success: ' + data);
                },
                error: function (error) {
                    alert(error.statusText);
                }
            });


        }

        getLocation();

        //function showPosition(position) {
        //    x.innerHTML = "Latitude: " + position.coords.latitude +
        //        "<br>Longitude: " + position.coords.longitude;
        //}



        function zfunction(s, e) {
            if (s.GetText() == "New") {
                pnlCardinfo.SetVisible(true);

            }


            else {
                pnlCardinfo.SetVisible(false);

            }
        }



        function gettheworking(s, e) {
            if (s.GetText() == "Mason") {
                pnlInstitute.SetVisible(false);

            }


            else {
                pnlInstitute.SetVisible(true);

            }
        }

    </script>

    <form runat="server">
        <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
        <div class="container-fluid full-height">
            <div class="row row-height">
                <div class="col-lg-5 content-left">
                    <%-- <div class="content-left-wrapper">
                       <div class="width-100">
                            <figure>
                                <img src="assets/images/Lanwa.png" alt="" class="img-fluid">
                            </figure>
                            <br />
                            <label class="title3">HealthScore</label>
                            <label class="title2">Ceylon Steel Corporation Limited</label>
                            <p>As a government entity, Ceylon Steel Corporation Introduced modern manufacture of steel rebars( 260 Grade plain mild steel bars) to Sri Lanka in the 1960s. It was a groundbreaking venture that shifted the emphasis of the economy from being agri-based to that of industry.</p>

                        </div>
                      

                    </div>--%>
                    <!-- /content-left-wrapper -->
                </div>
                <!-- /content-left -->

                <div class="col-lg-7 content-right">

                    <div class="container">
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-10">

                                <div class="row">
                                    <div class="col-md-12 row-space">
                                        <input id="HiddenField" type="hidden" runat="server" />
                                        <input id="Hidden2" type="hidden" runat="server" />
                                    </div>
                                </div>

                                <asp:Panel runat="server" ID="UserLogin">
                                    <div class="row">
                                        <div class="col-md-12 row-space">
                                            <label class="title1">User Accounts</label>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12 row-space text-center">
                                            <dx:BootstrapButton runat="server" ID="NonHomeOwner" OnClick="NonHomeOwner_Click"
                                                Text="Click to Register" CssClasses-Control="btn-company" CssClasses-Icon="fas fa-user noti-icon">
                                            </dx:BootstrapButton>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-12 row-space text-center">
                                            <dx:BootstrapButton Visible="false" runat="server" ID="HomeOwner" Text="Home Owner" OnClick="HomeOwner_Click" CssClasses-Control="btn-person" CssClasses-Icon="fas fa-user noti-icon"></dx:BootstrapButton>
                                        </div>
                                    </div>
                                </asp:Panel>



                                <%-----------------------------      PERSONAL         ------------------------------------%>




                                <%-- User Personal Details        PANEL 1--%>
                                <asp:Panel runat="server" ID="PersonalDetails">
                                    <div class="row">
                                        <div class="col-md-12 row-space">
                                            <label class="title1">Personal Details</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12 row-space">
                                            <asp:Label runat="server" Text="First Name"></asp:Label>
                                            <dx:BootstrapTextBox ID="txtStakeHolderName" runat="server" NullText=""
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
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12 row-space">
                                            <asp:Label runat="server" Text="Surname"></asp:Label>
                                            <dx:BootstrapTextBox ID="txtSurname" runat="server" NullText=""
                                                CssClasses-NullText="caption-style"
                                                ClientInstanceName="clStakeHolderName"
                                                Password="False" MaxLength="50">
                                                <ClientSideEvents KeyPress="function(s, e) {
                                                            if(e.htmlEvent.keyCode == 13) {
                                                                ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
                                                            }
                                                        }" />
                                                <ValidationSettings ValidationGroup="SignUpValidation">
                                                    <RequiredField ErrorText="Surnname is Required" IsRequired="True" />
                                                    <RegularExpression ErrorText="Surname format Invalid" ValidationExpression="^[a-zA-Z.\s]*$" />
                                                </ValidationSettings>
                                            </dx:BootstrapTextBox>
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-md-12 row-space">
                                            <asp:Label runat="server" PickerDisplayMode="Auto" EditFormatString="MMMM dd, yyyy" Text="Date of Birth"></asp:Label>
                                            <dx:BootstrapDateEdit AutoPostBack="false" OnCalendarCustomDisabledDate="dtDOB_CalendarCustomDisabledDate" ID="dtDOB" MaxDate="<%#System.DateTime.Now.AddDays(-1) %>" runat="server">

                                                <CalendarProperties HighlightToday="false" ShowTodayButton="false" ShowClearButton="false" />
                                                <%--       <ClientSideEvents CalendarCustomDisabledDate="onCustomDisabledDate" />--%>
                                                <ValidationSettings ValidationGroup="SignUpValidation">
                                                    <RequiredField ErrorText="DOB is Required" IsRequired="True" />
                                                    <%-- <RegularExpression ErrorText="Name format Invalid" ValidationExpression="^[a-zA-Z.\s]*$" />--%>
                                                </ValidationSettings>
                                            </dx:BootstrapDateEdit>
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-md-12 row-space">
                                            <asp:Label runat="server" Text="Email"></asp:Label>

                                            <dx:BootstrapTextBox MaxLength="50" ID="txtemail" runat="server">
                                                <ValidationSettings ValidationGroup="SignUpValidation">

                                                    <RequiredField ErrorText="* Email is Required" IsRequired="True" />
                                                    <RegularExpression ErrorText="* Invalid Email" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
                                                </ValidationSettings>

                                            </dx:BootstrapTextBox>
                                        </div>
                                    </div>




                                    <div class="row">
                                        <div class="col-md-12 row-space">
                                            <asp:Label runat="server" Text="Mobile No"></asp:Label>
                                            <dx:BootstrapTextBox ID="txtTelephone" runat="server" MaxLength="10">
                                                <ValidationSettings ValidationGroup="SignUpValidation">
                                                    <RequiredField ErrorText="Mobile No is Required" IsRequired="True" />
                                                    <RegularExpression ErrorText="10 digits only" ValidationExpression="^[0-9]{10}$" />
                                                </ValidationSettings>
                                            </dx:BootstrapTextBox>
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-md-12 row-space">
                                            <asp:Label runat="server" Text="Address"></asp:Label>

                                            <dx:BootstrapTextBox ClientInstanceName="clTxtAddress1"
                                                Password="False" MaxLength="50" ID="txtAddress1" runat="server">
                                                <ClientSideEvents KeyPress="function(s, e) {
                                                            if(e.htmlEvent.keyCode == 13) {
                                                                ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
                                                            }
                                                        }" />
                                                <ValidationSettings ValidationGroup="SignUpValidation">
                                                    <RequiredField ErrorText="Address Line 1 is Required" IsRequired="True" />
                                                    <RegularExpression ErrorText="Address Line 1 Invalid" ValidationExpression="^[a-zA-Z0-9. ():,'&quot;/-]*$" />
                                                </ValidationSettings>
                                            </dx:BootstrapTextBox>
                                        </div>
                                    </div>



                                    <div class="row">
                                        <div class="col-md-12 row-space">
                                            <asp:Label Visible="false" runat="server" Text="Address Line 2"></asp:Label>
                                            <dx:BootstrapTextBox Visible="false" ID="txtAddress2"
                                                ClientInstanceName="clTxtRetailerName"
                                                runat="server"
                                                Password="False" MaxLength="50">
                                                <ClientSideEvents KeyPress="function(s, e) {
                                                            if(e.htmlEvent.keyCode == 13) {
                                                                ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
                                                            }
                                                        }" />
                                                <ValidationSettings ValidationGroup="SignUpValidation">
                                                    <RequiredField ErrorText="Address Line 2 is Required" IsRequired="True" />
                                                    <RegularExpression ErrorText="Address Line 2 Invalid" ValidationExpression="^[a-zA-Z0-9. ():,'&quot;/-]*$" />
                                                </ValidationSettings>
                                            </dx:BootstrapTextBox>
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-md-12 row-space">
                                            <asp:Label runat="server" Visible="false" Text="Address Line 3"></asp:Label>
                                            <dx:BootstrapTextBox Visible="false" ID="txtAddress3" MaxLength="20" runat="server">
                                            </dx:BootstrapTextBox>
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-md-12 row-space">
                                            <asp:Label runat="server" Text="Gender"></asp:Label>
                                            <dx:BootstrapRadioButton ID="chkmale" runat="server" Text="Male" GroupName="RadioGroup" Checked="true">
                                            </dx:BootstrapRadioButton>
                                            <dx:BootstrapRadioButton ID="chkFemale" runat="server" Text="Female" GroupName="RadioGroup">
                                            </dx:BootstrapRadioButton>
                                        </div>
                                    </div>



                                    <div class="row">
                                        <div class="col-md-12 row-space text-right">
                                            <dx:BootstrapButton runat="server" ID="btnPersonalPrev" Text="Previous" CssClasses-Control="btn-width" CssClasses-Icon="fas fa-caret-left noti-icon"></dx:BootstrapButton>

                                            <dx:BootstrapButton runat="server" ID="btnPersonalNext" Text="Next" OnClick="btnPersonalNext_Click"
                                                CssClasses-Control="btn-width" CssClasses-Icon="fas fa-caret-right noti-icon">
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
                                                <SettingsBootstrap RenderOption="Primary" />
                                            </dx:BootstrapButton>
                                        </div>
                                    </div>
                                </asp:Panel>









                                <%--   Social --%>
                                <asp:Panel runat="server" ID="Social">
                                    <div class="row">
                                        <div class="col-md-12 row-space">
                                            <label class="title1">Other Details</label>
                                        </div>
                                    </div>



                                    <div class="row">
                                        <div class="col-md-12 row-space">
                                            <asp:Label runat="server" Text="Height(cm)"></asp:Label>
                                            <dx:BootstrapTextBox Visible="false" MaxLength="20" ID="txtDesignation" runat="server">
                                            </dx:BootstrapTextBox>

                                            <dx:BootstrapTextBox MaxLength="20" ID="txtHeight" runat="server">
                                            </dx:BootstrapTextBox>

                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-md-12 row-space">
                                            <asp:Label runat="server" Text="Weight(Kg)"></asp:Label>
                                            <dx:BootstrapTextBox MaxLength="20" ID="txtWeight" runat="server">
                                            </dx:BootstrapTextBox>
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-md-12 row-space">
                                            <asp:Label runat="server" Text="Weight Goal"></asp:Label>
                                            <dx:BootstrapComboBox ID="cmbStakeholder" DataSourceID="SqlStakeHolderTypes"
                                                TextField="Name" ValueField="Id" NullText="Select Fitness Goal" SelectedIndex="-1" runat="server">
                                                <ClientSideEvents SelectedIndexChanged="gettheworking" />

                                                <ValidationSettings ValidationGroup="SignUpValidation">
                                                    <RequiredField ErrorText="StakeHolder Type is Required" IsRequired="True" />
                                                    <%--                                                    <RegularExpression ErrorText="Address Line 2 Invalid" ValidationExpression="^[a-zA-Z0-9. ():,'&quot;/-]*$" />--%>
                                                </ValidationSettings>

                                            </dx:BootstrapComboBox>
                                        </div>
                                    </div>






                                    <div class="row">
                                        <div class="col-md-12 row-space">
                                            <asp:Label runat="server" Text="Contacted Type"></asp:Label>
                                            <dx:BootstrapComboBox TextField="Name" ValueField="Id" ID="cmdContactedType" runat="server">
                                                <Items>

                                                    <dx:BootstrapListEditItem Text="Social Media" Value="0" />
                                                    <dx:BootstrapListEditItem Text="Through a Friend" Value="1" />
                                                    <dx:BootstrapListEditItem Text="Over the Phone" Value="3" />

                                                </Items>
                                                <ValidationSettings ValidationGroup="WorkValidation">
                                                    <%-- <RequiredField ErrorText="Educational Details are Required" IsRequired="True" />--%>
                                                </ValidationSettings>
                                            </dx:BootstrapComboBox>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12 row-space">
                                            <asp:Label runat="server" Visible="false" Text="Profile Image"></asp:Label>
                                            <dx:BootstrapUploadControl Visible="false" runat="server" ShowUploadButton="false" FileUploadMode="OnPageLoad"
                                                ID="imgUploaderz" OnFilesUploadComplete="imgUploaderz_FilesUploadComplete">
                                                <ValidationSettings MaxFileSize="1000000" AllowedFileExtensions=".jpg,.jpeg,.gif,.png" />
                                            </dx:BootstrapUploadControl>
                                            <%--   <small>Allowed file extensions: .jpg, .jpeg, .gif, .png</small>
                                            <br />
                                            <small>Maximum file size: 1 MB</small>--%>
                                        </div>
                                    </div>






                                    <div class="row">
                                        <div class="col-md-12 row-space text-right">
                                            <dx:BootstrapButton runat="server" ID="btHOSocialPrev" Text="Previous" OnClick="btHOSocialPrev_Click" CssClasses-Control="btn-width" CssClasses-Icon="fas fa-caret-left noti-icon"></dx:BootstrapButton>
                                            <dx:BootstrapButton runat="server" ID="btnHOSocialNext" Text="Next" OnClick="btnHOSocialNext_Click" CssClasses-Control="btn-width" CssClasses-Icon="fas fa-caret-right noti-icon"></dx:BootstrapButton>
                                        </div>
                                    </div>
                                </asp:Panel>






                                <%--ACCOUNT--%>
                                <asp:Panel runat="server" ID="AccountDetails">
                                    <div class="row">
                                        <div class="col-md-12 row-space">
                                            <label class="title1">Account Details</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12 row-space">
                                            <asp:Label runat="server" Text="Username"></asp:Label>
                                            <dx:BootstrapTextBox ID="txtUserName" runat="server">
                                            </dx:BootstrapTextBox>
                                        </div>
                                    </div>


                                    <div class="row">
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12 row-space">
                                            <asp:Label runat="server" Text="Password"></asp:Label>
                                            <dx:BootstrapTextBox ID="txtPassword" Password="true" MaxLength="30" runat="server">
                                                <ClientSideEvents Validation="onPasswordValidation" KeyPress="function(s, e) {
                                                            if(e.htmlEvent.keyCode == 13) {
                                                                ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
                                                            }
                                                        }" />
                                                <ValidationSettings ValidationGroup="UserValidation"
                                                    SetFocusOnError="true" ErrorText="* Password should contain minimum of 8 characters including letters, numbers and/or special characters">
                                                    <RequiredField ErrorText="Password  is Required" IsRequired="True" />

                                                </ValidationSettings>
                                            </dx:BootstrapTextBox>
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-md-12 row-space">
                                            <asp:Label runat="server" Text="Re-enter Password" MaxLength="30"></asp:Label>
                                            <dx:BootstrapTextBox Password="true" ID="txtConfirmPassword" runat="server">
                                                <ClientSideEvents Validation="onPasswordValidation" KeyPress="function(s, e) {
                                                            if(e.htmlEvent.keyCode == 13) {
                                                                ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
                                                            }
                                                        }" />
                                                <ValidationSettings ValidationGroup="UserValidation"
                                                    SetFocusOnError="true">
                                                    <%--   ErrorText="* Password should contain minimum of 8 characters including letters, numbers and/or special characters">
                                                    --%>
                                                    <RequiredField ErrorText="Password Confirmation is Required" IsRequired="True" />

                                                </ValidationSettings>
                                            </dx:BootstrapTextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12 row-space text-right">
                                            <dx:BootstrapButton runat="server"
                                                ID="btnSubmit" OnClick="btnSubmit_Click"
                                                ClientInstanceName="clBtnNext" ClientEnabled="true"
                                                Text="Submit" CssClasses-Control="btn-width"
                                                CssClasses-Icon="fas fa-check noti-icon">
                                                <ClientSideEvents Click="function(s, e) { 
                                                    if(ASPxClientEdit.ValidateGroup('UserValidation'))
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
                                </asp:Panel>

                            </div>
                            <div class="col-md-1"></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12 row-space text-center">
                                Already have an Account?  <a href="Login.aspx">Login</a>
                            </div>
                        </div>
                        <br />
                    </div>
                </div>




                <!-- /content-right-->
            </div>
            <!-- /row-->
        </div>
        <!-- /container-fluid -->
        <%--  </ContentTemplate>
            </asp:UpdatePanel>--%>

        <asp:SqlDataSource ID="SqlStakeHolderTypes" runat="server"
            ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
            SelectCommand="sreGetFitnesstypes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

        <asp:SqlDataSource ID="sdsGetpurchasingitems" runat="server"
            ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
            SelectCommand="sreGetpurchasingitems" SelectCommandType="StoredProcedure"></asp:SqlDataSource>



        <asp:SqlDataSource ID="SqlASODetails" runat="server"
            ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
            SelectCommand="sreGetASOUsers" SelectCommandType="StoredProcedure"></asp:SqlDataSource>


    </form>

</body>
</html>
