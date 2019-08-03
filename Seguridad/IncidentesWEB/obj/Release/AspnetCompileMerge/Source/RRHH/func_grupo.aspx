<%@ Page Title="" Language="C#" MasterPageFile="~/RRHH/AdminMaster.Master" AutoEventWireup="true" CodeBehind="func_grupo.aspx.cs" Inherits="IncidentesWEB.RRHH.func_grupo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_cph_content" runat="server">
    <div id="contenido" class="cms">
        <div id="panel" class="custom_form">
            <div class="line-horiz">
            </div>
            <div id="contenido_interna" class="resultados">
                <h1 class="titulo-azul">Ingrese el Nombre de Empleado</h1>
                <br />

                <asp:TextBox ID="txtTag" runat="server" CssClass="search_txt" placeholder="Buscar..." />
                <asp:Button ID="btnSearch" runat="server" Text="Buscar" CssClass="search_btn" OnClick="btnSearch_Click" />
                <br />
                <br />
                <div class="clear">
                    <asp:Literal ID="ltlResults" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
