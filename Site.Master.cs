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
        protected Usuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("/Ingreso");
                return;
            }

            usuario = (Usuario)Session["Usuario"];
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/Ingreso");
        }
    }
}