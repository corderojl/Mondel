using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_ResponsableBL
    {
        TB_ResponsableADO _TB_ResponsableADO = new TB_ResponsableADO();

        public DataTable ListarTB_Responsable_All()
        {
            return _TB_ResponsableADO.ListarTB_Responsable_All();
        }
        public TB_ResponsableBE TraerTB_ResponsableByDepartamento(Int16 Departamento_id)
        {
            return _TB_ResponsableADO.TraerTB_ResponsableByDepartamento(Departamento_id);
        }
        public List<TB_ResponsableBE> ListarTB_ResponsableO_Act()
        {
            return _TB_ResponsableADO.ListarTB_ResponsableO();
        }

        public bool EliminarTB_Responsable(short _Departamento_id, short _Funcionario_id)
        {
            return _TB_ResponsableADO.EliminarTB_Responsable(_Departamento_id, _Funcionario_id);
        }

        public string InsertarTB_Responsable(short dpt, short emp)
        {
            return _TB_ResponsableADO.InsertarTB_Responsable(dpt, emp);
        }
    }
}
