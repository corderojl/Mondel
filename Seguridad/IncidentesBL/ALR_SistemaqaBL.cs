using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class ALR_SistemaqaBL
    {
        ALR_SistemaqaADO _ALR_SistemaqaADO = new ALR_SistemaqaADO();

        public DataTable ListarALR_Sistemaqa_All()
        {
            return _ALR_SistemaqaADO.ListarALR_Sistemaqa_All();
        }
        public DataTable ListarALR_Sistemaqa_Act()
        {
            return _ALR_SistemaqaADO.ListarALR_Sistemaqa_Act();
        }
        public List<ALR_SistemaqaBE> ListarALR_SistemaqaO_Act()
        {
            return _ALR_SistemaqaADO.ListarALR_SistemaqaO_Act();
        }
        public List<ALR_SistemaqaBE> ListarALR_SistemaqaByDepartamento(Int16 _Departamento_id)
        {
            return _ALR_SistemaqaADO.ListarALR_SistemaqaByDepartamento(_Departamento_id);
        }
        public int InsertarALR_Sistemaqa(ALR_SistemaqaBE _ALR_SistemaqaBE)
        {
            return _ALR_SistemaqaADO.InsertarALR_SistemaQA(_ALR_SistemaqaBE);
        }
        public bool EliminarALR_Sistemaqa(short _Sistemaqa_id)
        {
            return _ALR_SistemaqaADO.EliminarALR_SistemaQA(_Sistemaqa_id);
        }
        public bool ActualizarALR_Sistemaqa(ALR_SistemaqaBE _ALR_SistemaqaBE)
        {
            return _ALR_SistemaqaADO.ActualizarALR_SistemaQA(_ALR_SistemaqaBE);
        }

        public List<ALR_SistemaqaBE> ListarALR_SistemaqaO_All()
        {
            return _ALR_SistemaqaADO.ListarALR_SistemaqaO_All();
        }
    }
}
