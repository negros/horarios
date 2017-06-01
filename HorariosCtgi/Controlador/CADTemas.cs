using Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD
{
    public class CADTemas
    {
        string cadena = ConfigurationManager.ConnectionStrings["conSQLServer"].ConnectionString.ToString();
        DTOTemas dt;
        SqlConnection con;
        SqlCommand cmd = new SqlCommand();


        public bool insertarTemas(DTOTemas dt)
        {
            try
            {
                con = new SqlConnection(cadena);
                cmd.Connection = con;
                cmd.CommandText = "prcGestionTemas";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@codigo_tema", dt.Codigo_tema);
                cmd.Parameters.AddWithValue("@nombre_tema", dt.Nombre_tema);
                cmd.Parameters.AddWithValue("@descripcion_tema", dt.Descripcion_tema);
                cmd.Parameters.AddWithValue("@id_resul", dt.Id_resultado);
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
            catch (Exception ex)
            {

                return false;

            }

        }

        public DTOTemas buscarTemas(string Codigo_tema)
        {
            try
            {
                DTOTemas dt = new DTOTemas();
                con = new SqlConnection(cadena);
                cmd.Connection = con;
                cmd.CommandText = "prcGestionTemas";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "search");
                cmd.Parameters.AddWithValue("@codigo_tema", Codigo_tema);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    cmd.Parameters.AddWithValue("@id_resul", dt.Id_resultado);
                    dt.Id_resultado = Convert.ToInt32(sdr["id_resultado"]);
                    dt.Nombre_tema = Convert.ToString(sdr["nombre_tema"]);
                    dt.Descripcion_tema = Convert.ToString(sdr["descripcion_tema"]);
                    sdr.Close();
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool modificarTemas(DTOTemas dt)
        {
            try
            {
                con = new SqlConnection(cadena);
                cmd.Connection = con;
                cmd.CommandText = "prcGestionTemas";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "update");
                cmd.Parameters.AddWithValue("@codigo_tema", dt.Codigo_tema);
                cmd.Parameters.AddWithValue("@nombre_tema", dt.Nombre_tema);
                cmd.Parameters.AddWithValue("@descripcion_tema", dt.Descripcion_tema);
                cmd.Parameters.AddWithValue("@id_resul", dt.Id_resultado);
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

        public bool eliminarTemas(DTOTemas dt)
        {
            try
            {
                con = new SqlConnection(cadena);
                cmd.Connection = con;
                cmd.CommandText = "prcGestionTemas";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "delete");
                cmd.Parameters.AddWithValue("@codigo_tema", dt.Codigo_tema);
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

        public DataTable listarTemas()
        {
            DataTable data = new DataTable();
            DTOTemas dt = new DTOTemas();
            con = new SqlConnection(cadena);
            cmd.Connection = con;
            cmd.CommandText = "prcGestionTemas";
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
