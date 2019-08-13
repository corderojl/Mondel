<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptCartaFuncionario.aspx.cs" Inherits="IncidentesWEB.Indicadores.rptCartaFuncionario" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        table div{
            text-align:justify !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="863px" Height="650px">
        </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
