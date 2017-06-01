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
    public partial class FormAmbiente : System.Web.UI.Page
    {
        DTOAmbiente dt = new DTOAmbiente();
        CADAmbiente cd = new CADAmbiente();

        protected void Page_Load(object sender, EventArgs e)
        {
            chafe1.Text = DateTime.Now.ToShortDateString();
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            dt.codigo_amb = Convert.ToInt16(txtcod_ambiente.Text);
            dt.nombre_amb = txtnombre_ambiente.Text;
            dt.capacidad_amb = txtcapacidad_personas.Text;
            dt.estado_amb = txtestado_ambiente.Text;
            cd.insertarAmbiente(dt);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            dt.codigo_amb = Convert.ToInt16(txtcod_ambiente.Text);
            dt.nombre_amb = txtnombre_ambiente.Text;
            dt.capacidad_amb = txtcapacidad_personas.Text;
            dt.estado_amb = txtestado_ambiente.Text;
            cd.modificarAmbiente(dt);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            dt.codigo_amb = Convert.ToInt16(txtcod_ambiente.Text);
            cd.eliminarAmbiente(dt);
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            dt = cd.buscarAmbiente(Convert.ToInt32(txtcod_ambiente.Text));
            txtnombre_ambiente.Text = dt.nombre_amb;
            txtcapacidad_personas.Text = dt.capacidad_amb;
            txtestado_ambiente.Text = dt.estado_amb;
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            DataTable data = cd.listarAmbiente();
            grvAmbientes.DataSource = data;
            grvAmbientes.DataBind();
        }
    }
}