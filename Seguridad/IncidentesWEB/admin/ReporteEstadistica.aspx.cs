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

namespace IncidentesWEB.admin
{
    public partial class ReporteEstadistica : System.Web.UI.Page
    {
        string fecha_actual;
        //datatable
        TB_IncidentesBL _TB_IncidentesBL = new TB_IncidentesBL();
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


            DateTime _Fecha_incidente, _Fecha_incidente1;
            

            if (ckbInicio.Checked == true)
            {
                _Fecha_incidente = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null);
                _Fecha_incidente1 = DateTime.ParseExact(txtFecha0.Text, "dd/MM/yyyy", null);
            }
            else
            {
                _Fecha_incidente = DateTime.ParseExact("01/01/2011", "dd/MM/yyyy", null);
                _Fecha_incidente1 = Hoy;
            }
           
            GenerarTabla(_Fecha_incidente, _Fecha_incidente1);
        }

        private void GenerarTabla( DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {

            DataTable Resultados = _TB_IncidentesBL.ListarTB_IncidentesByDepartamento(_Fecha_incidente, _Fecha_incidente1);
            StringBuilder Tabla = new StringBuilder();

            int TotalRegistros = Resultados.Rows.Count;
            Tabla.AppendLine("<table id=\"myTable\" class=\"tablesorter\">");
            Tabla.AppendLine("<thead>");
            string cabecera = "";

            cabecera = "<th>DEPARTAMENTO</th><th># INCIDENTES</th>";
            Tabla.AppendLine(cabecera);
            Tabla.AppendLine("</thead>");
            Tabla.AppendLine("<tbody>");
            int Nro = 0;
            for (int i = 0; i < TotalRegistros; i++)
            {
                Nro = i + 1;
                Tabla.Append("<td>" + Resultados.Rows[i]["Departamento_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Incidentes"] + "</td>");
                Tabla.Append(Environment.NewLine);
                Tabla.AppendLine("</tr>");
            }
            Tabla.AppendLine("</tbody>");
            Tabla.AppendLine("</table>");
            ltlResults.Text = Tabla.ToString();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            //    DateTime _fecha, _fecha1, _fecha2, _fecha3;
            //    string _estado, _tipo, _clasificacion, _categoria, _prioridad, _equipe_id, _encontrado, _resolvido, _dueno, _depto_id, _parte;
            //    _estado = ddlEstado.SelectedValue;
            //    _tipo = ddlTipos.SelectedValue;
            //    _clasificacion = ddlClasificacion.SelectedValue;
            //    _categoria = ddlCategoria.SelectedValue;
            //    _prioridad = ddlPrioridad.SelectedValue;
            //    _equipe_id = ddlTeam.SelectedValue;
            //    _encontrado = ddlEncontrado.SelectedValue;
            //    _resolvido = ddlResuelto.SelectedValue;
            //    _dueno = ddlDueno.SelectedValue;
            //    _depto_id = ddlArea.SelectedValue;
            //    _parte = ddlPartes.SelectedValue;

            //    if (ckbInicio.Checked == true)
            //    {
            //        _fecha = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null);
            //        _fecha1 = DateTime.ParseExact(txtFecha0.Text, "dd/MM/yyyy", null);
            //    }
            //    else
            //    {
            //        _fecha = DateTime.ParseExact("01/01/2001", "dd/MM/yyyy", null);
            //        _fecha1 = Hoy;
            //    }
            //    if (ckbCierre.Checked == true)
            //    {
            //        _fecha2 = DateTime.ParseExact(txtFecha1.Text, "dd/MM/yyyy", null);
            //        _fecha3 = DateTime.ParseExact(txtFecha2.Text, "dd/MM/yyyy", null);
            //    }
            //    else
            //    {
            //        _fecha2 = DateTime.ParseExact("01/01/2001", "dd/MM/yyyy", null);
            //        _fecha3 = Hoy;
            //    }
            //    ExportToExcel(_estado, _tipo, _clasificacion, _categoria, _prioridad, _equipe_id, _encontrado, _resolvido, _dueno, _fecha, _fecha1, _fecha2, _fecha3, _depto_id, _parte);
        }

       
    }
}