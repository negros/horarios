using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class DTOCohorte
    {
        public int id_cohorte { get; set; }
        public long codigo_cohorte { get; set; }
        public string nombre_cohorte { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public string año_cohorte { get; set; }
        public int trimestre_cohorte { get; set; }
    }
}
