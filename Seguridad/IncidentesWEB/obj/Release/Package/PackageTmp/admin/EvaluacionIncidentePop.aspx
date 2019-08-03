<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EvaluacionIncidentePop.aspx.cs" Inherits="IncidentesWEB.admin.EvaluacionIncidentePop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=100">
    <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.core.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.widget.js" type="text/javascript"></script>

    <link href="css/style_cms.css" rel="stylesheet" type="text/css" />
    <link href="../css/reset.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />

    <link href="Styles/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="Styles/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.ui.datepicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#txtFecha").datepicker();
            $("#txtFecha0").datepicker();
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
            popUpWin = open(URLStr, 'popUpEvaluacion', 'toolbar=no,scrollbars=yes,location=no,directories=no,status=no,menubar=no,resizable=no,copyhistory=yes,width=' + width + ',height=' + height + ',left=' + left + ', top=' + top + ',screenX=' + left + ',screenY=' + top + '');
        }
        function OpenPopup() {
            window.open("actualizarpop.aspx" + URLStr, "Custom", "scrollbars=yes,resizable=no,menubar=no,status=no,toolbar=no,width=600,height=400");
            return false;
        }
    </script>
    <script>
        function ActualizoExito() {
            alert("El registro se Actualizo con exito");
            opener.location.reload();
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="contenido" class="cms">
            <div id="panel" class="custom_form">
                <h2>Registro de Eventos HSE</h2>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td align="right" width="80">ID :</td>
                                <td width="180">
                                    <asp:Label ID="lblIncidente_id" runat="server" CssClass="form_lab" Font-Bold="True" Font-Size="16px" Text="Label"></asp:Label>
                                    <br />
                                </td>
                                <td>Estado:</td>
                                <td>
                                    <asp:RadioButtonList ID="rblEstado" runat="server" RepeatDirection="Horizontal" Width="300px" OnSelectedIndexChanged="rblEstado_SelectedIndexChanged">
                                        <asp:ListItem Value="1">Reportado</asp:ListItem>
                                        <asp:ListItem Value="2">Investigado</asp:ListItem>
                                        <asp:ListItem Value="3">Solucionado</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="80">Área:</td>
                                <td width="180">
                                    <asp:DropDownList ID="ddlDepartamento" runat="server" AutoPostBack="True" CssClass="form_row" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlDepartamento" Display="Dynamic" ErrorMessage="*" Font-Size="Large" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" width="80">Responsable:</td>
                                <td width="300">
                                    <asp:Label ID="lblResponsable" runat="server" CssClass="form_lab" Text="Label"></asp:Label>
                                </td>

                            </tr>
                        </table>
                        <h2>¿Dónde?</h2>
                        <table>
                            <tr>
                                <td align="right">Clasificación:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlClasificacion" runat="server" CssClass="form_row" AutoPostBack="True" OnSelectedIndexChanged="ddlClasificacion_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="ddlClasificacion" InitialValue="0" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">Empleado Afectado:</td>
                                <td>
                                    <asp:DropDownList ID="ddlEmpleado" runat="server" CssClass="form_row" Enabled="False">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Zona:</td>
                                <td>
                                    <asp:DropDownList ID="ddlArea" runat="server" CssClass="form_row">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="ddlArea" InitialValue="0" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Tipo Personal:</td>
                                <td>
                                    <asp:RadioButtonList ID="rblTipoPersonal" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rblTipoPersonal_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="1">Mondelez</asp:ListItem>
                                        <asp:ListItem Value="2">Contratista</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="right">Emp. Contratista:</td>
                                <td>
                                    <asp:DropDownList ID="ddlContratista" runat="server" CssClass="form_row" Enabled="False">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <h2>¿Qué?</h2>
                <table>
                    <tbody>
                        <tr>
                            <td align="right" width="80">Titulo Corto:</td>
                            <td align="left" width="180">
                                <asp:TextBox ID="txtTitulo" runat="server" Width="249px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtTitulo" Font-Size="Large"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" width="80">Originador:</td>
                            <td align="left" width="180">
                                <asp:Label ID="lblOriginador" runat="server" Text="Label" CssClass="form_lab"></asp:Label>
                            </td>
                        </tr>

                        <tr valign="top">
                            <td align="right">Descripción breve:</td>
                            <td colspan="3" align="left">
                                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form_row" Height="109px" TextMode="MultiLine" Width="513px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtDescripcion" Font-Size="Large"></asp:RequiredFieldValidator>
                            </td>

                        </tr>
                        <tr>
                            <td align="right">Causa Inmediata:</td>
                            <td align="left">
                                <asp:DropDownList ID="ddlCausaInmediata" runat="server" CssClass="form_row">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCausaInmediata" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue="0"></asp:RequiredFieldValidator></td>
                        </tr>
                </table>

                <h2>¿Cúando?</h2>
                <table>
                    <tbody>
                        <tr>
                            <td align="right" width="120">Fecha del Incidente:</td>
                            <td width="190">
                                <asp:TextBox ID="txtFecha" runat="server" CssClass="form_cal" Enabled="False"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFecha" Display="Dynamic" ErrorMessage="*" Font-Size="Large"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" class="auto-style1">Turno:</td>
                            <td width="190">
                                <asp:RadioButtonList ID="rblTurno" runat="server" RepeatDirection="Horizontal" Width="300px">
                                    <asp:ListItem Selected="True" Value="1">1(7:00-14:59)</asp:ListItem>
                                    <asp:ListItem Value="2">2(03:00-10:59)</asp:ListItem>
                                    <asp:ListItem Value="3">3(11:00-06:59)</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Estatus Operacional:</td>
                            <td>
                                <asp:DropDownList ID="ddlEstatusOperacional" runat="server" CssClass="form_row">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="ddlEstatusOperacional" InitialValue="0" Font-Size="Large"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" class="auto-style1"></td>
                            <td>&nbsp;</td>
                        </tr>
                </table>

                <h2>¿Quien?</h2>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table>
                            <table>
                                <tr>
                                    <td align="right">Tipo de daño:</td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlTipoIncidente" runat="server" CssClass="form_row" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoIncidente_SelectedIndexChanged">
                    
                                        </asp:DropDownList>
                                    </td>
                                    <td>Daño:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlParteCuerpo" runat="server" CssClass="form_row">
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                            </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <h2>Investigación:</h2>
                <table>
                    <tbody>
                        <tr>
                            <td align="right">WP Causa Raíz:</td>
                            <td>
                                <asp:DropDownList ID="ddlSistema" runat="server" CssClass="form_row">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="ddlSistema" InitialValue="0" Font-Size="Large"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right">Comportamiento Involucrado:</td>
                            <td>
                                <asp:DropDownList ID="ddlComportamientoInvolucrado" runat="server" CssClass="form_row">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="ddlComportamientoInvolucrado" InitialValue="0" Font-Size="Large"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Condición Involucrada:</td>
                            <td align="left">

                                <asp:DropDownList ID="ddlCondicionaInvolucrado" runat="server" CssClass="form_row">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="ddlCondicionaInvolucrado" InitialValue="0" Font-Size="Large"></asp:RequiredFieldValidator>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                </table>
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CausesValidation="False" OnClick="btnEliminar_Click" />
                <asp:Literal ID="ltlPlanInmediato" runat="server"></asp:Literal>
                <asp:Literal ID="ltlPlanSistemico" runat="server"></asp:Literal>
            </div>
        </div>
    </form>
</body>
</html>
