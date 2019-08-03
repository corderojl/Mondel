<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ControlTeam.aspx.cs" Inherits="IncidentesWEB.admin.ControlTeam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/custom_inputs.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.core.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ui.widget.js" type="text/javascript"></script>
    <link href="Styles/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="Styles/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.ui.datepicker.js" type="text/javascript"></script>
    <script>
        var popUpWin = 0;
        function PopUp(URLStr, left, top, width, height) {
            if (popUpWin) {
                if (!popUpWin.closed) popUpWin.close();
            }
            popUpWin = open(URLStr, 'popUpWindows', 'toolbar=no,scrollbars=yes,location=no,directories=no,status=no,menubar=no,resizable=no,copyhistory=yes,width=' + width + ',height=' + height + ',left=' + left + ', top=' + top + ',screenX=' + left + ',screenY=' + top + '');
        }
        function OpenPopup() {
            window.open("actualizarpop.aspx" + URLStr, "Custom", "scrollbars=yes,resizable=no,menubar=no,status=no,toolbar=no,width=300,height=200");
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_cph_content" runat="server">
    <div class="line-horiz">
    </div>
    <div id="contenido" class="cms">
        <div id="panel" class="custom_form">
            <div id="contenido_interna" class="resultados">
                <br />

                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlDepartamento" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlGuardia" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Button ID="btnSearch" runat="server" Text="Buscar" CssClass="search_btn" OnClick="btnSearch_Click" />
                <br />
                <asp:Literal ID="ltlResults" runat="server"></asp:Literal>
                <br />
                <div class="clear">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
