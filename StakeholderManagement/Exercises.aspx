<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exercises.aspx.cs" Inherits="StakeholderManagement.Exercises" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Page Banner Section Start -->
    <div class="page-banner-section section" style="background-image: url(assets2/images/TitleBg1.jpg)">
        <div class="container">
            <div class="row">
                <div class="page-banner-content col">
                    <h1>Exercises</h1>
                    <ul class="page-breadcrumb">
                        <li><a href="index.html">Requests</a></li>
                        <li><a href="my-account.html">Exercises</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Banner Section End -->

    <div class="page-section section section-padding">
        <div class="container overflow-x-auto">

            <div class="row">
                <div class="col-md-6">
                    <asp:Label runat="server" Text="Search"></asp:Label>
                    <dx:BootstrapTextBox ID="txtSearch" runat="server">
                        <ValidationSettings ValidationGroup="Validations">
                            <RequiredField ErrorText="Subject is Required" IsRequired="True" />
                            <%--                                                    <RegularExpression ErrorText="Address Line 2 Invalid" ValidationExpression="^[a-zA-Z0-9. ():,'&quot;/-]*$" />--%>
                        </ValidationSettings>
                    </dx:BootstrapTextBox>
                </div>



                <div class="col-md-6 row-space text-left">
                    <dx:BootstrapButton runat="server" ID="btnSearch" OnClick="btnSearch_Click" Text="Search"
                        CssClasses-Control="btn-style" CssClasses-Icon="fas fa-search">
                    </dx:BootstrapButton>
                </div>
            </div>


            <div class="row">
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

            <br />
            <div class="row">
                <div class="col-md-6">
                    <asp:Label runat="server" Text="Exercise Mode"></asp:Label>
                    <dx:BootstrapComboBox ID="cmbExerciseMode" DataSourceID="SdsExerciseModes" AutoPostBack="true"
                        TextField="Name" ValueField="Id" NullText="Select Fitness Mode"
                        OnSelectedIndexChanged="cmbExerciseMode_SelectedIndexChanged"
                        SelectedIndex="-1" runat="server">


                        <ValidationSettings ValidationGroup="SignUpValidation">
                            <RequiredField ErrorText="StakeHolder Type is Required" IsRequired="True" />
                            <%--  <RegularExpression ErrorText="Address Line 2 Invalid" ValidationExpression="^[a-zA-Z0-9. ():,'&quot;/-]*$" />--%>
                        </ValidationSettings>

                    </dx:BootstrapComboBox>
                </div>


                <%-- <div class="col-md-6">
                    <asp:Label runat="server" Text="Exercise Type"></asp:Label>
                    <dx:BootstrapComboBox ID="cmbExerciseType" DataSourceID="SdsExerciseFitness"
                        TextField="Name" ValueField="Id" NullText="Select Fitness Type"
                        SelectedIndex="-1" runat="server">


                        <ValidationSettings ValidationGroup="SignUpValidation">
                            <RequiredField ErrorText="StakeHolder Type is Required" IsRequired="True" />
                            <%-- <RegularExpression ErrorText="Address Line 2 Invalid" ValidationExpression="^[a-zA-Z0-9. ():,'&quot;/-]*$" />
                        </ValidationSettings>
                    </dx:BootstrapComboBox>
                </div>--%>
            </div>

            <br />
            <br />

            <div class="row">
                <div class="col-md-12 overflow-x-auto">
                    <dx:BootstrapGridView runat="server" ID="gdExercises"
                        KeyFieldName="Id"
                        OnCellEditorInitialize="gdVisitRecords_CellEditorInitialize"
                        OnCommandButtonInitialize="gdVisitRecords_CommandButtonInitialize"
                        AutoGenerateColumns="False"
                        CssClasses-HeaderRow="grid-headers-custom">
                        <SettingsEditing Mode="Inline"></SettingsEditing>
                        <SettingsDataSecurity AllowEdit="true" AllowDelete="false" AllowInsert="true" />

                        <SettingsBootstrap Striped="true" />
                        <Columns>
                            <%--<dx:BootstrapGridViewCommandColumn ShowEditButton="true" ShowDeleteButton="false" ShowNewButtonInHeader="true" ButtonRenderMode="Button" Width="100px" />--%>

                            <dx:BootstrapGridViewTextColumn FieldName="Id" VisibleIndex="1" Visible="False">
                            </dx:BootstrapGridViewTextColumn>

                            <dx:BootstrapGridViewTextColumn Visible="false">
                                <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true"
                                    MaskSettings-ErrorText="Required" />
                            </dx:BootstrapGridViewTextColumn>


                            <%--<dx:BootstrapGridViewCheckColumn FieldName="Active" VisibleIndex="5" Caption="Active">
                        </dx:BootstrapGridViewCheckColumn>--%>


                            <dx:BootstrapGridViewTextColumn FieldName="Name" Visible="true"
                                VisibleIndex="2" Width="200px" Caption="Exercise">
                            </dx:BootstrapGridViewTextColumn>


                            <dx:BootstrapGridViewBinaryImageColumn FieldName="Exerciseimage" PropertiesBinaryImage-ImageHeight="50"
                                PropertiesBinaryImage-ImageWidth="50"
                                Visible="true" VisibleIndex="2" Width="200px" Caption="Image">
                                <PropertiesBinaryImage>
                                </PropertiesBinaryImage>
                                <DataItemTemplate>
                                    <dx:ASPxImageZoom runat="server" ID="zoom" LargeImageLoadMode="OnPageLoad" ShowHintText="false"
                                        ImageContentBytes='<%# Eval("Exerciseimage") %>' LargeImageContentBytes='<%# Eval("Exerciseimage") %>' EnableZoomMode="False">
                                        <SettingsAutoGeneratedImages ImageCacheFolder="~/Thumb/" ImageHeight="60px" LargeImageWidth="1200px"></SettingsAutoGeneratedImages>
                                        <SettingsZoomMode ZoomWindowWidth="350" ZoomWindowHeight="350" ZoomWindowPosition="Bottom" />


                                    </dx:ASPxImageZoom>
                                </DataItemTemplate>
                            </dx:BootstrapGridViewBinaryImageColumn>


                            <dx:BootstrapGridViewTextColumn FieldName="ExerciseLink" Visible="false"
                                VisibleIndex="2" Width="200px" Caption="Video">
                            </dx:BootstrapGridViewTextColumn>

                            <dx:BootstrapGridViewTextColumn FieldName="Descriptions"
                                Visible="true" VisibleIndex="2" Width="200px" Caption="Description">
                            </dx:BootstrapGridViewTextColumn>






                        </Columns>

                        <Templates>


                            <DetailRow>

                                <table>
                                    <tr>
                                        <td>Video Link
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <%--   Video Bind here --%>
                                            <dx:ASPxObjectContainer ID="odsObjectController" runat="server" Height="344px" ObjectType="Flash"
                                                ObjectUrl='<%# Bind("ExerciseLink")%>' Width="555px">
                                            </dx:ASPxObjectContainer>

                                        </td>

                                    </tr>
                                </table>
                                </>
                            </DetailRow>

                        </Templates>

                        <SettingsPager Mode="ShowAllRecords" />
                        <SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="true"></SettingsDetail>



                    </dx:BootstrapGridView>
                </div>


                <%--                 <div class="col-md-12 overflow-x-auto">
                    <dx:BootstrapGridView runat="server" ID="BootstrapGridView1"
                        KeyFieldName="Id"  DataSourceID="sgetExercises"
                        OnCellEditorInitialize="gdVisitRecords_CellEditorInitialize"
                        OnCommandButtonInitialize="gdVisitRecords_CommandButtonInitialize"
                        AutoGenerateColumns="False"
                        CssClasses-HeaderRow="grid-headers-custom">
                        <SettingsEditing Mode="Inline"></SettingsEditing>
                        <SettingsDataSecurity AllowEdit="true" AllowDelete="false" AllowInsert="true" />

                        <SettingsBootstrap Striped="true" />
                        <Columns>
                            <%--<dx:BootstrapGridViewCommandColumn ShowEditButton="true" ShowDeleteButton="false" ShowNewButtonInHeader="true" ButtonRenderMode="Button" Width="100px" />

                            <dx:BootstrapGridViewTextColumn FieldName="Id" VisibleIndex="1" Visible="False">
                            </dx:BootstrapGridViewTextColumn>

                            <dx:BootstrapGridViewTextColumn Visible="false">
                                <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true"
                                    MaskSettings-ErrorText="Required" />
                            </dx:BootstrapGridViewTextColumn>


                            <%--<dx:BootstrapGridViewCheckColumn FieldName="Active" VisibleIndex="5" Caption="Active">
                        </dx:BootstrapGridViewCheckColumn>


                            <dx:BootstrapGridViewTextColumn FieldName="Name" Visible="true"
                                VisibleIndex="2" Width="200px" Caption="Exercise">
                            </dx:BootstrapGridViewTextColumn>


                            <dx:BootstrapGridViewBinaryImageColumn FieldName="Exerciseimage"
                                Visible="true" VisibleIndex="2" Width="200px" Caption="Image">
                                <PropertiesBinaryImage>
                                </PropertiesBinaryImage>
                            </dx:BootstrapGridViewBinaryImageColumn>


                            <dx:BootstrapGridViewTextColumn FieldName="ExerciseLink" Visible="true"
                                VisibleIndex="2" Width="200px" Caption="Video">
                            </dx:BootstrapGridViewTextColumn>

                            <dx:BootstrapGridViewTextColumn FieldName="Descriptions"
                                Visible="true" VisibleIndex="2" Width="200px" Caption="Description">
                            </dx:BootstrapGridViewTextColumn>






                        </Columns>

                        <Templates>


                            <DetailRow>

                                <table>
                                    <tr>
                                        <td>Video
                                        </td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <%--   Video Bind here --%>

                <%--   <dx:ASPxObjectContainer ID="ASPxObjectContainer1" runat="server" ClientInstanceName="oc"
                                                ObjectType="Flash" Width="320px" Height="284px" ObjectUrl='<%# Bind("ExerciseLink")%>'>
                                                <ObjectProperties />
                                            </dx:ASPxObjectContainer>



                                            <dx:ASPxObjectContainer ID="ASPxObjectContainer2" runat="server" Height="344px" ObjectType="Flash"
                                                ObjectUrl="https://www.youtube.com/v/CBJ2TRkj_ms&hl=en_US&fs=1&" Width="555px">
                                            </dx:ASPxObjectContainer>

                                        </td>

                                    </tr>
                                </table>
                                </>
                            </DetailRow>

                        </Templates>

                        <SettingsPager Mode="ShowAllRecords" />
                        <SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="true"></SettingsDetail>



                    </dx:BootstrapGridView>
                </div>--%>
            </div>



            <div class="row">
                <div class="col-md-4">
                    <asp:Label Visible="false" runat="server" Text="Quotation Details"></asp:Label>
                    <dx:BootstrapMemo Visible="false" ID="txtMemo" MaxLength="200" runat="server">
                        <ValidationSettings ValidationGroup="Validations">
                            <RequiredField ErrorText="A Message is Required" IsRequired="True" />
                            <%--                                                    <RegularExpression ErrorText="Address Line 2 Invalid" ValidationExpression="^[a-zA-Z0-9. ():,'&quot;/-]*$" />--%>
                        </ValidationSettings>
                    </dx:BootstrapMemo>
                </div>
            </div>



            <div class="row">
                <div class="col-md-4 row-space text-right">
                    <dx:BootstrapButton ClientVisible="false" runat="server" ID="btnQuatation" OnClick="btnExercises_Click" Text="Submit"
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

        <asp:SqlDataSource ID="SdsExerciseFitness" runat="server"
            ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
            SelectCommand="sreGetFitnesstypes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>


        <asp:SqlDataSource ID="SdsExerciseModes" runat="server"
            ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
            SelectCommand="sreGetFitnessModes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        <%--     SelectCommand="sreNotify"    SelectCommandType="StoredProcedure"--%>


        <asp:SqlDataSource ID="SqlDataUserDetails" runat="server"
            ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
            SelectCommand="SreGetUserDetailsByStakeHolderId"
            SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="UserId" SessionField="UserId" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>


        <asp:SqlDataSource ID="dsUserEmail" runat="server"
            ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
            SelectCommand="SreGetAdminEmail"
            SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="UserId" SessionField="UserId" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>


        <asp:SqlDataSource ID="sgetExercises" runat="server"
            ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
            SelectCommand="sgetExerciseToGrid"
            SelectCommandType="StoredProcedure"></asp:SqlDataSource>


        <asp:SqlDataSource ID="NotificationSave" runat="server" ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
            UpdateCommand="sreNotify" UpdateCommandType="StoredProcedure">
            <UpdateParameters>
                <%--            <asp:SessionParameter Name="CreatedBy" SessionField="UserId" Type="String" />--%>
                <asp:ControlParameter ControlID="cmbStakeholder" Name="StakeHolderType" PropertyName="Value" Type="Int32" />
                <asp:ControlParameter ControlID="cmbNotificationType" Name="Type" PropertyName="Value" Type="Int32" />
                <asp:ControlParameter ControlID="txtMemo" Name="Msg" PropertyName="Text" Type="String" />

            </UpdateParameters>
        </asp:SqlDataSource>


        <asp:SqlDataSource ID="sreGetPromotions" runat="server" ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
            UpdateCommand="sreNotify" UpdateCommandType="StoredProcedure">
            <UpdateParameters>
                <%--            <asp:SessionParameter Name="CreatedBy" SessionField="UserId" Type="String" />--%>
                <asp:ControlParameter ControlID="cmbStakeholder" Name="StakeHolderType" PropertyName="Value" Type="Int32" />
                <asp:ControlParameter ControlID="cmbNotificationType" Name="Type" PropertyName="Value" Type="Int32" />
                <asp:ControlParameter ControlID="txtMemo" Name="Msg" PropertyName="Text" Type="String" />

            </UpdateParameters>
        </asp:SqlDataSource>
    </div>

</asp:Content>
