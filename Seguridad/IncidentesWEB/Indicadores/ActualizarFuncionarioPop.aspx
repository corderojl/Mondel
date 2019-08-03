<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActualizarFuncionarioPop.aspx.cs" Inherits="IncidentesWEB.Indicadores.ActualizarFuncionarioPop" %>

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
    <title></title>

    <script>
        function ActualizoExito() {
            alert("El registro se Actualizo con exito");
            opener.location.reload();
            window.close();
        }
        function CancelarExito() {
            window.close();
        }
        function confirmar()
        {
            if (!confirm('¿Esta seguro de restaurar la contraseña?'))
                return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="contenido" class="cms" style="width: 650px; min-height: 50px;">
            <div id="panel" class="custom_form">
                <h2>Actualizar Empleado</h2>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td align="right" width="80px">ID Empelado:</td>
                                <td>
                                    <asp:Label ID="lblIncidente_id" runat="server" CssClass="form_lab" Font-Bold="True" Font-Size="16px" Text="Label"></asp:Label>
                                    <br />
                                </td>
                                <td align="right" width="80px">Nombres:</td>
                                <td>
                                    <asp:TextBox ID="txtNombres" runat="server" Width="204px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlAreaLabor" Display="Dynamic" ErrorMessage="*" Font-Size="Large" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="80px">SHARP:</td>
                                <td>
                                    <asp:Label ID="lblSharp" runat="server" CssClass="form_lab" Font-Bold="True" Font-Size="16px" Text="Label"></asp:Label>
                                </td>
                                <td align="right" width="80px">Lider:</td>
                                <td width="300px">
                                    <asp:DropDownList ID="ddlLider" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlLider" Display="Dynamic" ErrorMessage="*" Font-Size="Large" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>

                            </tr>
                            <tr>
                                <td align="right" width="80px">Código:</td>
                                <td>
                                    <asp:TextBox ID="txtCodigo" runat="server" Width="120px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlAreaLabor" Display="Dynamic" ErrorMessage="*" Font-Size="Large" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" width="80px">CE. Coste:</td>
                                <td width="300px">
                                    <asp:TextBox ID="txtCoste" runat="server" Width="120px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="80px">Departamento:</td>
                                <td>
                                    <asp:DropDownList ID="ddlDepartamento" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlDepartamento" Display="Dynamic" ErrorMessage="*" Font-Size="Large" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" width="80px">E-mail:</td>
                                <td width="300px">
                                    <asp:TextBox ID="txtEmail" runat="server" Width="120px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="80px">Rol:</td>
                                <td>

                                    <asp:DropDownList ID="ddlRol" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlRol" Display="Dynamic" ErrorMessage="*" Font-Size="Large" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" width="80px">Area Labor:</td>
                                <td width="300px">
                                    <asp:DropDownList ID="ddlAreaLabor" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlAreaLabor" Display="Dynamic" ErrorMessage="*" Font-Size="Large" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="80px">Categoria:</td>
                                <td>
                                    <asp:DropDownList ID="ddlCategoria" runat="server" AutoPostBack="True" CssClass="form_row" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCategoria" Display="Dynamic" ErrorMessage="*" Font-Size="Large" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" width="80px">Sub-Categoria:</td>
                                <td width="300px">
                                    <asp:DropDownList ID="ddlSubCategoria" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlSubcategoria" Display="Dynamic" ErrorMessage="*" Font-Size="Large" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="80px">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="right" width="80px">Estado:</td>
                                <td width="300px">
                                    <asp:DropDownList ID="ddlEstado" runat="server">
                                        <asp:ListItem Value="1">Activo</asp:ListItem>
                                        <asp:ListItem Value="0">Baja</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="80px">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="right" width="80px">&nbsp;</td>
                                <td width="300px">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" width="80px">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="right" width="80px">&nbsp;</td>
                                <td width="300px">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" width="80px">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="right" width="80px">&nbsp;</td>
                                <td width="300px">
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <input id="btnCancelar" type="button" value="Cancelar" class="botonF" onclick="CancelarExito();" />
                <asp:Button ID="btnGuardar" runat="server" OnClick="Button2_Click" Text="Guardar" CssClass="botonF" />
                <asp:Button ID="btnRestaurar" runat="server" Text="Restaurar Contraseña" CssClass="botonF" OnClientClick="return confirmar();" OnClick="btnRestaurar_Click"/>
                </td>
            </div>
        </div>
    </form>
</body>
</html>
