using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.admin
{
    public partial class EvaluacionIncidentePop : System.Web.UI.Page
    {
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
        TB_PlanAccionBL _TB_PlanAccionBL = new TB_PlanAccionBL();

        TB_CausaInmediataBL _TB_CausaInmediataBL = new TB_CausaInmediataBL();
        TB_ElementoClaveBL _TB_ElementoClaveBL = new TB_ElementoClaveBL();
        TB_TecnologiaBL _TB_TecnologiaBL = new TB_TecnologiaBL();
        TB_ElementoClaveBL _TB_SistemaBL = new TB_ElementoClaveBL();

        TB_CondicionInvolucradaBL _TB_CondicionInvolucradaBL = new TB_CondicionInvolucradaBL();
        TB_RiesgoInvolucradoBL _TB_RiesgoIvolucradoBL = new TB_RiesgoInvolucradoBL();
        TB_ResponsableBL _TB_ResponsableBL = new TB_ResponsableBL();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TB_TipoDanioBL _TB_TipoDanioBL = new TB_TipoDanioBL();
        List<TB_TipoDanioBE> lTTB_TipoDanioBE;

        protected DataView dvEstatusOperacional;
        List<TB_AreaBE> lTTB_AreaBE;
        List<TB_EstatusOperacionalBE> lTTB_EstatusOperacionalBE;
        List<TB_ParteCuerpoBE> lTTB_ParteCuerpoBE;
        List<TB_ContratistaBE> lTTB_ContratistaBE;
        List<TB_GuardiaBE> lTTB_GuardiaBE;
        List<TB_ElementoClaveBE> lTTB_SistemaBE;
        List<TB_CausaInmediataBE> lTTB_CausaInmediataBE;
        List<TB_CondicionInvolucradaBE> lTTB_CondicionInvolucradaBE;
        List<TB_RiesgoInvolucradoBE> lTTB_RiesgoInvolucradoBE;
        List<Fnc_FuncionariosBE> lTFnc_FuncionariosBE;

        private List<TB_AreaBE> lbeFiltroArea;
        private List<TB_GuardiaBE> lbeFiltro;
        private List<TB_ParteCuerpoBE> lbeFiltroParte;
        int _Incidente_id;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.IsPostBack)
                {

                }
                else
                {
                    _Incidente_id = Convert.ToInt32(Request.QueryString["Incidente_id"]);
                    //Session["FUNCIONARIO_ID"] = "71046";                    
                    _TB_IncidentesBE = _TB_IncidentesBL.TraerTB_IncidentesById(_Incidente_id);
                    txtTitulo.Text = _TB_IncidentesBE.Titulo;
                    txtDescripcion.Text = _TB_IncidentesBE.Descripcion;
                    txtFecha.Text = _TB_IncidentesBE.Fecha_incidente.ToString("dd/MM/yyyy");
                    lTTB_AreaBE = _TB_AreaBL.ListarTB_AreaO_Act();
                    Session["Areas"] = lTTB_AreaBE;
                    lTTB_GuardiaBE = _TB_GuardiaBL.ListarTB_GuardiaO_Act();
                    Session["Guardias"] = lTTB_GuardiaBE;
                    lblIncidente_id.Text = _Incidente_id.ToString();
                    lTTB_ParteCuerpoBE = _TB_ParteCuerpoBL.ListarTB_ParteCuerpoO_Act();
                    Session["ParteCuerpo"] = lTTB_ParteCuerpoBE;
                    rblTipoPersonal.SelectedValue = _TB_IncidentesBE.Tipo_emp.ToString();
                    rblTurno.SelectedValue = _TB_IncidentesBE.Turno.ToString();

                    if (_TB_IncidentesBE.Estado == 1)
                        rblEstado.SelectedValue = "2";
                    else
                        rblEstado.SelectedValue = _TB_IncidentesBE.Estado.ToString();

                    LlenarComboDepartamento("1");
                    LlenarComboArea();
                    LlenarComboEstatusOperacional();
                    LlenarComboClasificacion();
                    LlenarCamboTipoDanio();
                    ddlTipoIncidente.SelectedValue = _TB_IncidentesBE.Daño_tipo.ToString();
                    LlenarComboParteCuerpo();
                    LlenarComboEquipoAfectado();
                    LlenarComboContratista();
                    LlenarComboSistema();
                    LlenarComboCondicionInvolucrada();
                    LlenarComboRiesgoInvolucrado();
                    LlenarComboEmpleado();

                    GenerarTablaPlanInmediato(_Incidente_id, txtTitulo.Text);
                    GenerarTablaPlanSistemico(_Incidente_id, txtTitulo.Text);
                    ddlDepartamento.SelectedValue = _TB_IncidentesBE.Departamento.ToString();
                    ddlEmpleado.SelectedValue = _TB_IncidentesBE.EmpleadoAfectado.ToString();
                    ddlContratista.SelectedValue = _TB_IncidentesBE.Contratista_id.ToString();
                    ddlParteCuerpo.SelectedValue = _TB_IncidentesBE.ParteCuerpo_id.ToString();
                    TraerResponsable(Convert.ToInt16(ddlDepartamento.SelectedValue));
                    TraerOriginador(_TB_IncidentesBE.Originador);
                    ddlCausaInmediata.SelectedValue = _TB_IncidentesBE.Causainmediata_id.ToString();
                    ddlCondicionaInvolucrado.SelectedValue = _TB_IncidentesBE.Condicion_inv_id.ToString();
                    ddlSistema.SelectedValue = _TB_IncidentesBE.ElementoClave_id.ToString();
                    ddlComportamientoInvolucrado.SelectedValue = _TB_IncidentesBE.Riesgo_inv_id.ToString();
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
            ddlTipoIncidente.DataBind();
        }
        private void TraerResponsable(Int16 _Departamento_id)
        {
            lblResponsable.Text = _TB_ResponsableBL.TraerTB_ResponsableByDepartamento(_Departamento_id).Funcionario_nome;
        }
        private void TraerOriginador(int _Funcionario_id)
        {
            Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
            lblOriginador.Text = _Fnc_FuncionariosBL.TraerFnc_Funcionario(_Funcionario_id).Funcionario_Nome;
        }
        private void LlenarComboRiesgoInvolucrado()
        {
            lTTB_RiesgoInvolucradoBE = _TB_RiesgoIvolucradoBL.ListarTB_RiesgoInvolucradoO_Act();
            ddlComportamientoInvolucrado.DataSource = lTTB_RiesgoInvolucradoBE;
            ddlComportamientoInvolucrado.DataValueField = "Riesgo_inv_id";
            ddlComportamientoInvolucrado.DataTextField = "Riesgo_inv_desc";
            ddlComportamientoInvolucrado.DataBind();
            ddlComportamientoInvolucrado.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));

        }

        private void LlenarComboCondicionInvolucrada()
        {
            lTTB_CondicionInvolucradaBE = _TB_CondicionInvolucradaBL.ListarTB_CondicionInvolucradaO_Act();
            ddlCondicionaInvolucrado.DataSource = lTTB_CondicionInvolucradaBE;
            ddlCondicionaInvolucrado.DataValueField = "Condicion_inv_id";
            ddlCondicionaInvolucrado.DataTextField = "Condicion_inv_desc";
            ddlCondicionaInvolucrado.DataBind();
            ddlCondicionaInvolucrado.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }


        private void LlenarComboSistema()
        {
            lTTB_SistemaBE = _TB_SistemaBL.ListarTB_ElementoClaveO_Act();
            ddlSistema.DataSource = lTTB_SistemaBE;
            ddlSistema.DataValueField = "ElementoClave_id";
            ddlSistema.DataTextField = "ElementoClave_desc";
            ddlSistema.DataBind();
            ddlSistema.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));

        }

        private void LlenarComboContratista()
        {
            lTTB_ContratistaBE = _TB_ContratistaBL.ListarTB_ContratistaO_Act();
            ddlContratista.DataSource = lTTB_ContratistaBE;
            ddlContratista.DataValueField = "Contratista_id";
            ddlContratista.DataTextField = "Contratista_desc";
            ddlContratista.DataBind();
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
            ddlArea.SelectedValue = _TB_IncidentesBE.Area_id.ToString();
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
        private void LlenarComboDepartamento(string Sistema_id)
        {
            ddlDepartamento.DataSource = _TB_DepartamentoBL.ListarTB_Departamento_All(Sistema_id);
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
            ddlEstatusOperacional.SelectedValue = _TB_IncidentesBE.Estatus_ope.ToString();
            ddlEstatusOperacional.DataBind();
            ddlEstatusOperacional.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        private void LlenarComboClasificacion()
        {

            ddlClasificacion.DataSource = _TB_ClasificacionBL.ListarTB_Clasificacion_All(); ;
            ddlClasificacion.DataValueField = "Clasificacion_id";
            ddlClasificacion.DataTextField = "Clasificacion_desc";
            ddlClasificacion.SelectedValue = _TB_IncidentesBE.Clasificacion_id.ToString();
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

                var _mietq_etiqueta = _TB_IncidentesBE;
                //_miempl.Emp_id = "";
                _mietq_etiqueta.Incidente_id = Convert.ToInt32(lblIncidente_id.Text);
                _mietq_etiqueta.Titulo = txtTitulo.Text;
                _mietq_etiqueta.Descripcion = txtDescripcion.Text;
                _mietq_etiqueta.Fecha_incidente = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null);
                _mietq_etiqueta.Fecha_estimada = DateTime.Now;
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
                _mietq_etiqueta.Clasificacion_id = Convert.ToInt16(ddlClasificacion.SelectedValue);
                _mietq_etiqueta.Daño_tipo = Convert.ToInt16(ddlTipoIncidente.SelectedValue);
                _mietq_etiqueta.Registro = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id.ToString();
                _mietq_etiqueta.Causainmediata_id = Convert.ToInt16(ddlCausaInmediata.SelectedValue);
                _mietq_etiqueta.Riesgo_inv_id = Convert.ToInt16(ddlComportamientoInvolucrado.SelectedValue);
                _mietq_etiqueta.Tecnologia_id = 1;
                _mietq_etiqueta.Condicion_inv_id = Convert.ToInt16(ddlCondicionaInvolucrado.SelectedValue);
                _mietq_etiqueta.ElementoClave_id = Convert.ToInt16(ddlSistema.SelectedValue);
                _mietq_etiqueta.Estado = Convert.ToInt16(rblEstado.SelectedValue);


                if (rblEstado.SelectedValue == "3")
                {
                    if (_TB_PlanAccionBL.ContarTB_PlanAccionByRegistro(int.Parse(lblIncidente_id.Text), 1) > 0)
                    {
                        String mensaje = "<script language='JavaScript'>window.alert('No puede cerrar Incidente si existe Planes pendientes');";
                        mensaje += Environment.NewLine;
                        mensaje += "</script>";
                        mensaje += Environment.NewLine;
                        this.Page.Response.Write(mensaje);
                    }
                    else
                    {
                        if (_TB_IncidentesBL.ActualizarTB_Incidentes(_TB_IncidentesBE))
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ActualizoExito();cerrarYActualizar();", true);
                        }
                        else
                        {
                            //Response.Redirect("error.aspx?error=" + vexito);
                        }
                    }
                }
                else
                {
                    if (_TB_IncidentesBL.ActualizarTB_Incidentes(_TB_IncidentesBE))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ActualizoExito();cerrarYActualizar();", true);
                    }
                    else
                    {
                        //Response.Redirect("error.aspx?error=" + vexito);
                    }
                }

            }
            catch (Exception ex)
            {
                // lblMensaje.Text = ex.ToString();
            }
        }
        private bool buscarParte(TB_ParteCuerpoBE obeParte)
        {
            bool exitoIdArea = true;
            if (!ddlTipoIncidente.SelectedValue.Equals("0")) exitoIdArea = (obeParte.TipoDanio.ToString().Equals(ddlTipoIncidente.SelectedValue));
            return (exitoIdArea);
        }
        private bool buscarGuardias(TB_GuardiaBE obeGuardia)
        {
            bool exitoIdGuardia = true;
            if (!ddlDepartamento.SelectedValue.Equals("0")) exitoIdGuardia = (obeGuardia.Departamento_id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdGuardia);
        }
        private bool buscarAreas(TB_AreaBE obeArea)
        {
            bool exitoIdArea = true;
            if (!ddlDepartamento.SelectedValue.Equals("0")) exitoIdArea = (obeArea.Departamento_id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdArea);
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
        public void GenerarTablaPlanSistemico(int _Incidente_id, string _Titulo)
        {
            DataTable Resultados = _TB_PlanAccionBL.BuscarTB_PlanAccionByIncidenteResponsable(_Incidente_id, 2, 1);
            StringBuilder Tabla = new StringBuilder();
            DateTime hoy = DateTime.Now;
            DateTime fecha;
            string _PlanAccion_id;

            int TotalRegistros = Resultados.Rows.Count;
            Tabla.AppendLine("<h2>Plan Sistémico:</h2>");
            Tabla.AppendLine("<table class=\"lista_table\">");
            Tabla.AppendLine("<thead>");
            Tabla.AppendLine("<th><a href=\"#\" onClick=\"PopUp('RegistrarPlanAccion.aspx?tipoPlan=2&Registro_id=" + _Incidente_id + "&Sistema_id=1',20,20,800,400); return false;\">Agregar</th><th> ID </th><th> PLAN </th><th> RESPONSABLE </th><th> ESTADO </th><th> FECHA ESTIMADA </th>");
            Tabla.AppendLine("</thead>");
            Tabla.AppendLine("<tbody>");

            for (int i = 0; i < TotalRegistros; i++)
            {
                fecha = Convert.ToDateTime(Resultados.Rows[i]["fecha"]);
                _PlanAccion_id = Resultados.Rows[i]["PlanAccion_id"].ToString();
                Tabla.AppendLine("<tr>");
                Tabla.Append("<td>" + "<a href=\"#\" onClick=\"PopUp('ActualizarPlanAccion.aspx?PlanAccion_id=" + _PlanAccion_id + "&Registro_id=" + _Incidente_id + "&Sistema_id=1',20,20,800,400); return false;\"> Editar </a></td>");
                Tabla.Append("<td>" + _PlanAccion_id + "</td>");
                Tabla.Append("<td align=\"left\">" + Resultados.Rows[i]["PlanAccion_desc"].ToString() + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Funcionario_nome"].ToString() + "</td>");
                if (Convert.ToBoolean(Convert.ToByte(Resultados.Rows[i]["Estado"])) == true)
                {
                    Tabla.Append("<td style='color: green;'>Cumplido</td>");
                }
                else
                {
                    if (fecha > hoy)
                        Tabla.Append("<td style='color: orange;'>En Fecha</td>");                        
                    else
                        Tabla.Append("<td style='color: red;'>Pendiente</td>");
                }
                Tabla.Append("<td>" + Resultados.Rows[i]["fecha"] + "</td>");
                Tabla.Append(Environment.NewLine);
                Tabla.AppendLine("</tr>");
            }

            Tabla.AppendLine("</tbody>");
            Tabla.AppendLine("</table>");

            //lblTitulo.Text = "Comentarios: " + Resultados.Rows[0]["Titulo"];
            ltlPlanSistemico.Text = Tabla.ToString();
        }
        public void GenerarTablaPlanInmediato(int _Incidente_id, string _Titulo)
        {
            DataTable Resultados = _TB_PlanAccionBL.BuscarTB_PlanAccionByIncidenteResponsable(_Incidente_id, 1, 1);
            StringBuilder Tabla = new StringBuilder();

            string _PlanAccion_id;
            DateTime hoy = DateTime.Now;
            DateTime fecha;

            int TotalRegistros = Resultados.Rows.Count;
            Tabla.AppendLine("<h2>Plan Inmediato:</h2>");
            Tabla.AppendLine("<table class=\"lista_table\">");
            Tabla.AppendLine("<thead>");
            Tabla.AppendLine("<th><a href=\"#\" onClick=\"PopUp('RegistrarPlanAccion.aspx?tipoPlan=1&Registro_id=" + _Incidente_id + "&Sistema_id=1&Titulo=" + _Titulo + "',20,20,800,400); return false;\">Agregar</th><th> ID </th><th> PLAN </th><th> RESPONSABLE </th><th> ESTADO </th><th> FECHA ESTIMADA </th>");
            Tabla.AppendLine("</thead>");
            Tabla.AppendLine("<tbody>");

            for (int i = 0; i < TotalRegistros; i++)
            {
                fecha = Convert.ToDateTime(Resultados.Rows[i]["fecha"]);
                _PlanAccion_id = Resultados.Rows[i]["PlanAccion_id"].ToString();
                Tabla.AppendLine("<tr>");
                Tabla.Append("<td>" + "<a href=\"#\" onClick=\"PopUp('ActualizarPlanAccion.aspx?PlanAccion_id=" + _PlanAccion_id + "&Registro_id=" + _Incidente_id + "&Sistema_id=1&Titulo=" + _Titulo + "',20,20,800,400); return false;\"> Editar </a></td>");
                Tabla.Append("<td>" + _PlanAccion_id + "</td>");
                Tabla.Append("<td align=\"left\">" + Resultados.Rows[i]["PlanAccion_desc"].ToString() + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Funcionario_nome"].ToString() + "</td>");
                if (Convert.ToBoolean(Convert.ToByte(Resultados.Rows[i]["Estado"])) == true)
                {
                    Tabla.Append("<td style='color: green;'>Cumplido</td>");
                }
                else
                {
                    if (fecha > hoy)
                        Tabla.Append("<td style='color: orange;'>En Fecha</td>");
                    else
                        Tabla.Append("<td style='color: red;'>Pendiente</td>");
                }
                Tabla.Append("<td>" + Resultados.Rows[i]["fecha"] + "</td>");
                Tabla.Append(Environment.NewLine);
                Tabla.AppendLine("</tr>");
            }

            Tabla.AppendLine("</tbody>");
            Tabla.AppendLine("</table>");

            //lblTitulo.Text = "Comentarios: " + Resultados.Rows[0]["Titulo"];
            ltlPlanInmediato.Text = Tabla.ToString();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            _TB_IncidentesBL.EliminarTB_Incidentes(int.Parse(lblIncidente_id.Text));
            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ActualizoExito();cerrarYActualizar();", true);
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

        protected void ddlTipoIncidente_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboParteCuerpo();
        }

        protected void rblEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}