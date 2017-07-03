using Modelo;
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
    public class CADPrograma
    {
        string cadena = ConfigurationManager.ConnectionStrings["conSQLServer"].ConnectionString.ToString();
        SqlConnection con;
        SqlCommand cmd = new SqlCommand();

        public bool insertarPrograma(DTOPrograma dt)
        {
            try
            {
                con = new SqlConnection(cadena);
                cmd.Connection = con;
                cmd.CommandText = "prc_GestionPrograma";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@codigo_prog", dt.cod_programa);
                cmd.Parameters.AddWithValue("@nombre_prog", dt.nombre_prog);
                cmd.Parameters.AddWithValue("@version_prog", dt.version_prog);
                cmd.Parameters.AddWithValue("@descripcion_prog", dt.descripcion_prog);
                cmd.Parameters.AddWithValue("@id_linea", dt.id_linea);
                con.Open();
                int respuesta = cmd.ExecuteNonQuery();
                con.Close();
                if (respuesta == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void modificar(DTOPrograma dt)
        {
            con = new SqlConnection(cadena);
            cmd.Connection = con;
            cmd.CommandText = "prc_GestionPrograma";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@codigo_prog", dt.cod_programa);
            cmd.Parameters.AddWithValue("@nombre_prog", dt.nombre_prog);
            cmd.Parameters.AddWithValue("@version_prog", dt.version_prog);
            cmd.Parameters.AddWithValue("@descripcion_prog", dt.descripcion_prog);
            cmd.Parameters.AddWithValue("@id_linea", dt.id_linea);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DTOPrograma buscar(int Cod_programa)
        {
            try
            {
                DTOPrograma dt = new DTOPrograma();
                con = new SqlConnection(cadena);
                cmd.Connection = con;
                cmd.CommandText = "prc_GestionPrograma";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "search");
                cmd.Parameters.AddWithValue("@codigo_prog", Cod_programa);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    dt.nombre_prog = Convert.ToString(sdr["nombre_prog"]);
                    dt.descripcion_prog = Convert.ToString(sdr["descripcion_prog"]);
                    dt.version_prog = Convert.ToString(sdr["version_prog"]);
                    dt.id_linea = Convert.ToInt32(sdr["id_linea_tecno"]);
                    sdr.Close();
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public void eliminar(DTOPrograma cpt)
        {
            try
            {
                con = new SqlConnection(cadena);
                cmd.Connection = con;
                cmd.CommandText = "prc_GestionPrograma";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "delete");
                cmd.Parameters.AddWithValue("@codigo_prog", cpt.cod_programa);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar ---> " + ex.ToString());
            }
        }

        public DataTable listar()
        {
            con = new SqlConnection(cadena);
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "prc_GestionPrograma";
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt= new DataTable();
            cmd.Parameters.AddWithValue("@action", "list");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            con.Close();
            return dt;
        }

    }
}
