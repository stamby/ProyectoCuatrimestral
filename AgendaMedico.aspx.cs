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
        int[] turnos;

        int ultimoIndice;
        MesSeleccionado mesSeleccionado;
        protected void Page_Load(object sender, EventArgs e)
        {
            Medico medico = (Medico)Session["Medico"];

            if (medico == null)
            {
                Session.Clear();
                Response.Redirect("/Ingreso");
                return;
            }

            Poblar();
        }
        protected void Poblar()
        {
            ultimoIndice = 0;
            
            return;
            if (!IsPostBack)
            {
                // Al cargar la página por primera vez, se muestra el presente mes
                mesSeleccionado = MesSeleccionado.Presente;
            }
            else if (Calendario.VisibleDate.Year < DateTime.Now.Year)
            {
                mesSeleccionado = MesSeleccionado.Pasado;
            }
            else if (Calendario.VisibleDate.Year > DateTime.Now.Year)
            {
                mesSeleccionado = MesSeleccionado.Futuro;
            }
            else
            {
                if (Calendario.VisibleDate.Month < DateTime.Now.Month)
                {
                    mesSeleccionado = MesSeleccionado.Pasado;
                }
                else if (Calendario.VisibleDate.Month > DateTime.Now.Month)
                {
                    mesSeleccionado = MesSeleccionado.Futuro;
                }
                else
                {
                    mesSeleccionado = MesSeleccionado.Presente;
                }
            }

            TurnoNegocio turnoNegocio = new TurnoNegocio();

            if (mesSeleccionado == MesSeleccionado.Pasado)
            {
                return;
            }
            else if (mesSeleccionado == MesSeleccionado.Presente)
            {
                turnos = turnoNegocio.ContarPorDia(
                    DateTime.Now.Year,
                    DateTime.Now.Month,
                    (Medico)Session["Medico"]);
            }
            else
            {
                turnos = turnoNegocio.ContarPorDia(
                    Calendario.VisibleDate.Year,
                    Calendario.VisibleDate.Month,
                    (Medico)Session["Medico"]);
            }
        }
        protected void Calendario_VisibleMonthChanged(object sender, System.Web.UI.WebControls.DayRenderEventArgs e)
        {
            Poblar();
        }
        protected void Calendario_DayRender(object sender, System.Web.UI.WebControls.DayRenderEventArgs e)
        {
            /*
            if (e.Day.Date >= DateTime.Today)
            {
                e.Day.IsSelectable = true;

                /*
                 * 
                 * Verde = hay disponibilidad
                 * Salmon = reservado
                 * 
                   

                if (turnos[e.Day.Date.Day] == 0)
                {
                    e.Cell.BackColor = System.Drawing.Color.LightGreen;
                    e.Cell.ForeColor = System.Drawing.Color.DarkGreen;
                }
                else if (turnos[e.Day.Date.Day] == 1)
                {
                    e.Cell.BackColor = System.Drawing.Color.LightSalmon;
                    e.Cell.ForeColor = System.Drawing.Color.DarkSalmon;
                }
                else if (turnos[e.Day.Date.Day] == 2)
                {
                    e.Cell.BackColor = System.Drawing.Color.Crimson;
                    e.Cell.ForeColor = System.Drawing.Color.DarkRed;
                }
            }
            else
            {
                e.Day.IsSelectable = false;
            }
    */
        }
        /*
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();

            int id = Convert.ToInt32(
                ((GridViewRow)((Button)sender).NamingContainer).Cells[0].Text);

            especialidadNegocio.Borrar(id);

            GrillaAgendaMedico.EditIndex = -1;
            Mostrar();
        }
    */
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AgregarDisponibilidad");
        }
    }
}