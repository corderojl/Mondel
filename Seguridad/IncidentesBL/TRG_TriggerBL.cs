using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TRG_TriggerBL
    {
        TRG_TriggerADO _TRG_TriggerADO = new TRG_TriggerADO();

        public DataTable ListarTRG_Trigger_All()
        {
            return _TRG_TriggerADO.ListarTRG_Trigger_All();
        }
        public DataTable ListarTRG_Trigger_Act()
        {
            return _TRG_TriggerADO.ListarTRG_Trigger_Act();
        }
        public List<TRG_TriggerBE> ListarTRG_TriggerO_Act()
        {
            return _TRG_TriggerADO.ListarTRG_TriggerO_Act();
        }
        public int InsertarTRG_Trigger(TRG_TriggerBE _inseBE)
        {
            return _TRG_TriggerADO.InsertarTRG_Trigger(_inseBE);
        }
        public bool ActualizarTRG_Trigger(TRG_TriggerBE _inseBE)
        {
            return _TRG_TriggerADO.ActualizarTRG_Trigger(_inseBE);
        }
        public bool EliminarTRG_Trigger(int vcod)
        {
            return _TRG_TriggerADO.EliminarTRG_Trigger(vcod);
        }
        public TRG_TriggerBE TraerTRG_TriggerById(int vcod)
        {
            return _TRG_TriggerADO.TraerTRG_TriggerById(vcod);
        }
        public DataTable TraerTRG_TriggerSemaforo(short vcod)
        {
            return _TRG_TriggerADO.TraerTRG_TriggerSemaforo(vcod);
        }
        public DataTable ListarTRG_TriggerFind(string _Departamento_id, string _Guardia_id, DateTime _Fecha_incidente, DateTime _Fecha_incidente1)
        {
            return _TRG_TriggerADO.ListarTRG_TriggerFind(_Departamento_id, _Guardia_id, _Fecha_incidente, _Fecha_incidente1);
        }
        public int TraerTRG_TriggerUltimo(short _Departamento_id)
        {
            return _TRG_TriggerADO.TraerTRG_TriggerUltimo(_Departamento_id);
        }
    }
}
