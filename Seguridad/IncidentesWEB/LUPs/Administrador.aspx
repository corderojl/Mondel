<%@ Page Title="" Language="C#" MasterPageFile="~/LUPs/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="IncidentesWEB.LUPs.Administrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="admin_cph_head" runat="server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_cph_content" runat="server">
    <div id="contenido" class="cms">
        <div id="formulario" class="custom_form">
            <div class="menu">
                <h2>Administrar</h2>
                <ul>
                    <li><a href="#" onclick="PopUp('../registrarDepartamento.aspx',20,20,950,650)"><font face="Verdana, Arial, Helvetica, sans-serif" size="2">Área</font></a></li>
                    <li><a href="#" onclick="PopUp('../Alerta/registrarGuardia.aspx',20,20,950,650)"><font face="Verdana, Arial, Helvetica, sans-serif" size="2">Guardia</font></a></li>
                    <li><a href="#" onclick="PopUp('registrarPilar.aspx',20,20,950,650)"><font face="Verdana, Arial, Helvetica, sans-serif" size="2">Pilar</font></a></li>
                    <li><a href="#" onclick="PopUp('../registrarResponsable.aspx',20,20,950,650)"><font face="Verdana, Arial, Helvetica, sans-serif" size="2">Responsable de Departamento</font></a></li>
                    <li><a href="#" onclick="PopUp('registrarResponsableCategoria.aspx',20,20,950,650)"><font face="Verdana, Arial, Helvetica, sans-serif" size="2">Responsable de Categoria</font></a></li>
                    <li><a href="#" onclick="PopUp('../registrarResponsablePilar.aspx',20,20,950,650)"><font face="Verdana, Arial, Helvetica, sans-serif" size="2">Responsable de Pilar</font></a></li>
                </ul>
                
            </div>
        </div>
    </div>
</asp:Content>
