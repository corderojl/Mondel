<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActualizarPlanInmediato.aspx.cs" Inherits="IncidentesWEB.admin.ActualizarPlanInmediato" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Plan Inmediato</title>
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

                <h2>¿Qué?</h2>
                <table>
                    <tbody>
                        <tr>
                            <td align="right" width="80">Fecha:</td>
                            <td align="left" width="180">
                                <asp:TextBox ID="txtFecha" runat="server" CssClass="form_cal"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFecha" Display="Dynamic" ErrorMessage="*" Font-Size="Large"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" width="80">Responsable:</td>
                            <td align="left" width="180">
                                <asp:DropDownList ID="ddlResponsable" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr valign="top">
                            <td align="right">Plan de Accion:</td>
                            <td colspan="3" align="left">
                                <asp:TextBox ID="txtPlan" runat="server" CssClass="form_row" Height="74px" TextMode="MultiLine" Width="399px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtPlan" Font-Size="Large"></asp:RequiredFieldValidator>
                            </td>

                        </tr>
                        <tr valign="top">
                            <td align="right">Cumplido:</td>
                            <td colspan="3" align="left">
                                <asp:CheckBox ID="chbCumplido" runat="server" />
                            </td>

                        </tr>
                </table>

                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
            </div>
        </div>
    </form>
</body>
</html>
