
using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace defectosView.Indicadores.controldefectos
{
    public partial class login_defectos : System.Web.UI.Page
    {
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            _Fnc_FuncionariosBE = _Fnc_FuncionariosBL.LoguearFuncionario(txtUsuario.Text, txtContrasena.Text);
            if (_Fnc_FuncionariosBE.Funcionario_Id >0)
            {
                Session["Fnc_Funcionarios"] = _Fnc_FuncionariosBE;
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblMensaje.Text = "Usuario o Contraseña incorrectas";
            }
        }
    }
}