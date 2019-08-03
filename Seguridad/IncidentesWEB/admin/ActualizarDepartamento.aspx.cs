using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.admin
{
    public partial class ActualizarDepartamento : System.Web.UI.Page
    {
        int _funcionario_id;
        TB_DepartamentoBE _TB_DepartamentoBE = new TB_DepartamentoBE();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();

        Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
        
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TB_GuardiaBL _TB_GuardiaBL = new TB_GuardiaBL();
        List<TB_GuardiaBE> lTTB_GuardiaBE;
        private List<TB_GuardiaBE> lbeFiltroGuardia;

        TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                _funcionario_id = Convert.ToInt32(Request.QueryString["funcionario_id"]);
                _Fnc_FuncionariosBE = _Fnc_FuncionariosBL.TraerFnc_Funcionario(_funcionario_id);
                lTTB_GuardiaBE = _TB_GuardiaBL.ListarTB_GuardiaO_Act();
                Session["Guardias"] = lTTB_GuardiaBE;
                lblLegajo.Text = _Fnc_FuncionariosBE.Funcionario_Drt;
                lblApellido.Text = _Fnc_FuncionariosBE.Funcionario_Nome;
                LlenarComboDepartamento();
                ddlDepartamento.SelectedValue = _Fnc_FuncionariosBE.Area_Id.ToString();
                LlenarComboGuardia();
                ddlGuardia.SelectedValue = _Fnc_FuncionariosBE.Grupo_Id.ToString();
                _Fnc_FuncionariosBE = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]);
                TB_AccesosBE _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(_Fnc_FuncionariosBE.Funcionario_Id, 1);
                //Session["FUNCIONARIO_ID"] = "71046";
                DateTime Hoy = DateTime.Today;
                if (_TB_AccesosBE.Permiso == 1)
                    btnEliminar.Visible = true;
            }
        }

        private void LlenarComboDepartamento()
        {
            ddlDepartamento.DataSource = _TB_DepartamentoBL.ListarTB_DepartamentoO_Act("%%");;
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        private bool buscarGuardias(TB_GuardiaBE obeGuardia)
        {
            bool exitoIdGuardia = true;
            if (!ddlDepartamento.SelectedValue.Equals("0")) exitoIdGuardia = (obeGuardia.Departamento_id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdGuardia);
        }

        private void LlenarComboGuardia()
        {
            lTTB_GuardiaBE = (List<TB_GuardiaBE>)Session["Guardias"];
            Predicate<TB_GuardiaBE> pred = new Predicate<TB_GuardiaBE>(buscarGuardias);
            lbeFiltroGuardia = lTTB_GuardiaBE.FindAll(pred);
            Session["Filtro"] = lbeFiltroGuardia;

            ddlGuardia.DataSource = lbeFiltroGuardia;
            ddlGuardia.DataValueField = "Guardia_id";
            ddlGuardia.DataTextField = "Guardia_desc";
            ddlGuardia.DataBind();
            ddlGuardia.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboGuardia();
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            short _Departamento_id, _Guardia_id, _Funcionario_id;
            _Departamento_id=Convert.ToInt16(ddlDepartamento.SelectedValue);
            _Guardia_id=Convert.ToInt16(ddlGuardia.SelectedValue);
            _Funcionario_id=Convert.ToInt16(Request.QueryString["funcionario_id"]);

            if (_Fnc_FuncionariosBL.ActualizarFnc_FuncionariosGuardia(_Departamento_id, _Guardia_id, _Funcionario_id))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ActualizoExito();cerrarYActualizar();", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('Error al actualizar registro, contactate con el administrador.');", true);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            _funcionario_id = Convert.ToInt32(Request.QueryString["funcionario_id"]);
            if(_Fnc_FuncionariosBL.DeshabilitarFuncionario(_funcionario_id))
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ActualizoExito();cerrarYActualizar();", true);
            else
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('Error al actualizar registro, contactate con el administrador.');", true);
        }
    }
}