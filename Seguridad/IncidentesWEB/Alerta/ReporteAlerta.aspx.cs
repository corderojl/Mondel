using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.Alerta
{
    public partial class ReporteAlerta : System.Web.UI.Page
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

        ALR_AlertasBL _ALR_AlertasBL = new ALR_AlertasBL();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_AreaBL _TB_AreaBL = new TB_AreaBL();
        ALR_SistemaqaBL _ALR_SistemaqaBL = new ALR_SistemaqaBL();
        ALR_ElementoClaveBL _ALR_ElementoClaveBL = new ALR_ElementoClaveBL();
        TB_CriticidadBL _TB_CriticidadBL = new TB_CriticidadBL();

        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<TB_AreaBE> lTTB_AreaBE;
        List<ALR_SistemaqaBE> lTALR_SistemaqaBE;
        List<ALR_ElementoClaveBE> lTALR_ElementoClaveBE;
        List<Fnc_FuncionariosBE> lTFnc_FuncionariosBE;
        List<TB_CriticidadBE> lTTB_CriticidadBE;


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
                LlenarComboDepartamento();
                LlenarComboArea();
                LlenarComboSistemaQA();
                LlenarComboElementoClave();
                LlenarComboSistemaQA();
                LlenarComboOriginador();
                LlenarComboCriticidad();
            }
        }
        private void LlenarComboCriticidad()
        {
            lTTB_CriticidadBE = _TB_CriticidadBL.ListarTB_CriticidadO_Act();
            ddlClasificacion.DataSource = lTTB_CriticidadBE;
            ddlClasificacion.DataValueField = "Criticidad_id";
            ddlClasificacion.DataTextField = "Criticidad_desc";
            ddlClasificacion.DataBind();
            ddlClasificacion.Items.Insert(0, new ListItem("(Todos)", "%%"));
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

        private void LlenarComboArea()
        {
            lTTB_AreaBE = _TB_AreaBL.ListarTB_AreaO_Act();
            ddlArea.DataSource = lTTB_AreaBE;
            ddlArea.DataValueField = "Area_id";
            ddlArea.DataTextField = "Area_desc";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }

        private void LlenarComboSistemaQA()
        {
            lTALR_SistemaqaBE = _ALR_SistemaqaBL.ListarALR_SistemaqaO_Act();
            ddlSistemaQA.DataSource = lTALR_SistemaqaBE;
            ddlSistemaQA.DataValueField = "SistemaQA_id";
            ddlSistemaQA.DataTextField = "SistemaQA_desc";
            ddlSistemaQA.DataBind();
            ddlSistemaQA.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }

        private void LlenarComboElementoClave()
        {
            lTALR_ElementoClaveBE = _ALR_ElementoClaveBL.ListarALR_ElementoClaveO_Act();
            ddlElementoClave.DataSource = lTALR_ElementoClaveBE;
            ddlElementoClave.DataValueField = "ElementoClave_id";
            ddlElementoClave.DataTextField = "ElementoClave_desc";
            ddlElementoClave.DataBind();
            ddlElementoClave.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }
        private void LlenarComboOriginador()
        {
            lTFnc_FuncionariosBE = _Fnc_FuncionariosBL.ListarFnc_FuncionariosO_Act();
            ddlOriginador.DataSource = lTFnc_FuncionariosBE;
            ddlOriginador.DataValueField = "Funcionario_id";
            ddlOriginador.DataTextField = "Funcionario_nome";
            ddlOriginador.DataBind();
            ddlOriginador.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string _Departamento_id, _Guardia_id, _Area_id, _Clasificacion_id
            , _ElementoClave_id, _Estado, _SistemaQA_id, _Originador;
            DateTime _Fecha_alerta, _Fecha_alerta1;
            int _Usuario_id;
            _Departamento_id = ddlDepartamento.SelectedValue;
            _Guardia_id = "%%";
            _Area_id = ddlArea.SelectedValue;
            _Clasificacion_id = ddlClasificacion.SelectedValue;
            _SistemaQA_id = ddlSistemaQA.SelectedValue;
            _Originador = ddlOriginador.SelectedValue;
            _ElementoClave_id = ddlElementoClave.SelectedValue;
            _Estado = ddlEstado.SelectedValue;

            if (ckbInicio.Checked == true)
            {
                _Fecha_alerta = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null);
                _Fecha_alerta1 = DateTime.ParseExact(txtFecha0.Text, "dd/MM/yyyy", null);
            }
            else
            {
                _Fecha_alerta = DateTime.ParseExact("01/01/2011", "dd/MM/yyyy", null);
                _Fecha_alerta1 = Hoy;
            }
            _Usuario_id = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id;
            //if (ddlResuelto.SelectedValue == "%%")
            //    GenerarTabla(_estado, _tipo, _clasificacion, _categoria, _prioridad, _equipe_id, _encontrado, _dueno, _fecha, _fecha1, _fecha2, _fecha3, _depto_id, _parte);
            //else
            GenerarTabla(_Departamento_id, _Guardia_id,
                _Area_id, _Clasificacion_id, _SistemaQA_id, _ElementoClave_id,
                _Originador, _Estado, _Fecha_alerta, _Fecha_alerta1, _Usuario_id);
        }

        private void GenerarTabla(string _Departamento_id, string _Guardia_id
            , string _Area_id, string _Clasificacion_id, string _SistemaQA_id, string _ElementoClave_id
            , string _Originador, string _Estado, DateTime _Fecha_alerta, DateTime _Fecha_alerta1, int _Usuario_id)
        {

            DataTable Resultados = _ALR_AlertasBL.ListarALR_AlertasFind(_Departamento_id, _Guardia_id,
                _Area_id, _Clasificacion_id, _SistemaQA_id, _ElementoClave_id, _Originador, _Estado, _Fecha_alerta, _Fecha_alerta1, _Usuario_id);

            //DataTable Estadisticas = _ALR_AlertasBL.ListarALR_Alertas_Estadistica(_Departamento_id, _Guardia_id,
            //    _Area_id, _Clasificacion_id, _SistemaQA_id, _ElementoClave_id, _Originador, _Estado, _Fecha_alerta, _Fecha_alerta1);
            StringBuilder Tabla = new StringBuilder();
            StringBuilder TablaE = new StringBuilder();
            TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();
            int _reportado = 0, _investigados = 0, _solucionados = 0;
            string _idEtiqueta;

            int TotalRegistros = Resultados.Rows.Count;
            Tabla.AppendLine("<table id=\"myTable\" class=\"tablesorter\">");
            Tabla.AppendLine("<thead>");
            string cabecera = "";
            cabecera = "<th>COD.</th><th width=\"250\"> DESCRIPCIÓN </th><th> CLASIF. </th><th>FECHA</th><th> DEPTO </th><th> ÁREA </th><th>TIP. FALLA</th><th>SIST. QA.</th><th>ORIGINADOR</th><th>DEPTO. ORI.</th>";
            Tabla.AppendLine(cabecera);
            Tabla.AppendLine("</thead>");
            Tabla.AppendLine("<tbody>");
            int Nro = 0;
            string _estilo = "";
            TB_AccesosBE _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id, 2);
            for (int i = 0; i < TotalRegistros; i++)
            {
                Nro = i + 1;

                //fecha = DateTime.ParseExact(Resultados.Rows[i]["Fecha_Alerta"].ToString(), "dd/MM/yyyy", null);
                _idEtiqueta = Resultados.Rows[i]["Alerta_id"].ToString();
                //if ((i % 2) == 0)
                //    Tabla.AppendLine("<tr bgcolor='#ECECEC'>");
                //else
                Tabla.AppendLine("<tr>");
                string color = "";
                if (Resultados.Rows[i]["Estado"].ToString() == "Reportado")
                {
                    _reportado++;
                    color = "style=\"background-color: #F82727;\"";
                }
                if (Resultados.Rows[i]["Estado"].ToString() == "Investigado")
                {
                    _investigados++;
                    color = "style=\"background-color: yellow;\"";
                }
                if (Resultados.Rows[i]["Estado"].ToString() == "Solucionado")
                {
                    _solucionados++;
                    color = "style=\"background-color: #52C226;\"";
                }
                //Tabla.Append("<td " + color + ">" + Resultados.Rows[i]["Estado"] + "</td>");
                if (_TB_AccesosBE.Permiso > 0)
                {
                    if (_TB_AccesosBE.Permiso == 1)
                        Tabla.Append("<td " + color + ">" + "<a href=\"#\" onClick=\"PopUp('EvaluacionAlertaPop.aspx?Alerta_id=" + _idEtiqueta + "',20,20,950,678); return false;\"> " + _idEtiqueta + " </a></td>");
                    else
                    {
                        if (Resultados.Rows[i]["Acceso"].ToString() == "1")
                            Tabla.Append("<td " + color + ">" + "<a href=\"#\" onClick=\"PopUp('EvaluacionAlertaPop.aspx?Alerta_id=" + _idEtiqueta + "',20,20,950,678); return false;\"> " + _idEtiqueta + " </a></td>");
                        else
                            Tabla.Append("<td " + color + ">" + _idEtiqueta + " </td>");
                    }
                }
                else
                    Tabla.Append("<td " + color + ">" + _idEtiqueta + " </td>");

                Tabla.Append("<td" + _estilo + ">" + "<a href=\"ActualizarAlerta.aspx?reg=ver&Alerta_id=" + _idEtiqueta + "\" > " + Resultados.Rows[i]["Alerta_desc"] + " </a></td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Clasificacion"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Fecha_Alerta"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Departamento_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Area_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["SistemaQA_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["SistemaQA_nom"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Funcionario_nome"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Departamento_ori"] + "</td>");
                
                Tabla.Append(Environment.NewLine);
                Tabla.AppendLine("</tr>");
            }
            Tabla.AppendLine("</tbody>");
            Tabla.AppendLine("</table>");
            ltlResults.Text = Tabla.ToString();

            //Generar Tabla Estadistica
            TablaE.AppendLine("<table border='1'>");
            TablaE.AppendLine("<tr>");
            TablaE.Append("<td> Reportados:</td>");
            TablaE.Append("<td style=\"background-color: #F82727;\">" + _reportado + "</td>");
            TablaE.Append(Environment.NewLine);
            TablaE.AppendLine("</tr>");
            TablaE.AppendLine("<tr>");
            TablaE.Append("<td> Investigado:</td>");
            TablaE.Append("<td style=\"background-color: yellow;\">" + _investigados + "</td>");
            TablaE.Append(Environment.NewLine);
            TablaE.AppendLine("</tr>");
            TablaE.AppendLine("<tr>");
            TablaE.Append("<td> Solucionado:</td>");
            TablaE.Append("<td style=\"background-color: #52C226;\">" + _solucionados + "</td>");
            TablaE.Append(Environment.NewLine);
            TablaE.AppendLine("</tr>");
            TablaE.AppendLine("<tr>");
            TablaE.Append("<td> Total:</td>");
            TablaE.Append("<td>" + (_solucionados+_investigados+_reportado) + "</td>");
            TablaE.Append(Environment.NewLine);
            TablaE.AppendLine("</tr>");
            TablaE.AppendLine("</table>");
            ltrEstadistica.Text = TablaE.ToString();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            string _Departamento_id, _Guardia_id, _Area_id, _Clasificacion_id
            , _ElementoClave_id, _Estado, _SistemaQA_id, _Originador;
            DateTime _Fecha_alerta, _Fecha_alerta1;
            int _Usuario_id;
            _Departamento_id = ddlDepartamento.SelectedValue;
            _Guardia_id = "%%";
            _Area_id = ddlArea.SelectedValue;
            _Clasificacion_id = ddlClasificacion.SelectedValue;
            _SistemaQA_id = ddlSistemaQA.SelectedValue;
            _Originador = ddlOriginador.SelectedValue;
            _ElementoClave_id = ddlElementoClave.SelectedValue;
            _Estado = ddlEstado.SelectedValue;

            if (ckbInicio.Checked == true)
            {
                _Fecha_alerta = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", null);
                _Fecha_alerta1 = DateTime.ParseExact(txtFecha0.Text, "dd/MM/yyyy", null);
            }
            else
            {
                _Fecha_alerta = DateTime.ParseExact("01/01/2011", "dd/MM/yyyy", null);
                _Fecha_alerta1 = Hoy;
            }
            _Usuario_id = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id;
            //if (ddlResuelto.SelectedValue == "%%")
            //    GenerarTabla(_estado, _tipo, _clasificacion, _categoria, _prioridad, _equipe_id, _encontrado, _dueno, _fecha, _fecha1, _fecha2, _fecha3, _depto_id, _parte);
            //else
            ExportToExcel(_Departamento_id, _Guardia_id,
                _Area_id, _Clasificacion_id, _SistemaQA_id, _ElementoClave_id,
                _Originador, _Estado, _Fecha_alerta, _Fecha_alerta1);
        }

        private void ExportToExcel(string _Departamento_id, string _Guardia_id
            , string _Area_id, string _Clasificacion_id, string _SistemaQA_id, string _ElementoClave_id
            , string _Originador, string _Estado, DateTime _Fecha_alerta, DateTime _Fecha_alerta1)
        {
            dvDefectos = new DataView(_ALR_AlertasBL.ListarALR_AlertasFindXLS(_Departamento_id, _Guardia_id,
                _Area_id, _Clasificacion_id, _SistemaQA_id, _ElementoClave_id,
                _Originador, _Estado, _Fecha_alerta, _Fecha_alerta1));
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
    }
}