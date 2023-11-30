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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Session.Clear();

            PacienteNegocio pacienteNegocio = new PacienteNegocio();

            Paciente paciente = pacienteNegocio.Nuevo(
                txtNombre.Text,
                txtApellido.Text,
                txtObraSocial.Text,
                txtUsuario.Text,
                txtClave.Text);

            Response.Redirect("/Ingreso");
            
            ScriptManager.RegisterClientScriptBlock(
                    this,
                    this.GetType(),
                    "alertMessage",
                    "alert('Su usuario fue registrado correctamente.')",
                    true);
        }
    }
}