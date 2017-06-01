using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class DTOPrograma
    {
        public int cod_programa { get; set; }
        public string nombre_prog { get; set; }
        public string descripcion_prog { get; set; }
        public string version_prog { get; set; }
        public int id_linea { get; set; }
    }
}
