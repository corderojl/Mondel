<%@ Page Title="" Language="C#" MasterPageFile="~/Trigger/AdminMaster.Master" AutoEventWireup="true" CodeBehind="RegistrarTrigger.aspx.cs" Inherits="IncidentesWEB.Trigger.RegistrarTrigger" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_cph_content" runat="server">
    <div id="contenido" class="cms">
        <div id="formulario" class="custom_form">
            <h2>Registro de Trigger</h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
           
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style="width: 100%">
                        <tr>
                            <td align="right" width="80">Departamento:</td>
                            <td>
                                <asp:DropDownList ID="ddlDepartamento" runat="server" AutoPostBack="True" CssClass="form_row" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlDepartamento" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" width="80">Guardia:</td>
                            <td width="300">
                                <asp:DropDownList ID="ddlGuardia" runat="server" CssClass="form_row">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlGuardia" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <div id="divEspera" style="position: absolute; left: 0px; top: 0px; width: 90%; height: 100%; background-color: #ccc; opacity: 0.4; filter: alpha(opacity=40);">
                                <h1 style="position: absolute; left: 300px; top: 50px">Registrando Alerta...</h1>
                                <img src="images/carga.gif" style="position: absolute; left: 40%; top: 40%; width: 20%; height: 20%" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Label ID="lblMensaje" runat="server" Font-Size="16px" ForeColor="Red" Visible="False"></asp:Label>
        </div>
        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
    </div>
</asp:Content>
