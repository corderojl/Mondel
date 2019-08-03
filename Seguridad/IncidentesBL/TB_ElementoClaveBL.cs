using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_ElementoClaveBL
    {
        TB_ElementoClaveADO _TB_ElementoClaveADO = new TB_ElementoClaveADO();

        public DataTable ListarTB_ElementoClave_All()
        {
            return _TB_ElementoClaveADO.ListarTB_ElementoClave_All();
        }
        public DataTable ListarTB_ElementoClave_Act()
        {
            return _TB_ElementoClaveADO.ListarTB_ElementoClave_Act();
        }
        public List<TB_ElementoClaveBE> ListarTB_ElementoClaveO_Act()
        {
            return _TB_ElementoClaveADO.ListarTB_ElementoClaveO_Act();
        }
    }
}
