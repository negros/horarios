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
    public partial class FormLineaTecno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            chafe1.Text = DateTime.Now.ToShortDateString();
        }

        Modelo.DTOLinea_tecno dt = new DTOLinea_tecno();
        CADLinea_tecno cd = new CADLinea_tecno();

        protected void Insertar(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtnombre_linea_tecno.Text))
                {
                    Response.Write("<script>window.alert('Por favor ingresar todos los campos');</script>");
                }
                else
                {
                    dt.nombre_linea_tecno = txtnombre_linea_tecno.Text;
                    
                    if (cd.insertarLinea_tecno(dt))
                    {
                        Response.Write("<script>window.alert('guardado exitosamente');</script>");

                    }
                    else
                    {

                        Response.Write("<script>window.alert('error al insertar');</script>");
                    }
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>window.alert('error al insertar');</script>");
            }
        }




     


        protected void Listar(object sender, EventArgs e)
        {
            DataTable data = cd.ListarLinea_tecno();
            DTVListar.DataSource = data;
            DTVListar.DataBind();
        }

        protected void DTVListar_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                 
                dt.id_linea_tecno = Convert.ToInt32(DTVListar.DataKeys[e.RowIndex].Value.ToString());
                

                if (cd.borrarLinea_tecno(dt))
                {
                    Response.Write("<script>window.alert('Eliminado exitosamente');</script>");

                }
                else
                {

                    Response.Write("<script>window.alert('Error al eliminar');</script>");
                }


            }
            catch
            {
                Response.Write("<script>window.alert('Error inesperado');</script>");

            }
            finally
            {
                Listar(sender, e);
            }
        }

        //Metodo para habilitar opciones de editar o cancelar
        protected void DTVListar_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DTVListar.EditIndex = e.NewEditIndex;
            Listar(sender, e);
        }

        //Metodo Actualizar
        protected void DTVListar_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


            try
            {
                
                GridViewRow row = (GridViewRow)DTVListar.Rows[e.RowIndex];
                TextBox textnombre = (TextBox)row.Cells[1].Controls[0];
                dt.id_linea_tecno = Convert.ToInt32(row.Cells[0].Text);
                dt.nombre_linea_tecno = textnombre.Text;
                if (String.IsNullOrEmpty(dt.nombre_linea_tecno))
                {
                    Response.Write("<script>window.alert('los campos con * son obligatorios');</script>");
                }
                else
                {
                    
                    if (cd.actualizarLinea_tecno(dt))
                    {
                        Response.Write("<script>window.alert('Modificado exitosamente');</script>");

                    }
                    else
                    {

                        Response.Write("<script>window.alert('error al Modificar');</script>");
                    }
                    DTVListar.EditIndex = -1;
                    Listar(sender, e);
                }
               
            }
            catch
            {
                Response.Write("<script>window.alert('Error inesperado');</script>");
                DTVListar.EditIndex = -1;
                Listar(sender, e);
            }
        }
        // metodo para paginacion
        protected void DTVListar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DTVListar.PageIndex = e.NewPageIndex;
            Listar(sender, e);
        }

        //boton cancelar edicion
        protected void DTVListar_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DTVListar.EditIndex = -1;
            Listar(sender, e);
        }


    }
}