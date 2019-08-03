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
    public partial class RegistrarPlanAccion : System.Web.UI.Page
    {
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TB_PlanAccionBL _TB_PlanAccionBL = new TB_PlanAccionBL();

        TB_PlanAccionBE _TB_PlanAccionBE = new TB_PlanAccionBE();

        List<Fnc_FuncionariosBE> lTFnc_FuncionariosBE;

        int _Registro_id;
        string fecha_actual;

        protected void Page_Load(object sender, EventArgs e)
        {
            _Registro_id = Convert.ToInt32(Request.QueryString["Registro_id"]);
            if (this.IsPostBack)
            {

            }
            else
            {
                _Registro_id = Convert.ToInt32(Request.QueryString["Registro_id"]);
                DateTime Hoy = DateTime.Today;
                fecha_actual = Hoy.ToString("dd/MM/yyyy");
                txtFecha.Text = fecha_actual;
                LlenarComboResponsable();
                ddlResponsable.SelectedValue = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id.ToString();
            }
        }

        private void LlenarComboResponsable()
        {
            lTFnc_FuncionariosBE = _Fnc_FuncionariosBL.ListarFnc_FuncionariosO_Act();
            ddlResponsable.DataSource = lTFnc_FuncionariosBE;
            ddlResponsable.DataValueField = "Funcionario_id";
            ddlResponsable.DataTextField = "Funcionario_nome";
            ddlResponsable.DataBind();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string _Asignado = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Nome.ToString();
            string _Titulo = "";
            _TB_PlanAccionBE.Fecha = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null);
            _TB_PlanAccionBE.Registro_id = _Registro_id;
            _TB_PlanAccionBE.PlanAccion_desc = txtPlan.Text;
            _TB_PlanAccionBE.Responsable = Convert.ToInt32(ddlResponsable.SelectedValue);
            _TB_PlanAccionBE.tipoPlan = Convert.ToInt16(Request.QueryString["tipoPlan"]);
            _TB_PlanAccionBE.Estado = chbCumplido.Checked;
            _TB_PlanAccionBE.Sistema_id = Convert.ToInt16(Request.QueryString["Sistema_id"]);

            if (_TB_PlanAccionBL.InsertarTB_PlanAccion(_TB_PlanAccionBE))
            {
                _Titulo = traerTitulo(_TB_PlanAccionBE.Registro_id, _TB_PlanAccionBE.Sistema_id);
                enviarEmail(_TB_PlanAccionBE.Registro_id, _Titulo, _TB_PlanAccionBE.tipoPlan, txtFecha.Text, txtPlan.Text, _Asignado);
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ActualizoExito();cerrarYActualizar();", true);
            }
            else
                Response.Write("<script language=javascript>alert('ERROR');</script>");
        }
        public void enviarEmail(int _Id, string _Titulo, int _TipoPlan, string _Fecha, string _Plan, string _Asignado)
        {
            Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
            MailBL _MailBL = new MailBL();
            _Fnc_FuncionariosBE = _Fnc_FuncionariosBL.TraerFnc_Funcionario(int.Parse(ddlResponsable.SelectedValue));
            string _BodyHTML = _MailBL.doBodyPlan(_Id, _Titulo, _TipoPlan, _Fecha, _Plan, _Asignado);
            _MailBL.sndMailHeader(_Fnc_FuncionariosBE.Funcionario_Email, _BodyHTML, "Plan de Acción para el Incidente N° " + _Id);
        }
        public string traerTitulo(int _registro_id, short _sistema_id)
        {
            string titulo="";
            switch(_sistema_id)
            {
                case 1:
                    TB_IncidentesBL _TB_IncidentesBL = new TB_IncidentesBL();
                    titulo = _TB_IncidentesBL.TraerTB_IncidentesById(_registro_id).Descripcion;
                    break;
                case 2:
                    ALR_AlertasBL _ALR_AlertasBL = new ALR_AlertasBL();
                    titulo = _ALR_AlertasBL.TraerALR_AlertasById(_registro_id).Alerta_desc;
                    break;
                case 4:
                    TRG_RiesgosBL _TRG_RiesgosBL= new TRG_RiesgosBL();
                    titulo = _TRG_RiesgosBL.TraerTRG_RiesgosById(_registro_id).Riesgo_desc;
                    break;
                //case 4:
                //    AUD_Auditoria_PreguntaBL _AUD_Auditoria_PreguntaBL= new AUD_Auditoria_PreguntaBL();
                //    titulo = _AUD_Auditoria_PreguntaBL.TraerAUD_Auditoria_PreguntaById(_registro_id).;
                //    break;
            }
            return titulo;
        }
    }
}