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
    public partial class FormFicha : System.Web.UI.Page
    {
        DTOFicha ficha = new DTOFicha();
        CADFicha daoficha = new CADFicha();

        protected void Page_Load(object sender, EventArgs e)
        {
            chafe1.Text = DateTime.Now.ToShortDateString();
        }

        protected void GuardarFicha_Click(object sender, EventArgs e)
        {
            ficha.codigo_ficha = Convert.ToInt64(txtcodigo.Text);
            ficha.id_programa = Convert.ToInt16(ddlnombre_programa.SelectedItem.Value);
            ficha.ningregantes_ficha = Convert.ToInt16(txtnintegrante.Text);
            ficha.jornada_ficha = ddljornada.SelectedItem.Value;
            ficha.id_cohorte = Convert.ToInt16(ddlcohorte.SelectedItem.Value);
            daoficha.insertarFicha(ficha);
        }

        protected void BuscarFicha_Click(object sender, EventArgs e)
        {
            ficha = daoficha.ConsultarFicha(Convert.ToInt64(txtcodigo.Text));
            ddlnombre_programa.SelectedValue = ficha.id_programa.ToString();
            txtnintegrante.Text = ficha.ningregantes_ficha.ToString();
            ddljornada.Text = ficha.jornada_ficha;
            ddlcohorte.SelectedValue = ficha.id_cohorte.ToString();
        }

        protected void ListarFicha_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = daoficha.ListarFicha();
            DTVListar.DataSource = dt;
            DTVListar.DataBind();
        }
        protected void DTVListar_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)DTVListar.Rows[e.RowIndex];
            ficha.codigo_ficha = Convert.ToInt64(DTVListar.DataKeys[e.RowIndex].Value.ToString());
             daoficha.eliminarFicha(ficha);
            ListarFicha_Click(sender, e);
        }

        //Metodo para habilitar opciones de editar o cancelar
        protected void DTVListar_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DTVListar.EditIndex = e.NewEditIndex;

            ListarFicha_Click(sender, e);
            DTVListar.Rows[e.NewEditIndex].Cells[2].Visible = false;
            DTVListar.Rows[e.NewEditIndex].Cells[4].Visible = false;
            DTVListar.Rows[e.NewEditIndex].Cells[6].Visible = false;
            DTVListar.Rows[e.NewEditIndex].Cells[3].Visible = true;
            DTVListar.Rows[e.NewEditIndex].Cells[5].Visible = true;
            DTVListar.Rows[e.NewEditIndex].Cells[7].Visible = true;
            DropDownList tid_Programa = (DropDownList)DTVListar.Rows[e.NewEditIndex].Cells[3].Controls[1];
            DropDownList tjornada_ficha = (DropDownList)DTVListar.Rows[e.NewEditIndex].Cells[5].Controls[1];
            DropDownList tid_coho = (DropDownList)DTVListar.Rows[e.NewEditIndex].Cells[7].Controls[1];
            TextBox programaActual = (TextBox)DTVListar.Rows[e.NewEditIndex].Cells[8].Controls[0];
            TextBox cohorteActual = (TextBox)DTVListar.Rows[e.NewEditIndex].Cells[9].Controls[0];
            TextBox jornadaAactual = (TextBox)DTVListar.Rows[e.NewEditIndex].Cells[4].Controls[0];
            String temp = programaActual.Text;
            tid_Programa.SelectedValue = temp;
            temp = cohorteActual.Text;
            tid_coho.SelectedValue = temp;
            temp = jornadaAactual.Text;
            tjornada_ficha.SelectedValue = temp;
        }
        //Metodo Actualizar
        protected void DTVListar_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)DTVListar.Rows[e.RowIndex];
            TextBox tnumeroIntegrantes = (TextBox)row.Cells[1].Controls[0];
            DropDownList tid_Programa = (DropDownList)row.Cells[3].Controls[1];
            DropDownList tjornada_ficha = (DropDownList)row.Cells[5].Controls[1];
            DropDownList tid_coho = (DropDownList)row.Cells[7].Controls[1];
            ficha.codigo_ficha = Convert.ToInt64(row.Cells[0].Text);
            ficha.id_programa = Convert.ToInt32(tid_Programa.SelectedItem.Value);
            ficha.ningregantes_ficha = Convert.ToInt32(tnumeroIntegrantes.Text);
            ficha.jornada_ficha = tjornada_ficha.SelectedItem.Value;
            ficha.id_cohorte = Convert.ToInt32(tid_coho.SelectedItem.Value);
            daoficha.actualizarFicha(ficha);
            DTVListar.EditIndex = -1;
            ListarFicha_Click(sender, e);
        }
        // metodo para paginacion
        protected void DTVListar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DTVListar.PageIndex = e.NewPageIndex;
            ListarFicha_Click(sender, e);
        }

        //boton cancelar edicion
        protected void DTVListar_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DTVListar.EditIndex = -1;
            ListarFicha_Click(sender, e);
        }
        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[2].Visible = true;
            e.Row.Cells[4].Visible = true;
            e.Row.Cells[6].Visible = true;
        }
    }
}