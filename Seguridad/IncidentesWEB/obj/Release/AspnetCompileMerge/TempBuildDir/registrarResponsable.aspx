<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrarResponsable.aspx.cs" Inherits="IncidentesWEB.registrarResponsable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administrar Responsables</title>
    <link href="../mondelez.png" rel="shortcut icon" type="image/x-icon" />
    <link href="css/reset.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/custom_inputs.css" rel="stylesheet" type="text/css" />
    <link href="Comportamiento/css/style_cms.css" rel="stylesheet" type="text/css" />

    <script src="Comportamiento/Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
       <link href="css/jquery.alerts.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../Scripts/jquery.alerts.js"></script>
    <script>
        function ActualizoExito() {
            alert("El registro se Actualizo con exito");
            opener.location.reload();
            window.close();
        }
    </script>
   
</head>
<body>
    <form id="form1" runat="server">
        <div id="contenido" class="cms">
            <div id="panel" class="custom_form">
                <h2>Administrar Responsables de Departamento</h2>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <table class='CSSTableGenerator' style="width: 100%;">
                    <tr>
                    <td>
                        <asp:DropDownList ID="ddlDepartamento" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlDepartamento" Display="Dynamic" ErrorMessage="*" Font-Size="Large" InitialValue="0"></asp:RequiredFieldValidator>
                    </td>
                        <td>
                            <asp:DropDownList ID="ddlEmpleado" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlEmpleado" Display="Dynamic" ErrorMessage="*" Font-Size="Large" InitialValue="0"></asp:RequiredFieldValidator>
                    </td>
                        <td>
                            <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click"  ImageUrl="~/Comportamiento/Images/btnGuardar.png"
                                  ToolTip="Cumplir Plan de Acción"/>
                    </td>
                        </tr>
                    </table>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Repeater ID="rpPlanAccion" runat="server">
                            <HeaderTemplate>
                                <table class='CSSTableGenerator' style="width: 100%;">
                                    <tr>
                                        <td width="60px" style="display:none">Id Dep</td>
                                        <td width="60px" style="display:none">Id Emp</td>
                                        <td width="100">Departamento</td>
                                        <td width="400">Responsable</td>                                        
                                        <td width="100px"></td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td style="display:none">
                                        <asp:Label ID="lblDepartamento_id" Text='<%# DataBinder.Eval(Container.DataItem, "Departamento_id") %>' runat="server" />
                                    </td>
                                    <td style="display:none">
                                        <asp:Label ID="lblFuncionario_id" Text='<%# DataBinder.Eval(Container.DataItem, "Funcionario_id") %>' runat="server" />
                                    </td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "Departamento_desc") %> </td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "funcionario_nome") %> </td>
                                    <td style="text-align: center">
                                        <asp:ImageButton ID="ibnCumplir" runat="server" ImageUrl="~/Comportamiento/Images/btnEliminar.png"
                                            OnClick="ibnCumplir_Click" ToolTip="Cumplir Plan de Acción" CausesValidation="False" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <br />
            <br />
            <div style="display: block; width: 94%; position: relative; text-align: -webkit-right; top: 0px; left: 0px;">
                <asp:Button ID="btnSalir" runat="server" Height="28px" OnClick="btnSalir_Click" Text="Salir" Width="104px" />
            </div>
        </div>
    </form>
</body>
</html>
