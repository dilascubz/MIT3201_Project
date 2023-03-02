<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SocialLife.aspx.cs" Inherits="StakeholderManagement.SocialLife" %>

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
                        <li><a href="my-account.html">Social Life</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Banner Section End -->

    <div class="page-section section section-padding">
        <div class="container overflow-x-auto">

            <div class="row">
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
                <asp:Label runat="server" Text="Image"></asp:Label>
                <dx:BootstrapBinaryImage ID="imgViewer" runat="server">
                    <EditingSettings Enabled="true" />
                </dx:BootstrapBinaryImage>
            </div>

        </div>


        <div class="row">
            <div class="col-md-6">
                <asp:Label runat="server" Text="Comments"></asp:Label>
                <dx:BootstrapMemo ID="txtcomment" runat="server" Rows="3" Text="Quisque imperdiet risus quis nisl vulputate, a pharetra tortor ornare. ">
                </dx:BootstrapMemo>
            </div>



        </div>


        <div class="row">
            <div class="col-md-6">
                <asp:Label runat="server" Text="Exercise Mode"></asp:Label>
                <dx:BootstrapMemo ID="userComments" runat="server" Rows="3"  >
                </dx:BootstrapMemo>
            </div>



        </div>


        <div class="row">
            <div class="col-md-6 row-space text-left">
                <dx:BootstrapButton runat="server" ID="btnSearch" OnClick="btnSearch_Click" Text="Comment"
                    CssClasses-Control="btn-style" CssClasses-Icon="fas fa-search">
                </dx:BootstrapButton>
            </div>
        </div>

        <br />
        <br />

        <div class="row">
            <div class="col-md-12 overflow-x-auto">
            </div>




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
                <dx:BootstrapButton ClientVisible="false" runat="server" ID="btnQuatation"
                    OnClick="btnExercises_Click" Text="Submit"
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





    <asp:SqlDataSource ID="srsUserDetailsGenerator" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>"
        SelectCommand="sreGetSocialDetails" SelectCommandType="StoredProcedure"
        UpdateCommand="SupSocialDetails" UpdateCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="SocialId" SessionField="SocialId" Type="String" />
        </SelectParameters>
        <UpdateParameters>

            <asp:Parameter Name="StakeholderId" Type="string" />
            <asp:Parameter Name="Comment" Type="String" />

        </UpdateParameters>

    </asp:SqlDataSource>


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


</asp:Content>
