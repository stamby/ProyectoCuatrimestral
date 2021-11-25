using System;
using System.Collections.Generic;

using ProyectoCuatrimestral.Dominio;

namespace ProyectoCuatrimestral.Negocio
{
    public class ProductoNegocio
    {
        public Producto Nuevo (
            int IdMarca,
            int IdOferente,
            string Nombre,
            string Descripcion,
            int Unidades,
            decimal PrecioLista,
            string EnlaceIlustracion)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetParametros("@IdMarca", IdMarca);
            acceso.SetParametros("@IdOferente", IdOferente);
            acceso.SetParametros("@Nombre", Nombre);
            acceso.SetParametros("@Descripcion", Descripcion);
            acceso.SetParametros("@Unidades", Unidades);
            acceso.SetParametros("@PrecioLista", PrecioLista);
            acceso.SetParametros("@EnlaceIlustracion", EnlaceIlustracion);

            acceso.SetConsulta(
                "insert into MOVIMIENTOS (id_marca, id_oferente, nombre, descripcion, unidades, "
                + "precio_lista, logotipo) values ("
                + "@IdMarca, @IdOferente, @Nombre, @Descripcion, @Unidades, @PrecioLista, "
                + "@EnlaceIlustracion);");

            int Id = acceso.EjecutarEscalar();

            acceso.CerrarConexion();

            if (Id != 0)
                return DesdeID(Id);

            return null;
        }
        public void Borrar(int ID)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetParametros("@ID", ID);
            acceso.SetConsulta(
                "delete from PRODUCTOS where ID = @ID;");
            acceso.EjecutarAccion();
            acceso.CerrarConexion();
        }
        public Producto DesdeID(int ID)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetConsulta(
                "select p.id_marca ProductoMarca, p.id_usuario ProductoOferente, p.nombre ProductoNombre, "
                + "p.descripcion ProductoDescripcion, p.unidades ProductoUnidades, p.precio_lista ProductoPrecio, "
                + "p.logotipo ProductoIlustracion, m.nombre MarcaNombre, "
                + "u.nombre OferenteNombre, u.p_admin OferentePermisoAdministrador, u.p_comprar OferentePermisoComprar, "
                + "u.p_vender OferentePermisoVender from PRODUCTOS p "
                + "left join MARCAS m on p.id_marca = m.id left join USUARIOS u on p.id_usuario = u.id "
                + "where p.id = " + ID + ";");
            acceso.EjecutarLectura();
            Producto producto = new Producto();
            acceso.Lector.Read();
            producto.Id = ID;
            producto.Oferente = new Usuario(
                (int)acceso.Lector["ProductoOferente"],
                (string)acceso.Lector["OferenteNombre"],
                (bool)acceso.Lector["OferentePermisoAdministrador"],
                (bool)acceso.Lector["OferentePermisoComprar"],
                (bool)acceso.Lector["OferentePermisoVender"]);
            producto.Nombre = (string)acceso.Lector["ProductoNombre"];
            producto.Descripcion = (string)acceso.Lector["p.descripcion"];
            producto.MarcaProducto.Id = (int)acceso.Lector["ProductoMarca"];
            producto.MarcaProducto.Nombre = (string)acceso.Lector["MarcaNombre"];
            producto.Unidades = (int)acceso.Lector["ProductoUnidades"];
            producto.PrecioLista = (decimal)acceso.Lector["ProductoPrecio"];
            producto.Ilustracion = new Uri((string)acceso.Lector["ProductoIlustracion"]);
            
            acceso.CerrarConexion();

            return producto;
        }
        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos acceso = new AccesoDatos();
            Producto producto;
            try
            {
                acceso.SetConsulta(
                    "select p.id ProductoId, p.id_marca ProductoMarca, p.id_usuario ProductoOferente, p.nombre ProductoNombre, "
                    + "p.descripcion ProductoDescripcion, p.unidades ProductoUnidades, p.precio_lista ProductoPrecio, "
                    + "p.logotipo ProductoIlustracion, m.nombre MarcaNombre, "
                    + "u.nombre OferenteNombre, u.p_admin OferentePermisoAdministrador, u.p_comprar OferentePermisoComprar, "
                    + "u.p_vender OferentePermisoVender from PRODUCTOS p "
                    + "left join MARCAS m on p.id_marca = m.id left join USUARIOS u on p.id_usuario = u.id;");
                acceso.EjecutarLectura();

                while (acceso.Lector.Read())
                {
                    producto = new Producto();
                    producto.Id = (int)acceso.Lector["ProductoId"];
                    producto.Oferente = new Usuario(
                        (int)acceso.Lector["ProductoOferente"],
                        (string)acceso.Lector["OferenteNombre"],
                        (bool)acceso.Lector["OferentePermisoAdministrador"],
                        (bool)acceso.Lector["OferentePermisoComprar"],
                        (bool)acceso.Lector["OferentePermisoVender"]);
                    producto.Nombre = (string)acceso.Lector["ProductoNombre"];
                    producto.Descripcion = (string)acceso.Lector["ProductoDescripcion"];
                    producto.MarcaProducto.Id = (int)acceso.Lector["ProductoMarca"];
                    producto.MarcaProducto.Nombre = (string)acceso.Lector["MarcaNombre"];
                    producto.Unidades = (int)acceso.Lector["ProductoUnidades"];
                    producto.PrecioLista = (decimal)acceso.Lector["ProductoPrecio"];
                    producto.Ilustracion = new Uri((string)acceso.Lector["ProductoIlustracion"]);
                    lista.Add(producto);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.CerrarConexion();
            }

            return lista;
        }
    }
}