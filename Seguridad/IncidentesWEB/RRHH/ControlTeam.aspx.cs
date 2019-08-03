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

namespace IncidentesWEB.RRHH
{
    public partial class ControlTeam : System.Web.UI.Page
    {
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_GuardiaBL _TB_GuardiaBL = new TB_GuardiaBL();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        StringBuilder Tabla = new StringBuilder();

        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<TB_GuardiaBE> lTTB_GuardiaBE;
        private List<TB_GuardiaBE> lbeFiltro;

        protected void Page_Load(object sender, EventArgs e)
        {

            int _func_id = Convert.ToInt32(Request.QueryString["func_id"]);
            if (!IsPostBack)
            {
                lTTB_GuardiaBE = _TB_GuardiaBL.ListarTB_GuardiaO_Act();
                Session["Guardias"] = lTTB_GuardiaBE;
                llenarDepto();
                LlenarComboGuardia();
            }
        }

        private void llenarDepto()
        {
            lTTB_DepartamentoBE = _TB_DepartamentoBL.ListarTB_DepartamentoO_Act("%%");
            ddlDepartamento.DataSource = lTTB_DepartamentoBE;
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Elija una Opcion..", "%%"));
        }
        private void LlenarComboGuardia()
        {
            lTTB_GuardiaBE = (List<TB_GuardiaBE>)Session["Guardias"];
            Predicate<TB_GuardiaBE> pred = new Predicate<TB_GuardiaBE>(buscarGuardias);
            lbeFiltro = lTTB_GuardiaBE.FindAll(pred);
            Session["Filtro"] = lbeFiltro;

            ddlGuardia.DataSource = lbeFiltro;
            ddlGuardia.DataValueField = "Guardia_id";
            ddlGuardia.DataTextField = "Guardia_desc";
            ddlGuardia.DataBind();
            ddlGuardia.Items.Insert(0, new ListItem("Elija una Opcion..", "%%"));
        }
        private bool buscarGuardias(TB_GuardiaBE obeGuardia)
        {
            bool exitoIdGuardia = true;
            if (!ddlDepartamento.SelectedValue.Equals("0")) exitoIdGuardia = (obeGuardia.Departamento_id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdGuardia);
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboGuardia();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            generarTabla(ddlDepartamento.SelectedValue,ddlGuardia.SelectedValue);
        }
        private void generarTabla(string _departamento_id, string _guardia_id)
        {
            DataTable _dt_func_grupos = new DataTable();
           // _idArea = Convert.ToInt32(ddlDepartamento.SelectedValue);
            _dt_func_grupos = _Fnc_FuncionariosBL.ListarFnc_FuncionariosByGuardia(_departamento_id, _guardia_id);
            if (_dt_func_grupos.Rows.Count > 0)
            {
                int TotalRegistros = _dt_func_grupos.Rows.Count;
                Tabla.Append("<table class=\"search_table\">");
                Tabla.Append(Environment.NewLine);
                Tabla.Append("<thead>");
                Tabla.Append(Environment.NewLine);
                Tabla.Append("<th> Legajo </th><th> Apellidos y Nombres </th><th> Grupo </th><th> Editar </th>");
                Tabla.Append(Environment.NewLine);
                Tabla.Append("</thead>");
                Tabla.Append(Environment.NewLine);
                Tabla.Append("<tbody>");
                Tabla.Append(Environment.NewLine);
                for (int i = 0; i < TotalRegistros; i++)
                {
                    int Nro = i + 1;
                    Tabla.Append("<tr>");
                    Tabla.Append(Environment.NewLine);
                    Tabla.Append("<td>" + _dt_func_grupos.Rows[i]["FUNCIONARIO_DRT"] + "</td>");
                    Tabla.Append("<td>" + _dt_func_grupos.Rows[i]["funcionario_nome"] + "</td>");
                    Tabla.Append("<td>" + _dt_func_grupos.Rows[i]["Guardia_desc"] + "</td>");
                    Tabla.Append("<td><a href=\"ActualizarDepartamento.aspx?funcionario_id=" + _dt_func_grupos.Rows[i]["FUNCIONARIO_ID"] + "\">cambiar</a></td>");
                    Tabla.Append(Environment.NewLine);
                    Tabla.Append("</tr>");
                }
                Tabla.Append(Environment.NewLine);
                Tabla.Append("</tbody>");
                Tabla.Append(Environment.NewLine);
                Tabla.Append("</table>");
                ltlResults.Text = Tabla.ToString();
            }
            else
            {
                ltlResults.Text = "No hay resultados";
            }
        }
    }
}