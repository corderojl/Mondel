using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class AUD_PreguntaBL
    {
        AUD_PreguntaADO _AUD_PreguntaADO = new AUD_PreguntaADO();

        public DataTable ListarAUD_Pregunta_All()
        {
            return _AUD_PreguntaADO.ListarAUD_Pregunta_All();
        }
        public DataTable ListarAUD_Pregunta_Act()
        {
            return _AUD_PreguntaADO.ListarAUD_PreguntaAct();
        }
        public List<AUD_PreguntaBE> ListarAUD_PreguntaO_Act()
        {
            return _AUD_PreguntaADO.ListarAUD_PreguntaO_Act();
        }
        public List<AUD_PreguntaBE> ListarAUD_PreguntaByDepartamento(Int16 _Departamento_id)
        {
            return _AUD_PreguntaADO.ListarAUD_PreguntaByDepartamento(_Departamento_id);
        }

        public bool ActualizarAUD_Pregunta(AUD_PreguntaBE _AUD_PreguntaBE)
        {
            return _AUD_PreguntaADO.ActualizarAUD_Pregunta(_AUD_PreguntaBE);
        }

        public AUD_PreguntaBE TraerAUD_PreguntaById(short _Pregunta_id)
        {
            return _AUD_PreguntaADO.TraerAUD_PreguntaById(_Pregunta_id);
        }
        public DataTable ListarAUD_PreguntaByAuditoriaTipo(short _AuditoriaTipo_id)
        {
            return _AUD_PreguntaADO.ListarAUD_PreguntaByAuditoriaTipo(_AuditoriaTipo_id);
        }

        public bool EliminarAUD_Pregunta(short _Sistemaqa_id)
        {
            return _AUD_PreguntaADO.EliminarAUD_Pregunta(_Sistemaqa_id);
        }

        public int InsertarAUD_Pregunta(AUD_PreguntaBE _AUD_PreguntaBE)
        {
            return _AUD_PreguntaADO.InsertarAUD_Pregunta(_AUD_PreguntaBE);
        }

        public List<AUD_PreguntaBE> ListarAUD_PreguntaByAuditoriaTipoO(short _AuditoriaTipo_id)
        {
            return _AUD_PreguntaADO.ListarAUD_PreguntaByAuditoriaTipoO(_AuditoriaTipo_id);
        }
    }
}
