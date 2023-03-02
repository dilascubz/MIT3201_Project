<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="StakeholderManagement.UserDetails" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Page Banner Section Start -->
    <div class="page-banner-section section" style="background-image: url(assets2/images/TitleBg.jpg)">
        <div class="container">
            <div class="row">
                <div class="page-banner-content col">
                    <h1>User Accounts</h1>
                    <ul class="page-breadcrumb">
                        <li><a href="index.html">Masters</a></li>
                        <li><a href="my-account.html">User Accounts</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Banner Section End -->

    <div class="page-section section section-padding">
        <div class="container overflow-x-auto">


            <dx:BootstrapGridView runat="server" DataSourceID="SqlGetUsers" ID="gdAccounts"
                KeyFieldName="Id" OnCustomButtonCallback="gdAccounts_CustomButtonCallback"
                OnRowInserting="gdAccounts_RowInserting" OnRowValidating="gdAccounts_RowValidating"
                CssClasses-HeaderRow="grid-headers-custom">
                <SettingsEditing Mode="Inline"></SettingsEditing>
                <SettingsDataSecurity AllowEdit="true" AllowDelete="false" AllowInsert="true" />

                <SettingsBootstrap Striped="true" />
                <Columns>
                    <dx:BootstrapGridViewCommandColumn ShowEditButton="false" ShowDeleteButton="false" ShowNewButtonInHeader="true" ButtonRenderMode="Button" Width="100px" />

                    <dx:BootstrapGridViewTextColumn FieldName="Id" VisibleIndex="1" Visible="False">
                    </dx:BootstrapGridViewTextColumn>



                    <dx:BootstrapGridViewTextColumn FieldName="FName" Visible="true" VisibleIndex="2" Width="200px" Caption="First Name">
                        <PropertiesTextEdit Width="200px" ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                            <ValidationSettings ValidationGroup="SignUpValidation">
                                <RequiredField ErrorText="Name is Required" IsRequired="True" />
                                <RegularExpression ErrorText="Name format Invalid" ValidationExpression="^[a-zA-Z.\s]*$" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>


                    <dx:BootstrapGridViewTextColumn FieldName="LName" Visible="true" VisibleIndex="2" Width="200px" Caption="Last Name">
                        <PropertiesTextEdit Width="200px" ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                            <ValidationSettings ValidationGroup="SignUpValidation">
                                <RequiredField ErrorText="Name is Required" IsRequired="True" />
                                <RegularExpression ErrorText="Name format Invalid" ValidationExpression="^[a-zA-Z.\s]*$" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>

                    <dx:BootstrapGridViewTextColumn FieldName="Email" Visible="true" VisibleIndex="2" Width="200px" Caption="Email">
                        <PropertiesTextEdit Width="200px" ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                            <ValidationSettings>
                                <RequiredField ErrorText="Email is Required" IsRequired="True" />
                                <RegularExpression ErrorText="Email format Invalid" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>



                    <dx:BootstrapGridViewDateColumn FieldName="DOB" Visible="false" VisibleIndex="2" Width="100px" Caption="DOB">

                        <SettingsEditForm Visible="True" />
                        <PropertiesDateEdit Width="200px" ValidationSettings-RequiredField-IsRequired="true">
                        </PropertiesDateEdit>

                    </dx:BootstrapGridViewDateColumn>

                    <%--          <dx:BootstrapGridViewDateColumn FieldName="DOB" Visible="true" VisibleIndex="2" Width="80px" Caption="DOB">                  
                    <PropertiesDateEdit  Width="200px">
                    </PropertiesDateEdit>
                
               </dx:BootstrapGridViewDateColumn>--%>

                    <%--  <dx:BootstrapGridViewDateColumn FieldName="DOB" Visible="true" VisibleIndex="2" Width="400px" Caption="DOB">
                    <%-- <PropertiesDateEdit ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                    </PropertiesDateEdit>
                </dx:BootstrapGridViewDateColumn>--%>

                    <dx:BootstrapGridViewTextColumn FieldName="NIC" Visible="true" VisibleIndex="2" Width="200px" Caption="NIC">
                        <PropertiesTextEdit Width="200px" ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                            <ValidationSettings>
                                <RequiredField ErrorText="NIC is Required" IsRequired="True" />
                                <RegularExpression ErrorText="NIC format Invalid" ValidationExpression="([0-9]{9}[x|X|v|V]|[0-9]{12})$" />
                            </ValidationSettings>

                        </PropertiesTextEdit>

                    </dx:BootstrapGridViewTextColumn>

                    <dx:BootstrapGridViewTextColumn FieldName="MobileNo" Visible="true" VisibleIndex="2" Width="50px" Caption="Mobile No">
                        <PropertiesTextEdit Width="200px" ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                            <ValidationSettings>
                                <RequiredField ErrorText="Mobile No is Required" IsRequired="True" />
                                <RegularExpression ErrorText="Name format Invalid" ValidationExpression="^[0-9]{10}$" />
                            </ValidationSettings>

                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>


                    <dx:BootstrapGridViewTextColumn FieldName="AddressLine1" Visible="false" VisibleIndex="2" Width="400px" Caption="Address 1">
                        <PropertiesTextEdit Width="200px" ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                            <ValidationSettings>
                                <RequiredField ErrorText="Address is Required" IsRequired="True" />
                                <%-- <RegularExpression ErrorText="Address format Invalid" ValidationExpression="^[a-zA-Z.\s]*$" />
                                --%>
                            </ValidationSettings>

                        </PropertiesTextEdit>
                        <SettingsEditForm Visible="True" />
                    </dx:BootstrapGridViewTextColumn>


                    <dx:BootstrapGridViewTextColumn FieldName="AddressLine2" Visible="false" VisibleIndex="2" Width="400px" Caption="Address 2">
                        <SettingsEditForm Visible="True" />
                        <PropertiesTextEdit Width="200px" ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">

                            <ValidationSettings>
                                <RequiredField ErrorText="Address is Required" IsRequired="True" />
                                <%--                            <RegularExpression ErrorText="Address format Invalid" ValidationExpression="^[a-zA-Z.\s]*$" />--%>
                            </ValidationSettings>

                        </PropertiesTextEdit>

                    </dx:BootstrapGridViewTextColumn>

                    <dx:BootstrapGridViewTextColumn FieldName="AddressLine3" Visible="false" VisibleIndex="2" Width="400px" Caption="Address 3">
                        <SettingsEditForm Visible="True" />
                        <PropertiesTextEdit Width="200px">
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>

                    <dx:BootstrapGridViewComboBoxColumn Width="100px" FieldName="StakeHolderTypeId" Name="CategoryId" VisibleIndex="3" Caption="StakeHolderCategory">
                        <PropertiesComboBox Width="200px" DataSourceID="SqlStakeHolderTypes" TextField="Name" ValueField="Id">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>

                        </PropertiesComboBox>
                    </dx:BootstrapGridViewComboBoxColumn>

                    <dx:BootstrapGridViewCheckColumn FieldName="Active" VisibleIndex="5" Caption="Active">
                    </dx:BootstrapGridViewCheckColumn>


                    <%--   <dx:BootstrapGridViewBinaryImageColumn FieldName="DP" PropertiesBinaryImage-ImageWidth="50"
                    PropertiesBinaryImage-ImageHeight="50"  Name="Image">
                    <PropertiesBinaryImage EnableServerResize="True" ShowLoadingImage="True">
                    </PropertiesBinaryImage>
                </dx:BootstrapGridViewBinaryImageColumn>--%>



                    <dx:BootstrapGridViewTextColumn FieldName="BankName" Visible="false" VisibleIndex="2" Width="400px" Caption="Bank Name">
                        <SettingsEditForm Visible="True" />
                        <PropertiesTextEdit Width="200px">
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>

                    <dx:BootstrapGridViewTextColumn FieldName="BankBranch" Visible="false" VisibleIndex="2" Width="400px" Caption="Bank Branch">
                        <SettingsEditForm Visible="True" />
                        <PropertiesTextEdit Width="200px">
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>


                    <dx:BootstrapGridViewTextColumn FieldName="BankAcc" Visible="false" VisibleIndex="2" Width="400px" Caption="Bank Account">
                        <SettingsEditForm Visible="True" />
                        <PropertiesTextEdit Width="200px">
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>


                    <dx:BootstrapGridViewTextColumn FieldName="WorkAddress" Visible="false" VisibleIndex="2" Width="400px" Caption="Work Address">
                    </dx:BootstrapGridViewTextColumn>


                    <dx:BootstrapGridViewSpinEditColumn FieldName="WorkExperience" Visible="false" VisibleIndex="2" Width="400px" Caption="Work Experience Years">
                        <SettingsEditForm Visible="True" />
                        <PropertiesSpinEdit ValidationSettings-RequiredField-IsRequired="true">
                        </PropertiesSpinEdit>
                    </dx:BootstrapGridViewSpinEditColumn>

                    <dx:BootstrapGridViewTextColumn FieldName="Educational" Visible="false" VisibleIndex="2" Width="200" Caption="Highest Education Level">
                        <SettingsEditForm Visible="True" />
                        <PropertiesTextEdit Width="200px">
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>

                    <dx:BootstrapGridViewTextColumn FieldName="remark" Visible="true" VisibleIndex="8" Width="200" Caption="Visit Remark">
                        <SettingsEditForm Visible="false" />
                        <PropertiesTextEdit Width="200px">
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>




                    <%-- <dx:BootstrapGridViewComboBoxColumn FieldName="EducationalTypeId" Visible="false" VisibleIndex="2" Width="400px" Caption="Highest Educational Qualification">


                    <SettingsEditForm Visible="True" />
                    <%--  <PropertiesComboBox DataSourceID="SqlGetEducationalLevel" TextField="Name" ValueField="Id" ValidationSettings-RequiredField-IsRequired="true">
                    </PropertiesComboBox>
                </dx:BootstrapGridViewComboBoxColumn>--%>


                    <dx:BootstrapGridViewCommandColumn ButtonRenderMode="Button" Caption="" VisibleIndex="7">
                        <CustomButtons>
                            <dx:BootstrapGridViewCommandColumnCustomButton Visibility="AllDataRows" ID="BootstrapGridViewCommandColumnCustomButton1" Text="Visit Plan"></dx:BootstrapGridViewCommandColumnCustomButton>
                        </CustomButtons>

                    </dx:BootstrapGridViewCommandColumn>


                </Columns>


                <%--     <Templates>
                <DetailRow>
                    <dx:BootstrapGridView runat="server" ID="gdDetailedAccounts" KeyFieldName="Id"
                        OnBeforePerformDataSelect="gdDetailedAccounts_BeforePerformDataSelect"
                        CssClasses-HeaderRow="grid-headers-custom">
                        <SettingsEditing Mode="Inline"></SettingsEditing>
                        <SettingsDataSecurity AllowEdit="true" AllowDelete="false" AllowInsert="true" />

                        <SettingsBootstrap Striped="true" />
                        <Columns>
                            <dx:BootstrapGridViewTextColumn FieldName="BankName" Visible="true" VisibleIndex="2" Width="400px" Caption="Bank Name">
                                <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                                </PropertiesTextEdit>
                            </dx:BootstrapGridViewTextColumn>
                            <dx:BootstrapGridViewTextColumn FieldName="BankBranch" Visible="true" VisibleIndex="2" Width="400px" Caption="Bank Branch">
                                <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                                </PropertiesTextEdit>
                            </dx:BootstrapGridViewTextColumn>
                            <dx:BootstrapGridViewTextColumn FieldName="BankAcc" Visible="true" VisibleIndex="2" Width="400px" Caption="Bank Account">
                                <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                                </PropertiesTextEdit>
                            </dx:BootstrapGridViewTextColumn>
                        </Columns>
                    </dx:BootstrapGridView>

                </DetailRow>
            </Templates>--%>


                <SettingsPopup>
                    <EditForm Modal="True" />
                </SettingsPopup>
                <SettingsText ConfirmDelete="Are you sure, you want to delete this record?"
                    PopupEditFormCaption="Add Users" />


                <SettingsPager PageSize="20">
                </SettingsPager>
                <SettingsBehavior ConfirmDelete="True"></SettingsBehavior>
                <SettingsEditing Mode="PopupEditForm" PopupEditFormHorizontalAlign="WindowCenter"
                    PopupEditFormVerticalAlign="WindowCenter">
                    <BatchEditSettings EditMode="Row"></BatchEditSettings>
                </SettingsEditing>
                <Settings ShowFooter="True" ShowHeaderFilterButton="True" ShowFilterRow="True"></Settings>
                <SettingsText ConfirmDelete="Are you sure you want to delete this record?"></SettingsText>
                <SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="true"></SettingsDetail>
                <SettingsPager Mode="ShowAllRecords" />


            </dx:BootstrapGridView>
        </div>
    </div>



    <asp:SqlDataSource ID="SqlGetUsers" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="sreGetUsers" SelectCommandType="StoredProcedure">

        <SelectParameters>
            <asp:SessionParameter Name="Usercategory" SessionField="UserCategoryId" Type="Int32" />
            <asp:SessionParameter Name="ASO" SessionField="ASOAcc" Type="Int32" />

        </SelectParameters>

    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlStakeHolderTypes" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommand="sregetStakeHolderTypes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>



</asp:Content>
