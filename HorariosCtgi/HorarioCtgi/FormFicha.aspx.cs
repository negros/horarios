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

        protected void EliminarFicha_Click(object sender, EventArgs e)
        {
            ficha.codigo_ficha = Convert.ToInt64(txtcodigo.Text);
            daoficha.eliminarFicha(ficha);
        }

        protected void ActualizarFicha_Click(object sender, EventArgs e)
        {
            ficha.codigo_ficha = Convert.ToInt64(txtcodigo.Text);
            ficha.id_programa = Convert.ToInt16(ddlnombre_programa.SelectedItem.Value);
            ficha.ningregantes_ficha = Convert.ToInt16(txtnintegrante.Text);
            ficha.jornada_ficha = ddljornada.Text;
            ficha.id_cohorte = Convert.ToInt16(ddlcohorte.SelectedItem.Value);
            daoficha.actualizarFicha(ficha);
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
    }
}