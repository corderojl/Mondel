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

namespace IncidentesWEB.Alerta
{
    public partial class EvaluacionAlertaPop : System.Web.UI.Page
    {
        ALR_AlertasBE _ALR_AlertasBE = new ALR_AlertasBE();

        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        ALR_AlertasBL _ALR_AlertasBL = new ALR_AlertasBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_AreaBL _TB_AreaBL = new TB_AreaBL();
        TB_GuardiaBL _TB_GuardiaBL = new TB_GuardiaBL();
        ALR_SistemaqaBL _ALR_SistemaqaBL = new ALR_SistemaqaBL();
        ALR_ElementoClaveBL _ALR_ElementoClaveBL = new ALR_ElementoClaveBL();
        TB_PlanAccionBL _TB_PlanAccionBL = new TB_PlanAccionBL();
        TB_CriticidadBL _TB_CriticidadBL = new TB_CriticidadBL();
        List<TB_CriticidadBE> lTTB_CriticidadBE;
        List<Fnc_FuncionariosBE> lTFnc_FuncionariosBE;
        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<TB_AreaBE> lTTB_AreaBE;
        List<TB_GuardiaBE> lTTB_GuardiaBE;
        List<ALR_SistemaqaBE> lTALR_SistemaqaBE;
        private List<TB_GuardiaBE> lbeFiltroGuardia;
        private List<TB_AreaBE> lbeFiltroArea;
        private List<ALR_SistemaqaBE> lbeFiltroSistemaQA;
        int _Alerta_id;
        string _reg;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.IsPostBack)
                {
                }
                else
                {
                    _Alerta_id = Convert.ToInt32(Request.QueryString["Alerta_id"]);
                    if (Request.QueryString["reg"] != null)
                        _reg = Request.QueryString["reg"].ToString();
                    if (_reg == "ver")
                        btnRegistrar.Visible = false;
                    _ALR_AlertasBE = _ALR_AlertasBL.TraerALR_AlertasById(_Alerta_id);
                    lblAlerta_id.Text = _ALR_AlertasBE.Alerta_id.ToString();
                    txtFecha.Text = _ALR_AlertasBE.Fecha_alerta.ToString("dd/MM/yyyy");
                    if (_ALR_AlertasBE.Estado == 1)
                        rblEstado.SelectedValue = "2";
                    else
                        rblEstado.SelectedValue = _ALR_AlertasBE.Estado.ToString();
                    lTTB_GuardiaBE = _TB_GuardiaBL.ListarTB_GuardiaO_Act();
                    Session["Guardias"] = lTTB_GuardiaBE;
                    lTTB_AreaBE = _TB_AreaBL.ListarTB_AreaO_Act();
                    Session["Areas"] = lTTB_AreaBE;
                    lTALR_SistemaqaBE = _ALR_SistemaqaBL.ListarALR_SistemaqaO_Act();
                    Session["SistemasQA"] = lTALR_SistemaqaBE;
                    LlenarComboOriginador();
                    ddlOriginador.SelectedValue = _ALR_AlertasBE.Originador.ToString();
                    LlenarComboDepartamento();
                    ddlDepartamento.SelectedValue = _ALR_AlertasBE.Departamento_id.ToString();
                    LlenarComboArea();
                    ddlArea.SelectedValue = _ALR_AlertasBE.Area_id.ToString();
                    LlenarComboGuardia();
                    ddlGuardia.SelectedValue = _ALR_AlertasBE.Guardia_id.ToString();
                    LlenarComboSistemaQA();
                    LlenarComboCriticidad();
                    ddlSistemaQA.SelectedValue = _ALR_AlertasBE.SistemaQA_id.ToString();
                    lblSistemaQA_nom.Text = TraerSistemaQANombre(_ALR_AlertasBE.SistemaQA_id);
                    ddlClasificacion.SelectedValue = _ALR_AlertasBE.Clasificacion.ToString();
                    txtDescripcion.Text = _ALR_AlertasBE.Alerta_desc;
                    GenerarTablaPlanInmediato(_Alerta_id, txtDescripcion.Text);
                    GenerarTablaPlanSistemico(_Alerta_id, txtDescripcion.Text);
                }
            }
            catch (Exception x)
            {
                // Response.Redirect("error.aspx");
            }
        }

        private void GenerarTablaPlanInmediato(int _Alerta_id, string _Descripcion)
        {
            DataTable Resultados = _TB_PlanAccionBL.BuscarTB_PlanAccionByIncidenteResponsable(_Alerta_id, 1, 2);
            StringBuilder Tabla = new StringBuilder();
            DateTime hoy = DateTime.Now;
            DateTime fecha;
            string _PlanAccion_id;

            int TotalRegistros = Resultados.Rows.Count;
            Tabla.AppendLine("<h2>Plan Inmediato:</h2>");
            Tabla.AppendLine("<table class=\"lista_table\">");
            Tabla.AppendLine("<thead>");
            Tabla.AppendLine("<th><a href=\"#\" onClick=\"PopUp('../admin/RegistrarPlanAccion.aspx?tipoPlan=1&Registro_id=" + _Alerta_id + "&Sistema_id=2',20,20,800,400); return false;\">Agregar </a></th><th> ID </th><th> PLAN </th><th> RESPONSABLE </th><th> ESTADO </th><th> FECHA ESTIMADA </th>");
            Tabla.AppendLine("</thead>");
            Tabla.AppendLine("<tbody>");

            for (int i = 0; i < TotalRegistros; i++)
            {
                fecha = Convert.ToDateTime(Resultados.Rows[i]["fecha"]);
                _PlanAccion_id = Resultados.Rows[i]["PlanAccion_id"].ToString();
                Tabla.AppendLine("<tr>");
                Tabla.Append("<td>" + "<a href=\"#\" onClick=\"PopUp('../admin/ActualizarPlanAccion.aspx?PlanAccion_id=" + _PlanAccion_id + "&Registro_id=" + _Alerta_id + "&Sistema_id=2',20,20,800,400); return false;\"> Editar </a></td>");
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
        private void GenerarTablaPlanSistemico(int _Alerta_id, string _Descripcion)
        {
            DataTable Resultados = _TB_PlanAccionBL.BuscarTB_PlanAccionByIncidenteResponsable(_Alerta_id, 2, 2);
            StringBuilder Tabla = new StringBuilder();
            DateTime hoy = DateTime.Now;
            DateTime fecha;
            string _PlanAccion_id;

            int TotalRegistros = Resultados.Rows.Count;
            Tabla.AppendLine("<h2>Plan Sistémico:</h2>");
            Tabla.AppendLine("<table class=\"lista_table\">");
            Tabla.AppendLine("<thead>");
            Tabla.AppendLine("<th><a href=\"#\" onClick=\"PopUp('../admin/RegistrarPlanAccion.aspx?tipoPlan=2&Registro_id=" + _Alerta_id + "&Sistema_id=" + 2 + "',20,20,800,400); return false;\">Agregar</th><th> ID </th><th> PLAN </th><th> RESPONSABLE </th><th> ESTADO </th><th> FECHA ESTIMADA </th>");
            //Tabla.AppendLine("<th></th><th> ID </th><th> PLAN </th><th> RESPONSABLE </th><th> ESTADO </th><th> FECHA ESTIMADA </th>");
            Tabla.AppendLine("</thead>");
            Tabla.AppendLine("<tbody>");

            for (int i = 0; i < TotalRegistros; i++)
            {
                fecha = Convert.ToDateTime(Resultados.Rows[i]["fecha"]);
                _PlanAccion_id = Resultados.Rows[i]["PlanAccion_id"].ToString();
                Tabla.AppendLine("<tr>");
                Tabla.Append("<td>" + "<a href=\"#\" onClick=\"PopUp('../admin/ActualizarPlanAccion.aspx?PlanAccion_id=" + _PlanAccion_id + "&Registro_id=" + _Alerta_id + "&Sistema_id=2',20,20,800,400); return false;\"> Editar </a></td>");
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

        private void LlenarComboCriticidad()
        {
            lTTB_CriticidadBE = _TB_CriticidadBL.ListarTB_CriticidadO_Act();
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
            lTTB_DepartamentoBE = _TB_DepartamentoBL.ListarTB_DepartamentoO_Act("%%");;
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
                _mietq_etiqueta.Alerta_id = Convert.ToInt32(lblAlerta_id.Text);
                _mietq_etiqueta.Alerta_desc = txtDescripcion.Text;
                _mietq_etiqueta.Fecha_alerta = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null);
                _mietq_etiqueta.Departamento_id = Convert.ToInt16(ddlDepartamento.SelectedValue);
                _mietq_etiqueta.Guardia_id = Convert.ToInt16(ddlGuardia.SelectedValue);
                _mietq_etiqueta.Area_id = Convert.ToInt16(ddlArea.SelectedValue);
                _mietq_etiqueta.SistemaQA_id = Convert.ToInt16(ddlSistemaQA.SelectedValue);
                _mietq_etiqueta.ElementoClave_id = 21;
                _mietq_etiqueta.Clasificacion = Convert.ToInt16(ddlClasificacion.SelectedValue);
                _mietq_etiqueta.Originador = Convert.ToInt16(ddlOriginador.SelectedValue); ;
                _mietq_etiqueta.Registrador = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id;
                _mietq_etiqueta.Estado = Convert.ToInt16(rblEstado.SelectedValue);
               
                if (rblEstado.SelectedValue == "3")
                {
                    if (_TB_PlanAccionBL.ContarTB_PlanAccionByRegistro(int.Parse(lblAlerta_id.Text),2) > 0)
                    {
                        String mensaje = "<script language='JavaScript'>window.alert('No puede cerrar Incidente si existe Planes pendientes');";
                        mensaje += Environment.NewLine;
                        mensaje += "</script>";
                        mensaje += Environment.NewLine;
                        this.Page.Response.Write(mensaje);
                    }
                    else
                    {
                        if (_ALR_AlertasBL.ActualizarALR_Alertas(_ALR_AlertasBE))
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
                    if (_ALR_AlertasBL.ActualizarALR_Alertas(_ALR_AlertasBE))
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

        private void enviarEmail(int _Id, Int16 _Departamento_id, string _Titulo)
        {
            MailBL _MailBL = new MailBL();
            TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();
            List<string> ListEmail = _TB_AccesosBL.ListarTB_AccesosEmailByDeparatmento(_Departamento_id, 2);
            string _BodyHTML = _MailBL.doBodyAlerta(_Id, _Titulo, ddlDepartamento.SelectedItem.ToString());
            foreach (string ElemtEmail in ListEmail)
            {
                _MailBL.sndMailHeader(ElemtEmail, _BodyHTML, "Incidente N° " + _Id + ": " + _Titulo);
            }
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
        private bool buscarSistemasQA(ALR_SistemaqaBE obeSistemaQA)
        {
            bool exitoIdSistemaQA = true;
            if (!ddlDepartamento.SelectedValue.Equals("0")) exitoIdSistemaQA = (obeSistemaQA.Departamento_id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdSistemaQA);
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
            LlenarComboGuardia();
            LlenarComboArea();
            LlenarComboSistemaQA();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            _ALR_AlertasBL.EliminarALR_Alertas(int.Parse(lblAlerta_id.Text));
            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ActualizoExito();cerrarYActualizar();", true);
        }

        protected void ddlSistemaQA_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSistemaQA_nom.Text = TraerSistemaQANombre(int.Parse(ddlSistemaQA.SelectedValue));
        }
        public string TraerSistemaQANombre(int _SistemaQA_id)
        {
            List<ALR_SistemaqaBE> lTALR_SistemaqaBEFil;
            lTALR_SistemaqaBEFil = (List<ALR_SistemaqaBE>)Session["Filtro"];
            string _nombre = "";
            foreach (ALR_SistemaqaBE aPart in lTALR_SistemaqaBEFil)
            {
                if (aPart.SistemaQA_id == _SistemaQA_id)
                    _nombre = aPart.SistemaQA_nom;
            }
            return _nombre;
        }
    }
}