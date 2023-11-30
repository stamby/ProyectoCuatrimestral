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
    public partial class Especialidades : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Medico medico = (Medico)Session["Medico"];

            if (medico == null || ! medico.EsAdministrador())
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
            EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
            GrillaEspecialidades.DataSource = especialidadNegocio.Listar();
            GrillaEspecialidades.DataBind();
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string id = ((GridViewRow)((Button)sender).NamingContainer).Cells[0].Text;

            Response.Redirect("/ModificarEspecialidad?id=" + id);

        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();

            int id = Convert.ToInt32(
                ((GridViewRow)((Button)sender).NamingContainer).Cells[0].Text);

            especialidadNegocio.Borrar(id);

            GrillaEspecialidades.EditIndex = -1;
            Mostrar();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AgregarEspecialidad");
        }
    }
}