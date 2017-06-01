using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
   public class CADValidaciones
    {
        string cadena = ConfigurationManager.ConnectionStrings["conSQLServer"].ConnectionString.ToString();
        Modelo.DTOHorario horario = new Modelo.DTOHorario();
        SqlConnection con;
        SqlCommand cmd = new SqlCommand();


        public Modelo.DTOHorario verificarAsignacion(Modelo.DTOHorario dt)
        {
            horario = new Modelo.DTOHorario();
            con = new SqlConnection(cadena);
            cmd.Connection = con;
            cmd.CommandText = "ProcedureAsignaciones";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "disponibilidad");
            cmd.Parameters.AddWithValue("@fecha_ini", dt.fechainicio_asig);
            cmd.Parameters.AddWithValue("@hora_ini", dt.horainicio_asig);
            cmd.Parameters.AddWithValue("@dia_asig", dt.dia_asig);
            cmd.Parameters.AddWithValue("@id_amb", dt.id_amb);
            cmd.Parameters.AddWithValue("@id_ficha", dt.id_ficha);
            cmd.Parameters.AddWithValue("@id_instru", dt.id_instru);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                horario.codigo_asig = Convert.ToString(sdr["cod_asig"]);
                horario.fechainicio_asig = Convert.ToDateTime(sdr["fechainicio_asig"]);
                horario.fechafin_asig = Convert.ToDateTime(sdr["fechafin_asig"]);
                horario.horainicio_asig = Convert.ToDateTime(sdr["horainicio_asig"].ToString());
                horario.horafin_asig = Convert.ToDateTime(sdr["horafin_asig"].ToString());
                horario.dia_asig = Convert.ToString(sdr["dia_asig"]);
                horario.descripcion_asig = Convert.ToString(sdr["descripcion_asig"]);
                horario.nombre_amb = Convert.ToString(sdr["nombre_amb"]);
                horario.codigo_ficha = Convert.ToString(sdr["codigo_ficha"]);
                horario.nombre_Instru = Convert.ToString(sdr["nombre_instructor"]);
                horario.nombre_resul = Convert.ToString(sdr["nombre_resu"]);
                horario.id_amb = Convert.ToInt16(sdr["id_ambiente"]);
                horario.id_ficha = Convert.ToInt16(sdr["id_ficha"]);
                horario.id_instru = Convert.ToInt16(sdr["id_instructor"]);
                sdr.Close();
                return horario;
            }
            else
            {
                con.Close();
                return null;
            }

        }

        public int verificarhoras(int id_instru)
        {
         
  cmd = new SqlCommand();
            con = new SqlConnection(cadena);
            cmd.Connection = con;
            cmd.CommandText = "ProcedureAsignaciones";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "horasinstu");
            cmd.Parameters.AddWithValue("@id_instru", id_instru);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                int minutos;
                if (sdr["minutos"] != DBNull.Value)
                {
                   minutos = Convert.ToInt16(sdr["minutos"]);
                }
                else {
                    minutos = 0;
                }    
                sdr.Close();
                return minutos;
            }
            else
            {
                con.Close();
                return 0;
            }

        }
    }
}
