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
   
    public partial class FormTema : System.Web.UI.Page
    {
       
      
        protected void Page_Load(object sender, EventArgs e)
        {
            chafe1.Text = DateTime.Now.ToShortDateString();
           
        }
        protected void Insertar(object sender, EventArgs e)
        {
            //try
            //{
            //    if (String.IsNullOrEmpty(txtcod_tema.Text) ||
            //        String.IsNullOrEmpty(txtnombre_tema.Text) || String.IsNullOrEmpty(txtdescripcion_tema.Text))
            //    {
            //        Response.Write("<script>window.alert('Por favor ingresar todos los campos');</script>");

            //    }
            //    else
            //    {
            DTOTemas dt = new DTOTemas();
            dt.Codigo_tema = txtcod_tema.Text;
            dt.Nombre_tema = txtnombre_tema.Text;
            dt.Descripcion_tema = txtdescripcion_tema.Text;
            dt.Id_resultado = int.Parse(resultado.SelectedValue);
            CADTemas cd = new CADTemas();
            cd.insertarTemas(dt);
            //        if (cd.insertarTemas(dt))
            //        {
            //            Response.Write("<script>window.alert('guardado exitosamente');</script>");

            //        }
            //        else
            //        {

            //            Response.Write("<script>window.alert('error al insertar');</script>");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //    Response.Write("<script>window.alert('error al insertar');</script>");
            //}
        }

        protected void Modificar(object sender, EventArgs e)
        {
            //try
            //{
            //    if (String.IsNullOrEmpty(txtcod_tema.Text) ||
            //        String.IsNullOrEmpty(txtnombre_tema.Text) || String.IsNullOrEmpty(txtdescripcion_tema.Text))
            //    {
            //        Response.Write("<script>window.alert('Por favor ingresar todos los campos');</script>");

            //    }
            //    else
            //    {
            DTOTemas dt = new DTOTemas();
            dt.Codigo_tema = txtcod_tema.Text;
            dt.Nombre_tema = txtnombre_tema.Text;
            dt.Descripcion_tema = txtdescripcion_tema.Text;
            dt.Id_resultado = int.Parse(resultado.SelectedValue);
            CADTemas cd = new CADTemas();
            cd.modificarTemas(dt);
            //        if (cd.modificarTemas(dt))
            //        {
            //            Response.Write("<script>window.alert('modificado exitosamente');</script>");

            //        }
            //        else
            //        {

            //            Response.Write("<script>window.alert('error al modificar');</script>");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("<script>window.alert('error al modificar');</script>");

            //}
        }

        protected void Eliminar(object sender, EventArgs e)
        {
            //try
            //{
            //    if (String.IsNullOrEmpty(txtcod_tema.Text))
            //    {
            //        Response.Write("<script>window.alert('Por favor ingresar el codigo del ambiente');</script>");

            //    }
            //    else
            //    {
            DTOTemas dt = new DTOTemas();
            dt.Codigo_tema = txtcod_tema.Text;
            CADTemas cd = new CADTemas();
            cd.eliminarTemas(dt);
            //        if (cd.eliminarTemas(dt))
            //        {
            //            Response.Write("<script>window.alert('eliminar exitosamente');</script>");

            //        }
            //        else
            //        {

            //            Response.Write("<script>window.alert('error al eliminar');</script>");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("<script>window.alert('error al eliminar');</script>");
            //}

        }

        protected void Consultar(object sender, EventArgs e)
        {
            //try
            //{

            //    if (String.IsNullOrEmpty(txtcod_tema.Text))
            //    {
            //        Response.Write("<script>window.alert('Por favor ingresar el codigo del ambiente');</script>");

            //    }
            //    else
            //    {

            DTOTemas dt = new DTOTemas();
            CADTemas cd = new CADTemas();
            dt = cd.buscarTemas(txtcod_tema.Text);
            //if (dt == null)
            //{
            //    Response.Write("<script>window.alert('el codigo no exixte');</script>");

            //}
            //else
            //{
            txtnombre_tema.Text = dt.Nombre_tema;
            txtdescripcion_tema.Text = dt.Descripcion_tema;
            resultado.SelectedValue = Convert.ToString(dt.Id_resultado);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("<script>window.alert('error inesperado');</script>");

            //}
        }

    
        protected void btnListar_Click(object sender, EventArgs e)
        {
            CADTemas cd = new CADTemas();
            DataTable data = cd.listarTemas();
            DTVListar.DataSource = data;
            DTVListar.DataBind();
        }

        protected void DTVListar_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DTOTemas dt = new DTOTemas();
            dt.Codigo_tema = DTVListar.DataKeys[e.RowIndex].Value.ToString();
            CADTemas cd = new CADTemas();
            cd.eliminarTemas(dt);
            btnListar_Click(sender, e);
        }

        //Metodo para habilitar opciones de editar o cancelar
        protected void DTVListar_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DTVListar.EditIndex = e.NewEditIndex;
            btnListar_Click(sender, e);
            DTVListar.Rows[e.NewEditIndex].Cells[3].Visible = false;
            DTVListar.Rows[e.NewEditIndex].Cells[4].Visible = true;
            DropDownList ddlResultado = (DropDownList)DTVListar.Rows[e.NewEditIndex].Cells[4].Controls[1];
            TextBox resultadoActual = (TextBox)DTVListar.Rows[e.NewEditIndex].Cells[5].Controls[0];
            ddlResultado.SelectedValue = resultadoActual.Text;
          


        }

        //Metodo Actualizar
        protected void DTVListar_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DTOTemas dt = new DTOTemas();
            GridViewRow row = (GridViewRow)DTVListar.Rows[e.RowIndex];

            TextBox textnombre = (TextBox)row.Cells[1].Controls[0];
            TextBox textDescripcion = (TextBox)row.Cells[2].Controls[0];
            DropDownList tidresultado = (DropDownList)row.Cells[4].Controls[1];
            dt.Codigo_tema = row.Cells[0].Text;
            dt.Nombre_tema = textnombre.Text;
            dt.Descripcion_tema = textDescripcion.Text;
            dt.Id_resultado = Convert.ToInt32(tidresultado.SelectedItem.Value);
            CADTemas cd = new CADTemas();
            cd.modificarTemas(dt);
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

        protected void DTVListar_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[5].Visible = false;
          
                     e.Row.Cells[4].Visible = false;
                e.Row.Cells[3].Visible = true;
            
        }
    }
}