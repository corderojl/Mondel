using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB
{
    public partial class registrarResponsable : System.Web.UI.Page
    {
        TB_ResponsableBL _TB_ResponsableBL = new TB_ResponsableBL();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        short _PlanAccion_id, _Tipo;
        protected void Page_Load(object sender, EventArgs e)
        {
            _PlanAccion_id = Convert.ToInt16(Request.QueryString["PlanAccion_id"]);
            _Tipo = Convert.ToInt16(Request.QueryString["Tipo"]);
            if (!this.IsPostBack)
            {
                llenarComboDepartamento();
                llenarComboEmpleado();
                GenerarTabla();
            }
        }

        private void llenarComboEmpleado()
        {
            ddlEmpleado.DataSource = _Fnc_FuncionariosBL.ListarFnc_FuncionariosO_Act(); ;
            ddlEmpleado.DataValueField = "Funcionario_id";
            ddlEmpleado.DataTextField = "Funcionario_nome";
            ddlEmpleado.DataBind();
            ddlEmpleado.Items.Insert(0, new ListItem("(Seleccionar)", "0"));
        }

        private void llenarComboDepartamento()
        {
            ddlDepartamento.DataSource = _TB_DepartamentoBL.ListarTB_DepartamentoO_Act("1");
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }
        protected void ibnCumplir_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            short _Departamento_id = short.Parse(((Label)fila.Controls[1]).Text);
            short _Funcionario_id = short.Parse(((Label)fila.Controls[3]).Text);
            bool obeRespuesta = _TB_ResponsableBL.EliminarTB_Responsable(_Departamento_id, _Funcionario_id);
            if (obeRespuesta)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('Se eliminó responsable con exito!');", true);
                GenerarTabla();
            }
            else
            {
            }
            //GenerarTabla(((Fnc_FuncionariosBE)Session["FNC_Funcionarios"]).Funcionario_Id);
        }
        private void GenerarTabla()
        {
            DataTable Resultados = _TB_ResponsableBL.ListarTB_Responsable_All();
            rpPlanAccion.DataSource = Resultados;
            rpPlanAccion.DataBind();
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ActualizoExito();", true);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            short dpt, emp;
            string vexito = "";
            dpt = short.Parse(ddlDepartamento.SelectedValue);
            emp = short.Parse(ddlEmpleado.SelectedValue);
            vexito = _TB_ResponsableBL.InsertarTB_Responsable(dpt, emp);
            if(vexito=="Exito")
                GenerarTabla();
            else
                if (vexito == "existe")
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('El responsable ya se encuentra en la lista!');", true);
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('Hubo un problema al registrar responsable, por favor contactese con el administrador!');", true);
        }
    }
}