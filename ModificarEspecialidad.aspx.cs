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
    public partial class ModificarEspecialidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Medico medico = (Medico)Session["Medico"];

            if (medico == null)
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
                Response.Redirect("/Especialidades");
                return;
            }

            lblID.Text = Request.QueryString["id"];

            EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
            
            Especialidad especialidad = especialidadNegocio.DesdeID(ID);

            if (especialidad == null)
            {
                Response.Redirect("/Especialidades");
                return;
            }

            lblID.Text = Convert.ToString(especialidad.Id);

            txtNombre.Text = especialidad.Nombre;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Especialidad especialidad = new Especialidad();

            especialidad.Id = Convert.ToInt32(lblID.Text);
            especialidad.Nombre = txtNombre.Text;
            
            EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
            
            especialidadNegocio.Modificar(especialidad);
            Response.Redirect("/Especialidades");
        }
    }
}