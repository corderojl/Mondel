using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.Auditoria
{
    public partial class RegistrarAuditoria : System.Web.UI.Page
    {
        string fecha_actual;

        AUD_AuditoriaBE _AUD_AuditoriaBE = new AUD_AuditoriaBE();

        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        AUD_AuditoriaBL _AUD_AuditoriaBL = new AUD_AuditoriaBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_GuardiaBL _TB_GuardiaBL = new TB_GuardiaBL();
        TB_AreaBL _TB_AreaBL = new TB_AreaBL();
        AUD_AuditoriaTipoBL _AUD_AuditoriaTipoBL = new AUD_AuditoriaTipoBL();
        COM_ComportamientoBL _COM_ComportamientoBL = new COM_ComportamientoBL();

        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<TB_GuardiaBE> lTTB_GuardiaBE;
        List<TB_AreaBE> lTTB_AreaBE;
        List<Fnc_FuncionariosBE> lTOperador;
        List<AUD_AuditoriaTipoBE> lTAUD_AuditoriaTipoBE;
        private List<TB_GuardiaBE> lbeFiltroGuardia;
        private List<TB_AreaBE> lbeFiltroArea;
        private List<Fnc_FuncionariosBE> lbeFiltroOperador;
        private List<AUD_AuditoriaTipoBE> lbeFiltroAuditoriaTipo;

        int _area_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime Hoy = DateTime.Today;
                fecha_actual = Hoy.ToString("dd/MM/yyyy");
                if (this.IsPostBack)
                {
                    _area_id = Convert.ToInt32(Session["AREA_ID"]);
                }
                else
                {
                    _area_id = Convert.ToInt32(Session["AREA_ID"]);
                    //Session["FUNCIONARIO_ID"] = "71046";

                    txtFecha.Text = fecha_actual;
                    lTTB_GuardiaBE = _TB_GuardiaBL.ListarTB_GuardiaO_Act();
                    Session["Guardias"] = lTTB_GuardiaBE;
                    lTTB_AreaBE = _TB_AreaBL.ListarTB_AreaO_Act();
                    Session["Area"] = lTTB_AreaBE;
                    lTOperador = _Fnc_FuncionariosBL.ListarFnc_FuncionariosO_Act();
                    Session["Operador"] = lTOperador;

                    //lTAUD_AuditoriaTipoBE = _AUD_AuditoriaTipoBL.ListarAUD_AuditoriaTipoO_Act();
                    //Session["AuditoriaTipo"] = lTAUD_AuditoriaTipoBE;
                    LlenarComboDepartamento();
                    ddlDepartamento.SelectedValue = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Area_Id.ToString();
                    LlenarComboGuardia();
                    LlenarComboArea();
                    LlenarComboOperador();
                    LlenarComboAuditoriaTipo();
                }
            }
            catch (Exception x)
            {
                // Response.Redirect("error.aspx");
            }
        }

        private void LlenarComboAuditoriaTipo()
        {
            lbeFiltroAuditoriaTipo = _AUD_AuditoriaTipoBL.ListarAUD_AuditoriaTipoO_Act(); 
            //Session["Filtro"] = lbeFiltroGuardia;

            ddlAuditoria.DataSource = lbeFiltroAuditoriaTipo;
            ddlAuditoria.DataValueField = "AuditoriaTipo_id";
            ddlAuditoria.DataTextField = "Auditoria_desc";
            ddlAuditoria.DataBind();
            ddlAuditoria.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboGuardia();
            LlenarComboArea();
            LlenarComboOperador();
            LlenarComboAuditoriaTipo();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                var _mietq_etiqueta = _AUD_AuditoriaBE;
                _mietq_etiqueta.Fecha_Auditoria = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null);
                _mietq_etiqueta.Departamento_id = Convert.ToInt16(ddlDepartamento.SelectedValue);
                _mietq_etiqueta.Guardia_id = Convert.ToInt16(ddlGuardia.SelectedValue);
                _mietq_etiqueta.Area_id = Convert.ToInt16(ddlArea.SelectedValue);
                _mietq_etiqueta.Operador = Convert.ToInt16(ddlOperador.SelectedValue);
                _mietq_etiqueta.Originador = Convert.ToInt16(((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id);
                _mietq_etiqueta.AuditoriaTipo_id = Convert.ToInt16(ddlAuditoria.SelectedValue);
                _mietq_etiqueta.Activo = true;
                int vexito = _AUD_AuditoriaBL.InsertarAUD_Auditoria(_AUD_AuditoriaBE);
                if (vexito != 0)
                {

                    RegistrarPlan(_mietq_etiqueta.Fecha_Auditoria, vexito, "Rebizar la auditoria N° " + vexito + "en la web de auditoria", _mietq_etiqueta.Operador);
                    Response.Redirect("ActualizarAuditoria.aspx?Auditoria_id=" + vexito + "&reg=exito");
                }
                else
                {
                    Response.Redirect("error.aspx?error=" + vexito);
                }

            }
            catch (Exception ex)
            {
                //lblMensaje.Text = ex.ToString();
            }
        }
        private void RegistrarPlan(DateTime _Fecha, int _Registro_id, string _PlanAccion_desc,int _Responsable_id)
        {
            TB_PlanAccionBL _TB_PlanAccionBL =new TB_PlanAccionBL();
            TB_PlanAccionBE _TB_PlanAccionBE =new TB_PlanAccionBE();

            string _Asignado = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Nome.ToString();
            _TB_PlanAccionBE.Fecha = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null);
            _TB_PlanAccionBE.Registro_id = _Registro_id;
            _TB_PlanAccionBE.PlanAccion_desc = _PlanAccion_desc;
            _TB_PlanAccionBE.Responsable = _Responsable_id;
            _TB_PlanAccionBE.tipoPlan = 1;
            _TB_PlanAccionBE.Estado = false;
            _TB_PlanAccionBE.Sistema_id = 5;

            if (_TB_PlanAccionBL.InsertarTB_PlanAccion(_TB_PlanAccionBE))
            {
                enviarEmail(_TB_PlanAccionBE.Registro_id, _PlanAccion_desc, 1, _TB_PlanAccionBE.Fecha.ToString(), _TB_PlanAccionBE.PlanAccion_desc, _Asignado);
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ActualizoExito();cerrarYActualizar();", true);
            }
            else
                Response.Write("<script language=javascript>alert('ERROR');</script>");
        }
        private void LlenarComboDepartamento()
        {
            lTTB_DepartamentoBE = _TB_DepartamentoBL.ListarTB_DepartamentoO_Act("%%");;
            ddlDepartamento.DataSource = lTTB_DepartamentoBE;
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
        private bool buscarArea(TB_AreaBE obeArea)
        {
            bool exitoIdSistemaQA = true;
            if (!ddlDepartamento.SelectedValue.Equals("0")) exitoIdSistemaQA = (obeArea.Departamento_id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdSistemaQA);
        }
        private bool buscarOperador(Fnc_FuncionariosBE obeOperador)
        {
            bool exitoIdSistemaQA = true;
            if (!ddlDepartamento.SelectedValue.Equals("0")) exitoIdSistemaQA = (obeOperador.Area_Id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdSistemaQA);
        }
        private void LlenarComboGuardia()
        {
            lTTB_GuardiaBE = (List<TB_GuardiaBE>)Session["Guardias"];
            Predicate<TB_GuardiaBE> pred = new Predicate<TB_GuardiaBE>(buscarGuardias);
            lbeFiltroGuardia = lTTB_GuardiaBE.FindAll(pred);
            //Session["Filtro"] = lbeFiltroGuardia;

            ddlGuardia.DataSource = lbeFiltroGuardia;
            ddlGuardia.DataValueField = "Guardia_id";
            ddlGuardia.DataTextField = "Guardia_desc";
            ddlGuardia.DataBind();
            ddlGuardia.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        private void LlenarComboArea()
        {
            lTTB_AreaBE = (List<TB_AreaBE>)Session["Area"];
            Predicate<TB_AreaBE> pred = new Predicate<TB_AreaBE>(buscarArea);
            lbeFiltroArea= lTTB_AreaBE.FindAll(pred);
            //Session["Filtro"] = lbeFiltroArea;

            ddlArea.DataSource = lbeFiltroArea;
            ddlArea.DataValueField = "Area_id";
            ddlArea.DataTextField = "Area_desc";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        private void LlenarComboOperador()
        {
            lTOperador = (List<Fnc_FuncionariosBE>)Session["Operador"];
            Predicate<Fnc_FuncionariosBE> pred = new Predicate<Fnc_FuncionariosBE>(buscarOperador);
            lbeFiltroOperador = lTOperador.FindAll(pred);
            //Session["Filtro"] = lbeFiltroGuardia;
            ddlOperador.DataSource = lbeFiltroOperador;
            ddlOperador.DataValueField = "Funcionario_id";
            ddlOperador.DataTextField = "Funcionario_nome";
            ddlOperador.DataBind();
            ddlOperador.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        public void enviarEmail(int _Id, string _Titulo, int _TipoPlan, string _Fecha, string _Plan, string _Asignado)
        {
            Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
            MailBL _MailBL = new MailBL();
            _Fnc_FuncionariosBE = _Fnc_FuncionariosBL.TraerFnc_Funcionario(int.Parse(ddlOperador.SelectedValue));
            string _BodyHTML = _MailBL.doBodyPlan(_Id, _Titulo, _TipoPlan, _Fecha, _Plan, _Asignado);
            _MailBL.sndMailHeader(_Fnc_FuncionariosBE.Funcionario_Email, _BodyHTML, "Plan de Acción para el Incidente N° " + _Id);
        }
    }
}