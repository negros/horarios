using CAD;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HorarioCtgi
{
    public partial class FormResultado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            chafe1.Text = DateTime.Now.ToShortDateString();
        }
        DTOResultado resultado = new DTOResultado();
        CADResultado cad = new CADResultado();
        protected void Insertar_Click(object sender, EventArgs e)
        {
            resultado.Nombre_resultado = txtnombre.Text;
            resultado.Codigo_resultado = txtcodigo.Text;
            //resultado.Horainicio = TimeSpan.Parse(txthorai.Text);
            //resultado.Horafin1 = TimeSpan.Parse(txthoraf.Text);
            resultado.Descripcion = txtdescripcion.Text;
            resultado.Id_comp = Convert.ToInt16(competencia.SelectedItem.Value);
            try
            {
                cad.insertarResultado(resultado);
            }
            catch (Exception ex)
            {

            }
        }

        protected void Modificar_Click(object sender, EventArgs e)
        {
            resultado.Nombre_resultado = txtnombre.Text;
            resultado.Codigo_resultado = txtcodigo.Text;
            //resultado.Horainicio = TimeSpan.Parse(txthorai.Text);
            //resultado.Horafin1 = TimeSpan.Parse(txthoraf.Text);
            resultado.Descripcion = txtdescripcion.Text;
            resultado.Id_comp = Convert.ToInt16(competencia.SelectedItem.Value);
            try
            {
                cad.actualizarResultado(resultado);
            }
            catch (Exception ex)
            {

            }
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                resultado.Codigo_resultado = txtcodigo.Text;
                cad.eliminarResultado(resultado);
            }
            catch (Exception ex)
            {

            }
        }

        protected void Consultar_Click(object sender, EventArgs e)
        {

            resultado = cad.BuscarR(txtcodigo.Text);
            txtnombre.Text = resultado.Nombre_resultado;
            txtcodigo.Text = resultado.Codigo_resultado.ToString();
            txtdescripcion.Text = resultado.Descripcion;
            //txthorai.Text = Convert.ToString(resultado.Horainicio);
            //txthoraf.Text = Convert.ToString(resultado.Horafin1);
            competencia.Text = Convert.ToString(resultado.Id_comp);
        }

        protected void Listar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = cad.listarResultados();
                grvResultado.DataSource = dt;
                grvResultado.DataBind();

            }
            catch (Exception ex)
            {

            }
        }
    }

}