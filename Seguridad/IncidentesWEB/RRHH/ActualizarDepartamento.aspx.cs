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
    public partial class ActualizarDepartamento : System.Web.UI.Page
    {
        int id, area;
        string _varea = "";
        protected DataView dvGrupo;

        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_GuardiaBL _TB_GuardiaBL = new TB_GuardiaBL();
        TB_GuardiaBE _TB_GuardiaBE = new TB_GuardiaBE();

        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        StringBuilder Tabla = new StringBuilder();

        Fnc_FuncionariosBE _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();

   


        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<TB_GuardiaBE> lTTB_GuardiaBE;
        private List<TB_GuardiaBE> lbeFiltro;

        protected void Page_Load(object sender, EventArgs e)
        {
            area = Convert.ToInt32(Request.QueryString["area"]);
            if (!IsPostBack)
            {
                
                lblLegajo.Text = _Fnc_FuncionariosBE.Funcionario_Drt;
                
                lblApellido.Text = _Fnc_FuncionariosBE.Funcionario_Nome;
                

                lTTB_GuardiaBE = _TB_GuardiaBL.ListarTB_GuardiaO_Act();
                Session["Guardias"] = lTTB_GuardiaBE;
               llenarDepto();
                ddlDepartamento.SelectedValue = _Fnc_FuncionariosBE.Area_Id.ToString();
                LlenarComboGuardia();
                ddlGuardia.SelectedValue = _Fnc_FuncionariosBE.Grupo_Id.ToString();
               




            }
                    }

        private void llenarDepto()
        {
            lTTB_DepartamentoBE = _TB_DepartamentoBL.ListarTB_Departamento_All("1");
            ddlDepartamento.DataSource = lTTB_DepartamentoBE;
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
            ddlDepartamento.DataBind();
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
            ddlGuardia.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
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
            int _funcionario_id = Convert.ToInt32(Request.QueryString["Funcionario_id"]);
            int _grupo_id = Convert.ToInt32(ddlGuardia.SelectedValue);
            int _area_id = Convert.ToInt32(ddlDepartamento.SelectedValue);

           // int grupo = Convert.ToInt32(ddlDepartamento.SelectedValue);
         //   int _vgrupo = Convert.ToInt32(Request.QueryString["grupo"]);
            if (_Fnc_FuncionariosBL.ActualizarFnc_FuncionariosGuardia(_area_id, _grupo_id, _funcionario_id) == true)
              
            {
                Response.Write("<script language=javascript>alert('Se actualizo con exito');</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('Ocurrio un error al actualizar');</script>");
            }
        }

        private void cargarFuncionario(int vcod)
        {
            DataTable _dt_guardias = new DataTable();
            DataTable _dt_grupos = new DataTable();
            string _vgrupo;
            _dt_guardias = _TB_GuardiaBL.ConsultarGuardiaId(vcod);
            _dt_grupos = _Fnc_FuncionariosBL.ListarFnc_Funcionarios_All();
            if (_dt_guardias.Rows.Count > 0)
            {
                lblLegajo.Text = Convert.ToString(_dt_guardias.Rows[0]["FUNCIONARIO_DRT"]);
                lblLegajo.Text = _Fnc_FuncionariosBE.Funcionario_Drt;
                lblApellido.Text = Convert.ToString(_dt_guardias.Rows[0]["funcionario_nome"]);
                lblApellido.Text = _Fnc_FuncionariosBE.Funcionario_Nome;
               // _vgrupo = Convert.ToString(_dt_guardias.Rows[0]["GRUPO_ID"]);
             //   _varea = Convert.ToString(_dt_guardias.Rows[0]["AREA_ID"]);
              //  llenarGrupo(_vgrupo, area);


              

            }
            else
            {
                ltrMensaje.Text = "Error al cargar los datos.";
            }
        }

        private void llenarGrupo(string _vcod, int _area)
        {
           // dvGrupo = new DataView(_T.ListarGrupo_Id(_area));
            dvGrupo = new DataView(_TB_GuardiaBL.ConsultarGuardiaId(_area));
            ddlGuardia.DataSource = dvGrupo;
            ddlGuardia.DataValueField = "GRUPO_ID";
            ddlGuardia.DataTextField = "GRUPO_NOME";
            ddlGuardia.SelectedValue = _vcod;
            ddlGuardia.DataBind();
        }
    }
}