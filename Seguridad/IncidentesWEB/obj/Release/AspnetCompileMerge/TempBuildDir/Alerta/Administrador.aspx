<%@ Page Title="" Language="C#" MasterPageFile="~/Alerta/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="IncidentesWEB.Alerta.Administrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <h2>Administrador</h2>
                <ul>                    
                     <li><a href="#" onclick="PopUp('registrarCriticidad.aspx',20,20,950,678)"><font face="Verdana, Arial, Helvetica, sans-serif" size="2">Criticidad</font></a></li>
                     <li><a href="#" onclick="PopUp('../registrarDepartamento.aspx',20,20,950,678)"><font face="Verdana, Arial, Helvetica, sans-serif" size="2">Departamento</font></a></li>
                     <li><a href="#" onclick="PopUp('registrarEventoQA.aspx',20,20,950,678)"><font face="Verdana, Arial, Helvetica, sans-serif" size="2">Tipo de Evento QA</font></a></li>
                    <li><a href="#" onclick="PopUp('registrarGuardia.aspx',20,20,950,678)"><font face="Verdana, Arial, Helvetica, sans-serif" size="2">Guardia</font></a></li>
                </ul>

            </div>
        </div>


    </div>
</asp:Content>
