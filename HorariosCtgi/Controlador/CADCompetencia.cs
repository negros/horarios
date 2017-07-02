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
    public class CADCompetencia
    {
        string cadena = ConfigurationManager.ConnectionStrings["conSQLServer"].ConnectionString.ToString();
        DTOCompetencia cohorte = new DTOCompetencia();
        
        SqlCommand cmd = new SqlCommand();
        public void insertarCompetencia(DTOCompetencia cpt)
        {
            try
            {
                SqlConnection con = new SqlConnection(cadena);
                cmd.Connection = con;
                cmd.CommandText = "GestionCompetencias";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@codigo_comp", cpt.codigo_comp);
                cmd.Parameters.AddWithValue("@nombre_comp", cpt.nombre_comp);
                cmd.Parameters.AddWithValue("@descripcion_comp", cpt.descripcion_comp);
                cmd.Parameters.AddWithValue("@id_programa", cpt.id_prog);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

            }

        }

        public void modificarCompetencia(Modelo.DTOCompetencia cpt)
        {
            SqlConnection con = new SqlConnection(cadena);
            cmd.Connection = con;
            cmd.CommandText = "GestionCompetencias";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@codigo_comp", cpt.codigo_comp);
            cmd.Parameters.AddWithValue("@nombre_comp", cpt.nombre_comp);
            cmd.Parameters.AddWithValue("@descripcion_comp", cpt.descripcion_comp);
            cmd.Parameters.AddWithValue("@id_programa", cpt.id_prog);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void eliminarCompetencia(Modelo.DTOCompetencia cpt)
        {
            try
            {
                SqlConnection con = new SqlConnection(cadena);
                cmd.Connection = con;
                cmd.CommandText = "GestionCompetencias";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "delete");
                cmd.Parameters.AddWithValue("@codigo_comp", cpt.codigo_comp);
                cmd.Parameters.AddWithValue("@id_programa", cpt.id_prog);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public Modelo.DTOCompetencia consultarCompetencia(String codigo_comp)
        {
            SqlConnection con = new SqlConnection(cadena);
            Modelo.DTOCompetencia r = new Modelo.DTOCompetencia();
            cmd.Connection = con;
            cmd.CommandText = "GestionCompetencias";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "Search");
            cmd.Parameters.AddWithValue("@codigo_comp", codigo_comp);
     
            con.Open();
            // lector permite acceder a las columnas
            SqlDataReader sdr = cmd.ExecuteReader();
            //la consulta trajo resultados?
            if (sdr.Read())
            {
        
                r.nombre_comp = (Convert.ToString(sdr["nombre_comp"]));
                r.codigo_comp = (Convert.ToString(sdr["codigo_comp"]));
                r.descripcion_comp = (Convert.ToString(sdr["descripcion_comp"]));
         
                sdr.Close();
            }
            return r;
        }


        public DataTable listarCompetencia()
        {
            SqlConnection con = new SqlConnection(cadena);
            cmd.Connection = con;
            cmd.CommandText = "GestionCompetencias";
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            cmd.Parameters.AddWithValue("@action", "list");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
