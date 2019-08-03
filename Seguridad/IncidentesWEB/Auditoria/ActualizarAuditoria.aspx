<%@ Page Title="" Language="C#" MasterPageFile="~/Auditoria/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ActualizarAuditoria.aspx.cs" Inherits="IncidentesWEB.Auditoria.ActualizarAuditoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=100">
    <link href="../default.aspxpg.png" rel="shortcut icon" type="image/x-icon" />
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
            <h2>Registro de Auditoria</h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <table>
                <td align="right" width="80">Fecha:</td>
                <td width="300">
                    <asp:TextBox ID="txtFecha" runat="server" CssClass="form_cal"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtFecha" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                </td>
                </tr>
            </table>
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
                                <asp:DropDownList ID="ddlGuardia" runat="server" EnableViewState="True">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlGuardia" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="80">Operador:</td>
                            <td>
                                <asp:DropDownList ID="ddlOperador" runat="server" CssClass="form_row">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlOperador" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" width="80">Área.</td>
                            <td width="300">
                                <asp:DropDownList ID="ddlArea" runat="server" CssClass="form_row">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlArea" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="80">Auditoria:</td>
                            <td>
                                <asp:DropDownList ID="ddlAuditoria" runat="server" CssClass="form_row" Enabled="False">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlAuditoria" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                    </table>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <div id="divEspera" style="position: absolute; left: 0px; top: 0px; width: 90%; height: 100%; background-color: #ccc; opacity: 0.4; filter: alpha(opacity=40);">
                                <h1 style="position: absolute; left: 300px; top: 50px">Registrando Auditoria...</h1>
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
                                <td width="0%" style="display: none">Id Registro</td>
                                <td width="3%">Id</td>
                                <td width="15%">¿A quién Auditar?</td>
                                <td width="15%">¿Dondé Auditar?</td>
                                <td width="60%">Pregunta</td>
                                <td width="7%">Respuesta</td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td width="0%" style="display: none">
                                <asp:Label ID="lblAuditoria_id" Text='<%# DataBinder.Eval(Container.DataItem, "Registro_id") %>' runat="server" />
                            </td>
                            <td width="3%"><%# Container.ItemIndex+1 %></td>
                            <td width="15%"><%# DataBinder.Eval(Container.DataItem, "QuienAuditar_Desc") %> </td>
                            <td width="15%"><%# DataBinder.Eval(Container.DataItem, "Pregunta_donde") %> </td>
                            <td width="60%"><%# DataBinder.Eval(Container.DataItem, "Pregunta_desc") %> </td>
                            <td width="7%">
                                <asp:Label ID="lblEstado" Text='<%# DataBinder.Eval(Container.DataItem, "Valor") %>' runat="server" />
                                <asp:ImageButton ID="ibnActualizar" runat="server" ImageUrl="~/Trigger/Images/change.png"
                                    OnClick="ibnActualizar_Click" ToolTip="Cambiar Valor" CausesValidation="False" Width="25px" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tr>                            
                            <td></td>
                            <td></td>
                            <td></td>
                            <td style="text-align: right;">Nota</td>
                    </FooterTemplate>
                </asp:Repeater>
                <td>
                    <asp:Label ID="lblNota" runat="server" Text="Label"></asp:Label></td>
                </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        
        <table style="width: 100%">

            <tr>
                <td align="right" width="80"><h2><font color="red">Firma:</font></h2></td>
                <td>
                    <asp:CheckBox ID="chbFirma" runat="server" OnCheckedChanged="chbFirma_CheckedChanged" AutoPostBack="True" />
                    <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblFechaFirma" runat="server" Text="Label"></asp:Label>
                </td>
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
