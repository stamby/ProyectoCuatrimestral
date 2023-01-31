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
        protected List<Turno> listaProductos;

        protected void Page_Load(object sender, EventArgs e)
        {
            Medico medico = (Medico)Session["Medico"];
            Paciente paciente = (Paciente)Session["Paciente"];

            if (medico != null)
            {
                Response.Redirect("/AgendaMedico");
            }
            else if (paciente != null)
            {
                Response.Redirect("/AgendaPaciente");
            }
            else
            {
                Response.Redirect("/Ingreso");
            }
            return;
        }
    }
}