using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProyectoCuatrimestral.Dominio;

namespace ProyectoCuatrimestral
{
    public partial class SiteMaster : MasterPage
    {
        public bool es_medico;
        public bool es_paciente;
        public bool es_administrador;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Medico"] != null)
            {
                Medico medico = (Medico)Session["Medico"];

                es_medico = true;
                es_administrador = medico.EsAdministrador();
            }
            else if (Session["Paciente"] != null)
            {
                es_paciente = true;
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/Ingreso");
        }
    }
}