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

namespace IncidentesWEB.Trigger
{
    public partial class ActualizarTrigger : System.Web.UI.Page
    {
        string fecha_actual;

        TRG_TriggerBE _TRG_TriggerBE = new TRG_TriggerBE();
        TB_PlanAccionBE _TB_PlanAccionBE = new TB_PlanAccionBE();
        TB_IncidentesBE _TB_IncidentesBE = new TB_IncidentesBE();

        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TRG_TriggerBL _TRG_TriggerBL = new TRG_TriggerBL();
        TRG_Trigger_RiesgosBL _TRG_Trigger_RiesgosBL = new TRG_Trigger_RiesgosBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_GuardiaBL _TB_GuardiaBL = new TB_GuardiaBL();
        COM_ComportamientoBL _COM_ComportamientoBL = new COM_ComportamientoBL();
        TB_PlanAccionBL _TB_PlanAccionBL = new TB_PlanAccionBL();
        TB_IncidentesBL _TB_IncidentesBL = new TB_IncidentesBL();

        private List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        private List<TB_GuardiaBE> lTTB_GuardiaBE;
        private List<COM_ComportamientoBE> lCOM_ComportamientoBE;
        private List<TB_GuardiaBE> lbeFiltroGuardia;
        int _Trigger_id;
        string _reg;
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime Hoy = DateTime.Today;
            fecha_actual = Hoy.ToString("dd/MM/yyyy");
            try
            {
                if (this.IsPostBack)
                {
                    _Trigger_id = Convert.ToInt32(Request.QueryString["Trigger_id"]);
                    GenerarPlanes(_Trigger_id);
                    _TRG_TriggerBE = _TRG_TriggerBL.TraerTRG_TriggerById(_Trigger_id);
                }
                else
                {
                    _Trigger_id = Convert.ToInt32(Request.QueryString["Trigger_id"]);
                    DateTime _Fecha_registro;
                    short _Departamento_id;

                    _TRG_TriggerBE = _TRG_TriggerBL.TraerTRG_TriggerById(_Trigger_id);

                    lTTB_GuardiaBE = _TB_GuardiaBL.ListarTB_GuardiaO_Act();
                    Session["Guardias"] = lTTB_GuardiaBE;
                    LlenarComboDepartamento();
                    ddlDepartamento.SelectedValue = _TRG_TriggerBE.Departamento_id.ToString();
                    LlenarComboGuardia();
                    ddlGuardia.SelectedValue = _TRG_TriggerBE.Guardia_id.ToString();
                    txtComp_crit_dia.Text = _TRG_TriggerBE.Comp_crit_dia;
                    txtComp_crit_sem.Text = _TRG_TriggerBE.Comp_crit_sem;
                    txtDondeSeria.Text = _TRG_TriggerBE.Accidente_donde;
                    rblCompletar.SelectedValue = _TRG_TriggerBE.Completar.ToString();
                    GenerarTabla(_Trigger_id);
                    GenerarPlanes(_Trigger_id);
                    _Departamento_id = short.Parse(ddlDepartamento.SelectedValue);
                    _Fecha_registro = _TRG_TriggerBE.Trigger_fecha;
                    llenarIncidenteRegistrable(_TRG_TriggerBE.Incidente_cls);
                    llenarIncidenteClaseI(_TRG_TriggerBE.Incidente_reg);
                }
            }
            catch (Exception x)
            {
                // Response.Redirect("error.aspx");
            }
        }
        private void llenarIncidenteClaseI(int _Incidente_id)
        {
            _TB_IncidentesBE = _TB_IncidentesBL.TraerTB_IncidentesById(_Incidente_id);
            txtDescripcionClaseI.Text = _TB_IncidentesBE.Descripcion;
            rblTipoPersonal2.SelectedValue = _TB_IncidentesBE.Tipo_emp.ToString();
            txtFechaClaseI.Text = _TB_IncidentesBE.Fecha_registro.ToString("dd/MM/yyyy");
        }
        private void llenarIncidenteRegistrable(int _Incidente_id)
        {
            _TB_IncidentesBE = _TB_IncidentesBL.TraerTB_IncidentesById(_Incidente_id);
            txtDescripcionRegistrable.Text = _TB_IncidentesBE.Descripcion;
            rblTipoPersonal1.SelectedValue = _TB_IncidentesBE.Tipo_emp.ToString();
            txtFechaRegistrable.Text = _TB_IncidentesBE.Fecha_registro.ToString("dd/MM/yyyy");
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


        private bool buscarGuardias(TB_GuardiaBE obeGuardia)
        {
            bool exitoIdGuardia = true;
            if (!ddlDepartamento.SelectedValue.Equals("0")) exitoIdGuardia = (obeGuardia.Departamento_id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdGuardia);
        }
        private bool buscarComportamientoDia(COM_ComportamientoBE obeComportamientoDia)
        {
            bool exitoIdSistemaQA = true;
            if (!ddlDepartamento.SelectedValue.Equals("0")) exitoIdSistemaQA = (obeComportamientoDia.Departamento.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdSistemaQA);
        }
        private bool buscarComportamientoSemana(COM_ComportamientoBE obeComportamientoSemana)
        {
            bool exitoIdSistemaQA = true;
            if (!ddlDepartamento.SelectedValue.Equals("0")) exitoIdSistemaQA = (obeComportamientoSemana.Departamento.ToString().Equals(ddlDepartamento.SelectedValue));
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
        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboGuardia();
            llenarIncidenteClaseI(_TRG_TriggerBE.Incidente_cls);
        }

        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            int _Estado;
            TRG_Trigger_RiesgosBE _TRG_Trigger_RiesgosBE = new TRG_Trigger_RiesgosBE();
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            int _Registro_id = int.Parse(((Label)fila.Controls[1]).Text);
            string _Var = ((Label)fila.Controls[3]).Text;
            if (_Var == "Si")
                _TRG_Trigger_RiesgosBE.Estado = false;
            else
                _TRG_Trigger_RiesgosBE.Estado = true;
            _TRG_Trigger_RiesgosBE.Trigger_id = Convert.ToInt32(Request.QueryString["Trigger_id"]);
            _TRG_Trigger_RiesgosBE.Registro_id = _Registro_id;
            _TRG_Trigger_RiesgosBE.Usuario_update = ((Fnc_FuncionariosBE)Session["FNC_Funcionarios"]).Funcionario_Id;

            if (_Var == "Si")
            {
                if (_TB_PlanAccionBL.ContarTB_PlanAccionByRegistro(_Registro_id,4) > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('No puede cerrar Riesgo si existe Planes pendientes');", true);
                }
                else
                {
                    ltlAlert.Text = "";

                    if (!_TRG_Trigger_RiesgosBL.ActualizarTRG_Trigger_Riesgos(_TRG_Trigger_RiesgosBE))
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('No se pudo actualizar riesgo!');", true);

                    }
                }
            }
            if (_Var == "No")
            {
                if (_TRG_Trigger_RiesgosBL.ActualizarTRG_Trigger_Riesgos(_TRG_Trigger_RiesgosBE))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "window.open('../admin/RegistrarPlanAccion.aspx?tipoPlan=1&Registro_id=" + _Registro_id + "&Titulo=Trigger&Sistema_id=4','Dates','scrollbars=no,resizable=yes','height=300px', 'width=200px')", true);
                }
                else
                {
                    String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo actualizar el registro')";
                    mensaje += Environment.NewLine;
                    this.Page.Response.Write(mensaje);
                }
                
            }
            GenerarTabla(int.Parse(Request.QueryString["Trigger_id"]));
        }
        private void GenerarTabla(int _Trigger_Id)
        {
            DataTable Resultados = _TRG_Trigger_RiesgosBL.BuscarTRG_Trigger_RiesgosByTrigger(_Trigger_Id);
            rpTrigger.DataSource = Resultados;
            rpTrigger.DataBind();

        }
        private void GenerarPlanes(int _Trigger_id)
        {
            DataTable Resultados = _TB_PlanAccionBL.BuscarTB_PlanAccionByTrigger(_Trigger_id);
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
                Tabla.Append("<td>" + "<a href=\"#\" onClick=\"PopUp('../admin/ActualizarPlanAccion.aspx?PlanAccion_id=" + _PlanAccion_id + "&Registro_id=" + Resultados.Rows[i]["Registro_id"].ToString() + "&Titulo=Trigger&Sistema_id=4',20,20,800,400); return false;\"> Editar </a></td>");

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
            TRG_TriggerBE _TRG_TriggerBE = new TRG_TriggerBE();
            try
            {
                var _mietq_etiqueta = _TRG_TriggerBE;
                _mietq_etiqueta.Trigger_id = int.Parse(Request.QueryString["Trigger_id"]);
                _mietq_etiqueta.Departamento_id = Convert.ToInt16(ddlDepartamento.SelectedValue);
                _mietq_etiqueta.Guardia_id = Convert.ToInt16(ddlGuardia.SelectedValue);
                _mietq_etiqueta.Comp_crit_dia = txtComp_crit_dia.Text;
                _mietq_etiqueta.Comp_crit_sem = txtComp_crit_sem.Text;
                _mietq_etiqueta.Accidente_donde = txtDondeSeria.Text;
                _mietq_etiqueta.Completar = short.Parse(rblCompletar.SelectedValue);
                _mietq_etiqueta.Activo = true;
                bool vexito = _TRG_TriggerBL.ActualizarTRG_Trigger(_TRG_TriggerBE);
                if (vexito)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('El trigger se actualizo con éxito');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('Error al intentar actualizar!');", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('"+e.ToString()+"');", true);
            }
        }

       

    }
}