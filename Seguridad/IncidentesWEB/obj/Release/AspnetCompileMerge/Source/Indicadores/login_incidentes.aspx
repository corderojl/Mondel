<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login_incidentes.aspx.cs" Inherits="defectosView.comportamiento.controldefectos.login_defectos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mondelez</title>
    <meta http-equiv="X-UA-Compatible" content="IE=100">
    <link href="../default.aspxpg.png" rel="shortcut icon" type="image/x-icon" />
    <link href="../css/reset.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />
    <link href="css/style_cms.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="js/jscript_cms.js" type="text/javascript"></script>

</head>
<body>
 <form id="admin_login_form" runat="server">
    <div id="admin_container">
        <div id="header">
            <div id="top_nav">
                <div id="logo_home">
                    <a href="../default.aspx"></a>
                </div>
                <div id="top_menu">
                    <ul>
                        <li></li>
                    </ul>
                </div>
            </div>
            <div id="top_tips">
                <div id="tips">
                    <ul id="lista_tips">
                        <li><span>Sistema de Evaluación de Indicadores</span></li>
                    </ul>
                    <ul id="lista_tips_Izq">
                        <li><span></span></li>
                    </ul>
                </div>
            </div>
        </div>
        <div id="contenido" class="cms">
            <div id="login" class="custom_form">
                <div class="login_pag">
                    <label>
                        Nombre de Usuario</label>
                    <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario"
                        Display="Dynamic" ErrorMessage="Ingrese Usuario"></asp:RequiredFieldValidator>
                </div>
                <div class="login_pag">
                    <label>
                        Contraseña</label>
                    <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvContrasena" runat="server" ControlToValidate="txtContrasena"
                        Display="Dynamic" ErrorMessage="Ingrese Contraseña"></asp:RequiredFieldValidator>
                </div>
                <div class="submits">
                    <div class="login_pag">
                        
                        <asp:Button ID="btnlogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" CssClass="btnlogin" />
                    </div>
                    <div class="login_pag">
                        <asp:Label ID="lblMensaje" CssClass="lbl_mensaje" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div id="footer">
            <div id="footer_copy">
                <div class="copy">
                    <span class="left">Copyright 2017. All rights reserved.</span> <span class="derecha">
                        Powered by <a href="mailto:chefo@gmail.com">Support contact</a></span>
                </div>
            </div>
        </div>
    </div>
    </form>
</html>
