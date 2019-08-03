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
    public partial class Default : System.Web.UI.Page
    {
        Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();
        TB_IncidentesBL _TB_IncidentesBL = new TB_IncidentesBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {

            }
            else
            {
                if (Session["Fnc_Funcionarios"] == null)
                {
                    Response.Redirect("login_incidentes.aspx");
                }
                
                _Fnc_FuncionariosBE = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]);
                TB_AccesosBE _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(_Fnc_FuncionariosBE.Funcionario_Id, 1);
                //Session["FUNCIONARIO_ID"] = "71046";
                DateTime Hoy = DateTime.Today;
                if (_TB_AccesosBE.Permiso > 0)
                    GenerarTabla(_TB_AccesosBE.Usuario_id, _TB_AccesosBE.Permiso);
            }

        }

        private void GenerarTabla(int _Usuario_id, Int16 _Permiso)
        {

            DataTable Resultados = _TB_IncidentesBL.BuscarTB_IncidentesByUsuario(_Usuario_id, _Permiso);
            StringBuilder Tabla = new StringBuilder();

            string _idEtiqueta;

            int TotalRegistros = Resultados.Rows.Count;
            if (TotalRegistros != 0)
            {
                Tabla.AppendLine("<div class=\"menu\"><h2>Administrar:</h2>");
                Tabla.AppendLine("<ul><li><a href=\"AdministracionFuncionarios.aspx\"><font face=\"Verdana, Arial, Helvetica, sans-serif\" size=\"2\">Administrar Empleado</font></a></li>");
                Tabla.AppendLine("<li><a href=\"Administrador.aspx\"><font face=\"Verdana, Arial, Helvetica, sans-serif\" size=\"2\">Administrador General</font></a></li></ul></div>");
                Tabla.AppendLine("<h2>Incidentes Nuevos:</h2>");
                Tabla.AppendLine("<table id=\"myTable\" class=\"tablesorter\">");
                Tabla.AppendLine("<thead>");
                string cabecera = "";
                    cabecera = "<th>COD.</th><th width=\"110\"> TITULO </th><th> ÁREA. </th><th>FECHA</th><th> ZONA </th><th> CLASIFI. </th><th>TIP. EMP.</th><th>ORIGINADOR</th><th> ESTADO </th>";

                Tabla.AppendLine(cabecera);
                Tabla.AppendLine("</thead>");
                Tabla.AppendLine("<tbody>");
                int Nro = 0;
                string _estilo = "";
                for (int i = 0; i < TotalRegistros; i++)
                {
                    Nro = i + 1;
                    _idEtiqueta = Resultados.Rows[i]["Incidente_id"].ToString();
                    Tabla.AppendLine("<tr>");
                    Tabla.Append("<td" + _estilo + ">" + "<a href=\"#\" onClick=\"PopUp('EvaluacionIncidentePop.aspx?Incidente_id=" + _idEtiqueta + "',20,20,950,678); return false;\"> " + _idEtiqueta + " </a></td>");
                    Tabla.Append("<td" + _estilo + ">" + "<a href=\"ActualizarIncidente.aspx?reg=&Incidente_id=" + _idEtiqueta + "\" > " + Resultados.Rows[i]["Titulo"] + " </a></td>");
                    Tabla.Append("<td>" + Resultados.Rows[i]["Departamento"] + "</td>");
                    Tabla.Append("<td>" + Resultados.Rows[i]["Fecha_incidente"] + "</td>");
                    Tabla.Append("<td>" + Resultados.Rows[i]["Area_desc"] + "</td>");
                    Tabla.Append("<td>" + Resultados.Rows[i]["Clasificacion_desc"] + "</td>");
                    Tabla.Append("<td>" + Resultados.Rows[i]["Tipo_emp"] + "</td>");
                    Tabla.Append("<td>" + Resultados.Rows[i]["Originador"] + "</td>");
                    Tabla.Append("<td>" + Resultados.Rows[i]["Estado"] + "</td>");
                    Tabla.Append(Environment.NewLine);
                    Tabla.AppendLine("</tr>");
                }
                Tabla.AppendLine("</tbody>");
                Tabla.AppendLine("</table>");
                ltlIncidentes.Text = Tabla.ToString();
            }
        }
    }
}