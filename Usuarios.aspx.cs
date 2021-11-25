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
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Mostrar();
        }
        protected void Mostrar()
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            UsuariosGrilla.DataSource = usuarioNegocio.Listar();
            UsuariosGrilla.DataBind();
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string id = ((GridViewRow)((Button)sender).NamingContainer).Cells[0].Text;

            Response.Redirect("/ModificarUsuario?id=" + id);

        }
        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            int id = Convert.ToInt32(
                ((GridViewRow)((Button)sender).NamingContainer).Cells[0].Text);

            usuarioNegocio.Borrar(id);

            UsuariosGrilla.EditIndex = -1;
            Mostrar();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AgregarUsuario");
        }
    }
}