using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IncidentesBL;
using IncidentesBE;

namespace IncidentesWEB
{
    public partial class _Default : System.Web.UI.Page
    {
        Fnc_FuncionariosBE _Fnc_FuncionariosBE = null;
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_PlanAccionBL _TB_PlanAccionBL = new TB_PlanAccionBL();
        TRG_TriggerBL _TRG_TriggerBL = new TRG_TriggerBL();
        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        MailBL _MailBL = new MailBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Fnc_Funcionarios"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (this.IsPostBack)
            {
                _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
                _Fnc_FuncionariosBE = (Fnc_FuncionariosBE)Session["Fnc_Funcionarios"];
                lblUsuario.Text = _Fnc_FuncionariosBE.Funcionario_Nome;
                llenarPlanesPendientes(_Fnc_FuncionariosBE.Funcionario_Id);
                llenarTriggerHSE(Convert.ToInt16(_Fnc_FuncionariosBE.Area_Id));
            }
            else
            {
                _Fnc_FuncionariosBE = new Fnc_FuncionariosBE();
                _Fnc_FuncionariosBE = (Fnc_FuncionariosBE)Session["Fnc_Funcionarios"];
                lblUsuario.Text = _Fnc_FuncionariosBE.Funcionario_Nome;
                LlenarComboDepartamento();
                ddlDepartamento.SelectedValue = _Fnc_FuncionariosBE.Area_Id.ToString();
                llenarPlanesPendientes(_Fnc_FuncionariosBE.Funcionario_Id);
                llenarTriggerHSE(Convert.ToInt16(_Fnc_FuncionariosBE.Area_Id));
                if (!_MailBL.ComprobarFormatoEmail(_Fnc_FuncionariosBE.Funcionario_Email))
                {
                    string script = @"<script type='text/javascript'>materialConfirm('Title','Content',function(result){console.log(result)});</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
            }
        }
        private void LlenarComboDepartamento()
        {
            lTTB_DepartamentoBE = _TB_DepartamentoBL.ListarTB_DepartamentoO_Act("%%");;
            ddlDepartamento.DataSource = lTTB_DepartamentoBE;
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Fnc_FuncionariosBE = (Fnc_FuncionariosBE)Session["Fnc_Funcionarios"];
            _Fnc_FuncionariosBE.Area_Id = int.Parse(ddlDepartamento.SelectedValue);
            Session["Fnc_Funcionarios"] = _Fnc_FuncionariosBE;
            llenarPlanesPendientes(_Fnc_FuncionariosBE.Funcionario_Id);
            llenarTriggerHSE(Convert.ToInt16(_Fnc_FuncionariosBE.Area_Id));
        }
        private void llenarPlanesPendientes(int _Funcionario_id)
        {
            int[] Valor;
            Valor = _TB_PlanAccionBL.ContarTB_PlanAccionByFuncionario(_Funcionario_id);
            lblPlanPendiente.Text = "<a href=\"#\" onClick=\"PopUp('PlanPendiente.aspx?Responsable=" + _Fnc_FuncionariosBE.Funcionario_Id + "&Tipo=1',20,20,924,625); return false;\">" + Valor[1].ToString() + "</a>";
            lblPlanCaducado.Text = "<a href=\"#\" onClick=\"PopUp('PlanPendiente.aspx?Responsable=" + _Fnc_FuncionariosBE.Funcionario_Id + "&Tipo=2',20,20,924,625); return false;\">" + Valor[2].ToString() + "</a>";
        }
        private void llenarTriggerHSE(short _Departamento_id)
        {
            try
            {
                DataTable Resultados = _TRG_TriggerBL.TraerTRG_TriggerSemaforo(_Departamento_id);
                int Valor = 0;
                string _estilo = "";
                Valor = Convert.ToInt32(Resultados.Rows[0]["Valor"]);
                int _idEtiqueta = Convert.ToInt32(Resultados.Rows[0]["Trigger_id"]);

                if (Valor <= 5)
                    _estilo = "<h1><span class='verde'><a href=\"#\" onClick=\"PopUp('Trigger/ActualizarTriggerPopUp.aspx?Trigger_id=" + _idEtiqueta + "',20,20,950,678); return false;\">" + Valor + "</a></span></h1> ";
                else
                {
                    if (Valor >= 6)
                        //  _estilo = "<h1><span class='amarillo'>" + Valor + "</span></h1> ";
                        _estilo = "<h1><span class='amarillo'><a href=\"#\" onClick=\"PopUp('Trigger/ActualizarTriggerPopUp.aspx?Trigger_id=" + _idEtiqueta + "',20,20,950,678); return false;\">" + Valor + "</a></span></h1> ";
                    if (Valor > 8)
                        // _estilo = "<h1><span class='rojo'>" + Valor + "</span></h1> ";
                        _estilo = "<h1><span class='rojo'><a href=\"#\" onClick=\"PopUp('Trigger/ActualizarTriggerPopUp.aspx?Trigger_id=" + _idEtiqueta + "',20,20,950,678); return false;\">" + Valor + "</a></span></h1> ";
                }
                lblTriggerHSE.Text = _estilo;
            }
            catch (Exception x)
            {
                lblTriggerHSE.Text = "<h1><span class='gris'>0</span></h1> ";
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            int _funcionario_id;
            string _funcionario_email;
            _Fnc_FuncionariosBE = (Fnc_FuncionariosBE)Session["Fnc_Funcionarios"];
            _funcionario_id = _Fnc_FuncionariosBE.Funcionario_Id;
            _funcionario_email = txtEmail.Text;
            Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
            try
            {
                if (!_MailBL.ComprobarFormatoEmail(_funcionario_email))
                {
                    string script = @"<script type='text/javascript'>materialConfirm('Title','Content',function(result){console.log(result)});</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
                else
                {
                    _Fnc_FuncionariosBL.ActualizarFNC_FuncionariosEmail(_funcionario_id, _funcionario_email);
                }
            }
            catch (Exception X)
            {
                String mensaje = "<script language='JavaScript'>window.alert('" + X.Message + "')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }

        }
    }
}