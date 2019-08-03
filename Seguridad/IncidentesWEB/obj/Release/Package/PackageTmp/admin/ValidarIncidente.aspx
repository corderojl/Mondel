<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ValidarIncidente.aspx.cs" Inherits="IncidentesWEB.admin.ValidarIncidente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=100">
    <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.core.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.widget.js" type="text/javascript"></script>
    <link href="Styles/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="Styles/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.ui.datepicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#ctl00_admin_cph_content_txtFecha").datepicker();
            $("#ctl00_admin_cph_content_txtFecha0").datepicker();
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
    <style type="text/css">
        .form_row {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_cph_content" runat="server">
    <div id="contenido" class="cms">
        <div id="panel" class="custom_form">
            <h2>Registro de Incidentes</h2>
            <table>
                <tr>
                    <td align="right" width="80">Departamento:</td>
                    <td width="180">
                        <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="form_row">
                        </asp:DropDownList>
                    </td>
                    <td align="right" width="80">Responsable:</td>
                    <td width="180">
                        <asp:Label ID="Label1" runat="server" Text="Label" CssClass="form_lab"></asp:Label>
                    </td>
                </tr>
                </table>
            <h2>¿Qué?</h2>
            <table>
                <tr>
                    <td align="right" width="80">Titulo Corto:</td>
                    <td align="left" width="180">
                        <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox>
                    </td>
                    <td align="right" width="80">Originador:</td>
                    <td align="left" width="180">
                        <asp:Label ID="lblOriginador" runat="server" Text="Label" CssClass="form_lab"></asp:Label>
                    </td>
                </tr>
                <tr valign="top">
                    <td align="right">Descripción breve:</td>
                    <td colspan="3" align="left">
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form_row" Height="74px" TextMode="MultiLine" Width="399px"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td align="right">Estado:</td>
                    <td>
                        <asp:RadioButtonList ID="rblEstado" runat="server" RepeatDirection="Horizontal" Width="223px">
                            <asp:ListItem Selected="True" Value="1">Reportado</asp:ListItem>
                            <asp:ListItem Value="2">Investigado</asp:ListItem>
                            <asp:ListItem Value="3">Solucionado</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

            <h2>¿Cúando?</h2>
            <table>
                <tr>
                    <td align="right" width="120">Fecha del Incidente:</td>
                    <td width="190">
                        <asp:TextBox ID="txtFecha" runat="server" CssClass="form_cal"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFecha" Display="Dynamic" ErrorMessage="*" Font-Size="Large"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" width="120">Turno:</td>
                    <td width="190">
                        <asp:RadioButtonList ID="rblTurno" runat="server" RepeatDirection="Horizontal" Width="246px">
                            <asp:ListItem Selected="True" Value="1">1(11:00-06:59)</asp:ListItem>
                            <asp:ListItem Value="2">2(7:00-14:59)</asp:ListItem>
                            <asp:ListItem Value="3">3(03:00-10:59)</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right">Estatus Operacional:</td>
                    <td>
                        <asp:DropDownList ID="ddlEstatusOperacional" runat="server" CssClass="form_row">
                        </asp:DropDownList>
                    </td>
                    <td align="right">Horas Extras:</td>
                    <td>
                        <asp:RadioButtonList ID="rblTiempo" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="1">No</asp:ListItem>
                            <asp:ListItem Value="2">Si</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
            <h2>¿Dónde?</h2>
            <table>

                <tr>
                    <td align="right">Clasificación:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlClasificacion" runat="server" CssClass="form_row">
                        </asp:DropDownList>
                    </td>
                    <td align="right">Guardia:</td>
                    <td>
                        <asp:DropDownList ID="ddlGuardia" runat="server" CssClass="form_row">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">Localización:</td>
                    <td>
                        <asp:DropDownList ID="ddlArea" runat="server" CssClass="form_row">
                        </asp:DropDownList>
                    </td>
                    <td align="right">Rol:</td>
                    <td>
                        <asp:DropDownList ID="ddlRol" runat="server" CssClass="form_row">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">Tipo Personal:</td>
                    <td>
                        <asp:RadioButtonList ID="rblTipoPersonal" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="1">P&amp;G</asp:ListItem>
                            <asp:ListItem Value="2">Contratista</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td align="right">Emp. Contratista:</td>
                    <td>
                        <asp:DropDownList ID="ddlContratista" runat="server" CssClass="form_row">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">Tiempo en el Rol:</td>
                    <td>
                        <asp:DropDownList ID="ddlTiempoRol" runat="server" CssClass="form_row">
                            <asp:ListItem Value="0">N/A</asp:ListItem>
                            <asp:ListItem Value="1">0-3 Semana</asp:ListItem>
                            <asp:ListItem Value="3 ">1-5 Meses</asp:ListItem>
                            <asp:ListItem Value="4">6-11 Meses</asp:ListItem>
                            <asp:ListItem Value="5">1-4 Años</asp:ListItem>
                            <asp:ListItem Value="6">5-9 Años</asp:ListItem>
                            <asp:ListItem Value="7">10-19 Años</asp:ListItem>
                            <asp:ListItem Value="8">20+ Años</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">Tiempo en la Compañia:</td>
                    <td>
                        <asp:DropDownList ID="ddlTiempoCompania" runat="server" CssClass="form_row">
                            <asp:ListItem Value="0">N/A</asp:ListItem>
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
                </tr>
            </table>
            <h2>¿Quien?</h2>
            <table>
                <tr>
                    <td align="right">Parte del cuerpo:</td>
                    <td>
                        <asp:DropDownList ID="ddlParteCuerpo" runat="server" CssClass="form_row">
                        </asp:DropDownList>
                    </td>
                    <td align="right">Equipo afectado:</td>
                    <td>
                        <asp:DropDownList ID="ddlEquipoAfectado" runat="server" CssClass="form_row">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">Tipo de incidente:</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlTipoIncidente" runat="server" CssClass="form_row">
                            <asp:ListItem Value="0">Sin Daño</asp:ListItem>
                            <asp:ListItem Value="1">Daño a la Propiedad</asp:ListItem>
                            <asp:ListItem Value="2">Daño a la Persona</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
        </div>
    </div>
</asp:Content>
