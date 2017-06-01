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
            //try
            //{
            //    if (String.IsNullOrEmpty(txtnombre_linea_tecno.Text))
            //    {
            //        Response.Write("<script>window.alert('Por favor ingresar todos los campos');</script>");
            //    }
            //    else
            //    {
            dt.nombre_linea_tecno = txtnombre_linea_tecno.Text;
            cd.insertarLinea_tecno(dt);
            //if (cd.insertarLinea_tecno(dt))
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




        protected void Consultar(object sender, EventArgs e)
        {
            //try
            //{

            //    if (String.IsNullOrEmpty(txtnombre_linea_tecno.Text))
            //    {
            //        Response.Write("<script>window.alert('Por favor ingresar las 3 letras iniciales del nombre de la linea Tecnologica');</script>");

            //    }
            //    else
            //    {

            dt = cd.ConsultarLinea_tecno(txtnombre_linea_tecno.Text);
            //if (dt == null)
            //{
            //    Response.Write("<script>window.alert('el codigo no exixte');</script>");

            //}
            //else
            //{
            txtnombre_linea_tecno.Text = dt.nombre_linea_tecno;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("<script>window.alert('error inesperado');</script>");

            //}
        }


        protected void Listar(object sender, EventArgs e)
        {
            DataTable data = cd.ListarLinea_tecno();
            grvAmbientes.DataSource = data;
            grvAmbientes.DataBind();
        }

    }
}