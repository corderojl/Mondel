<%@ Page Title="" Language="C#" MasterPageFile="~/LUPs/AdminMaster.Master" AutoEventWireup="true" CodeBehind="RegistrarLup.aspx.cs" Inherits="IncidentesWEB.LUPs.RegistrarLup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="admin_cph_head" runat="server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_cph_content" runat="server">
    <div id="contenido" class="cms">
        <div id="panel" class="custom_form">
            <h2>Registro de LUPs</h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <script type="text/javascript">
                Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
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

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td align="right" width="15%">Área:</td>
                            <td width="30%">
                                <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="form_row" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="ddlDepartamento" InitialValue="0" Font-Size="X-Large"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" width="15%">Responsable:</td>
                            <td width="30%">
                                <asp:Label ID="lblResponsable" runat="server" CssClass="form_lab"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Guardia: </td>
                            <td>
                                <asp:DropDownList ID="ddlGuardia" runat="server" CssClass="form_row">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlGuardia" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right">Dueño:</td>
                            <td>
                                <asp:DropDownList ID="ddlDuenio" runat="server" CssClass="form_row">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDuenio" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Fecha de Caducidad:</td>
                            <td>
                                <asp:TextBox ID="txtFecha" runat="server" CssClass="form_cal"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFecha" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right">Pilar:</td>
                            <td>
                                
                                <asp:DropDownList ID="ddlPilar" runat="server" CssClass="form_row" AutoPostBack="True" OnSelectedIndexChanged="ddlPilar_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlPilar" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="auto-style1">Titulo Corto</td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtTitulo" runat="server" Width="248px"></asp:TextBox>
                            </td>
                            <td align="right" class="auto-style1">Categoria:</td>
                            <td class="auto-style1">
                                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form_row">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlCategoria" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Descripción breve:</td>
                            <td colspan="3">
                                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form_row" Height="57px" TextMode="MultiLine" Width="513px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtDescripcion" Display="Dynamic" ErrorMessage="*" Font-Size="X-Large"></asp:RequiredFieldValidator>
                            </td>

                        </tr>
                    </table>

                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <div id="divEspera" style="position: absolute; left: 0px; top: 0px; width: 100%; height: 100%; background-color: #ccc; opacity: 0.4; filter: alpha(opacity=40);">
                                <h1 style="position: absolute; left: 300px; top: 50px">Registrando LUP...</h1>
                                <img src="images/carga.gif" style="position: absolute; left: 40%; top: 40%; width: 20%; height: 20%" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>

                </ContentTemplate>
            </asp:UpdatePanel>
            <table>
                <tr>
                    <td align="right" width="15%">Archivo:</td>
                    <td colspan="2" width="45%">
                        <asp:FileUpload ID="fupLup" runat="server" Width="370px"/>
                    </td>

                    <td width="30%"></td>
                </tr>
            </table>
            <asp:Button ID="btnRegistrar" runat="server" Text="Guardar" OnClick="btnRegistrar_Click" class="botonF"/>
            <asp:Label ID="lblMensaje" runat="server" Font-Size="16px" ForeColor="Red" Visible="False"></asp:Label>
        </div>
    </div>
</asp:Content>
