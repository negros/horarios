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
            dt.dia_asig = txtdia_asig.Text;
            dt.descripcion_asig = txtdescripcion_asig.Text;
            dt.id_amb = Convert.ToInt16(ambiente.Text);
            dt.id_ficha = Convert.ToInt16(ficha.Text);
            dt.id_resul = Convert.ToInt16(resultado.Text);
            dt.id_instru = Convert.ToInt16(instructor.Text);

         
      
            if ((dt2=val.verificarAsignacion(dt)) != null)
            {
                if (dt2.id_amb == dt.id_amb) {
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
            else {
                int i;

                TimeSpan ts = dt.horafin_asig - dt.horainicio_asig;

                if((i=(val.verificarhoras(dt.id_instru)+((ts.Hours*60)+(ts.Minutes))))>=2100){
                    int horas = i / 60;
                    int minutos = i  % 60;
                    Response.Write("<script>window.alert('El instructor tiene asignadas: "+horas+":"+minutos+" Horas');</script>");
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
            dt.dia_asig = txtdia_asig.Text;
            dt.descripcion_asig = txtdescripcion_asig.Text;
            dt.id_amb = Convert.ToInt16(ambiente.Text);
            dt.id_ficha = Convert.ToInt16(ficha.Text);
            dt.id_resul = Convert.ToInt16(resultado.Text);
            dt.id_instru = Convert.ToInt16(instructor.Text);
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
            txtdia_asig.Text = dt1.dia_asig;
            txtdescripcion_asig.Text = dt1.descripcion_asig;
            ambiente.SelectedValue = dt1.id_amb.ToString();
            ficha.SelectedValue = dt1.id_ficha.ToString();
            resultado.SelectedValue = dt1.id_resul.ToString();
            instructor.SelectedValue = dt1.id_instru.ToString();
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            
            DataTable data = cd.listarAsignacion();
            listaAsig.DataSource = data;
            listaAsig.DataBind();
        }
        
    }
}