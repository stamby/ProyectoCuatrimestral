using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProyectoCuatrimestral.Dominio;
using ProyectoCuatrimestral.Negocio;

namespace ProyectoCuatrimestral
{
    public partial class ConfirmarReserva : System.Web.UI.Page
    {
        public Turno turno;

        protected void Page_Load(object sender, EventArgs e)
        {
            Paciente paciente = (Paciente)Session["Paciente"];

            if (paciente == null)
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
            catch (FormatException)
            {
                Response.Redirect("/ReservarTurno");
                return;
            }

            TurnoNegocio turnoNegocio = new TurnoNegocio();

            turno = turnoNegocio.DesdeID(ID);

            if (turno == null)
            {
                Response.Redirect("/ReservarTurno");
            }

            lblID.Text = turno.Id.ToString();
            lblEspecialidad.Text = turno.Medico.Especialidad.Nombre;
            lblMedico.Text = turno.Medico.ToString();
            lblHoraDesde.Text = turno.HoraDesde.ToLongDateString();
            lblHoraHasta.Text = turno.HoraHasta.ToLongDateString();
            lblPaciente.Text = turno.Paciente.ToString();
            lblObraSocial.Text = turno.Paciente.ToString();
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

        }
    }

}