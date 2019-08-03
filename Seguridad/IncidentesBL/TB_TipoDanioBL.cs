using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_TipoDanioBL
    {
        TB_TipoDanioADO _TB_TipoDanioADO = new TB_TipoDanioADO();

        public DataTable ListarTB_TipoDanio_All()
        {
            return _TB_TipoDanioADO.ListarTB_TipoDanio_All();
        }
        public DataTable ListarTB_TipoDanio_Act()
        {
            return _TB_TipoDanioADO.ListarTB_TipoDanio_Act();
        }
        public List<TB_TipoDanioBE> ListarTB_TipoDanioO_Act()
        {
            return _TB_TipoDanioADO.ListarTB_TipoDanioO_Act();
        }

        public bool ActualizarTB_TipoDanio(TB_TipoDanioBE _TB_TipoDanioBE)
        {
            return _TB_TipoDanioADO.ActualizarTB_TipoDanio(_TB_TipoDanioBE);
        }

        public bool EliminarTB_TipoDanio(short _TipoDanio_id)
        {
            return _TB_TipoDanioADO.EliminarTB_TipoDanio(_TipoDanio_id);
        }

        public int InsertarTB_TipoDanio(TB_TipoDanioBE _TB_TipoDanioBE)
        {
            return _TB_TipoDanioADO.InsertarTB_TipoDanio(_TB_TipoDanioBE);
        }
    }
}
