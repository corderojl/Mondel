<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ReporteIncidente.aspx.cs" Inherits="IncidentesWEB.admin.ReporteIncidente" %>


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
                            <td>Departamento:</td>
                            <td>
                                <asp:DropDownList ID="ddlDepartamento" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>Guardia:</td>
                            <td>
                                <asp:DropDownList ID="ddlGuardia" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>Localizacion:</td>
                            <td>
                                <asp:DropDownList ID="ddlArea" runat="server">
                                    <asp:ListItem Selected="True" Value="%%">(Todos)</asp:ListItem>
                                    <asp:ListItem Value="1">Autonomo</asp:ListItem>
                                    <asp:ListItem Value="2">Progresivo</asp:ListItem>
                                    <asp:ListItem Value="3">Requiere Capital</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Clasificación:</td>
                            <td>
                                <asp:DropDownList ID="ddlClasificacion" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>Tipo Personal:</td>
                            <td>
                                <asp:DropDownList ID="ddlTipoPersonal" runat="server">
                                    <asp:ListItem Selected="True" Value="%%">(Todos)</asp:ListItem>
                                    <asp:ListItem Value="1">PG</asp:ListItem>
                                    <asp:ListItem Value="2">Contratista</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;Rol:</td>
                            <td>
                                <asp:DropDownList ID="ddlRol" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Tiempo en el Rol:</td>
                            <td>
                                <asp:DropDownList ID="ddlTiempoRol" runat="server">
                                    <asp:ListItem Selected="True" Value="%%">(Todos)</asp:ListItem>
                                    <asp:ListItem Value="1">0-3 Semana</asp:ListItem>
                                    <asp:ListItem Value="3 ">1-5 Meses</asp:ListItem>
                                    <asp:ListItem Value="4">6-11 Meses</asp:ListItem>
                                    <asp:ListItem Value="5">1-4 Años</asp:ListItem>
                                    <asp:ListItem Value="6">5-9 Años</asp:ListItem>
                                    <asp:ListItem Value="7">10-19 Años</asp:ListItem>
                                    <asp:ListItem Value="8">20+ Años</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>Tiempo en la Comp:</td>
                            <td>
                                <asp:DropDownList ID="ddlTiempoCompania" runat="server">
                                    <asp:ListItem Selected="True" Value="%%">(Todos)</asp:ListItem>
                                    <asp:ListItem Value="1">0-1 Semana</asp:ListItem>
                                    <asp:ListItem Value="2">2-3 Semana</asp:ListItem>
                                    <asp:ListItem Value="3">1-5 Meses</asp:ListItem>
                                    <asp:ListItem Value="4">6-11 Meses</asp:ListItem>
                                    <asp:ListItem Value="5">1-4 Años</asp:ListItem>
                                    <asp:ListItem Value="6">5-9 Años</asp:ListItem>
                                    <asp:ListItem Value="7">10-19 Años</asp:ListItem>
                                    <asp:ListItem Value="8">20+ Años</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>Turno:</td>
                            <td>
                                <asp:DropDownList ID="ddlTurno" runat="server">
                                    <asp:ListItem Selected="True" Value="%%">(Todos)</asp:ListItem>
                                    <asp:ListItem Value="1">1</asp:ListItem>
                                    <asp:ListItem Value="2">2</asp:ListItem>
                                    <asp:ListItem Value="3">3</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>

                    <table style="width: 100%;">
                        <tr>
                            <td>Estatus Operacional:</td>
                            <td>
                                <asp:DropDownList ID="ddlEstatusOperacional" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>Comportamiento involucrado:</td>
                            <td>
                                <asp:DropDownList ID="ddlComportamientoInv" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>Condición involucrada:</td>
                            <td>
                                <asp:DropDownList ID="ddlCondicionInv" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Causa inmediata:</td>
                            <td>
                                <asp:DropDownList ID="ddlCausaInmediata" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>Tecnología:</td>
                            <td>
                                <asp:DropDownList ID="ddlTecnologia" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>Sistema:</td>
                            <td>

                                <asp:DropDownList ID="ddlSistema" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Estado:</td>
                            <td>
                                <asp:DropDownList ID="ddlEstado" runat="server">
                                    <asp:ListItem Selected="True" Value="%%">(Todos)</asp:ListItem>
                                    <asp:ListItem Value="1">Reportado</asp:ListItem>
                                    <asp:ListItem Value="2">Investigado</asp:ListItem>
                                    <asp:ListItem Value="3">Solucionado</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <table style="width: 95%;">
                <tr>
                    <td>
                        <asp:CheckBox ID="ckbInicio" runat="server" Text="Fecha del Incidente:" Checked="True" />
                    </td>
                    <td>Desde:</td>

                    <td>
                        <asp:TextBox ID="txtFecha" runat="server"  autocomplete="off" CssClass="form_cal"></asp:TextBox>
                    </td>
                    <td>Hasta:</td>
                    <td>

                        <asp:TextBox ID="txtFecha0" runat="server"  autocomplete="off" CssClass="form_cal"></asp:TextBox>
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
                <asp:Literal ID="ltrEstadistica" runat="server"></asp:Literal>

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
