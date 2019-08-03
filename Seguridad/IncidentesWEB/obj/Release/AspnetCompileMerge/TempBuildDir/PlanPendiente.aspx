<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanPendiente.aspx.cs" Inherits="IncidentesWEB.PlanPendiente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Planes Pendientes</title>
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
                <h2>Planes Pendientes</h2>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <asp:Repeater ID="rpPlanAccion" runat="server">
                            <HeaderTemplate>
                                <table class='CSSTableGenerator' style="width: 100%;">
                                    <tr>
                                        <td width="60px">Id</td>
                                        <td width="400">Plan de Acción</td>
                                        <td width="100">Sistema</td>
                                        <td width="100">Id Sistema</td>
                                        <td width="100px">Fecha Planeada</td>
                                        <td width="100px">Fecha de Registro</td>
                                        <td width="100px"></td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblPlanAccion_id" Text='<%# DataBinder.Eval(Container.DataItem, "PlanAccion_id") %>' runat="server" />
                                    </td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "PlanAccion_desc") %> </td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "Sistema_desc") %> </td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "Registro_id") %> </td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "fecha") %> </td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "fecha_reg") %> </td>
                                    <td style="text-align: center">
                                        <asp:ImageButton ID="ibnCumplir" runat="server" ImageUrl="~/Comportamiento/Images/btnCerrar.png"
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
