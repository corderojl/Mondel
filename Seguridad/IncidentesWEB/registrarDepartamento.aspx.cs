using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidentesWEB.Comportamiento
{
    public partial class registrarDepartamento : System.Web.UI.Page
    {
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_DepartamentoBE _TB_DepartamentoBE = new TB_DepartamentoBE();
        List<TB_DepartamentoBE> lTTB_DepartamentoBE;

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

            lTTB_DepartamentoBE = _TB_DepartamentoBL.ListarTB_DepartamentoO_Act("1");
            rpEmpleado.DataSource = lTTB_DepartamentoBE;
            rpEmpleado.DataBind();
        }

        protected void ibnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            Int16 _Departamento_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            var _miObj = _TB_DepartamentoBE;
            //_miempl.Emp_id = "";
            _miObj.Departamento_desc = ((TextBox)fila.Controls[3]).Text;
            _miObj.Sigla = ((TextBox)fila.Controls[5]).Text;
            _miObj.Departamento_id = _Departamento_id;
            bool obeRespuesta = _TB_DepartamentoBL.ActualizarTB_Departamento(_TB_DepartamentoBE);
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
            Int16 _Departamento_id = Int16.Parse(((Label)fila.Controls[1]).Text);
            bool obeRespuesta = _TB_DepartamentoBL.EliminarTB_Departamento(_Departamento_id);
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
                var _miObj = _TB_DepartamentoBE;
                //_miempl.Emp_id = "";
                _miObj.Departamento_desc = txtSubCategoria.Text;
                _miObj.Sigla=txtSsiglas.Text;
                

                int vexito = _TB_DepartamentoBL.InsertarTB_Departamento(_TB_DepartamentoBE);
                if (vexito != 0)
                {
                    GenerarTabla();
                    txtSubCategoria.Text = "";
                    txtSsiglas.Text="";
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
    }
}