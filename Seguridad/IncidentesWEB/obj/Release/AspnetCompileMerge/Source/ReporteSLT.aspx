<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteSLT.aspx.cs" Inherits="IncidentesWEB.ReporteSLT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>J. Urco::Reporte SLT</title>
    <meta http-equiv="X-UA-Compatible" content="IE=100">
    <link href="../default.aspxpg.png" rel="shortcut icon" type="image/x-icon" />
    <link href="css/reset.css" rel="stylesheet" type="text/css" />
    <link href="css/css_tabla.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/custom_inputs.css" rel="stylesheet" type="text/css" />
    <link href="comportamiento/css/style_cms.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .auto-style1 {
            color: #000;
            background-color: #AEF3FF;
            height: 9px;
        }
        .auto-style2 {
            height: 9px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div id="admin_container">
            <div id="header">
                <div id="top_nav">
                    <div id="logo_home">
                        <a href="../default.aspx"></a>
                    </div>
                    <div id="top_menu">
                        <ul>
                            <li></li>
                        </ul>
                    </div>
                </div>
                <div id="top_tips">
                    <div id="tips">
                        <ul id="lista_tips">
                            <li><span>DMS RTT</span></li>
                        </ul>
                        <ul id="lista_tips_Izq">
                            <li><span></span></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div id="contenido" class="cms">
                <asp:DropDownList ID="ddlMes" runat="server">
                    <asp:ListItem Value="1">Enero</asp:ListItem>
                    <asp:ListItem Value="2">Febrero</asp:ListItem>
                    <asp:ListItem Value="3">Marzo</asp:ListItem>
                    <asp:ListItem Value="4">Abril</asp:ListItem>
                    <asp:ListItem Value="5" Selected>Mayo</asp:ListItem>
                    <asp:ListItem Value="6">Junio</asp:ListItem>
                    <asp:ListItem Value="7">Julio</asp:ListItem>
                    <asp:ListItem Value="8">Agosto</asp:ListItem>
                    <asp:ListItem Value="9">Setiembre</asp:ListItem>
                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                </asp:DropDownList><asp:DropDownList ID="ddlAnio" runat="server">
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <div id="myTable" class="tablesorter">
                    <table border="1" cellpadding="0" cellspacing="0">
                        <tr>
                            <th width="127">Sistema</th>
                            <th width="281">Medidas</th>
                            <th width="57">Target</th>
                            <th width="50">MKG</th>
                            <th width="50">PKG</th>
                            <th width="51">BC</th>
                            <th width="50">HC</th>
                            <th width="50">PD</th>
                            <th width="50">QA</th>
                            <th width="45">ING</th>
                            <th width="43">HS&amp;E</th>
                            <th width="45">HR</th>
                            <th width="45">SNO</th>
                            <th width="43">STOE</th>
                            <th width="64">Total</th>
                        </tr>
                        <tr>
                            <td rowspan="5" class="columna">Incidentes</td>
                            <td class="columna2">Incidentes    Primeros Auxilios</td>
                            <td width="57">0</td>
                            <td width="50">0</td>
                            <td width="50">0</td>
                            <td width="51">1</td>
                            <td width="50">0</td>
                            <td width="50">0</td>
                            <td width="50">0</td>
                            <td width="45">0</td>
                            <td width="43">0</td>
                            <td width="45">0</td>
                            <td width="45">0</td>
                            <td width="43">0</td>
                            <td width="64">1</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Incidentes clase 1 near misses reportados</td>
                            <td width="57" class="auto-style2">#</td>
                            <td width="50" class="auto-style2">15</td>
                            <td width="50" class="auto-style2">15</td>
                            <td width="51" class="auto-style2">11</td>
                            <td width="50" class="auto-style2">6</td>
                            <td width="50" class="auto-style2">61</td>
                            <td width="50" class="auto-style2">0</td>
                            <td width="45" class="auto-style2">0</td>
                            <td width="43" class="auto-style2">0</td>
                            <td width="45" class="auto-style2">0</td>
                            <td width="45" class="auto-style2">0</td>
                            <td width="43" class="auto-style2">1</td>
                            <td width="64" class="auto-style2">169</td>
                        </tr>
                        <tr>
                            <td class="columna2">Ratio de inc/pers</td>
                            <td width="57">0.40</td>
                            <td width="50">1.42</td>
                            <td width="50">0.46</td>
                            <td width="51">2.64</td>
                            <td width="50">2.40</td>
                            <td width="50">0.43</td>
                            <td width="50">0.4</td>
                            <td width="45">0.40</td>
                            <td width="43">13.33</td>
                            <td width="45">0.00</td>
                            <td width="45">0.00</td>
                            <td width="43">0.33</td>
                            <td width="64">1.04</td>
                        </tr>
                        <tr>
                            <td class="columna2">Incidentes     no cerrados a tiempo </td>
                            <td width="57">0</td>
                            <td width="50">0</td>
                            <td width="50">0</td>
                            <td width="51">0</td>
                            <td width="50">0</td>
                            <td width="50">16</td>
                            <td width="50">0</td>
                            <td width="45">0</td>
                            <td width="43">1</td>
                            <td width="45">0</td>
                            <td width="45">0</td>
                            <td width="43">0</td>
                            <td width="64">17</td>
                        </tr>
                        <tr>
                            <td class="columna2">Planes de acción pendientes</td>
                            <td width="57">0</td>
                            <td width="50">0</td>
                            <td width="50">4</td>
                            <td width="51">1</td>
                            <td width="50">2</td>
                            <td width="50">0</td>
                            <td width="50">0</td>
                            <td width="45">0</td>
                            <td width="43">0</td>
                            <td width="45">0</td>
                            <td width="45">0</td>
                            <td width="43">0</td>
                            <td width="64">6</td>
                        </tr>
                        <tr>
                            <td rowspan="4" class="columna">C&amp;C</td>
                            <td class="columna2">Cumplimiento    SSS</td>
                            <td width="57">100%</td>
                            <td>100%</td>
                            <td>100%</td>
                            <td>100%</td>
                            <td>100%</td>
                            <td>0%</td>
                            <td>100%</td>
                            <td>0%</td>
                            <td>100%</td>
                            <td>0%</td>
                            <td>100%</td>
                            <td>NA</td>
                            <td>70%</td>
                        </tr>
                        <tr>
                            <td class="columna2">Comportamientos Inseguros</td>
                            <td width="57">#</td>
                            <td>645</td>
                            <td>275</td>
                            <td>268</td>
                            <td>51</td>
                            <td>469</td>
                            <td>24</td>
                            <td>0</td>
                            <td>0</td>
                            <td>0</td>
                            <td>0</td>
                            <td>0</td>
                            <td width="64">1732</td>
                        </tr>
                        <tr>
                            <td class="columna2">Ratio de comp /pers</td>
                            <td width="57">4.0</td>
                            <td width="50">10.8</td>
                            <td width="50">7.1</td>
                            <td width="51">8.1</td>
                            <td width="50">3.4</td>
                            <td width="50">4.6</td>
                            <td width="50">4.8</td>
                            <td width="45">0.0</td>
                            <td width="43">0.0</td>
                            <td width="45">0.0</td>
                            <td width="45">0.0</td>
                            <td width="43">0.0</td>
                            <td width="64">6.2</td>
                        </tr>
                        <tr>
                            <td class="columna2">Cumplimiento FFS</td>
                            <td width="57">100%</td>
                            <td width="50">0%</td>
                            <td>100%</td>
                            <td>100%</td>
                            <td>100%</td>
                            <td width="50">50%</td>
                            <td width="50">NA</td>
                            <td width="45">NA</td>
                            <td width="43">NA</td>
                            <td width="45">NA</td>
                            <td width="45">NA</td>
                            <td width="43">NA</td>
                            <td>70%</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="footer">
                <div id="footer_copy">
                    <div class="copy">
                        <span class="left">Copyright 2017. All rights reserved.</span> <span class="derecha">Powered by <a href="mailto:chefolc@gmail.com">chefolc@gmail.com</a></span>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
