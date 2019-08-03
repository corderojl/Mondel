<%@ Page Title="" Language="C#" MasterPageFile="~/Indicadores/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IncidentesWEB.Indicadores.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <link href="../css/material-modal.css" rel="stylesheet" />
    <script src="../Scripts/material-modal.js" type="text/javascript"></script>
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
    <script language="JavaScript">
        function comprobarPass() {
            var pw_usua = document.getElementById("txtPassword1");
            var pw_usua2 = document.getElementById("txtPassword1");

            if (pw_usua.value == pw_usua2.value) {
                document.miFormulario.submit()
            }
            else {
                form.pw_usua.value = "";
                form.pw_usua2.value = "";
                alert("Los Password no coinciden");
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_cph_content" runat="server">
    <div id="panel" class="custom_form">
        <div id="materialModal" onclick="closeMaterialAlert(event, false)" class="hide">
            <div id="materialModalCentered">
                <div id="materialModalContent" onclick="event.stopPropagation()">
                    <div id="materialModalTitle">
                        <h2>Cambio de Contraseña</h2>
                    </div>
                    <div id="materialModalText">
                        <table>
                            <tr>
                                <td>Por favor ingrese nueva contraseña:
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtPassword1" runat="server" CssClass="form_row" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword1" ErrorMessage="Dato es requerido"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>Repita la contraseña:
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtPassword2" runat="server" CssClass="form_row" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword2" ErrorMessage="Dato es requerido"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword2" ControlToValidate="txtPassword1" ErrorMessage="Las contraseñas no coinciden"></asp:CompareValidator>
                        </table>
                    </div>
                    <div id="materialModalButtons">
                        <div id="materialModalButtonCANCEL" onclick="closeMaterialAlert(event, false)">
                            <input id="Button1" type="button" value="CANCELAR"  Class="btnlogin" Style="float: right; text-transform: uppercase; padding: 5px;" />
                        </div>
                        <asp:Button ID="btnActualizar" runat="server" Text="Aceptar" CssClass="btnlogin" Style="float: right; text-transform: uppercase; padding: 5px;" OnClick="btnActualizar_Click" />
                        
                    </div>
                </div>
            </div>

        </div>
    </div>
    <div id="contenido" class="cms">
        <div id="formulario" class="custom_form">
            <div class="menu">
                <asp:Literal ID="ltlMenu" runat="server"></asp:Literal>
                
            </div>
        </div>
        <asp:Literal ID="ltlIncidentes" runat="server"></asp:Literal>
    </div>
</asp:Content>
