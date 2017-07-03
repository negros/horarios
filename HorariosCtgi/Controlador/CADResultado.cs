using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Modelo;


namespace CAD
{
    public class CADResultado
    {
        string cadena = ConfigurationManager.ConnectionStrings["conSQLServer"].ConnectionString.ToString();

        SqlConnection con;
        SqlCommand cmd;

        public CADResultado()
        {
            con = new SqlConnection(cadena);
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "ProcedureResultado";
            cmd.CommandType = CommandType.StoredProcedure;
        }
        public void insertarResultado(DTOResultado resultado)
        {
            try
            {
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@codigo_resu", resultado.Codigo_resultado);
                cmd.Parameters.AddWithValue("@nombre_resu", resultado.Nombre_resultado);
                //cmd.Parameters.AddWithValue("@horainicio_resu", resultado.Horainicio);
                //cmd.Parameters.AddWithValue("@horafin_resu", resultado.Horafin1);
                cmd.Parameters.AddWithValue("@descripcion_resu", resultado.Descripcion);
                cmd.Parameters.AddWithValue("@id_competencia", resultado.Id_comp);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {

            }
        }

        public void eliminarResultado(DTOResultado resultado)
        {
            try
            {
                cmd.Parameters.AddWithValue("@action", "delete");
                cmd.Parameters.AddWithValue("@codigo_resu", resultado.Codigo_resultado);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {

            }
        }

        public DataTable listarResultados()
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "ProcedureResultado";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "list");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            con.Close();
            return dt;
        }

        public void actualizarResultado(DTOResultado resultado)
        {
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@codigo_resu", resultado.Codigo_resultado);
            cmd.Parameters.AddWithValue("@nombre_resu", resultado.Nombre_resultado);
            //cmd.Parameters.AddWithValue("@horainicio_resu", resultado.Horainicio);
            //cmd.Parameters.AddWithValue("@horafin_resu", resultado.Horafin1);
            cmd.Parameters.AddWithValue("@descripcion_resu", resultado.Descripcion);
            cmd.Parameters.AddWithValue("@id_competencia", resultado.Id_comp);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }




        public DTOResultado BuscarR(string codigo)
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "Search");
            cmd.Parameters.AddWithValue("@codigo_resu", codigo);
            con.Open();
            // lector permite acceder a las columnas
            SqlDataReader sdr = cmd.ExecuteReader();
            //la culta trajo resultados?
            DTOResultado resultado = new DTOResultado();

            if (sdr.Read())
            {
                resultado.Codigo_resultado = (Convert.ToString(sdr["codigo_resu"]));
                resultado.Nombre_resultado = (Convert.ToString(sdr["nombre_resu"]));
                //resultado.Horainicio = TimeSpan.Parse(sdr["horainicio_resu"].ToString());
                //resultado.Horafin1 = TimeSpan.Parse(sdr["horafin_resu"].ToString());
                resultado.Descripcion = (Convert.ToString(sdr["descripcion_resu"]));
                resultado.Id_comp = int.Parse(Convert.ToString(sdr["id_comp"]));
                sdr.Close();
            }
            return resultado;
        }
    }

}



