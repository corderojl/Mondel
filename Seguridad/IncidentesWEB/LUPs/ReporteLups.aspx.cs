using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.LUPs
{
    public partial class ReporteLups : System.Web.UI.Page
    {
        protected DataView dvDefectos;
        LUP_LupBL _LUP_LupBL = new LUP_LupBL();
        TB_PilarBL _TB_PilarBL = new TB_PilarBL();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        LUP_CategoriaBL _LUP_CategoriaBL = new LUP_CategoriaBL();
        TB_GuardiaBL _TB_GuardiaBL = new TB_GuardiaBL();
        private List<TB_GuardiaBE> lbeFiltroGuardia;
        private List<LUP_CategoriaBE> lbeFiltroCategoria;
        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<TB_GuardiaBE> lTTB_GuardiaBE;
        List<LUP_CategoriaBE> lTLUP_CategoriaBE;
        List<Fnc_FuncionariosBE> lTFnc_FuncionariosBE;
        string fecha_actual;


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
                LlenarComboDepartamento();
                lTTB_GuardiaBE = _TB_GuardiaBL.ListarTB_GuardiaO_Act();
                Session["Guardias"] = lTTB_GuardiaBE;

                LlenarComboPilar();
                lTLUP_CategoriaBE = _LUP_CategoriaBL.ListarLUP_CategoriaO_Act();
                Session["Categorias"] = lTLUP_CategoriaBE;
                LlenarComboGuardia();
                LlenarComboCategoria();
                LlenarComboOriginador();
            }
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

        private void LlenarComboPilar()
        {
            ddlPilar.DataSource = _TB_PilarBL.ListarTB_Pilar_Act();
            ddlPilar.DataValueField = "Pilar_id";
            ddlPilar.DataTextField = "Pilar_desc";
            ddlPilar.DataBind();
            ddlPilar.Items.Insert(0, new ListItem("(Todos)", "%%"));
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string dep, pil, due, estado, gua, cat, palabra;
            DateTime fecha, fecha1;
            dep = ddlDepartamento.SelectedValue;
            pil = ddlPilar.SelectedValue;
            due = ddlOriginador.SelectedValue;
            estado = ddlEstado.SelectedValue;
            fecha = Convert.ToDateTime(txtFecha0.Text);
            fecha1 = Convert.ToDateTime(txtFecha.Text);
            gua = ddlGuardia.SelectedValue;
            cat = ddlCategoria.SelectedValue;
            palabra = txtPalabra.Text;
            generarTabla(dep, pil, gua, cat, due, estado, fecha.AddDays(1), fecha1, palabra);
        }

        private void generarTabla(string dep, string pil, string gua, string cat, string due, string estado, DateTime fecha, DateTime fecha1, string palabra)
        {
            DataTable Resultados = _LUP_LupBL.ListarLUP_LupFind(dep, pil, gua, cat, due, estado, fecha, fecha1, palabra);
            StringBuilder Tabla = new StringBuilder();

            TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();

            string _idEtiqueta;

            int TotalRegistros = Resultados.Rows.Count;
            Tabla.AppendLine("<table id=\"myTable\" class=\"tablesorter\">");
            Tabla.AppendLine("<thead>");
            string cabecera = "";
            cabecera = "<th>COD.</th><th width=\"150\"> TITULO </th><th> PILAR </th><th> ÁREA </th><th>GUARDIA</th><th>CATEGORIA</th><th> DUEÑO </th>><th>LUP</th><th>FECH. VENC.</th><th>FECH. REG.</th><th>ESTADO</th>";
            Tabla.AppendLine(cabecera);
            Tabla.AppendLine("</thead>");
            Tabla.AppendLine("<tbody>");
            int Nro = 0;
            string _estilo = "", archivo = "";
            int _registrados = 0, _aprobados = 0;
            string ext;
            string img = "";
            TB_AccesosBE _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id, 8);
            for (int i = 0; i < TotalRegistros; i++)
            {
                Nro = i + 1;
                _idEtiqueta = Resultados.Rows[i]["Lup_id"].ToString();
                Tabla.AppendLine("<tr>");
                string color = "";
                if (Resultados.Rows[i]["Estado"].ToString() == "Por aprobar")
                {
                    _registrados++;
                    color = "style=\"background-color: #F82727;\"";
                }
                if (Resultados.Rows[i]["Estado"].ToString() == "Aprobado")
                {
                    _aprobados++;
                    color = "style=\"background-color: #52C226;\"";
                }

                if (_TB_AccesosBE.Permiso > 0)
                {
                    //if (_TB_AccesosBE.Permiso == 1)
                    Tabla.Append("<td>" + "<a href=\"#\" onClick=\"PopUp('ActualizarLupPop.aspx?Lup_id=" + _idEtiqueta + "',20,20,950,678); return false;\"> " + _idEtiqueta + " </a></td>");
                    //else
                    //{
                    //    if (Resultados.Rows[i]["Acceso"].ToString() == "1")
                    //        Tabla.Append("<td>" + "<a href=\"#\" onClick=\"PopUp('ActualizarLupPop.aspx?Lup_id=" + _idEtiqueta + "',20,20,950,678); return false;\"> " + _idEtiqueta + " </a></td>");
                    //    else
                    //        Tabla.Append("<td>" + _idEtiqueta + " </td>");
                    //}
                }
                else
                    Tabla.Append("<td>" + _idEtiqueta + " </td>");

                Tabla.Append("<td " + _estilo + ">" + "<a href=\"ActualizarLup.aspx?reg=ver&Lup_id=" + _idEtiqueta + "\" > " + Resultados.Rows[i]["Lup_Titulo"] + " </a></td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Pilar_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Departamento_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Guardia_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Categoria_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Funcionario_nome"] + "</td>");
                archivo = Resultados.Rows[i]["adjunto_lup"].ToString();
                if (archivo != "")
                {
                    ext = Path.GetExtension(archivo);
                    if (ext != "")
                        switch (ext)
                        {
                            case ".pdf": img = "pdf.jpg"; break;
                            case ".doc": img = "word.jpg"; break;
                            case ".docx": img = "word.jpg"; break;
                            case ".docm": img = "word.jpg"; break;
                            case ".xls": img = "excel.jpg"; break;
                            case ".xlsx": img = "excel.jpg"; break;
                            case ".ppt": img = "power.jpg"; break;
                            case ".pptx": img = "power.jpg"; break;
                            case ".jpg": img = "imagen.jpg"; break;
                            case ".png": img = "imagen.jpg"; break;
                            case ".bmp": img = "imagen.jpg"; break;
                            default: img = "archivo.jpg"; break;
                        }
                    Tabla.Append("<td>" + "<a title=\"" + archivo + "\" href=\"Archivos/" + archivo + "\"  target=\"_blank\"><img src=\"images/" + img + "\" alt=\"" + archivo + "\" width=\"20\" height=\"20\"/></a></td>");

                }
                else
                    Tabla.Append("<td>Ninguno</td>");

                Tabla.Append("<td>" + Resultados.Rows[i]["fecha_ven"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["fecha_reg"] + "</td>");
                Tabla.Append("<td " + color + ">" + Resultados.Rows[i]["Estado"] + "</td>");

                Tabla.Append(Environment.NewLine);
                Tabla.AppendLine("</tr>");
            }
            Tabla.AppendLine("</tbody>");
            Tabla.AppendLine("</table>");
            ltlResults.Text = Tabla.ToString();
        }


        protected void btnExportar_Click(object sender, EventArgs e)
        {
            string dep, pil, due, estado, gua, cat, palabra;
            DateTime fecha, fecha1;
            dep = ddlDepartamento.SelectedValue;
            pil = ddlPilar.SelectedValue;
            due = ddlOriginador.SelectedValue;
            estado = ddlEstado.SelectedValue;
            fecha = Convert.ToDateTime(txtFecha0.Text);
            fecha1 = Convert.ToDateTime(txtFecha.Text);
            gua = ddlGuardia.SelectedValue;
            cat = ddlCategoria.SelectedValue;
            palabra = txtPalabra.Text;
            ExportToExcel(dep, pil, gua, cat, due, estado, fecha.AddDays(1), fecha1, palabra);
         
        }

        private void ExportToExcel(string dep, string pil, string gua, string cat, string due, string estado, DateTime fecha, DateTime fecha1, string palabra)
        {
            dvDefectos = new DataView(_LUP_LupBL.ListarLUP_LupFindXLS(dep, pil, gua, cat, due, estado, fecha.AddDays(1), fecha1, palabra));
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

        private void LlenarComboGuardia()
        {
            lTTB_GuardiaBE = (List<TB_GuardiaBE>)Session["Guardias"];
            Predicate<TB_GuardiaBE> pred = new Predicate<TB_GuardiaBE>(buscarGuardias);
            lbeFiltroGuardia = lTTB_GuardiaBE.FindAll(pred);
            Session["Filtro"] = lbeFiltroGuardia;

            ddlGuardia.DataSource = lbeFiltroGuardia;
            ddlGuardia.DataValueField = "Guardia_id";
            ddlGuardia.DataTextField = "Guardia_desc";
            ddlGuardia.DataBind();
            ddlGuardia.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }
        private bool buscarGuardias(TB_GuardiaBE obeGuardia)
        {
            bool exitoIdGuardia = true;
            if (!ddlDepartamento.SelectedValue.Equals("%%")) exitoIdGuardia = (obeGuardia.Departamento_id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdGuardia);
        }

        private void LlenarComboCategoria()
        {
            lTLUP_CategoriaBE = (List<LUP_CategoriaBE>)Session["Categorias"];
            Predicate<LUP_CategoriaBE> pred = new Predicate<LUP_CategoriaBE>(buscarCategorias);
            lbeFiltroCategoria = lTLUP_CategoriaBE.FindAll(pred);
            Session["Filtro"] = lbeFiltroCategoria;

            ddlCategoria.DataSource = lbeFiltroCategoria;
            ddlCategoria.DataValueField = "Categoria_id";
            ddlCategoria.DataTextField = "Categoria_desc";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }
        private bool buscarCategorias(LUP_CategoriaBE obeCategoria)
        {
            bool exitoIdCategoria = true;
            if (!ddlPilar.SelectedValue.Equals("%%")) exitoIdCategoria = (obeCategoria.Pilar_id.ToString().Equals(ddlPilar.SelectedValue));
            return (exitoIdCategoria);
        }
    }
}