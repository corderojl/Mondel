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
    public partial class ReporteCurva : System.Web.UI.Page
    {
        EVA_EvaluacionBL _EVA_EvaluacionBL = new EVA_EvaluacionBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TB_AreaLaborBL _TB_AreaLaborBL = new TB_AreaLaborBL();
        EVA_CategoriaBL _EVA_CategoriaBL = new EVA_CategoriaBL();

        List<EVA_CurvaBE> lEVA_CurvaBE;
        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<Fnc_FuncionariosBE> lFNC_FuncionariosBE;
        List<TB_AreaLaborBE> lTTB_AreaLaborBE;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                llenarComboDepartamento();
                llenarComboLider();
                llenarComboAreaLaboral();
                llenarComboCategoria();
                string _Departamento_id, _Lider_id, _Anio, _Tipo, _AreaLabor, _Categoria;
                _Departamento_id = ddlDepartamento.SelectedValue;
                _Lider_id = ddlLider.SelectedValue;
                _Anio = ddlAnio.SelectedValue;
                _Tipo = ddlTipo.SelectedValue;
                _AreaLabor = ddlAreaLaboral.SelectedValue;
                _Categoria = ddlCategoria.SelectedValue;
                generarGraficoCurva(_Departamento_id, _Lider_id, _Anio, _Tipo, _AreaLabor, _Categoria);

            }
        }

        private void llenarComboCategoria()
        {
            ddlCategoria.DataSource = _EVA_CategoriaBL.ListarEVA_CategoriaO_Act();
            ddlCategoria.DataValueField = "Categoria_id";
            ddlCategoria.DataTextField = "Categoria_desc";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }

        private void llenarComboAreaLaboral()
        {
            lTTB_AreaLaborBE = _TB_AreaLaborBL.ListarTB_AreaLaborO_Act();
            ddlAreaLaboral.DataSource = lTTB_AreaLaborBE;
            ddlAreaLaboral.DataValueField = "AreaLabor_id";
            ddlAreaLaboral.DataTextField = "AreaLabor_desc";
            ddlAreaLaboral.DataBind();
            ddlAreaLaboral.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }

        private void llenarComboDepartamento()
        {
            lTTB_DepartamentoBE = _TB_DepartamentoBL.ListarTB_Departamento_All("%%");
            ddlDepartamento.DataSource = lTTB_DepartamentoBE;
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }

        private void llenarComboLider()
        {
            lFNC_FuncionariosBE = _Fnc_FuncionariosBL.ListarFNC_FuncionariosLideresO_Act();
            ddlLider.DataSource = lFNC_FuncionariosBE;
            ddlLider.DataValueField = "Funcionario_id";
            ddlLider.DataTextField = "Funcionario_nome";
            ddlLider.DataBind();
            ddlLider.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }

        protected string obtenerDatos(string _Departamento_id, string _Lider_id, string _Anio, string _Tipo, string _AreaLabor, string _Categoria)
        {
            lEVA_CurvaBE = _EVA_EvaluacionBL.TraerEVA_EvaluacionCurva(_Departamento_id, _Lider_id, _Anio, _Tipo, _AreaLabor, _Categoria);

            string strDatos;


            strDatos = "[['Clasificación', 'Curva Real', 'Curva Ideal'],";
            foreach (EVA_CurvaBE curva in lEVA_CurvaBE)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + curva.Clasificacion + "'," + curva.Porcentaje + "," + curva.Peso;
                strDatos = strDatos + "],";

            }
            strDatos = strDatos + "]";
            return strDatos;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string _Departamento_id, _Lider_id, _Anio, _Tipo, _AreaLabor, _Categoria;
            _Departamento_id = ddlDepartamento.SelectedValue;
            _Lider_id = ddlLider.SelectedValue;
            _Tipo = ddlTipo.SelectedValue;
            if (_Tipo=="%%")
            {
                if (ddlAnio.SelectedValue != "%%")
                    _Anio = ddlAnio.SelectedValue + "%";
                else
                    _Anio = ddlAnio.SelectedValue;
            }
            else
            {
                _Anio = ddlAnio.SelectedValue + "-" + _Tipo;
            }
            _AreaLabor = ddlAreaLaboral.SelectedValue;
            _Categoria = ddlCategoria.SelectedValue;
            generarGraficoCurva(_Departamento_id, _Lider_id, _Anio, _Tipo, _AreaLabor, _Categoria);
        }

        private void generarGraficoCurva(string _Departamento_id, string _Lider_id, string _Anio, string _Tipo, string _AreaLabor, string _Categoria)
        {
            StringBuilder TablaE = new StringBuilder();
            DataTable Estadisticas = _EVA_EvaluacionBL.TraerEVA_EvaluacionEstadisticaCurva(_Departamento_id, _Lider_id, _Anio, _Tipo, _AreaLabor, _Categoria);
            int TotalRegistros = Estadisticas.Rows.Count;
            TablaE.AppendLine("<table border='1'>");
            int total = 0;
            int num = 0;
           
            for (int i = 0; i < TotalRegistros; i++)
            {
                total = total + Convert.ToInt32(Estadisticas.Rows[i]["numero"]);
            }

            for (int i = 0; i < TotalRegistros; i++)
            {                
                num = Convert.ToInt32(Estadisticas.Rows[i]["numero"]);
                TablaE.AppendLine("<tr>");
                TablaE.Append("<td>" + Estadisticas.Rows[i]["Clasificacion_desc"] + "</td>");
                TablaE.Append("<td>" + num + "</td>");
                if (total>0)
                TablaE.Append("<td>" + decimal.Round(Convert.ToDecimal(num * 100.00 / total), 2) + "%</td>");
                else
                    TablaE.Append("<td>0%</td>");
                TablaE.Append(Environment.NewLine);
                TablaE.AppendLine("</tr>");
            }
            TablaE.AppendLine("<tr>");
            TablaE.Append("<td>Total</td>");
            TablaE.Append("<td>" + total + "</td>");
            TablaE.Append("<td>100%</td>");
            TablaE.Append(Environment.NewLine);
            TablaE.AppendLine("</tr>");
            TablaE.AppendLine("</table>");
            ltrEstadistica.Text = TablaE.ToString();

            string _Datos = obtenerDatos(_Departamento_id, _Lider_id, _Anio, _Tipo, _AreaLabor, _Categoria);
            string script;
            if (_Datos != "")
                script = @"<script type='text/javascript'>
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);
        function drawChart() {
            var data = google.visualization.arrayToDataTable(" + _Datos + ");var options = {format: 'percent',pointSize: 5,title: 'Curva de Cumplimiento',curveType: 'function', legend: { position: 'Center' } };var chart = new google.visualization.LineChart(document.getElementById('curve_chart'));chart.draw(data, options);}</script>";

            else
            {
                script = @"[
              ['Clasificación', 'Curva', 'Curva Ideal'],
              ['Cumple Parcial', 0, 10],
              ['Cumple Bien', 0, 70],
              ['Sobresaliente', 0, 20],
            ]";

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
        }

    }
}