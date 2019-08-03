<%@ Page Title="" Language="C#" MasterPageFile="~/Alerta/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IncidentesWEB.Alerta.Default" %>

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
                <h2>Opciones</h2>
                <ul>
                    <li><a href="registrarAlerta.aspx"><font face="Verdana, Arial, Helvetica, sans-serif" size="2">Registrar de Eventos QA</font></a></li>
                </ul>
                <h2>Reportes</h2>
                <ul>
                    
                    <li><a href="ReporteAlerta.aspx">
                        <font face="Verdana, Arial, Helvetica, sans-serif" size="2">Reporte General de Eventos QA</font></a></li>
                    <li><a href="ReportePlanAccion.aspx">
                        <font face="Verdana, Arial, Helvetica, sans-serif" size="2">Reporte General de Planes de Acción QA</font></a></li>
                </ul>
                
               
                    <asp:Label ID="lblAdministrador" runat="server" Visible="False"></asp:Label>
                
            </div>
        </div>
        <asp:Literal ID="ltlAlertas" runat="server"></asp:Literal>


    </div>
</asp:Content>
