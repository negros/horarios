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
    public partial class FormCohorte : System.Web.UI.Page
    {
        DTOCohorte cohorte = new DTOCohorte();
        CADCohorte datoc = new CADCohorte();

        protected void Page_Load(object sender, EventArgs e)
        {
            chafe1.Text = DateTime.Now.ToShortDateString();
        }

        protected void GuardarCohorte_Click(object sender, EventArgs e)
        {
            cohorte.codigo_cohorte = Convert.ToInt64(txtcodigo.Text);
            cohorte.nombre_cohorte = txtnombre.Text;
            cohorte.fecha_inicio = Convert.ToDateTime(txtfecha_inicio.Text);
            cohorte.fecha_fin = Convert.ToDateTime(txtfecha_fin.Text);
            cohorte.año_cohorte = txtano.Text;
            cohorte.trimestre_cohorte = Convert.ToInt16(ddltrimestre.Text);
            datoc.insertarCohorte(cohorte);
        }

        protected void EliminarCohorte_Click(object sender, EventArgs e)
        {
           
        }

        protected void ActualizarCohorte_Click(object sender, EventArgs e)
        {
   
            cohorte.codigo_cohorte = Convert.ToInt64(txtcodigo.Text);
            cohorte.nombre_cohorte = txtnombre.Text;
            cohorte.fecha_inicio = Convert.ToDateTime(txtfecha_inicio.Text);
            cohorte.fecha_fin = Convert.ToDateTime(txtfecha_fin.Text);
            cohorte.año_cohorte = txtano.Text;
            cohorte.trimestre_cohorte = Convert.ToInt16(ddltrimestre.Text);
            datoc.actualizarCohorte(cohorte);
        }

        protected void BuscarCohorte_Click(object sender, EventArgs e)
        {
            cohorte = datoc.ConsultarCohorte(txtcodigo.Text);
            txtcodigo.Text = Convert.ToString(cohorte.codigo_cohorte);
            txtnombre.Text = cohorte.nombre_cohorte;
            txtfecha_inicio.Text = cohorte.fecha_inicio.ToString("yyyy-MM-dd");
            txtfecha_fin.Text = cohorte.fecha_fin.ToString("yyyy-MM-dd");
            txtano.Text = cohorte.año_cohorte;
            ddltrimestre.Text = Convert.ToString(cohorte.trimestre_cohorte);
        }

        protected void ListarCohorte_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = datoc.ListarCohorte();
            DTVListar.DataSource = dt;
            DTVListar.DataBind();
        }
    }
}