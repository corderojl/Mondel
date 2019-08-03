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

namespace IncidentesWEB.Indicadores
{
    public partial class Default : System.Web.UI.Page
    {
        Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();
        TB_IncidentesBL _TB_IncidentesBL = new TB_IncidentesBL();
        TB_AccesosBE _TB_AccesosBE = new TB_AccesosBE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Fnc_Funcionarios"] == null)
            {
                Response.Redirect("login_incidentes.aspx");
            }
            _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
            _Fnc_FuncionariosBE = (Fnc_FuncionariosBE)Session["Fnc_Funcionarios"];
            if (!this.IsPostBack)
            {
                _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id, 7);
                StringBuilder Tabla = new StringBuilder();
                List<Fnc_FuncionariosBE> ltFuncionariosLider;
                ltFuncionariosLider = _Fnc_FuncionariosBL.ListarFNC_FuncionariosLideresO_Act();
                switch (_TB_AccesosBE.Permiso)
                {
                    case 1:
                        Tabla.AppendLine("<h2>Opciones</h2><ul>");
                        Tabla.AppendLine("<ul> <li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='RegistrarEvaluacion.aspx'>Evaluar Colega</a></font></li></ul>");
                        Tabla.AppendLine("<h2>Reportes</h2>");
                        Tabla.AppendLine("<ul><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='ReporteIndicadores.aspx'>Reporte de Evaluaciones</a></font></li><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='ReporteCurva.aspx'>Grafica de Curva</a></font></li></ul>");
                        Tabla.AppendLine("<h2>Administración</h2>");
                        Tabla.AppendLine("<ul><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='AdministracionFuncionarios.aspx'>Administrar Empleados</a></font></li><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'> <a href=\"#\" onClick=\"materialConfirm('Title','Content',function(result){console.log(result)});\">Cambiar contraseña</a></font></li></ul>");
                        break;
                    case 2: Tabla.AppendLine("<h2>Opciones</h2><ul>");
                        Tabla.AppendLine("<ul> <li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='RegistrarEvaluacion.aspx'>Evaluar Colega</a></font></li></ul>");
                        Tabla.AppendLine("<h2>Reportes</h2>");
                        Tabla.AppendLine("<ul><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='ReporteIndicadores.aspx'>Reporte de Evaluaciones</a></font></li><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='ReporteCurva.aspx'>Grafica de Curva</a></font></li></ul>");
                        Tabla.AppendLine("<h2>Administración</h2>");
                        Tabla.AppendLine("<ul><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='AdministracionFuncionarios.aspx'>Administrar Empleados</a></font></li><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'> <a href=\"#\" onClick=\"materialConfirm('Title','Content',function(result){console.log(result)});\">Cambiar contraseña</a></font></li></ul>");
                        break;
                    default:
                        if (_Fnc_FuncionariosBL.Contenido(ltFuncionariosLider,_Fnc_FuncionariosBE))
                        {
                            Tabla.AppendLine("<h2>Opciones</h2><ul>");
                            Tabla.AppendLine("<ul> <li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='RegistrarEvaluacion.aspx'>Evaluar Colega</a></font></li></ul>");
                            Tabla.AppendLine("<h2>Reportes</h2>");
                            Tabla.AppendLine("<ul><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='ReporteIndicadores.aspx'>Reporte de Evaluaciones</a></font></li><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='ReporteCurva.aspx'>Grafica de Curva</a></font></li></ul>");
                            Tabla.AppendLine("<h2>Administración</h2>");
                            Tabla.AppendLine("<ul><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='AdministracionFuncionarios.aspx'>Administrar Empleados</a></font></li><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'> <a href=\"#\" onClick=\"materialConfirm('Title','Content',function(result){console.log(result)});\">Cambiar contraseña</a></font></li></ul>");  
                        }
                        else
                        {
                            //Tabla.AppendLine("<h2>Reportes</h2>");
                            //Tabla.AppendLine("<ul><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='ReporteIndicadores.aspx'>Reporte de Evaluaciones</a></font></li><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'><a href='ReporteCurva.aspx'>Grafica de Curva</a></font></li></ul>");
                            Tabla.AppendLine("<h2>Administración</h2>");
                            Tabla.AppendLine("<ul><li><font face='Verdana, Arial, Helvetica, sans-serif' size='2'> <a href=\"#\" onClick=\"materialConfirm('Title','Content',function(result){console.log(result)});\">Cambiar contraseña</a></font></li></ul>");
                        }
                        break;

                }
                ltlMenu.Text = Tabla.ToString();
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





    }
}