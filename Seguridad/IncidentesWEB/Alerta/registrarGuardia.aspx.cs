using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.admin
{
    public partial class registrarGuardia : System.Web.UI.Page
    {
        TB_GuardiaBL _TB_GuardiaBL = new TB_GuardiaBL();
        TB_GuardiaBE _TB_GuardiaBE = new TB_GuardiaBE();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        List<TB_GuardiaBE> lTTB_GuardiaBE;
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
                txtArea.Visible = false;
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
                txtArea.Visible = true;
            }
            else
            {
                ibnGuardar.Visible = false;
                txtArea.Visible = false;
            }
            lTTB_GuardiaBE = _TB_GuardiaBL.ListarTB_GuardiaByDepartamento(_Departamento_id);
            rpArea.DataSource = lTTB_GuardiaBE;
            rpArea.DataBind();
        }

        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _Area_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            var _miObj = _TB_GuardiaBE;
            //_miempl.Emp_id = "";
            _miObj.Guardia_desc = ((TextBox)fila.Controls[3]).Text;
            _miObj.Departamento_id = short.Parse(ddlDepartamento.SelectedValue);
            _miObj.Guardia_id = Int16.Parse(((Label)fila.Controls[1]).Text);

            bool obeRespuesta = _TB_GuardiaBL.ActualizarTB_Guardia(_TB_GuardiaBE);
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
            Int16 _Area_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            bool obeRespuesta = _TB_GuardiaBL.EliminarTB_Guardia(_Area_id);
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
                var _miObj = _TB_GuardiaBE;
                Int16 _Departamento_id = Int16.Parse(ddlDepartamento.SelectedValue);
                _miObj.Guardia_desc = txtArea.Text;
                _miObj.Departamento_id = _Departamento_id;
                int vexito = _TB_GuardiaBL.InsertarTB_Guardia(_TB_GuardiaBE);
                if (vexito != 0)
                {
                    GenerarTabla(_Departamento_id);
                    txtArea.Text = "";
                }
                else
                {
                    lblMensaje.Text = "error, no se pudo registrar contacte con el administrador";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "error,  no se pudo registrar contacte con el administrador" + ex.Message;
            }
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int16 _Departamento_id = Int16.Parse(ddlDepartamento.SelectedValue);
            GenerarTabla(_Departamento_id);
        }
    }
}
