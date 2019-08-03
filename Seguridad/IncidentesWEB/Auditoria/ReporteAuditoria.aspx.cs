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
    public partial class ReporteAuditoria : System.Web.UI.Page
    {
        string fecha_actual;
        protected DataView dvAuditoria;
        //datatable

        AUD_AuditoriaBE _AUD_AuditoriaBE = new AUD_AuditoriaBE();

        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        AUD_AuditoriaBL _AUD_AuditoriaBL = new AUD_AuditoriaBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_GuardiaBL _TB_GuardiaBL = new TB_GuardiaBL();
        TB_AreaBL _TB_AreaBL = new TB_AreaBL();
        AUD_AuditoriaTipoBL _AUD_AuditoriaTipoBL = new AUD_AuditoriaTipoBL();
        AUD_Auditoria_PreguntaBL _AUD_Auditoria_PreguntaBL = new AUD_Auditoria_PreguntaBL();

        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<TB_GuardiaBE> lTTB_GuardiaBE;
        List<TB_AreaBE> lTTB_AreaBE;
        List<Fnc_FuncionariosBE> lTOperador;
        List<AUD_AuditoriaTipoBE> lTAUD_AuditoriaTipoBE;
        private List<TB_GuardiaBE> lbeFiltroGuardia;
        private List<TB_AreaBE> lbeFiltroArea;
        private List<Fnc_FuncionariosBE> lbeFiltroOperador;
        private List<AUD_AuditoriaTipoBE> lbeFiltroAuditoriaTipo;

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
                lTTB_AreaBE = _TB_AreaBL.ListarTB_AreaO_Act();
                Session["Area"] = lTTB_AreaBE;
                lTTB_GuardiaBE = _TB_GuardiaBL.ListarTB_GuardiaO_Act();
                Session["Guardias"] = lTTB_GuardiaBE;
                lTOperador = _Fnc_FuncionariosBL.ListarFnc_FuncionariosO_Act();
                Session["Operador"] = lTOperador;
                Session["Auditor"] = lTOperador;
                lTAUD_AuditoriaTipoBE = _AUD_AuditoriaTipoBL.ListarAUD_AuditoriaTipoO_Act();
                Session["AuditoriaTipo"] = lTAUD_AuditoriaTipoBE;
                LlenarComboDepartamento();
                LlenarComboArea();
                LlenarComboOperador();
                LlenarComboAuditor();
                LlenarComboAuditoriaTipo();
                LlenarComboGuardia();
                //LlenarComboAuditor();

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
        private bool buscarGuardias(TB_GuardiaBE obeGuardia)
        {
            bool exitoIdGuardia = true;
            if (!ddlDepartamento.SelectedValue.Equals("%%")) exitoIdGuardia = (obeGuardia.Departamento_id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdGuardia);
        }
        private bool buscarArea(TB_AreaBE obeArea)
        {
            bool exitoIdSistemaQA = true;
            if (!ddlDepartamento.SelectedValue.Equals("%%")) exitoIdSistemaQA = (obeArea.Departamento_id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdSistemaQA);
        }
        private bool buscarOperador(Fnc_FuncionariosBE obeOperador)
        {
            bool exitoIdSistemaQA = true;
            if (!ddlDepartamento.SelectedValue.Equals("%%")) exitoIdSistemaQA = (obeOperador.Area_Id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdSistemaQA);
        }
        private bool buscarAuditoriaTipo(AUD_AuditoriaTipoBE obeAuditoriaTipo)
        {
            bool exitoIdSistemaQA = true;
            if (!ddlDepartamento.SelectedValue.Equals("%%")) exitoIdSistemaQA = (obeAuditoriaTipo.Departamento_id.ToString().Equals(ddlDepartamento.SelectedValue));
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
            ddlGuardia.Items.Insert(0, new ListItem("(Todos)", "%%"));
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
            ddlArea.Items.Insert(0, new ListItem("(Todos)", "%%"));
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
            ddlOperador.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }
        private void LlenarComboAuditor()
        {
            lTOperador = (List<Fnc_FuncionariosBE>)Session["Auditor"];
            ddlOriginador.DataSource = lTOperador;
            ddlOriginador.DataValueField = "Funcionario_id";
            ddlOriginador.DataTextField = "Funcionario_nome";
            ddlOriginador.DataBind();
            ddlOriginador.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }
        private void LlenarComboAuditoriaTipo()
        {

            lTAUD_AuditoriaTipoBE = (List<AUD_AuditoriaTipoBE>)Session["AuditoriaTipo"];
            Predicate<AUD_AuditoriaTipoBE> pred = new Predicate<AUD_AuditoriaTipoBE>(buscarAuditoriaTipo);
            lbeFiltroAuditoriaTipo = lTAUD_AuditoriaTipoBE.FindAll(pred);
            ddlAuditoria.DataSource = lbeFiltroAuditoriaTipo;
            ddlAuditoria.DataValueField = "AuditoriaTipo_id";
            ddlAuditoria.DataTextField = "Auditoria_desc";
            ddlAuditoria.DataBind();
            ddlAuditoria.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            string _Departamento_id, _Guardia_id, _Area_id, _Auditoria_id, _Operador, _Originador;
            DateTime _Fecha_incidente, _Fecha_incidente1;
            int _Usuario_id;
            _Departamento_id = ddlDepartamento.SelectedValue;
            _Guardia_id = ddlGuardia.SelectedValue;
            _Area_id = ddlArea.SelectedValue;
            _Auditoria_id = ddlAuditoria.SelectedValue;
            _Operador = ddlOperador.SelectedValue;
            _Originador = ddlOriginador.SelectedValue;


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
            GenerarTabla(_Departamento_id, _Guardia_id, _Area_id, _Auditoria_id, _Operador, _Originador, _Fecha_incidente, _Fecha_incidente1);
        }

        private void GenerarTabla(string _Departamento_id, string _Guardia_id, string _Area_id,string _Auditoria_id , string _Operador, string _Originador ,DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            DataTable Resultados = _AUD_AuditoriaBL.ListarAUD_AuditoriaFind(_Departamento_id, _Guardia_id, _Area_id, _Auditoria_id, _Operador, _Originador, _Fecha_incidente, _Fecha_incidente1);

            //DataTable Estadisticas = _TB_IncidentesBL.ListarTB_Incidentes_Estadistica(_Departamento_id, _Guardia_id,
            //    _Area_id, _Clasificacion_id, _Tipo_emp, _Rol_id,  _Fecha_incidente, _Fecha_incidente1);
            StringBuilder Tabla = new StringBuilder();
            StringBuilder TablaE = new StringBuilder();
            TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();

            string _idEtiqueta;
            string _Fecha_Auditoria;
            int TotalRegistros = Resultados.Rows.Count;
            Tabla.AppendLine("<table id=\"myTable\" class=\"tablesorter\">");
            Tabla.AppendLine("<thead>");
            string cabecera = "";
            cabecera = "<th>COD.</th><th>AUDITORIA</th><th> DEPARTAMENTO </th><th width=\"110\"> GUARDIA </th><th width=\"110\"> ÁREA </th><th>OPERADOR</th><th>ORIGINADOR</th><th>FECHA REG.</th><th>FIRMA OPE.</th><th>Nota</th>";
            Tabla.AppendLine(cabecera);
            Tabla.AppendLine("</thñead>");
            Tabla.AppendLine("<tbody>");

            TB_AccesosBE _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id,5);
            for (int i = 0; i < TotalRegistros; i++)
            {
                _idEtiqueta = Resultados.Rows[i]["Auditoria_id"].ToString();
                Tabla.AppendLine("<tr>");
                _Fecha_Auditoria = Resultados.Rows[i]["Fecha_firmaOpe"].ToString();

                if (_TB_AccesosBE.Permiso > 0)
                {
                    if (_TB_AccesosBE.Permiso == 1)

                        Tabla.Append("<td>" + "<a href=\"#\" onClick=\"PopUp('ActualizarAuditoriaPop.aspx?Auditoria_id=" + _idEtiqueta + "',20,20,950,678); return false;\"> " + _idEtiqueta + " </a></td>");
                    else
                    {
                        if (Resultados.Rows[i]["Acceso"].ToString() == "1")
                            Tabla.Append("<td>" + "<a href=\"#\" onClick=\"PopUp('ActualizarAuditoriaPop.aspx?Auditoria_id=" + _idEtiqueta + "',20,20,950,678); return false;\"> " + _idEtiqueta + " </a></td>");
                        else
                            Tabla.Append("<td>" + _idEtiqueta + " </td>");
                    }
                }
                else
                Tabla.Append("<td>" + _idEtiqueta + " </a></td>");
                Tabla.Append("<td><a href=\"ActualizarAuditoria.aspx?Auditoria_id=" + _idEtiqueta + "\"> " + Resultados.Rows[i]["Auditoria_Desc"] + " </a></td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Departamento_desc"] + " </td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Guardia_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Area_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Operador"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Originador"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Fecha_Auditoria"] + "</td>");
                if (_Fecha_Auditoria == "Sin Firmar")
                    Tabla.Append("<td style='background-color: red;color:black;border: 1px solid #ECECEC;'>" + _Fecha_Auditoria + "</td>");
                else
                    Tabla.Append("<td style='background-color: green;color:black;border: 1px solid #ECECEC;'>" + _Fecha_Auditoria + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Nota"] + "</td>");
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
            string _Departamento_id, _Guardia_id, _Area_id, _Auditoria_id, _Operador, _Originador;
            DateTime _Fecha_incidente, _Fecha_incidente1;
            int _Usuario_id;
            _Departamento_id = ddlDepartamento.SelectedValue;
            _Guardia_id = ddlGuardia.SelectedValue;
            _Area_id = ddlArea.SelectedValue;
            _Auditoria_id = ddlAuditoria.SelectedValue;
            _Operador = ddlOperador.SelectedValue;
            _Originador = ddlOriginador.SelectedValue;

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

            ExportToExcel(_Departamento_id, _Guardia_id, _Area_id, _Auditoria_id, _Operador, _Originador, _Fecha_incidente, _Fecha_incidente1);
        }

        private void ExportToExcel(string _Departamento_id, string _Guardia_id, string _Area_id, string _Auditoria_id, string _Operador, string _Originador, DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            dvAuditoria = new DataView(_AUD_AuditoriaBL.ListarAUD_AuditoriaFind(_Departamento_id, _Guardia_id, _Area_id, _Auditoria_id, _Operador, _Originador, _Fecha_incidente, _Fecha_incidente1));
            if (dvAuditoria.Table.Rows.Count > 0)
            {
                try
                {
                    string filename = "Reporte General.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    GridView dgGrid = new GridView();
                    dgGrid.DataSource = dvAuditoria;
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
            LlenarComboArea();
            LlenarComboOperador();
            LlenarComboAuditoriaTipo();
        }
    }
}