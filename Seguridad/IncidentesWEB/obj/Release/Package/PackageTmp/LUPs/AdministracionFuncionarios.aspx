<%@ Page Title="" Language="C#" MasterPageFile="~/LUPs/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdministracionFuncionarios.aspx.cs" Inherits="IncidentesWEB.LUPs.AdministracionFuncionarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="admin_cph_head" runat="server">
    <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.core.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tablesorter.pager.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
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
            <h1>Administración de Empleados:</h1>
            &nbsp;&nbsp;&nbsp;
            
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style="width: 100%;">
                        <tr>
                            <td>Nombres:</td>
                            <td>
                                <asp:TextBox ID="txtFuncionarios" runat="server" Width="203px"></asp:TextBox>
                            </td>
                            <td>Categoria:</td>
                            <td>
                                <asp:DropDownList ID="ddlCategoria" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>Subcategoria</td>
                            <td>

                                <asp:DropDownList ID="ddlSubCategoria" runat="server">
                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td>Departamento:</td>
                            <td>
                                <asp:DropDownList ID="ddlDepartamento" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>Rol:</td>
                            <td>
                                <asp:DropDownList ID="ddlRol" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>Area Laboral:</td>
                            <td>
                                <asp:DropDownList ID="ddlAreaLaboral" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Lider:</td>
                            <td>
                                <asp:DropDownList ID="ddlLider" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>Estado:</td>
                            <td>
                                <asp:DropDownList ID="ddlEstado" runat="server">
                                    <asp:ListItem Value="%%">(Todos)</asp:ListItem>
                                    <asp:ListItem Value="1">Activo</asp:ListItem>
                                    <asp:ListItem Value="0">Baja</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                             
                            </td>
                        </tr>
                    </table>
                    
                         
                </ContentTemplate>
            </asp:UpdatePanel>
               <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="botonAdd" OnClientClick="PopUp('RegistrarFuncionarioPop.aspx?Funcionario_id=1012',20,20,850,500); return false;"/>
               <asp:Button ID="btnBuscar" runat="server" CssClass="botonB" OnClick="btnBuscar_Click" Text="Buscar" />
            <div id="tabla">
                        <asp:Literal ID="ltlResults" runat="server"></asp:Literal>
                    </div>
        </div>
    </div>
       <script language="javascript" type="text/javascript">
           $(document).ready(function () {
               $("#myTable")
                   .tablesorter({ widthFixed: true, widgets: ['zebra'] })
           }
       );
    </script>
</asp:Content>

