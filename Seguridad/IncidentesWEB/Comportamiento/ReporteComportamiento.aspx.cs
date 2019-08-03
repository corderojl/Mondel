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

namespace IncidentesWEB.Comportamiento
{
    public partial class ReporteComportamiento : System.Web.UI.Page
    {
        string fecha_actual;
        protected DataView dvLocaliza;
        protected DataView dvComponentes;
        protected DataView dvTipos;
        protected DataView dvEncontrado;
        protected DataView dvResuelto;
        protected DataView dvCategoria;
        protected DataView dvDispositivos;
        protected DataView dvPartes;
        protected DataView dvGrupos;
        protected DataView dvAreas;
        protected DataView dvDueno;
        protected DataView dvDefectos;
        //datatable
        protected DataTable dtFuncionario;
        protected DataTable dtComponente;
        protected DataTable dtPartes;
        protected DataTable dtDueno;
        protected DataTable dtAreas;

        COM_ComportamientoBL _COM_ComportamientoBL = new COM_ComportamientoBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_GuardiaBL _TB_GuardiaBL = new TB_GuardiaBL();
        TB_AreaBL _TB_AreaBL = new TB_AreaBL();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TB_SectorBL _TB_SectorBL = new TB_SectorBL();
        COM_CategoriasBL _COM_CategoriasBL = new COM_CategoriasBL();
        COM_SubCategoriasBL _COM_SubCategoriasBL = new COM_SubCategoriasBL();
        

        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<TB_GuardiaBE> lTTB_GuardiaBE;
        List<Fnc_FuncionariosBE> lTFnc_FuncionariosBE;
        List<TB_AreaBE> lTTB_AreaBE;
        List<TB_SectorBE> lTTB_SectorBE;
        List<COM_CategoriasBE> lTCOM_CategoriasBE;
        List<COM_SubCategoriasBE> lTCOM_SubCategoriasBE;

