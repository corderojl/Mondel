<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActualizarNovedadesPop.aspx.cs" Inherits="IncidentesWEB.Novedades.ActualizarNovedadesPop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Actualizar Novedades</title>
    <meta http-equiv="X-UA-Compatible" content="IE=100">
    <link href="../default.aspxpg.png" rel="shortcut icon" type="image/x-icon" />
    <link href="../css/reset.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />
    <link href="css/style_cms.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.alerts.js"></script>
    <link href="../css/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script>
        var popUpWin = 0;
        function PopUp(URLStr, left, top, width, height) {
            if (popUpWin) {
                if (!popUpWin.closed) popUpWin.close();
            }
            popUpWin = open(URLStr, 'popUpWindows', 'toolbar=no,scrollbars=yes,location=no,directories=no,status=no,menubar=no,resizable=no,copyhistory=yes,width=' + width + ',height=' + height + ',left=' + left + ', top=' + top + ',screenX=' + left + ',screenY=' + top + '');
        }
        function OpenPopup() {
            window.open("actualizarpop.aspx" + URLStr, "Custom", "scrollbars=yes,resizable=no,menubar=no,status=no,toolbar=no,width=300,height=200");
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="contenido" class="cms">
            <div id="contenido_form" class="cms">
                <div id="panel" class="custom_form">

                    <h2>Actualizar Novedades:</h2>
                    <table>
                        <tbody>
                            <tr>
                                <td align="right" width="80">Titulo:</td>
                                <td align="left" width="180">
                                    <asp:TextBox ID="txtTitulo" runat="server"  Enabled="False"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFecha" Display="Dynamic" ErrorMessage="*" Font-Size="Large"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" width="80"></td>
                                <td align="left" width="180">
                                    &nbsp;</td>
                            </tr>
                            <tr valign="top">
                                <td align="right">Descripción:</td>
                                <td colspan="3" align="left">
                                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form_row" Height="74px" TextMode="MultiLine" Width="399px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtPlan" Font-Size="Large"></asp:RequiredFieldValidator>
                                </td>

                            </tr>
                            <tr valign="top">
                                <td align="right">Foto:</td>
                                <td colspan="3" align="left">
                                    <asp:FileUpload ID="fupFoto" runat="server" />
                                </td>

                            </tr>
                            <tr valign="top">
                                <td align="right">&nbsp;</td>
                                <td colspan="3" align="left">
                                    <asp:Image ID="imgFoto" runat="server" Height="191px" Width="286px" />
                                </td>

                            </tr>
                    </table>

                    <asp:Button ID="btnRegistrar" runat="server" Text="Guardar" OnClick="btnRegistrar_Click" />
                    <input type="button" value="Volver" name="volver" onclick="history.back()" />

                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" Visible="False" OnClientClick="return confirm('¿Deseas Eliminar el registro?')" />
                </div>
            </div>
    </form>
</body>
</html>
