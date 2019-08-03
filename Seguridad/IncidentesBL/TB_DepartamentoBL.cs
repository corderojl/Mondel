using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_DepartamentoBL
    {
        TB_DepartamentoADO _TB_DepartamentoADO = new TB_DepartamentoADO();

        public List<TB_DepartamentoBE> ListarTB_Departamento_All(string Sistema_id)
        {
            return _TB_DepartamentoADO.ListarTB_Departamento_All(Sistema_id);
        }
        public DataTable ListarTB_Departamento_Act()
        {
            return _TB_DepartamentoADO.ListarTB_Departamento_Act();
        }
        public List<TB_DepartamentoBE> ListarTB_DepartamentoO_Act(string Sistema_id)
        {
            return _TB_DepartamentoADO.ListarTB_DepartamentoO_Act(Sistema_id);
        }

        public List<TB_DepartamentoBE> ListarTB_DepartamentoSuperiorO_Act(short _Superior)
        {
            return _TB_DepartamentoADO.ListarTB_DepartamentoSuperiorO_Act(_Superior);
        }

        public bool ActualizarTB_Departamento(TB_DepartamentoBE _TB_DepartamentoBE)
        {
            return _TB_DepartamentoADO.ActualizarTB_Departamento(_TB_DepartamentoBE);
        }

        public bool EliminarTB_Departamento(short _Departamento_id)
        {
            return _TB_DepartamentoADO.EliminarTB_Departamento(_Departamento_id);
        }

        public int InsertarTB_Departamento(TB_DepartamentoBE _TB_DepartamentoBE)
        {
            return _TB_DepartamentoADO.InsertarTB_Departamento(_TB_DepartamentoBE);
        }

        public DataTable ListarTB_DepartamentoBySector()
        {
            return _TB_DepartamentoADO.ListarTB_DepartamentoBySector();
        }
    }
}
