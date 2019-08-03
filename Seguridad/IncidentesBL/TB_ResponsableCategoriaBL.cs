using IncidentesADO;
using IncidentesBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IncidentesBL
{
    public class TB_ResponsableCategoriaBL
    {
        TB_ResponsableCategoriaADO _TB_ResponsableCategoriaADO = new TB_ResponsableCategoriaADO();

        public DataTable ListarTB_ResponsableCategoriaByCategoria(short Categoria_id)
        {
            return _TB_ResponsableCategoriaADO.ListarTB_ResponsableCategoriaByCategoria(Categoria_id);
        }
        public List<TB_ResponsableCategoriaBE> ListarTB_ResponsableCategoriaO_Act(short Categoria_id)
        {
            return _TB_ResponsableCategoriaADO.ListarTB_ResponsableCategoriaO_Act();
        }
        public bool EliminarTB_ResponsableCategoria(short _Departamento_id, short _Funcionario_id)
        {
            return _TB_ResponsableCategoriaADO.EliminarTB_ResponsableCategoria(_Departamento_id, _Funcionario_id);
        }
        public string InsertarTB_ResponsableCategoria(short dpt, short emp)
        {
            return _TB_ResponsableCategoriaADO.InsertarTB_ResponsableCategoria(dpt, emp);
        }
        public DataTable ListarTB_ResponsableCategoria_All()
        {
            return _TB_ResponsableCategoriaADO.ListarTB_ResponsableCategoria_All();
        }
    }
}
