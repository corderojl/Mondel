using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB
{
    public partial class PlanPendiente : System.Web.UI.Page
    {
        TB_PlanAccionBL _TB_PlanAccionBL = new TB_PlanAccionBL();
        Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
        short _PlanAccion_id, _Tipo;
        protected void Page_Load(object sender, EventArgs e)
        {
            _PlanAccion_id = Convert.ToInt16(Request.QueryString["PlanAccion_id"]);
            _Tipo = Convert.ToInt16(Request.QueryString["Tipo"]);
            if (!this.IsPostBack)
            {
                _Fnc_FuncionariosBE = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]);
                GenerarTabla(_Fnc_FuncionariosBE.Funcionario_Id, _Tipo);
            }
        }
        protected void ibnCumplir_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            int _PlanAccion_id = int.Parse(((Label)fila.Controls[1]).Text);
            bool obeRespuesta = _TB_PlanAccionBL.CerrarTB_PlanAccion(_PlanAccion_id);
            if (obeRespuesta)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('El Plan de Acción se cerró con exito!');", true);
                GenerarTabla(((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id, _Tipo);
            }
            else
            {
            }
            //GenerarTabla(((Fnc_FuncionariosBE)Session["FNC_Funcionarios"]).Funcionario_Id);
        }
        private void GenerarTabla(Int16 _Responsable, Int16 _Tipo)
        {
            DataTable Resultados = _TB_PlanAccionBL.BuscarTB_PlanAccionPendiente(_Responsable, _Tipo);
            rpPlanAccion.DataSource = Resultados;
            rpPlanAccion.DataBind();
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ActualizoExito();", true);
        }
    }
}