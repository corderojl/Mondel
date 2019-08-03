<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="RegistrarIncidente.aspx.cs" Inherits="IncidentesWEB.admin.RegistrarIncidente" %>

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
    <style type="text/css">
        .auto-style1 {
            width: 186px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_cph_content" runat="server">
    <div id="contenido" class="cms">
        <div id="panel" class="custom_form">
            <h2>Registro de Eventos HSE</h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td align="right" width="80">Área:</td>
                            <td width="180">
                                <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="form_row" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="ddlDepartamento" InitialValue="0" Font-Size="X-Large"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" width="80">Responsable:</td>
                            <td width="300">
                                <asp:Label ID="lblResponsable" runat="server" CssClass="form_lab"></asp:Label>
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
                                <asp:DropDownList ID="ddlEmpleado" runat="server" CssClass="form_row" Enabled="false">
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
                <tr>
                    <td align="right" width="80">Titulo Corto:</td>
                    <td align="left" width="180">
                        <asp:TextBox ID="txtTitulo" runat="server" Width="248px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtTitulo" Font-Size="X-Large"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr valign="top">
                    <td align="right">Descripción breve:</td>
                    <td align="left">
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form_row" Height="109px" TextMode="MultiLine" Width="513px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtDescripcion" Font-Size="X-Large"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">Causa Inmediata:</td>
                    <td align="left">
                         <asp:DropDownList ID="ddlCausaInmediata" runat="server" CssClass="form_row">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlCausaInmediata" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue="0"></asp:RequiredFieldValidator></td>
                </tr>
            </table>

            <h2>¿Cúando?</h2>
            <table>
                <tr>
                    <td align="right" width="120">Fecha del Incidente:</td>
                    <td width="190">
                        <asp:TextBox ID="txtFecha" runat="server" CssClass="form_cal"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFecha" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" width="120">Turno:</td>
                    <td width="200">
                        <asp:RadioButtonList ID="rblTurno" runat="server" RepeatDirection="Horizontal" Width="200px" Font-Size="16px">
                            <asp:ListItem Selected="True" Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right">Estatus Operacional:</td>
                    <td>
                        <asp:DropDownList ID="ddlEstatusOperacional" runat="server" CssClass="form_row">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="ddlEstatusOperacional" InitialValue="0" Font-Size="X-Large"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

            <h2>¿Quien?</h2>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td align="right">Tipo de daño:</td>
                            <td align="left">
                                <asp:DropDownList ID="ddlTipoIncidente" runat="server" CssClass="form_row" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoIncidente_SelectedIndexChanged">
                          
                                </asp:DropDownList>
                            </td>
                            <td>Daño:</td>
                            <td class="auto-style1">
                                <asp:DropDownList ID="ddlParteCuerpo" runat="server" CssClass="form_row">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">&nbsp;</td>
                            <td>
                               
                            </td>
                            <td align="right"></td>
                            <td class="auto-style1">
                                &nbsp;</td>
                        </tr>

                    </table>

                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <div id="divEspera" style="position: absolute; left: 0px; top: 0px; width: 100%; height: 100%; background-color: #ccc; opacity: 0.4; filter: alpha(opacity=40);">
                                <h1 style="position: absolute; left: 300px; top: 50px">Registrando Incidente...</h1>
                                <img src="images/carga.gif" style="position: absolute; left: 40%; top: 40%; width: 20%; height: 20%" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Label ID="lblMensaje" runat="server" Font-Size="16px" ForeColor="Red" Visible="False"></asp:Label>
        </div>
    </div>
</asp:Content>
