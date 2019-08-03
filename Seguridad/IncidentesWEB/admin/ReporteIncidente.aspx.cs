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

namespace IncidentesWEB.admin
{
    public partial class ReporteIncidente : System.Web.UI.Page
    {
        string fecha_actual;
       
        protected DataView dvDefectos;
        //datatable
       
        TB_IncidentesBL _TB_IncidentesBL = new TB_IncidentesBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_ClasificacionBL _TB_ClasificacionBL = new TB_ClasificacionBL();

        TB_AreaBL _TB_AreaBL = new TB_AreaBL();
        TB_RolBL _TB_RolBL = new TB_RolBL();
        TB_ContratistaBL _TB_ContratistaBL = new TB_ContratistaBL();
        TB_EstatusOperacionalBL _TB_EstatusOperacionalBL = new TB_EstatusOperacionalBL();
        TB_ParteCuerpoBL _TB_ParteCuerpoBL = new TB_ParteCuerpoBL();
        TB_EquipoAfectadoBL _TB_EquipoAfectadoBL = new TB_EquipoAfectadoBL();
        TB_CausaInmediataBL _TB_CausaInmediataBL = new TB_CausaInmediataBL();
        TB_RiesgoInvolucradoBL _TB_RiesgoIvolucradoBL = new TB_RiesgoInvolucradoBL();
        TB_CondicionInvolucradaBL _TB_CondicionInvolucradaBL = new TB_CondicionInvolucradaBL();
        TB_ElementoClaveBL _TB_ElementoClaveBL = new TB_ElementoClaveBL();

        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<TB_AreaBE> lTTB_AreaBE;
        List<TB_EstatusOperacionalBE> lTTB_EstatusOperacionalBE;
        List<TB_ClasificacionBE> lTTB_ClasificacionBE;

        List<TB_RolBE> lTTB_RolBE;
        List<TB_ElementoClaveBE> lTTB_SistemaBE;
        List<TB_CausaInmediataBE> lTTB_CausaInmediataBE;
        List<TB_CondicionInvolucradaBE> lTTB_CondicionInvolucradaBE;
        List<TB_RiesgoInvolucradoBE> lTTB_RiesgoInvolucradoBE;

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
                ddlDepartamento.SelectedValue = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Area_Id.ToString();
                LlenarComboArea();
                LlenarComboClasificacion();
                LlenarComboRol();
                LlenarComboEstatusOperacional();
                LlenarComboComportamientoInvolucrado();
                LlenarComboCausaInmediata();
                LlenarComboElementoCLave();
                LlenarComboCondicionInvolucrada();
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

        private void LlenarComboArea()
        {
            lTTB_AreaBE = _TB_AreaBL.ListarTB_AreaO_Act();
            ddlArea.DataSource = lTTB_AreaBE;
            ddlArea.DataValueField = "Area_id";
            ddlArea.DataTextField = "Area_desc";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }
        private void LlenarComboClasificacion()
        {
            lTTB_ClasificacionBE = _TB_ClasificacionBL.ListarTB_ClasificacionO_Act();
            ddlClasificacion.DataSource = lTTB_ClasificacionBE;
            ddlClasificacion.DataValueField = "Clasificacion_id";
            ddlClasificacion.DataTextField = "Clasificacion_desc";
            ddlClasificacion.DataBind();
            ddlClasificacion.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }
        private void LlenarComboRol()
        {
            lTTB_RolBE = _TB_RolBL.ListarTB_RolO_Act();
            ddlRol.DataSource = lTTB_RolBE;
            ddlRol.DataValueField = "Rol_id";
            ddlRol.DataTextField = "Rol_desc";
            ddlRol.DataBind();
            ddlRol.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }
        private void LlenarComboEstatusOperacional()
        {
            lTTB_EstatusOperacionalBE = _TB_EstatusOperacionalBL.ListarTB_EstatusOperacionalO_Act();
            ddlEstatusOperacional.DataSource = lTTB_EstatusOperacionalBE;
            ddlEstatusOperacional.DataValueField = "EstatusOperacional_id";
            ddlEstatusOperacional.DataTextField = "EstatusOperacional_desc";
            ddlEstatusOperacional.DataBind();
            ddlEstatusOperacional.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }
        private void LlenarComboComportamientoInvolucrado()
        {
            lTTB_RiesgoInvolucradoBE = _TB_RiesgoIvolucradoBL.ListarTB_RiesgoInvolucradoO_Act();
            ddlComportamientoInv.DataSource = lTTB_RiesgoInvolucradoBE;
            ddlComportamientoInv.DataValueField = "Riesgo_inv_id";
            ddlComportamientoInv.DataTextField = "Riesgo_inv_desc";
            ddlComportamientoInv.DataBind();
            ddlComportamientoInv.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }
        private void LlenarComboCondicionInvolucrada()
        {
            lTTB_CondicionInvolucradaBE = _TB_CondicionInvolucradaBL.ListarTB_CondicionInvolucradaO_Act();
            ddlCondicionInv.DataSource = lTTB_CondicionInvolucradaBE;
            ddlCondicionInv.DataValueField = "Condicion_inv_id";
            ddlCondicionInv.DataTextField = "Condicion_inv_desc";
            ddlCondicionInv.DataBind();
            ddlCondicionInv.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }
        private void LlenarComboCausaInmediata()
        {
            lTTB_CausaInmediataBE = _TB_CausaInmediataBL.ListarTB_CausaInmediataO_Act();
            ddlCausaInmediata.DataSource = lTTB_CausaInmediataBE;
            ddlCausaInmediata.DataValueField = "CausaInmediata_id";
            ddlCausaInmediata.DataTextField = "CausaInmediata_desc";
            ddlCausaInmediata.DataBind();
            ddlCausaInmediata.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }

