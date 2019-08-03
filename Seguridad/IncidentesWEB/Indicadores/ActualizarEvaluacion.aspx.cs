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
    public partial class ActualizarEvaluacion : System.Web.UI.Page
    {
        string fecha_actual;

        EVA_EvaluacionBE _EVA_EvaluacionBE = new EVA_EvaluacionBE();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        EVA_EvaluacionBL _EVA_EvaluacionBL = new EVA_EvaluacionBL();
        EVA_EvaluacionDetalleBL _EVA_EvaluacionDetalleBL = new EVA_EvaluacionDetalleBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        EVA_SubCategoriaBL _EVA_SubCategoriaBL = new EVA_SubCategoriaBL();
        TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();

        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<Fnc_FuncionariosBE> lTFnc_FuncionariosBE;

        TB_AccesosBE _TB_AccesosBE = new TB_AccesosBE();

        int _Evaluacion_id;
        string _RRHH;
        int medioanio;
        int anio;

        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime Hoy = DateTime.Today;
            fecha_actual = Hoy.ToString("dd/MM/yyyy");
            try
            {
                if (this.IsPostBack)
                {
                    _Evaluacion_id = Convert.ToInt32(Request.QueryString["Evaluacion_id"]);
                    _EVA_EvaluacionBE = _EVA_EvaluacionBL.TraerEVA_EvaluacionById(_Evaluacion_id);
                    acomodarTabla();
                }
                else
                {
                    _Evaluacion_id = Convert.ToInt32(Request.QueryString["Evaluacion_id"]);
                    _EVA_EvaluacionBE = _EVA_EvaluacionBL.TraerEVA_EvaluacionById(_Evaluacion_id);
                    lTFnc_FuncionariosBE = _Fnc_FuncionariosBL.ListarFnc_FuncionariosO_Act();
                    Session["Empleado"] = lTFnc_FuncionariosBE;
                    LlenarComboDepartamento();
                    ddlDepartamento.SelectedValue = _EVA_EvaluacionBE.Departamento_id.ToString();
                    LlenarComboEmpleado();
                    ddlEmpleado.SelectedValue = _EVA_EvaluacionBE.Empleado_id.ToString();
                    ddlAnio.SelectedValue = _EVA_EvaluacionBE.Anio.Substring(0, 4);
                    ddlTipo.SelectedValue = _EVA_EvaluacionBE.Tipo.ToString();
                    GenerarTabla(_Evaluacion_id);
                    GenerarTabla2(_Evaluacion_id);
                    GenerarTabla3(_Evaluacion_id);
                    GenerarTablaEstadistica();

                    ltrPrint.Text = "<a href=\"#\" onclick=\"PopUp('rptEvaluacionColega.aspx?Evaluacion_id=" + (Convert.ToInt32(Request.QueryString["Evaluacion_id"])) + " ',20,20,950,678); return false;\"> <img src=\"../Images/Print.png\"  width=\"30px\"> </a>";
                }
            }
            catch (Exception x)
            {
                // Response.Redirect("error.aspx");
            }
        }

        private void acomodarTabla()
        {
            string script = @"<script type='text/javascript'>
        $(function () {
            //Created By: Brij Mohan
            //Website: http://techbrij.com
            function groupTable($rows, startIndex, total) {
                if (total === 0) {
                    return;
                }
                var i, currentIndex = startIndex, count = 1, lst = [];
                var tds = $rows.find('td:eq(' + currentIndex + ')');
                var ctrl = $(tds[0]);
                lst.push($rows[0]);
                for (i = 1; i <= tds.length; i++) {
                    if (ctrl.text() == $(tds[i]).text()) {
                        count++;
                        $(tds[i]).addClass('deleted');
                        lst.push($rows[i]);
                    }
                    else {
                        if (count > 1) {
                            ctrl.attr('rowspan', count);
                            groupTable($(lst), startIndex + 1, total - 1)
                        }
                        count = 1;
                        lst = [];
                        ctrl = $(tds[i]);
                        lst.push($rows[i]);
                    }
                }
            }
            groupTable($('#myTable tr:has(td)'), 0, 3);
            $('#myTable .deleted').remove();
groupTable($('#myTable2 tr:has(td)'), 0, 3);
            $('#myTable2 .deleted').remove();
        });
</script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
        }

        private string[] traerCategoria(int SubCategoria_id)
        {

            return _EVA_SubCategoriaBL.TraerSubCategoria(SubCategoria_id);
        }


        private void LlenarComboDepartamento()
        {
            lTTB_DepartamentoBE = _TB_DepartamentoBL.ListarTB_DepartamentoO_Act("%%");
            ddlDepartamento.DataSource = lTTB_DepartamentoBE;
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();

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
        private void LlenarComboEmpleado()
        {
            ddlEmpleado.DataSource = lTFnc_FuncionariosBE;
            ddlEmpleado.DataValueField = "Funcionario_id";
            ddlEmpleado.DataTextField = "Funcionario_Nome";
            ddlEmpleado.DataBind();
        }


        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            int _Estado;
            EVA_EvaluacionDetalleBE _EVA_EvaluacionDetalleBE = new EVA_EvaluacionDetalleBE();
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            int _Registro_id = int.Parse(((Label)fila.Controls[3]).Text);
            string _Var = ((Label)fila.Controls[5]).Text;
            string _Puntos = ((Label)fila.Controls[11]).Text;

            if (_Var == "Sancionado")
                _EVA_EvaluacionDetalleBE.PuntosOpt = 0;
            else
                if (_Var == "Elegido")
                    _EVA_EvaluacionDetalleBE.PuntosOpt = 0;
                else
                    if (_Var == "Participa")
                        _EVA_EvaluacionDetalleBE.PuntosOpt = 0;
                    else
                        _EVA_EvaluacionDetalleBE.PuntosOpt = int.Parse(_Puntos);
            _EVA_EvaluacionDetalleBE.Evaluacion_id = Convert.ToInt32(Request.QueryString["Evaluacion_id"]);
            _EVA_EvaluacionDetalleBE.EvaluacionDetalle_id = _Registro_id;
            _EVA_EvaluacionDetalleBE.Observacion = "";

            if (!_EVA_EvaluacionDetalleBL.ActualizarEVA_EvaluacionDetalle(_EVA_EvaluacionDetalleBE))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('No se pudo actualizar!');", true);
            }

            GenerarTabla3(int.Parse(Request.QueryString["Evaluacion_id"]));
            GenerarTablaEstadistica();
        }

        protected void ibnActualizar1_Click(object sender, ImageClickEventArgs e)
        {
            EVA_EvaluacionDetalleBE _EVA_EvaluacionDetalleBE = new EVA_EvaluacionDetalleBE();
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            int _Registro_id = int.Parse(((Label)fila.Controls[1]).Text);
            string _Var = ((Label)fila.Controls[5]).Text;
            // string _Puntos = ((Label)fila.Controls[7]).Text;

            if (_Var == "Cumple")
                _EVA_EvaluacionDetalleBE.PuntosOpt = 0;
            else

                _EVA_EvaluacionDetalleBE.PuntosOpt = 1;
            _EVA_EvaluacionDetalleBE.Evaluacion_id = Convert.ToInt32(Request.QueryString["Evaluacion_id"]);
            _EVA_EvaluacionDetalleBE.EvaluacionDetalle_id = _Registro_id;
            _EVA_EvaluacionDetalleBE.Observacion = "";

            if (!_EVA_EvaluacionDetalleBL.ActualizarEVA_EvaluacionDetalle(_EVA_EvaluacionDetalleBE))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('No se pudo actualizar!');", true);
            }

            GenerarTabla(int.Parse(Request.QueryString["Evaluacion_id"]));
            GenerarTablaEstadistica();


        }
        private void GenerarTabla(int _Evaluacion_id)
        {
            DataTable Resultados = _EVA_EvaluacionDetalleBL.BuscarEVA_EvaluacionDetalleByEvaluacion(_Evaluacion_id, "1");
            rpTrigger.DataSource = Resultados;
            rpTrigger.DataBind();
            Label lbl1, lbl2;
            float _resp = 0, _num = 0; ;
            for (int i = 0; i < rpTrigger.Items.Count; i++)
            {
                lbl1 = rpTrigger.Items[i].FindControl("lblEstado") as Label;
                lbl2 = rpTrigger.Items[i].FindControl("lblPuntos") as Label;
                if (lbl1.Text == "Cumple")
                {
                    _resp = _resp + float.Parse(lbl2.Text);
                }
                _num = _num + int.Parse(lbl2.Text);
            }
            if (_num == 0 & _resp == 0)
                lblHard.Text = "0";
            else
                lblHard.Text = ((_resp / _num) * 50).ToString("0.##");
            string[] _Cat;
            _Cat = traerCategoria(_EVA_EvaluacionBE.SubCategoria_id);
            lblCategoria.Text = _Cat[1];
            lblSubCategoria.Text = _Cat[0];


        }

        private void GenerarTabla2(int _Evaluacion_id)
        {
            DataTable Resultados = _EVA_EvaluacionDetalleBL.BuscarEVA_EvaluacionDetalleByEvaluacion(_Evaluacion_id, "2");
            rpDetalle2.DataSource = Resultados;
            rpDetalle2.DataBind();
            Label lbl2;
            DropDownList ddl;
            float _resp = 0, _num = 0, _temp = 0;
            for (int i = 0; i < rpDetalle2.Items.Count; i++)
            {
                ddl = rpDetalle2.Items[i].FindControl("ddlEstado") as DropDownList;
                //ddl = = (DropDownList)e.Item.FindControl("ddlEstado")
                lbl2 = rpDetalle2.Items[i].FindControl("lblPuntos") as Label;
                if (ddl.SelectedValue != "")
                {
                    _temp = int.Parse(ddl.SelectedValue);
                    _resp = _resp + _temp;
                    _num = _num + int.Parse(lbl2.Text);
                }
            }
            if (_num == 0 & _resp == 0)
                lblSoft.Text = "0";
            else
                lblSoft.Text = ((_resp / _num) * 30).ToString("0.##");
            // lblNotaTotal2.Text = _num.ToString();
        }

        private void GenerarTabla3(int _Evaluacion_id)
        {
            DataTable Resultados = _EVA_EvaluacionDetalleBL.BuscarEVA_EvaluacionDetalleByEvaluacion(_Evaluacion_id, "3");
            rpDetalle3.DataSource = Resultados;
            rpDetalle3.DataBind();
            Label lbl1, lbl2;
            float _resp = 0; //_num = 0, _temp = 0;
            for (int i = 0; i < rpDetalle3.Items.Count; i++)
            {
                lbl1 = rpDetalle3.Items[i].FindControl("lblEstado") as Label;
                lbl2 = rpDetalle3.Items[i].FindControl("lblPuntos") as Label;
                if (lbl1.Text == "Participa")
                {
                    _resp = _resp + float.Parse(lbl2.Text);
                }
                if (lbl1.Text == "Sancionado")
                {
                    _resp = _resp + float.Parse(lbl2.Text);
                }
                if (lbl1.Text == "Elegido")
                {
                    _resp = _resp + float.Parse(lbl2.Text);
                }
                // _num = _num + int.Parse(lbl2.Text);
            }

            RRHH.Text = ((_resp / 3.0) * 20).ToString("0.##");
            if (float.Parse(RRHH.Text) < 0.0)
                lblRRHH.Text = "Sancionado";
            else
                lblRRHH.Text = RRHH.Text;
        }
        private void GenerarTablaEstadistica()
        {
            float _Suma = 0;
            string _clas = _EVA_EvaluacionBL.TraerEVA_LimiteCalsificacion(int.Parse(Request.QueryString["Evaluacion_id"]));
            lblNombre.Text = ddlEmpleado.SelectedItem.ToString();
            //lblSoft.Text = lblNota2.Text;
            if (float.Parse(RRHH.Text) < 0)
                _Suma = 0;
            else
                _Suma = float.Parse(lblHard.Text) + float.Parse(lblSoft.Text) + float.Parse(RRHH.Text);
            lblSuma.Text = (_Suma).ToString();
           // lblPuntajeTotal.Text = (_Suma).ToString();
            lblClas.Text = _clas;
            lblClasificacion.Text = _clas;
            if (!_EVA_EvaluacionBL.ActualizarEVA_EvaluacionNota(int.Parse(Request.QueryString["Evaluacion_id"]), _Suma))
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('No se actualizó nota en el reporte, contacte al administrador');", true);

        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            EVA_EvaluacionBE _EVA_EvaluacionBE = new EVA_EvaluacionBE();
            try
            {
                var _mietq_etiqueta = _EVA_EvaluacionBE;
                _mietq_etiqueta.Evaluacion_id = int.Parse(Request.QueryString["Evaluacion_id"]);
                _mietq_etiqueta.Departamento_id = Convert.ToInt16(ddlDepartamento.SelectedValue);
                _mietq_etiqueta.Empleado_id = Convert.ToInt16(ddlEmpleado.SelectedValue);
                _mietq_etiqueta.Lider_id = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id;
                //_mietq_etiqueta.Fecha_registro = short.Parse(rblCompletar.SelectedValue);
                _mietq_etiqueta.activo = true;
                bool vexito = _EVA_EvaluacionBL.ActualizarEVA_Evaluacion(_EVA_EvaluacionBE);
                if (vexito)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('La Evaluación se actualizo con éxito');", true);
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

        protected void rpTrigger_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                ImageButton ib = (ImageButton)e.Item.FindControl("ibnActualizar");

                if (ib != null)
                {

                    medioanio = ((DateTime.Today.AddMonths(-6).Month - 1) / 6) + 1;
                    anio = DateTime.Today.AddMonths(-6).Year;
                    if (ddlAnio.SelectedValue == anio.ToString() && ddlTipo.SelectedValue == medioanio.ToString())
                    {
                        ib.Enabled = true;
                    }
                    else
                    {
                        ib.Enabled = false;
                    }
                }
            }
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

            EVA_EvaluacionDetalleBE _EVA_EvaluacionDetalleBE = new EVA_EvaluacionDetalleBE();
            DropDownList ibn = (DropDownList)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            int _Registro_id = int.Parse(((Label)fila.Controls[1]).Text);
            string _Var = ((DropDownList)fila.Controls[5]).SelectedValue;
            if (_Var != "")
            {
                if (int.Parse(_Var) >= 0)
                {
                    _EVA_EvaluacionDetalleBE.PuntosOpt = int.Parse(_Var);
                    _EVA_EvaluacionDetalleBE.Evaluacion_id = Convert.ToInt32(Request.QueryString["Evaluacion_id"]);
                    _EVA_EvaluacionDetalleBE.EvaluacionDetalle_id = _Registro_id;
                    _EVA_EvaluacionDetalleBE.Observacion = "";

                    // ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('No puede cerrar Riesgo si existe Planes pendientes');", true);

                    if (!_EVA_EvaluacionDetalleBL.ActualizarEVA_EvaluacionDetalle(_EVA_EvaluacionDetalleBE))
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('No se pudo actualizar!');", true);
                    }
                    GenerarTabla(int.Parse(Request.QueryString["Evaluacion_id"]));
                    GenerarTabla2(int.Parse(Request.QueryString["Evaluacion_id"]));
                    GenerarTabla3(int.Parse(Request.QueryString["Evaluacion_id"]));
                    GenerarTablaEstadistica();
                }
            }
        }

        protected void rpDetalle2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Label lblPuntosOpt = (Label)e.Item.FindControl("lblPuntosOpt");
                string id;
                DropDownList ddl = (DropDownList)e.Item.FindControl("ddlEstado");

                if (ddl != null)
                {
                    id = lblPuntosOpt.Text;
                    ddl.SelectedValue = id;
                    medioanio = ((DateTime.Today.AddMonths(-6).Month - 1) / 6) + 1;
                    anio = DateTime.Today.AddMonths(-6).Year;
                    if (ddlAnio.SelectedValue == anio.ToString() && ddlTipo.SelectedValue == medioanio.ToString())
                    {
                        ddl.Enabled = true;
                    }
                    else
                    {
                        ddl.Enabled = false;
                    }
                }

            }
        }

        protected void rpDetalle3_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                ImageButton ib = (ImageButton)e.Item.FindControl("ibnActualizar");

                if (ib != null)
                {

                    medioanio = ((DateTime.Today.AddMonths(-6).Month - 1) / 6) + 1;
                    anio = DateTime.Today.AddMonths(-6).Year;
                    if (ddlAnio.SelectedValue == anio.ToString() && ddlTipo.SelectedValue == medioanio.ToString())
                    {

                        _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id, 7);
                        if (_TB_AccesosBE.Permiso == 2)
                            ib.Enabled = true;
                        else
                            ib.Enabled = false;
                    }
                    else
                    {
                        ib.Enabled = false;
                    }
                }
            }
        }

        protected void txtObservacion_TextChanged(object sender, EventArgs e)
        {
            EVA_EvaluacionDetalleBE _EVA_EvaluacionDetalleBE = new EVA_EvaluacionDetalleBE();
            TextBox ibn = (TextBox)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            int _EvaluacionDetalle_id = int.Parse(((Label)fila.Controls[1]).Text);
            string _Observacion = ((TextBox)fila.Controls[13]).Text;

            // ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('No puede cerrar Riesgo si existe Planes pendientes');", true);

            if (!_EVA_EvaluacionDetalleBL.ActualizarEVA_EvaluacionDetalleObservacion(_EvaluacionDetalle_id, _Observacion))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('No se pudo actualizar!');", true);
            }
        }
        protected void txtObservacion_TextChanged2(object sender, EventArgs e)
        {
            EVA_EvaluacionDetalleBE _EVA_EvaluacionDetalleBE = new EVA_EvaluacionDetalleBE();
            TextBox ibn = (TextBox)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            int _EvaluacionDetalle_id = int.Parse(((Label)fila.Controls[1]).Text);
            string _Observacion = ((TextBox)fila.Controls[11]).Text;

            // ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('No puede cerrar Riesgo si existe Planes pendientes');", true);

            if (!_EVA_EvaluacionDetalleBL.ActualizarEVA_EvaluacionDetalleObservacion(_EvaluacionDetalle_id, _Observacion))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('No se pudo actualizar!');", true);
            }
        }
        protected void txtObservacion_TextChanged3(object sender, EventArgs e)
        {
            TextBox ibn = (TextBox)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            int _EvaluacionDetalle_id = int.Parse(((Label)fila.Controls[3]).Text);
            string _Observacion = ((TextBox)fila.Controls[13]).Text;

            // ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('No puede cerrar Riesgo si existe Planes pendientes');", true);

            if (!_EVA_EvaluacionDetalleBL.ActualizarEVA_EvaluacionDetalleObservacion(_EvaluacionDetalle_id, _Observacion))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('No se pudo actualizar!');", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_EVA_EvaluacionBL.EliminarEVA_Evaluacion(int.Parse(Request.QueryString["Evaluacion_id"])))
            {
                Response.Redirect("RegistrarEvaluacion.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('No se pudo eliminar la evaluación, por favor contactese con el administrador!');", true);
            }
        }

    }
}