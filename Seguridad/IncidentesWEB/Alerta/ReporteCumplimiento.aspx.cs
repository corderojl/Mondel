using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.Alerta
{
    public partial class ReporteCumplimiento : System.Web.UI.Page
    {
        ALR_AlertasBL _ALR_AlertasBL = new ALR_AlertasBL();
        DateTime fecha, fecha1;
        int _Departamento_id;
        int idDepto;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                idDepto = Convert.ToInt32(Session["AREA_ID"]);
            }
            else
            {
                _Departamento_id = Convert.ToInt32(Request.QueryString["Departamento_id"]);
                fecha = Convert.ToDateTime(Request.QueryString["fecha"]);
                fecha1 = Convert.ToDateTime(Request.QueryString["fecha1"]);
                GenerarTabla(_Departamento_id, fecha, fecha1);
            }
        }
        private void GenerarTabla(int Departamento_id, DateTime _Fecha_Alerta, DateTime _Fecha_Alerta1)
        {

            DataTable Resultados = _ALR_AlertasBL.ListarALR_AlertasByDepartamentoFuncionario(Departamento_id, _Fecha_Alerta, _Fecha_Alerta1);
            StringBuilder Tabla = new StringBuilder();
            string _Grupo_desc;
            int TotalRegistros = Resultados.Rows.Count;
            Tabla.AppendLine("<table id=\"myTable\" class=\"tablesorter\" style=\"width: 92%;\">");
            Tabla.AppendLine("<thead>");
            string cabecera = "";

            cabecera = "<th class=\"first-name filter-select\" data-placeholder=\"Todo\">GUARDIA</th><th data-placeholder=\"Buscar\">NOMBRES</th><th data-placeholder=\"Todo\"># ALERTAS</th>";
            Tabla.AppendLine(cabecera);
            Tabla.AppendLine("</thead>");
            Tabla.AppendLine("<tbody>");
            int Nro = 0;
            for (int i = 0; i < TotalRegistros; i++)
            {
                Nro = i + 1;
                _Grupo_desc = buscarGrupo(Convert.ToInt32(Resultados.Rows[i]["grupo_id"]));
                Tabla.Append("<td>" + _Grupo_desc + "</td>");

                Tabla.Append("<td>" + Resultados.Rows[i]["funcionario_nome"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Alertas"] + "</td>");
                Tabla.Append(Environment.NewLine);
                Tabla.AppendLine("</tr>");
            }
            Tabla.AppendLine("</tbody>");
            Tabla.AppendLine("</table>");
            ltlResults.Text = Tabla.ToString();
        }

        private string buscarGrupo(int _Grupo_id)
        {
            TB_GuardiaBL _TB_GuardiaBL = new TB_GuardiaBL();
            List<TB_GuardiaBE> lTB_GuardiaBE;
            string _Grupo_desc="Sin Guardia";
            lTB_GuardiaBE = _TB_GuardiaBL.ListarTB_GuardiaO_Act();
            foreach (TB_GuardiaBE _MiLista in lTB_GuardiaBE)
            {
                if (_MiLista.Guardia_id.Equals(_Grupo_id))
                    _Grupo_desc = _MiLista.Guardia_desc;
            }
            return _Grupo_desc;
        }
    }
}