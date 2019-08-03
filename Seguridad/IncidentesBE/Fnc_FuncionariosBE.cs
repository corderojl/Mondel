using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
    public class Fnc_FuncionariosBE
    {
        public Int16 Funcionario_Id { get; set; }
        public string Funcionario_Nome { get; set; }
        public string Funcionario_Drt { get; set; }
        public Int16 Funcionario_Status { get; set; }
        public string Funcionario_Ramal { get; set; }
        public string Funcionario_Email { get; set; }
        public string Funcionario_Senha { get; set; }
        public string Funcionario_Tnumber { get; set; }
        public int Categoria_id { get; set; }
        public int SubCategoria_id { get; set; }
        public int Area_Id { get; set; }
        public Int16 Grupo_Id { get; set; }
        public int Rol_id { get; set; }

        public int AreaLabor_id { get; set; }
        public string Gr_Prof { get; set; }
        public string Tipo_Contrato { get; set; }
        public DateTime Fecha_ingreso { get; set; }
        public DateTime Fecha_naci { get; set; }
        public int Genero { get; set; }
        public int Superior { get; set; }
        public string CE_Coste { get; set; }
    }
}
