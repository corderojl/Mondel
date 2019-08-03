<%@ Page Title="" Language="C#" MasterPageFile="~/LUPs/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ReporteLups.aspx.cs" Inherits="IncidentesWEB.LUPs.ReporteLups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="admin_cph_head" runat="server">
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
            &nbsp;&nbsp;&nbsp;
            
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style="width: 100%;">
                        <tr>
                            <td>Departamento:</td>
                            <td>
                                <asp:DropDownList ID="ddlDepartamento" runat="server" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td>Pilar:</td>
                            <td>
                             <asp:DropDownList ID="ddlPilar" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>Dueño:</td>
                            <td>
                                 <asp:DropDownList ID="ddlOriginador" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>                        
                        <tr>
                            <td>Guardia:</td>
                            <td>
                                <asp:DropDownList ID="ddlGuardia" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>Categoria:</td>
                            <td>
                               
                                <asp:DropDownList ID="ddlCategoria" runat="server">
                                </asp:DropDownList>
                               
                            </td>
                            <td>Estado:</td>
                            <td>
                                <asp:DropDownList ID="ddlEstado" runat="server">
                                    <asp:ListItem Selected="True" Value="%%">(Todos)</asp:ListItem>
                                    <asp:ListItem Value="1">Por Aprobar</asp:ListItem>
                                    <asp:ListItem Value="2">Aprobado</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Buscar:</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtPalabra" runat="server" Width="100%"></asp:TextBox>
                            </td>
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
                       <!-- <asp:CheckBox ID="ckbInicio" runat="server" Text="Fecha del Registro de LUP's" Checked="True" />-->
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

            <asp:Literal ID="ltlResults" runat="server"></asp:Literal>

    </div>

    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#myTable")
                .tablesorter({ widthFixed: true, widgets: ['zebra'] })
        }
    );
    </script>
</asp:Content>
