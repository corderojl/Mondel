using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class ALR_ElementoClaveBL
    {
        ALR_ElementoClaveADO _ALR_ElementoClaveADO = new ALR_ElementoClaveADO();

        public DataTable ListarALR_ElementoClave_All()
        {
            return _ALR_ElementoClaveADO.ListarALR_ElementoClave_All();
        }
        public DataTable ListarALR_ElementoClave_Act()
        {
            return _ALR_ElementoClaveADO.ListarALR_ElementoClave_Act();
        }
        public List<ALR_ElementoClaveBE> ListarALR_ElementoClaveO_Act()
        {
            return _ALR_ElementoClaveADO.ListarALR_ElementoClaveO_Act();
        }
        public int InsertarALR_ElementoClave(ALR_ElementoClaveBE _ALR_ElementoClaveBE)
        {
            return _ALR_ElementoClaveADO.InsertarALR_ElementoClave(_ALR_ElementoClaveBE);
        }
        public bool EliminarALR_ElementoClave(short _ElementoClave_id)
        {
            return _ALR_ElementoClaveADO.EliminarALR_ElementoClave(_ElementoClave_id);
        }
        public bool ActualizarALR_ElementoClave(ALR_ElementoClaveBE _ALR_ElementoClaveBE)
        {
            return _ALR_ElementoClaveADO.ActualizarALR_ElementoClave(_ALR_ElementoClaveBE);
        }
    }
}
