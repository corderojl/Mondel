using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.Alerta
{
    public partial class RegistrarAlerta : System.Web.UI.Page
    {
        string fecha_actual;

        ALR_AlertasBE _ALR_AlertasBE = new ALR_AlertasBE();

        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        ALR_AlertasBL _ALR_AlertasBL = new ALR_AlertasBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_AreaBL _TB_AreaBL = new TB_AreaBL();
        ALR_SistemaqaBL _ALR_SistemaqaBL = new ALR_SistemaqaBL();
        ALR_ElementoClaveBL _ALR_ElementoClaveBL = new ALR_ElementoClaveBL();
        TB_CriticidadBL _TB_CriticidadBL = new TB_CriticidadBL();

        List<Fnc_FuncionariosBE> lTFnc_FuncionariosBE;
        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<TB_AreaBE> lTTB_AreaBE;
        List<ALR_SistemaqaBE> lTALR_SistemaqaBE;
        List<TB_CriticidadBE> lTTB_CriticidadBE;

        private List<TB_AreaBE> lbeFiltroArea;
        private List<ALR_SistemaqaBE> lbeFiltroSistemaQA;

        int _area_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.IsPostBack)
                {
                    _area_id = Convert.ToInt32(Session["AREA_ID"]);
                }
                else
                {
                    _area_id = Convert.ToInt32(Session["AREA_ID"]);
                    //Session["FUNCIONARIO_ID"] = "71046";
                    DateTime Hoy = DateTime.Today;
                    fecha_actual = Hoy.ToString("dd/MM/yyyy");
                    txtFecha.Text = fecha_actual;

                    lTTB_AreaBE = _TB_AreaBL.ListarTB_AreaO_Act();
                    Session["Areas"] = lTTB_AreaBE;
                    lTALR_SistemaqaBE = _ALR_SistemaqaBL.ListarALR_SistemaqaO_Act();
                    Session["SistemasQA"] = lTALR_SistemaqaBE;
                    LlenarComboOriginador();
                    //LlenarComboElementoClave();
                    LlenarComboDepartamento();
                    ddlDepartamento.SelectedValue = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Area_Id.ToString();
                    LlenarComboArea();
                    LlenarComboSistemaQA();
                    LlenarComboCriticidad();
                    
                }
            }
            catch (Exception x)
            {
                // Response.Redirect("error.aspx");
            }
        }

        private void LlenarComboCriticidad()
        {
            lTTB_CriticidadBE= _TB_CriticidadBL.ListarTB_CriticidadO_Act();
            ddlClasificacion.DataSource = lTTB_CriticidadBE;
            ddlClasificacion.DataValueField = "Criticidad_id";
            ddlClasificacion.DataTextField = "Criticidad_desc";
            ddlClasificacion.DataBind();
            ddlClasificacion.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }

        private void LlenarComboOriginador()
        {
            lTFnc_FuncionariosBE = _Fnc_FuncionariosBL.ListarFnc_FuncionariosO_Act();
            ddlOriginador.DataSource = lTFnc_FuncionariosBE;
            ddlOriginador.DataValueField = "Funcionario_id";
            ddlOriginador.DataTextField = "Funcionario_nome";
            ddlOriginador.DataBind();
            ddlOriginador.SelectedValue = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id.ToString();
            ddlOriginador.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }

        private void LlenarComboDepartamento()
        {
            lTTB_DepartamentoBE = _TB_DepartamentoBL.ListarTB_Departamento_All("1");
            ddlDepartamento.DataSource = lTTB_DepartamentoBE;
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                var _mietq_etiqueta = _ALR_AlertasBE;
                _mietq_etiqueta.Alerta_desc = txtDescripcion.Text;
                _mietq_etiqueta.Fecha_alerta = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null);
                _mietq_etiqueta.Departamento_id = Convert.ToInt16(ddlDepartamento.SelectedValue);
                _mietq_etiqueta.Area_id = Convert.ToInt16(ddlArea.SelectedValue);
                _mietq_etiqueta.SistemaQA_id = Convert.ToInt16(ddlSistemaQA.SelectedValue);
                _mietq_etiqueta.ElementoClave_id = 21;
                _mietq_etiqueta.Clasificacion = Convert.ToInt16(ddlClasificacion.SelectedValue);
                _mietq_etiqueta.Originador = Convert.ToInt16(ddlOriginador.SelectedValue); ;
                _mietq_etiqueta.Registrador = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id;
                _mietq_etiqueta.Estado = 1;
                int vexito =  _ALR_AlertasBL.InsertarALR_Alertas(_ALR_AlertasBE);
                if (vexito != 0)
                {
                    if (_ALR_AlertasBE.Clasificacion == 1)
                    {
                       // CrearPlanInmediato(vexito);
                        enviarEmail(vexito, _mietq_etiqueta.Departamento_id, _mietq_etiqueta.Alerta_desc);
                    }
                    Response.Redirect("actualizarAlerta.aspx?Alerta_id=" + vexito + "&reggistro=exito");
                }
                else
                {
                    Response.Redirect("error.aspx?error=" + vexito);
                }

            }
            catch (Exception ex)
            {
                // lblMensaje.Text = ex.ToString();
            }
        }
        private void CrearPlanInmediato(int _Registro_id)
        {
            TB_PlanAccionBE _TB_PlanAccionBE = new TB_PlanAccionBE();
            TB_PlanAccionBL _TB_PlanAccionBL = new TB_PlanAccionBL();
            int _Responsable = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id;
            string _Titulo = "Realizar análisis de condiciones básicas";
            _TB_PlanAccionBE.Fecha = DateTime.Today.AddDays(7);
            _TB_PlanAccionBE.Registro_id = _Registro_id;
            _TB_PlanAccionBE.PlanAccion_desc = "Realizar análisis de condiciones básicas de esta Alerta Crítica";
            _TB_PlanAccionBE.Responsable = _Responsable;
            _TB_PlanAccionBE.tipoPlan = 1;
            _TB_PlanAccionBE.Estado = false;
            _TB_PlanAccionBE.Sistema_id = 2;

            if (_TB_PlanAccionBL.InsertarTB_PlanAccion(_TB_PlanAccionBE))
            {
                enviarEmail(_TB_PlanAccionBE.Registro_id, _Titulo, _TB_PlanAccionBE.tipoPlan, txtFecha.Text, "Realizar análisis de condiciones básicas de esta Alerta Crítica", ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Nome);
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ActualizoExito();cerrarYActualizar();", true);
            }
            else
                Response.Write("<script language=javascript>alert('ERROR');</script>");
        }
        private void enviarEmail(int _Id, string _Titulo, int _TipoPlan, string _Fecha, string _Plan, string _Asignado)
        {
            Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
            MailBL _MailBL = new MailBL();
            _Fnc_FuncionariosBE = _Fnc_FuncionariosBL.TraerFnc_Funcionario(((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id);
            string _BodyHTML = _MailBL.doBodyPlan(_Id, _Titulo, _TipoPlan, _Fecha, _Plan, _Asignado);
            _MailBL.sndMailHeader(_Fnc_FuncionariosBE.Funcionario_Email, _BodyHTML, "Plan de Acción para el Incidente N° " + _Id);
        }

        private void enviarEmail(int _Id, Int16 _Departamento_id, string _Titulo)
        {
            MailBL _MailBL = new MailBL();
            TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();
            List<string> ListEmail=_TB_AccesosBL.ListarTB_AccesosEmailByDeparatmento(_Departamento_id, 2);
            string _BodyHTML = _MailBL.doBodyAlerta(_Id, _Titulo, ddlDepartamento.SelectedItem.ToString());
            foreach (string ElemtEmail in ListEmail)
            {
                _MailBL.sndMailHeader(ElemtEmail, _BodyHTML, "Alerta N° "+_Id+": "+_Titulo);
            }
        }
        private bool buscarAreas(TB_AreaBE obeArea)
        {
            bool exitoIdArea = true;
            if (!ddlDepartamento.SelectedValue.Equals("0")) exitoIdArea = (obeArea.Departamento_id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdArea);
        }
        private bool buscarSistemasQA(ALR_SistemaqaBE obeSistemaQA)
        {
            bool exitoIdSistemaQA = true;
            if (!ddlDepartamento.SelectedValue.Equals("0")) exitoIdSistemaQA = (obeSistemaQA.Departamento_id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdSistemaQA);
        }

        private void LlenarComboArea()
        {
            lTTB_AreaBE = (List<TB_AreaBE>)Session["Areas"];
            Predicate<TB_AreaBE> pred = new Predicate<TB_AreaBE>(buscarAreas);
            lbeFiltroArea = lTTB_AreaBE.FindAll(pred);
            Session["Filtro"] = lbeFiltroArea;

            ddlArea.DataSource = lbeFiltroArea;
            ddlArea.DataValueField = "Area_id";
            ddlArea.DataTextField = "Area_desc";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        private void LlenarComboSistemaQA()
        {
            lTALR_SistemaqaBE = (List<ALR_SistemaqaBE>)Session["SistemasQA"];
            Predicate<ALR_SistemaqaBE> pred = new Predicate<ALR_SistemaqaBE>(buscarSistemasQA);
            lbeFiltroSistemaQA = lTALR_SistemaqaBE.FindAll(pred);
            Session["Filtro"] = lbeFiltroSistemaQA;

            ddlSistemaQA.DataSource = lbeFiltroSistemaQA;
            ddlSistemaQA.DataValueField = "SistemaQA_id";
            ddlSistemaQA.DataTextField = "SistemaQA_desc";
            ddlSistemaQA.DataBind();
            ddlSistemaQA.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboArea();
            LlenarComboSistemaQA();
        }

        protected void ddlSistemaQA_SelectedIndexChanged(object sender, EventArgs e)
        {
           lblSistemaQA_nom.Text= TraerSistemaQANombre(int.Parse(ddlSistemaQA.SelectedValue));
        }
        public string TraerSistemaQANombre(int _SistemaQA_id)
        {
            List<ALR_SistemaqaBE> lTALR_SistemaqaBEFil;
            lTALR_SistemaqaBEFil = (List<ALR_SistemaqaBE>)Session["Filtro"];
            string _nombre="";
            foreach (ALR_SistemaqaBE aPart in lTALR_SistemaqaBEFil)
            {
                if (aPart.SistemaQA_id==_SistemaQA_id)
                    _nombre = aPart.SistemaQA_nom;
            }
            return _nombre;
        }
    }
}