﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Comportamiento/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ReporteComportamiento.aspx.cs" Inherits="IncidentesWEB.Comportamiento.ReporteComportamiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../default.aspxpg.png" rel="shortcut icon" type="image/x-icon" />
    <link href="../css/reset.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />
    <link href="css/style_cms.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.core.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tablesorter.pager.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>

    <link href="Styles/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="Styles/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.ui.datepicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#ctl00_admin_cph_content_txtFecha").datepicker();
            $("#ctl00_admin_cph_content_txtFecha0").datepicker();
            $("#ctl00$admin_cph_content$txtFecha1").datepicker();
            $("#ctl00$admin_cph_content$txtFecha4").datepicker();
        });
        jQuery(function ($) {
            $.datepicker.regional['es'] = {
                currentText: 'Hoy',
                monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
                dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
                dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
                dateFormat: 'dd/mm/yy',
                firstDay: 1,
                isRTL: false,
                showMonthAfterYear: false,
                yearSuffix: ''
            };
            $.datepicker.setDefaults($.datepicker.regional['es']);
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
            window.open("actualizarpop.aspx" + URLStr, "Custom", "scrollbars=yes,resizable=no,menubar=no,status=no,toolbar=no,width=300,height=200");
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_cph_content" runat="server">

    <div id="contenido" class="cms">
        <div id="formulario" class="custom_form">
            &nbsp;&nbsp;&nbsp;
            
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style="width: 100%;">
                        <tr>
                            <td>Area Labora:</td>
                            <td>
                                <asp:DropDownList ID="ddlSector" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSector_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>

                            <td>Departamento:</td>
                            <td>
                                <asp:DropDownList ID="ddlDepartamento" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>Área:</td>
                            <td>
                                <asp:DropDownList ID="ddlArea" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Auditor:</td>
                            <td>
                                <asp:DropDownList ID="ddlAuditor" runat="server">
                                    <asp:ListItem Selected="True" Value="%%">(Todos)</asp:ListItem>
                                    <asp:ListItem Value="1">Autonomo</asp:ListItem>
                                    <asp:ListItem Value="2">Progresivo</asp:ListItem>
                                    <asp:ListItem Value="3">Requiere Capital</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>Categoria:</td>
                            <td>
                                <asp:DropDownList ID="ddlSubCategoria" runat="server">
                                    <asp:ListItem Selected="True" Value="%%">(Todos)</asp:ListItem>
                                    <asp:ListItem Value="1">Mondelez</asp:ListItem>
                                    <asp:ListItem Value="2">Contratista</asp:ListItem>
                                </asp:DropDownList>

                            </td>
                            <td>Turno:</td>
                            <td>
                                <asp:DropDownList ID="ddlTurno" runat="server">
                                    <asp:ListItem Value="%%">(Todos)</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Tipo Empleado:</td>
                            <td>
                                <asp:DropDownList ID="ddlTipo_emp" runat="server">
                                    <asp:ListItem Selected="True" Value="%%">(Todos)</asp:ListItem>
                                    <asp:ListItem Value="1">Mondelez</asp:ListItem>
                                    <asp:ListItem Value="2">Contratista</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>Valor:</td>
                            <td>
                                <asp:DropDownList ID="ddlValor" runat="server">
                                    <asp:ListItem Value="%%">(Todos)</asp:ListItem>
                                    <asp:ListItem Value="1">+</asp:ListItem>
                                    <asp:ListItem Value="2">-</asp:ListItem>
                                    <asp:ListItem Value="3">No</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <table style="width: 95%;">
                <tr>
                    <td>
                        <asp:CheckBox ID="ckbInicio" runat="server" Text="Fecha de Reporte" Checked="True" />
                    </td>
                    <td>Desde:</td>

                    <td>
                        <asp:TextBox ID="txtFecha" runat="server" autocomplete="off" CssClass="form_cal"></asp:TextBox>
                    </td>
                    <td>Hasta:</td>
                    <td>

                        <asp:TextBox ID="txtFecha0" runat="server" autocomplete="off" CssClass="form_cal"></asp:TextBox>
                    </td>
                </tr>
                <!--
                <tr>
                    <td>
                        <asp:CheckBox ID="ckbCierre" runat="server" Text="Cierre:" />
                    </td>
                    <td>Desde:</td>
                    <td>

                        <asp:TextBox ID="txtFecha1" runat="server"  autocomplete="off" CssClass="form_cal"></asp:TextBox>
                    </td>
                    <td>Hasta:</td>
                    <td>

                        <asp:TextBox ID="txtFecha2" runat="server"  autocomplete="off" CssClass="form_cal"></asp:TextBox>
                    </td>
                </tr>
                -->
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" CssClass="botonB" />
                        <asp:Button ID="btnExportar" runat="server" Text="Exportar" OnClick="btnExportar_Click" CssClass="botonX" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="estadistica">
            <div id="subestadistica">
                <h3>Estadística Clasificación</h3>
                <br />
                <p>Comportamiento + :<asp:Label ID="lblValor1" runat="server" Text=""></asp:Label></p>
                <p>Comportamiento - :<asp:Label ID="lblValor2" runat="server" Text=""></asp:Label></p>
                <p>No Aplica  :<asp:Label ID="lblValor3" runat="server" Text=""></asp:Label></p>
            </div>
        </div>
        <div id="tabla">
            <asp:Literal ID="ltlResults" runat="server"></asp:Literal>
        </div>
    </div>

    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#myTable")
                .tablesorter({ widthFixed: true, widgets: ['zebra'] })
        }
    );
    </script>
</asp:Content>
