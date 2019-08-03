using IncidentesBE;
using IncidentesBL;
using System.Text;
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
    public partial class ReporteTrigger : System.Web.UI.Page
    {
        string fecha_actual;        
        protected DataView dvDefectos;
        //datatable

        TRG_TriggerBL _TRG_TriggerBL = new TRG_TriggerBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_GuardiaBL _TB_GuardiaBL = new TB_GuardiaBL();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        COM_FormatosBL _COM_FormatosBL = new COM_FormatosBL();
        COM_CategoriasBL _COM_CategoriasBL = new COM_CategoriasBL();
        COM_SubCategoriasBL _COM_SubCategoriasBL = new COM_SubCategoriasBL();


        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<TB_GuardiaBE> lTTB_GuardiaBE;
        List<Fnc_FuncionariosBE> lTFnc_FuncionariosBE;
        List<COM_FormatosBE> lTCOM_FormatosBE;
        List<COM_CategoriasBE> lTCOM_CategoriasBE;
        List<COM_SubCategoriasBE> lTCOM_SubCategoriasBE;
        private List<TB_GuardiaBE> lbeFiltroGuardia;

        DateTime Hoy, fecha1;

        protected void Page_Load(object sender, EventArgs e)
        {
            Hoy = DateTime.Today;
            if (this.IsPostBack)
            {

            }
            else
            {
                Hoy = DateTime.Today;
                fecha1 = new DateTime(Hoy.Year, Hoy.Month, 1);
                //fecha2 = new DateTime(Hoy.Year, Hoy.Month + 1, 1).AddDays(-1);

                fecha_actual = Hoy.ToString("dd/MM/yyyy");
                txtFecha.Text = fecha1.ToString("dd/MM/yyyy");
                txtFecha0.Text = fecha_actual;
                txtFecha1.Text = fecha1.ToString("dd/MM/yyyy");
                txtFecha2.Text = fecha_actual;
                lTTB_GuardiaBE = _TB_GuardiaBL.ListarTB_GuardiaO_Act();
                Session["Guardias"] = lTTB_GuardiaBE;
                lTCOM_FormatosBE = _COM_FormatosBL.ListarCOM_FormatosO_Act();
                Session["Formatos"] = lTCOM_FormatosBE;
                lTCOM_CategoriasBE = _COM_CategoriasBL.ListarCOM_CategoriasO_Act();
                Session["Categoria"] = lTCOM_CategoriasBE;
                lTCOM_SubCategoriasBE = _COM_SubCategoriasBL.ListarCOM_SubCategoriasO_Act();
                Session["SubCategoria"] = lTCOM_SubCategoriasBE;
                LlenarComboDepartamento();
                LlenarComboGuardia();
                //LlenarComboAuditor();

            }
        }
        private bool buscarFormato(COM_FormatosBE obeFormato)
        {
            bool exitoIdFormato = true;
            if (!ddlDepartamento.SelectedValue.Equals("%%")) exitoIdFormato = (obeFormato.AreaLabor_id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdFormato);
        }
        private bool buscarGuardias(TB_GuardiaBE obeGuardia)
        {
            bool exitoIdGuardia = true;
            if (!ddlDepartamento.SelectedValue.Equals("%%")) exitoIdGuardia = (obeGuardia.Departamento_id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdGuardia);
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
        private void LlenarComboGuardia()
        {
            lTTB_GuardiaBE = (List<TB_GuardiaBE>)Session["Guardias"];
            Predicate<TB_GuardiaBE> pred = new Predicate<TB_GuardiaBE>(buscarGuardias);
            lbeFiltroGuardia = lTTB_GuardiaBE.FindAll(pred);
            // Session["Filtro"] = lbeFiltro;

            ddlGuardia.DataSource = lbeFiltroGuardia;
            ddlGuardia.DataValueField = "Guardia_id";
            ddlGuardia.DataTextField = "Guardia_desc";
            ddlGuardia.DataBind();
            ddlGuardia.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }
        //private void LlenarComboAuditor()
        //{
        //    lTFnc_FuncionariosBE = _Fnc_FuncionariosBL.ListarFnc_FuncionariosO_Act();
        //    ddlAuditor.DataSource = lTFnc_FuncionariosBE;
        //    ddlAuditor.DataValueField = "Funcionario_id";
        //    ddlAuditor.DataTextField = "Funcionario_nome";
        //    ddlAuditor.DataBind();
        //    ddlAuditor.Items.Insert(0, new ListItem("(Todos)", "%%"));
        //}

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            string _Departamento_id, _Guardia_id;
            DateTime _Fecha_incidente, _Fecha_incidente1;
            int _Usuario_id;
            _Departamento_id = ddlDepartamento.SelectedValue;
            _Guardia_id = ddlGuardia.SelectedValue;

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
            _Usuario_id = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id;
            //if (ddlResuelto.SelectedValue == "%%")
            //    GenerarTabla(_estado, _tipo, _clasificacion, _categoria, _prioridad, _equipe_id, _encontrado, _dueno, _fecha, _fecha1, _fecha2, _fecha3, _depto_id, _parte);
            //else
            GenerarTabla(_Departamento_id, _Guardia_id, _Fecha_incidente, _Fecha_incidente1);
        }

        private void GenerarTabla(string _Departamento_id, string _Guardia_id, DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {

            DataTable Resultados = _TRG_TriggerBL.ListarTRG_TriggerFind(_Departamento_id, _Guardia_id, _Fecha_incidente, _Fecha_incidente1);

            //DataTable Estadisticas = _TB_IncidentesBL.ListarTB_Incidentes_Estadistica(_Departamento_id, _Guardia_id,
            //    _Area_id, _Clasificacion_id, _Tipo_emp, _Rol_id,  _Fecha_incidente, _Fecha_incidente1);
            StringBuilder Tabla = new StringBuilder();
            StringBuilder TablaE = new StringBuilder();
            TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();

            string _idEtiqueta;

            int TotalRegistros = Resultados.Rows.Count;
            Tabla.AppendLine("<table id=\"myTable\" class=\"tablesorter\">");
            Tabla.AppendLine("<thead>");
            string cabecera = "";
            cabecera = "<th>COD.</th><th> TIME STAMP </th><th> DEPARTAMENTO </th><th width=\"110\"> GUARDIA </th><th>QUIEN</th><th> RIESGO INI. </th><th>RIESGO FIN.</th>";
            Tabla.AppendLine(cabecera);
            Tabla.AppendLine("</thead>");
            Tabla.AppendLine("<tbody>");
            int Valor, Valor_ini;
            string _estilo = "";

            //TB_AccesosBE _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id);
            for (int i = 0; i < TotalRegistros; i++)
            {
                _idEtiqueta = Resultados.Rows[i]["Trigger_id"].ToString();
                Tabla.AppendLine("<tr>");
                Valor=Convert.ToInt32( Resultados.Rows[i]["Valor"]);
                Valor_ini= Convert.ToInt32( Resultados.Rows[i]["Valor_Ini"]);
                //if (_TB_AccesosBE.Permiso > 0)
                //{
                //    if (_TB_AccesosBE.Permiso == 1)
                //        Tabla.Append("<td" + _estilo + ">" + "<a href=\"#\" onClick=\"PopUp('EvaluacionIncidentePop.aspx?Trigger_id=" + _idEtiqueta + "',20,20,950,678); return false;\"> " + _idEtiqueta + " </a></td>");
                //    else
                //    {
                //if (Resultados.Rows[i]["Acceso"].ToString() == "1")
                //    Tabla.Append("<td" + _estilo + ">" + "<a href=\"#\" onClick=\"PopUp('EvaluacionIncidentePop.aspx?Trigger_id=" + _idEtiqueta + "',20,20,950,678); return false;\"> " + _idEtiqueta + " </a></td>");
                //else
                //    Tabla.Append("<td" + _estilo + ">" + _idEtiqueta + " </td>");
                //    }
                //}
                //else

                Tabla.Append("<td><a href=\"#\" onClick=\"PopUp('ActualizarTriggerPopUp.aspx?Trigger_id=" + _idEtiqueta + "',20,20,950,678); return false;\"> " + _idEtiqueta + " </a></td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["trigger_fecha"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Departamento_desc"] + " </td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Guardia_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Ultimo"] + "</td>");
                if (Valor_ini <= 5)
                    _estilo = "<h1><span class='verde'>" + Valor_ini + "</span></h1> ";
                else
                {
                    if (Valor_ini >= 6)
                        _estilo = "<h1><span class='amarillo'>" + Valor_ini + "</span></h1> ";
                    if (Valor_ini > 8)
                        _estilo = "<h1><span class='rojo'>" + Valor_ini + "</span></h1> ";
                }
                Tabla.Append("<td>" + _estilo + "</td>");
                if (Valor <= 5)
                    _estilo = "<h1><span class='verde'>" + Valor + "</span></h1> ";
                else
                {
                    if (Valor >= 6)
                        _estilo = "<h1><span class='amarillo'>" + Valor + "</span></h1> ";
                    if (Valor > 8)
                        _estilo = "<h1><span class='rojo'>" + Valor + "</span></h1> ";
                }
                Tabla.Append("<td>" + _estilo + "</td>");
                Tabla.Append(Environment.NewLine);
                Tabla.AppendLine("</tr>");
            }
            Tabla.AppendLine("</tbody>");
            Tabla.AppendLine("</table>");
            ltlResults.Text = Tabla.ToString();

            //Generar Tabla Estadistica
            //TotalRegistros = Estadisticas.Rows.Count;
            //TablaE.AppendLine("<table border='1'>");
            //for (int i = 0; i < TotalRegistros; i++)
            //{
            //    TablaE.AppendLine("<tr>");
            //    TablaE.Append("<td>" + Estadisticas.Rows[i]["clasificacion_desc"] + "</td>");
            //    TablaE.Append("<td>" + Estadisticas.Rows[i]["numero"] + "</td>");
            //    TablaE.Append(Environment.NewLine);
            //    TablaE.AppendLine("</tr>");
            //}
            //TablaE.AppendLine("</table>");
            //ltrEstadistica.Text = TablaE.ToString();

        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            string _Departamento_id, _Guardia_id, _Funcionario_id;
            DateTime _Fecha_incidente, _Fecha_incidente1;
            int _Usuario_id;
            _Departamento_id = ddlDepartamento.SelectedValue;
            _Guardia_id = ddlGuardia.SelectedValue;

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
            _Usuario_id = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id;

            ExportToExcel(_Departamento_id, _Guardia_id,
            _Fecha_incidente, _Fecha_incidente1);
        }

        private void ExportToExcel(string _Departamento_id, string _Guardia_id, DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            dvDefectos = new DataView(_TRG_TriggerBL.ListarTRG_TriggerFind(_Departamento_id, _Guardia_id, _Fecha_incidente, _Fecha_incidente1));
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

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboGuardia();
        }
    }
}