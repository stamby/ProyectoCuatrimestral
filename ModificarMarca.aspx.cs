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
    public partial class ModificarMarca : System.Web.UI.Page
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
                Response.Redirect("/Marcas");
                return;
            }

            lblID.Text = Request.QueryString["id"];

            MarcaNegocio marcaNegocio = new MarcaNegocio();
            
            Marca marca = marcaNegocio.DesdeID(ID);

            if (marca == null)
            {
                Response.Redirect("/Marcas");
                return;
            }

            lblID.Text = Convert.ToString(marca.Id);

            txtNombre.Text = marca.Nombre;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Marca marca = new Marca();

            marca.Id = Convert.ToInt32(lblID.Text);
            marca.Nombre = txtNombre.Text;
            
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            
            marcaNegocio.Modificar(marca);
            Response.Redirect("/Marcas");
        }
    }
}