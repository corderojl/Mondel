<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Scorecard.aspx.cs" Inherits="IncidentesWEB.Scorecard" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Chart ID="chrComportamiento" runat="server">
            <series>
                <asp:Series Name="Series1" ChartType="Area">
                </asp:Series>
              
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>

            </chartareas>
        </asp:Chart>
    
        <asp:Chart ID="chrIncidentesClasificacion" runat="server">
            <Series>
                <asp:Series Name="Series1">
                </asp:Series>
                  <asp:Series Name="Series2" ChartType="Line" BorderColor="180, 26, 59, 105" LabelFormat="C">

                  </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    
    </div>
    </form>
</body>
</html>
