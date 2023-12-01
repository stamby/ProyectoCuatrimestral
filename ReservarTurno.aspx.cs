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
    public partial class ReservarTurno : System.Web.UI.Page
    {
        protected List<Turno> listaTurnos;

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
            {
                CargarMedicos();
                CargarEspecialidades();
                CargarTurnos();
            }
        }

        private void CargarMedicos()
        {
            MedicoNegocio medicoNegocio = new MedicoNegocio();
            List<Medico> listaMedicos = medicoNegocio.Listar();

            ddlMedicos.DataSource = listaMedicos;
            ddlMedicos.DataValueField = "Id";
            ddlMedicos.DataTextField = "Apellido";

            ddlMedicos.DataBind();

            ddlMedicos.Items.Insert(0, new ListItem("Todos", "0"));
        }

        private void CargarEspecialidades()
        {
            EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
            List<Especialidad> listaEspecialidades = especialidadNegocio.Listar();

            ddlEspecialidades.DataSource = listaEspecialidades;
            ddlEspecialidades.DataValueField = "Id";
            ddlEspecialidades.DataTextField = "Nombre";
            ddlEspecialidades.DataBind();

            ddlEspecialidades.Items.Insert(0, new ListItem("Todas", "0"));
        }

        private void CargarTurnos()
        {
            DateTime hora_desde = DateTime.Now;
            DateTime hora_hasta = DateTime.Now.AddDays(30);

            int medicoId = Convert.ToInt32(ddlMedicos.SelectedValue);
            int especialidadId = Convert.ToInt32(ddlEspecialidades.SelectedValue);

            Especialidad especialidad = null;
            Medico medico = null;

            if (especialidadId > 0)
            {
                EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
                especialidad = especialidadNegocio.DesdeID(especialidadId);
            }

            if (medicoId > 0)
            {
                MedicoNegocio medicoNegocio = new MedicoNegocio();
                medico = medicoNegocio.DesdeID(medicoId);
            }

            TurnoNegocio turnoNegocio = new TurnoNegocio();
            listaTurnos = turnoNegocio.Listar(
                hora_desde, hora_hasta, especialidad, medico, solo_vacantes: true);

            GridView1.DataSource = listaTurnos;
            GridView1.DataBind();
        }

        protected void ddlMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTurnos();
        }

        protected void ddlEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTurnos();
        }

        protected void btnReservar_Click(object sender, EventArgs e)
        {
            string turnoId = ((GridViewRow)((Button)sender).NamingContainer).Cells[0].Text;
            
            Response.Redirect("/ConfirmarReserva?id=" + turnoId);
        }
    }
}
