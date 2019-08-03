<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EvaluacionAlertaPop.aspx.cs" Inherits="IncidentesWEB.Alerta.EvaluacionAlertaPop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Evaluación de Alertas</title>
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
                <h2>Evaluar Evento de Calidad</h2>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <table>
                    <tr>
                        <td align="right" width="80">N° de Alerta:</td>
                        <td width="220">
                            <asp:Label ID="lblAlerta_id" runat="server" CssClass="form_lab"></asp:Label>
                        </td>
                        <td align="right" width="80">Estado:</td>
                        <td width="300">
                            <asp:RadioButtonList ID="rblEstado" runat="server" RepeatDirection="Horizontal" Width="300px">
                                <asp:ListItem Value="2">Investigado</asp:ListItem>
                                <asp:ListItem Value="3">Solucionado</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="80" class="auto-style2">Fecha:</td>
                        <td width="220" class="auto-style2">
                            <asp:TextBox ID="txtFecha" runat="server" CssClass="form_cal"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFecha" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large"></asp:RequiredFieldValidator>

                        </td>
                        <td align="right" width="80" class="auto-style2">Originador:</td>
                        <td width="300" class="auto-style2">
                            <asp:DropDownList ID="ddlOriginador" runat="server" CssClass="form_row">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td align="right" width="80">Departamento:</td>
                                <td width="180">
                                    <asp:DropDownList ID="ddlDepartamento" runat="server" AutoPostBack="True" CssClass="form_row" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlDepartamento" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" width="80">Área   :</td>
                                <td width="300">
                                    <asp:DropDownList ID="ddlArea" runat="server" CssClass="form_row">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="ddlArea" InitialValue="0" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="80">Guardia:</td>
                                <td width="180">
                                    <asp:DropDownList ID="ddlGuardia" runat="server" CssClass="form_row">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlGuardia" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" width="80">&nbsp;</td>
                                <td width="300">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" width="80">Tipo de Evento:</td>
                                <td width="180">
                                    <asp:DropDownList ID="ddlSistemaQA" runat="server" AutoPostBack="True" CssClass="form_row" OnSelectedIndexChanged="ddlSistemaQA_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlSistemaQA" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" width="80"></td>
                                <td width="300">
                                    <asp:Label ID="lblSistemaQA_nom" runat="server" CssClass="form_lab" Width="200px" Visible="False">.</asp:Label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td align="right" width="80">Descripción breve:</td>
                                <td width="180" colspan="3">
                                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form_row" Height="109px" TextMode="MultiLine" Width="513px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtDescripcion" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="80">Clasificación:</td>
                                <td colspan="3" width="180">
                                    <asp:DropDownList ID="ddlClasificacion" runat="server" CssClass="form_row">
                                        <asp:ListItem Value="0">Seleccione una Opción</asp:ListItem>
                                        <asp:ListItem Value="1">Crítica</asp:ListItem>
                                        <asp:ListItem Value="2">No Crítica</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlClasificacion" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                                            </ContentTemplate>

                </asp:UpdatePanel>
                        <asp:Button ID="btnRegistrar" runat="server" Text="Actualizar" OnClick="btnRegistrar_Click" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Deseas Eliminar el registro?')"/>
                        <asp:Literal ID="ltlPlanInmediato" runat="server"></asp:Literal>
                        <asp:Literal ID="ltlPlanSistemico" runat="server"></asp:Literal>
                <asp:Label ID="lblMensaje" runat="server" Font-Size="16px" ForeColor="Red" Visible="False"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
