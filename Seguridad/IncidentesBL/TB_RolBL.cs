using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_RolBL
    {
        TB_RolADO _TB_RolADO = new TB_RolADO();

        public DataTable ListarTB_Rol_All()
        {
            return _TB_RolADO.ListarTB_Rol_All();
        }
        public DataTable ListarTB_Rol_Act()
        {
            return _TB_RolADO.ListarTB_Rol_Act();
        }
        public List<TB_RolBE> ListarTB_RolO_Act()
        {
            return _TB_RolADO.ListarTB_RolO_Act();
        }
    }
}
