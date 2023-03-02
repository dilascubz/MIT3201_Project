<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Visits.aspx.cs" Inherits="StakeholderManagement.Visits" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Page Banner Section Start -->


    <script type="text/javascript">
        function zfunction(s, e) {
            if (s.GetText() == "Successful")

                clCustomer.SetVisible(true);
            else


                clCustomer.SetVisible(false);
        }

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

    <script type="text/javascript">
        function OnSelectedIndexChanged(s, e) {
            if (s.GetText() == "Successful")

                clCustomer.SetVisible(true);
            else
                clCustomer.SetVisible(false);
            alert('tesxt');
        }
    </script>



    <div class="page-banner-section section" style="background-image: url(assets2/images/TitleBg.jpg)">
        <div class="container">
            <div class="row">
                <div class="page-banner-content col">
                    <h1>Visits</h1>
                    <ul class="page-breadcrumb">
                        <li><a href="index.html">Home</a></li>
                        <li><a href="my-account.html">Visits</a></li>
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
                    <dx:BootstrapTextBox ID="txtFirstName" runat="server"
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
                    <dx:BootstrapTextBox ID="txtLastName" runat="server"
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
                    <asp:Label runat="server" Text="Address Line 1"></asp:Label>
                    <dx:BootstrapTextBox ID="txtAddress1" runat="server">
                        <ValidationSettings ValidationGroup="SignUpValidation">
                            <RequiredField ErrorText="Address  is Required" IsRequired="True" />
                            <RegularExpression ErrorText="Address format Invalid" ValidationExpression="^[a-zA-Z0-9. ():,'&quot;/-]*$" />
                        </ValidationSettings>
                    </dx:BootstrapTextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <asp:Label runat="server" Text="Address Line 2"></asp:Label>
                    <dx:BootstrapTextBox ID="txtAddress2" runat="server">
                        <ValidationSettings ValidationGroup="SignUpValidation">
                            <RequiredField ErrorText="Address Line2 is Required" IsRequired="True" />
                            <RegularExpression ErrorText="Address2 format Invalid" ValidationExpression="^[a-zA-Z0-9. ():,'&quot;/-]*$" />
                        </ValidationSettings>
                    </dx:BootstrapTextBox>
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" Text="Address Line 3"></asp:Label>
                    <dx:BootstrapTextBox ID="txtAddress3" runat="server">
                        <ValidationSettings ValidationGroup="SignUpValidation">
                            <RegularExpression ErrorText="Address3 format Invalid" ValidationExpression="^[a-zA-Z.\s]*$" />
                        </ValidationSettings>
                    </dx:BootstrapTextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <asp:Label runat="server" Text="Email"></asp:Label>
                    <dx:BootstrapTextBox ID="txtEmail" runat="server">
                        <ValidationSettings ValidationGroup="SignUpValidation">

                            <RequiredField ErrorText="* Email is Required" IsRequired="True" />
                            <RegularExpression ErrorText="* Invalid Email" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
                        </ValidationSettings>
                    </dx:BootstrapTextBox>
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" Text="Telephone"></asp:Label>
                    <dx:BootstrapTextBox ID="txtTelephone" runat="server">
                        <ValidationSettings ValidationGroup="SignUpValidation">

                            <RequiredField ErrorText="Mobile No is Required" IsRequired="True" />
                            <RegularExpression ErrorText="10 digits only" ValidationExpression="^[0-9]{10}$" />


                        </ValidationSettings>
                    </dx:BootstrapTextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <asp:Label runat="server" Text="Stakeholder Type"></asp:Label>
                    <dx:BootstrapComboBox DataSourceID="SqlStakeHolderTypes" TextField="Name" ValueField="Id" ID="cmbStakeHolderType" runat="server">

                        <ValidationSettings ValidationGroup="SignUpValidation">
                            <RequiredField ErrorText="Stakeholder Type is Required" IsRequired="True" />
                        </ValidationSettings>

                    </dx:BootstrapComboBox>
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" Text="User Image"></asp:Label>
                    <%--  <dx:BootstrapBinaryImage ID="imgViewer" runat="server">
                        <EditingSettings Enabled="true" AllowDropOnPreview="true" EmptyValueText="Drop image here" />
                    </dx:BootstrapBinaryImage>--%>

                    <dx:BootstrapUploadControl ID="ImgUploader"
                        runat="server">
                    </dx:BootstrapUploadControl>
                </div>
            </div>
            <hr />

            <asp:Panel runat="server" ID="UserDetails" Visible="false">
            
                
                <div class="row">
                    <div class="col-md-6">
                        <asp:Label runat="server" Text="Bank Name"></asp:Label>
                        <dx:BootstrapTextBox ID="txtBankName" runat="server">
                        </dx:BootstrapTextBox>
                    </div>
                    <div class="col-md-6">
                        <asp:Label runat="server" Text="Branch"></asp:Label>
                        <dx:BootstrapTextBox ID="txtBranch" runat="server">
                        </dx:BootstrapTextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6">
                        <asp:Label runat="server" Text="Account number"></asp:Label>
                        <dx:BootstrapTextBox ID="txtAcc" runat="server">
                        </dx:BootstrapTextBox>
                    </div>

                </div>
                <hr />
                <div class="row">
                    <div class="col-md-6">
                        <asp:Label runat="server" Text="Work place Address"></asp:Label>
                        <dx:BootstrapTextBox ID="txtWorkAddress" runat="server">
                        </dx:BootstrapTextBox>
                    </div>
                    <div class="col-md-6">
                        <asp:Label runat="server" Text="Experience in years"></asp:Label>
                        <dx:BootstrapSpinEdit MaxLength="2" ID="spWorkEx" runat="server">
                        </dx:BootstrapSpinEdit>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6">
                        <asp:Label runat="server" Text="Highest Educational qualification"></asp:Label>
                        <dx:BootstrapTextBox ID="txtWorkEducational" runat="server">
                        </dx:BootstrapTextBox>
                    </div>
                    <div class="col-md-6">
                        <asp:Label runat="server" Text="Other Educational qualifications"></asp:Label>
                        <dx:BootstrapMemo ID="txtOtherEducational" MaxLength="100" runat="server"></dx:BootstrapMemo>
                    </div>
                </div>

            </asp:Panel>

            <div class="row">
                <div class="col-md-6">
                    <asp:Label runat="server" Text="Visit Status"></asp:Label>
                    <dx:BootstrapComboBox AutoPostBack="true" DataSourceID="SqlGetVisitStatus" TextField="Remark"
                        ValueField="ID" ID="cmbVisitStatus"
                        OnSelectedIndexChanged="cmbVisitStatus_SelectedIndexChanged"
                        runat="server"
                        CssClasses-NullText="caption-style"
                        ClientInstanceName="clStakeHolderName">
                      
                        <ValidationSettings ValidationGroup="SignUpValidation">
                            <RequiredField ErrorText="Visit Remark is  Required" IsRequired="True" />

                        </ValidationSettings>
                    </dx:BootstrapComboBox>
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" ID="lblCustomer" Text="Customer"></asp:Label>
                    <dx:BootstrapComboBox ClientInstanceName="clCustomer" DataSourceID="SqlgetCustomers" ValueField="Id" TextField="Name"
                        ID="cmbCustomer" runat="server">
                    </dx:BootstrapComboBox>
                </div>
            </div>





            <div class="row">
                <div class="col-md-12 row-space text-right">
                    <dx:BootstrapButton runat="server" ID="btnBack" OnClick="btnBack_Click" Text="Back" CssClasses-Control="btn-style" CssClasses-Icon="fas fa-times noti-icon"></dx:BootstrapButton>
                    <dx:BootstrapButton runat="server" ID="btnSave" OnClick="btnSave_Click" Text="Save" CssClasses-Control="btn-style" CssClasses-Icon="fas fa-save noti-icon">
                        <%--   <ClientSideEvents Click="function(s, e) { 
                                                    if(ASPxClientEdit.ValidateGroup('SignUpValidation'))
                                                    {
                                                        e.processOnServer=true;
                                                        fbq('track', 'CompleteRegistration');
                                                    }
                                                    else
                                                    {
                                                    e.processOnServer=false;
                                                    } 
                                                }" />--%>
                    </dx:BootstrapButton>
                </div>
            </div>
            <dx:BootstrapTextBox ID="txtLong" runat="server" Width="170px" ClientInstanceName="txtLong" Visible="false">
            </dx:BootstrapTextBox>
            <dx:BootstrapTextBox ID="txtLat" runat="server" Width="170px" ClientInstanceName="txtLat" Visible="false">
            </dx:BootstrapTextBox>

        </div>
    </div>



    <asp:SqlDataSource ID="SqlConfig" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="sreConfig" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="ASOAccx" SessionField="ASOAcc" Type="Int32" />
             <asp:SessionParameter Name="UserAcc" SessionField="StakeId" Type="Int32" />

        </SelectParameters>
    </asp:SqlDataSource>


    <asp:SqlDataSource ID="SqlGetVisitStatus" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="SELECT ID,REMARK FROM VISITREMARK"></asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlgetCustomers" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommand="sgetCustomerAsoWIse"
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="ASO" SessionField="ASOAcc" Type="Int32" />
        </SelectParameters>

    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlGetIdwise" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        InsertCommand="SinVisitdetails" InsertCommandType="StoredProcedure"
        SelectCommand="sreGetUsersbyId" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="UserId" SessionField="StakeId" Type="Int32" />
        </SelectParameters>

        <InsertParameters>
            <asp:Parameter Name="VisitDetailNo" Type="string" />
            <asp:Parameter Name="UserId" Type="Int32" />
            <asp:Parameter Name="ASOAccId" Type="Int32" />
            <asp:Parameter Name="VisitRemarkId" Type="Int32" />
            <asp:Parameter Name="CustomerId" Type="Int32" />
        </InsertParameters>
    </asp:SqlDataSource>


    <asp:SqlDataSource ID="SqlGetEducationalLevel" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommand="sregetEducationalLevels" SelectCommandType="StoredProcedure"></asp:SqlDataSource>


    <asp:SqlDataSource ID="SqlDataGetRetailerType" runat="server" ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="SreGetRetailerType" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlStakeHolderTypes" runat="server" ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommand="sreGetstakeholdertypes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataUserDetails" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="SreGetUserDetailsByStakeHolderId"
        SelectCommandType="StoredProcedure" UpdateCommand="SupUserDetailsByUserId" UpdateCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="UserId" SessionField="UserId" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="StakeholderId" Type="string" />
            <asp:Parameter Name="firstName" Type="String" />
            <asp:Parameter Name="LastName" Type="String" />

            <asp:Parameter Name="AddressLine1" Type="String" />
            <asp:Parameter Name="AddressLine2" Type="String" />
            <asp:Parameter Name="AddressLine3" Type="String" />
            <asp:Parameter Name="StakeHolderTypeId" Type="Int32" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="MobileNo" Type="String" />
            <asp:Parameter Name="DOB" Type="String" />
            <asp:Parameter Name="BankName" Type="String" />
            <asp:Parameter Name="BankAcc" Type="String" />
            <asp:Parameter Name="BankBranch" Type="String" />
            <asp:Parameter Name="WorkAddress" Type="String" />
        <%--    <asp:Parameter Name="WorkExperience" Type="Int32" />--%>
            <asp:Parameter Name="WorkEducational" Type="String" />
            <asp:Parameter Name="GPSLat" Type="Single" />
            <asp:Parameter Name="GPSLong" Type="Single" />
            <asp:Parameter Name="OtherEducational" Type="String" />
            <asp:Parameter Name="Image" Type="String" />

        </UpdateParameters>
    </asp:SqlDataSource>






</asp:Content>

