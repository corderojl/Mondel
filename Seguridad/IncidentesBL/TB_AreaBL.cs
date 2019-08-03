using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_AreaBL
    {
        TB_AreaADO _TB_AreaADO = new TB_AreaADO();

        public DataTable ListarTB_Area_All()
        {
            return _TB_AreaADO.ListarTB_Area_All();
        }
        public DataTable ListarTB_Area_Act()
        {
            return _TB_AreaADO.ListarTB_Area_Act();
        }
        public List<TB_AreaBE> ListarTB_AreaO_Act()
        {
            return _TB_AreaADO.ListarTB_AreaO_Act();
        }

        public List<TB_AreaBE> ListarTB_AreaByDepartamento(short _Departamento_id)
        {
            return _TB_AreaADO.ListarTB_AreaByDepartamento(_Departamento_id);
        }

        public bool ActualizarTB_Area(TB_AreaBE _TB_AreaBE)
        {
            return _TB_AreaADO.ActualizarTB_Area(_TB_AreaBE);
        }

        public bool EliminarTB_Area(short _Area_id)
        {
            return _TB_AreaADO.EliminarTB_Area(_Area_id);
        }

        public int InsertarTB_Area(TB_AreaBE _TB_AreaBE)
        {
            return _TB_AreaADO.InsertarTB_Area(_TB_AreaBE);
        }
    }
}
