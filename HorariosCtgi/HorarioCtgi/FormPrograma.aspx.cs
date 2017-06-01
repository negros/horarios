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
    public partial class FormPrograma : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            chafe1.Text = DateTime.Now.ToShortDateString();
        }

        DTOPrograma cpts = new DTOPrograma();
        CADPrograma datos = new CADPrograma();

        protected void Ingresar_Click(object sender, EventArgs e)
        {
            cpts.cod_programa = Convert.ToInt32(cod_programa.Text);
            cpts.nombre_prog = nombre_prog.Text;
            cpts.version_prog = version_prog.Text;
            cpts.descripcion_prog = descripcion_prog.Text;
            cpts.id_linea = Convert.ToInt32(lintec.SelectedItem.Value);
            datos.insertarPrograma(cpts);
        }

        protected void Modificar_Click(object sender, EventArgs e)
        {
            cpts.cod_programa = Convert.ToInt32(cod_programa.Text);
            cpts.nombre_prog = nombre_prog.Text;
            cpts.version_prog = version_prog.Text;
            cpts.descripcion_prog = descripcion_prog.Text;
            cpts.id_linea = Convert.ToInt32(lintec.SelectedItem.Value);
            datos.modificar(cpts);
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            cpts = datos.buscar(Convert.ToInt32(cod_programa.Text));
            nombre_prog.Text = cpts.nombre_prog;
            version_prog.Text = cpts.version_prog;
            descripcion_prog.Text = cpts.descripcion_prog;
            lintec.SelectedValue = Convert.ToString(cpts.id_linea);
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            cpts.cod_programa = Convert.ToInt32(cod_programa.Text);
            datos.eliminar(cpts);
        }

        protected void Listar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = datos.listar();
            DTVListar.DataSource = dt;
            DTVListar.DataBind();
        }


    }
}