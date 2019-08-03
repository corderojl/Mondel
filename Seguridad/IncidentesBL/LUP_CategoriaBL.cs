using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class LUP_CategoriaBL
    {
        LUP_CategoriaADO _LUP_CategoriaADO = new LUP_CategoriaADO();

        public List<LUP_CategoriaBE> ListarLUP_CategoriaO_Act()
        {
            return _LUP_CategoriaADO.ListarLUP_CategoriaO_Act();
        }

        public List<LUP_CategoriaBE> ListarLUP_CategoriaByPilar(short _Pilar_id)
        {
            return _LUP_CategoriaADO.ListarLUP_CategoriaByPilar(_Pilar_id);
        }

        public bool ActualizarLUP_Categoria(LUP_CategoriaBE _LUP_CategoriaBE)
        {
            return _LUP_CategoriaADO.ActualizarLUP_Categoria(_LUP_CategoriaBE);
        }

        public bool EliminarLUP_Categoria(short _Area_id)
        {
            return _LUP_CategoriaADO.EliminarLUP_Categoria(_Area_id);
        }

        public int InsertarLUP_Categoria(LUP_CategoriaBE _LUP_CategoriaBE)
        {
            return _LUP_CategoriaADO.InsertarLUP_Categoria(_LUP_CategoriaBE);
        }

    }
}
