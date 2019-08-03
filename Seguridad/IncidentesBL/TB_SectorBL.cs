using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_SectorBL
    {
        TB_SectorADO _TB_SectorADO = new TB_SectorADO();

        public List<TB_SectorBE> ListarTB_Sector_All(string Sistema_id)
        {
            return _TB_SectorADO.ListarTB_Sector_All(Sistema_id);
        }
        public System.Data.DataTable ListarTB_Sector_Act()
        {
            return _TB_SectorADO.ListarTB_Sector_Act();
        }
        public List<TB_SectorBE> ListarTB_SectorO_Act()
        {
            return _TB_SectorADO.ListarTB_SectorO_Act();
        }

        public List<TB_SectorBE> ListarTB_SectorSuperiorO_Act(short _Superior)
        {
            return _TB_SectorADO.ListarTB_SectorSuperiorO_Act(_Superior);
        }

        public bool ActualizarTB_Sector(TB_SectorBE _TB_SectorBE)
        {
            return _TB_SectorADO.ActualizarTB_Sector(_TB_SectorBE);
        }

        public bool EliminarTB_Sector(short _Sector_id)
        {
            return _TB_SectorADO.EliminarTB_Sector(_Sector_id);
        }

        public int InsertarTB_Sector(TB_SectorBE _TB_SectorBE)
        {
            return _TB_SectorADO.InsertarTB_Sector(_TB_SectorBE);
        }
    }
}
