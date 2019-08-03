using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class EVA_CategoriaBL
    {
        EVA_CategoriaADO _EVA_CategoriaADO = new EVA_CategoriaADO();

        public DataTable ListarEVA_Categoria_All()
        {
            return _EVA_CategoriaADO.ListarEVA_Categoria_All();
        }
        public DataTable ListarEVA_Categoria_Act()
        {
            return _EVA_CategoriaADO.ListarEVA_Categoria_Act();
        }
        public List<EVA_CategoriaBE> ListarEVA_CategoriaO_Act()
        {
            return _EVA_CategoriaADO.ListarEVA_CategoriaO_Act();
        }
        public List<EVA_CategoriaBE> ListarEVA_CategoriaByFormato(Int16 _Formato_id)
        {
            return _EVA_CategoriaADO.ListarEVA_CategoriaByFormato(_Formato_id);
        }

        public bool ActualizarCOM_Categoria(EVA_CategoriaBE _EVA_CategoriaBE)
        {
            return _EVA_CategoriaADO.ActualizarCOM_Categoria(_EVA_CategoriaBE);
        }

        public EVA_CategoriaBE TraerCOM_CategoriaById(int _Categoria_id)
        {
            return _EVA_CategoriaADO.TraerCOM_CategoriaById(_Categoria_id);
        }
    }
}
