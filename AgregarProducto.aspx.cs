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
    public partial class AgregarProducto : System.Web.UI.Page
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
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                MarcaDropdownList.DataSource = marcaNegocio.Listar();
                MarcaDropdownList.DataBind();
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length == 0)
                return;

            int unidades;
            decimal precio;
            Uri url;

            try
            {
                unidades = Convert.ToInt32(txtUnidades.Text);
                precio = Convert.ToDecimal(txtPrecio.Text);
                url = new Uri(txtIlustracion.Text);
            }
            catch
            {
                return;
            }
            
            ProductoNegocio productoNegocio = new ProductoNegocio();

            productoNegocio.Nuevo(
                Convert.ToInt32(MarcaDropdownList.SelectedValue.Split('-')[0]),
                1, // Administrador
                txtNombre.Text,
                txtDescripcion.Text,
                unidades,
                precio,
                url);

            Response.Redirect("/Productos");
        }
    }
}