        private List<TB_AreaBE> lbeFiltroArea;
        private List<COM_SubCategoriasBE> lbeFiltroSu;        
        private List<TB_DepartamentoBE> lbeFiltroDepartamento;
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
                lTTB_DepartamentoBE = _TB_DepartamentoBL.ListarTB_DepartamentoO_Act("3");
                Session["Departamento"] = lTTB_DepartamentoBE;
                lTTB_AreaBE = _TB_AreaBL.ListarTB_AreaO_Act();
                Session["Areas"] = lTTB_AreaBE;
                lTTB_SectorBE = _TB_SectorBL.ListarTB_SectorO_Act();
                Session["Sector"] = lTTB_SectorBE;
                lTCOM_CategoriasBE = _COM_CategoriasBL.ListarCOM_CategoriasO_Act();
                Session["Categoria"] = lTCOM_CategoriasBE;
                lTCOM_SubCategoriasBE = _COM_SubCategoriasBL.ListarCOM_SubCategoriasO_Act();
                Session["SubCategoria"] = lTCOM_SubCategoriasBE;
                LlenarComboSector();
                LlenarComboDepartamento();
                LlenarComboArea();
                LlenarComboAuditor();                
                LlenarComboSubCategoria();

            }
        }
        private bool buscarDepartamento(TB_DepartamentoBE obeDepartamento)
        {
            bool exitoIdDepartamento = true;
            if (!ddlSector.SelectedValue.Equals("%%")) exitoIdDepartamento = (obeDepartamento.Sector_id.ToString().Equals(ddlSector.SelectedValue));
            return (exitoIdDepartamento);
        }

        private bool buscarArea(TB_AreaBE obeArea)
        {
            bool exitoIdArea = true;
            if (!ddlDepartamento.SelectedValue.Equals("%%")) exitoIdArea = (obeArea.Departamento_id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdArea);
        }
        private bool buscarSubCategorias(COM_SubCategoriasBE obeSubCategoria)
        {
            bool exitoIdSubCategoria = true;
            if (!ddlSector.SelectedValue.Equals("%%")) exitoIdSubCategoria = (obeSubCategoria.AreaLabor_id.ToString().Equals(ddlSector.SelectedValue));
            return (exitoIdSubCategoria);
        }
        private void LlenarComboDepartamento()
        {
            lTTB_DepartamentoBE = (List<TB_DepartamentoBE>)Session["Departamento"];
            Predicate<TB_DepartamentoBE> pred = new Predicate<TB_DepartamentoBE>(buscarDepartamento);
            lbeFiltroDepartamento = lTTB_DepartamentoBE.FindAll(pred);
            ddlDepartamento.DataSource = lbeFiltroDepartamento;
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }
        private void LlenarComboArea()
        {
            lTTB_AreaBE = (List<TB_AreaBE>)Session["Areas"];
            Predicate<TB_AreaBE> pred = new Predicate<TB_AreaBE>(buscarArea);
            lbeFiltroArea = lTTB_AreaBE.FindAll(pred);
            // Session["Filtro"] = lbeFiltro;

            ddlArea.DataSource = lbeFiltroArea;
            ddlArea.DataValueField = "Area_id";
            ddlArea.DataTextField = "Area_desc";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }
        private void LlenarComboAuditor()
        {
            lTFnc_FuncionariosBE = _Fnc_FuncionariosBL.ListarFnc_FuncionariosO_Act();
            ddlAuditor.DataSource = lTFnc_FuncionariosBE;
            ddlAuditor.DataValueField = "Funcionario_id";
            ddlAuditor.DataTextField = "Funcionario_nome";
            ddlAuditor.DataBind();
            ddlAuditor.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }
        private void LlenarComboSector()
        {
            ddlSector.DataSource = _TB_SectorBL.ListarTB_SectorO_Act();
            ddlSector.DataValueField = "Sector_id";
            ddlSector.DataTextField = "Sector_desc";
            ddlSector.DataBind();
            ddlSector.Items.Insert(0, new ListItem("(Todos)", "%%"));
            LlenarComboSubCategoria();
        }

        private void LlenarComboSubCategoria()
        {
            lTCOM_SubCategoriasBE = (List<COM_SubCategoriasBE>)Session["SubCategoria"];
            Predicate<COM_SubCategoriasBE> pred = new Predicate<COM_SubCategoriasBE>(buscarSubCategorias);
            lbeFiltroSu = lTCOM_SubCategoriasBE.FindAll(pred);
            Session["FiltroSu"] = lbeFiltroSu;

            ddlSubCategoria.DataSource = lbeFiltroSu;
            ddlSubCategoria.DataValueField = "SubCategoria_id";
            ddlSubCategoria.DataTextField = "SubCategoria_desc";
            ddlSubCategoria.DataBind();
            ddlSubCategoria.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }
       
        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            string _Departamento_id, _Area_id, _Guardia_id, _Funcionario_id, _Sector_id, _Categoria_id, _SubCategoria_id,_Tipo_emp,_Valor;
            DateTime _Fecha_incidente, _Fecha_incidente1;
            int _Usuario_id;
            _Departamento_id = ddlDepartamento.SelectedValue;
            _Guardia_id = ddlTurno.SelectedValue;
            _Area_id = ddlArea.SelectedValue;
            _Funcionario_id = ddlAuditor.SelectedValue;
            _Sector_id = ddlSector.SelectedValue;
            _SubCategoria_id = ddlSubCategoria.SelectedValue;
            _Tipo_emp = ddlTipo_emp.SelectedValue;
            _Valor = ddlValor.SelectedValue;

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
            GenerarTabla(_Departamento_id,_Area_id, _Guardia_id,_Funcionario_id,
             _Sector_id, _SubCategoria_id, _Tipo_emp, _Valor
            ,_Fecha_incidente, _Fecha_incidente1);
        }

        private void GenerarTabla(string _Departamento_id, string _Area_id, string _Guardia_id, string _Funcionario_id
            ,string _Sector_id, string _SubCategoria_id, string _Tipo_emp, string _Valor
            , DateTime _Fecha_Comportamiento, DateTime _Fecha_Comportamiento1)
        {
            TEM_ComportamientoEstadistica _ComEstad = new TEM_ComportamientoEstadistica();
            DataTable Resultados = _COM_ComportamientoBL.ListarCOM_ComportamientoFind(_Departamento_id,_Area_id, _Guardia_id, _Funcionario_id,
               _Sector_id, _SubCategoria_id, _Tipo_emp, _Valor
            , _Fecha_Comportamiento, _Fecha_Comportamiento1);
            _ComEstad = _COM_ComportamientoBL.TraerCOM_ComportamientoEstadistica(_Departamento_id, _Area_id, _Guardia_id, _Funcionario_id,
               _Sector_id, _SubCategoria_id, _Tipo_emp, _Valor
            , _Fecha_Comportamiento, _Fecha_Comportamiento1);
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
            cabecera = "<th>COD.</th><th> SECTOR </th><th> DPTO. </th><th>ÁREA</th><th width=\"110\"> AUDITOR </th><th>FECHA</th><th> TURNO </th><th>TIP. EMP.</th><th width=\"210\"> CATEGORIA. </th><th>VALOR</th><th width=\"210\"> DESCRIPCIÓN </th>";
            Tabla.AppendLine(cabecera);
            Tabla.AppendLine("</thead>");
            Tabla.AppendLine("<tbody>");
            int Nro = 0;
            string _estilo = "";
            //TB_AccesosBE _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id);
            for (int i = 0; i < TotalRegistros; i++)
            {
                Nro = i + 1;
                _idEtiqueta = Resultados.Rows[i]["Comportamiento_id"].ToString();
                Tabla.AppendLine("<tr>");

                //if (_TB_AccesosBE.Permiso > 0)
                //{
                //    if (_TB_AccesosBE.Permiso == 1)
                //        Tabla.Append("<td" + _estilo + ">" + "<a href=\"#\" onClick=\"PopUp('EvaluacionIncidentePop.aspx?Comportamiento_id=" + _idEtiqueta + "',20,20,950,678); return false;\"> " + _idEtiqueta + " </a></td>");
                //    else
                //    {
                        //if (Resultados.Rows[i]["Acceso"].ToString() == "1")
                        //    Tabla.Append("<td" + _estilo + ">" + "<a href=\"#\" onClick=\"PopUp('EvaluacionIncidentePop.aspx?Comportamiento_id=" + _idEtiqueta + "',20,20,950,678); return false;\"> " + _idEtiqueta + " </a></td>");
                        //else
                        //    Tabla.Append("<td" + _estilo + ">" + _idEtiqueta + " </td>");
                //    }
                //}
                //else
                    Tabla.Append("<td" + _estilo + ">" + _idEtiqueta + " </td>");
                    Tabla.Append("<td>" + Resultados.Rows[i]["Sector_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Departamento_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Area_desc"] + "</td>");
                Tabla.Append("<td>"  + Resultados.Rows[i]["AUDITOR"] + " </td>");
                //Tabla.Append("<td>" + Resultados.Rows[i]["Descripcion"] + "</td>");                
                Tabla.Append("<td>" + Resultados.Rows[i]["Fecha"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Turno"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Tipo_emp"] + "</td>");                
                Tabla.Append("<td>" + Resultados.Rows[i]["SubCategoria_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Valor"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Descripcion"] + "</td>");
                Tabla.Append(Environment.NewLine);
                Tabla.AppendLine("</tr>");
            }
            Tabla.AppendLine("</tbody>");
            Tabla.AppendLine("</table>");
            ltlResults.Text = Tabla.ToString();
            lblValor1.Text = _ComEstad.Valor1.ToString();
            lblValor2.Text = _ComEstad.Valor2.ToString();
            lblValor3.Text = _ComEstad.Valor3.ToString();
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
            string _Departamento_id, _Area_id, _Guardia_id, _Funcionario_id, _Sector_id, _SubCategoria_id, _Tipo_emp, _Valor;
            DateTime _Fecha_incidente, _Fecha_incidente1;
            int _Usuario_id;
            _Departamento_id = ddlDepartamento.SelectedValue;
            _Guardia_id = ddlTurno.SelectedValue;
            _Area_id = ddlArea.SelectedValue;
            _Funcionario_id = ddlAuditor.SelectedValue;
            _Sector_id=ddlSector.SelectedValue;
            //_Categoria_id = ddlCategoria.SelectedValue;
            _SubCategoria_id = ddlSubCategoria.SelectedValue;
            _Tipo_emp = ddlTipo_emp.SelectedValue;
            _Valor = ddlValor.SelectedValue;

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

            ExportToExcel(_Departamento_id,_Area_id, _Guardia_id, _Funcionario_id,
            _Sector_id, _SubCategoria_id, _Tipo_emp, _Valor
            , _Fecha_incidente, _Fecha_incidente1);
        }

        private void ExportToExcel(string _Departamento_id, string _Area_id, string _Guardia_id, string _Funcionario_id
            ,string _Sector_id, string _SubCategoria_id, string _Tipo_emp, string _Valor
            , DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            dvDefectos = new DataView(_COM_ComportamientoBL.ListarCOM_ComportamientoFindXML(_Departamento_id,_Area_id, _Guardia_id, _Funcionario_id, 
                _Sector_id, _SubCategoria_id, _Tipo_emp, _Valor
            , _Fecha_incidente, _Fecha_incidente1));
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
            LlenarComboArea();
          
        }

        protected void ddlSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboDepartamento();
            LlenarComboSubCategoria();
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboSubCategoria();
        }

    }
}