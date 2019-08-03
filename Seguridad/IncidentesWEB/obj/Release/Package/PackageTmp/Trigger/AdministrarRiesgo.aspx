<%@ Page Title="" Language="C#" MasterPageFile="~/Trigger/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdministrarRiesgo.aspx.cs" Inherits="IncidentesWEB.Trigger.AdministrarRiesgo" %>

<%@ Import Namespace="IncidentesBE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_cph_content" runat="server">
    <div id="contenido_form" class="cms">
        <div id="panel" class="custom_form">
            <h2>Registro de Sub-Categorias</h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlDepartamento" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged"></asp:DropDownList>
                    <div id="tabla>">
                        <asp:Repeater ID="rpSistemaQA" runat="server">
                            <HeaderTemplate>
                                <table class="tablesorter" id="myTable" style="width: 90% !important;">
                                    <thead>
                                        <tr>
                                            <th tyle="width: 40px;">Código</th>
                                            <th style="display: none">Id</th>
                                            <th>Descripcion</th>
                                            <th tyle="width: 40px;">Valor</th>
                                            <th tyle="width: 90px;">Operaciones</th>
                                        </tr>
                                    </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <td style="display: none">
                                            <asp:Label ID="lblRiesgo_id" Text="<%#((TRG_RiesgosBE)Container.DataItem).Riesgo_id%>" runat="server" />
                                        </td>
                                        <td>
                                            <%# Container.ItemIndex +1%>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRiesgo_desc" Text="<%#((TRG_RiesgosBE)Container.DataItem).Riesgo_desc%>" Width="90%" runat="server" />
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtValor" Text="<%#((TRG_RiesgosBE)Container.DataItem).Valor%>" Width="90%" runat="server" />
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
                            <td style="display: none"></td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="txtRiesgo" Width="90%" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtValor" Width="90%" runat="server" />
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
    </div>
</asp:Content>
