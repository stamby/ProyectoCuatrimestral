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
    public partial class AgregarDisponibilidad : System.Web.UI.Page
    {
        IEnumerable<DateTime> BuscarDiasEntre(DateTime primero, DateTime ultimo)
        {
            for (DateTime i = primero; i < ultimo; i = i.AddDays(1))
            {
                yield return i;
            }
        }

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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            DayOfWeek[] diasDeLaSemana = new DayOfWeek[] {};

            if (chkDomingo.Checked)
                diasDeLaSemana.Append(DayOfWeek.Sunday);
            if (chkLunes.Checked)
                diasDeLaSemana.Append(DayOfWeek.Monday);
            if (chkMartes.Checked)
                diasDeLaSemana.Append(DayOfWeek.Tuesday);
            if (chkMiercoles.Checked)
                diasDeLaSemana.Append(DayOfWeek.Wednesday);
            if (chkJueves.Checked)
                diasDeLaSemana.Append(DayOfWeek.Thursday);
            if (chkViernes.Checked)
                diasDeLaSemana.Append(DayOfWeek.Friday);
            if (chkSabado.Checked)
                diasDeLaSemana.Append(DayOfWeek.Saturday);

            var dias = BuscarDiasEntre(
                DateTime.ParseExact(txtDiaDesde.Text, "yyyy-MM-dd", null),
                DateTime.ParseExact(txtDiaHasta.Text, "yyyy-MM-dd", null).AddDays(1)
                //.Where(d => diasDeLaSemana.Contains(d.DayOfWeek)
                );

            DateTime horaDesde = DateTime.ParseExact(txtHoraDesde.Text, "HH:mm", null);
            DateTime horaHasta = DateTime.ParseExact(txtHoraHasta.Text, "HH:mm", null);

            foreach (var dia in dias)
            {
                TurnoNegocio turnoNegocio = new TurnoNegocio();

                turnoNegocio.Nuevo(
                    DateTime.ParseExact(
                        dia.Date.ToString("yyyy-MM-dd ") + horaDesde.ToString("HH:mm"),
                        "yyyy-MM-dd HH:mm",
                        null),
                    DateTime.ParseExact(
                        dia.Date.ToString("yyyy-MM-dd ") + horaHasta.ToString("HH:mm"),
                        "yyyy-MM-dd HH:mm",
                        null),
                    (Medico)Session["Medico"]) ;
            }

            Response.Redirect("/AgendaMedico");
        }
    }
}