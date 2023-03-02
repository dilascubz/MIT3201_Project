<%@ Page Title="Closest" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClosestLocations.aspx.cs" Inherits="StakeholderManagement.ClosestLocations" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <script type="text/javascript"
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDSwUo8vYy309zYfu6117iyZbde9_tEHCE&sensor=false">
    </script>
    <script type="text/javascript">
        function initialize() {
            var lat = document.getElementById('txtlat').value;
            var lon = document.getElementById('txtlon').value;
            var myLatlng = new google.maps.LatLng(lat, lon) // This is used to center the map to show our markers
            var mapOptions = {
                center: myLatlng,
                zoom: 6,
                mapTypeId: google.maps.MapTypeId.ROADMAP,

                marker: true
            };
            var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
            var marker = new google.maps.Marker({
                position: myLatlng
            });
            marker.setMap(map);
        }
    </script>


    <!-- Page Banner Section Start -->
    <div class="page-banner-section section" style="background-image: url(assets2/images/TitleBg.jpg)">
        <div class="container">
            <div class="row">
                <div class="page-banner-content col">
                    <h1>Closest Exercise Locations</h1>
                    <ul class="page-breadcrumb">
                        <li><a href="index.html">Transactions</a></li>
                        <li><a href="my-account.html">Closest Exercise Locations</a></li>
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
                    <asp:Label runat="server" Text="Distance In (KM)"></asp:Label>
                    <dx:BootstrapSpinEdit MinValue="0" MaxValue="25" MaxLength="2" ID="spdist" runat="server">
                    </dx:BootstrapSpinEdit>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 row-space text-right">
                    <dx:BootstrapButton runat="server" ID="btnSave" OnClick="btnsubmit_Click" Text="Confirm" CssClasses-Control="btn-style" CssClasses-Icon="fas fa-save noti-icon">
                    </dx:BootstrapButton>
                </div>
            </div>

            <cc1:GMap ID="GMap1" runat="server" Width="100%" Height="600" zoom="false" />
        </div>
    </div>


    <asp:SqlDataSource ID="SqlStakeHolderTypes" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommand="sgetNearestLocation"
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="StakeHolder" SessionField="UserId" Type="String" />
            <asp:ControlParameter ControlID="spdist" Name="Distance" PropertyName="Value" Type="Int32" DefaultValue="10" />

        </SelectParameters>


    </asp:SqlDataSource>



    <asp:SqlDataSource ID="sqlCurrentLocation" runat="server"
        ConnectionString="<%$ ConnectionStrings:StakeHolderManagmentConnectionString %>" SelectCommand="sgetNearestLocationUserWise"
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="StakeHolder" SessionField="UserId" Type="String" />


        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
