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
    public partial class ModificarProducto : System.Web.UI.Page
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

            if (IsPostBack)
                return;

            int ID;

            try
            {
                ID = Convert.ToInt32(Request.QueryString["id"]);
            }
            catch
            {
                Response.Redirect("/Productos");
                return;
            }

            lblID.Text = Request.QueryString["id"];

            ProductoNegocio productoNegocio = new ProductoNegocio();

            Producto producto = productoNegocio.DesdeID(ID);

            if (producto == null)
            {
                Response.Redirect("/Productos");
                return;
            }

            txtNombre.Text = producto.Nombre;

            MarcaNegocio marcaNegocio = new MarcaNegocio();
            MarcaDropdownList.DataSource = marcaNegocio.Listar();
            MarcaDropdownList.DataBind();

            ListItem item = MarcaDropdownList.Items.FindByText(
                producto.MarcaProducto.Id
                + " - " + producto.MarcaProducto.Nombre);
            item.Selected = true;

            txtDescripcion.Text = producto.Descripcion;
            txtUnidades.Text = producto.Unidades.ToString();
            txtPrecio.Text = producto.PrecioLista.ToString();
            txtIlustracion.Text = producto.Ilustracion.ToString();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
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

            Producto producto = new Producto();

            ProductoNegocio productoNegocio = new ProductoNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            producto.Id = Convert.ToInt32(lblID.Text);
            producto.MarcaProducto = marcaNegocio.DesdeID(
                Convert.ToInt32(MarcaDropdownList.SelectedValue.Split('-')[0]));
            producto.Nombre = txtNombre.Text;
            producto.Descripcion = txtDescripcion.Text;
            producto.Oferente = usuarioNegocio.DesdeID(1); // Administrador
            producto.Unidades = unidades;
            producto.PrecioLista = precio;
            producto.Ilustracion = url;

            productoNegocio.Modificar(producto);

            Response.Redirect("/Productos");
        }
    }
}