using Controlador;
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
    public partial class FormCompetencia : System.Web.UI.Page
    {
        DTOCompetencia cpts = new DTOCompetencia();
        CADCompetencia datos = new CADCompetencia();

        protected void Page_Load(object sender, EventArgs e)
        {
            chafe1.Text = DateTime.Now.ToShortDateString();
        }

        protected void Ingresar_Click(object sender, EventArgs e)
        {            
            cpts.codigo_comp = codigo_comp.Text;
            cpts.nombre_comp = nombre_comp.Text;
            cpts.descripcion_comp = descripcion_comp.Text;
            cpts.id_prog = Convert.ToInt16(programa.SelectedItem.Value);
            datos.insertarCompetencia(cpts);
        }

        protected void Modificar_Click(object sender, EventArgs e)
        {

            cpts.codigo_comp = codigo_comp.Text;
            cpts.nombre_comp = nombre_comp.Text;
            cpts.descripcion_comp = descripcion_comp.Text;
            datos.modificarCompetencia(cpts);
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            cpts.id_prog = Convert.ToInt16(programa.SelectedItem.Value);
            cpts.codigo_comp = codigo_comp.Text;
            datos.eliminarCompetencia(cpts);
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            cpts = datos.consultarCompetencia(codigo_comp.Text);
            codigo_comp.Text = cpts.codigo_comp;
            nombre_comp.Text = cpts.nombre_comp;
            descripcion_comp.Text = cpts.descripcion_comp;
        }

        protected void Listar_Click(object sender, EventArgs e)
        {
            try
            {
                CADCompetencia datos = new CADCompetencia();
                DataTable dt = new DataTable();
                dt = datos.listarCompetencia();
                grvCompetencia.DataSource = dt;
                grvCompetencia.DataBind();

            }
            catch (Exception ex)
            {

            }
        }
    }
}