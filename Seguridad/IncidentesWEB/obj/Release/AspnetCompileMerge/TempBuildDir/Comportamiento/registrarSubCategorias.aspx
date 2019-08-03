<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrarSubCategorias.aspx.cs" Inherits="IncidentesWEB.Comportamiento.registrarSubCategorias" %>

<%@ Import Namespace="IncidentesBE" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../default.aspxpg.png" rel="shortcut icon" type="image/x-icon" />
    <link href="../css/reset.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />
    <link href="css/style_cms.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="contenido_form" class="cms">
            <div id="panel" class="custom_form">
                <h2>Registro de Sub-Categorias</h2>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div id="tabla>">
                            <asp:Repeater ID="rpEmpleado" runat="server">
                                <HeaderTemplate>
                                    <table class="tablesorter" id="myTable">
                                        <thead>
                                        <tr>
                                            <th>Código</th>
                                            <th style="display:none">Id</th>
                                            <th>Descripcion</th>
                                            <th>Operaciones</th>
                                        </tr>
                                            </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tbody>
                                    <tr>
                                        <td style="display:none">
                                            <asp:Label ID="lblSubCategoria_id" Text="<%#((COM_SubCategoriasBE)Container.DataItem).SubCategoria_id%>" runat="server" />
                                        </td>
                                        <td>
                                            <%# Container.ItemIndex +1%>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSubCategoria_desc" Text="<%#((COM_SubCategoriasBE)Container.DataItem).SubCategoria_desc%>" Width="90%" runat="server" />
                                        </td>

                                        </td>
                                <td style="text-align: center">
                                    <asp:ImageButton ID="ibnActualizar" ImageUrl="~/Comportamiento/Images/Guardar.png" Width="30" Height="30" ToolTip="Actualizar Empleado"
                                        OnClientClick="return validarActualizar(this);" OnClick="ibnActualizar_Click" runat="server" />&nbsp;&nbsp;
                                    <asp:ImageButton ID="ibnEliminar" ImageUrl="~/Comportamiento/Images/btnEliminar.png" Width="30" Height="30" ToolTip="Eliminar Empleado"
                                        OnClientClick="return confirm('Seguro de eliminarlo');" OnClick="ibnEliminar_Click" runat="server" />

                                </td>
                                    </tr>

                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:Repeater>
                            <tr>
                                        <td style="display:none">
                                           
                                        </td>
                                        <td>
                                            
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSubCategoria" Width="90%" runat="server" />
                                        </td>


                                        </td>
                                <td style="text-align: center">
                                    <asp:ImageButton ID="ibnGuardar" ImageUrl="~/Comportamiento/Images/btnGuardar.png" Width="30" Height="30" ToolTip="Agregar"
                                        OnClick="ibnGuardar_Click" runat="server" />

                                </td>
                                    </tr>
                                    </tbody>
                                    </table>
                        </div>
                        <asp:Label ID="lblMensaje" runat="server" Font-Names="Britannic Bold" Font-Size="12px" ForeColor="Red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
    </form>
</body>
</html>
