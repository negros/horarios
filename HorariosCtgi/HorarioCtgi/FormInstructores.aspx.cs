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
    public partial class FormInstructores : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            chafe1.Text = DateTime.Now.ToShortDateString();
        }

        protected void Insertar(object sender, EventArgs e)
        {
            DTOInstructores dt = new DTOInstructores();
            dt.Dni_instructor = Convert.ToInt32(txtdni_instruc.Text);
            dt.Nombre_instructor = txtnombre_instrucr.Text;
            dt.Apellido_instructor = txtapellido_instruc.Text;
            dt.Profesion_instructor = txtprefesion_instruc.Text;
            CADInstructores cd = new CADInstructores();
            cd.insertarInstructores(dt);
        }

        

        protected void Consultar(object sender, EventArgs e)
        {
            DTOInstructores dt = new DTOInstructores();
            CADInstructores cd = new CADInstructores();
            dt = cd.buscarInstructores(Convert.ToInt32(txtdni_instruc.Text));
            txtnombre_instrucr.Text = dt.Nombre_instructor;
            txtapellido_instruc.Text = dt.Apellido_instructor;
            txtprefesion_instruc.Text = dt.Profesion_instructor;

        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            CADInstructores cd = new CADInstructores();
            DataTable data = cd.listarInsructores();
            DTVListar.DataSource = data;
            DTVListar.DataBind();
        }
        protected void DTVListar_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            DTOInstructores dt = new DTOInstructores();
            dt.Dni_instructor = Convert.ToInt32(DTVListar.DataKeys[e.RowIndex].Value.ToString());
            CADInstructores cd = new CADInstructores();
            cd.eliminarInstructores(dt);
            btnListar_Click(sender, e);
        }

        //Metodo para habilitar opciones de editar o cancelar
        protected void DTVListar_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DTVListar.EditIndex = e.NewEditIndex;
            btnListar_Click(sender, e);
        }

        //Metodo Actualizar
        protected void DTVListar_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           DTOInstructores dt = new DTOInstructores();
            GridViewRow row = (GridViewRow)DTVListar.Rows[e.RowIndex];

            TextBox textnombre = (TextBox)row.Cells[1].Controls[0];
            TextBox textApellido = (TextBox)row.Cells[2].Controls[0];
            TextBox textprofesion= (TextBox)row.Cells[3].Controls[0];
            dt.Dni_instructor  = Convert.ToInt32(row.Cells[0].Text);
            dt.Nombre_instructor = textnombre.Text;
            dt.Apellido_instructor = textApellido.Text;
            dt.Profesion_instructor = textprofesion.Text;
            CADInstructores cd = new CADInstructores();
            cd.modificarInstructores(dt);
            DTVListar.EditIndex = -1;
            btnListar_Click(sender, e);
        }
        // metodo para paginacion
        protected void DTVListar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DTVListar.PageIndex = e.NewPageIndex;
            btnListar_Click(sender, e);
        }

        //boton cancelar edicion
        protected void DTVListar_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DTVListar.EditIndex = -1;
            btnListar_Click(sender, e);
        }
    }
}