using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_AreaLaborBL
    {
        TB_AreaLaborADO _TB_AreaLaborADO = new TB_AreaLaborADO();

        public DataTable ListarTB_AreaLabor_All()
        {
            return _TB_AreaLaborADO.ListarTB_AreaLabor_All();
        }
        public DataTable ListarTB_AreaLabor_Act()
        {
            return _TB_AreaLaborADO.ListarTB_AreaLabor_Act();
        }
        public List<TB_AreaLaborBE> ListarTB_AreaLaborO_Act()
        {
            return _TB_AreaLaborADO.ListarTB_AreaLaborO_Act();
        }
    }
}
