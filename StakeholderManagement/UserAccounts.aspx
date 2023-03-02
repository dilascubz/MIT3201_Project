<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserAccounts.aspx.cs" Inherits="StakeholderManagement.UserAccounts" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>


<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .dxtcLite > .dxtc-stripContainer .dxtc-tab, .dxtcLite > .dxtc-stripContainer .dxtc-activeTab {
            /*background-color: #ECECEC;*/
            float: left;
            overflow: hidden;
            text-align: center;
            white-space: nowrap;
            padding: 5px;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
            font-size: 14px;
            font-weight: 500;
        }

        .dxtcLite > .dxtc-stripContainer .dxtc-tab, .dxtcLite > .dxtc-stripContainer .dxtc-activeTab {
            border: 1px solid #CCC;
        }

        .dxtcLite > .dxtc-content {
            border: 1px solid #CCC;
            border-radius: 5px;
        }
    </style>
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
            <dx:ASPxPageControl ID="InvoicetabPage" runat="server" ActiveTabIndex="2">
                <TabPages>
                    <dx:TabPage Name="Others" Text="StakeHolders" ClientVisible="true">
                        <ContentCollection>
                            <dx:ContentControl runat="server">
                                <dx:BootstrapGridView runat="server" DataSourceID="SqlGetUsers" ID="gdAccounts"
                                    KeyFieldName="Id" OnCustomButtonCallback="gdAccounts_CustomButtonCallback"
                                    OnCellEditorInitialize="gdPromotions_CellEditorInitialize"
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

                                        <dx:BootstrapGridViewTextColumn Visible="false" VisibleIndex="2" Width="400px" Caption="District">
                                            <SettingsEditForm Visible="false" />
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


                                        <dx:BootstrapGridViewTextColumn FieldName="BankName" Visible="false" VisibleIndex="2" Width="400px" Caption="Bank Name">
                                            <SettingsEditForm Visible="True" />
                                        </dx:BootstrapGridViewTextColumn>


                                        <dx:BootstrapGridViewSpinEditColumn FieldName="WorkExperience" Visible="false" VisibleIndex="2" Width="400px" Caption="Work Experience Years">
                                            <SettingsEditForm Visible="false" />
                                            <PropertiesSpinEdit ValidationSettings-RequiredField-IsRequired="true">
                                            </PropertiesSpinEdit>
                                        </dx:BootstrapGridViewSpinEditColumn>

                                        <dx:BootstrapGridViewTextColumn FieldName="WorkAddress" Visible="false" VisibleIndex="2" Width="200" Caption="Institute">
                                            <SettingsEditForm Visible="false" />
                                            <PropertiesTextEdit Width="200px">
                                            </PropertiesTextEdit>
                                        </dx:BootstrapGridViewTextColumn>

                                        <dx:BootstrapGridViewTextColumn FieldName="Designation" Visible="false" VisibleIndex="2" Width="200" Caption="Designation">
                                            <SettingsEditForm Visible="True" />
                                            <PropertiesTextEdit Width="200px">
                                            </PropertiesTextEdit>
                                        </dx:BootstrapGridViewTextColumn>

                                        <dx:BootstrapGridViewTextColumn FieldName="WorkAddress" Visible="false" VisibleIndex="2" Width="200" Caption="Institute">
                                            <SettingsEditForm Visible="True" />
                                            <PropertiesTextEdit Width="200px">
                                            </PropertiesTextEdit>
                                        </dx:BootstrapGridViewTextColumn>

                                        <dx:BootstrapGridViewTextColumn FieldName="remark" Visible="true" VisibleIndex="8" Width="200" Caption="Visit Remark">
                                            <SettingsEditForm Visible="false" />
                                            <PropertiesTextEdit Width="200px">
                                            </PropertiesTextEdit>
                                        </dx:BootstrapGridViewTextColumn>


                                        <dx:BootstrapGridViewCommandColumn ButtonRenderMode="Button" Caption="" VisibleIndex="7">
                                            <CustomButtons>
                                                <dx:BootstrapGridViewCommandColumnCustomButton Visibility="AllDataRows" ID="VisitId" Text="User Visits"></dx:BootstrapGridViewCommandColumnCustomButton>
                                            </CustomButtons>

                                        </dx:BootstrapGridViewCommandColumn>
                                    </Columns>


                                    <Templates>
                                        <DetailRow>
                                            <div class="row ml-2">
                                                <div class="col-md-12">
                                                    <div class="row">
                                                        <div class="col-md-2 no-padding">
                                                            <label class="form-group">DOB :</label>
                                                        </div>
                                                        <div class="col-md-4 no-padding">
                                                            <asp:Label runat="server"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "DOB")%>'
                                                                CssClass="label-text"></asp:Label>
                                                        </div>



                                                        <div class="col-md-2 no-padding">
                                                            <label class="form-group">Designation:</label>
                                                        </div>
                                                        <div class="col-md-4 no-padding">
                                                            <asp:Label runat="server"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "Designation")%>'
                                                                CssClass="label-text"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-2 no-padding">
                                                            <label class="form-group">Bank Name :</label>
                                                        </div>
                                                        <div class="col-md-4 no-padding">
                                                            <asp:Label runat="server"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "BankName")%>'
                                                                CssClass="label-text"></asp:Label>
                                                        </div>



                                                        <div class="col-md-2 no-padding">
                                                            <label class="form-group">Bank Branch:</label>
                                                        </div>
                                                        <div class="col-md-4 no-padding">
                                                            <asp:Label runat="server"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "BankBranch")%>'
                                                                CssClass="label-text"></asp:Label>
                                                        </div>
                                                    </div>



                                                    <div class="row">
                                                        <div class="col-md-2 no-padding">
                                                            <label class="form-group">Institute :</label>
                                                        </div>
                                                        <div class="col-md-4 no-padding">
                                                            <asp:Label runat="server"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "WorkAddress")%>'
                                                                CssClass="label-text"></asp:Label>
                                                        </div>



                                                        <div class="col-md-2 no-padding">
                                                            <label class="form-group">Bank Account:</label>
                                                        </div>
                                                        <div class="col-md-4 no-padding">
                                                            <asp:Label runat="server"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "BankAcc")%>'
                                                                CssClass="label-text"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <div class="row">
                                                        <div class="col-md-2 no-padding">
                                                            <label class="form-group">Address :</label>
                                                        </div>
                                                        <div class="col-md-4 no-padding">
                                                            <asp:Label runat="server"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "Addressss")%>'
                                                                CssClass="label-text"></asp:Label>
                                                        </div>




                                                    </div>




                                                </div>
                                            </div>

                                        </DetailRow>
                                    </Templates>

                                    <SettingsPopup>
                                        <EditForm Modal="True" />
                                    </SettingsPopup>
                                    <SettingsText ConfirmDelete="Are you sure, you want to delete this record?"
                                        PopupEditFormCaption="Add Users" />
                                    <SettingsPager PageSize="15" AlwaysShowPager="true" EnableAdaptivity="true">
                                        <AllButton Visible="false"></AllButton>
                                        <PageSizeItemSettings Items="15, 30, 50, 100" ShowAllItem="false" Visible="True"></PageSizeItemSettings>
                                    </SettingsPager>

                                    <SettingsBehavior ConfirmDelete="True"></SettingsBehavior>
                                    <SettingsEditing Mode="PopupEditForm" PopupEditFormHorizontalAlign="WindowCenter"
                                        PopupEditFormVerticalAlign="WindowCenter">
                                        <BatchEditSettings EditMode="Row"></BatchEditSettings>
                                    </SettingsEditing>
                                    <Settings ShowFooter="True" ShowHeaderFilterButton="True" ShowFilterRow="True"></Settings>
                                    <SettingsText ConfirmDelete="Are you sure you want to delete this record?"></SettingsText>
                                    <SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="true"></SettingsDetail>
                                 


                                </dx:BootstrapGridView>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>



                    <%--                          Home Owner                                   --%>


                    <dx:TabPage Name="TemplateStocks" Text="Home Owner" ClientVisible="true">
                        <ContentCollection>
                            <dx:ContentControl runat="server">
                                <dx:BootstrapGridView runat="server" DataSourceID="SqlGetHomeOwners" ID="gdHomeOwner"
                                    KeyFieldName="Id" OnCustomButtonCallback="gdHomeOwner_CustomButtonCallback" OnCellEditorInitialize="gdHomeOwner_CellEditorInitialize"
                                    OnRowInserting="gdHomeOwner_RowInserting" OnRowValidating="gdHomeOwner_RowValidating"
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



                                        <dx:BootstrapGridViewCheckColumn FieldName="Active" VisibleIndex="5" Caption="Active">
                                        </dx:BootstrapGridViewCheckColumn>













                                        <dx:BootstrapGridViewTextColumn Visible="false" VisibleIndex="2" Width="400px" Caption="District">
                                            <SettingsEditForm Visible="false" />
                                            <PropertiesTextEdit Width="200px">
                                            </PropertiesTextEdit>
                                        </dx:BootstrapGridViewTextColumn>

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
                                            <SettingsEditForm Visible="false" />
                                            <PropertiesSpinEdit ValidationSettings-RequiredField-IsRequired="true">
                                            </PropertiesSpinEdit>
                                        </dx:BootstrapGridViewSpinEditColumn>

                                        <dx:BootstrapGridViewTextColumn FieldName="Educational" Visible="false" VisibleIndex="2" Width="200" Caption="Highest Education Level">
                                            <SettingsEditForm Visible="false" />
                                            <PropertiesTextEdit Width="200px">
                                            </PropertiesTextEdit>
                                        </dx:BootstrapGridViewTextColumn>

                                        <dx:BootstrapGridViewTextColumn FieldName="remark" Visible="true" VisibleIndex="8" Width="200" Caption="Visit Remark">
                                            <SettingsEditForm Visible="false" />
                                            <PropertiesTextEdit Width="200px">
                                            </PropertiesTextEdit>
                                        </dx:BootstrapGridViewTextColumn>

                                        <dx:BootstrapGridViewComboBoxColumn Width="100px" FieldName="Source" Name="Source" VisibleIndex="9" Caption="Source">
                                            <PropertiesComboBox Width="200px">
                                                <Items>

                                                    <dx:BootstrapListEditItem Text="Canvassing" Value="Canvassing"></dx:BootstrapListEditItem>
                                                    <dx:BootstrapListEditItem Text="Social Media Lead" Value="Social Media Lead"></dx:BootstrapListEditItem>
                                                    <dx:BootstrapListEditItem Text="Web Lead" Value="Web Lead"></dx:BootstrapListEditItem>

                                                    <dx:BootstrapListEditItem Text="Social Media Lead" Value="4"></dx:BootstrapListEditItem>
                                                </Items>

                                            </PropertiesComboBox>
                                        </dx:BootstrapGridViewComboBoxColumn>


                                        <dx:BootstrapGridViewComboBoxColumn Width="100px" FieldName="SiteType" Name="Site Type" VisibleIndex="10" Caption="Site Type">
                                            <PropertiesComboBox Width="200px">
                                                <Items>

                                                    <dx:BootstrapListEditItem Text="Single Storey" Value="Single Storey"></dx:BootstrapListEditItem>
                                                    <dx:BootstrapListEditItem Text="Two Storey" Value="Two Storey"></dx:BootstrapListEditItem>
                                                    <dx:BootstrapListEditItem Text="Multiple Storey" Value="Multiple Storey"></dx:BootstrapListEditItem>

                                                </Items>

                                            </PropertiesComboBox>
                                        </dx:BootstrapGridViewComboBoxColumn>

                                        <dx:BootstrapGridViewComboBoxColumn Width="100px" FieldName="CommercialSite" Name="CommercialSite" Visible="false" VisibleIndex="12" Caption="Commercial Site ">
                                            <SettingsEditForm Visible="True" />
                                            <PropertiesComboBox Width="200px">
                                                <Items>
                                                    <dx:BootstrapListEditItem Text="Yes" Value="0"></dx:BootstrapListEditItem>
                                                    <dx:BootstrapListEditItem Text="No" Value="1"></dx:BootstrapListEditItem>

                                                </Items>

                                            </PropertiesComboBox>
                                        </dx:BootstrapGridViewComboBoxColumn>


                                        <dx:BootstrapGridViewComboBoxColumn Width="100px" FieldName="SiteCondition" Visible="false" Name="Source" VisibleIndex="12" Caption="Site Condition">
                                            <PropertiesComboBox Width="200px">
                                                <Items>
                                                    <dx:BootstrapListEditItem Text="New" Value="New"></dx:BootstrapListEditItem>
                                                    <dx:BootstrapListEditItem Text="Ongoing" Value="Ongoing"></dx:BootstrapListEditItem>

                                                </Items>

                                            </PropertiesComboBox>
                                            <SettingsEditForm Visible="True" />
                                        </dx:BootstrapGridViewComboBoxColumn>




                                        <dx:BootstrapGridViewComboBoxColumn Width="100px" Visible="false" Name="Source" FieldName="ProductBrandId" VisibleIndex="13" Caption="Purchasing Brand">
                                            <PropertiesComboBox DataSourceID="sdsGetpurchasingitems" TextField="Name" ValueField="Id" Width="200px">
                                            </PropertiesComboBox>
                                            <SettingsEditForm Visible="True" />
                                        </dx:BootstrapGridViewComboBoxColumn>


                                        <dx:BootstrapGridViewSpinEditColumn FieldName="TotalProductReqiurement" Visible="false" VisibleIndex="14" Width="400px" Caption="Total Product Requirement">
                                            <SettingsEditForm Visible="True" />
                                            <PropertiesSpinEdit Width="200px">
                                            </PropertiesSpinEdit>
                                        </dx:BootstrapGridViewSpinEditColumn>


                                        <dx:BootstrapGridViewSpinEditColumn FieldName="PurchasedQty" Visible="false" VisibleIndex="15" Width="400px" Caption="PurchasedQty">
                                            <SettingsEditForm Visible="True" />
                                            <PropertiesSpinEdit Width="200px">
                                            </PropertiesSpinEdit>
                                        </dx:BootstrapGridViewSpinEditColumn>


                                        <dx:BootstrapGridViewCommandColumn ButtonRenderMode="Button" Caption="" VisibleIndex="7">
                                            <CustomButtons>
                                                <dx:BootstrapGridViewCommandColumnCustomButton Visibility="AllDataRows" ID="VisitHomeId" Text="User Visits"></dx:BootstrapGridViewCommandColumnCustomButton>
                                            </CustomButtons>

                                        </dx:BootstrapGridViewCommandColumn>
                                    </Columns>

                                    <Templates>
                                        <DetailRow>
                                            <div class="row ml-2">
                                                <div class="col-md-12">


                                                    <div class="row">
                                                        <div class="col-md-2 no-padding">
                                                            <label class="form-group">DOB :</label>
                                                        </div>
                                                        <div class="col-md-4 no-padding">
                                                            <asp:Label runat="server"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "DOB")%>'
                                                                CssClass="label-text"></asp:Label>
                                                        </div>



                                                        <div class="col-md-2 no-padding">
                                                            <label class="form-group">Address  :</label>
                                                        </div>
                                                        <div class="col-md-4 no-padding">
                                                            <asp:Label runat="server"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "Addressss")%>'
                                                                CssClass="label-text"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <%--         <div class="row">
                                                        <div class="col-md-2 no-padding">
                                                            <label class="form-group">Address Line 2 :</label>
                                                        </div>
                                                        <div class="col-md-4 no-padding">
                                                            <asp:Label runat="server"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "AddressLine2")%>'
                                                                CssClass="label-text"></asp:Label>
                                                        </div>



                                                        <div class="col-md-2 no-padding">
                                                            <label class="form-group">Address Line 3:</label>
                                                        </div>
                                                        <div class="col-md-4 no-padding">
                                                            <asp:Label runat="server"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "AddressLine3")%>'
                                                                CssClass="label-text"></asp:Label>
                                                        </div>
                                                    </div>--%>


                                                    <div class="row">
                                                        <div class="col-md-2 no-padding">
                                                            <label class="form-group">Bank Name :</label>
                                                        </div>
                                                        <div class="col-md-4 no-padding">
                                                            <asp:Label runat="server"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "BankName")%>'
                                                                CssClass="label-text"></asp:Label>
                                                        </div>



                                                        <div class="col-md-2 no-padding">
                                                            <label class="form-group">Bank Branch:</label>
                                                        </div>
                                                        <div class="col-md-4 no-padding">
                                                            <asp:Label runat="server"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "BankBranch")%>'
                                                                CssClass="label-text"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <div class="row">
                                                        <div class="col-md-2 no-padding">
                                                            <label class="form-group">Bank Account :</label>
                                                        </div>
                                                        <div class="col-md-4 no-padding">
                                                            <asp:Label runat="server"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "BankAcc")%>'
                                                                CssClass="label-text"></asp:Label>
                                                        </div>



                                                    </div>



                                                    <div class="row">
                                                        <div class="col-md-2 no-padding">
                                                            <label class="form-group">Source :</label>
                                                        </div>
                                                        <div class="col-md-4 no-padding">
                                                            <asp:Label runat="server"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "Source")%>'
                                                                CssClass="label-text"></asp:Label>
                                                        </div>



                                                        <div class="col-md-2 no-padding">
                                                            <label class="form-group">Site Type:</label>
                                                        </div>
                                                        <div class="col-md-4 no-padding">
                                                            <asp:Label runat="server"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "SiteType")%>'
                                                                CssClass="label-text"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-2 no-padding">
                                                            <label class="form-group">Site Condition:</label>
                                                        </div>
                                                        <div class="col-md-4 no-padding">
                                                            <asp:Label runat="server"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "SiteCondition")%>'
                                                                CssClass="label-text"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2 no-padding">
                                                            <label class="form-group">Commercial Site:</label>
                                                        </div>
                                                        <div class="col-md-4 no-padding">
                                                            <asp:Label runat="server"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "CommercialSite")%>'
                                                                CssClass="label-text"></asp:Label>
                                                        </div>


                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-2 no-padding">
                                                            <label class="form-group">Product Brand:</label>
                                                        </div>
                                                        <div class="col-md-4 no-padding">
                                                            <asp:Label runat="server"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "ProductBrand")%>'
                                                                CssClass="label-text"></asp:Label>
                                                        </div>




                                                    </div>

                                                    <div class="row">


                                                        <div class="col-md-2 no-padding">
                                                            <label class="form-group">Total Product Reqiurement:</label>
                                                        </div>
                                                        <div class="col-md-4 no-padding">
                                                            <asp:Label runat="server"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "TotalProductReqiurement")%>'
                                                                CssClass="label-text"></asp:Label>
                                                        </div>


                                                        <div class="row">
                                                            <div class="col-md-2 no-padding">
                                                                <label class="form-group">Purchased Qty  :</label>
                                                            </div>
                                                            <div class="col-md-4 no-padding">
                                                                <asp:Label runat="server"
                                                                    Text='<%# DataBinder.Eval(Container.DataItem, "PurchasedQty")%>'
                                                                    CssClass="label-text"></asp:Label>
                                                            </div>


                                                        </div>
                                                    </div>


                                                </div>
                                            </div>
                                        </DetailRow>
                                    </Templates>


                                    <SettingsPopup>
                                        <EditForm Modal="True" />
                                    </SettingsPopup>
                                    <SettingsText ConfirmDelete="Are you sure, you want to delete this record?"
                                        PopupEditFormCaption="Add Users" />


                                    <SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="true"></SettingsDetail>
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
                                   


                                </dx:BootstrapGridView>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>

                </TabPages>
            </dx:ASPxPageControl>





        </div>
    </div>



    <asp:SqlDataSource ID="SqlSMSDetails" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommand="sreGetSMSDetails" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:SqlDataSource ID="sdsGetpurchasingitems" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommand="sreGetpurchasingitems" SelectCommandType="StoredProcedure"></asp:SqlDataSource>



    <asp:SqlDataSource ID="SqlGetUsers" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="sreGetUsers" SelectCommandType="StoredProcedure">

        <SelectParameters>
            <asp:SessionParameter Name="Usercategory" SessionField="UserCategoryId" Type="Int32" />
            <asp:SessionParameter Name="ASO" SessionField="ASOAcc" Type="Int32" />

        </SelectParameters>

    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlGetHomeOwners" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="sreGetHomeUsers" SelectCommandType="StoredProcedure">

        <SelectParameters>
            <asp:SessionParameter Name="Usercategory" SessionField="UserCategoryId" Type="Int32" />
            <asp:SessionParameter Name="ASO" SessionField="ASOAcc" Type="Int32" />

        </SelectParameters>

    </asp:SqlDataSource>


    <asp:SqlDataSource ID="SqlStakeHolderTypes" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommand="sregetStakeHolderTypesReg" SelectCommandType="StoredProcedure"></asp:SqlDataSource>



</asp:Content>
