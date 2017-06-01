using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class DTOInstructores
    {
        private string nombre_isntructor;
        private string apellido_instructor;
        private string profesion_instructor;
        private int dni_instructor;


        public string Nombre_isntructor
        {
            get
            {
                return nombre_isntructor;
            }

            set
            {
                nombre_isntructor = value;
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
