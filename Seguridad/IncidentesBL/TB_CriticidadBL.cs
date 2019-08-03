using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_CriticidadBL
    {
        TB_CriticidadADO _TB_CriticidadADO = new TB_CriticidadADO();

        public DataTable ListarTB_Criticidad_All()
        {
            return _TB_CriticidadADO.ListarTB_Criticidad_All();
        }
        public DataTable ListarTB_Criticidad_Act()
        {
            return _TB_CriticidadADO.ListarTB_Criticidad_Act();
        }
        public List<TB_CriticidadBE> ListarTB_CriticidadO_Act()
        {
            return _TB_CriticidadADO.ListarTB_CriticidadO_Act();
        }

        public bool ActualizarTB_Criticidad(TB_CriticidadBE _TB_CriticidadBE)
        {
            return _TB_CriticidadADO.ActualizarTB_Criticidad(_TB_CriticidadBE);
        }

        public bool EliminarTB_Criticidad(short _Criticidad_id)
        {
            return _TB_CriticidadADO.EliminarTB_Criticidad(_Criticidad_id);
        }

        public int InsertarTB_Criticidad(TB_CriticidadBE _TB_CriticidadBE)
        {
            return _TB_CriticidadADO.InsertarTB_Criticidad(_TB_CriticidadBE);
        }
    }
}
