<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarFuncionarioPop.aspx.cs" Inherits="IncidentesWEB.LUPs.RegistrarFuncionarioPop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.core.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.widget.js" type="text/javascript"></script>


    <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />
    <link href="css/style_cms.css" rel="stylesheet" type="text/css" />
    <link href="../css/reset.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />

    <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />
    <link href="../Comportamiento/css/style_cms.css" rel="stylesheet" />
    <link href="Styles/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="Styles/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.ui.datepicker.js" type="text/javascript"></script>
    <title></title>

    <script>
        function ActualizoExito() {
            alert("El registro se Actualizo con exito");
            opener.location.reload();
            window.close();
        }
    </script>
    <script type="text/javascript">
        function getConfirmation() {
            return window.confirm("¿Seguro de eliminar aprobador?");
        }
        $(function () {
            $("#txtFechaIngreso").datepicker();
            $("#txtFechaNacimiento").datepicker();
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
</head>
<body>
    <form id="form1" runat="server">
        <div id="contenido" class="cms" style="width: 730px; min-height: 50px;">
            <div id="panel" class="custom_form">
                <h2>Actualizar Empleado</h2>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <script type="text/javascript">
                    Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
                        $("#txtFechaIngreso").datepicker();
                        $("#txtFechaNacimiento").datepicker();
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
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td align="right" width="15%">Nombres:</td>
                                <td>
                                    <asp:TextBox ID="txtNombres" runat="server" Width="204px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlAreaLabor" Display="Dynamic" ErrorMessage="*" Font-Size="Large" InitialValue="0"></asp:RequiredFieldValidator>
                                    <br />
                                </td>
                                <td align="right" width="15%">Lider:</td>
                                <td>
                                    <asp:DropDownList ID="ddlLider" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="15%">SHARP:</td>
                                <td>
                                    <asp:TextBox ID="txtSharp" runat="server" Width="120px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtSharp" Display="Dynamic" ErrorMessage="*" Font-Size="Large" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" width="15%">CE. Coste:</td>
                                <td width="35%">
                                    <asp:TextBox ID="txtCoste" runat="server" Width="120px"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td align="right" width="15%">Código:</td>
                                <td>
                                    <asp:TextBox ID="txtCodigo" runat="server" Width="120px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtCodigo" Display="Dynamic" ErrorMessage="*" Font-Size="Large" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" width="15%">E-mail:</td>
                                <td width="35%">
                                    <asp:TextBox ID="txtEmail" runat="server" Width="120px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="15%">Departamento:</td>
                                <td>
                                    <asp:DropDownList ID="ddlDepartamento" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlDepartamento" Display="Dynamic" ErrorMessage="*" Font-Size="Large" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" width="15%">Guardia:</td>
                                <td width="35%">
                                    <asp:DropDownList ID="ddlGuardia" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlGuardia" Display="Dynamic" ErrorMessage="*" Font-Size="Large" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="15%">Rol:</td>
                                <td>

                                    <asp:DropDownList ID="ddlRol" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlRol" Display="Dynamic" ErrorMessage="*" Font-Size="Large" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" width="15%">Area Labor:</td>
                                <td width="35%">
                                    <asp:DropDownList ID="ddlAreaLabor" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlAreaLabor" Display="Dynamic" ErrorMessage="*" Font-Size="Large" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="15%">Categoria:</td>
                                <td>
                                    <asp:DropDownList ID="ddlCategoria" runat="server" AutoPostBack="True" CssClass="form_row" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCategoria" Display="Dynamic" ErrorMessage="*" Font-Size="Large" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" width="15%">Sub-Categoria:</td>
                                <td width="35%">
                                    <asp:DropDownList ID="ddlSubCategoria" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlSubcategoria" Display="Dynamic" ErrorMessage="*" Font-Size="Large" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="15%">Fech. Ingreso</td>
                                <td>
                                    <asp:TextBox ID="txtFechaIngreso" runat="server" CssClass="form_cal"></asp:TextBox>
                                </td>
                                <td align="right" width="15%">Fech. Nacimiento</td>
                                <td width="35%">
                                    <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form_cal"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="15%">Genero:</td>
                                <td>
                                    <asp:RadioButtonList ID="rblEstado" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">Masculino</asp:ListItem>
                                        <asp:ListItem Value="2">Femenino</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="right" width="15%">Estado:</td>
                                <td width="35%">
                                    <asp:DropDownList ID="ddlEstado" runat="server">
                                        <asp:ListItem Value="1">Activo</asp:ListItem>
                                        <asp:ListItem Value="0">Baja</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="botonF" />
                <asp:Button ID="btnGuardar" runat="server" OnClick="Button2_Click" Text="Guardar" CssClass="botonF" />

            </div>
        </div>
    </form>
</body>
</html>
