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
    public partial class Administrador : System.Web.UI.Page
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
                    Response.Redirect("login_Alertas.aspx");
                }
                
                _Fnc_FuncionariosBE = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]);
                //TB_AccesosBE _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(_Fnc_FuncionariosBE.Funcionario_Id, 2);
                //Session["FUNCIONARIO_ID"] = "71046";
                DateTime Hoy = DateTime.Today;
                //if (_TB_AccesosBE.Permiso > 0)
                //    GenerarTabla(_TB_AccesosBE.Usuario_id, _TB_AccesosBE.Permiso);
            }

        }
    }
}