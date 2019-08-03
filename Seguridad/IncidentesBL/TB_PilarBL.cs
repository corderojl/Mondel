using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_PilarBL
    {
        TB_PilarADO _TB_PilarADO = new TB_PilarADO();

        public List<TB_PilarBE> ListarTB_Pilar_Act()
        {
            return _TB_PilarADO.ListarTB_PilarO_Act();
        }

        public bool ActualizarTB_Pilar(TB_PilarBE _TB_PilarBE)
        {
            return _TB_PilarADO.ActualizarTB_Pilar(_TB_PilarBE);
        }

        public bool EliminarTB_Pilar(short _Pilar_id)
        {
            return _TB_PilarADO.EliminarTB_Pilar(_Pilar_id);
        }

        public int InsertarTB_Pilar(TB_PilarBE _TB_PilarBE)
        {
            return _TB_PilarADO.InsertarTB_Pilar(_TB_PilarBE);
        }
    }
}
