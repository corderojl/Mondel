using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TRG_Trigger_RiesgosBL
    {
        TRG_Trigger_RiesgosADO _TRG_Trigger_RiesgosADO = new TRG_Trigger_RiesgosADO();

        public DataTable ListarTRG_Trigger_Riesgos_All()
        {
            return _TRG_Trigger_RiesgosADO.ListarTRG_Trigger_Riesgos_All();
        }
        public DataTable ListarTRG_Trigger_Riesgos_Act()
        {
            return _TRG_Trigger_RiesgosADO.ListarTRG_Trigger_Riesgos_Act();
        }
        public List<TRG_Trigger_RiesgosBE> ListarTRG_Trigger_RiesgosO_Act()
        {
            return _TRG_Trigger_RiesgosADO.ListarTRG_Trigger_RiesgosO_Act();
        }
        public int InsertarTRG_Trigger_Riesgos(TRG_Trigger_RiesgosBE _inseBE)
        {
            return _TRG_Trigger_RiesgosADO.InsertarTRG_Trigger_Riesgos(_inseBE);
        }
        public bool ActualizarTRG_Trigger_Riesgos(TRG_Trigger_RiesgosBE _inseBE)
        {
            return _TRG_Trigger_RiesgosADO.ActualizarTRG_Trigger_Riesgos(_inseBE);
        }
        public bool ActualizarTRG_Trigger_RiesgosFin(TRG_Trigger_RiesgosBE _inseBE)
        {
            return _TRG_Trigger_RiesgosADO.ActualizarTRG_Trigger_RiesgosFin(_inseBE);
        }
        public bool EliminarTRG_Trigger_Riesgos(int vcod)
        {
            return _TRG_Trigger_RiesgosADO.EliminarTRG_Trigger_Riesgos(vcod);
        }
        public TRG_Trigger_RiesgosBE TraerTRG_Trigger_RiesgosById(int vcod)
        {
            return _TRG_Trigger_RiesgosADO.TraerTRG_Trigger_RiesgosById(vcod);
        }

        public DataTable BuscarTRG_Trigger_RiesgosByTrigger(int _Trigger_Id)
        {
            return _TRG_Trigger_RiesgosADO.BuscarTRG_Trigger_RiesgosByTrigger(_Trigger_Id);
        }
    }
}
