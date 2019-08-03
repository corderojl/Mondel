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
    public partial class ActualizarFuncionarioPop : System.Web.UI.Page
    {
        EVA_CategoriaBL _EVA_CategoriaBL = new EVA_CategoriaBL();
        EVA_SubCategoriaBL _EVA_SubCategoriaBL = new EVA_SubCategoriaBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_RolBL _TB_RolBL = new TB_RolBL();
        EVA_AreaLaborBL _EVA_AreaLaboralBL = new EVA_AreaLaborBL();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();

        List<EVA_SubCategoriaBE> lTEVA_SubCategoriaBE;
        private List<EVA_SubCategoriaBE> lbeFiltroSu;
        Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                int _Funcionario_id;
                _Funcionario_id = Convert.ToInt32(Request.QueryString["Funcionario_id"]);
                _Fnc_FuncionariosBE = _Fnc_FuncionariosBL.TraerFnc_Funcionario(_Funcionario_id);
                lTEVA_SubCategoriaBE = _EVA_SubCategoriaBL.ListarEVA_SubCategoriaO_Act();
                Session["SubCategoria"] = lTEVA_SubCategoriaBE;
                lblIncidente_id.Text = _Fnc_FuncionariosBE.Funcionario_Id.ToString();
                lblSharp.Text = _Fnc_FuncionariosBE.Funcionario_Tnumber;
                txtNombres.Text = _Fnc_FuncionariosBE.Funcionario_Nome;
                txtCodigo.Text = _Fnc_FuncionariosBE.Funcionario_Drt;
                txtCoste.Text = _Fnc_FuncionariosBE.CE_Coste;
                txtEmail.Text = _Fnc_FuncionariosBE.Funcionario_Email;
                LlenarComboCategoria();
                LlenarComboSubCategoria();
                LlenarComboDepartamento();
                LlenarComboRol(_Fnc_FuncionariosBE.Rol_id);
                LlenarComboAreaLaboral(_Fnc_FuncionariosBE.AreaLabor_id);
                LlenarComboLider(_Fnc_FuncionariosBE.Superior);
                ddlCategoria.SelectedValue = _Fnc_FuncionariosBE.Categoria_id.ToString();
                ddlSubCategoria.SelectedValue = _Fnc_FuncionariosBE.SubCategoria_id.ToString();
                ddlEstado.SelectedValue = _Fnc_FuncionariosBE.Funcionario_Status.ToString();
                ddlDepartamento.SelectedValue = _Fnc_FuncionariosBE.Area_Id.ToString();
            }
        }
        private void LlenarComboLider(int _Lider)
        {
            ddlLider.DataSource = _Fnc_FuncionariosBL.ListarFnc_FuncionariosO_Act();
            ddlLider.DataValueField = "FUNCIONARIO_ID";
            ddlLider.DataTextField = "FUNCIONARIO_NOME";
            ddlLider.DataBind();
            ddlLider.Items.Insert(0, new ListItem("Seleccionar", "0"));
            ddlLider.SelectedValue = _Lider.ToString();
        }

        private void LlenarComboDepartamento()
        {
            ddlDepartamento.DataSource = _TB_DepartamentoBL.ListarTB_Departamento_All("1");
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Seleccionar", "0"));
           
        }
        private void LlenarComboRol(int _Rol_id)
        {
            ddlRol.DataSource = _TB_RolBL.ListarTB_RolO_Act();
            ddlRol.DataValueField = "Rol_id";
            ddlRol.DataTextField = "Rol_desc";
            ddlRol.DataBind();
            ddlRol.Items.Insert(0, new ListItem("Seleccionar", "0"));
            ddlRol.SelectedValue = _Rol_id.ToString();
        }
        private void LlenarComboAreaLaboral(int _AreaLabor_id)
        {
            ddlAreaLabor.DataSource = _EVA_AreaLaboralBL.ListarEVA_AreaLaborO_Act();
            ddlAreaLabor.DataValueField = "AreaLabor_id";
            ddlAreaLabor.DataTextField = "AreaLabor_desc";
            ddlAreaLabor.DataBind();
            ddlAreaLabor.Items.Insert(0, new ListItem("Seleccionar", "0"));
            ddlAreaLabor.SelectedValue = _AreaLabor_id.ToString();
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
            _Fnc_FuncionariosBE.Funcionario_Id =short.Parse(lblIncidente_id.Text);
            _Fnc_FuncionariosBE.Funcionario_Nome = txtNombres.Text;
            _Fnc_FuncionariosBE.Funcionario_Email = txtEmail.Text;
            _Fnc_FuncionariosBE.Funcionario_Drt = txtCodigo.Text;
            _Fnc_FuncionariosBE.Funcionario_Status = short.Parse(ddlEstado.SelectedValue);
            _Fnc_FuncionariosBE.Area_Id = short.Parse(ddlDepartamento.SelectedValue);
            _Fnc_FuncionariosBE.Rol_id = short.Parse(ddlRol.SelectedValue);
            _Fnc_FuncionariosBE.CE_Coste = txtCoste.Text;
            _Fnc_FuncionariosBE.AreaLabor_id = int.Parse(ddlAreaLabor.SelectedValue);
            _Fnc_FuncionariosBE.SubCategoria_id = int.Parse(ddlSubCategoria.SelectedValue);
            _Fnc_FuncionariosBE.Superior = short.Parse(ddlLider.SelectedValue);
            

            if (_Fnc_FuncionariosBL.ActualizarFNC_Funcionarios(_Fnc_FuncionariosBE))
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ActualizoExito();", true);
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "alert('Húbo un problema al actualizar empleado');", true);
        }

        private void ActualizarFuncionario(string _Funcionario_nome, string _Categoria_id, string _SubCategoria_id, string _Departamento_id, string _Rol_id, string _AreaLabor_id, string _Estado, string _Lider)
        {
            throw new NotImplementedException();
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboSubCategoria();
        }
    }
}