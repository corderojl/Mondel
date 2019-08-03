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
    public partial class registrarResponsablePilar : System.Web.UI.Page
    {
        TB_ResponsablePilarBL _TB_ResponsablePilarBL = new TB_ResponsablePilarBL();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TB_PilarBL _TB_PilarBL = new TB_PilarBL();
        short _PlanAccion_id, _Tipo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                llenarComboPilar();
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

        private void llenarComboPilar()
        {
            ddlPilar.DataSource = _TB_PilarBL.ListarTB_Pilar_Act();
            ddlPilar.DataValueField = "Pilar_id";
            ddlPilar.DataTextField = "Pilar_desc";
            ddlPilar.DataBind();
            ddlPilar.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }
        protected void ibnCumplir_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            short _Pilar_id = short.Parse(((Label)fila.Controls[1]).Text);
            short _Funcionario_id = short.Parse(((Label)fila.Controls[3]).Text);
            bool obeRespuesta = _TB_ResponsablePilarBL.EliminarTB_ResponsablePilar(_Pilar_id, _Funcionario_id);
            if (obeRespuesta)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('Se eliminó ResponsablePilar con exito!');", true);
                GenerarTabla();
            }
            else
            {
            }
            //GenerarTabla(((Fnc_FuncionariosBE)Session["FNC_Funcionarios"]).Funcionario_Id);
        }
        private void GenerarTabla()
        {
            DataTable Resultados = _TB_ResponsablePilarBL.ListarTB_ResponsablePilar_All();
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
            dpt = short.Parse(ddlPilar.SelectedValue);
            emp = short.Parse(ddlEmpleado.SelectedValue);
            vexito = _TB_ResponsablePilarBL.InsertarTB_ResponsablePilar(dpt, emp);
            if(vexito=="Exito")
                GenerarTabla();
            else
                if (vexito == "existe")
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('El ResponsablePilar ya se encuentra en la lista!');", true);
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('Hubo un problema al registrar ResponsablePilar, por favor contactese con el administrador!');", true);
        }
    }
}