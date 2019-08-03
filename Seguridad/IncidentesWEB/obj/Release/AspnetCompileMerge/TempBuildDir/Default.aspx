<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IncidentesWEB._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mondelez</title>
    <meta http-equiv="X-UA-Compatible" content="IE=100">
    <link href="../default.aspxpg.png" rel="shortcut icon" type="image/x-icon" />
    <link href="css/reset.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/acordion.css" rel="stylesheet" type="text/css" />
    <link href="Comportamiento/css/style_cms.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <link href="css/material-modal.css" rel="stylesheet" type="text/css"/>
    <script src="Scripts/material-modal.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            function close_accordion_section() {
                $('.accordion .accordion-section-title').removeClass('active');
                $('.accordion .accordion-section-content').slideUp(300).removeClass('open');
            }

            $('.accordion-section-title').click(function (e) {
                // Grab current anchor value
                var currentAttrValue = $(this).attr('href');

                if ($(e.target).is('.active')) {
                    close_accordion_section();
                } else {
                    close_accordion_section();

                    // Add active class to section title
                    $(this).addClass('active');
                    // Open up the hidden content panel
                    $('.accordion ' + currentAttrValue).slideDown(300).addClass('open');
                }

                e.preventDefault();
            });
        });
    </script>
    <script>
        var popUpWin = 0;
        function PopUp(URLStr, left, top, width, height) {
            if (popUpWin) {
                if (!popUpWin.closed) popUpWin.close();
            }
            popUpWin = open(URLStr, 'popUpWindows', 'toolbar=no,scrollbars=yes,location=no,directories=no,status=no,menubar=no,resizable=no,copyhistory=yes,width=' + width + ',height=' + height + ',left=' + left + ', top=' + top + ',screenX=' + left + ',screenY=' + top + '');
        }
        function OpenPopup() {
            window.open("actualizarpop.aspx" + URLStr, "Custom", "scrollbars=yes,resizable=no,menubar=no,status=no,toolbar=no,width=600,height=400");
            return false;
        }
        function Mensaje() {
            window.alert('El registro se actualizó con exito');
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="panel" class="custom_form">
            <div id="materialModal" onclick="closeMaterialAlert(event, false)" class="hide">
                <div id="materialModalCentered">
                    <div id="materialModalContent" onclick="event.stopPropagation()">
                        <div id="materialModalTitle">
                            <h2>Actualizar cuenta de intranet</h2>
                        </div>
                        <div id="materialModalText">
                            <table>
                                <tr>
                                    <td>Por favor ingrese su cuenta de intranet
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form_row"></asp:TextBox>(Ejemplo: urco.ju.1@mdlz.com)
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="materialModalButtons">
                            <div id="materialModalButtonOK" onclick="closeMaterialAlert(event, true)">
                                <asp:Button ID="btnActualizar" runat="server" Text="Aceptar" CssClass="btnlogin" Style="float: right; text-transform: uppercase; padding: 5px;" OnClick="btnActualizar_Click" />

                            </div>
                            <div id="materialModalButtonCANCEL" onclick="closeMaterialAlert(event, false)">
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div id="admin_container">

            <div id="header">
                <div id="top_nav">
                    <div id="logo_home">
                        <a href="../default.aspx"></a>
                    </div>

                    <div id="top_menu_titulo" class="">
                        <div class="titulo">
                            <img src="Images/titulo.jpg" height="60" />
                        </div>
                        <ul>
                            <li></li>
                        </ul>
                    </div>
                </div>
                <div id="top_tips">
                    <div id="tips">
                        <ul id="lista_tips">
                        </ul>
                        <ul id="lista_tips_Izq">
                            <li><span></span></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div id="contenido" class="cms">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table id="myTable" class="tablesorter">
                            <thead>
                                <tr>
                                    <th class="auto-style1">Bienvenido</th>
                                    <th class="auto-style1">Departamento</th>
                                    <th class="auto-style1">Rol</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlDepartamento" runat="server" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblRol" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table width="90%">
                            <tr>
                                <td>
                                    <table class="trigger">
                                        <tr>
                                            <td>
                                                <!--Trigger HS&E -->
                                            </td>
                                            <td>
                                                <!--Trigger QA-->
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <!--<asp:Label ID="lblTriggerHSE" runat="server" Text=""></asp:Label>-->
                                            </td>
                                            <td align="center">
                                                <!-- <h1><span class="gris">0</span></h1>-->
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="right">
                                    <table>
                                        <tr>
                                            <td align="center">Planes Pendientes
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <h1>
                                                    <span class="amarillo">
                                                        <a href="admin/">
                                                            <asp:Label ID="lblPlanPendiente" runat="server" Text=""></asp:Label>
                                                        </a>
                                                    </span>
                                                    <span class="rojo">
                                                        <asp:Label ID="lblPlanCaducado" runat="server" Text="0"></asp:Label></span>
                                                </h1>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="accordion">
                    <div class="accordion-sectix    on">
                        <a class="accordion-section-title" href="#accordion-1">Seguridad</a>
                        <div id="accordion-1" class="accordion-section-content" style="display: none;">
                            <ul id="navi">
                                <li><a href="admin/">Sistema de Registro HSE</a></li>
                                 <li><a href="Comportamiento/">Sistema de Comportamiento & Cultura</a></li>
                             <!--  <li><a href="Trigger/">Reporte de Trigger de HS&E</a></li>
                                <li><a href="Auditoria/">Auditorias</a></li>
                                <li><a href="ReporteSLT.aspx">Scorecard</a></li>-->
                            </ul>
                        </div>
                    </div>

                    <div class="accordion-section">
                        <a class="accordion-section-title" href="#accordion-2">Calidad</a>
                        <div id="accordion-2" class="accordion-section-content" style="display: none;">
                            <ul id="navi">
                                <li><a href="Alerta/">Sistema de Registro QA</a></li>
                                <!-- li><a href="../default.aspxcoas/admin/reportecoas.aspx" target="_blank">Web de COA's</a></li>
                                <li><a href="../default.aspxsop/admin/reportesop.aspx" target="_blank">Web de SOP's</a></li>-->
                            </ul>
                        </div>
                    </div>
                    <div class="accordion-section">
                        <a class="accordion-section-title" href="#accordion-3">RRHH</a>
                        <div id="accordion-3" class="accordion-section-content" style="display: none;">
                            <ul id="navi">
                                <li><a href="Indicadores/">Evaluación de Indicadores</a></li>

                            </ul>
                        </div>
                    </div>
                    <div class="accordion-section">
                        <a class="accordion-section-title" href="#accordion-4">Educación y Entrenamiento</a>
                        <div id="accordion-4" class="accordion-section-content" style="display: none;">
                            <ul id="navi">
                                <li><a href="LUPs/">Administrar LUP's</a></li>
                                <li><a href="http://plantail6s/SISTEMAS/RH/ET/Elearning/" target="_blank">ETool - Sistema de Entrenamientos</a></li>
                            </ul>
                        </div>
                        <!--end .accordion-section-content-->
                    </div>
                    <!--end .accordion-section-->
                </div>
                <!--<div style="width: 90%; margin: 0 auto; padding-top: 10px;">
                    <img src="Images/smallfondo_4.png" />
                </div>-->

            </div>

        <div id="footer">
            <div id="footer_copy">
                <div class="copy">
                    <span class="left">Copyright 2017. All rights reserved.</span> <span class="derecha">Powered by <a href="mailto:chefolc@gmail.com">chefolc@gmail.com</a></span>
                </div>
            </div>
        </div>
        </div>
    </form>
</body>
</html>
