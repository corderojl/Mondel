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

namespace IncidentesWEB.Auditoria
{
    public partial class ActualizarAuditoria : System.Web.UI.Page
    {
        string fecha_actual;

        AUD_AuditoriaBE _AUD_AuditoriaBE = new AUD_AuditoriaBE();
        TB_PlanAccionBE _TB_PlanAccionBE = new TB_PlanAccionBE();

        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        AUD_AuditoriaBL _AUD_AuditoriaBL = new AUD_AuditoriaBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_GuardiaBL _TB_GuardiaBL = new TB_GuardiaBL();
        TB_AreaBL _TB_AreaBL = new TB_AreaBL();
        AUD_AuditoriaTipoBL _AUD_AuditoriaTipoBL = new AUD_AuditoriaTipoBL();
        AUD_Auditoria_PreguntaBL _AUD_Auditoria_PreguntaBL = new AUD_Auditoria_PreguntaBL();
        TB_PlanAccionBL _TB_PlanAccionBL = new TB_PlanAccionBL();
        TB_IncidentesBL _TB_IncidentesBL = new TB_IncidentesBL();

        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<TB_GuardiaBE> lTTB_GuardiaBE;
        List<TB_AreaBE> lTTB_AreaBE;
        List<Fnc_FuncionariosBE> lTOperador;
        List<AUD_AuditoriaTipoBE> lTAUD_AuditoriaTipoBE;
        private List<TB_GuardiaBE> lbeFiltroGuardia;
        private List<TB_AreaBE> lbeFiltroArea;
        private List<Fnc_FuncionariosBE> lbeFiltroOperador;
        private List<AUD_AuditoriaTipoBE> lbeFiltroAuditoriaTipo;
        int _Auditoria_id;
        DateTime Hoy;
        protected void Page_Load(object sender, EventArgs e)
        {
            Hoy = DateTime.Today;
            fecha_actual = Hoy.ToString("dd/MM/yyyy");
            try
            {
                if (this.IsPostBack)
                {
                    _Auditoria_id = Convert.ToInt32(Request.QueryString["Auditoria_id"]);
                    GenerarPlanes(_Auditoria_id);
                    _AUD_AuditoriaBE = _AUD_AuditoriaBL.TraerAUD_AuditoriaById(_Auditoria_id);
                }
                else
                {
                    _Auditoria_id = Convert.ToInt32(Request.QueryString["Auditoria_id"]);
                    DateTime _Fecha_registro;
                    _AUD_AuditoriaBE = _AUD_AuditoriaBL.TraerAUD_AuditoriaById(_Auditoria_id);
                    lTTB_GuardiaBE = _TB_GuardiaBL.ListarTB_GuardiaO_Act();
                    Session["Guardias"] = lTTB_GuardiaBE;
                    lTTB_AreaBE = _TB_AreaBL.ListarTB_AreaO_Act();
                    Session["Area"] = lTTB_AreaBE;
                    lTOperador = _Fnc_FuncionariosBL.ListarFnc_FuncionariosO_Act();
                    Session["Operador"] = lTOperador;
                    LlenarComboDepartamento();
                    ddlDepartamento.SelectedValue = _AUD_AuditoriaBE.Departamento_id.ToString();
                    LlenarComboGuardia();
                    ddlGuardia.SelectedValue = _AUD_AuditoriaBE.Guardia_id.ToString();
                    LlenarComboArea();
                    LlenarComboOperador();
                    LlenarComboAuditoriaTipo();
                    ddlArea.SelectedValue = _AUD_AuditoriaBE.Area_id.ToString();
                    ddlOperador.SelectedValue = _AUD_AuditoriaBE.Operador.ToString();
                    ddlAuditoria.SelectedValue = _AUD_AuditoriaBE.AuditoriaTipo_id.ToString();
                    GenerarTabla(_Auditoria_id);
                    GenerarPlanes(_Auditoria_id);
                    _Fecha_registro = _AUD_AuditoriaBE.Fecha_Auditoria;
                    txtFecha.Text = _Fecha_registro.ToShortDateString();
                    chbFirma.Text = ddlOperador.SelectedItem.ToString();
                    if (_AUD_AuditoriaBE.Fecha_firmaOpe > Convert.ToDateTime("2000-01-01"))
                    {
                        lblFechaFirma.Text = _AUD_AuditoriaBE.Fecha_firmaOpe.ToShortDateString();
                        chbFirma.Checked = true;
                        chbFirma.Enabled = false;
                    }
                    else

                    {
                        lblFechaFirma.Text = "";
                        chbFirma.Checked = false;
                        if (((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id == Convert.ToInt32(ddlOperador.SelectedValue))
                            chbFirma.Enabled = true;
                        else
                        chbFirma.Enabled = false;
                    }
                    
                }
            }
            catch (Exception x)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('Se produjo un error: ');", true);
            }
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
            lbeFiltroArea = lTTB_AreaBE.FindAll(pred);
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
            ddlOperador.DataSource = lbeFiltroOperador;
            ddlOperador.DataValueField = "Funcionario_id";
            ddlOperador.DataTextField = "Funcionario_nome";
            ddlOperador.DataBind();
            ddlOperador.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        private void LlenarComboAuditoriaTipo()
        {
            lbeFiltroAuditoriaTipo = _AUD_AuditoriaTipoBL.ListarAUD_AuditoriaTipoO_Act();
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
           // LlenarComboAuditoriaTipo();
        }

        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            AUD_Auditoria_PreguntaBE _AUD_Auditoria_PreguntaBE = new AUD_Auditoria_PreguntaBE();
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            int _Registro_id = int.Parse(((Label)fila.Controls[1]).Text);
            string _Var = ((Label)fila.Controls[3]).Text;
            if (_Var == "Si")
                _AUD_Auditoria_PreguntaBE.Valor = 0;
            else
                _AUD_Auditoria_PreguntaBE.Valor = 1;
            _AUD_Auditoria_PreguntaBE.Auditoria_id = Convert.ToInt32(Request.QueryString["Auditoria_id"]);
            _AUD_Auditoria_PreguntaBE.Registro_id = _Registro_id;

            if (_Var == "No")
            {
                if (_TB_PlanAccionBL.ContarTB_PlanAccionByRegistro(_Registro_id, 5) > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('No puede cerrar Riesgo si existe Planes pendientes');", true);
                }
                else
                {
                    ltlAlert.Text = "";

                    if (!_AUD_Auditoria_PreguntaBL.ActualizarAUD_Auditoria_Pregunta(_AUD_Auditoria_PreguntaBE))
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('No se pudo actualizar riesgo!');", true);

                    }
                }
            }
            if (_Var == "Si")
            {
                if (_AUD_Auditoria_PreguntaBL.ActualizarAUD_Auditoria_Pregunta(_AUD_Auditoria_PreguntaBE))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "window.open('../admin/RegistrarPlanAccion.aspx?tipoPlan=1&Registro_id=" + _Registro_id + "&Titulo=Auditoria&Sistema_id=5','Dates','scrollbars=no,resizable=yes','height=300px', 'width=200px')", true);
                }
                else
                {
                    String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo actualizar el registro')";
                    mensaje += Environment.NewLine;
                    this.Page.Response.Write(mensaje);
                }

            }
            GenerarTabla(int.Parse(Request.QueryString["Auditoria_id"]));
        }
        private void GenerarTabla(int _Auditoria_id)
        {
            DataTable Resultados = _AUD_Auditoria_PreguntaBL.BuscarAUD_Auditoria_PreguntaByAuditoria(_Auditoria_id);
            rpTrigger.DataSource = Resultados;
            rpTrigger.DataBind();
            Label lbl1;
            int _resp = 0, _num;
            for (int i = 0; i < rpTrigger.Items.Count; i++)
            {
                lbl1 = rpTrigger.Items[i].FindControl("lblEstado") as Label;
                if (lbl1.Text == "Si")
                {
                    _resp++;
                }
            }
            _num = rpTrigger.Items.Count;
            lblNota.Text = _num + "/" + _resp;

        }
        private void GenerarPlanes(int _Auditoria_id)
        {
            DataTable Resultados = _TB_PlanAccionBL.BuscarTB_PlanAccionByAuditoria(_Auditoria_id);
            StringBuilder Tabla = new StringBuilder();

            string _PlanAccion_id;

            int TotalRegistros = Resultados.Rows.Count;
            Tabla.AppendLine("<h2>Planes de Acción:</h2>");
            Tabla.AppendLine("<table class=\"lista_table\" style='width: 100%;>'");
            Tabla.AppendLine("<thead>");
            Tabla.AppendLine("<th></th><th> ID </th><th> PLAN </th><th> RESPONSABLE </th><th> ESTADO </th><th> FECHA ESTIMADA </th>");
            Tabla.AppendLine("</thead>");
            Tabla.AppendLine("<tbody>");

            for (int i = 0; i < TotalRegistros; i++)
            {

                _PlanAccion_id = Resultados.Rows[i]["PlanAccion_id"].ToString();
                Tabla.AppendLine("<tr>");
                Tabla.Append("<td>" + "<a href=\"#\" onClick=\"PopUp('../admin/ActualizarPlanAccion.aspx?PlanAccion_id=" + _PlanAccion_id + "&Registro_id=" + Resultados.Rows[i]["Registro_id"].ToString() + "&Titulo=Auditoria&Sistema_id=5',20,20,800,400); return false;\"> Editar </a></td>");

                Tabla.Append("<td>" + _PlanAccion_id + "</td>");
                Tabla.Append("<td align=\"left\">" + Resultados.Rows[i]["PlanAccion_desc"].ToString() + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Funcionario_nome"].ToString() + "</td>");
                if (Convert.ToBoolean(Convert.ToByte(Resultados.Rows[i]["Estado"])) == true)
                {
                    Tabla.Append("<td>Cumplido</td>");
                }
                else
                {
                    Tabla.Append("<td style='color: red;'>No cumplido</td>");
                }
                Tabla.Append("<td>" + Resultados.Rows[i]["fecha"] + "</td>");
                Tabla.Append(Environment.NewLine);
                Tabla.AppendLine("</tr>");
            }

            Tabla.AppendLine("</tbody>");
            Tabla.AppendLine("</table>");

            ltrPlanes.Text = Tabla.ToString();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            AUD_AuditoriaBE _AUD_AuditoriaBE = new AUD_AuditoriaBE();
            try
            {
                var _mietq_etiqueta = _AUD_AuditoriaBE;
                _mietq_etiqueta.Auditoria_id = int.Parse(Request.QueryString["Auditoria_id"]);
                _mietq_etiqueta.Fecha_Auditoria = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null);
                _mietq_etiqueta.Departamento_id = Convert.ToInt16(ddlDepartamento.SelectedValue);
                _mietq_etiqueta.Guardia_id = Convert.ToInt16(ddlGuardia.SelectedValue);
                _mietq_etiqueta.Area_id = Convert.ToInt16(ddlArea.SelectedValue);
                _mietq_etiqueta.Operador = Convert.ToInt16(ddlOperador.SelectedValue);
                //_mietq_etiqueta.Originador = Convert.ToInt16(((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id);
                _mietq_etiqueta.AuditoriaTipo_id = Convert.ToInt16(ddlAuditoria.SelectedValue);
                _mietq_etiqueta.Activo = true;
                
                bool vexito = _AUD_AuditoriaBL.ActualizarAUD_Auditoria(_AUD_AuditoriaBE);
                if (vexito)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('La Auditoria se actualizo con éxito');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('Error al intentar actualizar!');", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('" + e.ToString() + "');", true);
            }
        }

        protected void chbFirma_CheckedChanged(object sender, EventArgs e)
        {
            if (lblFechaFirma.Enabled == true & lblFechaFirma.Text == "")
            {
                _AUD_AuditoriaBL.FirmarAUD_Auditoria(int.Parse(Request.QueryString["Auditoria_id"]), Hoy);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('La Auditoria se firmó con exito');", true);
            }

        }
    }
}