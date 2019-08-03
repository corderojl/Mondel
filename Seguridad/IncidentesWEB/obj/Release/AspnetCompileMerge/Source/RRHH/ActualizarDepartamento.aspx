<%@ Page Title="" Language="C#" MasterPageFile="~/RRHH/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ActualizarDepartamento.aspx.cs" Inherits="IncidentesWEB.RRHH.ActualizarDepartamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.core.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.widget.js" type="text/javascript"></script>
    <link href="Styles/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="Styles/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.ui.datepicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_cph_content" runat="server">
    <div id="contenido" class="cms">
        <div id="panel" class="custom_form">
            <div id="contenido_interna" class="resultados">




                <br />
                <table class="search_table">
                    <thead>
                        <th class="auto-style1">Legajo </th>
                        <th class="auto-style1">Apellidos y Nombres </th>
                        <th class="auto-style1">Área</th>
                        <th class="auto-style1">Turno </th>
                    </thead>
                    <tbody>
                    </tbody>
                    <td>
                        <asp:Label ID="lblLegajo" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblApellido" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDepartamento" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" >
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGuardia" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </table>
                <br />
                <asp:Literal ID="ltrMensaje" runat="server"></asp:Literal>
                <br />
                <br />
                <div class="clear">


                    <asp:Button ID="btnSearch" runat="server" Text="Cambiar" CssClass="search_btn" OnClick="btnSearch_Click"  />


                    <asp:Button ID="btnSearch0" runat="server" Text="Cancelar" CssClass="search_btn" />

                </div>
            </div>
        </div>
    </div>
</asp:Content>
