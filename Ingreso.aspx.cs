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
    public partial class Ingreso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Session.Clear();

            if (txtUsuario.Text == "")
                return;

            if (chkMedico.Checked)
            {
                MedicoNegocio medicoNegocio = new MedicoNegocio();

                Medico medico = medicoNegocio.Ingresar(
                    txtUsuario.Text, txtClave.Text);

                if (medico != null)
                {
                    Session.Add("Medico", medico);
                    Response.Redirect("/AgendaMedico");
                }
            } else if (chkPaciente.Checked) {
                PacienteNegocio pacienteNegocio = new PacienteNegocio();

                Paciente paciente = pacienteNegocio.Ingresar(
                    txtUsuario.Text, txtClave.Text);

                if (paciente != null)
                {
                    Session.Add("Paciente", paciente);
                    Response.Redirect("/AgendaPaciente");
                }
            }
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("/Registro");
        }
    }
}