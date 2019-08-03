<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Comportamiento/AdminMaster.Master" AutoEventWireup="true" CodeBehind="RegistrarComportamiento.aspx.cs" Inherits="IncidentesWEB.Comportamiento.RegistrarComportamiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../default.aspxpg.png" rel="shortcut icon" type="image/x-icon" />
    <link href="../css/reset.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />
    <link href="css/style_cms.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.core.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tablesorter.pager.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>

    <link href="Styles/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="Styles/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.ui.datepicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#ctl00_admin_cph_content_txtFecha").datepicker();
            $("#ctl00_admin_cph_content_txtFecha0").datepicker();
            $("#ctl00$admin_cph_content$txtFecha1").datepicker();
            $("#ctl00$admin_cph_content$txtFecha4").datepicker();
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
    <div id="contenido_form">
        <div id="panel" class="custom_form">
            <h2>Registro de Comportamiento</h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td align="right" width="75">Departamento:</td>
                            <td width="180">
                                <asp:DropDownList ID="ddlDepartamento" runat="server" AutoPostBack="True" CssClass="form_row" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" Width="200px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlDepartamento" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" width="75">Auditor:</td>
                            <td width="300">
                                <asp:DropDownList ID="ddlAuditor" runat="server" AutoPostBack="True" CssClass="form_row">
                                </asp:DropDownList>
                            </td>
                            <td align="right" width="75">&nbsp;</td>
                            <td width="300">&nbsp;</td>
                        </tr>

                        <tr>
                            <td align="right" width="75">Guardia:</td>
                            <td width="180">
                                <asp:DropDownList ID="ddlGuardia" runat="server" CssClass="form_row" Width="200px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlGuardia" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" width="75">Área:</td>
                            <td width="300">
                                <asp:DropDownList ID="ddlArea" runat="server" CssClass="form_row" Width="200px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlArea" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" width="75">Fecha:</td>
                            <td width="300">
                                <asp:TextBox ID="txtFecha" runat="server" CssClass="form_cal"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFecha" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                            </td>
                        </tr>

                    </table>
                    <asp:Literal ID="ltlTabla" runat="server"></asp:Literal>
                    <asp:Repeater ID="rpComportamiento" runat="server" >
                        <HeaderTemplate>
                            <table class='CSSTableGenerator'>
                                <tr>
                                    <td width="60px">Id</td>
                                    <td width="100px">Sistema</td>
                                    <td width="200px">Categoria</td>
                                    <td width="100px">Valor</td>
                                    <td width="200px">Descripción</td>
                                    <td width="100px">Emp.</td>
                                    <td width="100px"></td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lblComportamiento_id" Text='<%# DataBinder.Eval(Container.DataItem, "Comportamiento_id") %>' runat="server"/>
                                </td>
                                <td><%# DataBinder.Eval(Container.DataItem, "Formato_desc") %> </td>
                                <td><%# DataBinder.Eval(Container.DataItem, "SubCategoria_desc") %> </td>
                                <td><%# DataBinder.Eval(Container.DataItem, "Valor") %> </td>
                                <td><%# DataBinder.Eval(Container.DataItem, "Descripcion") %> </td>
                                <td><%# DataBinder.Eval(Container.DataItem, "Tipo_emp") %> </td>
                                <td style="text-align: center">
                                    <asp:ImageButton ID="ibnEliminar" runat="server" ImageUrl="~/Comportamiento/Images/btnEliminar.png"
                                        OnClick="ibnEliminar_Click" ToolTip="Eliminar Comportamiento" CausesValidation="False" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>
                    <tr valign="Center">
                        <td></td>
                        <td>
                            <asp:DropDownList ID="ddlFormato" runat="server" CssClass="form_row" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlFormato_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCategoria" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlSubCategoria" runat="server">
                            </asp:DropDownList>
                        </td>

                        <td>
                            <asp:DropDownList ID="ddlValor" runat="server" Height="30px" Width="60px">
                                <asp:ListItem Value="1">+</asp:ListItem>
                                <asp:ListItem Value="2">-</asp:ListItem>
                                <asp:ListItem Value="3">N/A</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td align="left">&nbsp;<asp:DropDownList ID="ddlTipoEmpleado" runat="server" Width="80px">
                            <asp:ListItem Value="1">J. Urco</asp:ListItem>
                            <asp:ListItem Value="2">Contratista</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td align="left">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Comportamiento/Images/btnGuardar.png"
                                OnClick="ImageButton1_Click" ToolTip="Guardar Comportamiento" />

                        </td>
                    </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
