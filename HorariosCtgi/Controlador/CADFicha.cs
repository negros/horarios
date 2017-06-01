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
    public class CADFicha
    {
        string cadena = ConfigurationManager.ConnectionStrings["conSQLServer"].ConnectionString.ToString();
        Modelo.DTOFicha ficha = new Modelo.DTOFicha();
        SqlConnection con;
        SqlCommand cmd = new SqlCommand();
        public bool insertarFicha(Modelo.DTOFicha ficha)
        {
            try
            {
                con = new SqlConnection(cadena);
                cmd.Connection = con;
                cmd.CommandText = "prcGestionFicha";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@codigo_ficha", ficha.codigo_ficha);
                cmd.Parameters.AddWithValue("@id_programa", ficha.id_programa);
                cmd.Parameters.AddWithValue("@nintegrantes_ficha", ficha.ningregantes_ficha);
                cmd.Parameters.AddWithValue("@jornada_ficha", ficha.jornada_ficha);
                cmd.Parameters.AddWithValue("@id_cohorte", ficha.id_cohorte);
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
        public void actualizarFicha(Modelo.DTOFicha ficha)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "prcGestionFicha";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@action", "update");
                    cmd.Parameters.AddWithValue("@id_ficha", ficha.id_ficha);
                    cmd.Parameters.AddWithValue("@codigo_ficha", ficha.codigo_ficha);
                    cmd.Parameters.AddWithValue("@id_programa", ficha.id_programa);
                    cmd.Parameters.AddWithValue("@nintegrantes_ficha", ficha.ningregantes_ficha);
                    cmd.Parameters.AddWithValue("@jornada_ficha", ficha.jornada_ficha);
                    cmd.Parameters.AddWithValue("@id_cohorte", ficha.id_cohorte);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void eliminarFicha(Modelo.DTOFicha ficha)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "prcGestionFicha";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@action", "delete");
                    cmd.Parameters.AddWithValue("@codigo_ficha", ficha.codigo_ficha);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }catch(Exception ex){
            }
        }
        public DataTable ListarFicha()
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prcGestionFicha";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "search");
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public Modelo.DTOFicha ConsultarFicha(long codigo_ficha)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    Modelo.DTOFicha ficha = new Modelo.DTOFicha();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "prcGestionFicha";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@action", "select");
                    cmd.Parameters.AddWithValue("@codigo_ficha", codigo_ficha);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        ficha.codigo_ficha = Convert.ToInt64(dr["codigo_ficha"]);
                        ficha.id_programa = int.Parse(Convert.ToString(dr["id_programa"]));
                        ficha.ningregantes_ficha = Convert.ToInt16(dr["nintegrantes_ficha"]);
                        ficha.jornada_ficha = Convert.ToString(dr["jornada_ficha"]);
                        ficha.id_cohorte = int.Parse(Convert.ToString(dr["id_cohorte"]));
                        dr.Close();
                        return ficha;
                    }
                    else
                    {
                        return null;
                    }

                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally {
              
            }
        }
    }
}
