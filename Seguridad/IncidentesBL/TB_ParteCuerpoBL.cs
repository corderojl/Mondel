using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_ParteCuerpoBL
    {
        TB_ParteCuerpoADO _TB_ParteCuerpoADO = new TB_ParteCuerpoADO();

        public DataTable ListarTB_ParteCuerpo_All()
        {
            return _TB_ParteCuerpoADO.ListarTB_ParteCuerpo_All();
        }
        public DataTable ListarTB_ParteCuerpo_Act()
        {
            return _TB_ParteCuerpoADO.ListarTB_ParteCuerpo_Act();
        }
        public List<TB_ParteCuerpoBE> ListarTB_ParteCuerpoO_Act()
        {
            return _TB_ParteCuerpoADO.ListarTB_ParteCuerpoO_Act();
        }

        public List<TB_ParteCuerpoBE> ListarTB_ParteCuerpoByTipoIncidente(short _TipoIncidente_id)
        {
            return _TB_ParteCuerpoADO.ListarTB_ParteCuerpoByTipoIncidente(_TipoIncidente_id);
        }

        public bool ActualizarTB_ParteCuerpo(TB_ParteCuerpoBE _TB_ParteCuerpoBE)
        {
            return _TB_ParteCuerpoADO.ActualizarTB_ParteCuerpo(_TB_ParteCuerpoBE);
        }

        public bool EliminarTB_ParteCuerpo(short _ParteCuerpo_id)
        {
            return _TB_ParteCuerpoADO.EliminarTB_ParteCuerpo(_ParteCuerpo_id);
        }

        public int InsertarTB_ParteCuerpo(TB_ParteCuerpoBE _TB_ParteCuerpoBE)
        {
            return _TB_ParteCuerpoADO.InsertarTB_ParteCuerpo(_TB_ParteCuerpoBE);
        }
    }
}
