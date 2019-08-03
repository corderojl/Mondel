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
    public partial class ReporteEstadistica : System.Web.UI.Page
    {
        string fecha_actual;
        //datatable
        ALR_AlertasBL _ALR_AlertasBL = new ALR_AlertasBL();
        DateTime Hoy, fecha1;
        int _area_id;
        int idDepto;
        protected void Page_Load(object sender, EventArgs e)
        {
            Hoy = DateTime.Today;
            if (this.IsPostBack)
            {
                idDepto = Convert.ToInt32(Session["AREA_ID"]);
            }
            else
            {
                _area_id = Convert.ToInt32(Session["AREA_ID"]);
                fecha_actual = Hoy.ToString("dd/MM/yyyy");
                Hoy = DateTime.Today;
                fecha1 = new DateTime(Hoy.Year, Hoy.Month, 1);
                fecha_actual = Hoy.ToString("dd/MM/yyyy");
                txtFecha.Text = fecha1.ToString("dd/MM/yyyy");
                txtFecha0.Text = fecha_actual;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {


            DateTime _Fecha_Alerta, _Fecha_Alerta1;


            if (ckbInicio.Checked == true)
            {
                _Fecha_Alerta = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null);
                _Fecha_Alerta1 = DateTime.ParseExact(txtFecha0.Text, "dd/MM/yyyy", null);
            }
            else
            {
                _Fecha_Alerta = DateTime.ParseExact("01/01/2011", "dd/MM/yyyy", null);
                _Fecha_Alerta1 = Hoy;
            }

            GenerarTabla(_Fecha_Alerta, _Fecha_Alerta1);
        }

        private void GenerarTabla(DateTime _Fecha_Alerta, DateTime _Fecha_Alerta1)
        {

            DataTable Resultados = _ALR_AlertasBL.ListarALR_AlertasByDepartamento(_Fecha_Alerta, _Fecha_Alerta1);
            StringBuilder Tabla = new StringBuilder();

            int TotalRegistros = Resultados.Rows.Count;
            Tabla.AppendLine("<table id=\"myTable\" class=\"tablesorter\">");
            Tabla.AppendLine("<thead>");
            string cabecera = "";

            cabecera = "<th>DEPARTAMENTO</th><th># ALERTAS</th>";
            Tabla.AppendLine(cabecera);
            Tabla.AppendLine("</thead>");
            Tabla.AppendLine("<tbody>");
            int Nro = 0;
            for (int i = 0; i < TotalRegistros; i++)
            {
                Nro = i + 1;
                //Tabla.Append("<td>"+ Resultados.Rows[i]["Departamento_desc"] + "</td>");
                Tabla.AppendLine("<td><a href=\"#\" onClick=\"PopUp('ReporteCumplimiento.aspx?Departamento_id=" + Resultados.Rows[i]["Departamento_id"] + "&Fecha=" + _Fecha_Alerta + "&Fecha1=" + _Fecha_Alerta1 + "',20,20,900,600); return false;\">" + Resultados.Rows[i]["Departamento_desc"] + "</td>");
            
                Tabla.Append("<td>" + Resultados.Rows[i]["Alertas"] + "</td>");
                Tabla.Append(Environment.NewLine);
                Tabla.AppendLine("</tr>");
            }
            Tabla.AppendLine("</tbody>");
            Tabla.AppendLine("</table>");
            ltlResults.Text = Tabla.ToString();
        }
    }
}