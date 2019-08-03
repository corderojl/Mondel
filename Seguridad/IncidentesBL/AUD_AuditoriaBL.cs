using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class AUD_AuditoriaBL
    {
        AUD_AuditoriaADO _AUD_AuditoriaADO = new AUD_AuditoriaADO();

        public DataTable ListarAUD_Auditoria_All()
        {
            return _AUD_AuditoriaADO.ListarAUD_Auditoria_All();
        }
        public DataTable ListarAUD_Auditoria_Act()
        {
            return _AUD_AuditoriaADO.ListarAUD_Auditoria_Act();
        }
        public List<AUD_AuditoriaBE> ListarAUD_AuditoriaO_Act()
        {
            return _AUD_AuditoriaADO.ListarAUD_AuditoriaO_Act();
        }
        public int InsertarAUD_Auditoria(AUD_AuditoriaBE _inseBE)
        {
            return _AUD_AuditoriaADO.InsertarAUD_Auditoria(_inseBE);
        }
        public bool ActualizarAUD_Auditoria(AUD_AuditoriaBE _inseBE)
        {
            return _AUD_AuditoriaADO.ActualizarAUD_Auditoria(_inseBE);
        }
        public bool EliminarAUD_Auditoria(int vcod)
        {
            return _AUD_AuditoriaADO.EliminarAUD_Auditoria(vcod);
        }
        public AUD_AuditoriaBE TraerAUD_AuditoriaById(int vcod)
        {
            return _AUD_AuditoriaADO.TraerAUD_AuditoriaById(vcod);
        }
        public DataTable TraerAUD_AuditoriaSemaforo(short vcod)
        {
            return _AUD_AuditoriaADO.TraerAUD_AuditoriaSemaforo(vcod);
        }
        public DataTable ListarAUD_AuditoriaFind(string _Departamento_id, string _Guardia_id, string _Area_id, string _Auditoria_id, string _Operador, string _Originador, DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            return _AUD_AuditoriaADO.ListarAUD_AuditoriaFind(_Departamento_id, _Guardia_id, _Area_id, _Auditoria_id, _Operador, _Originador, _Fecha_incidente, _Fecha_incidente1);
        }
        public int TraerAUD_AuditoriaUltimo(short _Departamento_id)
        {
            return _AUD_AuditoriaADO.TraerAUD_AuditoriaUltimo(_Departamento_id);
        }

        public bool FirmarAUD_Auditoria(int _Auditoria_id, DateTime Hoy)
        {
            return _AUD_AuditoriaADO.FirmarAUD_Auditoria(_Auditoria_id, Hoy);
        }
    }
}
