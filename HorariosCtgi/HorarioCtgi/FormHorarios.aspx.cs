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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            chafe1.Text = DateTime.Now.ToShortDateString();
        }

        DTOHorario dt = new DTOHorario();
        CADHorario cd = new CADHorario();

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            CADValidaciones val = new CADValidaciones();
            DTOHorario dt2 = new DTOHorario();
            dt.codigo_asig = txtcod_asig.Text;
            dt.fechainicio_asig = Convert.ToDateTime(txtfecha_ini.Text);
            dt.fechafin_asig = Convert.ToDateTime(txtfecha_fin.Text);
            dt.horainicio_asig = Convert.ToDateTime(txthora_ini.Text);
            dt.horafin_asig = Convert.ToDateTime(txthora_fin.Text);
            dt.dia_asig = ddldia_asig.Text;
            dt.descripcion_asig = txtdescripcion_asig.Text;
            dt.id_amb = Convert.ToInt32(ambiente.Text);
            dt.id_ficha = Convert.ToInt32(ficha.Text);
            dt.id_resul = Convert.ToInt32(resultado.Text);
            dt.id_instru = Convert.ToInt32(instructor.Text);



            if ((dt2 = val.verificarAsignacion(dt)) != null)
            {
                if (dt2.id_amb == dt.id_amb)
                {
                    Response.Write("<script>window.alert('El ambiente: " + dt2.nombre_amb + " se encuntra ocupado hasta las: " + dt2.horafin_asig.ToString("HH:mm") + " con la ficha: " + dt2.codigo_ficha + " y el Instructor: " + dt2.nombre_Instru + " por la asignacion: " + dt2.codigo_asig + "');</script>");
                }
                else if (dt2.id_ficha == dt.id_ficha)
                {
                    Response.Write("<script>window.alert('La ficha: " + dt2.codigo_ficha + "  se encuntra ocupada hasta las: " + dt2.horafin_asig.ToString("HH:mm") + " en el ambiente: " + dt2.nombre_amb + " y el Instructor: " + dt2.nombre_Instru + " por la asignacion: " + dt2.codigo_asig + "');</script>");
                }
                else if (dt2.id_instru == dt.id_instru)
                {
                    Response.Write("<script>window.alert('El instructor: " + dt2.nombre_Instru + " se encuntra ocupado hasta las: " + dt2.horafin_asig.ToString("HH:mm") + " con la ficha: " + dt2.codigo_ficha + " en el ambiente: " + dt2.nombre_amb + " por la asignacion: " + dt2.codigo_asig + "');</script>");
                }

            }
            else
            {
                int i;

                TimeSpan ts = dt.horafin_asig - dt.horainicio_asig;

                if ((i = (val.verificarhoras(dt.id_instru) + ((ts.Hours * 60) + (ts.Minutes)))) >= 2100)
                {
                    int horas = i / 60;
                    int minutos = i % 60;
                    Response.Write("<script>window.alert('El instructor tiene asignadas: " + horas + ":" + minutos + " Horas');</script>");
                }
                cd.insertarAsignacion(dt);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            dt = new DTOHorario();
            dt.codigo_asig = txtcod_asig.Text;
            dt.fechainicio_asig = Convert.ToDateTime(txtfecha_ini.Text);
            dt.fechafin_asig = Convert.ToDateTime(txtfecha_fin.Text);
            dt.horainicio_asig = Convert.ToDateTime(txthora_ini.Text);
            dt.horafin_asig = Convert.ToDateTime(txthora_fin.Text);
            dt.dia_asig = ddldia_asig.Text;
            dt.descripcion_asig = txtdescripcion_asig.Text;
            dt.id_amb = Convert.ToInt32(ambiente.Text);
            dt.id_ficha = Convert.ToInt32(ficha.Text);
            dt.id_resul = Convert.ToInt32(resultado.Text);
            dt.id_instru = Convert.ToInt32(instructor.Text);
            cd.modificarAsignacion(dt);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            cd.deleteAsignacion(txtcod_asig.Text);
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            DTOHorario dt1 = new DTOHorario();
            CADHorario cd1 = new CADHorario();
            dt1 = cd1.buscarAsignacion(txtcod_asig.Text);
            txtfecha_ini.Text = dt1.fechainicio_asig.ToString("yyyy-MM-dd");
            txtfecha_fin.Text = dt1.fechafin_asig.ToString("yyyy-MM-dd");
            txthora_ini.Text = dt1.horainicio_asig.ToString("HH:mm");
            txthora_fin.Text = dt1.horafin_asig.ToString("HH:mm");
            ddldia_asig.SelectedValue = dt1.dia_asig;
            txtdescripcion_asig.Text = dt1.descripcion_asig;
            ambiente.SelectedValue = dt1.id_amb.ToString();
            ficha.SelectedValue = dt1.id_ficha.ToString();
            resultado.SelectedValue = dt1.id_resul.ToString();
            instructor.SelectedValue = dt1.id_instru.ToString();
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {

            DataTable data = cd.listarAsignacion();
            DTVListar.DataSource = data;
            DTVListar.DataBind();
        }

        // Metodo para borrar registros a traves de la GridView 
        protected void DTVListar_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                cd.deleteAsignacion(DTVListar.DataKeys[e.RowIndex].Value.ToString());
            }
            catch
            {
                Response.Write("<script>window.alert('Error inesperado');</script>");
            }
            finally
            {

                btnListar_Click(sender, e);
            }


        }

        //Metodo para habilitar opciones de editar o cancelar
        protected void DTVListar_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                DTVListar.EditIndex = e.NewEditIndex;
                btnListar_Click(sender, e);
                for (int i = 1; i < 19; i++)
                {
                    if (i % 2 == 0)
                    {
                        DTVListar.Rows[e.NewEditIndex].Cells[i].Visible = true;
                    }
                    else
                    {
                        DTVListar.Rows[e.NewEditIndex].Cells[i].Visible = false;
                    }
                }
                for (int i = 1; i < 19; i = i + 2)
                {

                    if (i < 4)
                    {
                        TextBox tb = (TextBox)DTVListar.Rows[e.NewEditIndex].Cells[i].Controls[0];
                        TextBox tb2 = (TextBox)DTVListar.Rows[e.NewEditIndex].Cells[i + 1].Controls[1];
                        DateTime temp = Convert.ToDateTime(tb.Text);
                        tb2.Text = temp.ToString("yyyy-MM-dd");

                    }
                    else if (i < 9)
                    {
                        TextBox tb = (TextBox)DTVListar.Rows[e.NewEditIndex].Cells[i].Controls[0];
                        TextBox tb2 = (TextBox)DTVListar.Rows[e.NewEditIndex].Cells[i + 1].Controls[1];
                        tb2.Text = tb.Text;
                    }
                    else
                    {
                        DropDownList ddl = (DropDownList)DTVListar.Rows[e.NewEditIndex].Cells[i + 1].Controls[1];
                        TextBox tb = (TextBox)DTVListar.Rows[e.NewEditIndex].Cells[i].Controls[0];
                        String temp = tb.Text;
                        for (int j = 0; j < ddl.Items.Count; j++)
                        {
                            if (ddl.Items[j].Text.Equals(temp))
                            {
                                ddl.SelectedValue = ddl.Items[j].Value;
                                break;
                            }
                        }
                    }

                }
            }
            catch
            {
                Response.Write("<script>window.alert('Error inesperado');</script>");
                DTVListar.EditIndex = -1;
                btnListar_Click(sender, e);
            }
        }
        //Metodo Actualizar
        protected void DTVListar_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)DTVListar.Rows[e.RowIndex];
                TextBox fechainicio_asig = (TextBox)row.Cells[2].Controls[1];
                TextBox fechafin_asig = (TextBox)row.Cells[4].Controls[1];
                TextBox horainicio_asig = (TextBox)row.Cells[6].Controls[1];
                TextBox horafin_asig = (TextBox)row.Cells[8].Controls[1];
                DropDownList dia_asig = (DropDownList)row.Cells[10].Controls[1];
                DropDownList id_amb = (DropDownList)row.Cells[12].Controls[1];
                DropDownList id_ficha = (DropDownList)row.Cells[14].Controls[1];
                DropDownList id_instru = (DropDownList)row.Cells[16].Controls[1];
                DropDownList id_resul = (DropDownList)row.Cells[18].Controls[1];
                TextBox descripcion_asig = (TextBox)row.Cells[19].Controls[0];
                CADValidaciones val = new CADValidaciones();
                DTOHorario dt2 = new DTOHorario();
                dt = new DTOHorario();
                dt.codigo_asig = row.Cells[0].Text;
                dt.fechainicio_asig = Convert.ToDateTime(fechainicio_asig.Text);
                dt.fechafin_asig = Convert.ToDateTime(fechafin_asig.Text);
                dt.horainicio_asig = Convert.ToDateTime(horainicio_asig.Text);
                dt.horafin_asig = Convert.ToDateTime(horafin_asig.Text);
                dt.dia_asig = dia_asig.Text;
                dt.descripcion_asig = descripcion_asig.Text;
                dt.id_amb = Convert.ToInt32(id_amb.SelectedItem.Value);
                dt.id_ficha = Convert.ToInt32(id_ficha.SelectedItem.Value);
                dt.id_resul = Convert.ToInt32(id_resul.SelectedItem.Value);
                dt.id_instru = Convert.ToInt32(id_instru.SelectedItem.Value);



                if (String.IsNullOrEmpty(dt.fechainicio_asig.ToString()) || String.IsNullOrEmpty(dt.fechafin_asig.ToString()) || String.IsNullOrEmpty(dt.horainicio_asig.ToString()) ||
                    String.IsNullOrEmpty(dt.horafin_asig.ToString()) || String.IsNullOrEmpty(dt.dia_asig) || String.IsNullOrEmpty(dt.id_amb.ToString()) || String.IsNullOrEmpty(dt.id_ficha.ToString())
                    || String.IsNullOrEmpty(dt.id_resul.ToString()) || String.IsNullOrEmpty(dt.id_instru.ToString()))
                {
                    Response.Write("<script>window.alert('los campos con * son obligatorios');</script>");
                }
                else
                {
                    dt2 = val.verificarAsignacion(dt);
                    if (dt2.codigo_asig != dt.codigo_asig)
                    {

                        if (dt2.id_amb == dt.id_amb)
                        {
                            Response.Write("<script>window.alert('El ambiente: " + dt2.nombre_amb + " se encuntra ocupado hasta las: " + dt2.horafin_asig.ToString("HH:mm") + " con la ficha: " + dt2.codigo_ficha + " y el Instructor: " + dt2.nombre_Instru + " por la asignacion: " + dt2.codigo_asig + "');</script>");
                        }
                        else if (dt2.id_ficha == dt.id_ficha)
                        {
                            Response.Write("<script>window.alert('La ficha: " + dt2.codigo_ficha + "  se encuntra ocupada hasta las: " + dt2.horafin_asig.ToString("HH:mm") + " en el ambiente: " + dt2.nombre_amb + " y el Instructor: " + dt2.nombre_Instru + " por la asignacion: " + dt2.codigo_asig + "');</script>");
                        }
                        else if (dt2.id_instru == dt.id_instru)
                        {
                            Response.Write("<script>window.alert('El instructor: " + dt2.nombre_Instru + " se encuntra ocupado hasta las: " + dt2.horafin_asig.ToString("HH:mm") + " con la ficha: " + dt2.codigo_ficha + " en el ambiente: " + dt2.nombre_amb + " por la asignacion: " + dt2.codigo_asig + "');</script>");
                        }

                    }
                    else
                    {
                        int i;

                        TimeSpan ts = dt.horafin_asig - dt.horainicio_asig;

                        if ((i = (val.verificarhoras(dt.id_instru) + ((ts.Hours * 60) + (ts.Minutes)))) >= 2100)
                        {
                            int horas = i / 60;
                            int minutos = i % 60;
                            Response.Write("<script>window.alert('El instructor tiene asignadas: " + horas + ":" + minutos + " Horas');</script>");
                        }
                        cd.modificarAsignacion(dt);
                        DTVListar.EditIndex = -1;
                        btnListar_Click(sender, e);
                    }

                }
            }
            catch
            {
                Response.Write("<script>window.alert('Error inesperado');</script>");
                DTVListar.EditIndex = -1;
                btnListar_Click(sender, e);
            }
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

            try
            {
                DateTime s = Convert.ToDateTime(e.Row.Cells[1].Text);
                e.Row.Cells[1].Text = s.ToString("dd/MM/yyyy");
                s = Convert.ToDateTime(e.Row.Cells[3].Text);
                e.Row.Cells[3].Text = s.ToString("dd/MM/yyyy");
            }
            catch
            {
            }
            try
            {
                for (int i = 1; i < 19; i++)
                {
                    if (i % 2 == 0)
                    {
                        e.Row.Cells[i].Visible = false;
                    }
                    else
                    {
                        e.Row.Cells[i].Visible = true;
                    }
                }
            }
            catch {
                Response.Write("<script>window.alert('Error inesperado');</script>");
            }

        }
    }
}