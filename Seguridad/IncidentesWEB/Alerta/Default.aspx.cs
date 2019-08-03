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
    public partial class Default : System.Web.UI.Page
    {
        Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();
        ALR_AlertasBL _ALR_AlertasBL = new ALR_AlertasBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {

            }
            else
            {
                if (Session["Fnc_Funcionarios"] == null)
                {
                    Response.Redirect("login_Alertas.aspx");
                }
                
                _Fnc_FuncionariosBE = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]);
                TB_AccesosBE _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(_Fnc_FuncionariosBE.Funcionario_Id, 2);
                //Session["FUNCIONARIO_ID"] = "71046";
                DateTime Hoy = DateTime.Today;
                if (_TB_AccesosBE.Permiso > 0)
                {
                    GenerarTabla(_TB_AccesosBE.Usuario_id, _TB_AccesosBE.Permiso);
                    lblAdministrador.Visible = true;
                    lblAdministrador.Text = "<h2>Administrador General</h2><ul><li><a href='Administrador.aspx'><font face='Verdana, Arial, Helvetica, sans-serif' size='2'>Administración</font></a></li></ul>";
                }
            }

        }

        private void GenerarTabla(int _Usuario_id, Int16 _Permiso)
        {

            DataTable Resultados = _ALR_AlertasBL.BuscarALR_AlertasByUsuario(_Usuario_id, _Permiso);
            StringBuilder Tabla = new StringBuilder();

            string _idEtiqueta;

            int TotalRegistros = Resultados.Rows.Count;
            if (TotalRegistros != 0)
            {
                Tabla.AppendLine("<h2>Nuevos registros de Alertas:</h2>");
                Tabla.AppendLine("<table id=\"myTable\" class=\"tablesorter\">");
                Tabla.AppendLine("<thead>");
                string cabecera = "";
                cabecera = "<th>COD.</th><th width=\"210\"> DESCRIPCIÓN </th><th>CLASIF.</th><th>FECHA</th><th>DEPARTAMENTO</th><th>ÁREA</th><th>GUARDIA</th><th>ORIGINADOR</th><th>GUARDIA ORIG.</th><th> ESTADO </th>";

                Tabla.AppendLine(cabecera);
                Tabla.AppendLine("</thead>");
                Tabla.AppendLine("<tbody>");
                int Nro = 0;
                string _estilo = "";
                for (int i = 0; i < TotalRegistros; i++)
                {
                    Nro = i + 1;
                    _idEtiqueta = Resultados.Rows[i]["Alerta_id"].ToString();
                    Tabla.AppendLine("<tr>");
                    Tabla.Append("<td" + _estilo + ">" + "<a href=\"#\" onClick=\"PopUp('EvaluacionAlertaPop.aspx?Alerta_id=" + _idEtiqueta + "',20,20,950,678); return false;\"> " + _idEtiqueta + " </a></td>");
                    Tabla.Append("<td" + _estilo + ">" + "<a href=\"ActualizarAlerta.aspx?reg=&Alerta_id=" + _idEtiqueta + "\" > " + Resultados.Rows[i]["Alerta_desc"] + " </a></td>");
                    Tabla.Append("<td>" + Resultados.Rows[i]["Clasificacion"] + "</td>");
                    Tabla.Append("<td>" + Resultados.Rows[i]["Fecha_alerta"] + "</td>");
                    Tabla.Append("<td>" + Resultados.Rows[i]["Departamento_desc"] + "</td>");
                    Tabla.Append("<td>" + Resultados.Rows[i]["Area_Desc"] + "</td>");
                    Tabla.Append("<td>" + Resultados.Rows[i]["Guardia_desc"] + "</td>");
                    Tabla.Append("<td>" + Resultados.Rows[i]["Funcionario_nome"] + "</td>");
                    Tabla.Append("<td>" + Resultados.Rows[i]["Guardia_ori"] + "</td>");
                    Tabla.Append("<td>" + Resultados.Rows[i]["Estado"] + "</td>");
                    Tabla.Append(Environment.NewLine);
                    Tabla.AppendLine("</tr>");
                }
                Tabla.AppendLine("</tbody>");
                Tabla.AppendLine("</table>");
                ltlAlertas.Text = Tabla.ToString();
            }
        }
    }
}