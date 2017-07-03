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
    public partial class FormResultado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            chafe1.Text = DateTime.Now.ToShortDateString();
        }
        DTOResultado resultado = new DTOResultado();
        CADResultado cad = new CADResultado();
        protected void Insertar_Click(object sender, EventArgs e)
        {
            resultado.Nombre_resultado = txtnombre.Text;
            resultado.Codigo_resultado = txtcodigo.Text;
            resultado.Descripcion = txtdescripcion.Text;
            resultado.Id_comp = Convert.ToInt16(competencia.SelectedItem.Value);
            try
            {
                cad.insertarResultado(resultado);
            }
            catch (Exception ex)
            {

            }
        }

        protected void Consultar_Click(object sender, EventArgs e)
        {

            resultado = cad.BuscarR(txtcodigo.Text);
            txtnombre.Text = resultado.Nombre_resultado;
            txtcodigo.Text = resultado.Codigo_resultado.ToString();
            txtdescripcion.Text = resultado.Descripcion;
            //txthorai.Text = Convert.ToString(resultado.Horainicio);
            //txthoraf.Text = Convert.ToString(resultado.Horafin1);
            competencia.Text = Convert.ToString(resultado.Id_comp);
        }

        protected void Listar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = cad.listarResultados();
                grvResultado.DataSource = dt;
                grvResultado.DataBind();

            }
            catch (Exception ex)
            {

            }
        }


        protected void DTVListar_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            resultado.Codigo_resultado = grvResultado.DataKeys[e.RowIndex].Value.ToString();
            cad.eliminarResultado(resultado);
            Listar_Click(sender, e);
        }

        //Metodo para habilitar opciones de editar o cancelar
        protected void DTVListar_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvResultado.EditIndex = e.NewEditIndex;
            Listar_Click(sender, e);
            grvResultado.Rows[e.NewEditIndex].Cells[3].Visible = false;
            grvResultado.Rows[e.NewEditIndex].Cells[4].Visible = true;
            DropDownList ddlCompetencia = (DropDownList)grvResultado.Rows[e.NewEditIndex].Cells[4].Controls[1];
            TextBox competenciaActual = (TextBox)grvResultado.Rows[e.NewEditIndex].Cells[5].Controls[0];
            ddlCompetencia.SelectedValue = competenciaActual.Text;
        }

        //Metodo Actualizar
        protected void DTVListar_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        GridViewRow row = (GridViewRow)grvResultado.Rows[e.RowIndex];

            TextBox textnombre = (TextBox)row.Cells[1].Controls[0];
            TextBox textDescripcion = (TextBox)row.Cells[2].Controls[0];
            DropDownList tidCompetencia = (DropDownList)row.Cells[4].Controls[1];
            resultado.Codigo_resultado = row.Cells[0].Text;
            resultado.Nombre_resultado = textnombre.Text;
            resultado.Descripcion = textDescripcion.Text;
            resultado.Id_comp = Convert.ToInt32(tidCompetencia.SelectedItem.Value);
            cad.actualizarResultado(resultado);
            grvResultado.EditIndex = -1;
            Listar_Click(sender, e);
        }
        // metodo para paginacion
        protected void DTVListar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvResultado.PageIndex = e.NewPageIndex;
            Listar_Click(sender, e);
        }

        //boton cancelar edicion
        protected void DTVListar_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvResultado.EditIndex = -1;
            Listar_Click(sender, e);
        }

        protected void DTVListar_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[3].Visible = true;
        }
    }

}