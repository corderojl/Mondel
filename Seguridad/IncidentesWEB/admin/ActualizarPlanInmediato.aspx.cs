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
    public partial class ActualizarPlanInmediato : System.Web.UI.Page
    {
        int _PlanAccion_id;
        TB_PlanAccionBL _TB_PlanAccionBL = new TB_PlanAccionBL();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();

        TB_PlanAccionBE _TB_PlanAccionBE = new TB_PlanAccionBE();

        List<Fnc_FuncionariosBE> lTFnc_FuncionariosBE;
        int _Incidente_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _PlanAccion_id = Convert.ToInt32(Request.QueryString["PlanAccion_id"]);
                _Incidente_id = Convert.ToInt32(Request.QueryString["Incidente_id"]);
                if (this.IsPostBack)
                {

                }
                else
                {

                    
                    _TB_PlanAccionBE = _TB_PlanAccionBL.TraerTB_PlanAccionById(_PlanAccion_id);
                    LlenarComboResponsable(_TB_PlanAccionBE.Responsable);
                    txtFecha.Text = _TB_PlanAccionBE.Fecha.ToString("dd/MM/yyyy");
                    txtPlan.Text = _TB_PlanAccionBE.PlanAccion_desc;
                    chbCumplido.Checked = _TB_PlanAccionBE.Estado;
                    _Incidente_id = _TB_PlanAccionBE.Registro_id;
                }
            }
            catch (Exception x)
            {
                // Response.Redirect("error.aspx");
            }
        }

        private void LlenarComboResponsable(int _Responsable)
        {
            lTFnc_FuncionariosBE = _Fnc_FuncionariosBL.ListarFnc_FuncionariosO_Act();
            ddlResponsable.DataSource = lTFnc_FuncionariosBE;
            ddlResponsable.DataValueField = "Funcionario_id";
            ddlResponsable.DataTextField = "Funcionario_nome";
            ddlResponsable.DataBind();
            ddlResponsable.SelectedValue = _Responsable.ToString();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            _TB_PlanAccionBE.PlanAccion_id = _PlanAccion_id;
            _TB_PlanAccionBE.Fecha = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null);
            _TB_PlanAccionBE.Registro_id = _Incidente_id;
            _TB_PlanAccionBE.PlanAccion_desc = txtPlan.Text;
            _TB_PlanAccionBE.Responsable = Convert.ToInt32(ddlResponsable.SelectedValue);
            _TB_PlanAccionBE.Estado = chbCumplido.Checked;
            if (_TB_PlanAccionBL.ActualizarTB_PlanAccion(_TB_PlanAccionBE))
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ActualizoExito();cerrarYActualizar();", true);
            else
                Response.Write("<script language=javascript>alert('ERROR');</script>");
        
        }
    }
}