        private void LlenarComboElementoCLave()
        {
            lTTB_SistemaBE = _TB_ElementoClaveBL.ListarTB_ElementoClaveO_Act();
            ddlSistema.DataSource = lTTB_SistemaBE;
            ddlSistema.DataValueField = "ElementoClave_id";
            ddlSistema.DataTextField = "ElementoClave_desc";
            ddlSistema.DataBind();
            ddlSistema.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            string _Departamento_id, _Guardia_id, _Area_id, _Clasificacion_id, _Tipo_emp, _Rol_id
            , _Rol_tiempo, _Compania_tiempo, _Turno, _Estatus_ope
            , _Comportamiento_inv_id, _Condicion_inv_id, _CausaInmediata_id, _Tecnologia_id
            , _ElementoClave_id, _Estado;
            DateTime _Fecha_incidente, _Fecha_incidente1;
            int _Usuario_id;
            _Departamento_id = ddlDepartamento.SelectedValue;
            _Guardia_id = "%%";
            _Area_id = ddlArea.SelectedValue;
            _Clasificacion_id = ddlClasificacion.SelectedValue;
            _Tipo_emp = ddlTipoPersonal.SelectedValue;
            _Rol_id = ddlRol.SelectedValue;
            _Rol_tiempo = "%%";
            _Compania_tiempo = ddlTiempoCompania.SelectedValue;
            _Turno = ddlTurno.SelectedValue;
            _Estatus_ope = ddlEstatusOperacional.SelectedValue;
            _Comportamiento_inv_id = ddlComportamientoInv.SelectedValue;
            _Condicion_inv_id = ddlCondicionInv.SelectedValue;
            _CausaInmediata_id = ddlCausaInmediata.SelectedValue;
            _Tecnologia_id = "%%";
            _ElementoClave_id = ddlSistema.SelectedValue;
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
            _Usuario_id = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id;
            //if (ddlResuelto.SelectedValue == "%%")
            //    GenerarTabla(_estado, _tipo, _clasificacion, _categoria, _prioridad, _equipe_id, _encontrado, _dueno, _fecha, _fecha1, _fecha2, _fecha3, _depto_id, _parte);
            //else
            GenerarTabla(_Departamento_id, _Guardia_id,
                _Area_id, _Clasificacion_id, _Tipo_emp, _Rol_id, _Rol_tiempo, _Compania_tiempo, _Turno,
                _Estatus_ope, _Comportamiento_inv_id, _Condicion_inv_id, _CausaInmediata_id, _Tecnologia_id, _ElementoClave_id,
                _Estado, _Fecha_incidente, _Fecha_incidente1, _Usuario_id);
        }

