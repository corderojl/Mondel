using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_GuardiaBL
    {
        TB_GuardiaADO _TB_GuardiaADO = new TB_GuardiaADO();

        public DataTable ListarTB_Guardia_All()
        {
            return _TB_GuardiaADO.ListarTB_Guardia_All();
        }
        public DataTable ListarTB_Guardia_Act()
        {
            return _TB_GuardiaADO.ListarTB_Guardia_Act();
        }
        public List<TB_GuardiaBE> ListarTB_GuardiaO_Act()
        {
            return _TB_GuardiaADO.ListarTB_GuardiaO_Act();
        }
        public DataTable ConsultarGuardiaId(int vIdGrupo)
        {
            return _TB_GuardiaADO.ConsultarFunc_Grupo_Id(vIdGrupo);
        }

        public List<TB_GuardiaBE> ListarTB_GuardiaByDepartamento(short _Departamento_id)
        {
            return _TB_GuardiaADO.ListarTB_GuardiaByDepartamento(_Departamento_id);
        }

        public bool ActualizarTB_Guardia(TB_GuardiaBE _TB_GuardiaBE)
        {
            return _TB_GuardiaADO.ActualizarTB_Guardia(_TB_GuardiaBE);
        }

        public bool EliminarTB_Guardia(short _Area_id)
        {
            return _TB_GuardiaADO.EliminarTB_Guardia(_Area_id);
        }

        public int InsertarTB_Guardia(TB_GuardiaBE _TB_GuardiaBE)
        {
            return _TB_GuardiaADO.InsertarTB_Guardia(_TB_GuardiaBE);
        }
    }
}
