<%@ Page Title="" Language="C#" MasterPageFile="~/Comportamiento/AdminMaster.Master" AutoEventWireup="true" CodeBehind="registrarFormato.aspx.cs" Inherits="IncidentesWEB.Comportamiento.registrarFormato" %>

<%@ Import Namespace="IncidentesBE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../default.aspxpg.png" rel="shortcut icon" type="image/x-icon" />
    <link href="../css/reset.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />
    <link href="css/style_cms.css" rel="stylesheet" type="text/css" />

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
                            <td>
                                <asp:DropDownList ID="ddlDepartamento" runat="server" AutoPostBack="True" CssClass="form_row" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" Width="200px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlDepartamento" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                            <td>Formato:</td>
                            <td>

                                <asp:DropDownList ID="ddlFormato" runat="server" AutoPostBack="True" CssClass="form_row" Width="200px" OnSelectedIndexChanged="ddlFormato_SelectedIndexChanged">
                                </asp:DropDownList>

                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <div id="tabla">
                            
                        <asp:Repeater ID="rpEmpleado" runat="server">
                            <HeaderTemplate>
                           
                                <table class="tablesorter" id="myTable">
                                    <thead>
                                        <tr>
                                            <th style="display:none">Código</th>
                                            <th>Id</th>
                                            <th>Descripcion</th>
                                            <th>Operaciones</th>
                                        </tr>
                                    </thead>
                            </HeaderTemplate>
                            
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <td style="display:none">
                                            <asp:Label ID="lblCategoria_id" Text="<%#((COM_CategoriasBE)Container.DataItem).Categoria_id%>" runat="server" />
                                        </td>
                                        <td>
                                            <%# Container.ItemIndex+1 %>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCategoria_desc" Text="<%#((COM_CategoriasBE)Container.DataItem).Categoria_desc%>" Width="90%" runat="server" />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:ImageButton ID="ibnActualizar" ImageUrl="~/Comportamiento/Images/guardar.png" Width="30" Height="30" ToolTip="Actualizar Empleado"
                                                OnClientClick="return validarActualizar(this);" OnClick="ibnActualizar_Click" runat="server" />&nbsp;&nbsp;
                                    <img src="Images/add.png" alt="" width="30" height="30"
                                        title="Abrir Sub-Categorias" style="cursor: pointer"
                                        onclick="PopUp('registrarSubCategorias.aspx?Categoria_id=<%#((COM_CategoriasBE)Container.DataItem).Categoria_id%>',20,20,800,400);" />
                                            <!--<asp:ImageButton ID="ibnEliminar" ImageUrl="~/Comportamiento/Images/btnEliminar.png" Width="30" Height="30" ToolTip="Eliminar Empleado" 
                                      OnClientClick="return confirm('Seguro de eliminarlo');" OnClick="ibnEliminar_Click" runat="server"/>-->
                                        </td>
                                    </tr>
                                </tbody>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
