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

namespace IncidentesWEB.Indicadores
{
    public partial class RegistrarEvaluacion : System.Web.UI.Page
    {
        string fecha_actual;

        EVA_EvaluacionBE _EVA_EvaluacionBE = new EVA_EvaluacionBE();

        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        EVA_EvaluacionBL _EVA_EvaluacionBL = new EVA_EvaluacionBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();

        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<Fnc_FuncionariosBE> lTFnc_FuncionariosBE;
        TB_AccesosBE _TB_AccesosBE = new TB_AccesosBE();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime Hoy = DateTime.Today;
                fecha_actual = Hoy.ToString("dd/MM/yyyy");
                if (!this.IsPostBack)
                {
                    lTFnc_FuncionariosBE = _Fnc_FuncionariosBL.ListarFnc_FuncionariosO_Act();
                    Session["empleado"] = lTFnc_FuncionariosBE;
                    if (Hoy.AddMonths(-6).Month > 6)
                    {
                        ddlTipo.SelectedValue = "2";
                    }
                    else
                    {
                        ddlTipo.SelectedValue = "1";
                    }
                    ddlAnio.SelectedValue = Hoy.AddMonths(-6).Year.ToString();
                    _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id, 7);
                    string _anio;
                    _anio = ddlAnio.SelectedValue + "-" + ddlTipo.SelectedValue;
                    switch (_TB_AccesosBE.Permiso)
                    {
                        case 1:
                            LlenarComboDepartamentoAll();
                            llenarComboLider(2);
                            GenerarTabla(_anio, "%%", ddlDepartamento.SelectedValue, ddlEstado.SelectedValue);
                            ddlLider.Enabled = true; break;
                        case 2:
                            LlenarComboDepartamentoAll();
                            llenarComboLider(2);
                            GenerarTabla(_anio, "%%", ddlDepartamento.SelectedValue, ddlEstado.SelectedValue);
                            ddlLider.Enabled = true; break;
                        default:
                            LlenarComboDepartamento();
                            llenarComboLider(0);
                            GenerarTabla(_anio, ddlLider.SelectedValue, ddlDepartamento.SelectedValue, ddlEstado.SelectedValue);
                            ddlLider.Enabled = false; break;
                    }