        private void GenerarTabla(string _Departamento_id, string _Guardia_id
            , string _Area_id, string _Clasificacion_id, string _Tipo_emp, string _Rol_id
            , string _Rol_tiempo, string _Compania_tiempo, string _Turno, string _Estatus_ope
            , string _Comportamiento_inv_id, string _Condicion_inv_id, string _CausaInmediata_id, string _Tecnologia_id
            , string _ElementoClave_id, string _Estado, DateTime _Fecha_incidente, DateTime _Fecha_incidente1, int _Usuario_id)
        {

            DataTable Resultados = _TB_IncidentesBL.ListarTB_IncidentesFind(_Departamento_id, _Guardia_id,
                _Area_id, _Clasificacion_id, _Tipo_emp, _Rol_id, _Rol_tiempo, _Compania_tiempo, _Turno,
                _Estatus_ope, _Comportamiento_inv_id, _Condicion_inv_id, _CausaInmediata_id, _Tecnologia_id, _ElementoClave_id,
                _Estado, _Fecha_incidente, _Fecha_incidente1, _Usuario_id);

            DataTable Estadisticas = _TB_IncidentesBL.ListarTB_Incidentes_Estadistica(_Departamento_id, _Guardia_id,
                _Area_id, _Clasificacion_id, _Tipo_emp, _Rol_id, _Rol_tiempo, _Compania_tiempo, _Turno,
                _Estatus_ope, _Comportamiento_inv_id, _Condicion_inv_id, _CausaInmediata_id, _Tecnologia_id, _ElementoClave_id,
                _Estado, _Fecha_incidente, _Fecha_incidente1);
            StringBuilder Tabla = new StringBuilder();
            StringBuilder TablaE = new StringBuilder();
            TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();

            string _idEtiqueta;

            int TotalRegistros = Resultados.Rows.Count;
            Tabla.AppendLine("<table id=\"myTable\" class=\"tablesorter\">");
            Tabla.AppendLine("<thead>");
            string cabecera = "";
            cabecera = "<th>COD.</th><th width=\"210\"> TITULO </th><th> DEPARTAMENTO. </th><th>FECHA</th><th> LOCALIZACIÓN </th><th> CLASIFI. </th><th>TIP. EMP.</th><th>ORIGINADOR</th><th> ESTADO </th>";
            Tabla.AppendLine(cabecera);
            Tabla.AppendLine("</thead>");
            Tabla.AppendLine("<tbody>");
            int Nro = 0;
            string _estilo = "";
            TB_AccesosBE _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id,1);
            for (int i = 0; i < TotalRegistros; i++)
            {
                Nro = i + 1;

                //fecha = DateTime.ParseExact(Resultados.Rows[i]["Fecha_incidente"].ToString(), "dd/MM/yyyy", null);
                _idEtiqueta = Resultados.Rows[i]["Incidente_id"].ToString();
                //if ((i % 2) == 0)
                //    Tabla.AppendLine("<tr bgcolor='#ECECEC'>");
                //else
                Tabla.AppendLine("<tr>");

                if (_TB_AccesosBE.Permiso > 0)
                {
                    if (_TB_AccesosBE.Permiso == 1)
                        Tabla.Append("<td" + _estilo + ">" + "<a href=\"#\" onClick=\"PopUp('EvaluacionIncidentePop.aspx?Incidente_id=" + _idEtiqueta + "',20,20,950,678); return false;\"> " + _idEtiqueta + " </a></td>");
                    else
                    {
                        if (Resultados.Rows[i]["Acceso"].ToString()=="1")
                            Tabla.Append("<td" + _estilo + ">" + "<a href=\"#\" onClick=\"PopUp('EvaluacionIncidentePop.aspx?Incidente_id=" + _idEtiqueta + "',20,20,950,678); return false;\"> " + _idEtiqueta + " </a></td>");
                        else
                            Tabla.Append("<td" + _estilo + ">" + _idEtiqueta + " </td>");
                    }
                }
                else
                    Tabla.Append("<td" + _estilo + ">" + _idEtiqueta + " </td>");

                Tabla.Append("<td" + _estilo + ">" + "<a href=\"ActualizarIncidente.aspx?reg=ver&Incidente_id=" + _idEtiqueta + "\" > " + Resultados.Rows[i]["Titulo"] + " </a></td>");
                //Tabla.Append("<td>" + Resultados.Rows[i]["Descripcion"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Departamento"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Fecha_incidente"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Area_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Clasificacion_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Tipo_emp"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Originador"] + "</td>");
                string color = "";
                if (Resultados.Rows[i]["Estado"].ToString() == "Reportado")
                    color = "style=\"background-color: #F82727;\"";
                if (Resultados.Rows[i]["Estado"].ToString() == "Investigado")
                    color = "style=\"background-color: #F1BF20;\"";
                if (Resultados.Rows[i]["Estado"].ToString() == "Solucionado")
                    color = "style=\"background-color: #52C226;\"";
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
            for (int i = 0; i < TotalRegistros; i++)
            {
                TablaE.AppendLine("<tr>");
                TablaE.Append("<td>" + Estadisticas.Rows[i]["clasificacion_desc"] + "</td>");
                TablaE.Append("<td>" + Estadisticas.Rows[i]["numero"] + "</td>");
                TablaE.Append(Environment.NewLine);
                TablaE.AppendLine("</tr>");
            }
            TablaE.AppendLine("</table>");
            ltrEstadistica.Text = TablaE.ToString();

        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            string _Departamento_id, _Guardia_id, _Area_id, _Clasificacion_id, _Tipo_emp, _Rol_id
            , _Rol_tiempo, _Compania_tiempo, _Turno, _Estatus_ope
            , _Comportamiento_inv_id, _Condicion_inv_id, _CausaInmediata_id, _Tecnologia_id
            , _ElementoClave_id, _Estado;
            DateTime _Fecha_incidente, _Fecha_incidente1;
            int _Usuario_id;
            _Departamento_id = ddlDepartamento.SelectedValue;
            _Guardia_id = "%%";
            _Area_id = ddlArea.SelectedValue;
            _Clasificacion_id = ddlClasificacion.SelectedValue;
            _Tipo_emp = ddlTipoPersonal.SelectedValue;
            _Rol_id = ddlRol.SelectedValue;
            _Rol_tiempo = "%%";
            _Compania_tiempo = ddlTiempoCompania.SelectedValue;
            _Turno = ddlTurno.SelectedValue;
            _Estatus_ope = ddlEstatusOperacional.SelectedValue;
            _Comportamiento_inv_id = ddlComportamientoInv.SelectedValue;
            _Condicion_inv_id = ddlCondicionInv.SelectedValue;
            _CausaInmediata_id = ddlCausaInmediata.SelectedValue;
            _Tecnologia_id = "%%";
            _ElementoClave_id = ddlSistema.SelectedValue;
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
            _Usuario_id = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id;
            //if (ddlResuelto.SelectedValue == "%%")
            //    GenerarTabla(_estado, _tipo, _clasificacion, _categoria, _prioridad, _equipe_id, _encontrado, _dueno, _fecha, _fecha1, _fecha2, _fecha3, _depto_id, _parte);
            //else
            ExportToExcel(_Departamento_id, _Guardia_id,
                _Area_id, _Clasificacion_id, _Tipo_emp, _Rol_id, _Rol_tiempo, _Compania_tiempo, _Turno,
                _Estatus_ope, _Comportamiento_inv_id, _Condicion_inv_id, _CausaInmediata_id, _Tecnologia_id, _ElementoClave_id,
                _Estado, _Fecha_incidente, _Fecha_incidente1);  
        }

        private void ExportToExcel(string _Departamento_id, string _Guardia_id
            , string _Area_id, string _Clasificacion_id, string _Tipo_emp, string _Rol_id
            , string _Rol_tiempo, string _Compania_tiempo, string _Turno, string _Estatus_ope
            , string _Comportamiento_inv_id, string _Condicion_inv_id, string _CausaInmediata_id, string _Tecnologia_id
            , string _ElementoClave_id, string _Estado, DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            dvDefectos = new DataView(_TB_IncidentesBL.ListarTB_IncidentesFindXLS(_Departamento_id, _Guardia_id,
                _Area_id, _Clasificacion_id, _Tipo_emp, _Rol_id, _Rol_tiempo, _Compania_tiempo, _Turno,
                _Estatus_ope, _Comportamiento_inv_id, _Condicion_inv_id, _CausaInmediata_id, _Tecnologia_id, _ElementoClave_id,
                _Estado, _Fecha_incidente, _Fecha_incidente1));
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