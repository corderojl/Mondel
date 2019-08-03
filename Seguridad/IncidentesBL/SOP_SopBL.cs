using IncidentesADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class SOP_SopBL
    {
        SOP_SopADO _SOP_SopADO = new SOP_SopADO();
        public DataTable ListarSOP_SopDuenoCaducado()
        {
            return _SOP_SopADO.sp_ListarSOP_DuenoCaducado();
        }
    }
}
