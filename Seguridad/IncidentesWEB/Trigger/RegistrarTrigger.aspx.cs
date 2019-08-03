using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.Trigger
{
    public partial class RegistrarTrigger : System.Web.UI.Page
    {
        string fecha_actual;

        TRG_TriggerBE _TRG_TriggerBE = new TRG_TriggerBE();

        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TRG_TriggerBL _TRG_TriggerBL = new TRG_TriggerBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_GuardiaBL _TB_GuardiaBL = new TB_GuardiaBL();
        COM_ComportamientoBL _COM_ComportamientoBL = new COM_ComportamientoBL();

        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<TB_GuardiaBE> lTTB_GuardiaBE;
        List<COM_ComportamientoBE> lCOM_ComportamientoBE;
        private List<TB_GuardiaBE> lbeFiltroGuardia;
        private List<COM_ComportamientoBE> lbeFiltroCOM_ComportamientoDia;
        private List<COM_ComportamientoBE> lbeFiltroCOM_ComportamientoSemana;

        int _area_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime Hoy = DateTime.Today;
                fecha_actual = Hoy.ToString("dd/MM/yyyy");
                if (this.IsPostBack)
                {
                    _area_id = Convert.ToInt32(Session["AREA_ID"]);
                }
                else
                {
                    _area_id = Convert.ToInt32(Session["AREA_ID"]);
                    //Session["FUNCIONARIO_ID"] = "71046";
                    
                    //txtFecha.Text = fecha_actual;
                    lTTB_GuardiaBE = _TB_GuardiaBL.ListarTB_GuardiaO_Act();
                    Session["Guardias"] = lTTB_GuardiaBE;
                    lCOM_ComportamientoBE = _COM_ComportamientoBL.ListarCOM_Comportamiento_Dia();
                    Session["ComportamientoDia"] = lCOM_ComportamientoBE;
                    lCOM_ComportamientoBE = _COM_ComportamientoBL.ListarCOM_Comportamiento_Semana();
                    Session["ComportamientoSemana"] = lCOM_ComportamientoBE;
                    LlenarComboDepartamento();
                    ddlDepartamento.SelectedValue = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Area_Id.ToString();
                    LlenarComboGuardia();
                    
                }
            }
            catch (Exception x)
            {
                // Response.Redirect("error.aspx");
            }
        }
        private void LlenarComboDepartamento()
        {
            lTTB_DepartamentoBE = _TB_DepartamentoBL.ListarTB_Departamento_All("1");
            ddlDepartamento.DataSource = lTTB_DepartamentoBE;
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                var _mietq_etiqueta = _TRG_TriggerBE;
                _mietq_etiqueta.Trigger_fecha = DateTime.ParseExact(fecha_actual, "dd/MM/yyyy", null);
                _mietq_etiqueta.Departamento_id = Convert.ToInt16(ddlDepartamento.SelectedValue);
                _mietq_etiqueta.Guardia_id = Convert.ToInt16(ddlGuardia.SelectedValue);
                _mietq_etiqueta.Comp_crit_dia = "";
                _mietq_etiqueta.Comp_crit_sem = "";
                _mietq_etiqueta.Originador = Convert.ToInt16(((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id);
                _mietq_etiqueta.Accidente_donde ="";
                _mietq_etiqueta.Completar = 0;
                _mietq_etiqueta.Activo = true;
                int vexito = _TRG_TriggerBL.InsertarTRG_Trigger(_TRG_TriggerBE);
                if (vexito != 0)
                {
                    Response.Redirect("actualizarTrigger.aspx?Trigger_id=" + vexito + "&reg=exito");
                }
                else
                {
                    Response.Redirect("error.aspx?error=" + vexito);
                }

            }
            catch (Exception ex)
            {
                //lblMensaje.Text = ex.ToString();
            }
        }

        //private void enviarEmail(int _Id, Int16 _Departamento_id, string _Titulo)
        //{
        //    MailBL _MailBL = new MailBL();
        //    TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();
        //    List<string> ListEmail=_TB_AccesosBL.ListarTB_AccesosEmailByDeparatmento(_Departamento_id, 2);
        //    string _BodyHTML = _MailBL.doBodyAlerta(_Id, _Titulo, ddlDepartamento.SelectedItem.ToString());
        //    foreach (string ElemtEmail in ListEmail)
        //    {
        //        _MailBL.sndMailHeader(ElemtEmail, _BodyHTML, "Trigger N° "+_Id+": "+_Titulo);
        //    }
        //}

        private bool buscarGuardias(TB_GuardiaBE obeGuardia)
        {
            bool exitoIdGuardia = true;
            if (!ddlDepartamento.SelectedValue.Equals("0")) exitoIdGuardia = (obeGuardia.Departamento_id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdGuardia);
        }
        private bool buscarComportamientoDia(COM_ComportamientoBE obeComportamientoDia)
        {
            bool exitoIdSistemaQA = true;
            if (!ddlDepartamento.SelectedValue.Equals("0")) exitoIdSistemaQA = (obeComportamientoDia.Departamento.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdSistemaQA);
        }
        private bool buscarComportamientoSemana(COM_ComportamientoBE obeComportamientoSemana)
        {
            bool exitoIdSistemaQA = true;
            if (!ddlDepartamento.SelectedValue.Equals("0")) exitoIdSistemaQA = (obeComportamientoSemana.Departamento.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdSistemaQA);
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
        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboGuardia();
        }

    }
}