<%@ Page Title="" Language="C#" MasterPageFile="~/Novedades/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IncidentesWEB.Novedades.Default" %>

<%@ Import Namespace="IncidentesBE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=100">
    <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/tinymce.min.js"></script>
    <script>tinymce.init({ selector: 'textarea' });</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_cph_content" runat="server">
    <div id="contenido" class="cms">
        <div id="panel" class="custom_form">
            <h2>Registro de Novedades</h2>
            <table width="80%">
                <tr>
                    <td align="right" width="80px">Titulo:</td>
                    <td>
                        <asp:TextBox ID="txtTitulo" runat="server" Width="335px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtTitulo" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr valign="top">
                    <td align="right" width="80px">Descripción:</td>
                    <td>
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form_row" Height="109px" TextMode="MultiLine" Width="513px" ValidateRequestMode="Enabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="80">Subir Imagen:</td>
                    <td width="180">
                        <asp:FileUpload ID="FlpArchivo" runat="server" Width="335px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" width="80">
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="lblMensaje" runat="server" Font-Size="16px" ForeColor="Red" Visible="False"></asp:Label>
            <br />
                    </td>
                </tr>
                <tr>
                    <td align="right" width="80">
                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click"/>

                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <div id="tabla>">
                <asp:Repeater ID="rpNovedades" runat="server">
                    <HeaderTemplate>
                        <table class="tablesorter" id="myTable">
                            <thead>
                                <tr>
                                    <th width="5%">Código</th>
                                    <th style="display: none">Id</th>
                                    <th width="25%">Titulo</th>
                                    <th width="60%">Descripcion</th>
                                    <th width="5%">Foto</th>
                                    <th width="5%">Operaciones</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td style="display: none">
                                    <asp:Label ID="lblNovedades_id" Text="<%#((NOV_NovedadesBE)Container.DataItem).Novedades_id%>" runat="server" />
                                </td>
                                <td>
                                    <%# Container.ItemIndex +1%>
                                </td>
                                <td>
                                    <asp:Label ID="lblTitulo" Text="<%#((NOV_NovedadesBE)Container.DataItem).Titulo%>" runat="server" />
                                </td>
                                <td>
                                    <asp:Label ID="lblDescripcion" Text="<%#((NOV_NovedadesBE)Container.DataItem).Descripcion%>" runat="server" />
                                </td>
                                <td>
                                    <asp:Label ID="lblFoto" Text="<%#((NOV_NovedadesBE)Container.DataItem).Foto%>" runat="server" />
                                </td>

                                <td style="text-align: center">
                                   
                                    <asp:ImageButton ID="ibnEliminar" ImageUrl="~/Comportamiento/Images/btnEliminar.png" Width="30" Height="30" ToolTip="Eliminar Empleado"
                                        OnClientClick="return confirm('Seguro de eliminarlo');" OnClick="ibnEliminar_Click" runat="server" ValidateRequestMode="Disabled"/>

                                </td>
                            </tr>
                        </tbody>

                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>

            </div>

        </div>
    </div>
</asp:Content>
