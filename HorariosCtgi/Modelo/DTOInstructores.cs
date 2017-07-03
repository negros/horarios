using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class DTOInstructores
    {
        private string nombre_instructor;
        private string apellido_instructor;
        private string profesion_instructor;
        private int dni_instructor;


        public string Nombre_instructor
        {
            get
            {
                return nombre_instructor;
            }

            set
            {
                nombre_instructor = value;
            }
        }

        public string Apellido_instructor
        {
            get
            {
                return apellido_instructor;
            }

            set
            {
                apellido_instructor = value;
            }
        }

        public string Profesion_instructor
        {
            get
            {
                return profesion_instructor;
            }

            set
            {
                profesion_instructor = value;
            }
        }

        public int Dni_instructor
        {
            get
            {
                return dni_instructor;
            }

            set
            {
                dni_instructor = value;
            }
        }

    }
}
