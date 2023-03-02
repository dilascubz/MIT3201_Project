<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeaderBoard.aspx.cs" Inherits="StakeholderManagement.LeaderBoard" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Page Banner Section Start -->
    <div class="page-banner-section section" style="background-image: url(assets2/images/TitleBg.jpg)">
        <div class="container">
            <div class="row">
                <div class="page-banner-content col">
                    <h1>Community</h1>
                    <ul class="page-breadcrumb">
                        <li><a href="index.html">Online Community</a></li>
                        <li><a href="my-account.html">LeaderBoards</a></li>
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
                    <asp:Label runat="server" Text="Exercise Type"></asp:Label>
                    <dx:BootstrapTextBox ID="txtSubject" runat="server">
                        <ValidationSettings ValidationGroup="Validations">
                            <RequiredField ErrorText="Exercise is Required" IsRequired="True" />
                            <%--<RegularExpression ErrorText="Address Line 2 Invalid" ValidationExpression="^[a-zA-Z0-9. ():,'&quot;/-]*$" />--%>
                        </ValidationSettings>
                    </dx:BootstrapTextBox>
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



            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server" Text="Subject"></asp:Label>
                    <dx:BootstrapMemo ID="memoSubject" MaxLength="200" runat="server">
                        <ValidationSettings ValidationGroup="Validations">
                            <RequiredField ErrorText="A Message is Required" IsRequired="True" />
                            <%--<RegularExpression ErrorText="Address Line 2 Invalid" ValidationExpression="^[a-zA-Z0-9. ():,'&quot;/-]*$" />--%>
                        </ValidationSettings>
                    </dx:BootstrapMemo>
                </div>
            </div>



            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server" Text="Description"></asp:Label>
                    <dx:BootstrapMemo ID="txtDescription" MaxLength="200" runat="server">
                        <ValidationSettings ValidationGroup="Validations">
                            <RequiredField ErrorText="Description is Required" IsRequired="True" />
                            <%--<RegularExpression ErrorText="Address Line 2 Invalid" ValidationExpression="^[a-zA-Z0-9. ():,'&quot;/-]*$" />--%>
                        </ValidationSettings>
                    </dx:BootstrapMemo>
                </div>
            </div>


            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server" Text="Rep Count"></asp:Label>
                    <dx:BootstrapMemo ID="TxtRepCounts" MaxLength="200" runat="server">
                        <ValidationSettings ValidationGroup="Validations">
                            <RequiredField ErrorText="Description is Required" IsRequired="True" />
                            <%--<RegularExpression ErrorText="Address Line 2 Invalid" ValidationExpression="^[a-zA-Z0-9. ():,'&quot;/-]*$" />--%>
                        </ValidationSettings>
                    </dx:BootstrapMemo>
                </div>
            </div>


            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server" Text="Image"></asp:Label>
                    <dx:BootstrapUploadControl ID="ImgUploader" FileUploadMode="OnPageLoad"
                        OnFileUploadComplete="ImgUploader_FileUploadComplete"
                        runat="server">
                    </dx:BootstrapUploadControl>
                </div>
            </div>



            <div class="row">
                <div class="col-md-4 row-space text-right">
                    <dx:BootstrapButton runat="server" ID="btnLeaderBoard" OnClick="btnLeaderBoard_Click" Text="Submit"
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

        <asp:SqlDataSource ID="SqlStakeHolderTypes" runat="server" ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommand="sreGetstakeholdertypes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

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
