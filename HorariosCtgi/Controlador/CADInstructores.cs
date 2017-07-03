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
    public class CADInstructores
    {
        string cadena = ConfigurationManager.ConnectionStrings["conSQLServer"].ConnectionString.ToString();
        DTOInstructores dt;
        SqlConnection con;
        SqlCommand cmd = new SqlCommand();

        public bool insertarInstructores(DTOInstructores dt)
        {
            try
            {
                con = new SqlConnection(cadena);
                cmd.Connection = con;
                cmd.CommandText = "prcGestionInstructores";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@dni_instructor", dt.Dni_instructor);
                cmd.Parameters.AddWithValue("@nombre_instructor", dt.Nombre_instructor);
                cmd.Parameters.AddWithValue("@profesion", dt.Profesion_instructor);
                cmd.Parameters.AddWithValue("@apellido_instructor", dt.Apellido_instructor);
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

        public DTOInstructores buscarInstructores(int Dni_instructores)
        {
            try
            {
                DTOInstructores dt = new DTOInstructores();
                con = new SqlConnection(cadena);
                cmd.Connection = con;
                cmd.CommandText = "prcGestionInstructores";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "search");
                cmd.Parameters.AddWithValue("@dni_instructor", Dni_instructores);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    dt.Nombre_instructor = Convert.ToString(sdr["nombre_instructor"]);
                    dt.Apellido_instructor = Convert.ToString(sdr["apellido_instructor"]);
                    dt.Profesion_instructor = Convert.ToString(sdr["profesion"]);
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

        public bool modificarInstructores(DTOInstructores dt)
        {
            try
            {
                con = new SqlConnection(cadena);
                cmd.Connection = con;
                cmd.CommandText = "prcGestionInstructores";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "update");
                cmd.Parameters.AddWithValue("@dni_instructor", dt.Dni_instructor);
                cmd.Parameters.AddWithValue("@nombre_instructor", dt.Nombre_instructor);
                cmd.Parameters.AddWithValue("@profesion", dt.Profesion_instructor);
                cmd.Parameters.AddWithValue("@apellido_instructor", dt.Apellido_instructor);
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

        public bool eliminarInstructores(DTOInstructores dt)
        {
            try
            {
                con = new SqlConnection(cadena);
                cmd.Connection = con;
                cmd.CommandText = "prcGestionInstructores";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "delete");
                cmd.Parameters.AddWithValue("@dni_instructor", dt.Dni_instructor);
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

        public DataTable listarInsructores()
        {
            DataTable data = new DataTable();
            DTOInstructores dt = new DTOInstructores();
            con = new SqlConnection(cadena);
            cmd.Connection = con;
            cmd.CommandText = "prcGestionInstructores";
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

