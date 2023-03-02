<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StakeholderManagement.Login" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="Content/bootstrap.css" rel="Stylesheet" />
    <link href="Content/font-awesome.css" rel="Stylesheet" />
    <link href="Css/Login.css" rel="stylesheet" type="text/css" />

    <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/Login2.css" rel="stylesheet" />

    <title>HealthScore | Health & Fitness System</title>
    <link rel="shortcut icon" href="assets/images/logo2.png" />

    <script src="js/lib/jquery.min.js"></script>



</head>
<body class="loginbody">

    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <div class="login-form-style">
                        <div class="text-center">
                            <img src="assets/images/logo.png" />
                            <p class="main-title">Health Score</p>
                        </div>
                        <div>
                            <p class="title">Username</p>
                            <center>
                                <asp:TextBox ID="txtUsesName" runat="server" name="username" placeholder="Username" CssClass="username form-control font-italic shadow" required="" autofocus=""></asp:TextBox>
                            </center>
                        </div>

                        <div>
                            <p class="title">Password</p>
                            <center>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" name="password" CssClass="username form-control font-italic shadow" placeholder="Password" required=""></asp:TextBox>
                            </center>
                        </div>
                        <div>
                            <center>
                                <asp:Button ID="btnLogin" CssClass="btn-log" runat="server" OnClick="btnLogin_Click" Text="Login" />
                            </center>
                            <br />
                        </div>

                        <div class="row mt-3">
                            <div class="col-md-12 row-space text-center">
                                Don't Have an Account?  <a href="Registration.aspx">Sign Up</a>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 row-space text-center">
                                Forgot Password?   <a href="ForgetPassword.aspx">Click Here</a>
                            </div>
                        </div>


                    </div>
                </div>
                <div class="col-md-4"></div>
            </div>
        </div>
    </form>
</body>
</html>


