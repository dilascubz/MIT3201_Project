<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UserChat.aspx.cs" Inherits="StakeholderManagement.UserChat" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .direct-chat .box-body {
            border-bottom-right-radius: 0;
            border-bottom-left-radius: 0;
            position: relative;
            overflow-x: hidden;
            padding: 0;
        }

        .box-body {
            border-top-left-radius: 0;
            border-top-right-radius: 0;
            border-bottom-right-radius: 3px;
            border-bottom-left-radius: 3px;
            padding: 10px;
        }

        .direct-chat-messages, .direct-chat-contacts {
            -webkit-transition: -webkit-transform 0.5s ease-in-out;
            -moz-transition: -moz-transform 0.5s ease-in-out;
            -o-transition: -o-transform 0.5s ease-in-out;
            transition: transform 0.5s ease-in-out;
        }

        .direct-chat-messages {
            -webkit-transform: translate(0, 0);
            -ms-transform: translate(0, 0);
            -o-transform: translate(0, 0);
            transform: translate(0, 0);
            overflow: auto;
        }

        .direct-chat-msg {
            margin-bottom: 5px;
            border-bottom: 1px solid #dbdfe7;
            padding-bottom: 10px;
        }

        .direct-chat-msg, .direct-chat-text {
            display: block;
        }

        .box-header::before, .box-body::before, .box-footer::before, .box-header::after, .box-body::after, .box-footer::after {
            content: " ";
            display: table;
        }

        .direct-chat-msg::before, .direct-chat-msg::after {
            content: " ";
            display: table;
        }

        .direct-chat-info {
            display: block;
            margin-bottom: 2px;
            font-size: 12px;
        }

        .direct-chat-name {
            font-weight: bold;
            font-size: 14px;
        }

        .direct-chat-timestamp {
            color: #999;
        }

        .direct-chat-img {
            border-radius: 50%;
            float: left;
            width: 40px;
            height: 40px;
        }

        .right .direct-chat-img {
            float: right !important;
        }

        .direct-chat-primary .right > .direct-chat-text {
            background: #3c8dbc;
            border-color: #3c8dbc;
            color: #ffffff;
        }

        .right .direct-chat-text {
            margin-right: 50px;
            margin-left: 0;
        }

        .direct-chat-text {
            border-radius: 5px;
            position: relative;
            padding: 5px 10px;
            background: #d6dbe4;
            border: 0px solid #d2d6de;
            margin: 5px 0 0 50px;
            margin-right: 0px;
            margin-left: 50px;
            color: #474747;
            font-size: 15px;
            font-weight: normal;
        }


        .direct-chat-primary .right > .direct-chat-text::after, .direct-chat-primary .right > .direct-chat-text::before {
            border-left-color: #3c8dbc;
        }

        .right .direct-chat-text::after, .right .direct-chat-text::before {
            right: auto;
            left: 100%;
            border-right-color: transparent;
            border-left-color: #d2d6de;
        }

        .direct-chat-text::before {
            border-width: 6px;
            margin-top: -6px;
        }

        .direct-chat-text::after, .direct-chat-text::before {
            position: absolute;
            right: 100%;
            top: 15px;
            border: solid transparent;
            border-top-width: medium;
            border-right-color: transparent;
            border-right-width: medium;
            border-bottom-width: medium;
            border-left-color: transparent;
            border-left-width: medium;
            border-right-color: #d2d6de;
            height: 0;
            width: 0;
            pointer-events: none;
        }

        .box.box-solid.box-primary {
            border: 1px solid #3c8dbc;
        }

            .box.box-solid.box-primary > .box-header {
                color: #ffffff;
                background: #3c8dbc;
                background-color: rgb(60, 141, 188);
                background-color: #3c8dbc;
            }

        .box-header.with-border {
            border-bottom: 1px solid #f4f4f4;
        }

        .box-header {
            color: #444;
            display: block;
            padding: 10px;
            position: relative;
        }

            .box-header > .fa, .box-header > .glyphicon, .box-header > .ion, .box-header .box-title {
                display: inline-block;
                font-size: 18px;
                margin: 0;
                line-height: 1;
                color: #f4f4f4;
            }

        .box-comments {
            background: #f7f7f7;
        }

        .box-footer {
            border-top-left-radius: 0;
            border-top-right-radius: 0;
            border-bottom-right-radius: 3px;
            border-bottom-left-radius: 3px;
            border-top: 1px solid #f4f4f4;
            padding: 10px;
            background-color: #ffffff;
        }

        .box.box-solid.box-primary {
            border: 1px solid #043069;
        }

        .box {
            animation: none;
            position: relative;
            border-radius: 3px;
            background: #ffffff;
            border-top: 3px solid #d2d6de;
            margin-bottom: 20px;
            width: 100%;
            box-shadow: 0 1px 1px rgba(0, 0, 0, 0.1);
        }

            .box.box-solid.box-primary > .box-header {
                color: #ffffff;
                background: #043069;
            }

        .box-header.with-border {
            border-bottom: 1px solid #f4f4f4;
        }

        .box-header {
            color: #444;
            display: block;
            padding: 10px;
            position: relative;
        }

        .box-comments .box-comment::before, .box-comments .box-comment::after {
            content: " ";
            display: table;
        }

        .img-sm, .box-comments .box-comment img, .user-block.user-block-sm img {
            width: 30px !important;
            height: 30px !important;
        }

        .img-sm, .img-md, .img-lg, .box-comments .box-comment img, .user-block.user-block-sm img {
            float: left;
        }

        .box-comments .comment-text {
            margin-left: 40px;
            color: #555;
        }

        .box-comments .box-comment::after {
            clear: both;
        }

        .box-comments .box-comment::before, .box-comments .box-comment::after {
            content: " ";
            display: table;
        }

        .box-header::before {
            width: 10px;
            height: 10px;
            background: rgb(80, 255, 0) none repeat scroll 0% 0%;
            border-radius: 50%;
            display: inline-block;
            margin-right: 5px;
        }

        a, button {
            display: initial;
        }

        .box-comment {
            margin-bottom: 10px;
        }
    </style>
    <script src="/Scripts/jquery-3.4.1.min.js"></script>
    <script src="/Scripts/jquery.signalR-2.2.2.js"></script>
    <script src="/Scripts/date.format.js"></script>
    <script src="/signalr/hubs"></script>


    <script type="text/javascript">  



        $(function () {

            // Declare a proxy to reference the hub. 
            var chatHub = $.connection.chatHub;
            registerClientMethods(chatHub);
            // Start Hub
            $.connection.hub.start().done(function () {

                registerEvents(chatHub)

            });
            $(document).on('change', '#<%= FileUpload1.ClientID%>', function (e) {

                var tmppath = URL.createObjectURL(e.target.files[0]);
                $("#ImgDisp").attr('src', tmppath);

            });

        });

        function registerEvents(chatHub) {


            var name = '<%= this.UserName %>';
            var UserId = '<%= this.UserId %>';
            if (name.length > 0) {
                chatHub.server.connect(name,UserId);

            }


            $('#btnSendMsg').click(function () {

                var msg = $("#txtMessage").val();
                debugger;
                if (msg.length > 0) {

                    var userName = $('#hdUserName').val();

                    var date = GetCurrentDateTime(new Date());

                    chatHub.server.sendMessageToAll(userName, msg, date);
                    $("#txtMessage").val('');
                }
            });

            $("#txtMessage").keypress(function (e) {
                if (e.which == 13) {
                    $('#btnSendMsg').click();
                }
            });
        }

        function registerClientMethods(chatHub) {


            // Calls when user successfully logged in
            chatHub.client.onConnected = function (id, userName, allUsers, messages, times) {

                $('#hdId').val(id);
                $('#hdUserName').val(userName);
                $('#spanUser').html(userName);

                // Add All Users
                for (i = 0; i < allUsers.length; i++) {

                    AddUser(chatHub, allUsers[i].ConnectionId, allUsers[i].UserName, allUsers[i].UserImage, allUsers[i].LoginTime);
                }

                // Add Existing Messages
                for (i = 0; i < messages.length; i++) {
                    AddMessage(messages[i].UserName, messages[i].Message, messages[i].Time, messages[i].UserImage);

                }
            }

            // On New User Connected
            chatHub.client.onNewUserConnected = function (id, name, UserImage, loginDate) {
                AddUser(chatHub, id, name, UserImage, loginDate);
            }


            // On User Disconnected
            chatHub.client.onUserDisconnected = function (id, userName) {

                $('#Div' + id).remove();

                var ctrId = 'private_' + id;
                $('#' + ctrId).remove();


                var disc = $('<div class="disconnect">"' + userName + '" logged off.</div>');

                $(disc).hide();
                $('#divusers').prepend(disc);
                $(disc).fadeIn(200).delay(2000).fadeOut(200);

            }

            chatHub.client.messageReceived = function (userName, message, time, userimg) {

                AddMessage(userName, message, time, userimg);
            }


        }

        function GetCurrentDateTime(now) {

            var localdate = dateFormat(now, "dddd, mmmm dS, yyyy, h:MM:ss TT");

            return localdate;
        }

        function AddUser(chatHub, id, name, UserImage, date) {

            var userId = $('#hdId').val();

            var code = "";
            //var UserImage = GetUserImage(name);

            var Clist = "";
            if (userId == id) {

                code = $('<div class="box-comment">' +
                    '<img class="img-circle img-sm" src="' + UserImage + '"  alt="User Image" />' +
                    ' <div class="comment-text">' +
                    '<span class="username">' + name + '<span class="text-muted pull-right">' + date + '</span>  </span></div></div>');


                Clist = $(
                    '<li style="background:#494949;">' +
                    '<a href="#">' +
                    '<img class="contacts-list-img" src="' + UserImage + '"  alt="User Image" />' +

                    ' <div class="contacts-list-info">' +
                    ' <span class="contacts-list-name" id="' + id + '">' + name + ' <small class="contacts-list-date pull-right">' + date + '</small> </span>' +
                    ' <span class="contacts-list-msg">How have you been? I was...</span></div></a > </li >');

            }
            else {

                code = $('<div class="box-comment" id="Div' + id + '">' +
                    '<img class="img-circle img-sm" src="' + UserImage + '"  alt="User Image" />' +
                    ' <div class="comment-text">' +
                    '<span class="username">' + '<a id="' + id + '" class="user" >' + name + '<a>' + '<span class="text-muted pull-right">' + date + '</span>  </span></div></div>');


                Clist = $(
                    '<li>' +
                    '<a href="#">' +
                    '<img class="contacts-list-img" src="' + UserImage + '"  alt="User Image" />' +

                    ' <div class="contacts-list-info">' +
                    '<span class="contacts-list-name" id="' + id + '">' + name + ' <small class="contacts-list-date pull-right">' + date + '</small> </span>' +
                    ' <span class="contacts-list-msg">How have you been? I was...</span></div></a > </li >');

            }

            $("#divusers").append(code);

            $("#ContactList").append(Clist);

        }

        function AddMessage(userName, message, time, userimg) {

            var CurrUser = $('#hdUserName').val();
            var Side = 'right';
            var TimeSide = 'left';

            if (CurrUser == userName) {
                Side = 'left';
                TimeSide = 'right';

            }

            var divChat = '<div class="direct-chat-msg ' + Side + '">' +
                '<div class="direct-chat-info clearfix">' +
                '<span class="direct-chat-name pull-' + Side + '">' + userName + '</span>' +
                '<span class="direct-chat-timestamp pull-' + TimeSide + '"">' + time + '</span>' +
                '</div>' +

                ' <img class="direct-chat-img" src="images/DP/dummy.png" alt="User Image">' +
                ' <div class="direct-chat-text" >' + message + '</div> </div>';

            $('#divChatWindow').append(divChat);

            var height = $('#divChatWindow')[0].scrollHeight;
            $('#divChatWindow').scrollTop(height);

        }

    </script>
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <!-- Page Banner Section Start -->
    <div class="page-banner-section section" style="background-image: url(assets2/images/TitleBg.jpg)">
        <div class="container">
            <div class="row">
                <div class="page-banner-content col">
                    <h1>User Chat</h1>
                    <ul class="page-breadcrumb">
                        <li><a href="index.html">Requests</a></li>
                        <li><a href="my-account.html">User Chat</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Banner Section End -->

    <div class="page-section section section-padding">
        <div class="container">
            <div class="row">
                <div class="col-md-8">
                    <!-- DIRECT CHAT PRIMARY -->
                    <div class="direct-chat direct-chat-primary">
                        <div class="box-body">
                            <div class="box-body" id="chat-box">
                                <div id="divChatWindow" class="direct-chat-messages">
                                </div>
                            </div>
                        </div>
                        <!-- /.box-body -->
                        <div class="box-footer">
                            <textarea id="txtMessage" class="form-control"></textarea>
                            <div class="input-group" style="float: right;">
                                <input class="form-control" style="visibility: hidden;" />
                                <span class="input-group-btn">
                                    <input type="button" class="btn btn-primary btn-flat" id="btnSendMsg" value="Send" />
                                </span>
                            </div>
                        </div>
                        <!-- /.box-footer-->
                    </div>
                    <!--/.direct-chat -->
                </div>
                <div class="col-md-4">
                    <div class="box box-solid box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">Online Users <span id='UserCount'></span></h3>
                        </div>
                        <div class="box-footer box-comments" id="divusers">
                        </div>
                    </div>
                </div>
            </div>

            <span id="time"></span>
            <input id="hdId" type="hidden" />
            <input id="PWCount" type="hidden" value="info" />
            <input id="hdUserName" type="hidden" />

            <div class="modal fade" id="ChangePic" role="dialog">
                <div class="modal-dialog" style="width: 700px">
                    <div class="modal-content">
                        <div class="modal-header bg-light-blue-gradient with-border">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Change Profile Picture</h4>
                        </div>
                        <div class="modal-body">
                            <div class="container">

                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnChangePicModel" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <table class="table table-bordered table-striped table-hover table-responsive" style="width: 600px">
                                                    <tr>
                                                        <div class="col-md-12">
                                                            <td class="text-primary col-md-4" style="font-weight: bold;">
                                                                <img id="ImgDisp" src="<%= UserImage %>" class="user-image" style="height: 100px;" />
                                                            </td>
                                                            <td class="text-primary col-md-4" style="font-weight: bold;">
                                                                <asp:FileUpload ID="FileUpload1" runat="server" class="btn btn-default" />
                                                            </td>
                                                            <td class="col-md-4">
                                                                <asp:Button ID="btnChangePicModel" runat="server" Text="Update Picture" CssClass="btn btn-flat btn-success" OnClick="btnChangePicModel_Click" />
                                                            </td>
                                                        </div>
                                                    </tr>
                                                    <tr>
                                                        <div class="col-md-12">
                                                            <td class="col-md-12" colspan="4"></td>
                                                        </div>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <script src="Scripts/bootstrap.min.js"></script>


        </div>
    </div>

</asp:Content>

