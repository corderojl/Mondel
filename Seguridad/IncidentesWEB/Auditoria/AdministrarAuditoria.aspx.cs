using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.Auditoria
{
    public partial class AdministrarAuditoria : System.Web.UI.Page
    {
        AUD_PreguntaBL _AUD_PreguntaBL = new AUD_PreguntaBL();
        AUD_QuienAuditarBL _AUD_QuienAuditarBL = new AUD_QuienAuditarBL();
        AUD_PreguntaBE _AUD_PreguntaBE = new AUD_PreguntaBE();
        AUD_AuditoriaTipoBL _AUD_AuditoriaTipoBL = new AUD_AuditoriaTipoBL();
        List<AUD_AuditoriaTipoBE> lTAUD_AuditoriaTipoBE;
        List<AUD_QuienAuditarBE> lTAUD_QuienAuditarBE;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                lblMensaje.Text = "";
            }
            else
            {
                LlenarComboAuditoriaTipo();
                LlenarComboQuienAudita();
                lblMensaje.Text = "";
                lblMensaje.ForeColor = Color.Red;
                ibnGuardar.Visible = false;
                txtPreguntaDesc.Visible = false;
                ddlQuienAudita.Visible = false;
                ibnGuardar.Visible = false;
                txtPregunta_donde.Visible = false;
                //txtRiesgo.Visible = false;
                //txtValor.Visible = false;
            }
        }

        private void LlenarComboQuienAudita()
        {
            lTAUD_QuienAuditarBE = _AUD_QuienAuditarBL.ListarAUD_QuienAuditarO_Act();
            ddlQuienAudita.DataSource = lTAUD_QuienAuditarBE;
            ddlQuienAudita.DataValueField = "QuienAuditar_id";
            ddlQuienAudita.DataTextField = "QuienAuditar_Desc";
            ddlQuienAudita.DataBind();
            ddlQuienAudita.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }

        private void LlenarComboAuditoriaTipo()
        {
            lTAUD_AuditoriaTipoBE = _AUD_AuditoriaTipoBL.ListarAUD_AuditoriaTipoO_Act();
            ddlAuditoriaTipo.DataSource = lTAUD_AuditoriaTipoBE;
            ddlAuditoriaTipo.DataValueField = "AuditoriaTipo_id";
            ddlAuditoriaTipo.DataTextField = "Auditoria_desc";
            ddlAuditoriaTipo.DataBind();
            ddlAuditoriaTipo.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        private void GenerarTabla(Int16 _Departamento_id)
        {
            if (_Departamento_id != 0)
            {
                ibnGuardar.Visible = true;
                //txtRiesgo.Visible = true;
                //txtValor.Visible = true;
            }
            else
            {
                ibnGuardar.Visible = false;
                //txtRiesgo.Visible = false;
                //txtRiesgo.Visible = false;
            }
            rpPreguntaAuditoria.DataSource = _AUD_PreguntaBL.ListarAUD_PreguntaByAuditoriaTipo(_Departamento_id); ;
            rpPreguntaAuditoria.DataBind();
            ibnGuardar.Visible = true;
            ddlQuienAudita.Visible = true;
            txtPreguntaDesc.Visible = true;
            txtPregunta_donde.Visible = true;
        }

        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _Sistemaqa_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            string _valor;
            var _miObj = _AUD_PreguntaBE;
            //_miempl.Emp_id = "";
            _miObj.Pregunta_id = _Sistemaqa_id;
            _miObj.Pregunta_desc = ((TextBox)fila.Controls[7]).Text;
            //_miObj.Valor = Convert.ToInt32(((TextBox)fila.Controls[6]).Text);
            //_miObj.Departamento_id = Int16.Parse(ddlAuditoriaTipo.SelectedValue);

            bool obeRespuesta = _AUD_PreguntaBL.ActualizarAUD_Pregunta(_AUD_PreguntaBE);
            if (!obeRespuesta)
            {
                String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo eliminar el registro')</script>";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
            else
            {
                lblMensaje.ForeColor = Color.Green;
                lblMensaje.Text = "Registro actualizado";
            }
            Int16 _Departamento_id = Int16.Parse(ddlAuditoriaTipo.SelectedValue);
            GenerarTabla(_Departamento_id);
        }

        protected void ibnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _Sistemaqa_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            bool obeRespuesta = _AUD_PreguntaBL.EliminarAUD_Pregunta(_Sistemaqa_id);
            if (!obeRespuesta)
            {
                String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo eliminar el registro')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
            else
            {
                
            }
            Int16 _Departamento_id = Int16.Parse(ddlAuditoriaTipo.SelectedValue);
            GenerarTabla(_Departamento_id);
        }

        protected void ibnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                var _miObj = _AUD_PreguntaBE;
                Int16 _AuditoriaTipo_id = Int16.Parse(ddlAuditoriaTipo.SelectedValue);
                _miObj.Pregunta_desc = txtPreguntaDesc.Text;
                _miObj.Pregunta_donde = txtPregunta_donde.Text;
                _miObj.QuienAuditar_id = Convert.ToInt16(ddlQuienAudita.SelectedValue);
                _miObj.AuditoriaTipo_id = _AuditoriaTipo_id;
                int vexito = _AUD_PreguntaBL.InsertarAUD_Pregunta(_AUD_PreguntaBE);
                if (vexito != 0)
                {
                    GenerarTabla(_AuditoriaTipo_id);
                    //txtRiesgo.Text = "";
                }
                else
                {
                    lblMensaje.Text = "error, revise los datos";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "error inesperado: " + ex.Message;
            }
        }

        protected void ddlAuditoriaTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int16 _Auditoria_id = Int16.Parse(ddlAuditoriaTipo.SelectedValue);
            GenerarTabla(_Auditoria_id);
        }

    }
}