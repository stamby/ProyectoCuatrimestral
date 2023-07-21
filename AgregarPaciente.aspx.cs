using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProyectoCuatrimestral.Dominio;
using ProyectoCuatrimestral.Negocio;

namespace ProyectoCuatrimestral
{
    public partial class AgregarMedico : System.Web.UI.Page
    {
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
            /*
            Medico medico = (Medico)Session["Medico"];

            if (medico == null)
                return;

            MedicoNegocio medicoNegocio = new MedicoNegocio();

            medicoNegocio.Nuevo()
            */

            Response.Redirect("/Medicos");
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            var rBytes = new byte[4];
            using (var crypto = new RNGCryptoServiceProvider()) crypto.GetBytes(rBytes);
            string resultado = Convert.ToBase64String(rBytes).Replace("=", "");
            txtClave.Text = resultado;
        }
    }
}