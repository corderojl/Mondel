<%@ Page Title="" Language="C#" MasterPageFile="~/Auditoria/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdministrarAuditoria.aspx.cs" Inherits="IncidentesWEB.Auditoria.AdministrarAuditoria" %>

<%@ Import Namespace="IncidentesBE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_cph_content" runat="server">
    <div id="contenido_form" class="cms">
        <div id="panel" class="custom_form">
            <h2>Registro de Auditorias</h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlAuditoriaTipo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAuditoriaTipo_SelectedIndexChanged"></asp:DropDownList>
                    <div id="tabla>">
                        <asp:Repeater ID="rpPreguntaAuditoria" runat="server">
                            <HeaderTemplate>
                                <table class="tablesorter" id="myTable">
                                    <thead>
                                        <tr>
                                            <th style="display: none">Código</th>
                                            <th Width="3%">Id</th>
                                            <th Width="15%">¿Quíen?</th>
                                            <th Width="15%">¿Dónde?</th>
                                            <th Width="57%">Descripción</th>
                                            <th Width="10%">Operaciones</th>
                                        </tr>
                                    </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <td style="display: none">
                                            <asp:Label ID="lblPregunta_id" Text='<%# Eval("Pregunta_id") %>'  runat="server" />
                                        </td>
                                        <td>
                                            <%# Container.ItemIndex +1%>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblQuienAuditar_Desc" Text='<%# Eval("QuienAuditar_Desc") %>'  runat="server" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPregunta_donde" Text='<%# Eval("Pregunta_donde") %>'  runat="server" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Pregunta_desc" Text='<%# Eval("Pregunta_desc") %>' Width="95%" Height="35px" TextMode="MultiLine" runat="server" />
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
                            <td style="display: none"></td>
                            <td></td>
                            <td>
                                <asp:DropDownList ID="ddlQuienAudita" runat="server" Width="110px"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPregunta_donde" Width="90%" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtPreguntaDesc" Width="90%" runat="server" />
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
