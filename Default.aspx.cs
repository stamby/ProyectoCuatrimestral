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
    public partial class _Default : Page
    {
        protected List<Producto> listaProductos;

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["Usuario"];

            if (usuario == null)
            {
                Response.Redirect("/Ingreso");
                return;
            }
            else
            {
                if (!usuario.PermisoComprar)
                {
                    if (usuario.PermisoVender)
                    {
                        Response.Redirect("/Productos");
                        return;
                    }
                    if (usuario.PermisoAdmin)
                    {
                        Response.Redirect("/Usuarios");
                        return;
                    }
                }
            }

            ProductoNegocio productoNegocio = new ProductoNegocio();

            listaProductos = productoNegocio.Listar();
        }
    }
}