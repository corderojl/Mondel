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
    public partial class AdministracionFuncionarios : System.Web.UI.Page
    {
        EVA_CategoriaBL _EVA_CategoriaBL = new EVA_CategoriaBL();
        EVA_SubCategoriaBL _EVA_SubCategoriaBL = new EVA_SubCategoriaBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_RolBL _TB_RolBL = new TB_RolBL();
        EVA_AreaLaborBL _EVA_AreaLaboralBL = new EVA_AreaLaborBL();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        string _Funcionario_nome, _Categoria_id, _SubCategoria_id, _Departamento_id, _Rol_id, _AreaLabor_id, _Estado, _Lider;
        List<EVA_SubCategoriaBE> lTEVA_SubCategoriaBE;

        private List<EVA_SubCategoriaBE> lbeFiltroSu;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!this.IsPostBack)
            {
                lTEVA_SubCategoriaBE = _EVA_SubCategoriaBL.ListarEVA_SubCategoriaO_Act();
                Session["SubCategoria"] = lTEVA_SubCategoriaBE;
                LlenarComboCategoria();
                LlenarComboDepartamento();
                LlenarComboRol();
                LlenarComboAreaLaboral();
                LlenarComboLider();
                _Funcionario_nome = txtFuncionarios.Text;
                if (_Funcionario_nome == "")
                    _Funcionario_nome = "%%";
                _Categoria_id = ddlCategoria.SelectedValue;
                _SubCategoria_id = ddlSubCategoria.SelectedValue;
                _Departamento_id = ddlDepartamento.SelectedValue;
                _Rol_id = ddlRol.SelectedValue;
                _AreaLabor_id = ddlAreaLaboral.SelectedValue;
                _Estado = ddlEstado.SelectedValue;
                _Lider = ddlLider.SelectedValue;
                GenerarTabla(_Funcionario_nome, _Categoria_id, _SubCategoria_id, _Departamento_id, _Rol_id, _AreaLabor_id, _Estado, _Lider);
            }
            
        }

        private void LlenarComboLider()
        {
            ddlLider.DataSource = _Fnc_FuncionariosBL.ListarFNC_FuncionariosLideresO_Act();
            ddlLider.DataValueField = "Funcionario_id";
            ddlLider.DataTextField = "Funcionario_nome";
            ddlLider.DataBind();
            ddlLider.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }

        private void LlenarComboDepartamento()
        {
            ddlDepartamento.DataSource = _TB_DepartamentoBL.ListarTB_Departamento_All("%%"); 
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }

        private void GenerarTabla(string _Funcionario_nome, string _Categoria_id, string _SubCategoria_id, string _Departamento_id, string _Rol_id, string _AreaLabor_id
            , string _Estado, string _Lider)
        {
            TEM_ComportamientoEstadistica _ComEstad = new TEM_ComportamientoEstadistica();
            DataTable Resultados = _Fnc_FuncionariosBL.ListarFnc_FuncionariosFill(_Funcionario_nome, _Categoria_id, _SubCategoria_id, _Departamento_id, _Rol_id, _AreaLabor_id, _Estado, _Lider);
            StringBuilder Tabla = new StringBuilder();
            TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();

            string _idEtiqueta;

            int TotalRegistros = Resultados.Rows.Count;
            Tabla.AppendLine("<table id=\"myTable\" class=\"tablesorter\">");
            Tabla.AppendLine("<thead>");
            string cabecera = "";
            cabecera = "<th>SHARP</th><th width=\"110\"> NOMBRES </th><th> DPTO. </th><th>ÁREA LABOR</th><th> Ce.coste</th><th> POSICIÓN </th><th> CATEGORIA </th><th>SUBCATEGORIA</th><th>LIDER</th><th>ESTADO</th>";
            Tabla.AppendLine(cabecera);
            Tabla.AppendLine("</thead>");
            Tabla.AppendLine("<tbody>");
            int Nro = 0;
            string _estilo = "";
            //TB_AccesosBE _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id);
            for (int i = 0; i < TotalRegistros; i++)
            {
                Nro = i + 1;
                _idEtiqueta = Resultados.Rows[i]["Funcionario_id"].ToString();
                Tabla.AppendLine("<tr>");

                //if (_TB_AccesosBE.Permiso > 0)
                //{
                //    if (_TB_AccesosBE.Permiso == 1)
                Tabla.Append("<td" + _estilo + ">" + "<a href=\"#\" onClick=\"PopUp('ActualizarFuncionarioPop.aspx?Funcionario_id=" + _idEtiqueta + "',20,20,850,500); return false;\"> " + Resultados.Rows[i]["FUNCIONARIO_TNUMBER"] + " </a></td>");
                //    else
                //    {
                //if (Resultados.Rows[i]["Acceso"].ToString() == "1")
                //    Tabla.Append("<td" + _estilo + ">" + "<a href=\"#\" onClick=\"PopUp('EvaluacionIncidentePop.aspx?Comportamiento_id=" + _idEtiqueta + "',20,20,950,678); return false;\"> " + _idEtiqueta + " </a></td>");
                //else
                //    Tabla.Append("<td" + _estilo + ">" + _idEtiqueta + " </td>");
                //    }
                //}
                //else
                //Tabla.Append("<td" + _estilo + ">" + _idEtiqueta + " </td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["FUNCIONARIO_NOME"] + " </td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Departamento_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["AreaLabor_desc"] + "</td>");
                
                //Tabla.Append("<td>" + Resultados.Rows[i]["Descripcion"] + "</td>");

                Tabla.Append("<td>" + Resultados.Rows[i]["CE_COSTE"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Rol_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Categoria_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["SubCategoria_desc"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["Lider"] + "</td>");
                Tabla.Append("<td>" + Resultados.Rows[i]["FUNCIONARIO_STATUS"] + "</td>");
                Tabla.Append(Environment.NewLine);
                Tabla.AppendLine("</tr>");
            }
            Tabla.AppendLine("</tbody>");
            Tabla.AppendLine("</table>");
            ltlResults.Text = Tabla.ToString();            

        }
        private void LlenarComboRol()
        {
            ddlRol.DataSource = _TB_RolBL.ListarTB_RolO_Act();
            ddlRol.DataValueField = "Rol_id";
            ddlRol.DataTextField = "Rol_desc";
            ddlRol.DataBind();
            ddlRol.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }
        private void LlenarComboAreaLaboral()
        {
            ddlAreaLaboral.DataSource = _EVA_AreaLaboralBL.ListarEVA_AreaLaborO_Act();
            ddlAreaLaboral.DataValueField = "AreaLabor_id";
            ddlAreaLaboral.DataTextField = "AreaLabor_desc";
            ddlAreaLaboral.DataBind();
            ddlAreaLaboral.Items.Insert(0, new ListItem("(Todos)", "%%"));
        }
        private void LlenarComboCategoria()
        {
            ddlCategoria.DataSource = _EVA_CategoriaBL.ListarEVA_CategoriaO_Act();
            ddlCategoria.DataValueField = "Categoria_id";
            ddlCategoria.DataTextField = "Categoria_desc";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("(Todos)", "%%"));
            LlenarComboSubCategoria();
        }
        private bool buscarSubCategorias(EVA_SubCategoriaBE obeSubCategoria)
        {
            bool exitoIdSubCategoria = true;
            if (!ddlCategoria.SelectedValue.Equals("%%")) exitoIdSubCategoria = (obeSubCategoria.Categoria_id.ToString().Equals(ddlCategoria.SelectedValue));
            return (exitoIdSubCategoria);
        }
        private void LlenarComboSubCategoria()
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


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            _Funcionario_nome = txtFuncionarios.Text;
            if (_Funcionario_nome == "")
                _Funcionario_nome = "%%";
            _Categoria_id = ddlCategoria.SelectedValue;
            _SubCategoria_id = ddlSubCategoria.SelectedValue;
            _Departamento_id = ddlDepartamento.SelectedValue;
            _Rol_id = ddlRol.SelectedValue;
            _AreaLabor_id = ddlAreaLaboral.SelectedValue;
            _Estado = ddlEstado.SelectedValue;
            _Lider = ddlLider.SelectedValue;
            GenerarTabla(_Funcionario_nome, _Categoria_id, _SubCategoria_id, _Departamento_id, _Rol_id, _AreaLabor_id, _Estado, _Lider);
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboSubCategoria();
        }
    }
}