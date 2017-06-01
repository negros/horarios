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
    public class CADLinea_tecno
    {
        string cadena = ConfigurationManager.ConnectionStrings["conSQLServer"].ConnectionString.ToString();
        DTOLinea_tecno linea_tecno = new Modelo.DTOLinea_tecno();
        SqlConnection con;
        SqlCommand cmd = new SqlCommand();

        public bool insertarLinea_tecno(Modelo.DTOLinea_tecno linea_tecno)
        {
            try
            {
                con = new SqlConnection(cadena);
                cmd.Connection = con;
                cmd.CommandText = "prcGestionLinea_tecno";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@nombre_linea_tecno", linea_tecno.nombre_linea_tecno);
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

        public DataTable ListarLinea_tecno()
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prcGestionLinea_tecno";
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

        public Modelo.DTOLinea_tecno ConsultarLinea_tecno(String nombre_linea_tecno)
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "prcGestionLinea_tecno";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "search");
                cmd.Parameters.AddWithValue("@nombre_linea_tecno", nombre_linea_tecno);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    linea_tecno.nombre_linea_tecno = Convert.ToString(dr["nombre_linea_tecno"]);
                    dr.Close();
                    con.Close();
                    return linea_tecno;

                }
                else
                {
                    con.Close();
                    return null;

                }

            }
        }

    }
}
