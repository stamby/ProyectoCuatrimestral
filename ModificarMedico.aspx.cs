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
    public partial class ModificarMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Medico medico = (Medico)Session["Medico"];

            if (medico == null || !medico.EsAdministrador())
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
                Response.Redirect("/Medicos");
                return;
            }

            lblID.Text = Request.QueryString["id"];

            MedicoNegocio medicoNegocio = new MedicoNegocio();
            
            medico = medicoNegocio.DesdeID(ID);

            if (medico == null)
            {
                Response.Redirect("/Medicos");
                return;
            }

            lblID.Text = Convert.ToString(medico.Id);

            EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
            List<Especialidad> listaEspecialidades = especialidadNegocio.Listar();

            ddlEspecialidades.DataSource = listaEspecialidades;
            ddlEspecialidades.DataValueField = "Id";
            ddlEspecialidades.DataTextField = "Nombre";
            ddlEspecialidades.DataBind();

            txtNombre.Text = medico.Nombre;
            txtApellido.Text = medico.Apellido;
            ddlEspecialidades.SelectedValue = medico.Especialidad.Id.ToString();
            txtUsuario.Text = medico.Email;
            txtClave.Text = medico.Clave;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Medico medico = new Medico();

            medico.Id = Convert.ToInt32(lblID.Text);
            medico.Nombre = txtNombre.Text;
            medico.Apellido = txtApellido.Text;
            medico.Email = txtUsuario.Text;
            medico.Clave = txtClave.Text;

            medico.Especialidad = new Especialidad();
            medico.Especialidad.Id = Convert.ToInt32(
                ddlEspecialidades.SelectedValue);
            
            MedicoNegocio medicoNegocio = new MedicoNegocio();
            
            medicoNegocio.Modificar(medico);

            Response.Redirect("/Medicos");
        }
    }
}