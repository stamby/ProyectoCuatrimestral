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

            lblMedico.Text = turno.Medico.ToString();
            lblHoraDesde.Text = turno.HoraDesde.ToString("dd/MM/yyyy HH:mm");
            lblHoraHasta.Text = turno.HoraHasta.ToString("dd/MM/yyyy HH:mm");
            lblPaciente.Text = ((Paciente)Session["Paciente"]).ToString();
            lblObraSocial.Text = ((Paciente)Session["Paciente"]).ObraSocial;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            TurnoNegocio turnoNegocio = new TurnoNegocio();

            turnoNegocio.Reservar(Convert.ToInt32(Request.QueryString["id"]), ((Paciente)Session["Paciente"]).Id);
            
            Response.Redirect("/AgendaPaciente");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ReservarTurno");
        }
    }

}