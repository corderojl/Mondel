using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_EstatusOperacionalBL
    {
        TB_EstatusOperacionalADO _TB_EstatusOperacionalADO = new TB_EstatusOperacionalADO();

        public DataTable ListarTB_EstatusOperacional_All()
        {
            return _TB_EstatusOperacionalADO.ListarTB_EstatusOperacional_All();
        }

        public DataTable ListarTB_EstatusOperacional_Act()
        {
            return _TB_EstatusOperacionalADO.ListarTB_EstatusOperacional_Act();
        }

        public List<TB_EstatusOperacionalBE> ListarTB_EstatusOperacionalO_Act()
        {
            return _TB_EstatusOperacionalADO.ListarTB_EstatusOperacionalO_Act();
        }

        public int InsertarTB_EstatusOperacional(TB_EstatusOperacionalBE _TB_EstatusOperacionalBE)
        {
            return _TB_EstatusOperacionalADO.InsertarTB_EstatusOperacional(_TB_EstatusOperacionalBE);
        }

        public bool ActualizarTB_EstatusOperacional(TB_EstatusOperacionalBE _TB_EstatusOperacionalBE)
        {
            return _TB_EstatusOperacionalADO.ActualizarTB_EstatusOperacional(_TB_EstatusOperacionalBE);
        }

        public bool EliminarTB_EstatusOperacional(short _EstatusOperacional_id)
        {
            return _TB_EstatusOperacionalADO.EliminarTB_EstatusOperacional(_EstatusOperacional_id);
        }
    }
}
