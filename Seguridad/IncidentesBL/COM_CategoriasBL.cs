using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class COM_CategoriasBL
    {
        COM_CategoriasADO _COM_CategoriasADO = new COM_CategoriasADO();

        public DataTable ListarCOM_Categorias_All()
        {
            return _COM_CategoriasADO.ListarCOM_Categorias_All();
        }
        public DataTable ListarCOM_Categorias_Act()
        {
            return _COM_CategoriasADO.ListarCOM_Categorias_Act();
        }
        public List<COM_CategoriasBE> ListarCOM_CategoriasO_Act()
        {
            return _COM_CategoriasADO.ListarCOM_CategoriasO_Act();
        }
        public List<COM_CategoriasBE> ListarCOM_CategoriasByFormato(Int16 _Formato_id)
        {
            return _COM_CategoriasADO.ListarCOM_CategoriasByFormato(_Formato_id);
        }

        public bool ActualizarCOM_Categoria(COM_CategoriasBE _COM_CategoriasBE)
        {
            return _COM_CategoriasADO.ActualizarCOM_Categoria(_COM_CategoriasBE);
        }

        public COM_CategoriasBE TraerCOM_CategoriaById(int _Categoria_id)
        {
            return _COM_CategoriasADO.TraerCOM_CategoriaById(_Categoria_id);
        }

        public List<COM_CategoriasBE> ListarCOM_CategoriasBySector(short _Sector_id)
        {
            return _COM_CategoriasADO.ListarCOM_CategoriasBySector(_Sector_id);
        }
    }
}
