using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentesBE
{
   public class LUP_AprobadorBE
    {
       public int Lup_id { get; set; }
       public Int16 Funcionario_Id { get; set; }
       public DateTime Fecha { get; set; }
       public string Comentario { get; set; }
       public Int16 Estado { get; set; }
    }
}
