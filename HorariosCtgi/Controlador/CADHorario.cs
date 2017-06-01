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
    public class CADHorario
    {
        string cadena = ConfigurationManager.ConnectionStrings["conSQLServer"].ConnectionString.ToString();
        Modelo.DTOHorario horario = new Modelo.DTOHorario();
        SqlConnection con;
        SqlCommand cmd = new SqlCommand();


     
        public void insertarAsignacion(Modelo.DTOHorario dt)
        {
            cmd = new SqlCommand();
            con = new SqlConnection(cadena);
            cmd.Connection = con;
            cmd.CommandText = "ProcedureAsignaciones";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "insert");
            cmd.Parameters.AddWithValue("@codigo_asig", dt.codigo_asig);
            cmd.Parameters.AddWithValue("@fecha_ini", dt.fechainicio_asig);
            cmd.Parameters.AddWithValue("@fecha_fin", dt.fechafin_asig);
            cmd.Parameters.AddWithValue("@hora_ini", dt.horainicio_asig);
            cmd.Parameters.AddWithValue("@hora_fin", dt.horafin_asig);
            cmd.Parameters.AddWithValue("@dia_asig", dt.dia_asig);
            cmd.Parameters.AddWithValue("@descripcion_asig", dt.descripcion_asig);
            cmd.Parameters.AddWithValue("@id_amb", dt.id_amb);
            cmd.Parameters.AddWithValue("@id_ficha", dt.id_ficha);
            cmd.Parameters.AddWithValue("@id_resul", dt.id_resul);
            cmd.Parameters.AddWithValue("@id_instru", dt.id_instru);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void modificarAsignacion(Modelo.DTOHorario dt)
        {
            con = new SqlConnection(cadena);
            cmd.Connection = con;
            cmd.CommandText = "ProcedureAsignaciones";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@codigo_asig", dt.codigo_asig);
            cmd.Parameters.AddWithValue("@fecha_ini", dt.fechainicio_asig);
            cmd.Parameters.AddWithValue("@fecha_fin", dt.fechafin_asig);
            cmd.Parameters.AddWithValue("@hora_ini", dt.horainicio_asig);
            cmd.Parameters.AddWithValue("@hora_fin", dt.horafin_asig);
            cmd.Parameters.AddWithValue("@dia_asig", dt.dia_asig);
            cmd.Parameters.AddWithValue("@descripcion_asig", dt.descripcion_asig);
            cmd.Parameters.AddWithValue("@id_amb", dt.id_amb);
            cmd.Parameters.AddWithValue("@id_ficha", dt.id_ficha);
            cmd.Parameters.AddWithValue("@id_resul", dt.id_resul);
            cmd.Parameters.AddWithValue("@id_instru", dt.id_instru);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void deleteAsignacion(String codigo)
        {
            con = new SqlConnection(cadena);
            cmd.Connection = con;
            cmd.CommandText = "ProcedureAsignaciones";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "delete");
            cmd.Parameters.AddWithValue("@codigo_asig",codigo);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public Modelo.DTOHorario buscarAsignacion(string Codigo_asig)
        {
            con = new SqlConnection(cadena);
            cmd.Connection = con;
            cmd.CommandText = "ProcedureAsignaciones";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "Search");
            cmd.Parameters.AddWithValue("@codigo_asig", Codigo_asig);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                horario.fechainicio_asig = Convert.ToDateTime(sdr["fechainicio_asig"]);
                horario.fechafin_asig = Convert.ToDateTime(sdr["fechafin_asig"]);
                horario.horainicio_asig = Convert.ToDateTime(sdr["horainicio_asig"].ToString());
               horario.horafin_asig = Convert.ToDateTime(sdr["horafin_asig"].ToString());
                horario.dia_asig = Convert.ToString(sdr["dia_asig"]);
                horario.descripcion_asig = Convert.ToString(sdr["descripcion_asig"]);
                horario.id_amb = Convert.ToInt16(sdr["id_ambiente"]);
                horario.id_ficha = Convert.ToInt16(sdr["id_ficha"]);
                horario.id_instru = Convert.ToInt16(sdr["id_instructor"]);
                horario.id_resul = Convert.ToInt16(sdr["id_resultado"]);
                sdr.Close();
                con.Close();
                return horario;
            }
            else
            {
                con.Close();
                return null;
            }
          
        }


        public DataTable listarAsignacion()
        {
            DataTable data = new DataTable();
            Modelo.DTOHorario dt = new Modelo.DTOHorario();
            con = new SqlConnection(cadena);
            cmd.Connection = con;
            cmd.CommandText = "ProcedureAsignaciones";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "list");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(data);
            con.Close();
            return data;
        }
    }
}
