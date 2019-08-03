using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IncidentesBL;
using IncidentesBE;

namespace IncidentesWEB.LUPs
{
    public partial class Login : System.Web.UI.Page
    {
        Fnc_FuncionariosBL _fnc_funcionarioBL = new Fnc_FuncionariosBL();
        Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            _Fnc_FuncionariosBE = _fnc_funcionarioBL.LoguearFuncionario(txtUsuario.Text, txtContrasena.Text);
            if (_Fnc_FuncionariosBE.Funcionario_Id > 0)
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