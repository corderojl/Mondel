<%@ Page Title="" Language="C#" MasterPageFile="~/Trigger/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ActualizarTrigger.aspx.cs" Inherits="IncidentesWEB.Trigger.ActualizarTrigger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=100">
    <link href="http://materiales/pg.png" rel="shortcut icon" type="image/x-icon" />
    <link href="../css/reset.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />
    <link href="css/style_cms.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../Scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.alerts.js"></script>
    <link href="../css/jquery.alerts.css" rel="stylesheet" type="text/css" />

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

    <script type="text/javascript">
        $(document).ready(function () {
            $('#boton_jalert').click(function () {
                jAlert("Actualidad jQuery", "Actualidad jQuery");
            });
            $('#boton_jconfirm').click(function () {
                jConfirm("¿Te gusta Actualidad jQuery?", "Actualidad jQuery", function (r) {
                    if (r) {
                        jAlert("Te gusta Actualidad jQuery", "Actualidad jQuery");
                    } else {
                        jAlert("No te gusta Actualidad jQuery", "Actualidad jQuery");
                    }
                });
            });
            $('#boton_jprompt').click(function () {
                jPrompt("Introduce tu nombre", "", "Actualidad jQuery", function (r) {
                    if (r) {
                        jAlert("Tu nombre es " + r, "Actualidad jQuery");
                    }
                });
            });
        });
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
                    <table class="tableTrigger">
                        <tr>
                            <td align="right" width="100px">Departamento:</td>
                            <td width="35%">
                                <asp:DropDownList ID="ddlDepartamento" runat="server" AutoPostBack="True" CssClass="form_row" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlDepartamento" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" width="10%">Guardia:</td>
                            <td width="35%">
                                <asp:DropDownList ID="ddlGuardia" runat="server" CssClass="form_row">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlGuardia" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <h1>Últimos Incidentes:</h1>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Último incidente registrable de la Planta:</td>
                            <td width="60%">
                                <asp:TextBox ID="txtDescripcionRegistrable" runat="server" Width="90%" Height="50px" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                                <asp:RadioButtonList ID="rblTipoPersonal1" runat="server" RepeatDirection="Horizontal" Enabled="False">
                                    <asp:ListItem Selected="True" Value="1">P&amp;G</asp:ListItem>
                                    <asp:ListItem Value="2">Contratista</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td align="right">Fecha:
                            </td>
                            <td width="10%">
                                <asp:TextBox ID="txtFechaRegistrable" runat="server" Style="text-align: center" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="80px" align="right">Último incidente Clase 1 del Área:</td>
                            <td width="60%">
                                <asp:TextBox ID="txtDescripcionClaseI" runat="server" Width="90%" Height="50px" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                                <asp:RadioButtonList ID="rblTipoPersonal2" runat="server" RepeatDirection="Horizontal" Enabled="False">
                                    <asp:ListItem Value="1" Selected="True">P&amp;G</asp:ListItem>
                                    <asp:ListItem Value="2">Contratista</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td align="right">Fecha:
                            </td>
                            <td width="10%">
                                <asp:TextBox ID="txtFechaClaseI" runat="server" Style="text-align: center" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <h1>Comportamientos Inseguros (BOS/OFS):</h1>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Comp. crítico del día:</td>
                            <td>
                                <asp:TextBox ID="txtComp_crit_dia" runat="server" Height="30px" Width="90%" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtComp_crit_dia" Display="Dynamic" ErrorMessage="*" Font-Size="Large" Font-Bold="True"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right">Comp. crítico de la semana:</td>
                            <td width="300">
                                <asp:TextBox ID="txtComp_crit_sem" runat="server" Height="30px" Width="90%" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtComp_crit_sem" Display="Dynamic" ErrorMessage="*" Font-Size="Large" Font-Bold="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <div id="divEspera" style="position: absolute; left: 0px; top: 0px; width: 90%; height: 100%; background-color: #ccc; opacity: 0.4; filter: alpha(opacity=40);">
                                <h1 style="position: absolute; left: 300px; top: 50px">Registrando Trigger...</h1>
                                <img src="images/carga.gif" style="position: absolute; left: 40%; top: 40%; width: 20%; height: 20%" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <h1>Riesgos Potenciales de HS&E:</h1>
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
                                    OnClick="ibnActualizar_Click" ToolTip="Cambiar Valor" CausesValidation="False" Width="25px"/>
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
        <table class="tableTrigger">
            <tr>
                <td colspan="4">
                    <h1>Prueba Ácida:</h1>
                </td>
            </tr>
            <tr>
                <td align="right" width="80">Si ocurriera un incidente en el turno, ¿cómo y dónde sería?</td>
                <td>
                    <asp:TextBox ID="txtDondeSeria" runat="server" Height="30px" Width="90%" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtDondeSeria" Display="Dynamic" ErrorMessage="*" Font-Size="Large" Font-Bold="True"></asp:RequiredFieldValidator>
                </td>
                <td align="right" width="80">¿Completaste el seguimiento al trigger del turno anterior?</td>
                <td width="300">
                    <asp:RadioButtonList ID="rblCompletar" runat="server" RepeatDirection="Horizontal" Width="95px">
                        <asp:ListItem Selected="True" Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
        <table style="width: 100%">

            <tr>
                <td align="right" width="80">&nbsp;</td>
                <td>&nbsp;</td>
                <td align="right" width="80">&nbsp;</td>
                <td width="300" align="right">
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" Width="130px" OnClick="btnActualizar_Click" />
                </td>
            </tr>
        </table>
        <asp:Literal ID="ltlAlert" runat="server"></asp:Literal>
        <asp:Literal ID="ltrPlanes" runat="server"></asp:Literal>
    </div>
</asp:Content>
