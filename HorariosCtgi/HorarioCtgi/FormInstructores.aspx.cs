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
    public partial class FormInstructores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            chafe1.Text = DateTime.Now.ToShortDateString();
        }

        protected void Insertar(object sender, EventArgs e)
        {
            DTOInstructores dt = new DTOInstructores();
            dt.Dni_instructor = Convert.ToInt32(txtdni_instruc.Text);
            dt.Nombre_isntructor = txtnombre_instrucr.Text;
            dt.Apellido_instructor = txtapellido_instruc.Text;
            dt.Profesion_instructor = txtprefesion_instruc.Text;
            CADInstructores cd = new CADInstructores();
            cd.insertarInstructores(dt);
        }

        protected void Modificar(object sender, EventArgs e)
        {
            DTOInstructores dt = new DTOInstructores();
            dt.Dni_instructor = Convert.ToInt32(txtdni_instruc.Text);
            dt.Nombre_isntructor = txtnombre_instrucr.Text;
            dt.Apellido_instructor = txtapellido_instruc.Text;
            dt.Profesion_instructor = txtprefesion_instruc.Text;
            CADInstructores cd = new CADInstructores();
            cd.modificarInstructores(dt);
        }

        protected void Eliminar(object sender, EventArgs e)
        {
            DTOInstructores dt = new DTOInstructores();
            dt.Dni_instructor = Convert.ToInt32(txtdni_instruc.Text);
            CADInstructores cd = new CADInstructores();
            cd.eliminarInstructores(dt);
        }

        protected void Consultar(object sender, EventArgs e)
        {
            DTOInstructores dt = new DTOInstructores();
            CADInstructores cd = new CADInstructores();
            dt = cd.buscarInstructores(Convert.ToInt32(txtdni_instruc.Text));
            txtnombre_instrucr.Text = dt.Nombre_isntructor;
            txtapellido_instruc.Text = dt.Apellido_instructor;
            txtprefesion_instruc.Text = dt.Profesion_instructor;

        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            CADInstructores cd = new CADInstructores();
            DataTable data = cd.listarInsructores();
            grvAmbientes.DataSource = data;
            grvAmbientes.DataBind();
        }
    }
}