using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.Trigger
{
    public partial class AdministrarRiesgo : System.Web.UI.Page
    {
        TRG_RiesgosBL _TRG_RiesgosBL = new TRG_RiesgosBL();
        TRG_RiesgosBE _TRG_RiesgosBE = new TRG_RiesgosBE();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        List<TRG_RiesgosBE> lTTRG_RiesgosBE;
        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                lblMensaje.Text = "";
            }
            else
            {
                LlenarComboDepartamento();
                lblMensaje.Text = "";
                lblMensaje.ForeColor = Color.Red;
                ibnGuardar.Visible = false;
                txtRiesgo.Visible = false;
                txtValor.Visible = false;
            }
        }
        private void LlenarComboDepartamento()
        {
            lTTB_DepartamentoBE = _TB_DepartamentoBL.ListarTB_DepartamentoO_Act("1");
            ddlDepartamento.DataSource = lTTB_DepartamentoBE;
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
        }
        private void GenerarTabla(Int16 _Departamento_id)
        {
            if (_Departamento_id != 0)
            {
                ibnGuardar.Visible = true;
                txtRiesgo.Visible = true;
                txtValor.Visible = true;
            }
            else
            {
                ibnGuardar.Visible = false;
                txtRiesgo.Visible = false;
                txtRiesgo.Visible = false;
            }
            lTTRG_RiesgosBE = _TRG_RiesgosBL.ListarTRG_RiesgosByDepartamento(_Departamento_id);
            rpSistemaQA.DataSource = lTTRG_RiesgosBE;
            rpSistemaQA.DataBind();
        }

        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _Sistemaqa_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            string _valor;
            var _miObj = _TRG_RiesgosBE;
            //_miempl.Emp_id = "";
            _miObj.Riesgo_id = _Sistemaqa_id;
            _miObj.Riesgo_desc = ((TextBox)fila.Controls[3]).Text;
            _miObj.Valor = Convert.ToInt32(((TextBox)fila.Controls[5]).Text);
            _miObj.Departamento_id = Int16.Parse(ddlDepartamento.SelectedValue);

            bool obeRespuesta = _TRG_RiesgosBL.ActualizarTRG_Riesgos(_TRG_RiesgosBE);
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
            Int16 _Departamento_id = Int16.Parse(ddlDepartamento.SelectedValue);
            GenerarTabla(_Departamento_id);
        }

        protected void ibnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _Sistemaqa_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            bool obeRespuesta = _TRG_RiesgosBL.EliminarTRG_Riesgos(_Sistemaqa_id);
            if (!obeRespuesta)
            {
                String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo eliminar el registro')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
            else
            {
                
            }
            Int16 _Departamento_id = Int16.Parse(ddlDepartamento.SelectedValue);
            GenerarTabla(_Departamento_id);
        }

        protected void ibnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int status;
                var _miObj = _TRG_RiesgosBE;
                Int16 _Departamento_id = Int16.Parse(ddlDepartamento.SelectedValue);
                _miObj.Riesgo_desc = txtRiesgo.Text;
                _miObj.Valor = int.Parse(txtValor.Text);
                _miObj.Departamento_id = _Departamento_id;
                int vexito = _TRG_RiesgosBL.InsertarTRG_Riesgos(_TRG_RiesgosBE);
                if (vexito != 0)
                {
                    GenerarTabla(_Departamento_id);
                    txtRiesgo.Text = "";
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

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int16 _Departamento_id = Int16.Parse(ddlDepartamento.SelectedValue);
            GenerarTabla(_Departamento_id);
        }
    }
}