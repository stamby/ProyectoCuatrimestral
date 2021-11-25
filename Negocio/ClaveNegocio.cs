using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ProyectoCuatrimestral.Dominio;

namespace ProyectoCuatrimestral.Negocio
{
    public class ClaveNegocio
    {
        public Clave Nuevo(Usuario UsuarioRegistrado, string Secreto)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetParametros("@UsuarioRegistrado", UsuarioRegistrado);
            acceso.SetParametros("@Secreto", Secreto);
            acceso.SetConsulta(
                "insert into CLAVES (id_usuario, clave) values "
                + "(@UsuarioRegistrado, @Secreto);");
            Clave clave = new Clave();
            clave.Id = acceso.EjecutarEscalar();
            clave.UsuarioRegistrado = UsuarioRegistrado;
            clave.Secreto = Secreto;
            acceso.CerrarConexion();

            return clave;
        }
        public void Modificar(Clave clave)
        {
            AccesoDatos acceso = new AccesoDatos();

            acceso.SetParametros("@ID", clave.Id);
            acceso.SetParametros("@UsuarioRegistrado", clave.UsuarioRegistrado.Id);
            acceso.SetParametros("@Secreto", clave.Secreto);

            acceso.SetConsulta(
                "update CLAVES set id_usuario = @UsuarioRegistrado, "
                + "clave = @Secreto where id = @ID;");

            acceso.EjecutarAccion();
            acceso.CerrarConexion();
        }
        public Clave DesdeUsuario(Usuario usuario)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetConsulta(
                "select id, clave from CLAVES where id_usuario = " +
                usuario.Id + ";");
            acceso.EjecutarLectura();
            Clave clave = new Clave();

            bool correcto = acceso.Lector.Read();

            if (correcto)
            {
                clave.Id = Convert.ToInt32(acceso.Lector["id"]);
                clave.UsuarioRegistrado = usuario;
                clave.Secreto = (string)acceso.Lector["clave"];

                acceso.CerrarConexion();
            }
            else
            {
                acceso.CerrarConexion();
                return null;
            }

            return clave;
        }
        /* El borrado se realiza al eliminar un usuario */
    }
}