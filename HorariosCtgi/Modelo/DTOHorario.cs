using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class DTOHorario
    {
        public string codigo_asig { get; set; }
        public DateTime fechainicio_asig { get; set; }
        public DateTime fechafin_asig { get; set; }
        public DateTime horainicio_asig { get; set; }
        public DateTime horafin_asig { get; set; }
        public string dia_asig { get; set; }
        public string descripcion_asig { get; set; }
        public int id_amb { get; set; }
        public int id_ficha { get; set; }
        public int id_resul { get; set; }
        public int id_instru { get; set;}
             public string codigo_ficha { get; set; }
         public string nombre_Instru { get; set; }
         public string nombre_amb { get; set; }
         public string nombre_resul { get; set; }
    }
}
