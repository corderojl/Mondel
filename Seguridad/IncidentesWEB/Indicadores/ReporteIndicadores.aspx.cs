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
    public partial class ReporteIndicadores : System.Web.UI.Page
    {
        EVA_EvaluacionBL _EVA_EvaluacionBL = new EVA_EvaluacionBL();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        EVA_CategoriaBL _EVA_CategoriaBL = new EVA_CategoriaBL();
        EVA_SubCategoriaBL _EVA_SubCategoriaBL = new EVA_SubCategoriaBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_AreaLaborBL _TB_AreaLaborBL = new TB_AreaLaborBL();

        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<EVA_SubCategoriaBE> lTEVA_SubCategoriaBE;
        List<Fnc_FuncionariosBE> lTFnc_FuncionariosBE;
        List<TB_AreaLaborBE> lTTB_AreaLaborBE;

        private List<EVA_SubCategoriaBE> lbeFiltroSu;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                llenarComboDepartamento();
                llenarComboEmpleados();
                llenarComboLider();
                lTEVA_SubCategoriaBE = _EVA_SubCategoriaBL.ListarEVA_SubCategoriaO_Act();
                Session["SubCategoria"] = lTEVA_SubCategoriaBE;
                llenarComboCategoria();
                llenarComboAreaLaboral();
            }
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
        private void llenarComboCategoria()
        {
            ddlCategoria.DataSource = _EVA_CategoriaBL.ListarEVA_CategoriaO_Act();
            ddlCategoria.DataValueField = "Categoria_id";
            ddlCategoria.DataTextField = "Categoria_desc";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("(Todos)", "%%"));
            llenarComboSubCategoria();
        }

        private bool buscarSubCategorias(EVA_SubCategoriaBE obeSubCategoria)
        {
            bool exitoIdSubCategoria = true;
            if (!ddlCategoria.SelectedValue.Equals("%%")) exitoIdSubCategoria = (obeSubCategoria.Categoria_id.ToString().Equals(ddlCategoria.SelectedValue));
            return (exitoIdSubCategoria);
        }
        private void llenarComboSubCategoria()
        {
            lTEVA_SubCategoriaBE = (List<EVA_SubCategoriaBE>)Session["SubCategoria"];
            Predicate<EVA_SubCategoriaBE> pred = new Predicate<EVA_SubCategoriaBE>(buscarSubCategorias);
            lbeFiltroSu = lTEVA_SubCategoriaBE.FindAll(pred);
            Session["FiltroSu"] = lbeFiltroSu;

            ddlSubCategoria.DataSource = lbeFiltroSu;
            ddlSubCategoria.DataValueField = "SubCategoria_id";
            ddlSubCategoria.DataTextField = "SubCategoria_desc";
            ddlSubCategoria.DataBind();
            ddlSubCategoria.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }

        private void llenarComboLider()
        {
            lTFnc_FuncionariosBE = _Fnc_FuncionariosBL.ListarFNC_FuncionariosLideresO_Act();
            ddlLider.DataSource = lTFnc_FuncionariosBE;
            ddlLider.DataValueField = "Funcionario_id";
            ddlLider.DataTextField = "Funcionario_nome";
            ddlLider.DataBind();
            ddlLider.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }

        private void llenarComboEmpleados()
        {
            lTFnc_FuncionariosBE = _Fnc_FuncionariosBL.ListarFnc_FuncionariosO_Act();
            ddlEmpleado.DataSource = lTFnc_FuncionariosBE;
            ddlEmpleado.DataValueField = "Funcionario_id";
            ddlEmpleado.DataTextField = "Funcionario_nome";
            ddlEmpleado.DataBind();
            ddlEmpleado.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }

        private void llenarComboDepartamento()
        {
            lTTB_DepartamentoBE = _TB_DepartamentoBL.ListarTB_Departamento_All("%%");;
            ddlDepartamento.DataSource = lTTB_DepartamentoBE;
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string _Empleado, _Categoria, _SubCategoria, _Lider, _Departamento_id,
                _Tipo, _Anio, _Clasificacion, _Estado, _Arealaboral;
            _Departamento_id = ddlDepartamento.SelectedValue;
            _Empleado = ddlEmpleado.SelectedValue;
            _Categoria = ddlCategoria.SelectedValue;
            _SubCategoria = ddlSubCategoria.SelectedValue;
            _Lider = ddlLider.SelectedValue;
            _Tipo = ddlTipo.SelectedValue;
            _Anio = ddlAnio.SelectedValue;
            _Clasificacion = ddlClasificacion.SelectedValue;
            _Estado = ddlEstado.SelectedValue;
            _Arealaboral = ddlAreaLaboral.SelectedValue;
            generarTabla(_Empleado, _Categoria, _SubCategoria, _Lider, _Departamento_id,
                _Tipo, _Anio, _Clasificacion, _Estado, _Arealaboral);

        }

        private void generarTabla(string _Empleado, string _Categoria, string _SubCategoria, string _Lider, string _Departamento_id, string _Tipo, string _Anio, string _Clasificacion, string _Estado, string _Arealaboral)
        {
            DataTable Resultados = _EVA_EvaluacionBL.ListarEVA_EvaluacionFind(_Empleado, _Categoria, _SubCategoria, _Lider, _Departamento_id,
                _Tipo, _Anio, _Clasificacion, _Estado, _Arealaboral);

            DataTable Estadisticas = _EVA_EvaluacionBL.ListarEVA_EvaluacionEstadistica(_Empleado, _Categoria, _SubCategoria, _Lider, _Departamento_id,
                _Tipo, _Anio, _Clasificacion, _Estado, _Arealaboral);
            StringBuilder Tabla = new StringBuilder();
            StringBuilder TablaE = new StringBuilder();

            string _idEvaluacion;

            int TotalRegistros = Resultados.Rows.Count;
            Tabla.AppendLine("<table id=\"myTable\" class=\"tablesorter\">");
            Tabla.AppendLine("<thead>");
            string cabecera = "";
            cabecera = "<th>COD.</th><th width=\"210\"> EMPLEADO </th><th> CATEGORIA </th><th> SUBCATEGORIA </th><th> EVALUADOR </th><th> DEPARTAMENTO </th><th> TIPO </th><th> AÑO </th><th>PUNTOS</th><th>CLASIFICACIÓN</th><th> ESTADO </th>";
            Tabla.AppendLine(cabecera);
            Tabla.AppendLine("</thead>");
            Tabla.AppendLine("<tbody>");

            for (int i = 0; i < TotalRegistros; i++)
            {
                //fecha = DateTime.ParseExact(Resultados.Rows[i]["Fecha_incidente"].ToString(), "dd/MM/yyyy", null);
                _idEvaluacion = Resultados.Rows[i]["Evaluacion_id"].ToString();
                //if ((i % 2) == 0)
                //    Tabla.AppendLine("<tr bgcolor='#ECECEC'>");
                //else
                Tabla.AppendLine("<tr>");
                Tabla.Append("<td>" + "<a href=\"#\" onClick=\"PopUp('rptEvaluacionColega.aspx?Evaluacion_id=" + _idEvaluacion + "',20,20,950,678); return false;\"> " + _idEvaluacion + " </a></td>");

                Tabla.Append("<td>" + Resultados.Rows[i]["Funcionario_nome"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Categoria_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["SubCategoria_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Lider"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Departamento_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Tipo"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Anio"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Puntos"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Clasificacion"] + "</td>");
                string color = "";
                color = "style=\"background-color: " + Resultados.Rows[i]["Color"].ToString()+ ";\"";
                Tabla.Append("<td " + color + ">" + Resultados.Rows[i]["Estado"] + "</td>");
                Tabla.Append(Environment.NewLine);
                Tabla.AppendLine("</tr>");
            }
            Tabla.AppendLine("</tbody>");
            Tabla.AppendLine("</table>");
            ltlResults.Text = Tabla.ToString();

            //Generar Tabla Estadistica
            TotalRegistros = Estadisticas.Rows.Count;
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
                TablaE.Append("<td>" + Estadisticas.Rows[i]["Estado"] + "</td>");
                TablaE.Append("<td>" + num + "</td>");
                TablaE.Append("<td>" + decimal.Round(Convert.ToDecimal(num * 100.00 / total), 2) + "%</td>");
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
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
           string _Empleado, _Categoria, _SubCategoria, _Lider, _Departamento_id,
                _Tipo, _Anio, _Clasificacion, _Estado, _Arealaboral;
            _Departamento_id = ddlDepartamento.SelectedValue;
            _Empleado = ddlEmpleado.SelectedValue;
            _Categoria = ddlCategoria.SelectedValue;
            _SubCategoria = ddlSubCategoria.SelectedValue;
            _Lider = ddlLider.SelectedValue;
            _Tipo = ddlTipo.SelectedValue;
            _Anio = ddlAnio.SelectedValue;
            _Clasificacion = ddlClasificacion.SelectedValue;
            _Estado = ddlEstado.SelectedValue;
            _Arealaboral = ddlAreaLaboral.SelectedValue;
            ExportToExcel(_Empleado, _Categoria, _SubCategoria, _Lider, _Departamento_id,
                _Tipo, _Anio, _Clasificacion, _Estado, _Arealaboral);
            
           
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarComboSubCategoria();
        }
        private void ExportToExcel(string _Empleado, string _Categoria, string _SubCategoria, string _Lider, string _Departamento_id, string _Tipo, string _Anio, string _Clasificacion, string _Estado, string _Arealaboral)
        {
            DataView dvDefectos = new DataView(_EVA_EvaluacionBL.ListarEVA_EvaluacionFindXML(_Empleado, _Categoria, _SubCategoria, _Lider, _Departamento_id,
                _Tipo, _Anio, _Clasificacion, _Estado, _Arealaboral));
            if (dvDefectos.Table.Rows.Count > 0)
            {
                try
                {
                    string filename = "Reporte General.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    GridView dgGrid = new GridView();
                    dgGrid.DataSource = dvDefectos;
                    dgGrid.DataBind();
                    dgGrid.RenderControl(hw);
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();
                }
                catch (Exception x)
                {

                }
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            string _Empleado, _Categoria, _SubCategoria, _Lider, _Departamento_id,
                _Tipo, _Anio, _Clasificacion, _Estado, _Arealaboral;
            string script = "";
            _Departamento_id = ddlDepartamento.SelectedValue;
            _Empleado = ddlEmpleado.SelectedValue;
            _Categoria = ddlCategoria.SelectedValue;
            _SubCategoria = ddlSubCategoria.SelectedValue;
            _Lider = ddlLider.SelectedValue;
            _Tipo = ddlTipo.SelectedValue;
            _Anio = ddlAnio.SelectedValue;
            _Clasificacion = ddlClasificacion.SelectedValue;
            _Estado = ddlEstado.SelectedValue;
            _Arealaboral = ddlAreaLaboral.SelectedValue;
            script = @"PopUp('rptEvaluacionColegaAll.aspx?Departamento=" + _Departamento_id + "&Empleado=" + _Empleado + "&Categoria=" + _Categoria + "&SubCategoria=" + _SubCategoria + "&Lider=" + _Lider + "&Tipo=" + _Tipo + "&Anio=" + _Anio + "&Clasificacion=" + _Clasificacion + "&Estado=" + _Estado + "&Arealaboral=" + _Arealaboral+"')" ;
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
            //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", script, true);
        }
    }
}