                    if (_TB_AccesosBE.Permiso == 2)
                    {
                        LlenarComboDepartamentoAll();
                        llenarComboLider(2);
                        GenerarTabla(_anio, "%%", ddlDepartamento.SelectedValue, ddlEstado.SelectedValue);
                        ddlLider.Enabled = true;
                    }
                    else
                    {
                        LlenarComboDepartamento();
                        llenarComboLider(0);
                        GenerarTabla(_anio, ddlLider.SelectedValue, ddlDepartamento.SelectedValue, ddlEstado.SelectedValue);
                        ddlLider.Enabled = false;
                    }
                }
            }
            catch (Exception x)
            {
                // Response.Redirect("error.aspx");
            }
        }

        private void llenarComboLider(int permiso)
        {
            List<Fnc_FuncionariosBE> ltFuncionariosLider;
            ltFuncionariosLider = _Fnc_FuncionariosBL.ListarFNC_FuncionariosLideresO_Act();
            Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
            _Fnc_FuncionariosBE = (Fnc_FuncionariosBE)Session["Fnc_Funcionarios"];
            ddlLider.DataSource = ltFuncionariosLider;
            ddlLider.DataValueField = "FUNCIONARIO_ID";
            ddlLider.DataTextField = "FUNCIONARIO_NOME";
            ddlLider.DataBind();

            if (permiso != 2)
                if (_Fnc_FuncionariosBL.Contenido(ltFuncionariosLider, _Fnc_FuncionariosBE))
                {
                    ddlLider.SelectedValue = _Fnc_FuncionariosBE.Funcionario_Id.ToString();
                    ddlLider.Items.Insert(0, new ListItem("(Todos)", "%%"));
                }
                else
                {
                    ddlLider.Items.Insert(0, new ListItem("(Deshabilitado)", "-"));
                }
            else
            {
                ddlLider.Items.Insert(0, new ListItem("(Todos)", "%%"));
            }
        }

        private void GenerarTabla(string _Anio, string _Superior, string _Departamento_id, string _Estado)
        {
            DataTable Resultados = _Fnc_FuncionariosBL.ListarEVA_FuncionariosBySuperior(_Anio, _Superior, _Departamento_id, _Estado);
            rpPlanAccion.DataSource = Resultados;
            rpPlanAccion.DataBind();
        }
        protected void ibnCumplir_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            short _Funcionario_id = short.Parse(((Label)fila.Controls[1]).Text);
            int Eva = _EVA_EvaluacionBL.ExisteEva_Evaluacion(_Funcionario_id, ddlAnio.SelectedValue + "-" + ddlTipo.SelectedValue);

            if (Eva == 0)
            {
                RegistrarEvaluacionColega(_Funcionario_id, ddlAnio.SelectedValue + "-" + ddlTipo.SelectedValue);
            }
            else
            {
                Response.Redirect("actualizarEvaluacion.aspx?Evaluacion_id=" + Eva);
            }
            //GenerarTabla(((Fnc_FuncionariosBE)Session["FNC_Funcionarios"]).Funcionario_Id);
        }
        private void LlenarComboDepartamento()
        {
            lTTB_DepartamentoBE = _TB_DepartamentoBL.ListarTB_DepartamentoSuperiorO_Act(((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id);

            ddlDepartamento.DataSource = lTTB_DepartamentoBE;
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Elija una Opcion..", "%%"));
        }
        private void LlenarComboDepartamentoAll()
        {
            lTTB_DepartamentoBE = _TB_DepartamentoBL.ListarTB_Departamento_All("%%");
            ddlDepartamento.DataSource = lTTB_DepartamentoBE;
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Elija una Opcion..", "%%"));
        }

        private void RegistrarEvaluacionColega(short _Empleado_id, string _Anio)
        {
            try
            {
                var _mietq_etiqueta = _EVA_EvaluacionBE;
                _mietq_etiqueta.Fecha_registro = DateTime.ParseExact(fecha_actual, "dd/MM/yyyy", null);
                // _mietq_etiqueta.Departamento_id = Convert.ToInt16(ddlDepartamento.SelectedValue);
                _mietq_etiqueta.Empleado_id = _Empleado_id;
                _mietq_etiqueta.Lider_id = Convert.ToInt32(((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id);
                _mietq_etiqueta.Anio = _Anio;
                _mietq_etiqueta.Tipo = Convert.ToInt32(ddlTipo.SelectedValue);
                int vexito = _EVA_EvaluacionBL.InsertarEVA_Evaluacion(_EVA_EvaluacionBE);

                if (vexito != 0)
                {
                    Response.Redirect("actualizarEvaluacion.aspx?Evaluacion_id=" + vexito + "&registro=exito");
                }
                else
                {
                    //Response.Redirect("error.aspx?error=" + vexito);
                }

            }
            catch (Exception ex)
            {
                //lblMensaje.Text = ex.ToString();
            }
        }

        private bool buscarEmpleado(Fnc_FuncionariosBE obeEmpleado)
        {
            bool exitoIdEmpleado = true;
            if (!ddlDepartamento.SelectedValue.Equals("%%")) exitoIdEmpleado = (obeEmpleado.Area_Id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdEmpleado);
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _anio, _lider;
            _anio = ddlAnio.SelectedValue + "-" + ddlTipo.SelectedValue;
            _lider = ddlLider.SelectedValue;
            GenerarTabla(_anio, ddlLider.SelectedValue, ddlDepartamento.SelectedValue, ddlEstado.SelectedValue);


        }

        protected void rpPlanAccion_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Label lblBoton = (Label)e.Item.FindControl("lblBoton");
                ImageButton btn = (ImageButton)e.Item.FindControl("ibnCumplir");
                if (btn != null)
                {
                    btn.ImageUrl = "~/Comportamiento/Images/" + lblBoton.Text;
                }
            }
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            string _anio, _lider;
            _anio = ddlAnio.SelectedValue + "-" + ddlTipo.SelectedValue;
            _lider = ddlLider.SelectedValue;
            ExportToExcel(_anio, ddlLider.SelectedValue, ddlDepartamento.SelectedValue, ddlEstado.SelectedValue);

        }

        private void ExportToExcel(string _Anio, string _Superior, string _Departamento_id, string _Estado)
        {
            Response.Redirect("download.aspx?_Anio=" + _Anio + "&_Superior=" + _Superior + "&_Departamento_id=" + _Departamento_id + "&_Estado=" + _Estado, false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}