using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncidenteWEB.Indicadores
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Fnc_Funcionarios"] == null)
            {
                Response.Redirect("login_incidentes.aspx");
            }
        }
    }
}