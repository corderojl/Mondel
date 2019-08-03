<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanesPendientes.aspx.cs" Inherits="IncidentesWEB.admin.PlanesPendientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <h1>Planes pendientes:</h1>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Repeater ID="rpTrigger" runat="server">
                            <HeaderTemplate>
                                <table class='CSSTableGenerator'>
                                    <tr>
                                        <td width="60px" style="display: none">Id Riesgo</td>
                                        <td width="60px">Id</td>
                                        <td width="100px">Descripción</td>
                                        <td width="100px">Valor</td>
                                        <td width="100px">Valor</td>
                                        <td width="100px">Planes de Acción</td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td style="display: none">
                                        <asp:Label ID="lblTrigger_id" Text='<%# DataBinder.Eval(Container.DataItem, "Registro_id") %>' runat="server" />
                                    </td>
                                    <td><%# Container.ItemIndex+1 %></td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "Riesgo_desc") %> </td>
                                    <td>
                                        <asp:Label ID="lblEstado" Text='<%# DataBinder.Eval(Container.DataItem, "Estado") %>' runat="server" />
                                        <asp:ImageButton ID="ibnActualizar" runat="server" ImageUrl="~/Trigger/Images/change.png"
                                            OnClick="ibnActualizar_Click" ToolTip="Cambiar Valor" CausesValidation="False" Width="25px" />
                                    </td>
                                    <td style="text-align: center">
                                        <%# DataBinder.Eval(Container.DataItem, "Valor") %> 
                                    </td>
                                    <td style="text-align: center">
                                        <%# DataBinder.Eval(Container.DataItem, "VerPlanes") %> 
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
