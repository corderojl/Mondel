using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.LUPs
{
    public partial class registrarResponsableCategoria : System.Web.UI.Page
    {
        TB_ResponsableCategoriaBL _TB_ResponsableCategoriaBL = new TB_ResponsableCategoriaBL();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        LUP_CategoriaBL _LUP_CategoriaBL = new LUP_CategoriaBL();
        short _PlanAccion_id, _Tipo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                llenarComboCategoria();
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

        private void llenarComboCategoria()
        {
            ddlCategoria.DataSource = _LUP_CategoriaBL.ListarLUP_CategoriaO_Act();
            ddlCategoria.DataValueField = "Categoria_id";
            ddlCategoria.DataTextField = "Categoria_desc";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }
        protected void ibnCumplir_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            short _Categoria_id = short.Parse(((Label)fila.Controls[1]).Text);
            short _Funcionario_id = short.Parse(((Label)fila.Controls[3]).Text);
            bool obeRespuesta = _TB_ResponsableCategoriaBL.EliminarTB_ResponsableCategoria(_Categoria_id, _Funcionario_id);
            if (obeRespuesta)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('Se eliminó ResponsableCategoria con exito!');", true);
                GenerarTabla();
            }
            else
            {
            }
            //GenerarTabla(((Fnc_FuncionariosBE)Session["FNC_Funcionarios"]).Funcionario_Id);
        }
        private void GenerarTabla()
        {
            DataTable Resultados = _TB_ResponsableCategoriaBL.ListarTB_ResponsableCategoria_All();
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
            dpt = short.Parse(ddlCategoria.SelectedValue);
            emp = short.Parse(ddlEmpleado.SelectedValue);
            vexito = _TB_ResponsableCategoriaBL.InsertarTB_ResponsableCategoria(dpt, emp);
            if(vexito=="Exito")
                GenerarTabla();
            else
                if (vexito == "existe")
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('El ResponsableCategoria ya se encuentra en la lista!');", true);
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('Hubo un problema al registrar ResponsableCategoria, por favor contactese con el administrador!');", true);
        }
    }
}