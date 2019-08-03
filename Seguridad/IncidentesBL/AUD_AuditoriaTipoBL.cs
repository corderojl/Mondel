using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class AUD_AuditoriaTipoBL
    {
        AUD_AuditoriaTipoADO _AUD_AuditoriaTipoADO = new AUD_AuditoriaTipoADO();

        public DataTable ListarAUD_AuditoriaTipo_All()
        {
            return _AUD_AuditoriaTipoADO.ListarAUD_AuditoriaTipo_All();
        }
        public DataTable ListarAUD_AuditoriaTipo_Act()
        {
            return _AUD_AuditoriaTipoADO.ListarAUD_AuditoriaTipoAct();
        }
        public List<AUD_AuditoriaTipoBE> ListarAUD_AuditoriaTipoO_Act()
        {
            return _AUD_AuditoriaTipoADO.ListarAUD_AuditoriaTipoO_Act();
        }
        public List<AUD_AuditoriaTipoBE> ListarAUD_AuditoriaTipoByDepartamento(Int16 _Departamento_id)
        {
            return _AUD_AuditoriaTipoADO.ListarAUD_AuditoriaTipoByDepartamento(_Departamento_id);
        }

        public bool ActualizarAUD_AuditoriaTipo(AUD_AuditoriaTipoBE _AUD_AuditoriaTipoBE)
        {
            return _AUD_AuditoriaTipoADO.ActualizarAUD_AuditoriaTipo(_AUD_AuditoriaTipoBE);
        }

        public AUD_AuditoriaTipoBE TraerAUD_AuditoriaTipoById(short _AuditoriaTipo_id)
        {
            return _AUD_AuditoriaTipoADO.TraerAUD_AuditoriaTipoById(_AuditoriaTipo_id);
        }
    }
}
