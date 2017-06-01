using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class DTOCompetencia
    {
        public int id_comp { get; set; }
        public string codigo_comp { get; set; }
        public string nombre_comp { get; set; }
        public string descripcion_comp { get; set; }
        public int id_prog { get; set; }
    }
}
