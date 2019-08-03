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

namespace IncidentesWEB.LUPs
{
    public partial class Default : System.Web.UI.Page
    {
        Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();
        LUP_AprobadorBL _LUP_AprobadorBL = new LUP_AprobadorBL();
        TB_AccesosBE _TB_AccesosBE = new TB_AccesosBE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Fnc_Funcionarios"] == null)
            {
                Response.Redirect("login.aspx");
            }
            _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
            _Fnc_FuncionariosBE = (Fnc_FuncionariosBE)Session["Fnc_Funcionarios"];
            _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(_Fnc_FuncionariosBE.Funcionario_Id, 8);
            if (!this.IsPostBack)
            {   
                StringBuilder Tabla = new StringBuilder();
                List<Fnc_FuncionariosBE> ltFuncionariosLider;
                ltFuncionariosLider = _Fnc_FuncionariosBL.ListarFNC_FuncionariosLideresO_Act();
                switch (_TB_AccesosBE.Permiso)
                {
                    case 1:
                        Tabla.AppendLine("<h2>Opciones</h2><ul>");
                        Tabla.AppendLine("<ul> <li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='RegistrarLup.aspx'>Registrar LUP</a></font></li></ul>");
                        Tabla.AppendLine("<h2>Reportes</h2>");
                        Tabla.AppendLine("<ul><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='ReporteLups.aspx'>Reporte de LUP's</a></font></li></ul>");
                        Tabla.AppendLine("<h2>Administración</h2>");
                        Tabla.AppendLine("<ul><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='AdministracionFuncionarios.aspx'>Administrar Empleados</a></font></li><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='Administrador.aspx'>Administrador General</a></font></li><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'> <a href=\"#\" onClick=\"materialConfirm('Title','Content',function(result){console.log(result)});\">Cambiar contraseña</a></font></li></ul>");
                        break;
                    case 2: Tabla.AppendLine("<h2>Opciones</h2><ul>");
                        Tabla.AppendLine("<ul> <li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='RegistrarLup.aspx'>Registrar LUP</a></font></li></ul>");
                        Tabla.AppendLine("<h2>Reportes</h2>");
                        Tabla.AppendLine("<ul><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='ReporteLups.aspx'>Reporte de LUP's</a></font></li></ul>");
                        Tabla.AppendLine("<h2>Administración</h2>");
                        Tabla.AppendLine("<ul><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='AdministracionFuncionarios.aspx'>Administrar Empleados</a></font></li><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='Administrador.aspx'>Administrador General</a></font></li><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'> <a href=\"#\" onClick=\"materialConfirm('Title','Content',function(result){console.log(result)});\">Cambiar contraseña</a></font></li></ul>");
                        break;
                    default:
                        Tabla.AppendLine("<h2>Opciones</h2><ul>");
                        Tabla.AppendLine("<ul> <li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='RegistrarLup.aspx'>Registrar LUP</a></font></li></ul>");
                        Tabla.AppendLine("<h2>Reportes</h2>");
                        Tabla.AppendLine("<ul><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='ReporteLups.aspx'>Reporte de LUP's</a></font></li></ul>");
                        Tabla.AppendLine("<h2>Administración</h2>");
                        Tabla.AppendLine("<ul><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'> <a href=\"#\" onClick=\"materialConfirm('Title','Content',function(result){console.log(result)});\">Cambiar contraseña</a></font></li></ul>");
                        break;

                }
                ltlMenu.Text = Tabla.ToString();

                GenerarTabla(_Fnc_FuncionariosBE.Funcionario_Id, _TB_AccesosBE.Permiso);
                if (_Fnc_FuncionariosBL.comprobarFnc_FuncionariosPassword(_Fnc_FuncionariosBE.Funcionario_Id))
                {
                    string script = @"<script type='text/javascript'>materialConfirm('Title','Content',function(result){console.log(result)});</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
            }

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!_Fnc_FuncionariosBL.cambiarFnc_FuncionariosPassword(_Fnc_FuncionariosBE.Funcionario_Id, txtPassword1.Text))
            {
                String mensaje = "<script language='JavaScript'>window.alert('Hubo un error al modificar contraseña, por favor contacte al administrador')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
            else
            {
                string script = @"<script type='text/javascript'>materialConfirm('Title','Content',function(result){console.log(result)});</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
            }

        }

        private void GenerarTabla(int _Usuario_id, Int16 _Permiso)
        {

            DataTable Resultados = _LUP_AprobadorBL.BuscarLUP_AprobadorPendiente(_Usuario_id, _Permiso);
            StringBuilder Tabla = new StringBuilder();

            string _idEtiqueta;

            int TotalRegistros = Resultados.Rows.Count;
            if (TotalRegistros != 0)
            {
                Tabla.AppendLine("<h2>LUP's pendientes de aprobación:</h2>");
                Tabla.AppendLine("<table id=\"myTable\" class=\"tablesorter\">");
                Tabla.AppendLine("<thead>");
                string cabecera = "";
                cabecera = "<th>COD.</th><th width=\"110\"> TITULO </th><th>APROBADOR</th><th> ÁREA. </th><th> PILAR </th><th>FECH. REG.</th><th> ESTADO </th>";

                Tabla.AppendLine(cabecera);
                Tabla.AppendLine("</thead>");
                Tabla.AppendLine("<tbody>");
                int Nro = 0;
                string _estilo = "";
                for (int i = 0; i < TotalRegistros; i++)
                {
                    Nro = i + 1;
                    _idEtiqueta = Resultados.Rows[i]["Lup_id"].ToString();
                    Tabla.AppendLine("<tr>");
                    Tabla.Append("<td" + _estilo + ">" + "<a href=\"#\" onClick=\"PopUp('ActualizarLupPop.aspx?Lup_id=" + _idEtiqueta + "',20,20,950,678); return false;\"> " + _idEtiqueta + " </a></td>");
                    Tabla.Append("<td" + _estilo + ">" + "<a href=\"ActualizarLup.aspx?reg=&Lup_id=" + _idEtiqueta + "\" > " + Resultados.Rows[i]["Lup_Titulo"] + " </a></td>");
                    Tabla.Append("<td>" + Resultados.Rows[i]["FUNCIONARIO_NOME"] + "</td>");
                    Tabla.Append("<td>" + Resultados.Rows[i]["Departamento_desc"] + "</td>");
                    Tabla.Append("<td>" + Resultados.Rows[i]["Pilar_desc"] + "</td>");
                    Tabla.Append("<td>" + Resultados.Rows[i]["Fecha_reg"] + "</td>");
                    Tabla.Append("<td>" + Resultados.Rows[i]["Estado"] + "</td>");
                    Tabla.Append(Environment.NewLine);
                    Tabla.AppendLine("</tr>");
                }
                Tabla.AppendLine("</tbody>");
                Tabla.AppendLine("</table>");
                ltlPendiente.Text = Tabla.ToString();
            }


        }
    }
}