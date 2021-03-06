using System;
using System.Collections.Generic;

using ProyectoCuatrimestral.Dominio;

namespace ProyectoCuatrimestral.Negocio
{
    public class UsuarioNegocio
    {
        public Usuario Nuevo(
            string Nombre,
            bool PermisoAdmin,
            bool PermisoComprar,
            bool PermisoVender)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetParametros("@Nombre", Nombre);
            acceso.SetParametros("@PermisoAdmin", PermisoAdmin);
            acceso.SetParametros("@PermisoComprar", PermisoComprar);
            acceso.SetParametros("@PermisoVender", PermisoVender);
            acceso.SetConsulta(
                "insert into USUARIOS (nombre, p_admin, p_comprar, p_vender) values ("
                + "@Nombre, @PermisoAdmin, @PermisoComprar, @PermisoVender);");

            int Id = acceso.EjecutarEscalar();

            acceso.CerrarConexion();

            if (Id != 0)
                return DesdeID(Id);

            return null;
        }
        public void Modificar(Usuario usuario)
        {
            AccesoDatos acceso = new AccesoDatos();

            acceso.SetParametros("@ID", usuario.Id);
            acceso.SetParametros("@Nombre", usuario.Nombre);
            acceso.SetParametros("@PermisoAdmin", usuario.PermisoAdmin);
            acceso.SetParametros("@PermisoComprar", usuario.PermisoComprar);
            acceso.SetParametros("@PermisoVender", usuario.PermisoVender);

            acceso.SetConsulta(
                "update USUARIOS set nombre = @Nombre, p_admin = @PermisoAdmin, "
                + "p_comprar = @PermisoComprar, p_vender = @PermisoVender "
                + "where id = @ID;");

            acceso.EjecutarAccion();
            acceso.CerrarConexion();
        }
        public void Borrar(int ID)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetParametros("@ID", ID);
            acceso.SetConsulta(
                "delete from USUARIOS where ID = @ID;");
            acceso.EjecutarAccion();
            acceso.CerrarConexion();
        }
        public Usuario DesdeID(int ID)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetConsulta(
                "select nombre, p_admin, p_comprar, p_vender from USUARIOS where id = " +
                ID + ";");

            acceso.EjecutarLectura();

            Usuario usuario = new Usuario();

            usuario.Id = ID;

            bool correcto = acceso.Lector.Read();

            if (correcto)
            {
                usuario.Nombre = (string)acceso.Lector["nombre"];
                usuario.PermisoAdmin = (bool)acceso.Lector["p_admin"];
                usuario.PermisoComprar = (bool)acceso.Lector["p_comprar"];
                usuario.PermisoVender = (bool)acceso.Lector["p_vender"];

                acceso.CerrarConexion();
            }
            else
            {
                acceso.CerrarConexion();
                return null;
            }

            return usuario;
        }
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos acceso = new AccesoDatos();
            
            acceso.SetConsulta(
                "select id, nombre, p_admin, p_comprar, p_vender from USUARIOS");
            acceso.EjecutarLectura();

            while (acceso.Lector.Read())
            {
                lista.Add(new Usuario(
                    Convert.ToInt32(acceso.Lector["id"]),
                    (string)acceso.Lector["nombre"],
                    (bool)acceso.Lector["p_admin"],
                    (bool)acceso.Lector["p_comprar"],
                    (bool)acceso.Lector["p_vender"]));
            }
            acceso.CerrarConexion();

            return lista;
        }
        public Usuario Ingresar(string strUsuario, string strClave)
        {
            Usuario usuario = new Usuario();
            Clave clave = new Clave();

            AccesoDatos acceso = new AccesoDatos();

            acceso.SetParametros("@Nombre", strUsuario);
            acceso.SetParametros("@Secreto", strClave);

            acceso.SetConsulta(
                "select u.id IdUsuario, u.nombre NombreUsuario, u.p_admin Administrador, "
                + "u.p_comprar PuedeComprar, u.p_vender PuedeVender, "
                + "c.id IdClave, c.clave Secreto from USUARIOS u "
                + "left join CLAVES c on u.id = c.id_usuario "
                + "where u.nombre = @Nombre and c.clave = @Secreto;");

            acceso.EjecutarLectura();

            if (acceso.Lector.Read())
            {
                usuario.Id = Convert.ToInt32(acceso.Lector["IdUsuario"]);
                usuario.Nombre = (string)acceso.Lector["NombreUsuario"];
                usuario.PermisoAdmin = (bool)acceso.Lector["Administrador"];
                usuario.PermisoComprar = (bool)acceso.Lector["PuedeComprar"];
                usuario.PermisoVender = (bool)acceso.Lector["PuedeVender"];

                clave.Id = Convert.ToInt32(acceso.Lector["IdClave"]);
                clave.Secreto = (string)acceso.Lector["Secreto"];

                acceso.CerrarConexion();
            }
            else
            {
                acceso.CerrarConexion();
                return null;
            }
            
            return usuario;
        }
    }
}