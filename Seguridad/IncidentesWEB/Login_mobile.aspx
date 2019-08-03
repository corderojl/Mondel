<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_mobile.aspx.cs" Inherits="IncidentesWEB.Login_mobile" %>

<!DOCTYPE html>
<!--[if lt IE 7]> <html class="lt-ie9 lt-ie8 lt-ie7" lang="en"> <![endif]-->
<!--[if IE 7]> <html class="lt-ie9 lt-ie8" lang="en"> <![endif]-->
<!--[if IE 8]> <html class="lt-ie9" lang="en"> <![endif]-->
<!--[if gt IE 8]><!--> <html lang="en"> <!--<![endif]-->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login DMS</title>
      <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
  <link rel="stylesheet" href="css/style_mobile.css">
  <!--[if lt IE 9]><script src="scipts/html5.js"></script><![endif]-->
</head>
<body>
    <form id="form1" runat="server">
        <section class="container">
            <div class="login">
                <h1>Login DMS RTT</h1>
                <p>
                    <asp:TextBox ID="txtUsuario" runat="server" placeholder="Usuario"></asp:TextBox>
                </p>
                <p>
                    <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                </p>

                <p>
                    <asp:Button ID="btnLogin" runat="server" Text="Login" />&nbsp;
                </p>
            </div>
        </section>
    </form>
</body>
</html>
