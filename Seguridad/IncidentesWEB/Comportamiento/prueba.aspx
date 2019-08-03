<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="prueba.aspx.cs" Inherits="IncidentesWEB.Comportamiento.prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
                            <td align="right" width="75">Fecha::</td>
                            <td width="300">
                                <asp:TextBox ID="txtFecha" runat="server" CssClass="form_cal"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFecha" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" width="75">&nbsp;</td>
                            <td width="300">&nbsp;</td>
                        </tr>

                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>

                    <asp:Literal ID="ltlTabla" runat="server"></asp:Literal>
                    <asp:Repeater ID="rpComportamiento" runat="server">
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
                                    <asp:Label ID="lblComportamiento_id" runat="server"><%# DataBinder.Eval(Container.DataItem, "Comportamiento_id") %></asp:Label>
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
                        <td class="auto-style1">
                            <asp:DropDownList ID="ddlCategoria" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlSubCategoria" runat="server">
                            </asp:DropDownList>
                        </td>

                        <td>
                            <asp:DropDownList ID="ddlValor" runat="server" Height="30px" Width="60px">
                                <asp:ListItem Value="1">+</asp:ListItem>
                                <asp:ListItem Value="2">-</asp:ListItem>
                                <asp:ListItem Value="3">No</asp:ListItem>
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
         
        </div>
    </form>
</body>
</html>
