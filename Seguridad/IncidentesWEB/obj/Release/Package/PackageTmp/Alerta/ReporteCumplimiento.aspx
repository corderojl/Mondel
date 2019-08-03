<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteCumplimiento.aspx.cs" Inherits="IncidentesWEB.Alerta.ReporteCumplimiento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Evaluación de Alertas</title>
    <link href="../default.aspxpg.png" rel="shortcut icon" type="image/x-icon" />
    <link href="../css/reset.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />
    <link href="css/style_cms.css" rel="stylesheet" type="text/css" />

	<link href="../sorter/docs/css/jq.css" rel="stylesheet">

	<!-- jQuery: required (tablesorter works with jQuery 1.2.3+) -->
	<script src="../sorter/docs/js/jquery-1.2.6.min.js"></script>
	<script src="../sorter/docs/js/jquery-latest.min.js"></script>

    <link href="../css/theme.blue.css" rel="stylesheet" />
    <link href="../sorter/dist/css/theme.default.min.css" rel="stylesheet" />
    <script src="../sorter/dist/js/jquery.tablesorter.widgets.js"></script>
    <script src="../sorter/dist/js/widgets/widget-filter.min.js"></script>
    <script src="../sorter/docs/js/prettify.js"></script>
    <link href="../sorter/docs/css/prettify.css" rel="stylesheet" />
    <script src="../sorter/dist/js/jquery.tablesorter.min.js"></script>
	<script src="../sorter/dist/js/jquery.tablesorter.widgets.min.js"></script>

    <link href="Styles/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="Styles/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.ui.datepicker.js" type="text/javascript"></script>
    
</head>
<body>

    <form id="form1" runat="server">
        <div id="contenido" class="cms">
            <div id="panel" class="custom_form">
                    <div id="Div1" class="cms">
        <div id="tabla">
            <asp:Literal ID="ltlResults" runat="server"></asp:Literal>
        </div>
    </div>

    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#myTable")
                .tablesorter({
                    theme: 'blue',

                    // hidden filter input/selects will resize the columns, so try to minimize the change
                    widthFixed: true,

                    // initialize zebra striping and filter widgets
                    widgets: ["zebra", "filter"],

                    // headers: { 5: { sorter: false, filter: false } },

                    widgetOptions: {

                        // extra css class applied to the table row containing the filters & the inputs within that row
                        filter_cssFilter: '',

                        // If there are child rows in the table (rows with class name from "cssChildRow" option)
                        // and this option is true and a match is found anywhere in the child row, then it will make that row
                        // visible; default is false
                        filter_childRows: false,

                        // if true, filters are collapsed initially, but can be revealed by hovering over the grey bar immediately
                        // below the header row. Additionally, tabbing through the document will open the filter row when an input gets focus
                        filter_hideFilters: false,

                        // Set this option to false to make the searches case sensitive
                        filter_ignoreCase: true,

                        // jQuery selector string of an element used to reset the filters
                        filter_reset: '.reset',

                        // Use the $.tablesorter.storage utility to save the most recent filters
                        filter_saveFilters: true,

                        // Delay in milliseconds before the filter widget starts searching; This option prevents searching for
                        // every character while typing and should make searching large tables faster.
                        filter_searchDelay: 300,

                        // Set this option to true to use the filter to find text from the start of the column
                        // So typing in "a" will find "albert" but not "frank", both have a's; default is false
                        filter_startsWith: false,

                        // if false, filters are collapsed initially, but can be revealed by hovering over the grey bar immediately
                        // below the header row. Additionally, tabbing through the document will open the filter row when an input gets focus
                        filter_hideFilters: false,

                        // Add select box to 4th column (zero-based index)
                        // each option has an associated function that returns a boolean
                        // function variables:
                        // e = exact text from cell
                        // n = normalized value returned by the column parser
                        // f = search filter input value
                        // i = column index
                        filter_functions: {

                            // Add select menu to this column
                            // set the column value to true, and/or add "filter-select" class name to header
                            // '.first-name' : true,

                            // Exact match only
                            //1: function (e, n, f, i, $r, c, data) {
                            //    return e === f;
                            //},

                            // Add these options to the select dropdown (regex example)
                            
                            // Add these options to the select dropdown (numerical comparison example)
                            // Note that only the normalized (n) value will contain numerical data
                            // If you use the exact text, you'll need to parse it (parseFloat or parseInt)
                            2: {
                                ">1": function (e, n, f, i, $r, c, data) { return n > 0; },
                                //"$10 - $100": function (e, n, f, i, $r, c, data) { return n >= 10 && n <= 100; },
                                "=0": function (e, n, f, i, $r, c, data) { return n ==0; }
                            }
                        }

                    }
                })
        }
    );
    </script>
            </div>
        </div>
    </form>
</body>
</html>
