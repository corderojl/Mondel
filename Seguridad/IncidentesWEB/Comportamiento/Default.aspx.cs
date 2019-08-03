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

namespace IncidentesWEB.Comportamiento
{
    public partial class Default : System.Web.UI.Page
    {
        Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();
        TB_IncidentesBL _TB_IncidentesBL = new TB_IncidentesBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["Fnc_Funcionarios"] == null)
                {
                    Response.Redirect("login_incidentes.aspx");
                }

                _Fnc_FuncionariosBE = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]);
                TB_AccesosBE _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(_Fnc_FuncionariosBE.Funcionario_Id,3);
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
                Tabla.AppendLine("<li><a href=\"../admin/AdministracionFuncionarios.aspx\"><font face=\"Verdana, Arial, Helvetica, sans-serif\" size=\"2\">Administrar Empleado</font></a></li>");
                Tabla.AppendLine("<li><a href=\"Administrador.aspx\"><font face=\"Verdana, Arial, Helvetica, sans-serif\" size=\"2\">Administrador General</font></a></li>");
          
                
                ltlIncidentes.Text = Tabla.ToString();
            }
        }
    }
}