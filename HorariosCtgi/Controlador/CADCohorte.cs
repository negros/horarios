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
    public class CADCohorte
    {
        string cadena = ConfigurationManager.ConnectionStrings["conSQLServer"].ConnectionString.ToString();
        Modelo.DTOCohorte cohorte = new Modelo.DTOCohorte();
        SqlConnection con;
        SqlCommand cmd = new SqlCommand();
        public void insertarCohorte(Modelo.DTOCohorte cohorte)
        {
            con = new SqlConnection(cadena);
            cmd.Connection = con;
            cmd.CommandText = "prcGestionCohorte";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "insert");
            cmd.Parameters.AddWithValue("@codigo_cohorte", cohorte.codigo_cohorte);
            cmd.Parameters.AddWithValue("@nombre_cohorte", cohorte.nombre_cohorte);
            cmd.Parameters.AddWithValue("@fecha_inicio_cohorte", cohorte.fecha_inicio);
            cmd.Parameters.AddWithValue("@fecha_fin_cohorte", cohorte.fecha_fin);
            cmd.Parameters.AddWithValue("@año_cohorte", cohorte.año_cohorte);
            cmd.Parameters.AddWithValue("@trimestre_cohorte", cohorte.trimestre_cohorte);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void actualizarCohorte(Modelo.DTOCohorte cohorte)
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prcGestionCohorte";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "update");
                cmd.Parameters.AddWithValue("@codigo_cohorte", cohorte.codigo_cohorte);
                cmd.Parameters.AddWithValue("@nombre_cohorte", cohorte.nombre_cohorte);
                cmd.Parameters.AddWithValue("@fecha_inicio_cohorte", cohorte.fecha_inicio);
                cmd.Parameters.AddWithValue("@fecha_fin_cohorte", cohorte.fecha_fin);
                cmd.Parameters.AddWithValue("@año_cohorte", cohorte.año_cohorte);
                cmd.Parameters.AddWithValue("@trimestre_cohorte", cohorte.trimestre_cohorte);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void eliminarCohorte(Modelo.DTOCohorte cohorte)
        {
          

        }
        public DataTable ListarCohorte()
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prcGestionCohorte";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "select");
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //El fill se encarga de llenar la tabla
                sda.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public Modelo.DTOCohorte ConsultarCohorte(String codigo)
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prcGestionCohorte";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "search");
                cmd.Parameters.AddWithValue("@codigo_cohorte", codigo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    cohorte.codigo_cohorte = Convert.ToInt64(dr["codigo_coho"]);
                    cohorte.nombre_cohorte = Convert.ToString(dr["nombre_coho"]);
                    cohorte.fecha_inicio = Convert.ToDateTime(dr["fechainicio_coho"]);
                    cohorte.fecha_fin = Convert.ToDateTime(dr["fechafin_coho"]);
                    cohorte.año_cohorte = Convert.ToString(dr["año_coho"]);
                    cohorte.trimestre_cohorte = Convert.ToInt16(dr["trimestre_coho"]);
                    dr.Close();
                    return cohorte;
                }
                else
                {
                    return null;
                }
                con.Close();
            }
        }
    }
}
