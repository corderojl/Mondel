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
    public partial class ActualizarPlanAccion : System.Web.UI.Page
    {
        int _PlanAccion_id;
        TB_PlanAccionBL _TB_PlanAccionBL = new TB_PlanAccionBL();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();
        TB_PlanAccionBE _TB_PlanAccionBE = new TB_PlanAccionBE();
        Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
        TRG_Trigger_RiesgosBE _TRG_Trigger_RiesgosBE = new TRG_Trigger_RiesgosBE();
        List<Fnc_FuncionariosBE> lTFnc_FuncionariosBE;
        int _Registro_id;
        Int16 _Sistema_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _PlanAccion_id = Convert.ToInt32(Request.QueryString["PlanAccion_id"]);
                _Registro_id = Convert.ToInt32(Request.QueryString["Registro_id"]);
                _Sistema_id = Convert.ToInt16(Request.QueryString["Sistema_id"]);
                if (!this.IsPostBack)
                {
                    _Fnc_FuncionariosBE = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]);
                    TB_AccesosBE _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(_Fnc_FuncionariosBE.Funcionario_Id, _Sistema_id);
                    DateTime Hoy = DateTime.Today;
                    if (_TB_AccesosBE.Permiso == 1)
                    {
                        txtFecha.Enabled = true;
                        btnEliminar.Visible = true;
                    }
                    _TB_PlanAccionBE = _TB_PlanAccionBL.TraerTB_PlanAccionById(_PlanAccion_id);
                    LlenarComboResponsable(_TB_PlanAccionBE.Responsable);
                    txtFecha.Text = _TB_PlanAccionBE.Fecha.ToString("dd/MM/yyyy");
                    txtPlan.Text = _TB_PlanAccionBE.PlanAccion_desc;
                    chbCumplido.Checked = _TB_PlanAccionBE.Estado;
                    _Registro_id = _TB_PlanAccionBE.Registro_id;
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
            TRG_Trigger_RiesgosBL _TRG_Trigger_RiesgosBL=new TRG_Trigger_RiesgosBL();
            _TB_PlanAccionBE.PlanAccion_id = _PlanAccion_id;
            _TB_PlanAccionBE.Fecha = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null);
            _TB_PlanAccionBE.Registro_id = _Registro_id;
            _TB_PlanAccionBE.PlanAccion_desc = txtPlan.Text;
            _TB_PlanAccionBE.Responsable = Convert.ToInt32(ddlResponsable.SelectedValue);
            _TB_PlanAccionBE.Estado = chbCumplido.Checked;
 
            if (_TB_PlanAccionBL.ActualizarTB_PlanAccion(_TB_PlanAccionBE))
            {
                if (_TB_PlanAccionBL.ContarTB_PlanAccionByRegistro(_Registro_id, Convert.ToInt16(Request.QueryString["Sistema_id"])) == 0)
                {
                    if (_Sistema_id == 4)
                    {
                        _TRG_Trigger_RiesgosBE.Estado = false;
                        _TRG_Trigger_RiesgosBE.Trigger_id = Convert.ToInt32(Request.QueryString["Trigger_id"]);
                        _TRG_Trigger_RiesgosBE.Registro_id = _Registro_id;
                        _TRG_Trigger_RiesgosBE.Usuario_update = ((Fnc_FuncionariosBE)Session["FNC_Funcionarios"]).Funcionario_Id;
                        if (_TRG_Trigger_RiesgosBL.ActualizarTRG_Trigger_RiesgosFin(_TRG_Trigger_RiesgosBE))
                        {
                        }
                    }
                }
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ActualizoExito();cerrarYActualizar();", true);
            }
            else
                Response.Write("<script language=javascript>alert('ERROR');</script>");

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_TB_PlanAccionBL.EliminarTB_PlanAccion(_PlanAccion_id))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ActualizoExito();cerrarYActualizar();", true);
            }
            else
                Response.Write("<script language=javascript>alert('ERROR');</script>");
        }
    }
}