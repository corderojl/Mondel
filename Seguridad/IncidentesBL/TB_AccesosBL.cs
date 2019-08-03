using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_AccesosBL
    {
        TB_AccesosADO _TB_AccesosADO = new TB_AccesosADO();

        public DataTable ListarTB_Accesos_All()
        {
            return _TB_AccesosADO.ListarTB_Accesos_All();
        }
        public DataTable ListarTB_Accesos_Act()
        {
            return _TB_AccesosADO.ListarTB_Accesos_Act();
        }
        public List<TB_AccesosBE> ListarTB_AccesosO_Act()
        {
            return _TB_AccesosADO.ListarTB_AccesosO_Act();
        }
        public TB_AccesosBE TraerTB_Accesos(Int16 _Funcionario_id, Int16 _Sistema_id)
        {
            return _TB_AccesosADO.TraerTB_Accesos(_Funcionario_id, _Sistema_id);
        }
        public List<string> ListarTB_AccesosEmailByDeparatmento(Int16 _Departamento_id, Int16 _Sistema_id)
        {
            return _TB_AccesosADO.ListarTB_AccesosEmailByDeparatmento(_Departamento_id, _Sistema_id);
        }
    }
}
