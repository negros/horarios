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



        protected void Buscar_Click(object sender, EventArgs e)
        {
            cpts = datos.buscar(Convert.ToInt32(cod_programa.Text));
            nombre_prog.Text = cpts.nombre_prog;
            version_prog.Text = cpts.version_prog;
            descripcion_prog.Text = cpts.descripcion_prog;
            lintec.SelectedValue = Convert.ToString(cpts.id_linea);
        }



        protected void Listar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = datos.listar();
            DTVListar.DataSource = dt;
            DTVListar.DataBind();
        }
        protected void DTVListar_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                cpts.cod_programa = Convert.ToInt32(DTVListar.DataKeys[e.RowIndex].Value.ToString());
                datos.eliminar(cpts);
            }
            catch
            {
                Response.Write("<script>window.alert('Error inesperado');</script>");
            }
            finally
            {
                Listar_Click(sender, e);
            }
        }

        //Metodo para habilitar opciones de editar o cancelar
        protected void DTVListar_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                DTVListar.EditIndex = e.NewEditIndex;
                Listar_Click(sender, e);
                DTVListar.Rows[e.NewEditIndex].Cells[4].Visible = false;
                DTVListar.Rows[e.NewEditIndex].Cells[5].Visible = true;
                DropDownList ddlLinea = (DropDownList)DTVListar.Rows[e.NewEditIndex].Cells[5].Controls[1];
                TextBox lineaActual = (TextBox)DTVListar.Rows[e.NewEditIndex].Cells[6].Controls[0];
                ddlLinea.SelectedValue = lineaActual.Text;
            }
            catch
            {
                Response.Write("<script>window.alert('Error inesperado');</script>");
                DTVListar.EditIndex = -1;
                Listar_Click(sender, e);
            }
        }

        //Metodo Actualizar
        protected void DTVListar_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)DTVListar.Rows[e.RowIndex];
                TextBox textnombre = (TextBox)row.Cells[1].Controls[0];
                TextBox textDescripcion = (TextBox)row.Cells[2].Controls[0];
                TextBox textVersion = (TextBox)row.Cells[3].Controls[0];
                DropDownList tidLinea = (DropDownList)row.Cells[5].Controls[1];
                cpts.cod_programa = Convert.ToInt32(row.Cells[0].Text);
                cpts.nombre_prog = textnombre.Text;
                cpts.descripcion_prog = textDescripcion.Text;
                cpts.version_prog = textVersion.Text;
                cpts.id_linea = Convert.ToInt32(tidLinea.SelectedItem.Value);

                if (String.IsNullOrEmpty(cpts.nombre_prog) || String.IsNullOrEmpty(cpts.version_prog) || String.IsNullOrEmpty(cpts.id_linea.ToString()))
                {
                    Response.Write("<script>window.alert('los campos con * son obligatorios');</script>");
                }
                else
                {
                    datos.modificar(cpts);
                    DTVListar.EditIndex = -1;
                    Listar_Click(sender, e);
                }
            }
            catch
            {
                Response.Write("<script>window.alert('Error inesperado');</script>");
                DTVListar.EditIndex = -1;
                Listar_Click(sender, e);
            }
        }
        // metodo para paginacion
        protected void DTVListar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DTVListar.PageIndex = e.NewPageIndex;
            Listar_Click(sender, e);
        }

        //boton cancelar edicion
        protected void DTVListar_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DTVListar.EditIndex = -1;
            Listar_Click(sender, e);
        }

        protected void DTVListar_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[4].Visible = true;
        }

   

    }
}