<%@ Page Title="" Language="C#" MasterPageFile="~/Indicadores/AdminMaster.Master" AutoEventWireup="true" CodeBehind="RegistrarEvaluacion.aspx.cs" Inherits="IncidentesWEB.Indicadores.RegistrarEvaluacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.core.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.widget.js" type="text/javascript"></script>
    <link href="Styles/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="Styles/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.ui.datepicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#ctl00_admin_cph_content_txtFecha").datepicker();
            $("#ctl00_admin_cph_content_txtFecha0").datepicker();
        });
        jQuery(function ($) {
            $.datepicker.regional['es'] = {
                currentText: 'Hoy',
                monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
                dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
                dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
                dateFormat: 'dd/mm/yy',
                firstDay: 1,
                isRTL: false,
                showMonthAfterYear: false,
                yearSuffix: ''
            };
            $.datepicker.setDefaults($.datepicker.regional['es']);
        });
    </script>
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
            <h2>Registro de Evaluación</h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
           
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style="width: 100%">
                        <tr>
                            <td align="right" width="80">Departamento:</td>
                            <td>
                                <asp:DropDownList ID="ddlDepartamento" runat="server" AutoPostBack="True" CssClass="form_row" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>Lider:</td>
                            <td>
      
                                <asp:DropDownList ID="ddlLider" runat="server" AutoPostBack="True" CssClass="form_row" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                                </asp:DropDownList>
      
                            </td>
                            <td align="right" width="80">Estado:</td>
                            <td width="300">
                                <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="True" CssClass="form_row" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                                    <asp:ListItem Value="%%" Selected="True">(Todos)</asp:ListItem>
                                    <asp:ListItem Value="0">Sin Evaluación</asp:ListItem>
                                    <asp:ListItem Value="1">Incompleto</asp:ListItem>
                                    <asp:ListItem Value="2">Evaluado</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="80">Año:</td>
                            <td>
                                <asp:DropDownList ID="ddlAnio" runat="server" AutoPostBack="True" CssClass="form_row" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                                    <asp:ListItem Selected="True">2017</asp:ListItem>
                                    <asp:ListItem>2018</asp:ListItem>
                                    <asp:ListItem>2019</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right" width="80">Período:</td>
                            <td width="300">
                                <asp:DropDownList ID="ddlTipo" runat="server" AutoPostBack="True" CssClass="form_row" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                                    <asp:ListItem Value="1" >Revisión Mitad de Año</asp:ListItem>
                                    <asp:ListItem Value="2" Selected="True">Revisión Final de Año</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right" width="80"></td>
                            <td width="300">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" width="80">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td align="right" width="80">&nbsp;</td>
                            <td width="300">&nbsp;</td>
                            <td align="right" width="80">&nbsp;</td>
                            <td width="300">
                                <asp:Button ID="btnExportar" runat="server" Text="Exportar" OnClick="btnExportar_Click" CssClass="botonX"/>
                            </td>
                        </tr>
                    </table>
                    <h2>Personal a cargo:</h2>
                        <asp:Repeater ID="rpPlanAccion" runat="server" OnItemDataBound="rpPlanAccion_ItemDataBound">
                            <HeaderTemplate>
                                <table class='CSSTableGenerator' style="width: 100%;">
                                    <tr>
                                        <th width="60px" style="display: none">ID</th>
                                        <th width="60px" style="display: none">Boton</th>
                                        <th width="60px">Codigo</th>
                                        <th width="400">Nombres</th>
                                        <th width="100">Subcategoria</th>
                                        <th width="100">Evaluación</th>
                                        <th width="100px"></th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                               <tr style="background-color: #e3dfff;font-size: 12px !important;">
                                    <td style="display: none">
                                        <asp:Label ID="lblFuncionario_id" Text='<%# DataBinder.Eval(Container.DataItem, "FUNCIONARIO_ID") %>' runat="server" />
                                    </td>
                                   <td style="display: none">
                                        <asp:Label ID="lblBoton" Text='<%# DataBinder.Eval(Container.DataItem, "boton") %>' runat="server" />
                                    </td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "FUNCIONARIO_TNUMBER") %> </td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "FUNCIONARIO_NOME") %> </td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "SubCategoria_desc") %> </td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "Evaluacion_id") %> </td>
                                    <td style="text-align: center">
                                        <asp:ImageButton ID="ibnCumplir" runat="server" ImageUrl='~/Comportamiento/Images/btnCerrar.png'
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
            <asp:Label ID="lblMensaje" runat="server" Font-Size="16px" ForeColor="Red" Visible="False"></asp:Label>
        </div>

    </div>
</asp:Content>
