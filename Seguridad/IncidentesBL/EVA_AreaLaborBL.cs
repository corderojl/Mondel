using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class EVA_AreaLaborBL
    {
        EVA_AreaLaborADO _EVA_AreaLaborADO = new EVA_AreaLaborADO();

        public DataTable ListarEVA_AreaLabor_All()
        {
            return _EVA_AreaLaborADO.ListarEVA_AreaLabor_All();
        }
        public DataTable ListarEVA_AreaLabor_Act()
        {
            return _EVA_AreaLaborADO.ListarEVA_AreaLabor_Act();
        }
        public List<EVA_AreaLaborBE> ListarEVA_AreaLaborO_Act()
        {
            return _EVA_AreaLaborADO.ListarEVA_AreaLaborO_Act();
        }
        public bool ActualizarEVA_AreaLabor(EVA_AreaLaborBE _EVA_AreaLaborBE)
        {
            return _EVA_AreaLaborADO.ActualizarEVA_AreaLabor(_EVA_AreaLaborBE);
        }

        public EVA_AreaLaborBE TraerEVA_AreaLaborById(int _AreaLabor_id)
        {
            return _EVA_AreaLaborADO.TraerEVA_AreaLaborById(_AreaLabor_id);
        }
    }
}
