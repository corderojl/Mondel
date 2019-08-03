using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.LUPs
{
    public partial class RegistrarFuncionarioPop : System.Web.UI.Page
    {
        EVA_CategoriaBL _EVA_CategoriaBL = new EVA_CategoriaBL();
        EVA_SubCategoriaBL _EVA_SubCategoriaBL = new EVA_SubCategoriaBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_RolBL _TB_RolBL = new TB_RolBL();
        EVA_AreaLaborBL _EVA_AreaLaboralBL = new EVA_AreaLaborBL();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TB_GuardiaBL _TB_GuardiaBL = new TB_GuardiaBL();
        List<EVA_SubCategoriaBE> lTEVA_SubCategoriaBE;
        private List<EVA_SubCategoriaBE> lbeFiltroSu;
        Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();

        private List<TB_GuardiaBE> lbeFiltroGuardia;
        List<TB_GuardiaBE> lTTB_GuardiaBE;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DateTime Hoy;
                Hoy = DateTime.Today;
                string fecha_actual;
                lTEVA_SubCategoriaBE = _EVA_SubCategoriaBL.ListarEVA_SubCategoriaO_Act();
                Session["SubCategoria"] = lTEVA_SubCategoriaBE;
                fecha_actual = Hoy.ToString("dd/MM/yyyy");
                txtFechaIngreso.Text = fecha_actual;
                txtFechaNacimiento.Text = fecha_actual;
                LlenarComboCategoria();
                LlenarComboSubCategoria();
                LlenarComboDepartamento();
                lTTB_GuardiaBE = _TB_GuardiaBL.ListarTB_GuardiaO_Act();
                Session["Guardias"] = lTTB_GuardiaBE;
                LlenarComboGuardia();
                LlenarComboRol();
                LlenarComboAreaLaboral();
                LlenarComboLider();
            }
        }
        private bool buscarGuardias(TB_GuardiaBE obeGuardia)
        {
            bool exitoIdGuardia = true;
            if (!ddlDepartamento.SelectedValue.Equals("0")) exitoIdGuardia = (obeGuardia.Departamento_id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdGuardia);
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
            ddlGuardia.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string _Funcionario_nome, _Categoria_id, _SubCategoria_id, _Departamento_id, _Rol_id, _AreaLabor_id, _Estado, _Lider;


            _Funcionario_nome = txtNombres.Text;

            _Categoria_id = ddlCategoria.SelectedValue;
            _SubCategoria_id = ddlSubCategoria.SelectedValue;
            _Departamento_id = ddlDepartamento.SelectedValue;
            _Rol_id = ddlRol.SelectedValue;
            _AreaLabor_id = ddlAreaLabor.SelectedValue;
            _Estado = ddlEstado.SelectedValue;
            _Lider = ddlLider.SelectedValue;

            _Fnc_FuncionariosBE.Funcionario_Nome = txtNombres.Text;
            _Fnc_FuncionariosBE.Funcionario_Tnumber = txtSharp.Text;
            _Fnc_FuncionariosBE.Funcionario_Email = txtEmail.Text;
            _Fnc_FuncionariosBE.Funcionario_Drt = txtCodigo.Text;
            _Fnc_FuncionariosBE.Funcionario_Status = short.Parse(ddlEstado.SelectedValue);
            _Fnc_FuncionariosBE.Area_Id = short.Parse(ddlDepartamento.SelectedValue);
            _Fnc_FuncionariosBE.Rol_id = short.Parse(ddlRol.SelectedValue);
            _Fnc_FuncionariosBE.CE_Coste = txtCoste.Text;
            _Fnc_FuncionariosBE.AreaLabor_id = int.Parse(ddlAreaLabor.SelectedValue);
            _Fnc_FuncionariosBE.SubCategoria_id = int.Parse(ddlSubCategoria.SelectedValue);
            _Fnc_FuncionariosBE.Superior = short.Parse(ddlLider.SelectedValue);
            _Fnc_FuncionariosBE.Fecha_ingreso = DateTime.Parse(txtFechaIngreso.Text);
            _Fnc_FuncionariosBE.Fecha_naci= DateTime.Parse(txtFechaNacimiento.Text);
            _Fnc_FuncionariosBE.Genero = short.Parse(rblEstado.SelectedValue);

            short id = _Fnc_FuncionariosBL.InsertarFNC_Funcionarios(_Fnc_FuncionariosBE);
            if (id>0)
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ActualizoExito();", true);
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "alert('Húbo un problema al actualizar empleado');", true);
        }
        private void LlenarComboLider()
        {
            ddlLider.DataSource = _Fnc_FuncionariosBL.ListarFnc_FuncionariosO_Act();
            ddlLider.DataValueField = "FUNCIONARIO_ID";
            ddlLider.DataTextField = "FUNCIONARIO_NOME";
            ddlLider.DataBind();
            ddlLider.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        private void LlenarComboDepartamento()
        {
            ddlDepartamento.DataSource = _TB_DepartamentoBL.ListarTB_Departamento_All("1");
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Seleccionar", "0"));

        }
        private void LlenarComboRol()
        {
            ddlRol.DataSource = _TB_RolBL.ListarTB_RolO_Act();
            ddlRol.DataValueField = "Rol_id";
            ddlRol.DataTextField = "Rol_desc";
            ddlRol.DataBind();
            ddlRol.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }
        private void LlenarComboAreaLaboral()
        {
            ddlAreaLabor.DataSource = _EVA_AreaLaboralBL.ListarEVA_AreaLaborO_Act();
            ddlAreaLabor.DataValueField = "AreaLabor_id";
            ddlAreaLabor.DataTextField = "AreaLabor_desc";
            ddlAreaLabor.DataBind();
            ddlAreaLabor.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }
        private void LlenarComboCategoria()
        {
            ddlCategoria.DataSource = _EVA_CategoriaBL.ListarEVA_CategoriaO_Act();
            ddlCategoria.DataValueField = "Categoria_id";
            ddlCategoria.DataTextField = "Categoria_desc";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("Seleccionar", "0"));

        }
        private bool buscarSubCategorias(EVA_SubCategoriaBE obeSubCategoria)
        {
            bool exitoIdSubCategoria = true;
            if (!ddlCategoria.SelectedValue.Equals("0")) exitoIdSubCategoria = (obeSubCategoria.Categoria_id.ToString().Equals(ddlCategoria.SelectedValue));
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
            ddlSubCategoria.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboSubCategoria();
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboGuardia();
        }
    }
}