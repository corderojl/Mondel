using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_CondicionInvolucradaBL
    {
        TB_CondicionInvolucradaADO _TB_CondicionInvolucradaADO = new TB_CondicionInvolucradaADO();

        public DataTable ListarTB_CondicionInvolucrada_All()
        {
            return _TB_CondicionInvolucradaADO.ListarTB_CondicionInvolucrada_All();
        }
        public DataTable ListarTB_CondicionInvolucrada_Act()
        {
            return _TB_CondicionInvolucradaADO.ListarTB_CondicionInvolucrada_Act();
        }
        public List<TB_CondicionInvolucradaBE> ListarTB_CondicionInvolucradaO_Act()
        {
            return _TB_CondicionInvolucradaADO.ListarTB_CondicionInvolucradaO_Act();
        }
        public bool ActualizarTB_CondicionInvolucrada(TB_CondicionInvolucradaBE _TB_CondicionInvolucradaBE)
        {
            return _TB_CondicionInvolucradaADO.ActualizarTB_CondicionInvolucrada(_TB_CondicionInvolucradaBE);
        }

        public bool EliminarTB_CondicionInvolucrada(short _CondicionInvolucrada_id)
        {
            return _TB_CondicionInvolucradaADO.EliminarTB_CondicionInvolucrada(_CondicionInvolucrada_id);
        }

        public int InsertarTB_CondicionInvolucrada(TB_CondicionInvolucradaBE _TB_CondicionInvolucradaBE)
        {
            return _TB_CondicionInvolucradaADO.InsertarTB_CondicionInvolucrada(_TB_CondicionInvolucradaBE);
        }
    }
}
