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
    public partial class Ingreso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
                return;

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            Usuario usuario = usuarioNegocio.Ingresar(
                txtUsuario.Text, txtClave.Text);

            if (usuario != null)
            {
                Session.Add("Usuario", usuario);
                Response.Redirect("/");
            }
        }
    }
}