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
    public partial class registrarRiesgoInvolucrado : System.Web.UI.Page
    {
        TB_RiesgoInvolucradoBL _TB_RiesgoInvolucradoBL = new TB_RiesgoInvolucradoBL();
        TB_RiesgoInvolucradoBE _TB_RiesgoInvolucradoBE = new TB_RiesgoInvolucradoBE();
        List<TB_RiesgoInvolucradoBE> lTTB_RiesgoInvolucradoBE;

        protected void Page_Load(object sender, EventArgs e)
        {
            Int16 _Categoria_id = Convert.ToInt16(Request.QueryString["Categoria_id"]);
            if (this.IsPostBack)
            {
                lblMensaje.Text = "";
            }
            else
            {
                GenerarTabla(_Categoria_id);
                lblMensaje.Text = "";
            }
        }
        private void GenerarTabla(Int16 _CategoriaTB_RiesgoInvolucrado_id)
        {

            lTTB_RiesgoInvolucradoBE = _TB_RiesgoInvolucradoBL.ListarTB_RiesgoInvolucradoO_Act();
            rpEmpleado.DataSource = lTTB_RiesgoInvolucradoBE;
            rpEmpleado.DataBind();
        }

        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _RiesgoInvolucrado_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            var _miObj = _TB_RiesgoInvolucradoBE;
            //_miempl.Emp_id = "";
            _miObj.Riesgo_inv_desc = ((TextBox)fila.Controls[3]).Text;
            _miObj.Riesgo_inv_id = Int16.Parse(((Label)fila.Controls[1]).Text);

            bool obeRespuesta = _TB_RiesgoInvolucradoBL.ActualizarTB_RiesgoInvolucrado(_TB_RiesgoInvolucradoBE);
            if (!obeRespuesta)
            {
                String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo eliminar el registro')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
            else
            {
            }
            GenerarTabla(Convert.ToInt16(Request.QueryString["Categoria_id"]));
        }

        protected void ibnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _RiesgoInvolucrado_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            bool obeRespuesta = _TB_RiesgoInvolucradoBL.EliminarTB_RiesgoInvolucrado(_RiesgoInvolucrado_id);
            if (!obeRespuesta)
            {
                String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo eliminar el registro')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
            else
            {
            }
            GenerarTabla(Convert.ToInt16(Request.QueryString["Categoria_id"]));
        }

        protected void ibnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int status;
                var _miObj = _TB_RiesgoInvolucradoBE;
                //_miempl.Emp_id = "";
                _miObj.Riesgo_inv_desc = txtRiesgoInvolucrado.Text;
                int vexito = _TB_RiesgoInvolucradoBL.InsertarTB_RiesgoInvolucrado(_TB_RiesgoInvolucradoBE);
                if (vexito != 0)
                {
                    GenerarTabla(Convert.ToInt16(Request.QueryString["Categoria_id"]));
                    txtRiesgoInvolucrado.Text = "";
                }
                else
                {
                    lblMensaje.Text = "error, no se pudo registrar la Categoria";
                }


            }
            catch (Exception ex)
            {
                lblMensaje.Text = "error, no se pudo registrar la Categoria" + ex.Message;
            }
        }
    }
}