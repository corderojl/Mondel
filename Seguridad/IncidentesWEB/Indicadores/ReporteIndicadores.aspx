<%@ Page Title="" Language="C#" MasterPageFile="~/Indicadores/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ReporteIndicadores.aspx.cs" Inherits="IncidentesWEB.Indicadores.ReporteIndicadores" %>

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
    var popUpWin = 0;
        function PopUp(URLStr, left, top, width, height) {
            if (popUpWin) {
                if (!popUpWin.closed) popUpWin.close();
            }
            popUpWin = open(URLStr, 'popUpWindows', 'scrollbars=yes,location=no,directories=no,status=no,menubar=no,resizable=no,copyhistory=yes');
        }
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
                            <td>Empleado:</td>
                            <td>
                                <asp:DropDownList ID="ddlEmpleado" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>Categoria:</td>
                            <td>
                                <asp:DropDownList ID="ddlCategoria" runat="server" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>Subcategoria:</td>
                            <td>
                                <asp:DropDownList ID="ddlSubCategoria" runat="server">
                                    <asp:ListItem Selected="True" Value="%%">(Todos)</asp:ListItem>
                                    <asp:ListItem Value="1">Autonomo</asp:ListItem>
                                    <asp:ListItem Value="2">Progresivo</asp:ListItem>
                                    <asp:ListItem Value="3">Requiere Capital</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Evaluador:</td>
                            <td>
                                <asp:DropDownList ID="ddlLider" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>Departamento:</td>
                            <td>
                                <asp:DropDownList ID="ddlDepartamento" runat="server">
                                    
                                </asp:DropDownList>
                            </td>
                            <td>Area:</td>
                            <td>
                                <asp:DropDownList ID="ddlAreaLaboral" runat="server">
                                    <asp:ListItem Selected="True" Value="%%">(Todos)</asp:ListItem>
                                    <asp:ListItem Value="2017-%">2017</asp:ListItem>
                                    <asp:ListItem Value="2018-%">2018</asp:ListItem>
                                    <asp:ListItem Value="2019-%">2019</asp:ListItem>
                                    <asp:ListItem Value="2020-%">2020</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Año:</td>
                            <td>
                                <asp:DropDownList ID="ddlAnio" runat="server">
                                    <asp:ListItem Selected="True" Value="%%">(Todos)</asp:ListItem>
                                    <asp:ListItem Value="2017-%">2017</asp:ListItem>
                                    <asp:ListItem Value="2018-%">2018</asp:ListItem>
                                    <asp:ListItem Value="2019-%">2019</asp:ListItem>
                                    <asp:ListItem Value="2020-%">2020</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;Período:</td>
                            <td>
                                <asp:DropDownList ID="ddlTipo" runat="server">
                                    <asp:ListItem Selected="True" Value="%%">(Todo)</asp:ListItem>
                                    <asp:ListItem Value="1">Revisión Mitad de Año</asp:ListItem>
                                    <asp:ListItem Value="2">Revisión Fin de Año</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>Estado:</td>
                            <td>
                                <asp:DropDownList ID="ddlEstado" runat="server">
                                    <asp:ListItem Selected="True" Value="%%">(Todos)</asp:ListItem>
                                    <asp:ListItem Value="1">Incompleto</asp:ListItem>
                                    <asp:ListItem Value="2">Completo</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Clasificación:</td>
                            <td>
                                <asp:DropDownList ID="ddlClasificacion" runat="server">
                                    <asp:ListItem Selected="True" Value="%%">(Todos)</asp:ListItem>
                                    <asp:ListItem>Cumple Parcial</asp:ListItem>
                                    <asp:ListItem>Cumple Bien</asp:ListItem>
                                    <asp:ListItem>Sobresaliente</asp:ListItem>
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
                        <asp:Button ID="btnImprimir" runat="server" OnClick="btnImprimir_Click" Text="Imprimir" CssClass="botonPrint" />
                    </td>
                </tr>
            </table>
        </div>
        
        <div id="estadistica">
            <div id="subestadistica">
                <h3>Estadística Estado</h3>
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
