using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class COM_SubCategoriasBL
    {
        COM_SubCategoriasADO _COM_SubCategoriasADO = new COM_SubCategoriasADO();

        public DataTable ListarCOM_SubCategorias_All()
        {
            return _COM_SubCategoriasADO.ListarCOM_SubCategorias_All();
        }
        public DataTable ListarCOM_SubCategorias_Act()
        {
            return _COM_SubCategoriasADO.ListarCOM_SubCategorias_Act();
        }
        public List<COM_SubCategoriasBE> ListarCOM_SubCategoriasO_Act()
        {
            return _COM_SubCategoriasADO.ListarCOM_SubCategoriasO_Act();
        }

        public List<COM_SubCategoriasBE> ListarCOM_SubCategoriasByCategoria(short _Categoria_id)
        {
            return _COM_SubCategoriasADO.ListarCOM_SubCategoriasByCategoria(_Categoria_id);
        }

        public int InsertarCOM_SubCategoria(COM_SubCategoriasBE _COM_SubCategoriasBE)
        {
            return _COM_SubCategoriasADO.InsertarCOM_SubCategoria(_COM_SubCategoriasBE);
        }

        public bool EliminarCOM_SubCategoria(short _SubCategoria_id)
        {
            return _COM_SubCategoriasADO.EliminarCOM_SubCategoria(_SubCategoria_id);
        }

        public bool ActualizarCOM_SubCategoria(COM_SubCategoriasBE _COM_SubCategoriasBE)
        {
            return _COM_SubCategoriasADO.ActualizarCOM_SubCategoria(_COM_SubCategoriasBE);
        }

        public COM_SubCategoriasBE TraerCOM_SubCategoriaByID(short SubCategoria_id)
        {
            return _COM_SubCategoriasADO.TraerCOM_SubCategoriaByID(SubCategoria_id);
        }

        public List<COM_SubCategoriasBE> ListarCOM_SubCategoriasBySector(short _Categoria_id)
        {
            return _COM_SubCategoriasADO.ListarCOM_SubCategoriasBySector(_Categoria_id);
        }
    }
}
