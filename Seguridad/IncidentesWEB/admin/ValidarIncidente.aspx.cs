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
    public partial class ValidarIncidente : System.Web.UI.Page
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
        TB_EquipoAfectadoBL _TB_EquipoAfectadoBL = new TB_EquipoAfectadoBL();
        TB_ContratistaBL _TB_ContratistaBL = new TB_ContratistaBL();
        TB_GuardiaBL _TB_GuardiaBL = new TB_GuardiaBL();
        TB_RolBL _TB_RolBL = new TB_RolBL();
        
        protected DataView dvEstatusOperacional;
        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<TB_AreaBE> lTTB_AreaBE;
        List<TB_EstatusOperacionalBE> lTTB_EstatusOperacionalBE;
        List<TB_ClasificacionBE> lTTB_ClasificacionBE;
        List<TB_ParteCuerpoBE> lTTB_ParteCuerpoBE;
        List<TB_EquipoAfectadoBE> lTTB_EquipoAfectadoBE;
        List<TB_ContratistaBE> lTTB_ContratistaBE;
        List<TB_GuardiaBE> lTTB_GuardiaBE;
        List<TB_RolBE> lTTB_RolBE;

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
                    LlenarComboDepartamento();
                    LlenarComboArea();
                    LlenarComboEstatusOperacional();
                    LlenarComboClasificacion();
                    LlenarComboParteCuerpo();
                    LlenarComboEquipoAfectado();
                    LlenarComboRol();
                    LlenarComboGuardia();
                    LlenarComboContratista();
                    //_fun_id = Convert.ToInt32(Session["FUNCIONARIO_ID"]);
                    //LlenarEncontrado(_area_id, _fun_id);
                    //LlenarResuelto(_area_id);
                    //LlenarComboDispositivos(_area_id.ToString());
                    ////LlenarComboEquipos();
                    //lblMensaje.Text = "";
                }
            }
            catch (Exception x)
            {
               // Response.Redirect("error.aspx");
            }
        }

        private void LlenarComboContratista()
        {
            lTTB_ContratistaBE = _TB_ContratistaBL.ListarTB_ContratistaO_Act();
            ddlContratista.DataSource = lTTB_ContratistaBE;
            ddlContratista.DataValueField = "Contratista_id";
            ddlContratista.DataTextField = "Contratista_desc";
            ddlContratista.DataBind();
            ddlContratista.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }

        private void LlenarComboGuardia()
        {
            lTTB_GuardiaBE = _TB_GuardiaBL.ListarTB_GuardiaO_Act();
            ddlGuardia.DataSource = lTTB_GuardiaBE;
            ddlGuardia.DataValueField = "Guardia_id";
            ddlGuardia.DataTextField = "Guardia_desc";
            ddlGuardia.DataBind();
            ddlGuardia.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }

        private void LlenarComboRol()
        {
            lTTB_RolBE = _TB_RolBL.ListarTB_RolO_Act();
            ddlRol.DataSource = lTTB_RolBE;
            ddlRol.DataValueField = "Rol_id";
            ddlRol.DataTextField = "Rol_desc";
            ddlRol.DataBind();
            ddlRol.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }

        private void LlenarComboArea()
        {
            lTTB_AreaBE = _TB_AreaBL.ListarTB_AreaO_Act();
            ddlArea.DataSource = lTTB_AreaBE;
            ddlArea.DataValueField = "Area_id";
            ddlArea.DataTextField = "Area_desc";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
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
            lTTB_ParteCuerpoBE = _TB_ParteCuerpoBL.ListarTB_ParteCuerpoO_Act();
            ddlParteCuerpo.DataSource = lTTB_ParteCuerpoBE;
            ddlParteCuerpo.DataValueField = "ParteCuerpo_id";
            ddlParteCuerpo.DataTextField = "ParteCuerpo_desc";
            ddlParteCuerpo.DataBind();
            ddlParteCuerpo.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        private void LlenarComboEquipoAfectado()
        {
            lTTB_EquipoAfectadoBE = _TB_EquipoAfectadoBL.ListarTB_EquipoAfectadoO_Act();
            ddlEquipoAfectado.DataSource = lTTB_EquipoAfectadoBE;
            ddlEquipoAfectado.DataValueField = "EquipoAfectado_id";
            ddlEquipoAfectado.DataTextField = "EquipoAfectado_desc";
            ddlEquipoAfectado.DataBind();
            ddlEquipoAfectado.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                int status;
                var _mietq_etiqueta = _TB_IncidentesBE;
                //_miempl.Emp_id = "";
                _mietq_etiqueta.Titulo = txtTitulo.Text;
                _mietq_etiqueta.Descripcion = txtDescripcion.Text;
                _mietq_etiqueta.Fecha_incidente = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null);
                _mietq_etiqueta.Turno = Convert.ToInt16(rblTurno.SelectedValue);
                _mietq_etiqueta.Tiempo_ext = Convert.ToInt16(rblTiempo.SelectedValue);
                _mietq_etiqueta.Estatus_ope = Convert.ToInt16(ddlEstatusOperacional.SelectedValue);
                _mietq_etiqueta.Departamento = Convert.ToInt16(ddlDepartamento.SelectedValue);
                _mietq_etiqueta.Guardia = Convert.ToInt16(ddlGuardia.SelectedValue);
                _mietq_etiqueta.Area_id = Convert.ToInt16(ddlArea.SelectedValue);
                _mietq_etiqueta.Tipo_emp = Convert.ToInt16(rblTipoPersonal.SelectedValue);
                _mietq_etiqueta.Contratista_id = Convert.ToInt16(ddlContratista.SelectedValue);
                _mietq_etiqueta.Rol_id = Convert.ToInt16(ddlRol.SelectedValue);
                _mietq_etiqueta.Rol_tiempo = Convert.ToInt16(ddlTiempoRol.SelectedValue);
                _mietq_etiqueta.Compania_tiempo = Convert.ToInt16(ddlTiempoCompania.SelectedValue);
                _mietq_etiqueta.ParteCuerpo_id = Convert.ToInt16(ddlParteCuerpo.SelectedValue);
                _mietq_etiqueta.EquipoAfectado_id = Convert.ToInt16(ddlEquipoAfectado.SelectedValue);
                _mietq_etiqueta.Clasificacion_id = Convert.ToInt16(ddlClasificacion.SelectedValue);
                _mietq_etiqueta.Daño_tipo = Convert.ToInt16(ddlTipoIncidente.SelectedValue);
                _mietq_etiqueta.Originador = Convert.ToInt16(1);
                _mietq_etiqueta.Registro = "urco.ju.1";
                _mietq_etiqueta.Estado = 1;
                _mietq_etiqueta.ParteCuerpo_id = Convert.ToInt16(ddlParteCuerpo.SelectedValue);
                int vexito = _TB_IncidentesBL.InsertarTB_Incidentes(_TB_IncidentesBE);
                if (vexito != 0)
                {

                    Response.Redirect("actualizardefecto.aspx?etiqueta_id=" + vexito + "&reg=exito");
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
    }
}