using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class AUD_QuienAuditarBL
    {
        AUD_QuienAuditarADO _AUD_QuienAuditarADO = new AUD_QuienAuditarADO();

        public DataTable ListarAUD_QuienAuditar_All()
        {
            return _AUD_QuienAuditarADO.ListarAUD_QuienAuditar_All();
        }
        public DataTable ListarAUD_QuienAuditar_Act()
        {
            return _AUD_QuienAuditarADO.ListarAUD_QuienAuditar_Act();
        }
        public List<AUD_QuienAuditarBE> ListarAUD_QuienAuditarO_Act()
        {
            return _AUD_QuienAuditarADO.ListarAUD_QuienAuditarO_Act();
        }
    }
}
