<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrarDepartamento.aspx.cs" Inherits="IncidentesWEB.Comportamiento.registrarDepartamento" %>

<%@ Import Namespace="IncidentesBE" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="default.aspxpg.png" rel="shortcut icon" type="image/x-icon" />
    <link href="css/reset.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/popup.css" rel="stylesheet" type="text/css" />
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
                                            <th tyle="width: 5%;">Código</th>
                                            <th style="display:none">Id</th>
                                            <th tyle="width: 50%;">Descripcion</th>
                                            <th tyle="width: 10%;">Siglas</th>
                                            <th tyle="width: 25%;">Zona</th>
                                            <th tyle="width: 5%;">Operaciones</th>
                                        </tr>
                                            </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tbody>
                                    <tr>
                                        <td style="display:none">
                                            <asp:Label ID="lblSubCategoria_id" Text='<%# DataBinder.Eval(Container.DataItem, "Departamento_id") %>' runat="server" />
                                        </td>
                                        <td>
                                            <%# Container.ItemIndex +1%>
                                        </td>
                                        <td>
                                           <%# DataBinder.Eval(Container.DataItem, "Departamento_Desc") %> 
                                        </td>
                                        <td>
                                             <%# DataBinder.Eval(Container.DataItem, "Sigla") %> 
                                        </td>
                              <td>
                                             <%# DataBinder.Eval(Container.DataItem, "Sector_desc") %> 
                                        </td>
                                <td style="text-align: center">
                                   
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
                                            <asp:TextBox ID="txtDepartemento" Width="90%" runat="server" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDepartemento" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue=""></asp:RequiredFieldValidator>
                                        </td>
                                <td>
                                            <asp:TextBox ID="txtSsiglas" Width="90%" runat="server" />
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSsiglas" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue=""></asp:RequiredFieldValidator>
                                        </td>
                                <td>
                                    <asp:DropDownList ID="ddlSector" runat="server"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="ddlSector" InitialValue="0" Font-Size="X-Large"></asp:RequiredFieldValidator>
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
