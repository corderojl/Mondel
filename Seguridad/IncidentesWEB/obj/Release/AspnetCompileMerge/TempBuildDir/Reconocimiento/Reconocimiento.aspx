<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reconocimiento.aspx.cs" Inherits="IncidentesWEB.Reconocimiento.Reconocimiento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/styleRec.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div>

            <p>&nbsp;</p>
            <h1>Estrella de Reconocimiento</h1>
            <label>
                <span>Para:</span>
                <asp:DropDownList ID="ddlEmpleado" runat="server" Font-Bold="True">
                </asp:DropDownList>


            </label>

            <label>
                <span>De:</span><asp:DropDownList ID="ddlOriginador" runat="server" Font-Bold="True">
                </asp:DropDownList>
            </label>

            <label>
                <span>Categoria:</span><asp:DropDownList ID="ddlCategoriaPremiacion" runat="server" Font-Bold="True">
                </asp:DropDownList>
            </label>

            <label>
                <span>Motivo</span><asp:TextBox ID="txtMotivo" runat="server" TextMode="MultiLine"></asp:TextBox>
            </label>
            <label>
                <span>Lider:</span><asp:DropDownList ID="ddlLider" runat="server" Font-Bold="True">
                </asp:DropDownList>
                
            </label>
             <label>
                <span>Fecha:</span><asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
            </label>
        </div>
    </form>
</body>
</html>
