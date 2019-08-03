using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.admin
{
    public partial class RegistrarIncidente : System.Web.UI.Page
    {
        string fecha_actual;
        protected DataView dvLocaliza;
        protected DataView dvComponentes;
        protected DataView dvTipos;
        protected DataView dvEncontrado;
        protected DataView dvResuelto;
        protected DataView dvCategoria;
        protected DataView dvDispositivos;
        protected DataView dvPartes;
        protected DataView dvGrupos;
        //datatable
        protected DataTable dtFuncionario;
        protected DataTable dtComponente;
        protected DataTable dtPartes;
        protected DataTable dtDueno;

        TB_IncidentesBE _TB_IncidentesBE = new TB_IncidentesBE();

        TB_IncidentesBL _TB_IncidentesBL = new TB_IncidentesBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_AreaBL _TB_AreaBL = new TB_AreaBL();
        TB_EstatusOperacionalBL _TB_EstatusOperacionalBL = new TB_EstatusOperacionalBL();
        TB_ClasificacionBL _TB_ClasificacionBL = new TB_ClasificacionBL();
        TB_ParteCuerpoBL _TB_ParteCuerpoBL = new TB_ParteCuerpoBL();
        TB_CausaInmediataBL _TB_CausaInmediataBL = new TB_CausaInmediataBL();
        TB_ContratistaBL _TB_ContratistaBL = new TB_ContratistaBL();
        TB_GuardiaBL _TB_GuardiaBL = new TB_GuardiaBL();
        TB_RolBL _TB_RolBL = new TB_RolBL();
        TB_ResponsableBL _TB_ResponsableBL = new TB_ResponsableBL();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TB_TipoDanioBL _TB_TipoDanioBL = new TB_TipoDanioBL();

        protected DataView dvEstatusOperacional;
        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<TB_AreaBE> lTTB_AreaBE;
        List<TB_EstatusOperacionalBE> lTTB_EstatusOperacionalBE;
        List<TB_ClasificacionBE> lTTB_ClasificacionBE;
        List<TB_ParteCuerpoBE> lTTB_ParteCuerpoBE;
        List<TB_CausaInmediataBE> lTTB_CausaInmediataBE;
        List<TB_ContratistaBE> lTTB_ContratistaBE;
        List<TB_GuardiaBE> lTTB_GuardiaBE;
        List<Fnc_FuncionariosBE> lTFnc_FuncionariosBE;
        List<TB_TipoDanioBE> lTTB_TipoDanioBE;

        private List<TB_AreaBE> lbeFiltroArea;
        private List<TB_ParteCuerpoBE> lbeFiltroParte;

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
                    lTTB_GuardiaBE = _TB_GuardiaBL.ListarTB_GuardiaO_Act();
                    Session["Guardias"] = lTTB_GuardiaBE;
                    lTTB_ParteCuerpoBE = _TB_ParteCuerpoBL.ListarTB_ParteCuerpoO_Act();
                    Session["ParteCuerpo"] = lTTB_ParteCuerpoBE;
                    LlenarComboDepartamento();
                    ddlDepartamento.SelectedValue = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Area_Id.ToString();
                    LlenarComboArea();
                    LlenarComboEstatusOperacional();
                    LlenarComboClasificacion();
                    LlenarComboParteCuerpo();
                    LlenarComboEquipoAfectado();
                    LlenarComboEmpleado();
                    LlenarComboContratista();
                    LlenarCamboTipoDanio();
                    TraerResponsable(Convert.ToInt16(ddlDepartamento.SelectedValue));
                }
            }
            catch (Exception x)
            {
                // Response.Redirect("error.aspx");
            }
        }

        private void LlenarCamboTipoDanio()
        {
            lTTB_TipoDanioBE = _TB_TipoDanioBL.ListarTB_TipoDanioO_Act();
            ddlTipoIncidente.DataSource = lTTB_TipoDanioBE;
            ddlTipoIncidente.DataValueField = "TipoDanio_id";
            ddlTipoIncidente.DataTextField = "TipoDanio_Desc";
            ddlTipoIncidente.SelectedValue = "0";
            ddlTipoIncidente.DataBind();
        }

        private void LlenarComboContratista()
        {
            lTTB_ContratistaBE = _TB_ContratistaBL.ListarTB_ContratistaO_Act();
            ddlContratista.DataSource = lTTB_ContratistaBE;
            ddlContratista.DataValueField = "Contratista_id";
            ddlContratista.DataTextField = "Contratista_desc";
            ddlContratista.SelectedValue = "1";
            ddlContratista.DataBind();

        }


        private void LlenarComboArea()
        {
            lTTB_AreaBE = (List<TB_AreaBE>)Session["Areas"];
            Predicate<TB_AreaBE> pred = new Predicate<TB_AreaBE>(buscarAreas);
            lbeFiltroArea = lTTB_AreaBE.FindAll(pred);
            //Session["Filtro"] = lbeFiltroArea;

            ddlArea.DataSource = lbeFiltroArea;
            ddlArea.DataValueField = "Area_id";
            ddlArea.DataTextField = "Area_desc";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }

        private void LlenarComboDepartamento()
        {
            lTTB_DepartamentoBE = _TB_DepartamentoBL.ListarTB_DepartamentoO_Act("1");
            ddlDepartamento.DataSource = lTTB_DepartamentoBE;
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        private void LlenarComboEstatusOperacional()
        {
            lTTB_EstatusOperacionalBE = _TB_EstatusOperacionalBL.ListarTB_EstatusOperacionalO_Act();
            ddlEstatusOperacional.DataSource = lTTB_EstatusOperacionalBE;
            ddlEstatusOperacional.DataValueField = "EstatusOperacional_id";
            ddlEstatusOperacional.DataTextField = "EstatusOperacional_desc";
            ddlEstatusOperacional.DataBind();
            ddlEstatusOperacional.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        private void LlenarComboClasificacion()
        {
            lTTB_ClasificacionBE = _TB_ClasificacionBL.ListarTB_ClasificacionO_Act();
            ddlClasificacion.DataSource = lTTB_ClasificacionBE;
            ddlClasificacion.DataValueField = "Clasificacion_id";
            ddlClasificacion.DataTextField = "Clasificacion_desc";
            ddlClasificacion.DataBind();
            ddlClasificacion.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        private void LlenarComboParteCuerpo()
        {
            lTTB_ParteCuerpoBE = (List<TB_ParteCuerpoBE>)Session["ParteCuerpo"];
            Predicate<TB_ParteCuerpoBE> pred = new Predicate<TB_ParteCuerpoBE>(buscarParte);
            lbeFiltroParte = lTTB_ParteCuerpoBE.FindAll(pred);
            // Session["Filtro"] = lbeFiltroArea;

            lTTB_ParteCuerpoBE = lbeFiltroParte;
            ddlParteCuerpo.DataSource = lTTB_ParteCuerpoBE;
            ddlParteCuerpo.DataValueField = "ParteCuerpo_id";
            ddlParteCuerpo.DataTextField = "ParteCuerpo_desc";
            ddlParteCuerpo.DataBind();
            ddlParteCuerpo.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        private void LlenarComboEquipoAfectado()
        {
            lTTB_CausaInmediataBE = _TB_CausaInmediataBL.ListarTB_CausaInmediataO_Act();
            ddlCausaInmediata.DataSource = lTTB_CausaInmediataBE;
            ddlCausaInmediata.DataValueField = "Causainmediata_id";
            ddlCausaInmediata.DataTextField = "Causainmediata_desc";
            ddlCausaInmediata.DataBind();
            ddlCausaInmediata.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
            ddlCausaInmediata.SelectedValue = "0";

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                int status;
                var _mietq_etiqueta = _TB_IncidentesBE;
                _mietq_etiqueta.Titulo = txtTitulo.Text;
                _mietq_etiqueta.Descripcion = txtDescripcion.Text;
                _mietq_etiqueta.Fecha_incidente = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null);
                _mietq_etiqueta.Turno = Convert.ToInt16(rblTurno.SelectedValue);
                _mietq_etiqueta.Tiempo_ext = 1;
                _mietq_etiqueta.Estatus_ope = Convert.ToInt16(ddlEstatusOperacional.SelectedValue);
                _mietq_etiqueta.Departamento = Convert.ToInt16(ddlDepartamento.SelectedValue);
                _mietq_etiqueta.Guardia = 0;
                _mietq_etiqueta.Area_id = Convert.ToInt16(ddlArea.SelectedValue);
                _mietq_etiqueta.Tipo_emp = Convert.ToInt16(rblTipoPersonal.SelectedValue);
                _mietq_etiqueta.Contratista_id = Convert.ToInt16(ddlContratista.SelectedValue);
                _mietq_etiqueta.Rol_id = 1;
                _mietq_etiqueta.Rol_tiempo = 1;
                _mietq_etiqueta.Compania_tiempo = 1;
                _mietq_etiqueta.ParteCuerpo_id = Convert.ToInt16(ddlParteCuerpo.SelectedValue);
                _mietq_etiqueta.EquipoAfectado_id = 1;
                _mietq_etiqueta.Causainmediata_id = Convert.ToInt16(ddlCausaInmediata.SelectedValue);
                _mietq_etiqueta.Clasificacion_id = Convert.ToInt16(ddlClasificacion.SelectedValue);
                _mietq_etiqueta.Daño_tipo = Convert.ToInt16(ddlTipoIncidente.SelectedValue);
                _mietq_etiqueta.Originador = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id;
                _mietq_etiqueta.Registro = "urco.ju.1";
                _mietq_etiqueta.Estado = 1;
                _mietq_etiqueta.EmpleadoAfectado = Convert.ToInt16(ddlEmpleado.SelectedValue);
                int vexito = _TB_IncidentesBL.InsertarTB_Incidentes(_TB_IncidentesBE);
                if (vexito != 0)
                {
                    enviarEmail(vexito, _mietq_etiqueta.Departamento, _mietq_etiqueta.Titulo);
                    //String mensaje = "<script language='JavaScript'>window.alert('El Incidente se registro con exito')";
                    //mensaje += Environment.NewLine;
                    //mensaje += "window.location.href='ActualizarIncidente.aspx?reg=ac&Incidente_id=" + vexito + "';</script>";
                    //mensaje += Environment.NewLine;
                    //this.Page.Response.Write(mensaje);

                    Response.Redirect("actualizarIncidente.aspx?Incidente_id=" + vexito + "&reg=exito");
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

        private void enviarEmail(int _Id, Int16 _Departamento_id, string _Titulo)
        {
            MailBL _MailBL = new MailBL();
            TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();
            List<string> ListEmail = _TB_AccesosBL.ListarTB_AccesosEmailByDeparatmento(_Departamento_id, 1);
            string _BodyHTML = _MailBL.doBodyIncidente(_Id, _Titulo, ddlDepartamento.SelectedItem.ToString(), rblTipoPersonal.SelectedItem.ToString());
            foreach (string ElemtEmail in ListEmail)
            {
                _MailBL.sndMailHeader(ElemtEmail, _BodyHTML, "Incidente N° " + _Id + ": " + _Titulo);
            }
        }

        private bool buscarAreas(TB_AreaBE obeArea)
        {
            bool exitoIdArea = true;
            if (!ddlDepartamento.SelectedValue.Equals("0")) exitoIdArea = (obeArea.Departamento_id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdArea);
        }
        private bool buscarParte(TB_ParteCuerpoBE obeParte)
        {
            bool exitoIdArea = true;
            if (!ddlTipoIncidente.SelectedValue.Equals("0")) exitoIdArea = (obeParte.TipoDanio.ToString().Equals(ddlTipoIncidente.SelectedValue));
            return (exitoIdArea);
        }
        private void LlenarComboEmpleado()
        {
            lTFnc_FuncionariosBE = _Fnc_FuncionariosBL.ListarFnc_FuncionariosO_Act();
            //Session["Filtro"] = lbeFiltro;

            ddlEmpleado.DataSource = lTFnc_FuncionariosBE;
            ddlEmpleado.DataValueField = "FUNCIONARIO_ID";
            ddlEmpleado.DataTextField = "FUNCIONARIO_NOME";
            ddlEmpleado.DataBind();
            ddlEmpleado.Items.Insert(0, new ListItem("Elija Empleado", "0"));
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboArea();
            TraerResponsable(Convert.ToInt16(ddlDepartamento.SelectedValue));
        }

        protected void rblTipoPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblTipoPersonal.SelectedValue == "1")
            {
                ddlContratista.Enabled = false;
                ddlContratista.SelectedValue = "1";

            }
            else
            {
                ddlContratista.Enabled = true;
            }
        }
        private void TraerResponsable(Int16 _Departamento_id)
        {
            lblResponsable.Text = _TB_ResponsableBL.TraerTB_ResponsableByDepartamento(_Departamento_id).Funcionario_nome;
        }

        protected void ddlTipoIncidente_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboParteCuerpo();
        }

        protected void ddlClasificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.Parse(ddlClasificacion.SelectedValue) == 9 || int.Parse(ddlClasificacion.SelectedValue) == 10)
            {
                ddlEmpleado.SelectedValue = "0";
                ddlEmpleado.Enabled = true;
            }
            else
            {
                ddlEmpleado.SelectedValue = "0";
                ddlEmpleado.Enabled = false;
            }
        }
    }
}