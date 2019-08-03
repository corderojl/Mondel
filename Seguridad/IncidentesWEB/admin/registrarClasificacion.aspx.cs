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
    public partial class registrarClasificacion : System.Web.UI.Page
    {
        TB_ClasificacionBL _TB_ClasificacionBL = new TB_ClasificacionBL();
        TB_ClasificacionBE _TB_ClasificacionBE = new TB_ClasificacionBE();
        List<TB_ClasificacionBE> lTTB_ClasificacionBE;

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
        private void GenerarTabla(Int16 _CategoriaTB_Clasificacion_id)
        {

            lTTB_ClasificacionBE = _TB_ClasificacionBL.ListarTB_ClasificacionO_Act();
            rpEmpleado.DataSource = lTTB_ClasificacionBE;
            rpEmpleado.DataBind();
        }

        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _Clasificacion_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            var _miObj = _TB_ClasificacionBE;
            //_miempl.Emp_id = "";
            _miObj.Clasificacion_desc = ((TextBox)fila.Controls[3]).Text;
            _miObj.Clasificacion_id = Int16.Parse(((Label)fila.Controls[1]).Text);

            bool obeRespuesta = _TB_ClasificacionBL.ActualizarTB_Clasificacion(_TB_ClasificacionBE);
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
            Int16 _Clasificacion_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            bool obeRespuesta = _TB_ClasificacionBL.EliminarTB_Clasificacion(_Clasificacion_id);
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
                var _miObj = _TB_ClasificacionBE;
                //_miempl.Emp_id = "";
                _miObj.Clasificacion_desc = txtClasificacion.Text;
                int vexito = _TB_ClasificacionBL.InsertarTB_Clasificacion(_TB_ClasificacionBE);
                if (vexito != 0)
                {
                    GenerarTabla(Convert.ToInt16(Request.QueryString["Categoria_id"]));
                    txtClasificacion.Text = "";
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