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
    public partial class AgendaPaciente : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Paciente paciente = (Paciente)Session["Paciente"];

            if (paciente == null)
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
            TurnoNegocio turnoNegocio = new TurnoNegocio();

            List<Turno> lista = turnoNegocio.Listar(
                DateTime.Today, DateTime.Today.AddDays(30), null, null, (Paciente)Session["Paciente"]);

            if (lista.Count == 0)
            {
                lblAbajo.Visible = true;
            }

            GrillaAgendaPaciente.DataSource = lista;

            GrillaAgendaPaciente.DataBind();
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            TurnoNegocio turnoNegocio = new TurnoNegocio();

            int id = Convert.ToInt32(
                ((GridViewRow)((Button)sender).NamingContainer).Cells[0].Text);

            turnoNegocio.CancelarReserva(id);

            GrillaAgendaPaciente.EditIndex = -1;
            Mostrar();
        }
        protected void btn_ReservarTurno_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ReservarTurno");
        }
    }
}