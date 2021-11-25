using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProyectoCuatrimestral.Dominio;
using ProyectoCuatrimestral.Negocio;

namespace ProyectoCuatrimestral
{
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            int ID;

            try
            {
                ID = Convert.ToInt32(Request.QueryString["id"]);
            }
            catch
            {
                Response.Redirect("/Usuarios");
                return;
            }

            lblID.Text = Request.QueryString["id"];

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            Usuario usuario = usuarioNegocio.DesdeID(ID);

            if (usuario == null)
            {
                Response.Redirect("/Usuarios");
                return;
            }

            lblID.Text = Convert.ToString(usuario.Id);

            txtNombre.Text = usuario.Nombre;
            chkAdmin.Checked = usuario.PermisoAdmin;
            chkComprar.Checked = usuario.PermisoComprar;
            chkVender.Checked = usuario.PermisoVender;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario.Id = Convert.ToInt32(lblID.Text);
            usuario.Nombre = txtNombre.Text;
            usuario.PermisoAdmin = chkAdmin.Checked;
            usuario.PermisoComprar = chkComprar.Checked;
            usuario.PermisoVender = chkVender.Checked;

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            usuarioNegocio.Modificar(usuario);

            if (txtClave.Text.Length > 0)
            {
                ClaveNegocio claveNegocio = new ClaveNegocio();
                Clave clave = claveNegocio.DesdeUsuario(usuario);
                clave.Secreto = txtClave.Text;
                claveNegocio.Modificar(clave);
            }
            
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