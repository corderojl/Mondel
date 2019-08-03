<%@ Page Title="" Language="C#" MasterPageFile="~/Comportamiento/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IncidentesWEB.Comportamiento.Default" %>

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
                    <li><font face="Verdana, Arial, Helvetica, sans-serif" size="2"><a href="registrarComportamiento.aspx">Registrar Comportamiento</a></font></li>
                </ul>
                <h2>Reportes</h2>
                <ul>
                    <li><font face="Verdana, Arial, Helvetica, sans-serif" size="2"><a href="ReporteComportamiento.aspx">
                        Reporte General de Comportamientos</a></font></li>
                </ul>
               
                <h2>Administración</h2>
                <ul>
                    <li><font face="Verdana, Arial, Helvetica, sans-serif" size="2"><a href="registrarFormato.aspx">Administrar Formatos</a></font></li>
                </ul>
            </div>
        </div>
        <asp:Literal ID="ltlIncidentes" runat="server"></asp:Literal>
    </div>
</asp:Content>
