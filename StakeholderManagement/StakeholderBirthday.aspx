<%@ Page Title="Stakeholder Birthday Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StakeholderBirthday.aspx.cs" Inherits="StakeholderManagement.StakeholderBirthday" %>

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
                    <h1>Reports</h1>
                    <ul class="page-breadcrumb">
                        <li><a href="index.html">Stakeholder Birthday Details</a></li>

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
                    <asp:Label runat="server" Text="ASM"></asp:Label>

                    <%--  DataSourceID="SqlGetUsers"  TextField="FName"  ValueField="Id "--%>

                    <dx:BootstrapComboBox AutoPostBack="True"
                        ID="cmbASM" DataSourceID="OdsASM" ValueField="Id" TextField="Name"
                        OnSelectedIndexChanged="cmbASM_SelectedIndexChanged" runat="server">

                        <ValidationSettings ValidationGroup="SignUpValidation">
                            <RequiredField ErrorText="Please Select an ASM" IsRequired="True" />

                        </ValidationSettings>
                        <%--   <Items>
                            <dx:BootstrapListEditItem Text="Select All" Value="0" />
                        </Items>--%>
                    </dx:BootstrapComboBox>
                </div>




            </div>


            <div class="row">
                <div class="col-md-6">
                    <asp:Label runat="server" Text="ASO"></asp:Label>

                    <%--  DataSourceID="SqlGetUsers"  TextField="FName"  ValueField="Id"--%>

                    <dx:BootstrapComboBox
                        ID="cmbASO"
                        OnSelectedIndexChanged="cmbASO_SelectedIndexChanged" runat="server">

                        <ValidationSettings ValidationGroup="SignUpValidation">
                            <RequiredField ErrorText="Please Select an ASO" IsRequired="True" />
                        </ValidationSettings>
                        <%--   <Items>
                            <dx:BootstrapListEditItem Text="Select All" Value="0" />
                        </Items>--%>
                    </dx:BootstrapComboBox>
                </div>




            </div>


            <div class="row">


                <div class="col-md-6">
                    <asp:Label runat="server" Text="Month"></asp:Label>

                    <dx:BootstrapComboBox ID="cmbMonth"
                        NullText="Select Month"
                        runat="server">
                        <ValidationSettings ValidationGroup="SignUpValidation">
                            <RequiredField ErrorText="Please Select a Month" IsRequired="True" />
                        </ValidationSettings>
                    </dx:BootstrapComboBox>
                </div>





            </div>


            <%--     <div class="row">


                <div class="col-md-6">
                    <asp:Label runat="server" Text="Stakeholder Type"></asp:Label>

                    <dx:BootstrapComboBox ID="cmbStakeHolderType" DataSourceID="odsStakeholderTypes"
                        OnSelectedIndexChanged="cmbStakeHolderType_SelectedIndexChanged" AutoPostBack="true"
                        TextField="Name" ValueField="Id" NullText="Select Stakeholder"
                        runat="server">
                    </dx:BootstrapComboBox>
                </div>



                <div class="col-md-6">
                    <asp:Label runat="server" Text="Stakeholder Name"></asp:Label>
                    <dx:BootstrapComboBox
                        ID="cmbStakeHolderId"
                        OnSelectedIndexChanged="cmbStakeHolderId_SelectedIndexChanged" runat="server">

                        <ValidationSettings ValidationGroup="SignUpValidation">
                            <RequiredField ErrorText="Please Select a StakeHolder" IsRequired="True" />

                        </ValidationSettings>
                        <%--   <Items>
                            <dx:BootstrapListEditItem Text="Select All" Value="0" />
                        </Items>
                    </dx:BootstrapComboBox>
                </div>

            </div>--%>

            <div class="row">
                <div class="col-md-6">
                    <asp:Label runat="server" Visible="false" Text="From Date"></asp:Label>
                    <dx:BootstrapDateEdit ID="dtFromDate" Visible="false" OnDateChanged="dtFromDate_DateChanged" runat="server">
                    </dx:BootstrapDateEdit>
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" Visible="false" Text="To Date"></asp:Label>


                    <dx:BootstrapDateEdit ID="dtToDate" Visible="false" AutoPostBack="true" OnDateChanged="dtToDate_DateChanged"
                        runat="server">
                    </dx:BootstrapDateEdit>
                </div>
            </div>


            <div class="row">
                <div class="col-md-6">

                    <dx:BootstrapButton ID="btnProcess" Text="Generate" OnClick="btnProcess_Click" CssClasses-Control="btn-style" runat="server">
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




            <br />



            <div class="row">
                <div class="col-md-12">



                    <dx:ASPxButton ID="btnXlsExport" Width="40px" Height="40px" Text="" UseSubmitBehavior="False" OnClick="btnXlsExport_Click" runat="server">
                        <HoverStyle>
                            <BackgroundImage HorizontalPosition="center" ImageUrl="assets/images/xls.png" Repeat="NoRepeat" VerticalPosition="center" />
                        </HoverStyle>
                        <BackgroundImage HorizontalPosition="center" ImageUrl="assets/images/xls.png" Repeat="NoRepeat" VerticalPosition="center" />
                    </dx:ASPxButton>
                </div>
            </div>





            <dx:BootstrapGridView runat="server" ID="gdStakeholderBirthday"
                KeyFieldName="Id" DataSourceID="odsStakeHolderBirthday" 
                CssClasses-HeaderRow="grid-headers-custom">
                <SettingsEditing Mode="Inline"></SettingsEditing>
                <SettingsDataSecurity AllowEdit="true" AllowDelete="false" AllowInsert="true" />

                <SettingsBootstrap Striped="true" />
                <Columns>

                    <dx:BootstrapGridViewTextColumn FieldName="Id" VisibleIndex="1" Visible="False">
                    </dx:BootstrapGridViewTextColumn>



                    <dx:BootstrapGridViewTextColumn FieldName="FName" Visible="true" VisibleIndex="2" Width="150px" Caption="First Name">
                        <PropertiesTextEdit Width="200px" ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                            <ValidationSettings ValidationGroup="SignUpValidation">
                                <RequiredField ErrorText="Name is Required" IsRequired="True" />
                                <RegularExpression ErrorText="Name format Invalid" ValidationExpression="^[a-zA-Z.\s]*$" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>


                    <dx:BootstrapGridViewTextColumn FieldName="LName" Visible="true" VisibleIndex="2" Width="150px" Caption="Last Name">
                        <PropertiesTextEdit Width="200px" ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                            <ValidationSettings ValidationGroup="SignUpValidation">
                                <RequiredField ErrorText="Name is Required" IsRequired="True" />
                                <RegularExpression ErrorText="Name format Invalid" ValidationExpression="^[a-zA-Z.\s]*$" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>

                    <dx:BootstrapGridViewTextColumn FieldName="Email" Visible="false" VisibleIndex="2" Width="200px" Caption="Email">
                        <PropertiesTextEdit Width="200px" ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                            <ValidationSettings>
                                <RequiredField ErrorText="Email is Required" IsRequired="True" />
                                <RegularExpression ErrorText="Email format Invalid" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>



                    <dx:BootstrapGridViewDateColumn FieldName="DOB" Visible="true" VisibleIndex="2" Width="150px" Caption="DOB">

                        <SettingsEditForm Visible="false" />
                        <PropertiesDateEdit Width="100px" ValidationSettings-RequiredField-IsRequired="true">
                        </PropertiesDateEdit>

                    </dx:BootstrapGridViewDateColumn>



                    <dx:BootstrapGridViewTextColumn FieldName="NIC" Visible="false" VisibleIndex="2" Width="150px" Caption="NIC">
                        <PropertiesTextEdit Width="200px" ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                            <ValidationSettings>
                                <RequiredField ErrorText="NIC is Required" IsRequired="True" />
                                <RegularExpression ErrorText="NIC format Invalid" ValidationExpression="([0-9]{9}[x|X|v|V]|[0-9]{12})$" />
                            </ValidationSettings>

                        </PropertiesTextEdit>

                    </dx:BootstrapGridViewTextColumn>

                    <dx:BootstrapGridViewTextColumn FieldName="MobileNo" Visible="true" VisibleIndex="2" Width="50px" Caption="Mobile No">
                        <PropertiesTextEdit Width="100px" ValidationSettings-RequiredField-IsRequired="true" MaskSettings-ErrorText="Required">
                            <ValidationSettings>
                                <RequiredField ErrorText="Mobile No is Required" IsRequired="True" />
                                <RegularExpression ErrorText="Name format Invalid" ValidationExpression="^[0-9]{10}$" />
                            </ValidationSettings>

                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>

                    <dx:BootstrapGridViewTextColumn FieldName="ASO" VisibleIndex="2" Visible="true" Width="160px" Caption="ASO">
                        <SettingsEditForm Visible="false" />
                        <PropertiesTextEdit Width="200px">
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


                    <dx:BootstrapGridViewTextColumn FieldName="StakeHolderType" Visible="true" VisibleIndex="2" Width="150px" Caption="StakeHolder Category">
                        <SettingsEditForm Visible="false" />
                        <PropertiesTextEdit Width="200px">
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>


                    <dx:BootstrapGridViewComboBoxColumn Width="200px" FieldName="StakeHolderTypeId" Name="CategoryId" Visible="false" VisibleIndex="3" Caption="StakeHolder Category">
                        <PropertiesComboBox Width="200px" DataSourceID="SqlStakeHolderTypes" TextField="Name" ValueField="Id">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>

                        </PropertiesComboBox>
                    </dx:BootstrapGridViewComboBoxColumn>

                    <dx:BootstrapGridViewCheckColumn FieldName="Active" Visible="false" VisibleIndex="5" Caption="Active">
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


                    <dx:BootstrapGridViewTextColumn FieldName="WorkAddress" Visible="false" VisibleIndex="2" Width="400px" Caption="Work Address">
                    </dx:BootstrapGridViewTextColumn>


                    <dx:BootstrapGridViewSpinEditColumn FieldName="WorkExperience" Visible="false" VisibleIndex="2" Width="400px" Caption="Work Experience Years">
                        <SettingsEditForm Visible="false" />
                        <PropertiesSpinEdit ValidationSettings-RequiredField-IsRequired="true">
                        </PropertiesSpinEdit>
                    </dx:BootstrapGridViewSpinEditColumn>

                    <dx:BootstrapGridViewTextColumn FieldName="BankName" Visible="false" VisibleIndex="2" Width="200" Caption="Bank Name">
                        <SettingsEditForm Visible="True" />

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

                    <dx:BootstrapGridViewTextColumn FieldName="remark" Visible="false" VisibleIndex="8" Width="200" Caption="Visit Remark">
                        <SettingsEditForm Visible="false" />
                        <PropertiesTextEdit Width="200px">
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>


                    <dx:BootstrapGridViewCommandColumn Visible="false" ButtonRenderMode="Button" Caption="" VisibleIndex="7">
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
                                        <label class="form-group">Bank Name:</label>
                                    </div>
                                    <div class="col-md-4 no-padding">
                                        <asp:Label runat="server"
                                            Text='<%# DataBinder.Eval(Container.DataItem, "BankName")%>'
                                            CssClass="label-text"></asp:Label>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-2 no-padding">
                                        <label class="form-group">Bank Branch :</label>
                                    </div>
                                    <div class="col-md-4 no-padding">
                                        <asp:Label runat="server"
                                            Text='<%# DataBinder.Eval(Container.DataItem, "BankBranch")%>'
                                            CssClass="label-text"></asp:Label>
                                    </div>



                                    <div class="col-md-2 no-padding">
                                        <label class="form-group">Bank Acc:</label>
                                    </div>
                                    <div class="col-md-4 no-padding">
                                        <asp:Label runat="server"
                                            Text='<%# DataBinder.Eval(Container.DataItem, "BankAcc")%>'
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
                                        <label class="form-group">Designation:</label>
                                    </div>
                                    <div class="col-md-4 no-padding">
                                        <asp:Label runat="server"
                                            Text='<%# DataBinder.Eval(Container.DataItem, "Designation")%>'
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




                <SettingsExport FileName="Sales Orders List" EnableClientSideExportAPI="true"
                    ExcelExportMode="DataAware" ExportEmptyDetailGrid="false"
                    PaperKind="A4" Landscape="true">
                </SettingsExport>

            </dx:BootstrapGridView>

            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" GridViewID="gdStakeholderBirthday" runat="server"></dx:ASPxGridViewExporter>

        </div>
    </div>

    <asp:SqlDataSource ID="sdsGetpurchasingitems" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="sreGetpurchasingitems" SelectCommandType="StoredProcedure"></asp:SqlDataSource>



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
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="sregetStakeHolderTypesReg" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:SqlDataSource ID="OdsASM" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="sreGetAllASMs" SelectCommandType="StoredProcedure"></asp:SqlDataSource>




    <asp:SqlDataSource ID="odsStakeholderTypes" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="sreGetstakeholdertypesAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>


   


    <asp:ObjectDataSource ID="odsStakeHolderBirthday" runat="server"
        SelectMethod="GetStakeHolderBirthdays" 
        TypeName="BLLRMS.BLLRetailerPreviousOrderItems">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmbASO" Name="ASOAccId" PropertyName="Value"  />
            <asp:ControlParameter ControlID="cmbMonth" Name="Month" PropertyName="Value"  />


        </SelectParameters>
    </asp:ObjectDataSource>


</asp:Content>
