using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo{
    public class DTOResultado

    {
        private int id_resultado;

        public int Id_resultado
        {
            get { return id_resultado; }
            set { id_resultado = value; }
        }
        private string nombre_resultado;

        public string Nombre_resultado
        {
            get { return nombre_resultado; }
            set { nombre_resultado = value; }
        }
        private string codigo_resultado;

        public string Codigo_resultado
        {
            get { return codigo_resultado; }
            set { codigo_resultado = value; }
        }

        
      
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private TimeSpan horainicio;

        public TimeSpan Horainicio
        {
            get { return horainicio; }
            set { horainicio = value; }
        }

        private TimeSpan Horafin;

        public TimeSpan Horafin1
        {
            get { return Horafin; }
            set { Horafin = value; }
        }

        private int id_comp;

        public int Id_comp
        {
            get { return id_comp; }
            set { id_comp = value; }
        }

       

    }
}
