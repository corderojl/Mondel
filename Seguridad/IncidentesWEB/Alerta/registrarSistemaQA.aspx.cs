using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.Alerta
{
    public partial class registrarSistemaQA : System.Web.UI.Page
    {
        ALR_SistemaqaBL _ALR_SistemaqaBL = new ALR_SistemaqaBL();
        ALR_SistemaqaBE _ALR_SistemaqaBE = new ALR_SistemaqaBE();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        List<ALR_SistemaqaBE> lTALR_SistemaqaBE;
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
                ibnGuardar.Visible = false;
                txtSistemaQA.Visible = false;
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
                txtSistemaQA.Visible = true;
            }
            else
            {
                ibnGuardar.Visible = false;
                txtSistemaQA.Visible = false;
            }
            lTALR_SistemaqaBE = _ALR_SistemaqaBL.ListarALR_SistemaqaByDepartamento(_Departamento_id);
            rpSistemaQA.DataSource = lTALR_SistemaqaBE;
            rpSistemaQA.DataBind();
        }

        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _Sistemaqa_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            var _miObj = _ALR_SistemaqaBE;
            //_miempl.Emp_id = "";
            _miObj.SistemaQA_desc = ((TextBox)fila.Controls[3]).Text;
            _miObj.SistemaQA_id = Int16.Parse(((Label)fila.Controls[1]).Text);

            bool obeRespuesta = _ALR_SistemaqaBL.ActualizarALR_Sistemaqa(_ALR_SistemaqaBE);
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

        protected void ibnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _Sistemaqa_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            bool obeRespuesta = _ALR_SistemaqaBL.EliminarALR_Sistemaqa(_Sistemaqa_id);
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
                var _miObj = _ALR_SistemaqaBE;
                Int16 _Departamento_id = Int16.Parse(ddlDepartamento.SelectedValue);
                _miObj.SistemaQA_desc = txtSistemaQA.Text;
                _miObj.Departamento_id = _Departamento_id;
                int vexito = _ALR_SistemaqaBL.InsertarALR_Sistemaqa(_ALR_SistemaqaBE);
                if (vexito != 0)
                {
                    GenerarTabla(_Departamento_id);
                    txtSistemaQA.Text = "";
                }
                else
                {
                    lblMensaje.Text="error, no se pudo registrar la Categoria";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "error, no se pudo registrar la Categoria" + ex.Message;
            }
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int16 _Departamento_id = Int16.Parse(ddlDepartamento.SelectedValue);
            GenerarTabla(_Departamento_id);
        }
    }
}