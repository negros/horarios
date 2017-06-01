using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class DTOTemas
    {

        private int id_tema;
        private int id_resultado;

   
        private string codigo_tema;
        private string nombre_tema;
        private string descripcion_tema;

        public int Id_tema
        {
            get
            {
                return id_tema;
            }

            set
            {
                id_tema = value;

            }
        }
        public int Id_resultado
        {
            get { return id_resultado; }
            set { id_resultado = value; }
        }
        public string Codigo_tema
        {
            get
            {
                return codigo_tema;
            }

            set
            {
                codigo_tema = value;

            }
        }

        public string Nombre_tema
        {
            get
            {
                return nombre_tema;
            }

            set
            {
                nombre_tema = value;

            }
        }

        public string Descripcion_tema
        {
            get
            {
                return descripcion_tema;
            }

            set
            {
                descripcion_tema = value;

            }
        }
    
    }
}
