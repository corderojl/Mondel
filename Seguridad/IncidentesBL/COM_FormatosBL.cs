using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class COM_FormatosBL
    {
        COM_FormatosADO _COM_FormatosADO = new COM_FormatosADO();

        public DataTable ListarCOM_Formatos_All()
        {
            return _COM_FormatosADO.ListarCOM_Formatos_All();
        }
        public DataTable ListarCOM_Formatos_Act()
        {
            return _COM_FormatosADO.ListarCOM_Formatos_Act();
        }
        public List<COM_FormatosBE> ListarCOM_FormatosO_Act()
        {
            return _COM_FormatosADO.ListarCOM_FormatosO_Act();
        }
        public List<COM_FormatosBE> ListarCOM_FormatosByDepartamentoO_Act(Int16 _Departamento_id)
        {
            return _COM_FormatosADO.ListarCOM_FormatosByDepartamentoO_Act(_Departamento_id);
        }
    }
}
