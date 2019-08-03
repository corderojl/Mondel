using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TRG_RiesgosBL
    {
        TRG_RiesgosADO _TRG_RiesgosADO = new TRG_RiesgosADO();

        public DataTable ListarTRG_Riesgos_All()
        {
            return _TRG_RiesgosADO.ListarTRG_Riesgos_All();
        }
        public DataTable ListarTRG_Riesgos_Act()
        {
            return _TRG_RiesgosADO.ListarTRG_Riesgos_Act();
        }
        public List<TRG_RiesgosBE> ListarTRG_RiesgosO_Act()
        {
            return _TRG_RiesgosADO.ListarTRG_RiesgosO_Act();
        }
        public int InsertarTRG_Riesgos(TRG_RiesgosBE _inseBE)
        {
            return _TRG_RiesgosADO.InsertarTRG_Riesgos(_inseBE);
        }
        public bool ActualizarTRG_Riesgos(TRG_RiesgosBE _inseBE)
        {
            return _TRG_RiesgosADO.ActualizarTRG_Riesgos(_inseBE);
        }
        public bool EliminarTRG_Riesgos(int vcod)
        {
            return _TRG_RiesgosADO.EliminarTRG_Riesgos(vcod);
        }
        public TRG_RiesgosBE TraerTRG_RiesgosById(int vcod)
        {
            return _TRG_RiesgosADO.TraerTRG_RiesgosById(vcod);
        }
        public List<TRG_RiesgosBE> ListarTRG_RiesgosByDepartamento(short _Departamento_id)
        {
            return _TRG_RiesgosADO.ListarTRG_RiesgosByDepartamento(_Departamento_id);
        }
    }
}
