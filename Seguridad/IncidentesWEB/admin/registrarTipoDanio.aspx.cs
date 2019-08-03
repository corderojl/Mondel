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
    public partial class registrarTipoDanio : System.Web.UI.Page
    {
        TB_TipoDanioBL _TB_TipoDanioBL = new TB_TipoDanioBL();
        TB_TipoDanioBE _TB_TipoDanioBE = new TB_TipoDanioBE();
        List<TB_TipoDanioBE> lTTB_TipoDanioBE;

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (this.IsPostBack)
            {
                lblMensaje.Text = "";
            }
            else
            {
                GenerarTabla();
                lblMensaje.Text = "";
            }
        }
        private void GenerarTabla()
        {

            lTTB_TipoDanioBE = _TB_TipoDanioBL.ListarTB_TipoDanioO_Act();
            rpEmpleado.DataSource = lTTB_TipoDanioBE;
            rpEmpleado.DataBind();
        }

        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _TipoDanio_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            var _miObj = _TB_TipoDanioBE;
            //_miempl.Emp_id = "";
            _miObj.TipoDanio_desc = ((TextBox)fila.Controls[3]).Text;
            _miObj.TipoDanio_id = Int16.Parse(((Label)fila.Controls[1]).Text);

            bool obeRespuesta = _TB_TipoDanioBL.ActualizarTB_TipoDanio(_TB_TipoDanioBE);
            if (!obeRespuesta)
            {
                String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo eliminar el registro')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
            else
            {
            }
            GenerarTabla();
        }

        protected void ibnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _TipoDanio_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            bool obeRespuesta = _TB_TipoDanioBL.EliminarTB_TipoDanio(_TipoDanio_id);
            if (!obeRespuesta)
            {
                String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo eliminar el registro')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
            else
            {
            }
            GenerarTabla();
        }

        protected void ibnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int status;
                var _miObj = _TB_TipoDanioBE;
                //_miempl.Emp_id = "";
                _miObj.TipoDanio_desc = txtTipoDanio.Text;
                int vexito = _TB_TipoDanioBL.InsertarTB_TipoDanio(_TB_TipoDanioBE);
                if (vexito != 0)
                {
                    GenerarTabla();
                    txtTipoDanio.Text = "";
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