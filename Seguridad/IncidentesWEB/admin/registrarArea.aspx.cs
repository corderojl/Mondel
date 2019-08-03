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
    public partial class registrarArea : System.Web.UI.Page
    {
        TB_AreaBL _TB_AreaBL = new TB_AreaBL();
        TB_AreaBE _TB_AreaBE = new TB_AreaBE();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        List<TB_AreaBE> lTTB_AreaBE;
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
            lTTB_AreaBE = _TB_AreaBL.ListarTB_AreaByDepartamento(_Departamento_id);
            rpArea.DataSource = lTTB_AreaBE;
            rpArea.DataBind();
        }

        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _Area_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            var _miObj = _TB_AreaBE;
            //_miempl.Emp_id = "";
            _miObj.Area_desc = ((TextBox)fila.Controls[3]).Text;
            _miObj.Departamento_id = short.Parse(ddlDepartamento.SelectedValue);
            _miObj.Area_id = Int16.Parse(((Label)fila.Controls[1]).Text);

            bool obeRespuesta = _TB_AreaBL.ActualizarTB_Area(_TB_AreaBE);
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
            bool obeRespuesta = _TB_AreaBL.EliminarTB_Area(_Area_id);
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
                var _miObj = _TB_AreaBE;
                Int16 _Departamento_id = Int16.Parse(ddlDepartamento.SelectedValue);
                _miObj.Area_desc = txtArea.Text;
                _miObj.Departamento_id = _Departamento_id;
                int vexito = _TB_AreaBL.InsertarTB_Area(_TB_AreaBE);
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
