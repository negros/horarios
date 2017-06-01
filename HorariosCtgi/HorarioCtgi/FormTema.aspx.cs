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
            grvAmbientes.DataSource = data;
            grvAmbientes.DataBind();
        }
    }
}