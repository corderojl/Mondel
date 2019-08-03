using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_TecnologiaBL
    {
        TB_TecnologiaADO _TB_TecnologiaADO = new TB_TecnologiaADO();

        public DataTable ListarTB_Tecnologia_All()
        {
            return _TB_TecnologiaADO.ListarTB_Tecnologia_All();
        }
        public DataTable ListarTB_Tecnologia_Act()
        {
            return _TB_TecnologiaADO.ListarTB_Tecnologia_Act();
        }
        public List<TB_TecnologiaBE> ListarTB_TecnologiaO_Act()
        {
            return _TB_TecnologiaADO.ListarTB_TecnologiaO_Act();
        }
    }
}
