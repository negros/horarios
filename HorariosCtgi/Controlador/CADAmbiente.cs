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
    public class CADAmbiente
    {
        string cadena = ConfigurationManager.ConnectionStrings["conSQLServer"].ConnectionString.ToString();
        Modelo.DTOAmbiente dt;
        SqlConnection con;
        SqlCommand cmd = new SqlCommand();

        public void insertarAmbiente(Modelo.DTOAmbiente dt)
        {
            con = new SqlConnection(cadena);
            cmd.Connection = con;
            cmd.CommandText = "prcGestionAmbiente";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "insert");
            cmd.Parameters.AddWithValue("@codigo_amb", dt.codigo_amb);
            cmd.Parameters.AddWithValue("@nombre_amb", dt.nombre_amb);
            cmd.Parameters.AddWithValue("@capacidad_amb", dt.capacidad_amb);
            cmd.Parameters.AddWithValue("@estado_amb", dt.estado_amb);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public Modelo.DTOAmbiente buscarAmbiente(int Codigo_amb)
        {
            Modelo.DTOAmbiente dt = new Modelo.DTOAmbiente();
            con = new SqlConnection(cadena);
            cmd.Connection = con;
            cmd.CommandText = "prcGestionAmbiente";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "search");
            cmd.Parameters.AddWithValue("@codigo_amb", Codigo_amb);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                dt.nombre_amb = Convert.ToString(sdr["nombre_amb"]);
                dt.capacidad_amb = Convert.ToString(sdr["capacidad_amb"]);
                dt.estado_amb = Convert.ToString(sdr["estado_amb"]);
                sdr.Close();
                return dt;
            }
            else
            {
                return null;
            }
            con.Close();
        }

        public void modificarAmbiente(Modelo.DTOAmbiente dt)
        {
            con = new SqlConnection(cadena);
            cmd.Connection = con;
            cmd.CommandText = "prcGestionAmbiente";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@codigo_amb", dt.codigo_amb);
            cmd.Parameters.AddWithValue("@nombre_amb", dt.nombre_amb);
            cmd.Parameters.AddWithValue("@capacidad_amb", dt.capacidad_amb);
            cmd.Parameters.AddWithValue("@estado_amb", dt.estado_amb);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void eliminarAmbiente(Modelo.DTOAmbiente dt)
        {
            con = new SqlConnection(cadena);
            cmd.Connection = con;
            cmd.CommandText = "prcGestionAmbiente";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "delete");
            cmd.Parameters.AddWithValue("@codigo_amb", dt.codigo_amb);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable listarAmbiente()
        {
            DataTable data = new DataTable();
            Modelo.DTOAmbiente dt = new Modelo.DTOAmbiente();
            con = new SqlConnection(cadena);
            cmd = null;
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "prcGestionAmbiente";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "select");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(data);
            con.Close();
            return data;
        }
    }
}
