using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProyectoCuatrimestral.Dominio;
using ProyectoCuatrimestral.Negocio;

namespace ProyectoCuatrimestral
{
    public partial class AgregarMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Medico medico = (Medico)Session["Medico"];

            if (medico == null || ! medico.EsAdministrador())
            {
                Session.Clear();
                Response.Redirect("/Ingreso");
                return;
            }

            if (!IsPostBack)
            {
                EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
                List<Especialidad> listaEspecialidades = especialidadNegocio.Listar();

                ddlEspecialidades.DataSource = listaEspecialidades;
                ddlEspecialidades.DataValueField = "Id";
                ddlEspecialidades.DataTextField = "Nombre";
                ddlEspecialidades.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length == 0)
                return;

            EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
            MedicoNegocio medicoNegocio = new MedicoNegocio();

            medicoNegocio.Nuevo(
                txtNombre.Text, txtApellido.Text, txtUsuario.Text, txtClave.Text, Convert.ToInt32(ddlEspecialidades.Text));

            Response.Redirect("/Medicos");
        }
    }
}