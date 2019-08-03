using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class AUD_Auditoria_PreguntaBL
    {
        AUD_Auditoria_PreguntaADO _AUD_Auditoria_PreguntaADO = new AUD_Auditoria_PreguntaADO();

        public DataTable ListarAUD_Auditoria_Pregunta_All()
        {
            return _AUD_Auditoria_PreguntaADO.ListarAUD_Auditoria_Pregunta_All();
        }
        public DataTable ListarAUD_Auditoria_Pregunta_Act()
        {
            return _AUD_Auditoria_PreguntaADO.ListarAUD_Auditoria_Pregunta_Act();
        }
        public List<AUD_Auditoria_PreguntaBE> ListarAUD_Auditoria_PreguntaO_Act()
        {
            return _AUD_Auditoria_PreguntaADO.ListarAUD_Auditoria_PreguntaO_Act();
        }
        public int InsertarAUD_Auditoria_Pregunta(AUD_Auditoria_PreguntaBE _inseBE)
        {
            return _AUD_Auditoria_PreguntaADO.InsertarAUD_Auditoria_Pregunta(_inseBE);
        }
        public bool ActualizarAUD_Auditoria_Pregunta(AUD_Auditoria_PreguntaBE _inseBE)
        {
            return _AUD_Auditoria_PreguntaADO.ActualizarAUD_Auditoria_Pregunta(_inseBE);
        }
        public bool ActualizarAUD_Auditoria_PreguntaFin(AUD_Auditoria_PreguntaBE _inseBE)
        {
            return _AUD_Auditoria_PreguntaADO.ActualizarAUD_Auditoria_PreguntaFin(_inseBE);
        }
        public bool EliminarAUD_Auditoria_Pregunta(int vcod)
        {
            return _AUD_Auditoria_PreguntaADO.EliminarAUD_Auditoria_Pregunta(vcod);
        }
        public AUD_Auditoria_PreguntaBE TraerAUD_Auditoria_PreguntaById(int vcod)
        {
            return _AUD_Auditoria_PreguntaADO.TraerAUD_Auditoria_PreguntaById(vcod);
        }

        public DataTable BuscarAUD_Auditoria_PreguntaByAuditoria(int _Auditoria_id)
        {
            return _AUD_Auditoria_PreguntaADO.BuscarAUD_Auditoria_PreguntaByAuditoria(_Auditoria_id);
        }
    }
}
