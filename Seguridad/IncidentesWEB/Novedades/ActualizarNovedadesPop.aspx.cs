using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.Novedades
{
    public partial class ActualizarNovedadesPop : System.Web.UI.Page
    {
        Fnc_FuncionariosBE _Fnc_FuncionariosBE = null;
        TB_AccesosBE _TB_AccesosBE = null;
        TB_AccesosBL _TB_AccesosBL = null;
        NOV_NovedadesBE _NOV_NovedadesBE = null;
        NOV_NovedadesBL _NOV_NovedadesBL = new NOV_NovedadesBL();
        int _Novedades_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            _TB_AccesosBE = new TB_AccesosBE();
            _TB_AccesosBL = new TB_AccesosBL();

            if (Session["Fnc_Funcionarios"] == null)
            {
                Response.Redirect("login_Novedades.aspx");
            }
            else
            {
                _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(_Fnc_FuncionariosBE.Funcionario_Id, 6);
                if (_TB_AccesosBE.Permiso != 1)
                    Response.Redirect("login_Novedades.aspx?men=1");
                else
                {
                    _Novedades_id = Convert.ToInt32(Request.QueryString["Novedades_id"]);
                    _NOV_NovedadesBE=new NOV_NovedadesBE();
                    _NOV_NovedadesBE = _NOV_NovedadesBL.TraerNOV_NovedadesById(_Novedades_id);
                    txtTitulo.Text = _NOV_NovedadesBE.Titulo;
                    txtDescripcion.Text = _NOV_NovedadesBE.Descripcion;
                    imgFoto.ImageUrl = _NOV_NovedadesBE.Foto;
                }
            }
            if (!this.IsPostBack)
            {
                if (Session["Fnc_Funcionarios"] == null)
                {
                    Response.Redirect("login_Novedades.aspx");
                }
                _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
                _Fnc_FuncionariosBE = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]);
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}