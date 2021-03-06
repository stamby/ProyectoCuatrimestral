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
    public partial class Productos : System.Web.UI.Page
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

            if (!IsPostBack)
                Mostrar();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AgregarProducto");
        }
        protected void Mostrar()
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            ProductoNegocio productoNegocio = new ProductoNegocio();
            ProductosGrilla.DataSource = productoNegocio.Listar(
                usuarioNegocio.DesdeID(1)); // Administrador
            ProductosGrilla.DataBind();
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string id = ((GridViewRow)((Button)sender).NamingContainer).Cells[0].Text;

            Response.Redirect("/ModificarProducto?id=" + id);

        }
        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();

            int id = Convert.ToInt32(
                ((GridViewRow)((Button)sender).NamingContainer).Cells[0].Text);

            productoNegocio.Borrar(id);

            ProductosGrilla.EditIndex = -1;
            Mostrar();
        }
    }
}