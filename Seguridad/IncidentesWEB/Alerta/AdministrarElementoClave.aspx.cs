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
    public partial class AdministrarElementoClave : System.Web.UI.Page
    {
        ALR_ElementoClaveBL _ALR_ElementoClaveBL = new ALR_ElementoClaveBL();
        ALR_ElementoClaveBE _ALR_ElementoClaveBE = new ALR_ElementoClaveBE();
        List<ALR_ElementoClaveBE> lTALR_ElementoClaveBE;

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
        private void GenerarTabla(Int16 _CategoriaALR_ElementoClave_id)
        {

            lTALR_ElementoClaveBE = _ALR_ElementoClaveBL.ListarALR_ElementoClaveO_Act();
            rpEmpleado.DataSource = lTALR_ElementoClaveBE;
            rpEmpleado.DataBind();
        }

        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _ElementoClave_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            var _miObj = _ALR_ElementoClaveBE;
            //_miempl.Emp_id = "";
            _miObj.ElementoClave_desc = ((TextBox)fila.Controls[3]).Text;
            _miObj.ElementoClave_id = Int16.Parse(((Label)fila.Controls[1]).Text);

            bool obeRespuesta = _ALR_ElementoClaveBL.ActualizarALR_ElementoClave(_ALR_ElementoClaveBE);
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
            Int16 _ElementoClave_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            bool obeRespuesta = _ALR_ElementoClaveBL.EliminarALR_ElementoClave(_ElementoClave_id);
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
                var _miObj = _ALR_ElementoClaveBE;
                //_miempl.Emp_id = "";
                _miObj.ElementoClave_desc = txtElementoClave.Text;
                int vexito = _ALR_ElementoClaveBL.InsertarALR_ElementoClave(_ALR_ElementoClaveBE);
                if (vexito != 0)
                {
                    GenerarTabla(Convert.ToInt16(Request.QueryString["Categoria_id"]));
                    txtElementoClave.Text = "";
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