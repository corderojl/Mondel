<%@ Page Title="" Language="C#" MasterPageFile="~/Indicadores/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ActualizarEvaluacion.aspx.cs" Inherits="IncidentesWEB.Indicadores.ActualizarEvaluacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=100">

    <link href="../css/reset.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />
    <link href="css/style_cms.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../Scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.alerts.js"></script>
    <link href="../css/jquery.alerts.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/jquery-1.2.6.min.js"></script>

    <script type="text/javascript">
        var popUpWin = 0;
        function PopUp(URLStr, left, top, width, height) {
            if (popUpWin) {
                if (!popUpWin.closed) popUpWin.close();
            }
            popUpWin = open(URLStr, 'popUpWindows', 'toolbar=no,scrollbars=yes,location=no,directories=no,status=no,menubar=no,resizable=no,copyhistory=yes,width=' + width + ',height=' + height + ',left=' + left + ', top=' + top + ',screenX=' + left + ',screenY=' + top + '');
        }
        function OpenPopup() {
            window.open("actualizarpop.aspx" + URLStr, "Custom", "scrollbars=yes,resizable=no,menubar=no,status=no,toolbar=no,width=600,height=400");
            return false;
        }
        function Mensaje() {
            window.alert('El registro se actualizó con exito');
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#boton_jalert').click(function () {
                jAlert("Actualidad jQuery", "Actualidad jQuery");
            });
            $('#boton_jconfirm').click(function () {
                jConfirm("¿Te gusta Actualidad jQuery?", "Actualidad jQuery", function (r) {
                    if (r) {
                        jAlert("Te gusta Actualidad jQuery", "Actualidad jQuery");
                    } else {
                        jAlert("No te gusta Actualidad jQuery", "Actualidad jQuery");
                    }
                });
            });
            $('#boton_jprompt').click(function () {
                jPrompt("Introduce tu nombre", "", "Actualidad jQuery", function (r) {
                    if (r) {
                        jAlert("Tu nombre es " + r, "Actualidad jQuery");
                    }
                });
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_cph_content" runat="server">
    <div id="contenido" class="cms">
        <div id="formulario" class="custom_form">
            <h2>Evaluar Colega</h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td align="right" width="80">Departamento:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="form_row" Enabled="False">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right" width="80">Empleado:</td>
                                    <td width="300">
                                        <asp:DropDownList ID="ddlEmpleado" runat="server" CssClass="form_row" Enabled="False">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="80">Año:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlAnio" runat="server" CssClass="form_row" Enabled="False">
                                            <asp:ListItem >2017</asp:ListItem>
                                            <asp:ListItem>2018</asp:ListItem>
                                            <asp:ListItem>2019</asp:ListItem>
                                            <asp:ListItem>2020</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right" width="80">Tipo:</td>
                                    <td width="300">
                                        <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form_row" Enabled="False">
                                            <asp:ListItem Value="1">Revisión Mitad de Año</asp:ListItem>
                                            <asp:ListItem Value="2">Revisión Final de Año</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="80">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td align="right" width="80">Imprimir Reporte:</td>
                                    <td width="300">
                                        <asp:Literal ID="ltrPrint" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                            </table>

                            <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                                <ProgressTemplate>
                                    <div id="divEspera0" style="position: absolute; left: 0px; top: 0px; width: 90%; height: 100%; background-color: #ccc; opacity: 0.4; filter: alpha(opacity=40);">
                                        <h1 style="position: absolute; left: 300px; top: 50px">Actualizando Indicadores...</h1>
                                        <img src="images/carga.gif" style="position: absolute; left: 40%; top: 40%; width: 20%; height: 20%" />
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <br>
        <table class='CSSTableGenerator'>
            <tr style="text-align: right;">
                <th>
                    <asp:Label ID="lblCategoria" runat="server" Text=""></asp:Label></th>
            </tr>
        </table>
        <table class='CSSTableGenerator'>
            <tr style="text-align: right;">
                <th align="right">
                    <asp:Label ID="lblSubCategoria" runat="server" Text=""></asp:Label></th>
            </tr>
        </table>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Repeater ID="rpTrigger" runat="server" OnItemDataBound="rpTrigger_ItemDataBound">
                    <HeaderTemplate>
                        <table id="myTable" class='CSSTableGenerator'>
                            <tr>
                                <th width="60px">CBN</th>
                                <th width="60px">FUN. CBN</th>
                                <th width="60px" style="display: none">Id</th>
                                <th width="100px">Indicador</th>
                                <th width="40px" style="display: none">Puntos</th>
                                <th width="100px">Target</th>
                                <th width="100px">Cumplió</th>
                                <th width="40px">Puntaje</th>
                                <th width="100px">Comentarios</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style="background-color: bisque;">
                            <td><%# DataBinder.Eval(Container.DataItem, "CBN") %></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "FCBN") %> </td>
                            <td style="display: none">
                                <asp:Label ID="lblEvaluacionDetalle_id" Text='<%# DataBinder.Eval(Container.DataItem, "EvaluacionDetalle_id") %>' runat="server" />
                            </td>
                            <td><%# DataBinder.Eval(Container.DataItem, "Objetivo") %> </td>
                            <td>
                                <asp:Label ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem, "Target") %>' runat="server" />
                            </td>
                            <td>
                               <asp:Label ID="lblEstado" Text='<%# DataBinder.Eval(Container.DataItem, "Estado") %>' runat="server" />
                                <asp:ImageButton ID="ibnActualizar" runat="server" ImageUrl="~/Trigger/Images/change.png"
                                    OnClick="ibnActualizar1_Click" ToolTip='<%# DataBinder.Eval(Container.DataItem, "Meta") %>' CausesValidation="False" Width="25px" />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblPuntosOpt" Text='<%# DataBinder.Eval(Container.DataItem, "PuntosOpt") %>' runat="server" />
                            </td>
                            <td style="display: none">
                                <asp:Label ID="lblPuntos" Text='<%# DataBinder.Eval(Container.DataItem, "Puntos") %>' runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtObservacion" Text='<%# DataBinder.Eval(Container.DataItem, "Observacion").ToString() %>' runat="server" TextMode="MultiLine" AutoPostBack="True" OnTextChanged="txtObservacion_TextChanged" MaxLength="500"></asp:TextBox>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>

                <!--</table> -->

                <asp:Repeater ID="rpDetalle2" runat="server" OnItemDataBound="rpDetalle2_ItemDataBound">
                    <HeaderTemplate>
                        <!--<table class='CSSTableGenerator2' id="myTable2">-->
                        <tr>
                            <th width="60px">Valores Corporativos</th>
                            <th width="120px" colspan="2">Significado</th>
                            <th width="0px" style="display: none">Id</th>
                            <th width="0px" style="display: none">Puntos</th>
                            <th width="120px">Comportamientos Esperados</th>
                            <th width="120px">Cumplió</th>
                            <th width="60px" style="display: none">Puntaje</th>
                            <th width="180px" colspan="2">Comentarios</th>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style="background-color: #fff4a8;">
                            <td><%# DataBinder.Eval(Container.DataItem, "Meta") %> </td>
                            <td colspan="2"><%# DataBinder.Eval(Container.DataItem, "FCBN") %> </td>
                            <td style="display: none">
                                <asp:Label ID="lblEvaluacionDetalle_id" Text='<%# DataBinder.Eval(Container.DataItem, "EvaluacionDetalle_id") %>' runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem, "Objetivo") %>' runat="server" />
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" Style="width: 100px;">
                                    <asp:ListItem Value="">-Seleccione-</asp:ListItem>
                                    <asp:ListItem Value="0">Poco</asp:ListItem>
                                    <asp:ListItem Value="1">La mayoria de las veces</asp:ListItem>
                                    <asp:ListItem Value="2">Siempre</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td  style="display: none">
                                <asp:Label ID="lblPuntosOpt" Text='<%# DataBinder.Eval(Container.DataItem, "PuntosOpt") %>' runat="server" />
                            </td>
                            <td style="display: none">
                                <asp:Label ID="lblPuntos" Text='<%# DataBinder.Eval(Container.DataItem, "Puntos") %>' runat="server" />
                            </td>
                            <td  colspan="2">
                                <asp:TextBox ID="txtObservacion" Text='<%# DataBinder.Eval(Container.DataItem, "Observacion").ToString() %>' runat="server" TextMode="MultiLine" AutoPostBack="True" OnTextChanged="txtObservacion_TextChanged2" MaxLength="500"></asp:TextBox>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>

                <!--</table> -->


                <asp:Repeater ID="rpDetalle3" runat="server" OnItemDataBound="rpDetalle3_ItemDataBound">
                    <HeaderTemplate>
                        <!-- <table class='CSSTableGenerator3'>-->
                        <tr>
                            <th width="100px" colspan="7">Solo para RRHH</th>
                        </tr>
                        <tr>
                            <th width="100px" colspan="4">Indicador</th>
                            <th width="60px" style="display: none">Id</th>
                            <th width="40px" style="display: none">Puntos</th>
                            <th width="100px" colspan="2">Cumplió</th>
                            <th width="60px" style="display: none">Puntaje</th>
                            <th width="100px">Comentarios</th>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style="background-color: #ecfbd7;">
                            <td colspan="4">
                                <asp:Label ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem, "Objetivo") %>' runat="server" /></td>

                            <td style="display: none">
                                <asp:Label ID="lblEvaluacionDetalle_id" Text='<%# DataBinder.Eval(Container.DataItem, "EvaluacionDetalle_id") %>' runat="server" />
                            </td>
                            <td colspan="2">
                                <asp:Label ID="lblEstado" Text='<%# DataBinder.Eval(Container.DataItem, "Estado") %>' runat="server" />
                                <asp:ImageButton ID="ibnActualizar" runat="server" ImageUrl="~/Trigger/Images/change.png"
                                    OnClick="ibnActualizar_Click" ToolTip="Cambiar Valor" CausesValidation="False" Width="25px" Enabled="False" />
                            </td>
                            <td style="display: none">
                                <asp:Label ID="lblPuntosOpt" Text='<%# DataBinder.Eval(Container.DataItem, "PuntosOpt") %>' runat="server" />
                            </td>
                            <td style="display: none">
                                <asp:Label ID="lblPuntos" Text='<%# DataBinder.Eval(Container.DataItem, "Puntos") %>' runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtObservacion" Text='<%# DataBinder.Eval(Container.DataItem, "Observacion").ToString() %>' runat="server" TextMode="MultiLine" AutoPostBack="True" OnTextChanged="txtObservacion_TextChanged3" MaxLength="500"></asp:TextBox>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
                </table>
                 <div id="estadistica">
                     <div id="subestadistica">
                         <h3>Evaluación:</h3>

                         <asp:Label ID="lblNombre" runat="server" Text="" Font-Bold="True"></asp:Label><br />
                         Puntos Hard(50%):
                         <asp:Label ID="lblHard" runat="server" Text="" Font-Bold="True"></asp:Label><strong>%</strong><br />
                         Puntos Soft(30%):
                         <asp:Label ID="lblSoft" runat="server" Text="" Font-Bold="True"></asp:Label><strong>%</strong><br />
                         Puntos RRHH(20%):
                         <asp:Label ID="lblRRHH" runat="server" Text="" Font-Bold="True"></asp:Label><strong>%</strong><br />
                         Total:<asp:Label ID="lblSuma" runat="server" Text="" Font-Bold="True"></asp:Label><strong>%</strong><br />
                         Clasificación:
                         <asp:Label ID="lblClas" runat="server" Text="" Font-Bold="True"></asp:Label><br />
                         <asp:Literal ID="ltrEstadistica" runat="server"></asp:Literal>

                     </div>
                 </div>

                <script type="text/javascript">

                    $(function () {
                        //Created By: Brij Mohan
                        //Website: http://techbrij.com
                        function groupTable($rows, startIndex, total) {
                            if (total === 0) {
                                return;
                            }
                            var i, currentIndex = startIndex, count = 1, lst = [];
                            var tds = $rows.find('td:eq(' + currentIndex + ')');
                            var ctrl = $(tds[0]);
                            lst.push($rows[0]);
                            for (i = 1; i <= tds.length; i++) {
                                if (ctrl.text() == $(tds[i]).text()) {
                                    count++;
                                    $(tds[i]).addClass('deleted');
                                    lst.push($rows[i]);
                                }
                                else {
                                    if (count > 1) {
                                        ctrl.attr('rowspan', count);
                                        groupTable($(lst), startIndex + 1, total - 1)
                                    }
                                    count = 1;
                                    lst = [];
                                    ctrl = $(tds[i]);
                                    lst.push($rows[i]);
                                }
                            }
                        }
                        groupTable($('#myTable tr:has(td)'), 0, 3);
                        $('#myTable .deleted').remove();
                        groupTable($('#myTable2 tr:has(td)'), 0, 3);
                        $('#myTable2 .deleted').remove();
                    });
                </script>
                <br>
                <table class="rwd-table">
                    <%--<tr>
                        <td></td>
                        <td></td>
                        <td>% de Cump.:</td>
                        <td>
                            <asp:Label ID="lblPuntajeTotal" runat="server" Text="0" Visible="false"></asp:Label>
                        </td>
                    </tr>--%>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>Clasificación:</td>
                        <td>
                            <asp:Label ID="lblClasificacion" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:Literal ID="ltlAlert" runat="server"></asp:Literal>
            </ContentTemplate>
        </asp:UpdatePanel>
        <table class="tableTrigger">
            <tr>
                <td align="right" width="80">
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Evaluación" CssClass="btnlogin" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Deseas Eliminar el registro?')" Height="39px"/>
                </td>
                <td>&nbsp;</td>
                <td align="right" width="80">&nbsp;</td>
                <td width="300">
                    <asp:Label ID="RRHH" runat="server" Text="0" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>

    </div>

</asp:Content>
