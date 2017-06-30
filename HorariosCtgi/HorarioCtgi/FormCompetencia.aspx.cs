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
    public partial class FormCompetencia : System.Web.UI.Page
    {
        DTOCompetencia cpts = new DTOCompetencia();
        CADCompetencia datos = new CADCompetencia();
       

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Ingresar_Click(object sender, EventArgs e)
        {            
            cpts.codigo_comp = codigo_comp.Text;
            cpts.nombre_comp = nombre_comp.Text;
            cpts.descripcion_comp = descripcion_comp.Text;
            cpts.id_prog = Convert.ToInt32(programa.SelectedItem.Value);
            datos.insertarCompetencia(cpts);
        }


        protected void Buscar_Click(object sender, EventArgs e)
        {
            cpts = datos.consultarCompetencia(codigo_comp.Text);
            codigo_comp.Text = cpts.codigo_comp;
            nombre_comp.Text = cpts.nombre_comp;
            descripcion_comp.Text = cpts.descripcion_comp;
        }

        protected void Listar_Click(object sender, EventArgs e)
        {
            try
            {
                CADCompetencia datos = new CADCompetencia();
                DataTable dt = new DataTable();
                dt = datos.listarCompetencia();
                grvCompetencia.DataSource = dt;
                grvCompetencia.DataBind();

            }
            catch (Exception ex)
            {

            }
        }

        // Metodo para borrar registros a traves de la GridView 
        protected void grvCompetencia_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            GridViewRow row = (GridViewRow)grvCompetencia.Rows[e.RowIndex];
            cpts.codigo_comp = grvCompetencia.DataKeys[e.RowIndex].Value.ToString();
            cpts.id_prog = Convert.ToInt32(row.Cells[4].Text);
            datos.eliminarCompetencia(cpts);
            Listar_Click(sender, e);
        }

        //Metodo para habilitar opciones de editar o cancelar
        protected void grvCompetencia_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvCompetencia.EditIndex = e.NewEditIndex;
         
            Listar_Click(sender, e);
            grvCompetencia.Rows[e.NewEditIndex].Cells[3].Visible = false;
            grvCompetencia.Rows[e.NewEditIndex].Cells[5].Visible = true;
            DropDownList tid_Programa = (DropDownList)grvCompetencia.Rows[e.NewEditIndex].Cells[5].Controls[1];
            TextBox programaAactual= (TextBox)grvCompetencia.Rows[e.NewEditIndex].Cells[4].Controls[0];
            String temp = programaAactual.Text; 
            tid_Programa.SelectedValue=temp;
        }
        //Metodo Actualizar
        protected void grvCompetencia_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)grvCompetencia.Rows[e.RowIndex];
            TextBox tnombre_comp = (TextBox)row.Cells[1].Controls[0];
            TextBox tdescripcion_comp = (TextBox)row.Cells[2].Controls[0];
            DropDownList tid_Programa=(DropDownList)row.Cells[5].Controls[1];
            cpts.codigo_comp = row.Cells[0].Text;
            cpts.nombre_comp = tnombre_comp.Text;
            cpts.descripcion_comp = tdescripcion_comp.Text;
           cpts.id_prog = Convert.ToInt32(tid_Programa.SelectedItem.Value);
            datos.modificarCompetencia(cpts);
            grvCompetencia.EditIndex = -1;
           
            Listar_Click(sender, e);
        }
        // metodo para paginacion
        protected void grvCompetencia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvCompetencia.PageIndex = e.NewPageIndex;
            Listar_Click(sender, e);
        }

        //boton cancelar edicion
        protected void grvCompetencia_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvCompetencia.EditIndex = -1;
            Listar_Click(sender, e);
        }
        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;

                e.Row.Cells[3].Visible = true;
                
            
        }
    }
}