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
    public partial class registrarCriticidad : System.Web.UI.Page
    {
        TB_CriticidadBL _TB_CriticidadBL = new TB_CriticidadBL();
        TB_CriticidadBE _TB_CriticidadBE = new TB_CriticidadBE();
        List<TB_CriticidadBE> lTTB_CriticidadBE;

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

            lTTB_CriticidadBE = _TB_CriticidadBL.ListarTB_CriticidadO_Act();
            rpEmpleado.DataSource = lTTB_CriticidadBE;
            rpEmpleado.DataBind();
        }

        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _Criticidad_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            var _miObj = _TB_CriticidadBE;
            //_miempl.Emp_id = "";
            _miObj.Criticidad_desc = ((TextBox)fila.Controls[3]).Text;
            _miObj.Criticidad_id = Int16.Parse(((Label)fila.Controls[1]).Text);

            bool obeRespuesta = _TB_CriticidadBL.ActualizarTB_Criticidad(_TB_CriticidadBE);
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
            Int16 _Criticidad_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            bool obeRespuesta = _TB_CriticidadBL.EliminarTB_Criticidad(_Criticidad_id);
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
                var _miObj = _TB_CriticidadBE;
                //_miempl.Emp_id = "";
                _miObj.Criticidad_desc = txtCriticidad.Text;
                int vexito = _TB_CriticidadBL.InsertarTB_Criticidad(_TB_CriticidadBE);
                if (vexito != 0)
                {
                    GenerarTabla();
                    txtCriticidad.Text = "";
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