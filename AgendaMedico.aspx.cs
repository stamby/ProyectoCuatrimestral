using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProyectoCuatrimestral.Dominio;
using ProyectoCuatrimestral.Negocio;

enum MesSeleccionado
{
    Pasado,
    Presente,
    Futuro
};

namespace ProyectoCuatrimestral
{
    public partial class AgendaMedico : Page
    {
        DateTime fechaSeleccionada;
        // int [] turnosPorDia;

        protected void Page_Load(object sender, EventArgs e)
        {
            Medico medico = (Medico)Session["Medico"];

            if (medico == null)
            {
                Session.Clear();
                Response.Redirect("/Ingreso");
                return;
            }
        }
        protected void Calendario_VisibleMonthChanged(
            object sender, System.Web.UI.WebControls.DayRenderEventArgs e)
        {
        }
        protected void Mostrar()
        {
            TurnoNegocio turnoNegocio = new TurnoNegocio();

            List<Turno> turnos = turnoNegocio.Listar(
                fechaSeleccionada,
                fechaSeleccionada.AddDays(1),
                null,
                (Medico)Session["Medico"]);

            if (turnos.Count() > 0)
            {
                lblAbajo.Visible = false;

                GrillaTurnos.DataSource = turnos;
                GrillaTurnos.DataBind();
            }
            else
            {
                lblAbajo.Text = String.Format(
                    "No se ha agregado disponibilidad en la fecha seleccionada ({0}).",
                    fechaSeleccionada.ToShortDateString());
            }
        }
        protected void Calendario_DayRender(
            object sender, System.Web.UI.WebControls.DayRenderEventArgs e)
        {
            if (e.Day.Date >= DateTime.Today)
            {
                e.Day.IsSelectable = true;

                if (e.Day.IsSelected)
                {
                    e.Cell.BackColor = System.Drawing.Color.DarkBlue;
                    e.Cell.ForeColor = System.Drawing.Color.White;

                    fechaSeleccionada = e.Day.Date;

                    TurnoNegocio turnoNegocio = new TurnoNegocio();

                    Mostrar();
                }
                else
                {
                    if (e.Day.IsWeekend)
                    {
                        e.Cell.BackColor = System.Drawing.Color.LightSalmon;
                        e.Cell.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        e.Cell.BackColor = System.Drawing.Color.LightGreen;
                        e.Cell.ForeColor = System.Drawing.Color.DarkGreen;
                    }
                }
            }
            else {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.LightGray;
                e.Cell.ForeColor = System.Drawing.Color.DarkGray;
            }
        }
        protected void GrillaTurnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerTurno")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(GrillaTurnos.DataKeys[index].Value);
                Response.Redirect("/VerTurno?id=" + id);
            }
            else if (e.CommandName == "CancelarTurno")
            {
                TurnoNegocio turnoNegocio = new TurnoNegocio();

                int indice = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(GrillaTurnos.DataKeys[indice].Value);

                turnoNegocio.Borrar(id);

                GrillaTurnos.EditIndex = -1;
                Mostrar();
            }
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AgregarDisponibilidad");
        }
    }
}