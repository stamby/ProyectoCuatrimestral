using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProyectoCuatrimestral.Dominio;
using ProyectoCuatrimestral.Negocio;

namespace ProyectoCuatrimestral
{
    public partial class Medicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Medico medico = (Medico)Session["Medico"];

            if (medico == null)
            {
                Session.Clear();
                Response.Redirect("/Ingreso");
                return;
            }

            if (!IsPostBack)
                Mostrar();
        }
        protected void Mostrar()
        {
            MedicoNegocio medicoNegocio = new MedicoNegocio();
            MedicosGrilla.DataSource = medicoNegocio.Listar();
            MedicosGrilla.DataBind();
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string id = ((GridViewRow)((Button)sender).NamingContainer).Cells[0].Text;

            Response.Redirect("/ModificarMedico?id=" + id);

        }
        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            MedicoNegocio medicoNegocio = new MedicoNegocio();

            int id = Convert.ToInt32(
                ((GridViewRow)((Button)sender).NamingContainer).Cells[0].Text);

            medicoNegocio.Borrar(id);

            MedicosGrilla.EditIndex = -1;
            Mostrar();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AgregarMedico");
        }
    }
}