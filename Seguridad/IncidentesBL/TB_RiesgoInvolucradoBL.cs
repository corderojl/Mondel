using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_RiesgoInvolucradoBL
    {
        TB_RiesgoInvolucradoADO _TB_RiesgoInvolucradoADO = new TB_RiesgoInvolucradoADO();

        public DataTable ListarTB_RiesgoInvolucrado_All()
        {
            return _TB_RiesgoInvolucradoADO.ListarTB_RiesgoInvolucrado_All();
        }
        public DataTable ListarTB_RiesgoInvolucrado_Act()
        {
            return _TB_RiesgoInvolucradoADO.ListarTB_RiesgoInvolucrado_Act();
        }
        public List<TB_RiesgoInvolucradoBE> ListarTB_RiesgoInvolucradoO_Act()
        {
            return _TB_RiesgoInvolucradoADO.ListarTB_RiesgoInvolucradoO_Act();
        }
        public bool ActualizarTB_RiesgoInvolucrado(TB_RiesgoInvolucradoBE _TB_RiesgoInvolucradoBE)
        {
            return _TB_RiesgoInvolucradoADO.ActualizarTB_RiesgoInvolucrado(_TB_RiesgoInvolucradoBE);
        }

        public bool EliminarTB_RiesgoInvolucrado(short _RiesgoInvolucrado_id)
        {
            return _TB_RiesgoInvolucradoADO.EliminarTB_RiesgoInvolucrado(_RiesgoInvolucrado_id);
        }

        public int InsertarTB_RiesgoInvolucrado(TB_RiesgoInvolucradoBE _TB_RiesgoInvolucradoBE)
        {
            return _TB_RiesgoInvolucradoADO.InsertarTB_RiesgoInvolucrado(_TB_RiesgoInvolucradoBE);
        }
    }
}
