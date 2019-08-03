using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.LUPs
{
    public partial class registrarPilar : System.Web.UI.Page
    {
        TB_PilarBL _TB_PilarBL = new TB_PilarBL();
        TB_PilarBE _TB_PilarBE = new TB_PilarBE();
        List<TB_PilarBE> lTTB_PilarBE;

        protected void Page_Load(object sender, EventArgs e)
        {
            Int16 _Pilar_id = Convert.ToInt16(Request.QueryString["Pilar_id"]);
            if (this.IsPostBack)
            {
                lblMensaje.Text = "";
            }
            else
            {
                GenerarTabla(_Pilar_id);
                lblMensaje.Text = "";
            }
        }
        private void GenerarTabla(Int16 _PilarTB_Pilar_id)
        {

            lTTB_PilarBE = _TB_PilarBL.ListarTB_Pilar_Act();
            rpEmpleado.DataSource = lTTB_PilarBE;
            rpEmpleado.DataBind();
        }

        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _Pilar_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            var _miObj = _TB_PilarBE;
            //_miempl.Emp_id = "";
            _miObj.Pilar_desc = ((TextBox)fila.Controls[3]).Text;
            _miObj.Pilar_id = Int16.Parse(((Label)fila.Controls[1]).Text);

            bool obeRespuesta = _TB_PilarBL.ActualizarTB_Pilar(_TB_PilarBE);
            if (!obeRespuesta)
            {
                String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo eliminar el registro')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
            else
            {
            }
            GenerarTabla(Convert.ToInt16(Request.QueryString["Pilar_id"]));
        }

        protected void ibnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _Pilar_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            bool obeRespuesta = _TB_PilarBL.EliminarTB_Pilar(_Pilar_id);
            if (!obeRespuesta)
            {
                String mensaje = "<script language='JavaScript'>window.alert('error, no se pudo eliminar el registro')";
                mensaje += Environment.NewLine;
                this.Page.Response.Write(mensaje);
            }
            else
            {
            }
            GenerarTabla(Convert.ToInt16(Request.QueryString["Pilar_id"]));
        }

        protected void ibnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int status;
                var _miObj = _TB_PilarBE;
                //_miempl.Emp_id = "";
                _miObj.Pilar_desc = txtPilar.Text;
                int vexito = _TB_PilarBL.InsertarTB_Pilar(_TB_PilarBE);
                if (vexito != 0)
                {
                    GenerarTabla(Convert.ToInt16(Request.QueryString["Pilar_id"]));
                    txtPilar.Text = "";
                }
                else
                {
                    lblMensaje.Text = "error, no se pudo registrar la Pilar";
                }


            }
            catch (Exception ex)
            {
                lblMensaje.Text = "error, no se pudo registrar la Pilar" + ex.Message;
            }
        }
    }
}