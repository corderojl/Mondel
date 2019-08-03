using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_ContratistaBL
    {
        TB_ContratistaADO _TB_ContratistaADO = new TB_ContratistaADO();

        public DataTable ListarTB_Contratista_All()
        {
            return _TB_ContratistaADO.ListarTB_Contratista_All();
        }
        public DataTable ListarTB_Contratista_Act()
        {
            return _TB_ContratistaADO.ListarTB_Contratista_Act();
        }
        public List<TB_ContratistaBE> ListarTB_ContratistaO_Act()
        {
            return _TB_ContratistaADO.ListarTB_ContratistaO_Act();
        }
    }
}
