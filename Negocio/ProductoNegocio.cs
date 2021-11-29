using System;
using System.Collections.Generic;

using ProyectoCuatrimestral.Dominio;



using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoCuatrimestral.Negocio
{
    public class ProductoNegocio
    {
        public Producto Nuevo(
            int IdMarca,
            int IdOferente,
            string Nombre,
            string Descripcion,
            int Unidades,
            decimal PrecioLista,
            Uri EnlaceIlustracion)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetParametros("@IdMarca", IdMarca);
            acceso.SetParametros("@IdOferente", IdOferente);
            acceso.SetParametros("@Nombre", Nombre);
            acceso.SetParametros("@Descripcion", Descripcion);
            acceso.SetParametros("@Unidades", Unidades);
            acceso.SetParametros("@PrecioLista", PrecioLista);
            acceso.SetParametros("@EnlaceIlustracion", EnlaceIlustracion.ToString());

            acceso.SetConsulta(
                "insert into PRODUCTOS (id_marca, id_usuario, nombre, descripcion, "
                + "unidades, precio_lista, logotipo) values (@IdMarca, @IdOferente, "
                + "@Nombre, @Descripcion, @Unidades, @PrecioLista, @EnlaceIlustracion);");

            int Id = acceso.EjecutarEscalar();

            acceso.CerrarConexion();

            if (Id != 0)
                return DesdeID(Id);

            return null;
        }
        public void Modificar(Producto producto)
        {
            AccesoDatos acceso = new AccesoDatos();
            acceso.SetParametros("@ID", producto.Id);
            acceso.SetParametros("@IdMarca", producto.MarcaProducto.Id);
            acceso.SetParametros("@IdOferente", producto.Oferente.Id);
            acceso.SetParametros("@Nombre", producto.Nombre);
            acceso.SetParametros("@Descripcion", producto.Descripcion);
            acceso.SetParametros("@Unidades", producto.Unidades);
            acceso.SetParametros("@PrecioLista", producto.PrecioLista);
            acceso.SetParametros("@EnlaceIlustracion", producto.Ilustracion.ToString());

            acceso.SetConsulta(
                "update PRODUCTOS set id_marca = @IdMarca, id_usuario = @IdOferente, "
                + "nombre = @Nombre, descripcion = @Descripcion, unidades = @Unidades, "
                + "precio_lista = @PrecioLista, logotipo = @EnlaceIlustracion "
                + "where id = @ID;");

            acceso.EjecutarAccion();
            acceso.CerrarConexion();
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
            
            bool correcto = acceso.Lector.Read();

            if (!correcto)
            {
                acceso.CerrarConexion();
                return null;
            }

            producto.Id = ID;
            if (acceso.Lector["OferenteNombre"] != null)
            {
                producto.Oferente = new Usuario(
                Convert.ToInt32(acceso.Lector["ProductoOferente"]),
                (string)acceso.Lector["OferenteNombre"],
                (bool)acceso.Lector["OferentePermisoAdministrador"],
                (bool)acceso.Lector["OferentePermisoComprar"],
                (bool)acceso.Lector["OferentePermisoVender"]);
            }
            else
            {
                producto.Oferente = null;
            }
            producto.Nombre = (string)acceso.Lector["ProductoNombre"];
            producto.Descripcion = (string)acceso.Lector["ProductoDescripcion"];
            producto.MarcaProducto = new Marca();
            if (acceso.Lector["MarcaNombre"] != null)
            {
                producto.MarcaProducto.Id = Convert.ToInt32(acceso.Lector["ProductoMarca"]);
                producto.MarcaProducto.Nombre = (string)acceso.Lector["MarcaNombre"];
            }
            else
            {
                producto.MarcaProducto = null;
            }
            producto.Unidades = Convert.ToInt32(acceso.Lector["ProductoUnidades"]);
            producto.PrecioLista = (decimal)acceso.Lector["ProductoPrecio"];
            producto.Ilustracion = new Uri((string)acceso.Lector["ProductoIlustracion"]);

            acceso.CerrarConexion();

            return producto;
        }
        public List<Producto> Listar(Usuario usuario=null)
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos acceso = new AccesoDatos();
            Producto producto;
            acceso.SetConsulta(
                "select p.id ProductoId, p.id_marca ProductoMarca, p.id_usuario ProductoOferente, p.nombre ProductoNombre, "
                + "p.descripcion ProductoDescripcion, p.unidades ProductoUnidades, p.precio_lista ProductoPrecio, "
                + "p.logotipo ProductoIlustracion, m.nombre MarcaNombre, "
                + "u.nombre OferenteNombre, u.p_admin OferentePermisoAdministrador, u.p_comprar OferentePermisoComprar, "
                + "u.p_vender OferentePermisoVender from PRODUCTOS p "
                + "left join MARCAS m on p.id_marca = m.id left join USUARIOS u on p.id_usuario = u.id"
                + (usuario == null ? "" : " where p.id_usuario = " + usuario.Id)
                + ";");

            acceso.EjecutarLectura();

            while (acceso.Lector.Read())
            {
                producto = new Producto();
                producto.Id = Convert.ToInt32(acceso.Lector["ProductoId"]);
                if (acceso.Lector["OferenteNombre"] != null)
                {
                    producto.Oferente = new Usuario(
                    Convert.ToInt32(acceso.Lector["ProductoOferente"]),
                    (string)acceso.Lector["OferenteNombre"],
                    (bool)acceso.Lector["OferentePermisoAdministrador"],
                    (bool)acceso.Lector["OferentePermisoComprar"],
                    (bool)acceso.Lector["OferentePermisoVender"]);
                }
                else
                {
                    producto.Oferente = null;
                }
                producto.Nombre = (string)acceso.Lector["ProductoNombre"];
                producto.Descripcion = (string)acceso.Lector["ProductoDescripcion"];
                producto.MarcaProducto = new Marca();
                if (acceso.Lector["MarcaNombre"] != null)
                {
                    producto.MarcaProducto.Id = Convert.ToInt32(acceso.Lector["ProductoMarca"]);
                    producto.MarcaProducto.Nombre = (string)acceso.Lector["MarcaNombre"];
                }
                else
                {
                    producto.MarcaProducto = null;
                }
                producto.Unidades = Convert.ToInt32(acceso.Lector["ProductoUnidades"]);
                producto.PrecioLista = (decimal)acceso.Lector["ProductoPrecio"];
                producto.Ilustracion = new Uri((string)acceso.Lector["ProductoIlustracion"]);
                lista.Add(producto);
            }
            
            acceso.CerrarConexion();
            
            return lista;
        }
    }
}