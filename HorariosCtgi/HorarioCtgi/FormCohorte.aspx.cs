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
    public partial class FormCohorte : System.Web.UI.Page
    {
        DTOCohorte cohorte = new DTOCohorte();
        CADCohorte datoc = new CADCohorte();

        protected void Page_Load(object sender, EventArgs e)
        {
            chafe1.Text = DateTime.Now.ToShortDateString();
        }

        protected void GuardarCohorte_Click(object sender, EventArgs e)
        {
            cohorte.codigo_cohorte = Convert.ToInt64(txtcodigo.Text);
            cohorte.nombre_cohorte = txtnombre.Text;
            cohorte.fecha_inicio = Convert.ToDateTime(txtfecha_inicio.Text);
            cohorte.fecha_fin = Convert.ToDateTime(txtfecha_fin.Text);
            cohorte.año_cohorte = txtano.Text;
            cohorte.trimestre_cohorte = Convert.ToInt16(ddltrimestre.Text);
            datoc.insertarCohorte(cohorte);
        }

        protected void EliminarCohorte_Click(object sender, EventArgs e)
        {
           
        }


        protected void BuscarCohorte_Click(object sender, EventArgs e)
        {
            cohorte = datoc.ConsultarCohorte(txtcodigo.Text);
            txtcodigo.Text = Convert.ToString(cohorte.codigo_cohorte);
            txtnombre.Text = cohorte.nombre_cohorte;
            txtfecha_inicio.Text = cohorte.fecha_inicio.ToString("yyyy-MM-dd");
            txtfecha_fin.Text = cohorte.fecha_fin.ToString("yyyy-MM-dd");
            txtano.Text = cohorte.año_cohorte;
            ddltrimestre.Text = Convert.ToString(cohorte.trimestre_cohorte);
        }

        protected void ListarCohorte_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = datoc.ListarCohorte();
            DTVListar.DataSource = dt;
            DTVListar.DataBind();
        }
        // Metodo para borrar registros a traves de la GridView 
        protected void DTVListar_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
        }

        //Metodo para habilitar opciones de editar o cancelar
        protected void DTVListar_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DTVListar.EditIndex = e.NewEditIndex;
            ListarCohorte_Click(sender, e);
        }

        //Metodo Actualizar
        protected void DTVListar_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)DTVListar.Rows[e.RowIndex];
         
            TextBox textnombre = (TextBox)row.Cells[1].Controls[0];
            TextBox textfecha_inicio = (TextBox)row.Cells[2].Controls[0];
            TextBox textfecha_fin = (TextBox)row.Cells[3].Controls[0];
            TextBox textano = (TextBox)row.Cells[4].Controls[0];
            TextBox textTrimeste = (TextBox)row.Cells[5].Controls[0];
            cohorte.codigo_cohorte = Convert.ToInt64(row.Cells[0].Text);
            cohorte.nombre_cohorte = textnombre.Text;
            cohorte.fecha_inicio = Convert.ToDateTime(textfecha_inicio.Text);
            cohorte.fecha_fin = Convert.ToDateTime(textfecha_fin.Text);
            cohorte.año_cohorte = textano.Text;
            cohorte.trimestre_cohorte = Convert.ToInt32(textTrimeste.Text);
            datoc.actualizarCohorte(cohorte);
            DTVListar.EditIndex = -1;
            ListarCohorte_Click(sender, e);
        }
        // metodo para paginacion
        protected void DTVListar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DTVListar.PageIndex = e.NewPageIndex;
            ListarCohorte_Click(sender, e);
        }

        //boton cancelar edicion
        protected void DTVListar_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DTVListar.EditIndex = -1;
            ListarCohorte_Click(sender, e);
        }
    }
}