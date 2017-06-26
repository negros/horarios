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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)grvAmbientes.Rows[e.RowIndex];
            Label lbldeleteid = (Label)row.FindControl("lblID");
            
            Console.Write(grvAmbientes.DataKeys[e.RowIndex].Value.ToString());
           dt.codigo_amb = Convert.ToInt16(grvAmbientes.DataKeys[e.RowIndex].Value.ToString());
            cd.eliminarAmbiente(dt);
            btnListar_Click(sender,e);
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvAmbientes.EditIndex = e.NewEditIndex;
            btnListar_Click(sender, e);
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int userid = Convert.ToInt32(grvAmbientes.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)grvAmbientes.Rows[e.RowIndex];
            Label lblID = (Label)row.FindControl("lblID");
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
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvAmbientes.PageIndex = e.NewPageIndex;
            btnListar_Click(sender, e);
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvAmbientes.EditIndex = -1;
            btnListar_Click(sender, e);
        }
    }

}