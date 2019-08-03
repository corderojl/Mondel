<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActualizarDepartamento.aspx.cs" Inherits="IncidentesWEB.admin.ActualizarDepartamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Plan Sistémico</title>
    <meta http-equiv="X-UA-Compatible" content="IE=100">
    <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.alerts.js"></script>
    <link href="../css/jquery.alerts.css" rel="stylesheet" type="text/css" />

    <link href="css/style_cms.css" rel="stylesheet" type="text/css" />
    <link href="../css/reset.css" rel="stylesheet" type="text/css" />

    <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.core.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.widget.js" type="text/javascript"></script>
    <link href="Styles/jquery.ui.all.css" rel="stylesheet" type="text/css" />

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
        <div id="contenido_form" class="cms">
            <div id="panel" class="custom_form" >
                <div id="contenido_interna" class="resultados">
                    <br />
                    <table class="search_table">
                        <thead>
                            <th >Legajo </th>
                            <th style="width: 30%;">Apellidos y Nombres</th>
                            <th>Área</th>
                            <th>Turno </th>
                        </thead>
                        <tbody>
                        </tbody>
                        <td>
                            <asp:Label ID="lblLegajo" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblApellido" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDepartamento" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" Width="120px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlGuardia" runat="server" AutoPostBack="True" Width="120px">
                            </asp:DropDownList>
                        </td>
                    </table>
                    <br />
                    <asp:Literal ID="ltrMensaje" runat="server"></asp:Literal>
                    <br />
                    <br />
                    <div class="clear">


                        <asp:Button ID="btnCambiar" runat="server" Text="Cambiar" CssClass="search_btn" OnClick="btnCambiar_Click" />

                        <asp:Button ID="btnEliminar" runat="server" Text="Dar de baja" CssClass="search_btn" OnClick="btnEliminar_Click" Visible="False" OnClientClick="return confirm('¿Deseas Eliminar el registro?')"/>
                        <asp:Button ID="btnSearch0" runat="server" Text="Cancelar" CssClass="search_btn" />

                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
