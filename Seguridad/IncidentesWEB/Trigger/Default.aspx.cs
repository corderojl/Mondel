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

namespace IncidentesWEB.Trigger
{
    public partial class Default : System.Web.UI.Page
    {
        Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();
        ALR_AlertasBL _ALR_AlertasBL = new ALR_AlertasBL();
        StringBuilder Tabla = new StringBuilder();
        TRG_TriggerBL _TRG_TriggerBL = new TRG_TriggerBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            int Valor_ini = 0, Valor = 0;
            string _estilo = "";
            short _Departamento_id = 0;
            if (this.IsPostBack)
            {

            }
            else
            {
                if (Session["Fnc_Funcionarios"] == null)
                {
                    Response.Redirect("login_Trigger.aspx");
                }

                _Fnc_FuncionariosBE = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]);
                _Departamento_id = Convert.ToInt16(_Fnc_FuncionariosBE.Area_Id);
                GenerarSemaforo(_Departamento_id);
                TB_AccesosBE _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(_Fnc_FuncionariosBE.Funcionario_Id, 2);
                //Session["FUNCIONARIO_ID"] = "71046";
                DateTime Hoy = DateTime.Today;
                if (_TB_AccesosBE.Permiso > 0)
                {
                    //GenerarTabla(_TB_AccesosBE.Usuario_id, _TB_AccesosBE.Permiso);
                    lblAdministrador.Visible = true;
                    lblAdministrador.Text = "<h2>Administrador</h2><ul><li><a href='Administrador.aspx'><font face='Verdana, Arial, Helvetica, sans-serif' size='2'>Administración</font></a></li></ul>";
                }

            }

        }
        private void GenerarSemaforo(short _Departamento_id)
        {
            DataTable Resultados = _TRG_TriggerBL.TraerTRG_TriggerSemaforo(_Departamento_id);

            //DataTable Estadisticas = _TB_IncidentesBL.ListarTB_Incidentes_Estadistica(_Departamento_id, _Guardia_id,
            //    _Area_id, _Clasificacion_id, _Tipo_emp, _Rol_id,  _Fecha_incidente, _Fecha_incidente1);
            StringBuilder Tabla = new StringBuilder();
            StringBuilder TablaE = new StringBuilder();
            TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();

            string _idEtiqueta;

            int TotalRegistros = Resultados.Rows.Count;
            if (TotalRegistros > 0)
            {
                Tabla.AppendLine("<table id=\"myTable\" class=\"tablesorter\">");
                Tabla.AppendLine("<thead>");
                string cabecera = "";
                cabecera = "<th>COD.</th><th> TIME STAMP </th><th> DEPARTAMENTO </th><th width=\"110\"> GUARDIA </th><th>QUIEN</th><th> RIESGO INI. </th><th>RIESGO FIN.</th>";
                Tabla.AppendLine(cabecera);
                Tabla.AppendLine("</thead>");
                Tabla.AppendLine("<tbody>");
                int Valor, Valor_ini;
                string _estilo = "";

                //TB_AccesosBE _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id);
                //for (int i = 0; i < TotalRegistros; i++)
                //{
                _idEtiqueta = Resultados.Rows[0]["Trigger_id"].ToString();
                Tabla.AppendLine("<tr>");
                Valor = Convert.ToInt32(Resultados.Rows[0]["Valor"]);
                Valor_ini = Convert.ToInt32(Resultados.Rows[0]["Valor_Ini"]);
                Tabla.Append("<td><a href=\"#\" onClick=\"PopUp('ActualizarTriggerPopUp.aspx?Trigger_id=" + _idEtiqueta + "',20,20,950,678); return false;\"> " + _idEtiqueta + " </a></td>");
                Tabla.Append("<td>" + Resultados.Rows[0]["trigger_fecha"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[0]["Departamento_desc"] + " </td>");
                Tabla.Append("<td>" + Resultados.Rows[0]["Guardia_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[0]["Ultimo"] + "</td>");
                if (Valor_ini <= 5)
                    _estilo = "<h1><span class='verde'>" + Valor_ini + "</span></h1> ";
                else
                {
                    if (Valor_ini >= 6)
                        _estilo = "<h1><span class='amarillo'>" + Valor_ini + "</span></h1> ";
                    if (Valor_ini > 8)
                        _estilo = "<h1><span class='rojo'>" + Valor_ini + "</span></h1> ";
                }
                Tabla.Append("<td>" + _estilo + "</td>");
                if (Valor <= 5)
                    _estilo = "<h1><span class='verde'>" + Valor + "</span></h1> ";
                else
                {
                    if (Valor >= 6)
                        _estilo = "<h1><span class='amarillo'>" + Valor + "</span></h1> ";
                    if (Valor > 8)
                        _estilo = "<h1><span class='rojo'>" + Valor + "</span></h1> ";
                }
                Tabla.Append("<td>" + _estilo + "</td>");
                Tabla.Append(Environment.NewLine);
                Tabla.AppendLine("</tr>");
                //}
                Tabla.AppendLine("</tbody>");
                Tabla.AppendLine("</table>");
                Literal1.Text = Tabla.ToString();
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
                ltlTriggers.Text = Tabla.ToString();
            }
        }
    }
}