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
            dt.codigo_amb = Convert.ToInt32(txtcod_ambiente.Text);
            dt.nombre_amb = txtnombre_ambiente.Text;
            dt.capacidad_amb = txtcapacidad_personas.Text;
            dt.estado_amb = txtestado_ambiente.Text;
            cd.insertarAmbiente(dt);
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

        // Metodo para borrar registros a traves de la GridView 
        protected void grvAmbientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)grvAmbientes.Rows[e.RowIndex];
            dt.codigo_amb = Convert.ToInt32(grvAmbientes.DataKeys[e.RowIndex].Value.ToString());
            cd.eliminarAmbiente(dt);
            btnListar_Click(sender,e);
        }

        //Metodo para habilitar opciones de editar o cancelar
        protected void grvAmbientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvAmbientes.EditIndex = e.NewEditIndex;
            btnListar_Click(sender, e);
        }

        //Metodo Actualizar
        protected void grvAmbientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)grvAmbientes.Rows[e.RowIndex];
            TextBox textCodAmb = (TextBox)row.Cells[0].Controls[0];
            TextBox textNombreAmb= (TextBox)row.Cells[1].Controls[0];
            TextBox textCapacidadAmb= (TextBox)row.Cells[2].Controls[0];
            TextBox textEstadoAmb = (TextBox)row.Cells[3].Controls[0];
            dt.codigo_amb = Convert.ToInt32(textCodAmb.Text);
            dt.nombre_amb = textNombreAmb.Text;
            dt.capacidad_amb = textCapacidadAmb.Text;
            dt.estado_amb = textEstadoAmb.Text;
            cd.modificarAmbiente(dt);
            grvAmbientes.EditIndex = -1;
            btnListar_Click(sender, e);
        }
        // metodo para paginacion
        protected void grvAmbientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvAmbientes.PageIndex = e.NewPageIndex;
            btnListar_Click(sender, e);
        }

        //boton cancelar edicion
        protected void grvAmbientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvAmbientes.EditIndex = -1;
            btnListar_Click(sender, e);
        }
    }

}