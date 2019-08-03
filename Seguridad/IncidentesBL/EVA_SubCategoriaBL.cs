using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class EVA_SubCategoriaBL
    {
        EVA_SubCategoriaADO _EVA_SubCategoriaADO = new EVA_SubCategoriaADO();

        public DataTable ListarEVA_SubCategoria_All()
        {
            return _EVA_SubCategoriaADO.ListarEVA_SubCategoria_All();
        }
        public DataTable ListarEVA_SubCategoria_Act()
        {
            return _EVA_SubCategoriaADO.ListarEVA_SubCategoria_Act();
        }
        public List<EVA_SubCategoriaBE> ListarEVA_SubCategoriaO_Act()
        {
            return _EVA_SubCategoriaADO.ListarEVA_SubCategoriaO_Act();
        }
        public int InsertarEVA_SubCategoria(EVA_SubCategoriaBE _EVA_SubCategoriaBE)
        {
            return _EVA_SubCategoriaADO.InsertarEVA_SubCategoria(_EVA_SubCategoriaBE);
        }
        public bool EliminarEVA_SubCategoria(short _ElementoClave_id)
        {
            return _EVA_SubCategoriaADO.EliminarEVA_SubCategoria(_ElementoClave_id);
        }
        public bool ActualizarEVA_SubCategoria(EVA_SubCategoriaBE _EVA_SubCategoriaBE)
        {
            return _EVA_SubCategoriaADO.ActualizarEVA_SubCategoria(_EVA_SubCategoriaBE);
        }

        public string[] TraerSubCategoria(int SubCategoria_id)
        {
            return _EVA_SubCategoriaADO.TraerSubCategoria(SubCategoria_id);
        }
    }
}
