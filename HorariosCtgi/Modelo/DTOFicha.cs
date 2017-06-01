using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class DTOFicha
    {
        public int id_ficha { get; set; }
        public long codigo_ficha { get; set; }
        public int id_programa { get; set; }
        public int ningregantes_ficha { get; set; }
        public string jornada_ficha { get; set; }
        public int id_cohorte { get; set; }
    }
}
