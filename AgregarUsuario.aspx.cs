using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProyectoCuatrimestral.Dominio;
using ProyectoCuatrimestral.Negocio;

namespace ProyectoCuatrimestral
{
    public partial class AgregarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length == 0 || txtClave.Text.Length == 0)
                return;

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            Usuario usuario = usuarioNegocio.Nuevo(
                txtNombre.Text,
                chkAdmin.Checked,
                chkComprar.Checked,
                chkVender.Checked);

            ClaveNegocio claveNegocio = new ClaveNegocio();

            claveNegocio.Nuevo(
                usuario, txtClave.Text);

            Response.Redirect("/Usuarios");
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            var rBytes = new byte[4];
            using (var crypto = new RNGCryptoServiceProvider()) crypto.GetBytes(rBytes);
            string resultado = Convert.ToBase64String(rBytes).Replace("=", "");
            txtClave.Text = resultado;
        }
    }
}