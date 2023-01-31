using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProyectoCuatrimestral.Dominio;
using ProyectoCuatrimestral.Negocio;

namespace ProyectoCuatrimestral
{
    public partial class AgregarEspecialidad : System.Web.UI.Page
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
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length == 0)
                return;

            EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();

            especialidadNegocio.Nuevo(txtNombre.Text);

            Response.Redirect("/Especialidades");
        }
    }
}