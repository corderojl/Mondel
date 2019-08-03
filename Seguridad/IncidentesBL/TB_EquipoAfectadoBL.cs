using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_EquipoAfectadoBL
    {
        TB_EquipoAfectadoADO _TB_EquipoAfectadoADO = new TB_EquipoAfectadoADO();

        public DataTable ListarTB_EquipoAfectado_All()
        {
            return _TB_EquipoAfectadoADO.ListarTB_EquipoAfectado_All();
        }
        public DataTable ListarTB_EquipoAfectado_Act()
        {
            return _TB_EquipoAfectadoADO.ListarTB_EquipoAfectado_Act();
        }
        public List<TB_EquipoAfectadoBE> ListarTB_EquipoAfectadoO_Act()
        {
            return _TB_EquipoAfectadoADO.ListarTB_EquipoAfectadoO_Act();
        }
    }
}
