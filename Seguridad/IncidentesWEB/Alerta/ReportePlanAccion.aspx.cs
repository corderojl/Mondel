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
    public partial class ReportePlanAccion : System.Web.UI.Page
    {
        string fecha_actual;
        protected DataView dvResponsable;

        //datatable
        protected DataTable dtResponsable;

        TB_PlanAccionBL _TB_PlanAccionBL = new TB_PlanAccionBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();

        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<Fnc_FuncionariosBE> lTFnc_FuncionariosBE;
        
        DateTime Hoy;

        protected void Page_Load(object sender, EventArgs e)
        {
            Hoy = DateTime.Today;
            if (this.IsPostBack)
            {

            }
            else
            {
                fecha_actual = Hoy.ToString("dd/MM/yyyy");
                string mes = Hoy.Month.ToString();
                string anio = Hoy.Year.ToString();
                if (mes.Length < 2)
                    mes = "0" + mes;
                txtFecha.Text = "01/" + mes + "/" + anio;
                txtFecha0.Text = fecha_actual;
                LlenarComboDepartamento();
                LlenarComboResponsables();
            }
        }
        private void LlenarComboDepartamento()
        {
            lTTB_DepartamentoBE = _TB_DepartamentoBL.ListarTB_Departamento_All("1");
            ddlDepartamento.DataSource = lTTB_DepartamentoBE;
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }
        private void LlenarComboResponsables()
        {
            lTFnc_FuncionariosBE = _Fnc_FuncionariosBL.ListarFnc_FuncionariosO_Act();
            ddlResponsable.DataSource = lTFnc_FuncionariosBE;
            ddlResponsable.DataValueField = "Funcionario_id";
            ddlResponsable.DataTextField = "Funcionario_nome";
            ddlResponsable.DataBind();
            ddlResponsable.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            string _Departamento_id, _Responsable, _tipoPlan, _Estado;
            DateTime _Fecha_incidente, _Fecha_incidente1;
            _Departamento_id = ddlDepartamento.SelectedValue;
            _tipoPlan = ddlTipoPlan.SelectedValue;
            _Responsable = ddlResponsable.SelectedValue;
            _Estado = ddlEstado.SelectedValue;

            if (ckbInicio.Checked == true)
            {
                _Fecha_incidente = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null);
                _Fecha_incidente1 = DateTime.ParseExact(txtFecha0.Text, "dd/MM/yyyy", null);
            }
            else
            {
                _Fecha_incidente = DateTime.ParseExact("01/01/2011", "dd/MM/yyyy", null);
                _Fecha_incidente1 = Hoy;
            }

            GenerarTabla(_Departamento_id, _tipoPlan, _Responsable
                , _Estado, _Fecha_incidente, _Fecha_incidente1);
        }

        private void GenerarTabla(string _Departamento_id, string _tipoPlan, string _Responsable
            , string _Estado, DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {

            DataTable Resultados = _TB_PlanAccionBL.ListarTB_PlanAccionFind_ALR(_Departamento_id, _tipoPlan, _Responsable, _Estado, _Fecha_incidente, _Fecha_incidente1);
            StringBuilder Tabla = new StringBuilder();
            TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();
            int _cumplido = 0, _progreso = 0, _pendiente = 0, _total = 0;

            string _idEtiqueta;

            int TotalRegistros = Resultados.Rows.Count;
            Tabla.AppendLine("<table id=\"myTable\" class=\"tablesorter\">");
            Tabla.AppendLine("<thead>");
            string cabecera = "";
            cabecera = "<th>COD.</th><th width=\"210\"> DESCRIPCIÓN DEL PLAN </th><th width=\"150\">DESCRIPCIÓN DE LA ALERTA</th><th>FECHA</th><th> RESPONSABLE </th><th> DEPARTAMENTO. </th><th>TIP. PLAN.</th><th>ESTADO</th>";
            Tabla.AppendLine(cabecera);
            Tabla.AppendLine("</thead>");
            Tabla.AppendLine("<tbody>");

            TB_AccesosBE _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id,2);

            for (int i = 0; i < TotalRegistros; i++)
            {
                _total++;
                _idEtiqueta = Resultados.Rows[i]["PlanAccion_id"].ToString();
                Tabla.AppendLine("<tr>");

                Tabla.Append("<td>" + _idEtiqueta + " </a></td>");

                //if (int.Parse(Resultados.Rows[i]["Departamento_id"].ToString()) == _TB_AccesosBE.Departamento_id)
                //    Tabla.Append("<td>" + "<a href=\"#\" onClick=\"PopUp('ActualizarPlanAccion.aspx?PlanAccion_id=" + _idEtiqueta + "',20,20,950,678); return false;\"> " + _idEtiqueta + " </a></td>");
                //else
                //    Tabla.Append("<td>" + _idEtiqueta + " </td>");

                Tabla.Append("<td><a href=\"#\" onClick=\"PopUp('../admin/ActualizarPlanAccion.aspx?PlanAccion_id=" + _idEtiqueta + " ',20,20,950,678); return false;\"> " + Resultados.Rows[i]["PlanAccion_desc"] + " </a></td>");
                //Tabla.Append("<td>" + Resultados.Rows[i]["Descripcion"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Alerta_Desc"] + "</td>");
                Tabla.Append("<td>" + (Resultados.Rows[i]["Fecha"]) + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Responsable"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Departamento_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["tipoPlan"] + "</td>");
                string color = "";
                if (Resultados.Rows[i]["Estado"].ToString() == "No Cumplido")
                {
                    color = "style=\"background-color: #F82727;\"";
                    if (DateTime.ParseExact((Resultados.Rows[i]["Fecha"]).ToString(), "dd/MM/yyyy", null) <= DateTime.Today)
                    {
                        color = "style=\"background-color: #F82727;\"";
                        Tabla.Append("<td " + color + ">No Cumplido</td>");
                        _progreso++;
                    }
                    else
                    {
                        color = "style=\"background-color: #F1BF20;\"";
                        Tabla.Append("<td " + color + ">En Proceso</td>");
                        _pendiente++;
                    }
                }
                if (Resultados.Rows[i]["Estado"].ToString() == "Cumplido")
                {
                    color = "style=\"background-color: #52C226;\"";
                    Tabla.Append("<td " + color + ">Cumplido</td>");
                    _cumplido++;
                }
                
                Tabla.Append(Environment.NewLine);
                Tabla.AppendLine("</tr>");
            }
            Tabla.AppendLine("</tbody>");
            Tabla.AppendLine("</table>");
            ltlResults.Text = Tabla.ToString();
            lblTotal.Text = _total.ToString();
            lblCumplido.Text = _cumplido.ToString();
            lblEnProceso.Text = _progreso.ToString();
            lblPendiente.Text = _pendiente.ToString();

        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            string _Departamento_id, _Responsable, _tipoPlan, _Estado;
            DateTime _Fecha_incidente, _Fecha_incidente1;
            _Departamento_id = ddlDepartamento.SelectedValue;
            _tipoPlan = ddlTipoPlan.SelectedValue;
            _Responsable = ddlResponsable.SelectedValue;
            _Estado = ddlEstado.SelectedValue;

            if (ckbInicio.Checked == true)
            {
                _Fecha_incidente = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null);
                _Fecha_incidente1 = DateTime.ParseExact(txtFecha0.Text, "dd/MM/yyyy", null);
            }
            else
            {
                _Fecha_incidente = DateTime.ParseExact("01/01/2011", "dd/MM/yyyy", null);
                _Fecha_incidente1 = Hoy;
            }

            GenerarTabla(_Departamento_id, _tipoPlan, _Responsable
                , _Estado, _Fecha_incidente, _Fecha_incidente1);
            ExportToExcel(_Departamento_id, _tipoPlan, _Responsable
                , _Estado, _Fecha_incidente, _Fecha_incidente1);
        }

        private void ExportToExcel(string _Departamento_id, string _tipoPlan, string _Responsable
            , string _Estado, DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            DataView dvDefectos;
            dvDefectos = new DataView(_TB_PlanAccionBL.ListarTB_PlanAccionFind_ALR(_Departamento_id, _tipoPlan, _Responsable, _Estado, _Fecha_incidente, _Fecha_incidente1));
            if (dvDefectos.Table.Rows.Count > 0)
            {
                try
                {
                    string filename = "Reporte de Planes.xls";
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
    }
}