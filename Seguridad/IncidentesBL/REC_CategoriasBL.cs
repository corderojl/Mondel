using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class REC_CategoriasBL
    {
        REC_CategoriasADO _REC_CategoriasADO = new REC_CategoriasADO();

        public DataTable ListarREC_Categorias_All()
        {
            return _REC_CategoriasADO.ListarREC_Categorias_All();
        }
        public DataTable ListarREC_Categorias_Act()
        {
            return _REC_CategoriasADO.ListarREC_Categorias_Act();
        }
        public List<REC_CategoriasBE> ListarREC_CategoriasO_Act()
        {
            return _REC_CategoriasADO.ListarREC_CategoriasO_Act();
        }
        public bool ActualizarREC_Categoria(REC_CategoriasBE _REC_CategoriasBE)
        {
            return _REC_CategoriasADO.ActualizarREC_Categoria(_REC_CategoriasBE);
        }
        public REC_CategoriasBE TraerREC_CategoriaById(int _Categoria_id)
        {
            return _REC_CategoriasADO.TraerREC_CategoriaById(_Categoria_id);
        }
    }
}
