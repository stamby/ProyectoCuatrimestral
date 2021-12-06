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
    public partial class Marcas : Page
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
        protected void Mostrar()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            MarcasGrilla.DataSource = marcaNegocio.Listar();
            MarcasGrilla.DataBind();
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string id = ((GridViewRow)((Button)sender).NamingContainer).Cells[0].Text;

            Response.Redirect("/ModificarMarca?id=" + id);

        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();

            int id = Convert.ToInt32(
                ((GridViewRow)((Button)sender).NamingContainer).Cells[0].Text);

            marcaNegocio.Borrar(id);

            MarcasGrilla.EditIndex = -1;
            Mostrar();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AgregarMarca");
        }
    }
}