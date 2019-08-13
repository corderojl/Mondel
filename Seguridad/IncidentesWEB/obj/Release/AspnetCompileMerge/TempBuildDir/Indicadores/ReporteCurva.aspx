<%@ Page Title="" Language="C#" MasterPageFile="~/Indicadores/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ReporteCurva.aspx.cs" Inherits="IncidentesWEB.Indicadores.ReporteCurva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_cph_content" runat="server">
    <div id="contenido" class="cms">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="formulario" class="custom_form">

                    <table style="width: 100%;">
                        <tr>
                            <td>Departamento:</td>
                            <td>
                                <asp:DropDownList ID="ddlDepartamento" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>Lider:</td>
                            <td>
                                <asp:DropDownList ID="ddlLider" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>Tipo:</td>
                            <td>
                                <asp:DropDownList ID="ddlTipo" runat="server">
                                    <asp:ListItem Selected="True" Value="%%">(Todos)</asp:ListItem>
                                    <asp:ListItem Value="1">Revisión Mitad de Año</asp:ListItem>
                                    <asp:ListItem Value="2">Revisión Final de Año</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Año:</td>
                            <td>
                                <asp:DropDownList ID="ddlAnio" runat="server">
                                    <asp:ListItem Selected="True" Value="%%">(Todos)</asp:ListItem>
                                    <asp:ListItem Value="2017">2017</asp:ListItem>
                                    <asp:ListItem Value="2018">2018</asp:ListItem>
                                    <asp:ListItem Value="2019">2019</asp:ListItem>
                                </asp:DropDownList>

                            </td>
                            <td>Área</td>
                            <td>
                                <asp:DropDownList ID="ddlAreaLaboral" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>Categoria:</td>
                            <td>
                                <asp:DropDownList ID="ddlCategoria" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>

                    <table style="width: 95%;">
                        <!--
                <tr>
                    <td>
                        <asp:CheckBox ID="ckbCierre" runat="server" Text="Cierre:" />
                    </td>
                    <td>Desde:</td>
                    <td>

                        <asp:TextBox ID="txtFecha1" runat="server"  autocomplete="off" CssClass="form_cal"></asp:TextBox>
                    </td>
                    <td>Hasta:</td>
                    <td>

                        <asp:TextBox ID="txtFecha2" runat="server"  autocomplete="off" CssClass="form_cal"></asp:TextBox>
                    </td>
                </tr>
                -->
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" CssClass="botonG" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="estadistica">
                    <div id="subestadistica">
                        <h3>Estadística Clasificación</h3>
                        <br />
                        <asp:Literal ID="ltrEstadistica" runat="server"></asp:Literal>

                    </div>
                </div>
                <div id="curve_chart" style="width: 90%; height: 500px;"></div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>

</asp:Content>
