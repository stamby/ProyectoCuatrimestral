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
    public partial class AgregarMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["Usuario"];

            if (usuario == null || !usuario.PermisoVender)
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

            MarcaNegocio marcaNegocio = new MarcaNegocio();

            marcaNegocio.Nuevo(txtNombre.Text);

            Response.Redirect("/Marcas");
        }
    }
}